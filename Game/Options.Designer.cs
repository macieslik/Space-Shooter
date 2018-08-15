namespace Game
{
    partial class Options
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
            this.btnBack = new Game.CustomControls.NotSelectableButton();
            this.btnLevel = new Game.CustomControls.NotSelectableButton();
            this.btnShip = new Game.CustomControls.NotSelectableButton();
            this.lblShip = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(245, 300);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(300, 100);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnLevel
            // 
            this.btnLevel.Location = new System.Drawing.Point(245, 172);
            this.btnLevel.Name = "btnLevel";
            this.btnLevel.Size = new System.Drawing.Size(300, 100);
            this.btnLevel.TabIndex = 1;
            this.btnLevel.Text = "level";
            this.btnLevel.UseVisualStyleBackColor = true;
            // 
            // btnShip
            // 
            this.btnShip.Location = new System.Drawing.Point(245, 39);
            this.btnShip.Name = "btnShip";
            this.btnShip.Size = new System.Drawing.Size(300, 100);
            this.btnShip.TabIndex = 0;
            this.btnShip.Text = "ship";
            this.btnShip.UseVisualStyleBackColor = true;
            // 
            // lblShip
            // 
            this.lblShip.AutoSize = true;
            this.lblShip.Location = new System.Drawing.Point(379, 113);
            this.lblShip.Name = "lblShip";
            this.lblShip.Size = new System.Drawing.Size(33, 13);
            this.lblShip.TabIndex = 3;
            this.lblShip.Text = "name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblShip);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnLevel);
            this.Controls.Add(this.btnShip);
            this.Name = "Options";
            this.Text = "Space Shooter";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Options_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.NotSelectableButton btnShip;
        private CustomControls.NotSelectableButton btnLevel;
        private CustomControls.NotSelectableButton btnBack;
        private System.Windows.Forms.Label lblShip;
        private System.Windows.Forms.Label label1;
    }
}