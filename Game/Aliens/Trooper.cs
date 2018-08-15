using Game.Enumerations;
using System.Drawing;

namespace Game.Aliens
{
    public class Trooper : Alien
    {
        public Trooper()
        {
            base.Hp = Consts.ALEIN_TROOPER_HP;
            base.Type = AlienType.Trooper;
            base.Color = Color.MediumVioletRed;
        }
    }
}
