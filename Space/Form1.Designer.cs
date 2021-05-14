
namespace Space
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TxtScore = new System.Windows.Forms.Label();
            this.plant = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.totalScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.plant)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtScore
            // 
            this.TxtScore.AutoSize = true;
            this.TxtScore.BackColor = System.Drawing.Color.Transparent;
            this.TxtScore.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TxtScore.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtScore.Location = new System.Drawing.Point(-2, 524);
            this.TxtScore.Name = "TxtScore";
            this.TxtScore.Size = new System.Drawing.Size(98, 31);
            this.TxtScore.TabIndex = 1;
            this.TxtScore.Text = "Score: 0";
            // 
            // plant
            // 
            this.plant.BackColor = System.Drawing.Color.Black;
            this.plant.Image = ((System.Drawing.Image)(resources.GetObject("plant.Image")));
            this.plant.Location = new System.Drawing.Point(285, 463);
            this.plant.Name = "plant";
            this.plant.Size = new System.Drawing.Size(70, 92);
            this.plant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.plant.TabIndex = 0;
            this.plant.TabStop = false;
            this.plant.Click += new System.EventHandler(this.player_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1;
            this.gameTimer.Tick += new System.EventHandler(this.MainGameTimerEvent);
            // 
            // totalScore
            // 
            this.totalScore.AutoSize = true;
            this.totalScore.BackColor = System.Drawing.Color.Transparent;
            this.totalScore.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.totalScore.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.totalScore.Location = new System.Drawing.Point(549, 513);
            this.totalScore.Name = "totalScore";
            this.totalScore.Size = new System.Drawing.Size(98, 31);
            this.totalScore.TabIndex = 2;
            this.totalScore.Text = "Score: 0";
            this.totalScore.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(732, 553);
            this.Controls.Add(this.totalScore);
            this.Controls.Add(this.TxtScore);
            this.Controls.Add(this.plant);
            this.Name = "Form1";
            this.Text = "SpaceGame";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.plant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TxtScore;
        private System.Windows.Forms.PictureBox plant;
        private System.Windows.Forms.Timer gameTimer;
        //private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalScore;
    }
}

