using Game.Enumerations;
using System.Drawing;

namespace Game.Aliens
{
    public class Heavy : Alien
    {
        public Heavy()
        {
            base.Hp = Consts.ALIEN_HEAVY_HP;
            base.Type = AlienType.Heavy;
            base.Color = Color.Purple;
        }
    }
}
