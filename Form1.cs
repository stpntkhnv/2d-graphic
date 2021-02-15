using _2d_graphic.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2d_graphic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Cursor.Show();
        }

        private void OpenFill_button_Click(object sender, EventArgs e)
        {
            Fill f = new Fill();
            f.Show();
        }

        private void OpenFractals_button_Click(object sender, EventArgs e)
        {
            Fractals f = new Fractals();
            f.Show();

        }

        private void OpenGeometricTransformation_button_Click(object sender, EventArgs e)
        {
            GeometrickTransformation g = new GeometrickTransformation();
            g.Show();
        }

        private void OpenVectorButton_Click(object sender, EventArgs e)
        {
            Brezanhamm b = new Brezanhamm();
            b.Show();
        }

        private void OpenOtrezkiButton_Click(object sender, EventArgs e)
        {
            Otrezki o = new Otrezki();
            o.Show();
        }
    }
}
