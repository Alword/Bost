using System;
using System.Collections.Generic;

namespace McAI.BOT.Model.AStar
{
    public enum MoveActions { Walk, Jump, Fall, Swim, Stairs };

    public class PathNode
    {
        public Int3 Position { get; set; }
        public int GCost { get; set; }
        public int HCost { get; set; }
        public int FCost { get; set; }
        public void CalculateFCost()
        {
            FCost = HCost + GCost;
        }

        public override bool Equals(object obj)
        {
            return obj is PathNode node &&
                   EqualityComparer<Int3>.Default.Equals(Position, node.Position);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Position);
        }

        // способ движения
        public MoveActions moveAction = MoveActions.Walk;
        // точка из которой пришли сюда
        public PathNode cameFromNode;

        public PathNode() { }

        public PathNode(Int3 point, int pathLenghtFromStart, int heuristicEstimatePathLenght, MoveActions moveAction, PathNode cameFrom = null)
        {
            this.Position = point;
            this.GCost = pathLenghtFromStart;
            this.HCost = heuristicEstimatePathLenght;
            this.moveAction = moveAction;
            this.cameFromNode = cameFrom;
        }
    }
}
