namespace BingoLab
{
    partial class frmBingo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBingo));
            this.btnLetsGo = new System.Windows.Forms.Button();
            this.txtNameEntry = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblRules = new System.Windows.Forms.Label();
            this.btnDontHave = new System.Windows.Forms.Button();
            this.txtNumberCalled = new System.Windows.Forms.TextBox();
            this.lblYourCard = new System.Windows.Forms.Label();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.btnPlayAgain = new System.Windows.Forms.Button();
            this.glowTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnLetsGo
            // 
            this.btnLetsGo.Location = new System.Drawing.Point(568, 38);
            this.btnLetsGo.Name = "btnLetsGo";
            this.btnLetsGo.Size = new System.Drawing.Size(75, 23);
            this.btnLetsGo.TabIndex = 0;
            this.btnLetsGo.Text = "Lets Go!";
            this.btnLetsGo.UseVisualStyleBackColor = true;
            this.btnLetsGo.Click += new System.EventHandler(this.btnLetsGo_Click);
            // 
            // txtNameEntry
            // 
            this.txtNameEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameEntry.Location = new System.Drawing.Point(402, 31);
            this.txtNameEntry.Name = "txtNameEntry";
            this.txtNameEntry.Size = new System.Drawing.Size(160, 32);
            this.txtNameEntry.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(94, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(308, 31);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Please enter your name:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(649, 38);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblRules
            // 
            this.lblRules.AutoSize = true;
            this.lblRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRules.Location = new System.Drawing.Point(12, 101);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(664, 100);
            this.lblRules.TabIndex = 4;
            this.lblRules.Text = resources.GetString("lblRules.Text");
            this.lblRules.Visible = false;
            // 
            // btnDontHave
            // 
            this.btnDontHave.Location = new System.Drawing.Point(695, 178);
            this.btnDontHave.Name = "btnDontHave";
            this.btnDontHave.Size = new System.Drawing.Size(75, 23);
            this.btnDontHave.TabIndex = 5;
            this.btnDontHave.Text = "Don\'t have";
            this.btnDontHave.UseVisualStyleBackColor = true;
            this.btnDontHave.Visible = false;
            this.btnDontHave.Click += new System.EventHandler(this.btnDontHave_Click);
            // 
            // txtNumberCalled
            // 
            this.txtNumberCalled.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumberCalled.Location = new System.Drawing.Point(695, 140);
            this.txtNumberCalled.Name = "txtNumberCalled";
            this.txtNumberCalled.ReadOnly = true;
            this.txtNumberCalled.Size = new System.Drawing.Size(85, 32);
            this.txtNumberCalled.TabIndex = 6;
            this.txtNumberCalled.Visible = false;
            // 
            // lblYourCard
            // 
            this.lblYourCard.AutoSize = true;
            this.lblYourCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourCard.Location = new System.Drawing.Point(452, 226);
            this.lblYourCard.Name = "lblYourCard";
            this.lblYourCard.Size = new System.Drawing.Size(191, 29);
            this.lblYourCard.TabIndex = 7;
            this.lblYourCard.Text = "Your Bingo Card";
            this.lblYourCard.Visible = false;
            // 
            // pnlCard
            // 
            this.pnlCard.Location = new System.Drawing.Point(299, 258);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(566, 566);
            this.pnlCard.TabIndex = 8;
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPlayAgain.Enabled = false;
            this.btnPlayAgain.Location = new System.Drawing.Point(898, 276);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(75, 23);
            this.btnPlayAgain.TabIndex = 9;
            this.btnPlayAgain.Text = "Play Again?";
            this.btnPlayAgain.UseVisualStyleBackColor = true;
            this.btnPlayAgain.Visible = false;
            this.btnPlayAgain.Click += new System.EventHandler(this.BtnPlayAgain_Click);
            // 
            // glowTimer
            // 
            this.glowTimer.Interval = 500;
            // 
            // frmBingo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.btnPlayAgain);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.lblYourCard);
            this.Controls.Add(this.txtNumberCalled);
            this.Controls.Add(this.btnDontHave);
            this.Controls.Add(this.lblRules);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtNameEntry);
            this.Controls.Add(this.btnLetsGo);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "frmBingo";
            this.Text = "Bingo!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLetsGo;
        private System.Windows.Forms.TextBox txtNameEntry;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblRules;
        private System.Windows.Forms.Button btnDontHave;
        private System.Windows.Forms.TextBox txtNumberCalled;
        private System.Windows.Forms.Label lblYourCard;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Button btnPlayAgain;
        private System.Windows.Forms.Timer glowTimer;
    }
}

