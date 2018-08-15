namespace Game
{
    partial class Leaderboards
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCurrentScore = new System.Windows.Forms.Label();
            this.lblBestScore = new System.Windows.Forms.Label();
            this.lblVictory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCurrentScore
            // 
            this.lblCurrentScore.AutoSize = true;
            this.lblCurrentScore.Location = new System.Drawing.Point(364, 48);
            this.lblCurrentScore.Name = "lblCurrentScore";
            this.lblCurrentScore.Size = new System.Drawing.Size(35, 13);
            this.lblCurrentScore.TabIndex = 0;
            this.lblCurrentScore.Text = "label1";
            // 
            // lblBestScore
            // 
            this.lblBestScore.AutoSize = true;
            this.lblBestScore.Location = new System.Drawing.Point(364, 84);
            this.lblBestScore.Name = "lblBestScore";
            this.lblBestScore.Size = new System.Drawing.Size(35, 13);
            this.lblBestScore.TabIndex = 1;
            this.lblBestScore.Text = "label2";
            // 
            // lblVictory
            // 
            this.lblVictory.AutoSize = true;
            this.lblVictory.Location = new System.Drawing.Point(366, 211);
            this.lblVictory.Name = "lblVictory";
            this.lblVictory.Size = new System.Drawing.Size(35, 13);
            this.lblVictory.TabIndex = 2;
            this.lblVictory.Text = "label1";
            // 
            // Leaderboards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblVictory);
            this.Controls.Add(this.lblBestScore);
            this.Controls.Add(this.lblCurrentScore);
            this.Name = "Leaderboards";
            this.Text = "Space Shooter";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Leaderboards_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentScore;
        private System.Windows.Forms.Label lblBestScore;
        private System.Windows.Forms.Label lblVictory;
    }
}