using McAI.BOT.Enum;
using McAI.BOT.Extentions;
using McAI.BOT.Types;
using McAI.Proto.Mapping.Generator;
using System;
using System.Collections.Generic;
using System.Data;
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
        private List<PathNode> closedList;

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

            var startNode = new PathNode(beginBlock, 0, beginPoint.Distance(targetPoint), MoveActions.Walk);
            openList = new List<PathNode> { startNode };
            closedList = new List<PathNode>();

            startNode.LenghtFromStart = 0;
            startNode.HeuristicPathLenght = CalculateDistanceCost(startNode.Position, targetBlock);

            while (openList.Count > 0)
            {
                PathNode currentNode = GetLowestFCostNode(openList);
                if (currentNode.Position == targetBlock)
                {
                    // Reached final node
                    return CalculatePath(currentNode);
                }
                openList.Remove(currentNode);
                closedList.Add(currentNode);

            }

            // "Стоп сигнал" для нашего поиска
            Console.WriteLine("Nodes created " + closedList.Count.ToString());

            return path;
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
                if (pathNodes[i].FullPathLenght < lowestFCostNode.FullPathLenght)
                {
                    lowestFCostNode = pathNodes[i];
                }
            }
            return lowestFCostNode;
        }

        public List<PathNode> CalculatePath(PathNode pathNode)
        {
            throw new NotImplementedException();
        }

        private List<PathNode> GetNeighbourList(PathNode currentNode)
        {
            List<PathNode> neighbourList = new List<PathNode>();

            Dictionary<Int3, PathNode> located = new Dictionary<Int3, PathNode>(81)
            {
                { currentNode.Position, currentNode }
            };

            BlockState x1 = world[currentNode.Position + Int3.Forward];
            BlockState x2 = world[currentNode.Position + Int3.Backward];
            BlockState x3 = world[currentNode.Position + Int3.Right];
            BlockState x4 = world[currentNode.Position + Int3.Left];
            BlockState x5 = world[currentNode.Position + Int3.Right + Int3.Forward];
            BlockState x6 = world[currentNode.Position + Int3.Right + Int3.Backward];
            BlockState x7 = world[currentNode.Position + Int3.Left + Int3.Forward];
            BlockState x8 = world[currentNode.Position + Int3.Left + Int3.Backward];
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
                if (chache.Contains(key))
                {
                }
                else
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
                        Int3 blockVector = key - position;

                        blockVector.AsXZVector();

                        int i = 0;
                        while (blockVector.X < 5 && blockVector.X < 5 && blockVector.X + blockVector.Y < 8)
                        {
                            chache.Add(key + blockVector * i);
                            i += 1;
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
