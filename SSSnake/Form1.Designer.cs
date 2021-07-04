namespace SSSnake
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.snapButton = new System.Windows.Forms.Button();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.txtScore = new System.Windows.Forms.Label();
            this.txtHighScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize) (this.picCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.gameTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.SkyBlue;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.startButton.Location = new System.Drawing.Point(612, 24);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(114, 49);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.StartGame);
            // 
            // snapButton
            // 
            this.snapButton.BackColor = System.Drawing.Color.LightGreen;
            this.snapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.snapButton.Location = new System.Drawing.Point(612, 79);
            this.snapButton.Name = "snapButton";
            this.snapButton.Size = new System.Drawing.Size(114, 49);
            this.snapButton.TabIndex = 0;
            this.snapButton.Text = "Snap";
            this.snapButton.UseVisualStyleBackColor = false;
            this.snapButton.Click += new System.EventHandler(this.TakeSnapShot);
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.DimGray;
            this.picCanvas.Location = new System.Drawing.Point(12, 24);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(580, 680);
            this.picCanvas.TabIndex = 1;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePictureBoxGraphics);
            // 
            // txtScore
            // 
            this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtScore.Location = new System.Drawing.Point(618, 212);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(91, 19);
            this.txtScore.TabIndex = 2;
            this.txtScore.Text = "Score: 0";
            // 
            // txtHighScore
            // 
            this.txtHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtHighScore.Location = new System.Drawing.Point(618, 248);
            this.txtHighScore.Name = "txtHighScore";
            this.txtHighScore.Size = new System.Drawing.Size(108, 62);
            this.txtHighScore.TabIndex = 2;
            this.txtHighScore.Text = "HighScore";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 40D;
            this.gameTimer.SynchronizingObject = this;
            this.gameTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.GameTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 725);
            this.Controls.Add(this.txtHighScore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.snapButton);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "SSSnake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize) (this.picCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.gameTimer)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button snapButton;

        private System.Windows.Forms.Button startButton;

        private System.Timers.Timer gameTimer;

        private System.Windows.Forms.Label txtHighScore;

        private System.Windows.Forms.Label txtScore;

        private System.Windows.Forms.PictureBox picCanvas;

        #endregion
    }
}