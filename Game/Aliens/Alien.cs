
using Game.Enumerations;
using System.Drawing;

namespace Game.Aliens
{
    public class Alien
    {
        private int x;
        private int y;
        private int rightEdge;
        private int bottomEdge;
        private int hp;

        private Color color;

        private AlienType type;

        private bool firstInCol = false;

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }
        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }
        public int RightEdge
        {
            get
            {
                return this.rightEdge;
            }
            set
            {
                this.rightEdge = value;
            }
        }
        public int BottomEdge
        {
            get
            {
                return this.bottomEdge;
            }
            set
            {
                this.bottomEdge = value;
            }
        }
        public int Hp
        {
            get
            {
                return this.hp;
            }
            set
            {
                this.hp = value;
            }
        }

        public Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        public AlienType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public bool FirstInCol
        {
            get
            {
                return this.firstInCol;
            }
            set
            {
                this.firstInCol = value;
            }
        }

        public Alien()
        {

        }
    }
}
