using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MyWorkAtTheLesson
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            MyDb.Go();
        }
        private void MenuClosed(object sender, FormClosedEventArgs e)
        {
            MyDb.End();
        }
        
        private void btnShowDish_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var item in MyDb.ShowAllDish())
            {
                listBox1.Items.Add(item);
            }
        }

        private void buttonAddMenu_Click(object sender, EventArgs e)
        {
            AddDishForm form = new AddDishForm();
            form.ShowDialog();
        }
        //List<Tuple<string, int, string>>
        private void myListBox_Click(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb != null)
            {
                if (lb.SelectedItem == null) return;
                DishInfoForm form = new DishInfoForm(lb.SelectedItem.ToString());
                form.ShowDialog();
            }
        }
    }
}
