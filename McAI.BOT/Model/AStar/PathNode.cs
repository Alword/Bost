using McAI.BOT.Types;

namespace McAI.BOT.Model.AStar
{
    public enum MoveActions { Walk, Jump, Fall, Swim, Stairs };

    public class PathNode
    {
        public Int3 Position { get; set; }
        public double LenghtFromStart { get; set; }
        public double HeuristicPathLenght { get; set; }
        public double FullPathLenght
        {
            get
            {
                return this.HeuristicPathLenght + this.LenghtFromStart;
            }
        }
        // способ движения
        public MoveActions moveAction = MoveActions.Walk;
        // точка из которой пришли сюда
        public PathNode cameFrom;

        public PathNode() { }

        public PathNode(Int3 point, double pathLenghtFromStart, double heuristicEstimatePathLenght, MoveActions moveAction, PathNode cameFrom = null)
        {
            this.Position = point;
            this.LenghtFromStart = pathLenghtFromStart;
            this.HeuristicPathLenght = heuristicEstimatePathLenght;
            this.moveAction = moveAction;
            this.cameFrom = cameFrom;
        }
    }
}
