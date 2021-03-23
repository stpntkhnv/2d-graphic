using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2d_graphic.Windows
{
    public partial class Fractals : Form
    {
        public double currentmaxr { get; set; }
        public double currentmaxi { get; set; }
        public double currentminr { get; set; }
        public double currentmini { get; set; }
        public Bitmap bitMap;
        private Graphics graphics;
        private Pen pen;
        private int width;
        private int height;
        private int x;
        private int y;
        private int x2;
        private int y2;
        private bool draw = true;
        private bool k = false;

        private double angle30 = Math.PI / 6;
        private double angle45 = Math.PI / 4;
        private double angle90 = Math.PI / 2;

        public Fractals()
        {
            InitializeComponent();
            width = pictureBox1.Width;
            height = pictureBox1.Height;
            bitMap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitMap);
            pen = new Pen(Color.White);
            
            
        }

        void DrawMandelbrot(double maxr, double minr, double maxi, double mini)
        {
            currentmaxr = maxr;
            currentmaxi = maxi;
            currentminr = minr;
            currentmini = mini;
            double zx = 0;
            double zy = 0;
            double cx = 0;
            double cy = 0;
            double xjump = (maxr - minr) / Width;
            double yjump = (maxi - mini) / Height;
            double tempzx = 0;
            int loopmax = 1000;
            int loopgo = 0;
            for (int x = 0; x < Width; x++)
            {
                cx = (xjump * x) - Math.Abs(minr);
                for (int y = 0; y < Height; y++)
                {
                    zx = 0;
                    zy = 0;
                    cy = (yjump * y) - Math.Abs(mini);
                    loopgo = 0;
                    while (zx * zx + zy * zy <= 4 && loopgo < loopmax)
                    {
                        loopgo++;
                        tempzx = zx;
                        zx = (zx * zx) - (zy * zy) + cx;
                        zy = (2 * tempzx * zy) + cy;
                    }

                    if (loopgo == loopmax)
                    {
                        Point point = new Point(x, y);
                        graphics.DrawEllipse(pen, point.X, point.Y, 4, 4);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawTree(pen, width / 2, height, 200, angle90, 0);
            pictureBox1.Image = bitMap;
        }

        private void CreateMandelbrotButton_Click(object sender, EventArgs e)
        {
            DrawMandelbrot(2, -2, 2, -2);
            pictureBox1.Image = bitMap;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.Indigo);
            pictureBox1.Image = bitMap;
        }

        private void DrawTree(Pen pencil, double x, double y, double a, double angle, int count)
        {
            Random rnd = new Random();
            pencil.Color = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255), rnd.Next(255));
            for(int i = 0; i < a; i++)
            { 
                
                double xnew = Math.Round(x + 100 * Math.Cos(angle)),
                ynew = Math.Round(y - 100 * Math.Sin(angle));

                graphics.DrawLine(pencil, (float)x, (float)y, (float)xnew, (float)ynew);


                x = xnew;
                y = ynew;

                


                DrawTree(pencil, x, y, 100, angle + angle45, count);
                DrawTree(pencil, x, y, 100, angle - angle30, count);
            }
        }
    }
}
