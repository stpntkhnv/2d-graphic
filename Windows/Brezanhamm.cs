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
    public partial class Brezanhamm : Form
    {
        public Brezanhamm()
        {
            InitializeComponent();
        }

        private Pen pen;
        private Bitmap bitMap;
        private Graphics graphics;
        private int width;
        private int height;
        private int x0;
        private int y0;
        private int x1;
        private int y1;

        private void Form1_Load(object sender, EventArgs e)
        {
            width = pictureBox1.Width;
            height = pictureBox1.Height;
            bitMap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitMap);
            graphics.Clear(Color.Indigo);
            pen = new Pen(Color.White);

            x0 = width / 2 - 200;
            y0 = height / 2;
            x1 = width / 2;
            y1 = height / 2 - 50;

            BresenhamLine(x0, y0, x1, y1);

            pictureBox1.Image = bitMap;
        }

        void BresenhamLine(int x0, int y0, int x1, int y1)
        {
            var steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int d = 2 * dy - dx;
            int d1 = 2 * dy;
            int d2 = (dy - dx) / 2;
            int y = y0;
            for (int x = x0; x <= x1; x++)
            {
                if (d < 0) d += d1;
                else
                {
                    y--;
                    d += d2;
                }
                graphics.FillRectangle(Brushes.White, x, y, 1, 1);
            }
        }

    }
}
