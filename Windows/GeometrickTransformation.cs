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

        private double[,] GetMatrixForRotate(double angle)
        {
            return new double[,] { { Math.Cos(angle), Math.Sin(angle), 0 }, { -Math.Sin(angle), Math.Cos(angle), 0 }, { 0, 0, 1 } };
        }

        private double[,] GetMatrixForMove(double dx, double dy)
        {
            return new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { dx, dy, 1 } };
        }

        private double[,] GetMatrixForResize(double sx, double sy)
        {
            return new double[,] { { sx, 0, 0 }, { 0, sy, 0 }, { 0, 0, 1 } };
        }

        private double[,] GetSimpleMatrix(Point p)
        {
            return new double[,] { { p.X, p.Y, 1 }};
        }


        public GeometrickTransformation()
        {
            InitializeComponent();
            width = pictureBox1.Width;
            height = pictureBox1.Height;
            pen = new Pen(Color.White);
            bitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitmap);
            points = new List<Point>() {new Point(0, height-50), new Point(0, height - 100), new Point(100, height - 100), new Point(70, height - 75), new Point(100, height - 50), new Point(0, height - 50) };
            Draw();
        }

        private void Draw()
        {
            Coordinates();
            DrawFlag();
            pictureBox1.Image = bitmap;
        }

        private void Coordinates()
        {
            graphics.DrawLine(pen, width / 2, 0, width / 2, height);
            graphics.DrawLine(pen, 0, height / 2, width, height / 2);
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

        public void DrawFlag()
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                graphics.DrawLine(pen, (float)points[i].X, (float)points[i].Y, (float)points[i + 1].X, (float)points[i + 1].Y);
            }
        }

        public void Move(double dx, double dy)
        {
            var a = GetMatrixForMove(dx, dy);
            for (int i = 0; i < points.Count; i++)
            {
                points[i].X = MultiplicationMatrix(GetSimpleMatrix(points[i]), a)[0, 0];
                points[i].Y = MultiplicationMatrix(GetSimpleMatrix(points[i]), a)[0, 1];
            }
        }

        public void Resize(double sx, double sy)
        {
            var a = GetMatrixForMove(-points[0].X, -points[0].Y);
            var b = GetMatrixForResize(sx, sy);
            var c = GetMatrixForMove(points[0].X, points[0].Y);
            var result = MultiplicationMatrix(MultiplicationMatrix(a, b), c);
            for (int i = 0; i < points.Count; i++)
            {
                points[i].X = MultiplicationMatrix(GetSimpleMatrix(points[i]), result)[0, 0];
                points[i].Y = MultiplicationMatrix(GetSimpleMatrix(points[i]), result)[0, 1];
            }
        }

        public void SimpleRotate(double angle)
        {
            angle *= 0.0174532925199;

            double x = (double)numericUpDown1.Value;
            double y = (double)numericUpDown2.Value;

            var a = GetMatrixForMove(-x, -y);
            var b = GetMatrixForRotate(angle);
            var c = GetMatrixForMove(x, y);

            var m = MultiplicationMatrix(MultiplicationMatrix(a, b), c);

            for (int i = 0; i < points.Count; i++)
            {
                double[,] result = new double[,] { { points[i].X * Math.Cos(angle) - points[i].Y * Math.Sin(angle), points[i].X * Math.Sin(angle) + points[i].Y * Math.Cos(angle), 1 } };
                points[i].X = MultiplicationMatrix(result, m)[0, 0];
                points[i].Y = MultiplicationMatrix(result, m)[0, 1];
            }
        }

        public void Clear()
        {
            graphics.Clear(Color.Indigo);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Move(0, -20);
            Clear();
            Draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Move(0, 20);
            Clear();
            Draw();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Move(-20, 0);
            Clear();
            Draw();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Move(20, 0);
            Clear();
            Draw();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Resize(1.5, 1);
            Clear();
            Draw();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Resize(0.7, 1);
            Clear();
            Draw();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Resize(1, 1.5);
            Clear();
            Draw();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Resize(1, 0.7);
            Clear();
            Draw();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var dx = points[1].X;
            var dy = points[1].Y;
            SimpleRotate(15);
            Clear();
            Draw();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var dx = points[1].X;
            var dy = points[1].Y;
            SimpleRotate(-15);
            Clear();
            Draw();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Move(-points[1].X, -points[1].Y);
            Clear();
            Draw();
        }
    }
}
