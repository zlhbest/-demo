using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class Meanclustering : Form
    {
        Graphics g = null;
        string on = "";
        List<Point> list = new List<Point>();//记录鼠标点击的点
        Random rod = new Random();//随机数生成
        static int randrom = 800;//随机点的个数
        Point[] points = new Point[randrom];// 随机点数组
        
        public Meanclustering()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < randrom;i++ )
            {
                Point p = new Point();//定义一个点
                p.X = rod.Next(pictureBox1.Width);
                p.Y = rod.Next(pictureBox1.Height);
                points[i] = p;
                g = pictureBox1.CreateGraphics();
                g.DrawEllipse(new Pen(Color.Red, 1), p.X, p.Y, 1, 1);
             }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            on = "addpoint";
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (on.Equals("addpoint"))
            {
                if (e.Button==MouseButtons.Left)
                {
                    Point p = new Point();
                    p.X = e.X;
                    p.Y = e.Y;
                    list.Add(p);
                    g.DrawEllipse(new Pen(Color.Yellow, 1), p.X, p.Y, 1, 1);
                }
            }
        }
        public void k_means()
        {
            int i=0;
            Point[] pt=new Point[list.Count+points.Length];
            foreach (Point element in list)
             {
                  pt[i] = element;
                  i++;
             }
            for (int j=0;j<points.Length;j++)
            {
                pt[list.Count+j]=points[j];
            }
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            K_meas km = new K_meas(a,b);
            for (int n = 0; n < km.cluster(pt).Length; n++)
            {
               int R,G,B;
                R = rod.Next(255);
                G = rod.Next(255);
                B = rod.Next(255);
                for (int m = 0; m < km.cluster(pt)[n].Length; m++)
                {
                    Point p = km.cluster(pt)[n][m];
                    g.DrawEllipse(new Pen(Color.FromArgb(R,G,B), 1), p.X, p.Y, 1, 1);
                }
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            k_means();
        }

    }
}
