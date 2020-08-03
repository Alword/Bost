namespace McAI.BOT.Model.AStar
{
    public struct PathFinderConfig
    {
        public bool canWalk;
        public bool canJump;
        public bool canFall;
        public bool canSwim;

        public int MaxFallDistance;
        public int JumpHeight;
        public int JumpDistance;

        public int CharacterHeight;

        public static PathFinderConfig Default => new PathFinderConfig
        {
            canWalk = true,
            canJump = true,
            canFall = true,
            canSwim = false,
            MaxFallDistance = 1,
            JumpHeight = 1,
            JumpDistance = 3,
            CharacterHeight = 2
        };

    }
}
