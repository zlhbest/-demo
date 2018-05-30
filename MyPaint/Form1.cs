using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using OpenTK;

namespace MyPaint
{
    public partial class Form1 : Form
    {
        des d = new des();
        area a = new area();
        private bool CanMove = false;        
        public Point startpt, endpt;
        public point[] points = new point[100];
        public string des = "";
        int count = 0;
        Koch kf = new Koch();
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            toolStrip.Text = "X:" + e.X + "  " + "Y:" + e.Y;
             Graphics g = pictureBox1.CreateGraphics();
            if (e.Button == MouseButtons.Right)
            {
                this.CanMove = true;
            }
            startpt.X = e.X;
            startpt.Y = e.Y;
            points[count].X = startpt.X;
            points[count].Y = startpt.Y;
            ++count;
            if (count >= 2)
            {
                Point[] points2 = new Point[count];
                for (int j = 0; j < count; j++)
                {
                    points2[j].X = (int)points[j].X;
                    points2[j].Y = (int)points[j].Y;
                }
                g.DrawLines(new Pen(Color.Red, 1), points2);
                g.Dispose();
                points2 = new Point[count];
            }
           
           
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
                if (this.CanMove == true)
                {
                    Point[] points1 = new Point[count + 1];
                    Graphics g = pictureBox1.CreateGraphics();
                    points[count] = points[0];
                    for (int j = 0; j <= count ; j++)
                    {
                        points1[j].X = (int)points[j].X;
                        points1[j].Y = (int)points[j].Y;
                    }
                   
                    endpt.X = e.X;
                    endpt.Y = e.Y;
                    g.DrawLines(new Pen(Color.Red, 1), points1);
                    g.Dispose();
                    points1 = new Point[count + 1];
                }
               
        }
        private void 平面面积ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           MessageBox.Show("所画的多边形的面积为：" + a.pingmianji(points));
                 
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            count = 0;
            points = new point[100];

        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStrip2.Text = "X:" + e.X + "  " + "Y:" + e.Y;
        }
        private void 欧式距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            des = "Euclidean";
            double[] x = new double[count];
            double[] y = new double[count];
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = points[i].X;
                y[i] = points[i].Y;
            }

            MessageBox.Show("所画线段的欧式距离为：" + d.Euclidean(x, y)); 
        }
        private void 绝对值距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            des = "Manhattan";
            double[] x = new double[count];
            double[] y = new double[count];
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = points[i].X;
                y[i] = points[i].Y;
            }

            MessageBox.Show("所画线段的绝对值距离为：" + d.Manhattan(x, y)); 
        }
        private void 切式距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            des = "Chebyshev";
            double[] x = new double[count];
            double[] y = new double[count];
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = points[i].X;
                y[i] = points[i].Y;
            }

            MessageBox.Show("所画线段的切式距离为：" + d.Chebyshev(x, y)); 
        }
        private void 明氏距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string  str=Interaction.InputBox("输入次数","m的值","",50,50);
            des = "Minkowski";
            int m = Convert.ToInt32(str);
            double[] x = new double[count];
            double[] y = new double[count];
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = points[i].X;
                y[i] = points[i].Y;
            }

            MessageBox.Show("所画线段的明式距离为：" + d.Minkowski(x, y,m)); 
        }
        private void 马氏距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void 球面距离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            des = "qiu";
            des.point x, y;
            double[] X = new double[count];
            double[] Y = new double[count];
            for (int i = 0; i < X.Length; i++)
            {
                X[i] = points[i].X;
                Y[i] = points[i].Y;
            }
            x.X = X[0];y.X=X[1];
            x.Y= Y[0]; y.Y = Y[1];
            MessageBox.Show("所画线段的球面距离为：" + d.qiu(x, y)); 
        }
        private void 空间面积ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Form2 form = new Form2();
            form.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dEM表面积ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void 道格拉斯ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Douglas_Peuker DP = new Douglas_Peuker();
            DP.Show();
        }

        private void 多边形外接圆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            waijieyuan wj = new waijieyuan();
            wj.Show();
        }

        private void tIN的生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TIN tin = new TIN();
            tin.Show();
        }

        private void 分型图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fenxing fx = new fenxing();
            fx.Show();
        }

        private void 判断点在多边形内ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pointwhere pw = new pointwhere();
            pw.Show();
        }

        private void kmeans点聚合ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Meanclustering ms = new Meanclustering();
            ms.Show();
        }

        private void 凸包ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tubaop tb = new tubaop();
            tb.Show();
        }

       
    }
}