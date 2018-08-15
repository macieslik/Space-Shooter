using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Game.Aliens;

namespace Game
{
    public partial class Play : Form
    {
        private int missileX;
        private int gridSpaceY;
        private int gridSpaceX;
        private int arrayIndex;
        private int alienIndex;
        private int alienSpeedX;
        private int alienSpeedY;
        private int aliensLeft;
        private int score;

        private int[] currentLevelArray;

        private bool moveLeft;
        private bool moveRight;
        private bool gameOver;

        private List<Alien> aliens = new List<Alien>();

        public Play()
        {
            InitializeComponent();
            
            Cursor.Hide();

            this.KeyPreview = true;
            this.ClientSize = new Size(Consts.FORM_WIDTH, Consts.FORM_HEIGHT);
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            pbGraphics.Location = new Point(0, 0);
            pbGraphics.Width = Consts.FORM_WIDTH;
            pbGraphics.Height = Consts.FORM_HEIGHT;
            pbGraphics.BackColor = Color.Black;
            pbGraphics.BorderStyle = BorderStyle.None;
            pbGraphics.Image = new Bitmap(pbGraphics.Width, pbGraphics.Height);

            GameReset();
        }
        
        private void tmrPlay_Tick(object sender, EventArgs e)
        {
            int fps = 60;
            tmrPlay.Interval = 1000 / fps;
            AliensMove();
            PlayerMove();
            pbGraphics.Refresh();
            CheckIfGameOver();
            Invalidate();
        }
        
        private void pbGraphics_Paint(object sender, PaintEventArgs e)
        {
            alienIndex = 0;
            arrayIndex = 0;
            // Draw Player
            e.Graphics.FillRectangle(new SolidBrush(Globals.spaceships[Globals.selectedSpaceship].Color), 
                                     new Rectangle(Globals.spaceships[Globals.selectedSpaceship].X, Consts.PLAYER_Y, 
                                     Consts.PLAYER_WIDTH, Consts.PLAYER_HEIGHT));

            foreach (var alien in aliens)
            {
                alien.RightEdge = alien.X + Consts.ALIEN_WIDTH;
                alien.BottomEdge = alien.Y + Consts.ALIEN_HEIGHT;
                // Check if alien is alive
                aliens.ForEach(a =>
                {
                    if (a.Hp > 0)
                    {
                        if (Globals.missileFired == true &&
                        a.X <= (missileX + Consts.MISSILE_WIDTH) &&
                        a.RightEdge >= missileX &&
                        a.Y <= (Globals.missileY + Consts.MISSILE_HEIGHT) &&
                        a.BottomEdge >= Globals.missileY)
                        {
                            a.Hp--;
                            Globals.missileFired = false;
                            if (a.Hp <= 0)
                            {
                                score++;
                                aliensLeft--;
                            }
                        }
                    }
                });
                // Draw alien if he is alive
                if (aliens[alienIndex].Hp > 0)
                {
                    e.Graphics.FillRectangle(new SolidBrush(aliens[alienIndex].Color), new Rectangle(aliens[alienIndex].X, 
                                             aliens[alienIndex].Y, Consts.ALIEN_WIDTH, Consts.ALIEN_HEIGHT));
                }

                alienIndex++;

                if (alienIndex >= aliens.Count())
                {
                    alienIndex = 0;
                }
            }

            if (Globals.missileFired)
            {
                e.Graphics.FillRectangle(new SolidBrush(Globals.spaceships[Globals.selectedSpaceship].Color),
                                         new Rectangle(missileX, Globals.missileY, Consts.MISSILE_WIDTH, Consts.MISSILE_HEIGHT));

                Globals.missileY -= Globals.spaceships[Globals.selectedSpaceship].MissileSpeed;
                // Missile reaches the top
                if (Globals.missileY <= 0)
                {
                    Globals.missileFired = false;
                }
            }
        }

        private void Play_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    moveLeft = true;
                    break;

                case Keys.Right:
                    moveRight = true;
                    break;

                case Keys.Space:
                    if (!Globals.missileFired)
                    {
                        // Get missile location at the moment of fire
                        missileX = (Globals.spaceships[Globals.selectedSpaceship].X + (Consts.PLAYER_WIDTH / 2) - (Consts.MISSILE_WIDTH / 2));
                        Globals.spaceships[Globals.selectedSpaceship].Shoot();
                        SoundEffects.fire.Play();
                    }
                    break;

                case Keys.Escape:
                    Globals.message = "GAME OVER";
                    Globals.allRecords.Add(new Record(score, Globals.spaceships[Globals.selectedSpaceship].Name));
                    score = 0;
                    tmrPlay.Enabled = false;
                    this.Hide();
                    Leaderboards leaderboards = new Leaderboards();
                    leaderboards.Show();
                    break;
            }
        }

        private void Play_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    moveLeft = false;
                    break;
                case Keys.Right:
                    moveRight = false;
                    break;
            }
        }

        private void PlayerMove()
        {
            // Separated method to reducde KeyDown event lag while holding the button
            if (moveLeft)
            {
                if (Globals.spaceships[Globals.selectedSpaceship].X > 0 + Consts.GAP)
                {
                    Globals.spaceships[Globals.selectedSpaceship].X -= Globals.spaceships[Globals.selectedSpaceship].Speed;
                }
                else if (Globals.spaceships[Globals.selectedSpaceship].X <= 0 + Consts.GAP)
                {
                    Globals.spaceships[Globals.selectedSpaceship].X = 0 + Consts.GAP;
                }
            }

            if (moveRight)
            {
                if (Globals.spaceships[Globals.selectedSpaceship].X + Consts.PLAYER_WIDTH < Consts.FORM_WIDTH - Consts.GAP)
                {
                    Globals.spaceships[Globals.selectedSpaceship].X += Globals.spaceships[Globals.selectedSpaceship].Speed;
                }
                else if (Globals.spaceships[Globals.selectedSpaceship].X + Consts.PLAYER_WIDTH >= Consts.FORM_WIDTH - Consts.GAP)
                {
                    Globals.spaceships[Globals.selectedSpaceship].X = Consts.FORM_WIDTH - Consts.GAP - Consts.PLAYER_WIDTH;
                }
            }
        }

        private void AliensMove()
        {
            // Move aliens vertically if any alien hits the wall and change horizontal moving direction
            foreach (var alien in aliens)
            {
                if (alien.Hp > 0)
                {
                    if (((alien.X + Consts.ALIEN_WIDTH + Consts.GAP) >= Consts.FORM_WIDTH) || 
                        (alien.X <= Consts.GAP))
                    {
                        alienSpeedX *= -1;
                        aliens.ForEach(a => a.Y += alienSpeedY);
                        break;
                    }
                }
            }
            // Move aliens horizontally
            aliens.ForEach(a => a.X += alienSpeedX);
        }

        private void BuildAlienList()
        {
            // Build list of aliens with X and Y based on their starting point on the level grid
            aliens.Clear();
            alienIndex = 0;
            arrayIndex = 0;
            for (int eachRow = 0; eachRow < Consts.GRID_ROWS; eachRow++)
            {
                for (int eachCol = 0; eachCol < Consts.GRID_COLUMNS; eachCol++)
                {
                    switch (currentLevelArray[arrayIndex])
                    {
                        case 1:
                            aliens.Add(new Light());
                            aliens[alienIndex].X = gridSpaceX;
                            aliens[alienIndex].Y = gridSpaceY;                            
                            alienIndex++;
                            break;

                        case 2:
                            aliens.Add(new Trooper());
                            aliens[alienIndex].X = gridSpaceX;
                            aliens[alienIndex].Y = gridSpaceY;
                            alienIndex++;
                            break;

                        case 3:
                            aliens.Add(new Heavy());
                            aliens[alienIndex].X = gridSpaceX;
                            aliens[alienIndex].Y = gridSpaceY;
                            alienIndex++;
                            break;
                    } 
                    gridSpaceX += Consts.ALIEN_WIDTH + (2 * Consts.GAP);
                    arrayIndex++;
                }
                gridSpaceX = 0 + Consts.GAP;
                gridSpaceY += Consts.ALIEN_HEIGHT + (2 * Consts.GAP);
            }
            gridSpaceY = 0 + Consts.GAP;
            aliensLeft = aliens.Count();
        }

        private void CheckIfGameOver()
        {
            // Execute if player won
            if (aliensLeft <= 0)
            {
                if (Globals.selectedLevel >= Globals.allLevels.Count - 1)
                {
                    Globals.message = "VICTORY!";
                    // Update scores
                    Globals.allRecords.Add(new Record(score, Globals.spaceships[Globals.selectedSpaceship].Name));
                    // Reset score for the next game
                    score = 0;

                    this.Hide();
                    Leaderboards leaderboards = new Leaderboards();
                    leaderboards.Show();
                    tmrPlay.Enabled = false;
                }
                else
                {
                    int milliseconds = 2000;
                    Thread.Sleep(milliseconds);
                    Globals.selectedLevel++;
                    GameReset();
                }
            }
            // Checking alien-player collision
            aliens.ForEach(a =>
            {
                Globals.spaceships[Globals.selectedSpaceship].RightEdge = Globals.spaceships[Globals.selectedSpaceship].X + Consts.PLAYER_WIDTH;

                if (a.Hp > 0)
                {
                    if (gameOver == false &&
                    Globals.spaceships[Globals.selectedSpaceship].X <= a.RightEdge &&
                    Globals.spaceships[Globals.selectedSpaceship].RightEdge >= a.X &&
                    Consts.PLAYER_Y <= a.BottomEdge &&
                    Consts.PLAYER_BOTTOM_EDGE >= a.Y)
                    {
                       gameOver = true;
                    }
                }
            });
            // Checking alien-bottom collision
            aliens.ForEach(a =>
            {
                if (a.BottomEdge >= Consts.PLAYER_BOTTOM_EDGE)
                {
                    gameOver = true;
                }
            });
            // Execute if player lost
            if (gameOver)
            {
                SoundEffects.destruction.Play();

                Globals.message = "GAME OVER";
                Globals.allRecords.Add(new Record(score, Globals.spaceships[Globals.selectedSpaceship].Name));
                score = 0;

                this.Hide();
                Leaderboards leaderboards = new Leaderboards();
                leaderboards.Show();
                tmrPlay.Enabled = false;
            }
        }

        private void GameReset()
        {
            gridSpaceY = 0 + Consts.GAP;
            gridSpaceX = 0 + Consts.GAP;
            alienSpeedX = 1;
            alienSpeedY = 4;

            moveLeft = false;
            moveRight = false;
            gameOver = false;
            Globals.missileFired = false;
            currentLevelArray = Globals.allLevels[Globals.selectedLevel];

            BuildAlienList();

            tmrPlay.Enabled = true;
        }
    }
}
