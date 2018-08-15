using Game.Enumerations;
using System.Drawing;

namespace Game.Spaceships
{
    public abstract class Spaceship
    {
        private int x = (Consts.FORM_WIDTH / 2) - (Consts.PLAYER_WIDTH / 2);
        private int rightEdge;
        private int speed;
        private int missileSpeed;

        private string name;

        private SpaceshipType type;

        private Color color;

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
        public int Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                this.speed = value;
            }
        }
        public int MissileSpeed
        {
            get
            {
                return this.missileSpeed;
            }
            set
            {
                this.missileSpeed = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public SpaceshipType Type
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

        public void Shoot()
        {
            Globals.missileY = Consts.PLAYER_Y - Consts.MISSILE_HEIGHT;
            Globals.missileFired = true;
        }

        public Spaceship()
        {
            
        }
    }
}
