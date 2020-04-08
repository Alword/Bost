﻿using McAI.BOT.Enum;
using McAI.BOT.Extentions;
using McAI.BOT.Types;
using McAI.Proto.Mapping.Generator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace McAI.BOT.Model.AStar
{
    public class Pathfinder
    {
        private static readonly int STRAIGHT_COST = 10;
        private static readonly int DIAGONAL_COST = 14;

        private static readonly int maxEstimatePath = 1500;
        private static readonly int maxNodes = 6000;

        private List<PathNode> openList;
        private List<Int3> closedList;

        private readonly World world;
        private readonly PathFinderConfig pathFinderConfig;
        public Pathfinder(World world, PathFinderConfig config)
        {
            this.world = world;
            this.pathFinderConfig = config;
        }

        public List<PathNode> FindPath(Double3 beginPoint, Double3 targetPoint)
        {
            Int3 beginBlock = beginPoint.BlockPosition();
            Int3 targetBlock = targetPoint.BlockPosition();

            var startNode = new PathNode(beginBlock, 0, (int)beginPoint.Distance(targetPoint), MoveActions.Walk);
            openList = new List<PathNode> { startNode };
            closedList = new List<Int3>();

            startNode.GCost = 0;
            startNode.HCost = CalculateDistanceCost(startNode.Position, targetBlock);

            while (openList.Count > 0)
            {
                PathNode currentNode = GetLowestFCostNode(openList);
                if (currentNode.Position == targetBlock)
                {
                    // Reached final node
                    return CalculatePath(currentNode);
                }
                openList.Remove(currentNode);
                closedList.Add(currentNode.Position);

                foreach (PathNode neighbourNode in GetNeighbourList(currentNode))
                {
                    if (closedList.Contains(neighbourNode.Position)) continue;

                    int tententiveGCos = currentNode.GCost + CalculateDistanceCost(currentNode.Position, neighbourNode.Position);
                    if (tententiveGCos < neighbourNode.GCost)
                    {
                        neighbourNode.cameFromNode = currentNode;
                        neighbourNode.GCost = tententiveGCos;
                        neighbourNode.HCost = CalculateDistanceCost(neighbourNode.Position, targetBlock);
                        neighbourNode.CalculateFCost();

                        if (!openList.Contains(neighbourNode))
                        {
                            openList.Add(neighbourNode);
                        }
                    }
                }

            }

            return null;
        }

        private int CalculateDistanceCost(Int3 a, Int3 b)
        {
            double xDistance = Math.Abs(a.X - b.X);
            double yDistance = Math.Abs(a.Y - b.Y);
            double zDistance = Math.Abs(a.Z - b.Z);

            double remaining = Math.Abs(xDistance - yDistance - zDistance);
            double minStrait = Math.Min(Math.Min(xDistance, yDistance), zDistance);

            return (int)Math.Round(minStrait * DIAGONAL_COST + STRAIGHT_COST * remaining);
        }

        private PathNode GetLowestFCostNode(List<PathNode> pathNodes)
        {
            PathNode lowestFCostNode = pathNodes[0];
            for (int i = 1; i < pathNodes.Count; i++)
            {
                if (pathNodes[i].FCost < lowestFCostNode.FCost)
                {
                    lowestFCostNode = pathNodes[i];
                }
            }
            return lowestFCostNode;
        }

        private List<PathNode> CalculatePath(PathNode endNode)
        {
            List<PathNode> path = new List<PathNode> { endNode };
            PathNode currentNode = endNode;
            while (currentNode.cameFromNode != null)
            {
                currentNode = currentNode.cameFromNode;
                path.Add(currentNode);
            }
            path.Reverse();
            return path;
        }

        private List<PathNode> GetNeighbourList(PathNode currentNode)
        {
            List<PathNode> neighbourList = new List<PathNode>();

            Dictionary<Int3, PathNode> located = new Dictionary<Int3, PathNode>(81)
            {
                { currentNode.Position, currentNode }
            };

            Dictionary<Int3, BlockState> dictionary = FindNeighbour(currentNode.Position, new HashSet<Int3>());

            return dictionary.Select(d => new PathNode() { Position = d.Key }).ToList();
        }

        private Dictionary<Int3, BlockState> FindNeighbour(Int3 position, HashSet<Int3> chache)
        {
            Dictionary<Int3, BlockState> neigbourNodes = new Dictionary<Int3, BlockState>();
            List<Int3> keys = new List<Int3>
            {
                position + Int3.Forward,
                position + Int3.Backward,
                position + Int3.Right,
                position + Int3.Left,
                position + Int3.Forward + Int3.Right,
                position + Int3.Forward + Int3.Left,
                position + Int3.Backward + Int3.Right,
                position + Int3.Backward + Int3.Left
            };
            List<Int3> notChecked = new List<Int3>();
            foreach (var key in keys)
            {
                if (!chache.Contains(key))
                {
                    chache.Add(key);
                    notChecked.Add(key);
                }
            }
            foreach (Int3 key in notChecked)
            {
                NodeState state = IsSuitable(key, out BlockState blockState1);
                if (state == NodeState.Suitable)
                {
                    neigbourNodes.Add(key, blockState1);
                }
                else
                {
                    if (state == NodeState.Blocker)
                    {
                        Int3 blockVector = (key - position).AsXZVector();
                        Int3 blockKey = key;
                        int i = 1;
                        while (Math.Abs(blockKey.X) < 5 &&
                            Math.Abs(blockKey.Z) < 5 &&
                            Math.Abs(blockKey.X + blockKey.Z) < 8)
                        {
                            chache.Add(blockVector);
                            i += 1;
                            blockKey += blockVector * i;
                        }
                    }
                    FindNeighbour(key, chache);
                }
            }
            return neigbourNodes;
        }

        private NodeState IsSuitable(Int3 position, out BlockState blockState)
        {
            blockState = world[position];

            if (blockState.Id == 0) // Block is air
                return NodeState.Empty;

            if (blockState.Id != 0 && world[position + Int3.Up].Id == 0 && world[position + Int3.Up * 2].Id == 0)
                return NodeState.Suitable;

            return NodeState.Blocker;
        }
    }
}