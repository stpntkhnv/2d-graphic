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
    public partial class GeometrickTransformation : Form
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

        private List<Point> points;
        private int width;
        private int height;
        private Pen pen;
        private Bitmap bitmap;
        private Graphics graphics;

        public GeometrickTransformation()
        {
            InitializeComponent();
            width = pictureBox1.Width;
            height = pictureBox1.Height;
            pen = new Pen(Color.White);
            bitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitmap);
            points = new List<Point>() {new Point(0, height-50), new Point(0, height - 100), new Point(100, height - 100), new Point(70, height - 75), new Point(100, height - 50), new Point(0, height - 50) };
            CreateFlag();
        }

        public void CreateFlag()
        {
            for (int i = 1; i < points.Count; i++)
            {
                graphics.DrawLine(pen, (float)points[i - 1].X, (float)points[i - 1].Y, (float)points[i].X, (float)points[i].Y);
                pictureBox1.Image = bitmap;
            }
        }


        public void MoveFlag(double dx, double dy)
        {
            for(int i = 0; i < points.Count; i++)
            {
                points[i].X += dx;
                points[i].Y += dy;
            }
        }

        static double[,] MultiplicationMatrix(double[,] a, double[,] b)
        {
            if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            double[,] r = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("XUY");
        }

        private void GeometrickTransformation_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    MoveFlag(0, -10);
                    break;
                case Keys.A:
                    MoveFlag(-10, 0);
                    break;
                case Keys.S:
                    MoveFlag(0, 10);
                    break;
                case Keys.D:
                    MoveFlag(10, 0);
                    break;
                case Keys.E:
                    Resize(0.75, 1);
                    break;
                case Keys.Q:
                    Resize(1, 0.75);
                    break;
                case Keys.X:
                    Resize(1.5, 1);
                    break;
                case Keys.Y:
                    Resize(1, 1.5);
                    break;
                default:
                    break;
            }
            Clear();
            CreateFlag();
        }

        public void Rotate(double angle)
        {
            angle = angle * Math.PI / 180;
            double[,] matrixForRotate = new double[,] { { Math.Cos(angle), Math.Sin(angle), 0 }, { -Math.Sin(angle), Math.Cos(angle), 0}, { 0, 0, 1} };
            for (int i = 0; i < points.Count; i++)
            {
                points[i].X = MultiplicationMatrix(new double[,] { { points[i].X, points[i].Y, 1 } }, matrixForRotate)[0, 0];
                points[i].Y = MultiplicationMatrix(new double[,] { { points[i].X, points[i].Y, 1 } }, matrixForRotate)[0, 1];
            }
        }

        public void Resize(double sx, double sy)
        {
            double[,] matrixForResize = new double[,] { { sx, 0 }, { 0, sy } };
            double dx = points[0].X;
            double dy = points[0].Y;
            MoveFlag(-dx, -dy);
            for (int i = 0; i < points.Count; i++)
            {
                points[i].X = MultiplicationMatrix(new double[,] { { points[i].X, points[i].Y } }, matrixForResize)[0, 0];
                points[i].Y = MultiplicationMatrix(new double[,] { { points[i].X, points[i].Y } }, matrixForResize)[0, 1];
            }
            MoveFlag(dx, dy);
        }

        public void Clear()
        {
            graphics.Clear(Color.Indigo);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            double angle = e.Button == MouseButtons.Left ? 10 : -10;
            double dx = points[0].X;
            double dy = points[0].Y;
            Clear();
            MoveFlag(-dx, -dy);
            Rotate(angle);
            MoveFlag(dx, dy);
            Clear();
            CreateFlag();
        }
    }
}
