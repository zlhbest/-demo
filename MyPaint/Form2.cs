using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace MyPaint
{
    public partial class Form2 : Form
    {
        int bianshu = 0;
        int count = 0;
        area area1 = new area();
        public struct pointz
        {
            public double X;
            public double Y;
            public double Z;
        }
        public pointz[] points = null; 

        public Form2()
        {
            bianshu = Convert.ToInt32(Interaction.InputBox("输入多边形边数上限", "", "", 50, 50));
            if (bianshu >= 3)
            {
                points = new pointz[bianshu];
            }
            InitializeComponent();
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left && count <= bianshu)
                {
                   
                    double Z = Convert.ToDouble(Interaction.InputBox("输入点的高程值", "", "", 50, 50));
                    points[count].X = e.X;
                    points[count].Y = e.Y;
                    points[count].Z = Z;
                    ++count;
                }
                else if (e.Button == MouseButtons.Right)
                {

                    Point[] point = new Point[count+1];
                    for (int i = 0; i < count; i++)
                    {
                        point[i].X = Convert.ToInt32(points[i].X);
                        point[i].Y = Convert.ToInt32(points[i].Y);
                    }
                    point[count].X = Convert.ToInt32(point[0].X);
                    point[count].Y = Convert.ToInt32(point[0].Y);
                    Graphics g = pictureBox1.CreateGraphics();
                    g.DrawLines(new Pen(Color.Red, 1), point);
                    g.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex);
            }
        }


      
        private void 计算空间面积ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pointz[] pointz=new Pointz[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                pointz[i].x = points[i].X;
                pointz[i].y = points[i].Y;
                pointz[i].z = points[i].Z;
            }
            MessageBox.Show(""+area1.kongmianji(pointz));
        }
    }
}
