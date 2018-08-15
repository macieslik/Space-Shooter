using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Menu : Form
    {
        int currentButtonIndex = 0;

        List<Button> menuButtons = new List<Button>();

        Button selectedButton = new Button();

        public Menu()
        {
            InitializeComponent();

            Cursor.Hide();

            this.KeyPreview = true;
            this.ClientSize = new Size(Consts.FORM_WIDTH, Consts.FORM_HEIGHT);
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            btnPlay.Location = new Point(Consts.FORM_WIDTH / 2 - btnPlay.Width / 2, Consts.MARGIN_TOP);
            btnPlay.BackColor = Color.Black;
            btnPlay.ForeColor = Color.White;
            btnPlay.Font = Globals.defaultFont;
            btnPlay.Text = "PLAY";
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.FlatAppearance.BorderColor = Color.White;
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.Width = Consts.BUTTON_WIDTH;
            btnPlay.Height = Consts.BUTTON_HEIGHT;
            btnPlay.TextAlign = ContentAlignment.MiddleCenter;
            
            btnOptions.Location = new Point(Consts.FORM_WIDTH / 2 - btnOptions.Width / 2, 
                                  btnPlay.Location.Y + Consts.BUTTON_HEIGHT + Consts.BUTTON_GAP);
            btnOptions.BackColor = Color.Black;
            btnOptions.ForeColor = Color.White;
            btnOptions.Font = Globals.defaultFont;
            btnOptions.Text = "OPTIONS";
            btnOptions.FlatStyle = FlatStyle.Flat;
            btnOptions.FlatAppearance.BorderColor = Color.White;
            btnOptions.FlatAppearance.BorderSize = 0;
            btnOptions.Width = Consts.BUTTON_WIDTH;
            btnOptions.Height = Consts.BUTTON_HEIGHT;
            btnOptions.TextAlign = ContentAlignment.MiddleCenter;

            btnExit.Location = new Point(Consts.FORM_WIDTH / 2 - btnExit.Width / 2, 
                               btnOptions.Location.Y + Consts.BUTTON_HEIGHT + Consts.BUTTON_GAP);
            btnExit.BackColor = Color.Black;
            btnExit.ForeColor = Color.White;
            btnExit.Font = Globals.defaultFont;
            btnExit.Text = "EXIT";
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderColor = Color.White;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.Width = Consts.BUTTON_WIDTH;
            btnExit.Height = Consts.BUTTON_HEIGHT;
            btnExit.TextAlign = ContentAlignment.MiddleCenter;

            menuButtons.Add(btnPlay);
            menuButtons.Add(btnOptions);
            menuButtons.Add(btnExit);

            menuButtons[currentButtonIndex].FlatAppearance.BorderSize = 1;
        }

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            // Removing border from the previous button
            menuButtons[currentButtonIndex].FlatAppearance.BorderSize = 0;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (currentButtonIndex > 0)
                    {
                        currentButtonIndex--;
                    }
                    else if (currentButtonIndex <= 0)
                    {
                        currentButtonIndex = menuButtons.Count - 1;
                    }
                    SoundEffects.button.Play();
                    break;

                case Keys.Down:
                    if (currentButtonIndex < menuButtons.Count - 1)
                    {
                        currentButtonIndex++;
                    }
                    else if (currentButtonIndex >= menuButtons.Count - 1)
                    {
                        currentButtonIndex = 0;
                    }
                    SoundEffects.button.Play();
                    break;

                case Keys.Enter:
                    switch (currentButtonIndex)
                    {
                        case 0:
                            this.Hide();
                            Play play = new Play();
                            play.Show();
                            break;
                        case 1:
                            this.Hide();
                            Options options = new Options();
                            options.Show();
                            break;
                        case 2:
                            this.Close();
                            break;
                    }
                    SoundEffects.button.Play();
                    break;
            }
            // Setting border for the newly selected button
            menuButtons[currentButtonIndex].FlatAppearance.BorderSize = 1;
        }
    }
}
