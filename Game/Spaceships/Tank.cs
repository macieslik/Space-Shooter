using Game.Enumerations;
using System.Drawing;

namespace Game.Spaceships
{
    public class Tank : Spaceship
    {
        public static Color colorTank = Color.Blue;

        public Tank()
        {
            base.Speed = Consts.Tank.SPEED;
            base.MissileSpeed = Consts.Tank.MISSILE_SPEED;
            base.Name = Consts.Tank.NAME;
            base.Color = colorTank;
            base.Type = SpaceshipType.Tank;
        }
    }
}
