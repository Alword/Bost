using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.BOT.Model
{
    public class Player : Transform
    {
        public Guid UUID { get; set; }
        public int Health { get; set; }
        public int Food { get; set; }
        public float FoodS { get; set; }
        public Inventory Inventory { get; set; }
    }
}
