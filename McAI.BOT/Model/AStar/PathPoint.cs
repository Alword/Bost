using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.BOT.Model.AStar
{
    public enum EMoveAction { walk, jump, fall, swim, stairs };

    public class PathPoint
    {
        // текущая точка
        public Vector3 point { get; set; }
        // расстояние от старта
        public float pathLenghtFromStart { get; set; }
        // примерное расстояние до цели
        public float heuristicEstimatePathLenght { get; set; }
        // еврестическое расстояние до цели
        public float estimateFullPathLenght
        {
            get
            {
                return this.heuristicEstimatePathLenght + this.pathLenghtFromStart;
            }
        }
        // способ движения
        public EMoveAction moveAction = EMoveAction.walk;
        // точка из которой пришли сюда
        public PathPoint cameFrom;
    }
}
