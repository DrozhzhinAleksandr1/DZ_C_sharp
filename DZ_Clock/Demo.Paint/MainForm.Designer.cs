namespace Demo.Paint
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuClock = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.прозрачностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бордерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myClock1 = new Demo.Paint.MyClock();
            this.myClock2 = new Demo.Paint.MyClock();
            this.contextMenuClock.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timerTick);
            // 
            // contextMenuClock
            // 
            this.contextMenuClock.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прозрачностьToolStripMenuItem,
            this.бордерToolStripMenuItem});
            this.contextMenuClock.Name = "contextMenuClock";
            this.contextMenuClock.Size = new System.Drawing.Size(154, 48);
            // 
            // прозрачностьToolStripMenuItem
            // 
            this.прозрачностьToolStripMenuItem.Name = "прозрачностьToolStripMenuItem";
            this.прозрачностьToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.прозрачностьToolStripMenuItem.Text = "Прозрачность";
            this.прозрачностьToolStripMenuItem.Click += new System.EventHandler(this.прозрачностьToolStripMenuItem_Click);
            // 
            // бордерToolStripMenuItem
            // 
            this.бордерToolStripMenuItem.Name = "бордерToolStripMenuItem";
            this.бордерToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.бордерToolStripMenuItem.Text = "Бордер";
            this.бордерToolStripMenuItem.Click += new System.EventHandler(this.бордерToolStripMenuItem_Click);
            // 
            // myClock1
            // 
            this.myClock1.ColorArrowHour = System.Drawing.Color.Yellow;
            this.myClock1.ColorArrowMin = System.Drawing.Color.Green;
            this.myClock1.ColorArrowSec = System.Drawing.Color.Red;
            this.myClock1.Location = new System.Drawing.Point(371, 12);
            this.myClock1.MyClockTimezone = 0;
            this.myClock1.Name = "myClock1";
            this.myClock1.Size = new System.Drawing.Size(150, 150);
            this.myClock1.TabIndex = 3;
            // 
            // myClock2
            // 
            this.myClock2.ColorArrowHour = System.Drawing.Color.DarkKhaki;
            this.myClock2.ColorArrowMin = System.Drawing.Color.GreenYellow;
            this.myClock2.ColorArrowSec = System.Drawing.Color.DarkRed;
            this.myClock2.Location = new System.Drawing.Point(29, 12);
            this.myClock2.MyClockTimezone = 3;
            this.myClock2.Name = "myClock2";
            this.myClock2.Size = new System.Drawing.Size(150, 150);
            this.myClock2.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(562, 232);
            this.ContextMenuStrip = this.contextMenuClock;
            this.Controls.Add(this.myClock1);
            this.Controls.Add(this.myClock2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.contextMenuClock.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ContextMenuStrip contextMenuClock;
        private System.Windows.Forms.ToolStripMenuItem прозрачностьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem бордерToolStripMenuItem;
        private MyClock myClock2;
        private MyClock myClock1;
    }
}

