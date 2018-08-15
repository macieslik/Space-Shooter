using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Game
{
    public partial class Leaderboards : Form
    {
        private Font victoryFont = new Font("Tahoma", 30);

        public Leaderboards()
        {
            InitializeComponent();

            Cursor.Hide();

            this.KeyPreview = true;
            this.ClientSize = new Size(Consts.FORM_WIDTH, Consts.FORM_HEIGHT);
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            lblVictory.BackColor = Color.Black;
            lblVictory.ForeColor = Color.White;
            lblVictory.Font = victoryFont;
            lblVictory.Text = Globals.message;
            lblVictory.Location = new Point(Consts.FORM_WIDTH / 2 - lblVictory.Width / 2, Consts.LEADERBOARDS_GAP);

            // Extracting the last record, which will be the one from the just finished game
            var currentRecord = Globals.allRecords.Skip(Globals.allRecords.Count() - 1).FirstOrDefault();

            lblCurrentScore.BackColor = Color.Black;
            lblCurrentScore.ForeColor = Globals.spaceships[Globals.selectedSpaceship].Color;
            lblCurrentScore.Font = Globals.defaultFont;
            lblCurrentScore.Text = $"YOU HAVE SCORED {currentRecord.Score} WITH {currentRecord.SpaceshipName}";
            lblCurrentScore.Location = new Point(Consts.FORM_WIDTH / 2 - lblCurrentScore.Width / 2, lblVictory.Location.Y 
                                       + lblVictory.Height + Consts.LEADERBOARDS_GAP);

            // Sort out the list descending based on the score
            var bestScore = from s in Globals.allRecords
                            orderby s.Score descending
                            select s.Score;

            lblBestScore.BackColor = Color.Black;
            lblBestScore.ForeColor = Color.White;
            lblBestScore.Font = Globals.defaultFont;
            lblBestScore.Text = $"BEST SCORE: {bestScore.First()}";
            lblBestScore.Location = new Point(Consts.FORM_WIDTH / 2 - lblBestScore.Width / 2, lblCurrentScore.Location.Y
                                       + lblCurrentScore.Height + Consts.LEADERBOARDS_GAP);
        }

        private void Leaderboards_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
                Menu menu = new Menu();
                menu.Show();
            }
        }
    }
}
