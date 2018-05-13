using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.Paint
{
    public partial class MainForm : Form
    {
        private float[] _sin = new float[360];
        private float[] _cos = new float[360];
        private Point _leftTopPoint;
        private bool _isMouseDown = false;

        public MainForm()
        {
            InitializeComponent();
            for(int i=0;i<360; ++i)
            {
                _sin[i] = (float )Math.Sin(i * Math.PI / 180.0F);
                _cos[i] = (float)Math.Cos(i * Math.PI / 180.0F);
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            PointF centerPoint = new PointF(ClientSize.Width / 2.0F, ClientSize.Height / 2.0F);
            float radius = ClientSize.Width> ClientSize.Height ? ClientSize.Height / 2 - 20 : ClientSize.Width / 2 - 20;
            float radius2 = ClientSize.Width> ClientSize.Height ? ClientSize.Height / 2 - 30 : ClientSize.Width / 2 - 30;
            float radius3 = ClientSize.Width> ClientSize.Height ? ClientSize.Height / 2 - 40 : ClientSize.Width / 2 - 40;

            int angle = DateTime.Now.Second * 6 + 270;
            int angle2 = DateTime.Now.Minute * 6 + 270;
            int angle3 = DateTime.Now.Hour * 30 + 270 + DateTime.Now.Minute / 2;

            PointF endPoint = new PointF(centerPoint.X + radius * _cos[angle % 360], centerPoint.Y + radius * _sin[angle % 360]);
            PointF endPoint20 = new PointF(centerPoint.X + radius2 * _cos[angle2 % 360], centerPoint.Y + radius2 * _sin[angle2 % 360]);
            PointF endPoint30 = new PointF(centerPoint.X + radius3 * _cos[angle3 % 360], centerPoint.Y + radius3 * _sin[angle3 % 360]);          
          
            for (int i = 1; i < 13; ++i)
            {
                string dig = i.ToString();
                SizeF sd = gr.MeasureString(dig, this.Font);
                PointF rp= new PointF(centerPoint.X + (radius+10) * _cos[(i * 30 + 270) % 360] - sd.Width /2, centerPoint.Y + (radius+10) * _sin[(i * 30 +270) % 360] -sd.Height /2);
                
                gr.DrawString(dig, this.Font, new SolidBrush(Color.Blue), rp);
            }
            
            Pen p = new Pen(Color.Red, 4);
            gr.DrawLine(p, centerPoint, endPoint);
            PointF endPoint2 = new PointF(
                endPoint.X + radius / 8 * _cos[(angle - 135) % 360],
                endPoint.Y + radius / 8 * _sin[(angle - 135) % 360]
            );
            PointF endPoint3 = new PointF(
                endPoint.X + radius / 8 * _cos[(angle + 135) % 360],
                endPoint.Y + radius / 8 * _sin[(angle + 135) % 360]
            );
            gr.DrawLine(p, endPoint, endPoint2);                     
            gr.DrawLine(p, endPoint, endPoint3);

            Pen p2 = new Pen(Color.Green, 4);
            gr.DrawLine(p2, centerPoint, endPoint20);
            PointF endPoint22 = new PointF(
                endPoint20.X + radius / 8 * _cos[(angle2 - 135) % 360],
                endPoint20.Y + radius / 8 * _sin[(angle2 - 135) % 360]
            );
            PointF endPoint23 = new PointF(
                endPoint20.X + radius / 8 * _cos[(angle2 + 135) % 360],
                endPoint20.Y + radius / 8 * _sin[(angle2 + 135) % 360]
            );
            gr.DrawLine(p2, endPoint20, endPoint22);
            gr.DrawLine(p2, endPoint20, endPoint23);
            
            Pen p3 = new Pen(Color.Yellow, 4);
            gr.DrawLine(p3, centerPoint, endPoint30);
            PointF endPoint32 = new PointF(
                endPoint30.X + radius / 8 * _cos[(angle3 - 135) % 360],
                endPoint30.Y + radius / 8 * _sin[(angle3 - 135) % 360]
            );
            PointF endPoint33 = new PointF(
                endPoint30.X + radius / 8 * _cos[(angle3 + 135) % 360],
                endPoint30.Y + radius / 8 * _sin[(angle3 + 135) % 360]
            );
            gr.DrawLine(p3, endPoint30, endPoint32);
            gr.DrawLine(p3, endPoint30, endPoint33);
        }


        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void timerTick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown = true;
            _leftTopPoint.X = e.X;
            _leftTopPoint.Y = e.Y;
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                this.SetDesktopLocation(
                    MousePosition.X - _leftTopPoint.X,
                    MousePosition.Y - _leftTopPoint.Y
                );
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.RButton)
            {
                contextMenuClock.Show();
            }
        }

        private void бордерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.SizableToolWindow)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            }
        }

        private void прозрачностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.TransparencyKey == System.Drawing.Color.Empty)
            {
                this.TransparencyKey = System.Drawing.Color.White;
            }
            else
            {
                this.TransparencyKey = System.Drawing.Color.Empty;
            }
            
        }

    }
}
