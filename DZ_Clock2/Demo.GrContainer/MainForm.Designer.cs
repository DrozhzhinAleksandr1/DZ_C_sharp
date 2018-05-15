namespace Demo.GrContainer
{
    partial class MainForm
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
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.myClock2 = new Demo.GrContainer.MyClock();
            this.myClock1 = new Demo.GrContainer.MyClock();
            this.SuspendLayout();
            // 
            // clockTimer
            // 
            this.clockTimer.Enabled = true;
            this.clockTimer.Interval = 1000;
            this.clockTimer.Tick += new System.EventHandler(this.clockTimer_Tick);
            // 
            // myClock2
            // 
            this.myClock2.BackColor = System.Drawing.SystemColors.Control;
            this.myClock2.Location = new System.Drawing.Point(228, -34);
            this.myClock2.Name = "myClock2";
            this.myClock2.Size = new System.Drawing.Size(472, 350);
            this.myClock2.TabIndex = 1;
            // 
            // myClock1
            // 
            this.myClock1.BackColor = System.Drawing.SystemColors.Control;
            this.myClock1.Location = new System.Drawing.Point(-76, -34);
            this.myClock1.Name = "myClock1";
            this.myClock1.Size = new System.Drawing.Size(392, 259);
            this.myClock1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.myClock2);
            this.Controls.Add(this.myClock1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer clockTimer;
        private MyClock myClock1;
        private MyClock myClock2;
    }
}

