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
    public partial class AddDishForm : Form
    {
        public AddDishForm()
        {
            InitializeComponent();
        }
        private void AddDishFormClosed(object sender, FormClosedEventArgs e)
        {
            //MyDb.End();
        }

        private void buttonAddDish_Click(object sender, EventArgs e)
        {
            if( MyDb.DishId(textBox1.Text) != "" + 0)
            {
                MessageBox.Show("Блюдо с таким именем уже существует");
                return;
            }
            MyDb.InsertDish(textBox1.Text);
            int idDish;
            int.TryParse(MyDb.DishId(textBox1.Text), out idDish);
            MyDb.InsertRecipe(textBox2.Text, idDish);
            int idRecipe;
            int.TryParse(MyDb.RecipeId(textBox2.Text), out idRecipe);

            for (int i = 0; i < listView1.Items.Count; ++i)
            {
                MyDb.InsertQuantities(idRecipe,
                    listView1.Items[i].SubItems[0].Text,
                    int.Parse(listView1.Items[i].SubItems[1].Text),
                    listView1.Items[i].SubItems[2].Text);
            }
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if(textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                int number;
                if(int.TryParse(textBox4.Text, out number))
                {
                    ListViewItem lwt = new ListViewItem(textBox3.Text);
                    lwt.SubItems.Add(textBox4.Text);
                    lwt.SubItems.Add(textBox5.Text);
                    listView1.Items.Add(lwt);
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
            }
        }
    }
}
