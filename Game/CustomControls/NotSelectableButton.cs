using System.Windows.Forms;

namespace Game.CustomControls
{
    public class NotSelectableButton : Button
    {
        public NotSelectableButton()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
