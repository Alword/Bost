namespace McAI.BOT.Model
{
    public class Transform
    {
        public Position Position { get; set; }

        public Rotation Rotation { get; set; }

        public bool OnGround { get; set; }

        public Transform()
        {
            Position = new Position();
            Rotation = new Rotation();
        }
    }
}
