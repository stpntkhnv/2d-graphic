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
    public partial class Otrezki : Form
    {
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public class Line
        {
            public int X0 { get; set; }
            public int Y0 { get; set; }
            public int X1 { get; set; }
            public int Y1 { get; set; }
        }

        private Graphics graphics;
        private Bitmap bitmap;
        private Pen pen;
        public int width;
        public int height;

        private int Xmax;
        private int Xmin;
        private int Ymax;
        private int Ymin;

        private List<Point> RectPoints { get; set; }
        private List<Point> LinesPoints { get; set; }

        public Otrezki()
        {
            InitializeComponent();
            width = pictureBox1.Width;
            height = pictureBox1.Height;
            bitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitmap);
            pen = new Pen(Color.White);
            LinesPoints = new List<Point>();
            RectPoints = new List<Point>();
            Xmax = 250;
            Xmin = 50;
            Ymin = 50;
            Ymax = 250;

            

            pictureBox1.Image = bitmap;
        }

        public void CreateRectangle()
        {
            graphics.DrawRectangle(pen, RectPoints[0].X, RectPoints[0].Y, RectPoints[1].X - RectPoints[0].X, RectPoints[1].Y - RectPoints[0].Y);
        }
        
        private void CreateLines()
        {
            for(int i = 1; i < LinesPoints.Count; i+=2)
            {
                graphics.DrawLine(pen, LinesPoints[i - 1].X, LinesPoints[i - 1].Y, LinesPoints[i].X, LinesPoints[i].Y);
            }
        }

        public int GetCode(int x, int y)
        {
            return
                ((x < Xmin) ? 1 : 0) << 3 |
                ((x > Xmax) ? 1 : 0) << 2 |
                ((y < Ymin) ? 1 : 0) << 1 |
                ((y > Ymax) ? 1 : 0);
        }

        public void Clip(int x1, int y1, int x2, int y2)
        {
            graphics.DrawLine(new Pen(Color.Red), new PointF(x1, y1), new PointF(x2, y2));
            int c1 = GetCode(x1, y1);
            int c2 = GetCode(x2, y2);
            int dx, dy;
            if ((c1 & c2) != 0) return;
            while ((c1 | c2) != 0)
            {
                dx = x2 - x1;
                dy = y2 - y1;
                if (c1 != 0)
                {
                    if (x1 < Xmin)
                    {
                        y1 += dy * (Xmin - x1) / dx;
                        x1 = Xmin;

                        continue;
                    }

                    if (x1 > Xmax)
                    {
                        y1 += dy * (Xmax - x1) / dx;
                        x1 = Xmax;

                        continue;
                    }

                    if (y1 < Ymin)
                    {
                        x1 += dx * (Ymin - y1) / dy;
                        y1 = Ymin;

                        continue;
                    }

                    if (y1 > Ymax)
                    {
                        x1 += dx * (Ymax - y1) / dy;
                        y1 = Ymax;

                        continue;
                    }
                    c1 = GetCode(x1, y1);
                }
                else
                {
                    if (x2 < Xmin)
                    {
                        y2 += dy * (Xmin - x2) / dx;
                        x2 = Xmin;

                        continue;
                    }

                    if (x2 > Xmax)
                    {
                        y2 += dy * (Xmax - x2) / dx;
                        x2 = Xmax;

                        continue;
                    }

                    if (y2 < Ymin)
                    {
                        x2 += dx * (Ymin - y2) / dy;
                        y2 = Ymin;

                        continue;
                    }

                    if (y2 > Ymax)
                    {
                        x2 += dx * (Ymax - y2) / dy;
                        y2 = Ymax;

                        continue;
                    }
                    c2 = GetCode(x2, y2);
                }
                if ((c1 & c2) != 0) break;
            }

            graphics.DrawLine(new Pen(Color.White), new PointF(x1, y1), new PointF(x2, y2));


        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            graphics.Clear(Color.Indigo);
            if (RectPoints.Count != 2)
            {
                RectPoints.Add(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
            else 
            {
                LinesPoints.Add(new Point(Cursor.Position.X, Cursor.Position.Y));
                
            }
            
            if (RectPoints.Count == 2)
            {
                CreateRectangle();
                Xmin = RectPoints[0].X;
                Ymin = RectPoints[0].Y;
                Xmax = RectPoints[1].X;
                Ymax = RectPoints[1].Y;

            }
            CreateLines();
            graphics.DrawEllipse(pen, Cursor.Position.X, Cursor.Position.Y, 10, 10);
            pictureBox1.Image = bitmap;
        }

        private void DrawAll()
        {
            if (RectPoints.Count == 2)
                CreateRectangle();
            CreateLines();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            graphics.Clear(Color.Indigo);
            DrawAll();
            graphics.DrawEllipse(pen, Cursor.Position.X, Cursor.Position.Y, 10, 10);
            if (LinesPoints.Count >= 2)
            {
                for (int i = 1; i < LinesPoints.Count; i+=2)
                {
                    Clip(LinesPoints[i - 1].X, LinesPoints[i - 1].Y, LinesPoints[i].X, LinesPoints[i].Y);
                }
            }
            pictureBox1.Image = bitmap;
            Cursor.Hide();
        }

        private void Otrezki_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.E)
            {
                
                    Clip(LinesPoints[0].X, LinesPoints[0].Y, LinesPoints[1].X, LinesPoints[1].Y);
                
            }
        }
    }
}
