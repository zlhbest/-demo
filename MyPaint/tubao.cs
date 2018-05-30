using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class tubao : Form
    {
        private List<Point> points = new List<Point>();
        private Graphics g = null;
        private string witch = "";
        public tubao()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            witch = "drowpoint";
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
             if (witch.Equals("drowpoint"))
            {
                Point pPoint = new Point();
                pPoint.X = e.X ;
                pPoint.Y = e.Y;
                points.Add(pPoint);
                g = pictureBox1.CreateGraphics();
                g.DrawEllipse(new Pen(Color.Blue, 1), pPoint.X, pPoint.Y, 5, 5);
            }
        }
    }
}
