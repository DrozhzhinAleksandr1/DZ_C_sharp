namespace MyWorkAtTheLesson
{
    partial class Menu
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnShowDish = new System.Windows.Forms.Button();
            this.buttonAddMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 21);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(643, 394);
            this.listBox1.TabIndex = 2;
            this.listBox1.Click += new System.EventHandler(this.myListBox_Click);
            // 
            // btnShowDish
            // 
            this.btnShowDish.Location = new System.Drawing.Point(673, 333);
            this.btnShowDish.Name = "btnShowDish";
            this.btnShowDish.Size = new System.Drawing.Size(155, 82);
            this.btnShowDish.TabIndex = 3;
            this.btnShowDish.Text = "showList";
            this.btnShowDish.UseVisualStyleBackColor = true;
            this.btnShowDish.Click += new System.EventHandler(this.btnShowDish_Click);
            // 
            // buttonAddMenu
            // 
            this.buttonAddMenu.Location = new System.Drawing.Point(674, 21);
            this.buttonAddMenu.Name = "buttonAddMenu";
            this.buttonAddMenu.Size = new System.Drawing.Size(154, 75);
            this.buttonAddMenu.TabIndex = 14;
            this.buttonAddMenu.Text = "ShowAddMenu";
            this.buttonAddMenu.UseVisualStyleBackColor = true;
            this.buttonAddMenu.Click += new System.EventHandler(this.buttonAddMenu_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 427);
            this.Controls.Add(this.buttonAddMenu);
            this.Controls.Add(this.btnShowDish);
            this.Controls.Add(this.listBox1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuClosed);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnShowDish;
        private System.Windows.Forms.Button buttonAddMenu;
    }
}

