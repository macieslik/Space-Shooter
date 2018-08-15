using Game.Enumerations;
using System.Drawing;

namespace Game.Aliens
{
    public class Light : Alien
    {
        public Light()
        {
            base.Hp = Consts.ALIEN_LIGHT_HP;
            base.Type = AlienType.Light;
            base.Color = Color.Red;
        }
    }
}
