using Game.Enumerations;
using System.Drawing;

namespace Game.Spaceships
{
    public class Scout : Spaceship
    {
        public Color colorScout = Color.Green;

        public Scout()
        {
            base.Speed = Consts.Scout.SPEED;
            base.MissileSpeed = Consts.Scout.MISSILE_SPEED;
            base.Name = Consts.Scout.NAME;
            base.Color = colorScout;
            base.Type = SpaceshipType.Scout;
        }
    }
}
