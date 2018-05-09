using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_CalculatorWPF
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private double int1;
        private double int2;
        private double result;
        private string calcOperator = "";
        /// <summary>
        /// clear text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearTextBox(object sender = null, EventArgs e = null)
        {
            textBox1.Text = "0";
            int1 = 0;
            int2 = 0;
            result = 0;
            calcOperator = "";
        }
        /// <summary>
        /// press number button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            if (
                textBox1.Text == "0" ||
                textBox1.Text == "+" ||
                textBox1.Text == "-" ||
                textBox1.Text == "*" ||
                textBox1.Text == "/"
            )
            {
                textBox1.Text = "";
            }
            Button btn = (Button)sender;
            textBox1.Text += btn.Text;
        }
        /// <summary>
        /// do work with operator +
        /// </summary>
        private void Plus()
        {
            result = int1 + int2;
        }
        /// <summary>
        /// do work with operator -
        /// </summary>
        private void Minus()
        {
            result = int1 - int2;
        }
        /// <summary>
        /// do work with operator *
        /// </summary>
        private void Multiply()
        {
            result = int1 * int2;
        }
        /// <summary>
        /// do work with operator /
        /// </summary>
        private void Divide()
        {
            if (int2==0)
            {
                return;
            }
            result = int1 / int2;
        }
        /// <summary>
        /// do work with operator =
        /// </summary>
        private void Equally(object sender = null, EventArgs e = null)
        {
            if(
                int1 !=0 &&
                textBox1.Text != "+" &&
                textBox1.Text != "-" &&
                textBox1.Text != "*" &&
                textBox1.Text != "/" &&
                calcOperator != ""
            )
            {
                double.TryParse(textBox1.Text, out int2);
                switch (calcOperator)
                {
                    case "+":
                        Plus();
                        break;
                    case "-":
                        Minus();
                        break;
                    case "*":
                        Multiply();
                        break;
                    case "/":
                        Divide();
                        break;
                }
                calcOperator = "";
                textBox1.Text = "" + result;
                int1 = 0;
                int2 = 0;
                result = 0;
            }
            else
            {
                textBox1.Text = "" + int1;
                int1 = 0;
                int2 = 0;
                result = 0;
                calcOperator = "";
            }
        }
        /// <summary>
        /// press operator button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PressOperator(object sender = null, EventArgs e = null)
        {
            if (
                textBox1.Text != "0" && 
                textBox1.Text != "+" &&
                textBox1.Text != "-" &&
                textBox1.Text != "*" &&
                textBox1.Text != "/" 
            )
            {
                Button btn = (Button)sender;
                string btnText = btn.Text;
                if(int1 == 0)
                {
                    double.TryParse(textBox1.Text, out int1);
                    textBox1.Text = "";
                    calcOperator = btnText;
                    textBox1.Text += btnText;
                }
                else
                {
                    double.TryParse(textBox1.Text, out int2);
                    textBox1.Text = "";
                    textBox1.Text += btnText;

                    switch (calcOperator)
                    {
                        case "+":
                            Plus();
                            break;
                        case "-":
                            Minus();
                            break;
                        case "*":
                            Multiply();
                            break;
                        case "/":
                            Divide();
                            break;
                    }
                    textBox1.Text = btnText;
                    int1 = result;
                    int2 = 0;
                    calcOperator = btnText;

                }

            }
        }
        /// <summary>
        /// add dot to number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PressDot(object sender = null, EventArgs e = null)
        {
            if(
                textBox1.Text != "+" &&
                textBox1.Text != "-" &&
                textBox1.Text != "*" &&
                textBox1.Text != "/"
            )
            {
                bool presentDot = false;
                foreach(char symb in textBox1.Text)
                {
                    if (symb == ',')
                    {
                        presentDot = true;
                    }
                }
                if (presentDot)
                {
                    return;
                }
                else
                {
                    textBox1.Text += ',';
                }
            }

        }

    }
}
