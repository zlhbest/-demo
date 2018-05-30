using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class pointwhere : Form
    {
        string chick = "";
        Point p = new Point();//用于画点
        List<Point> list = new List<Point>();//用于放多边形
        public pointwhere()
        {
            
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请在绘图上面画多边形（右键闭合）");
            chick = "duobianxing";
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (chick)
            {
                case "duobianxing":
                    {
                        
                        Graphics g = pictureBox1.CreateGraphics();
                        if (e.Button==MouseButtons.Left)
                        {
                            Point p = new Point();
                            p.X = e.X;p.Y =e.Y;
                            list.Add(p);
                            int i = 0;
                            if (list.Count>1)
                            {
                                Point[] points = new Point[list.Count];
                                foreach (Point element in list)
                                {
                                    points[i] = element;
                                    i++;
                                }
                                g.DrawLines(new Pen(Color.Red, 1), points);
                            }
                            
                        }
                        else
                        { 
                            int i = 0;
                            Point[] points = new Point[list.Count+1];
                            foreach (Point element in list)
                            {
                                points[i] = element;
                                i++;
                            }
                            points[list.Count] = points[0];
                            g.DrawLines(new Pen(Color.Red, 1), points);
                        }
                        break;
                    }
                case "huadian":
                    {
                        
                        p.X = e.X;
                        p.Y = e.Y;
                        Graphics g = pictureBox1.CreateGraphics();
                        g.DrawEllipse(new Pen(Color.Red, 10), p.X,p.Y,10,10);
                        break;
                    }
                case "clear":
                    {
                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chick = "huadian";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IsInPolygon(p, list))
            {
                MessageBox.Show("点在多边形内");
            }
            else
            {
                MessageBox.Show("点在多边形外");
            }
        }
        public static bool IsInPolygon(PointF checkPoint, List<Point> polygonPoints)
        {
            bool inside = false;
            int pointCount = polygonPoints.Count;
            Point p1, p2;
            for (int i = 0, j = pointCount - 1; i < pointCount; j = i, i++)//第一个点和最后一个点作为第一条线，之后是第一个点和第二个点作为第二条线，之后是第二个点与第三个点，第三个点与第四个点...  
            {
                p1 = polygonPoints[i];
                p2 = polygonPoints[j];
                if (checkPoint.Y < p2.Y)
                {//p2在射线之上  
                    if (p1.Y <= checkPoint.Y)
                    {//p1正好在射线中或者射线下方  
                        if ((checkPoint.Y - p1.Y) * (p2.X - p1.X) > (checkPoint.X - p1.X) * (p2.Y - p1.Y))//斜率判断,在P1和P2之间且在P1P2右侧  
                        {
                            //射线与多边形交点为奇数时则在多边形之内，若为偶数个交点时则在多边形之外。  
                            //由于inside初始值为false，即交点数为零。所以当有第一个交点时，则必为奇数，则在内部，此时为inside=(!inside)  
                            //所以当有第二个交点时，则必为偶数，则在外部，此时为inside=(!inside)  
                            inside = (!inside);
                        }
                    }
                }
                else if (checkPoint.Y < p1.Y)
                {
                    //p2正好在射线中或者在射线下方，p1在射线上  
                    if ((checkPoint.Y - p1.Y) * (p2.X - p1.X) < (checkPoint.X - p1.X) * (p2.Y - p1.Y))//斜率判断,在P1和P2之间且在P1P2右侧  
                    {
                        inside = (!inside);
                    }
                }
            }
            return inside;
        }  

        private void button4_Click(object sender, EventArgs e)
        {
            chick = "clear";
        }
    }
}
