using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public partial class Options : Form
    {
        private int currentButtonIndex = 0;

        private List<Button> menuButtons = new List<Button>();
         
        private Button selectedButton = new Button();

        public Options()
        {
            InitializeComponent();

            Cursor.Hide();

            this.KeyPreview = true;
            this.ClientSize = new Size(Consts.FORM_WIDTH, Consts.FORM_HEIGHT);
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            btnShip.Location = new Point(Consts.FORM_WIDTH / 2 - btnShip.Width / 2, Consts.MARGIN_TOP);
            btnShip.BackColor = Color.Black;
            btnShip.ForeColor = Color.White;
            btnShip.Font = Globals.defaultFont;
            btnShip.Text = $"SHIP\n{char.ConvertFromUtf32(0x2190)} {Globals.spaceships[Globals.selectedSpaceship].Name} " +
                           $"{char.ConvertFromUtf32(0x2192)}";
            btnShip.FlatStyle = FlatStyle.Flat;
            btnShip.FlatAppearance.BorderColor = Color.White;
            btnShip.FlatAppearance.BorderSize = 0;
            btnShip.Width = Consts.BUTTON_WIDTH;
            btnShip.Height = Consts.BUTTON_HEIGHT;
            btnShip.TextAlign = ContentAlignment.MiddleCenter;


            btnLevel.Location = new Point(Consts.FORM_WIDTH / 2 - btnLevel.Width / 2,
                                  btnShip.Location.Y + Consts.BUTTON_HEIGHT + Consts.BUTTON_GAP);
            btnLevel.BackColor = Color.Black;
            btnLevel.ForeColor = Color.White;
            btnLevel.Font = Globals.defaultFont;
            btnLevel.Text = $"LEVEL\n{char.ConvertFromUtf32(0x2190)} {Globals.selectedLevel} {char.ConvertFromUtf32(0x2192)}";
            btnLevel.FlatStyle = FlatStyle.Flat;
            btnLevel.FlatAppearance.BorderColor = Color.White;
            btnLevel.FlatAppearance.BorderSize = 0;
            btnLevel.Width = Consts.BUTTON_WIDTH;
            btnLevel.Height = Consts.BUTTON_HEIGHT;
            btnLevel.TextAlign = ContentAlignment.MiddleCenter;

            btnBack.Location = new Point(Consts.FORM_WIDTH / 2 - btnBack.Width / 2,
                               btnLevel.Location.Y + Consts.BUTTON_HEIGHT + Consts.BUTTON_GAP);
            btnBack.BackColor = Color.Black;
            btnBack.ForeColor = Color.White;
            btnBack.Font = Globals.defaultFont;
            btnBack.Text = "BACK";
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderColor = Color.White;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Width = Consts.BUTTON_WIDTH;
            btnBack.Height = Consts.BUTTON_HEIGHT;
            btnBack.TextAlign = ContentAlignment.MiddleCenter;
            // Label on the btnShip to display selected ship's name
            lblShip.BackColor = Color.Black;
            lblShip.ForeColor = Globals.spaceships[Globals.selectedSpaceship].Color;
            lblShip.Font = Globals.defaultFont;
            lblShip.Text = Globals.spaceships[Globals.selectedSpaceship].Name;
            lblShip.Location = new Point(Consts.FORM_WIDTH / 2 - lblShip.Width / 2, Consts.MARGIN_TOP + Consts.LABEL_OFF);
            lblShip.TextAlign = ContentAlignment.MiddleCenter;

            menuButtons.Add(btnShip);
            menuButtons.Add(btnLevel);
            menuButtons.Add(btnBack);

            menuButtons[currentButtonIndex].FlatAppearance.BorderSize = 1;

        }

        private void Options_KeyDown(object sender, KeyEventArgs e)
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

                case Keys.Left:
                    if (currentButtonIndex == 0)
                    {
                        if (Globals.selectedSpaceship > 0)
                        {
                            Globals.selectedSpaceship--;
                        }
                        else if (Globals.selectedSpaceship <= 0)
                        {
                            Globals.selectedSpaceship = Globals.spaceships.Count - 1;
                        }
                        // Update text with newly selected ship's info
                        lblShip.Text = Globals.spaceships[Globals.selectedSpaceship].Name;
                        lblShip.Location = new Point(Consts.FORM_WIDTH / 2 - lblShip.Width / 2, Consts.MARGIN_TOP + Consts.LABEL_OFF);
                        lblShip.ForeColor = Globals.spaceships[Globals.selectedSpaceship].Color;

                        btnShip.Text = $"SHIP\n{char.ConvertFromUtf32(0x2190)} {Globals.spaceships[Globals.selectedSpaceship].Name} " +
                               $"{char.ConvertFromUtf32(0x2192)}";
                    }

                    if (currentButtonIndex == 1)
                    {
                        if (Globals.selectedLevel > 0)
                        {
                            Globals.selectedLevel--;
                        }
                        else if (Globals.selectedLevel <= 0)
                        {
                            Globals.selectedLevel = Globals.allLevels.Count - 1;
                        }
                        // Update text with newly selected level's index
                        btnLevel.Text = $"LEVEL\n{char.ConvertFromUtf32(0x2190)} {Globals.selectedLevel} {char.ConvertFromUtf32(0x2192)}";
                    }

                    SoundEffects.button.Play();
                    break;

                case Keys.Right:
                    if (currentButtonIndex == 0)
                    {
                        if (Globals.selectedSpaceship < Globals.spaceships.Count - 1)
                        {
                            Globals.selectedSpaceship++;
                        }
                        else if (Globals.selectedSpaceship >= Globals.spaceships.Count - 1)
                        {
                            Globals.selectedSpaceship = 0;
                        }
                        // Update text with newly selected ship's info
                        lblShip.Text = Globals.spaceships[Globals.selectedSpaceship].Name;
                        lblShip.Location = new Point(Consts.FORM_WIDTH / 2 - lblShip.Width / 2, Consts.MARGIN_TOP + Consts.LABEL_OFF);
                        lblShip.ForeColor = Globals.spaceships[Globals.selectedSpaceship].Color;

                        btnShip.Text = $"SHIP\n{char.ConvertFromUtf32(0x2190)} {Globals.spaceships[Globals.selectedSpaceship].Name} " +
                               $"{char.ConvertFromUtf32(0x2192)}";
                    }

                    if (currentButtonIndex == 1)
                    {
                        if (Globals.selectedLevel < Globals.allLevels.Count - 1)
                        {
                            Globals.selectedLevel++;
                        }
                        else if (Globals.selectedLevel >= Globals.allLevels.Count - 1)
                        {
                            Globals.selectedLevel = 0;
                        }
                        // Update text with newly selected level's index
                        btnLevel.Text = $"LEVEL\n{char.ConvertFromUtf32(0x2190)} {Globals.selectedLevel} {char.ConvertFromUtf32(0x2192)}";
                    }

                    SoundEffects.button.Play();
                    break;

                case Keys.Enter:
                    if (currentButtonIndex == 2)
                    {
                        SoundEffects.button.Play();
                        this.Hide();
                        Menu menu = new Menu();
                        menu.Show();
                    }
                    break;
            }
            // Setting border for the newly selected button
            menuButtons[currentButtonIndex].FlatAppearance.BorderSize = 1; 
        }
    }
}
