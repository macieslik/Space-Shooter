namespace Game
{
    partial class Play
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
            this.components = new System.ComponentModel.Container();
            this.pbGraphics = new System.Windows.Forms.PictureBox();
            this.tmrPlay = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbGraphics)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGraphics
            // 
            this.pbGraphics.Cursor = System.Windows.Forms.Cursors.No;
            this.pbGraphics.Location = new System.Drawing.Point(302, 137);
            this.pbGraphics.Name = "pbGraphics";
            this.pbGraphics.Size = new System.Drawing.Size(100, 50);
            this.pbGraphics.TabIndex = 0;
            this.pbGraphics.TabStop = false;
            this.pbGraphics.Paint += new System.Windows.Forms.PaintEventHandler(this.pbGraphics_Paint);
            // 
            // tmrPlay
            // 
            this.tmrPlay.Tick += new System.EventHandler(this.tmrPlay_Tick);
            // 
            // Play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbGraphics);
            this.Name = "Play";
            this.Text = "Space Shooter";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Play_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Play_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbGraphics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGraphics;
        private System.Windows.Forms.Timer tmrPlay;
    }
}