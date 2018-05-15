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

namespace Demo.GrContainer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            int baseRadius = ClientSize.Width > ClientSize.Height ? ClientSize.Height * 3 / 10 : ClientSize.Width * 3 / 10;

            Graphics gr = e.Graphics;

            DrawHearth(gr);

            DrawArrow(Color.DeepSkyBlue, 1, gr, baseRadius-30, DateTime.Now.Second * 6);
            DrawArrow(Color.Blue, 3,  gr, baseRadius - 30, DateTime.Now.Minute * 6);
            DrawArrow(Color.Red, 4, gr, baseRadius - 50, DateTime.Now.Hour * 30);

            DrawScale(Color.DarkViolet, 1, gr, baseRadius - 30, 10 );

        }

        private void DrawScale(Color color, int penWidth, Graphics gr, int radius, int length)
        {
            for (int i = 0; i < 60; ++i)
            {
                GraphicsContainer container = gr.BeginContainer(
                    new Rectangle(ClientSize.Width / 2, ClientSize.Height * 3 / 5, ClientSize.Width, ClientSize.Height),
                    new Rectangle(0, 0, ClientSize.Width, ClientSize.Height),
                    GraphicsUnit.Pixel
                );

                gr.RotateTransform(i*6);

                gr.DrawLine(
                    new Pen(color, i % 5 == 0 ? penWidth + penWidth : penWidth),
                    new Point(0, i % 5 == 0 ? -radius + length + length : -radius + length),
                    new Point(0, -radius)
                );
                
                if(i % 5 == 0)
                {
                    int number = i / 5;
                    if (i == 0)
                    {
                        number = 12;
                    } 
                    gr.RotateTransform(180);
                    SolidBrush newBrush = new SolidBrush(Color.Green);
                    
                    gr.DrawString(
                        "" + number, 
                        this.Font, 
                        newBrush, 
                        0 - gr.MeasureString(""+ number,this.Font).Width / 2, 
                        radius + gr.MeasureString("" + number, this.Font).Height/5
                    );
                }
                
                gr.EndContainer(container);
            }
        }

        private void DrawArrow(Color color, int penWidth, Graphics gr, int length, int angle)
        {
            GraphicsContainer container = gr.BeginContainer(
                new Rectangle(ClientSize.Width / 2, ClientSize.Height * 3 / 5, ClientSize.Width, ClientSize.Height),
                new Rectangle(0, 0, ClientSize.Width, ClientSize.Height),
                GraphicsUnit.Pixel
            );

            gr.RotateTransform(angle);

            gr.DrawLine(new Pen(color, penWidth),
                new Point(0, 0),
                new Point(0, - length)
            );
            gr.EndContainer(container);
        }       

        private void DrawHearth(Graphics gr)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddBezier(
                new Point(ClientSize.Width / 2, ClientSize.Height * 2 / 7),
                new Point(ClientSize.Width / 3, 0),
                new Point(0, ClientSize.Height * 3 / 5),
                new Point(ClientSize.Width / 2, ClientSize.Height - 10)
                );

            gp.AddBezier(
               new Point(ClientSize.Width / 2, ClientSize.Height - 10),
               new Point(ClientSize.Width, ClientSize.Height * 3 / 5),
               new Point(ClientSize.Width * 2 / 3, 0),
               new Point(ClientSize.Width / 2, ClientSize.Height * 2 / 7)
               );
            PathGradientBrush br = new PathGradientBrush(gp);
            br.CenterPoint = new PointF(ClientSize.Width / 2, ClientSize.Height / 2);
            br.CenterColor = Color.White;
            br.SurroundColors = new Color[]
            {
                Color.Pink
            };
            gr.FillPath(br, gp);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
