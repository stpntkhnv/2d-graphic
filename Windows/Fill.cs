using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2d_graphic.Windows
{
    public partial class Fill : Form
    {
        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }
        }

        private Pen pen;
        private Bitmap bitmap;
        private Graphics graphics;
        private int width;
        private int height;


        private List<Point> FigurePoints { get; set; }
        private bool IsFilling { get; set; }

        public Fill()
        {
            InitializeComponent();
            FigurePoints = new List<Point>();
            IsFilling = false;
            width = picturebox.Width;
            height = picturebox.Height;
            bitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitmap);
            pen = new Pen(Color.White);
        }

        private void picturebox_MouseClick(object sender, MouseEventArgs e)
        {
            
            //MessageBox.Show("asdasd");
            if(e.Button == MouseButtons.Right)
            {
                Cursor.Hide();
            }

            if(!IsFilling)
            {
                FigurePoints.Add(new Point(Cursor.Position.X, Cursor.Position.Y));
                DrawFigure();
            }
            else
            {
                StartFilling(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private async Task<int> StartFilling(int x, int y)
        {
            Brush brush = Brushes.White;
            Stack<int[]> pixs = new Stack<int[]>();
            pixs.Push(new[] { x, y });
            while (pixs.Count > 0)
            {
                picturebox.Image = bitmap;
                await Task.Delay(1);
                
                
                var n = pixs.Pop();
                if (n[1] >= height)
                {
                    --n[1];
                }
                if (n[0] >= width)
                {
                    --n[0];
                }
                Color pi = ((Bitmap)picturebox.Image).GetPixel(n[0], n[1]);
                if (Color.White.ToArgb() != pi.ToArgb())
                {
                    graphics.FillRectangle(brush, n[0], n[1], 1, 1);
                    pixs.Push(new[] { n[0], n[1] - 1 });
                    pixs.Push(new[] { n[0], n[1] + 1 });
                    pixs.Push(new[] { n[0] + 1, n[1] });
                    pixs.Push(new[] { n[0] - 1, n[1] });
                }
            }
            return 1;
        }

        

        private void picturebox_MouseMove(object sender, MouseEventArgs e)
        {
            if (FigurePoints.Count > 0 && !IsFilling)
            {
                Point lastPoint = FigurePoints.ToArray()[FigurePoints.Count - 1];
                if (!IsFilling)
                {
                    graphics.Clear(Color.Indigo);
                }
                
                DrawFigure();
                if (!IsFilling)
                {
                    graphics.DrawLine(pen, (int)lastPoint.X, (int)lastPoint.Y, Cursor.Position.X - 2, Cursor.Position.Y - 2);
                }
                //graphics.DrawEllipse(new Pen(Color.Black), Cursor.Position.X - 2, Cursor.Position.Y - 2, 5, 5);
            }
        }
        private void DrawFigure()
        {
            if (FigurePoints.Count > 1)
            {
                for (int i = 1; i < FigurePoints.Count; i++)
                {
                    graphics.DrawLine(pen, (int)FigurePoints[i - 1].X, (int)FigurePoints[i - 1].Y, (int)FigurePoints[i].X, (int)FigurePoints[i].Y);
                    picturebox.Image = bitmap;
                }
            }
        }

        private void Filling_Click(object sender, EventArgs e)
        {
            IsFilling = !IsFilling;            
        }

        private void Fill_Leave(object sender, EventArgs e)
        {
            Cursor.Show();
        }
    }
}
