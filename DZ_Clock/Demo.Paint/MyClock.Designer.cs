﻿namespace Demo.Paint
{
    partial class MyClock
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MyClockTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // MyClockTimer
            // 
            this.MyClockTimer.Enabled = true;
            this.MyClockTimer.Interval = 1000;
            this.MyClockTimer.Tick += new System.EventHandler(this.timerTick);
            // 
            // MyClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "MyClock";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MyClock_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer MyClockTimer;
    }
}
