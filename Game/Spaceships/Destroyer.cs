using Game.Enumerations;
using System.Drawing;

namespace Game.Spaceships
{
    public class Destroyer : Spaceship
    {
        public Color colorDestroyer = Color.Yellow;

        public Destroyer()
        {
            base.Speed = Consts.Destroyer.SPEED;
            base.MissileSpeed = Consts.Destroyer.MISSILE_SPEED;
            base.Name = Consts.Destroyer.NAME;
            base.Color = colorDestroyer;
            base.Type = SpaceshipType.Destroyer;
        }
    }
}
