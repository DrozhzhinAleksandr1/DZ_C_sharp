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
    public partial class DishInfoForm : Form
    {
        public DishInfoForm(string dishName)
        {
            InitializeComponent();
            label1.Text = dishName;
            int idDish = int.Parse(MyDb.DishId(label1.Text));
            int idRecipe = int.Parse(MyDb.RecipeIdByDishId(idDish));
            textBox1.Text = MyDb.GetRecipe(idRecipe);

            var list = MyDb.GetQuantities(idRecipe);
            foreach (var item in list)
            {
                ListViewItem lwt = new ListViewItem(item.Item1);
                lwt.SubItems.Add("" + item.Item2);
                lwt.SubItems.Add(item.Item3);
                listView1.Items.Add(lwt);
            }
        }
    }
}
