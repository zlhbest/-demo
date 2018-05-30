using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class fenxing : Form
    {
        Koch kc = new Koch();
        public fenxing()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            double x1 = Convert.ToDouble(textBox2.Text);
             double y1 = Convert.ToDouble(textBox3.Text);
             double x2 = Convert.ToDouble(textBox4.Text);
             double y2 = Convert.ToDouble(textBox5.Text);
            int depth = Convert.ToInt32(textBox1.Text);
            kc.kochf(x1, y1, x2, y2, depth, g);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            int depth = Convert.ToInt32(textBox1.Text);
            kc.paint(g, depth);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            int depth = Convert.ToInt32(textBox1.Text);
            double x1 = Convert.ToDouble(textBox2.Text);
            double y1 = Convert.ToDouble(textBox3.Text);
            kc.kochf(x1, y1, e.X, e.Y, depth, g);
        }


    }
}
