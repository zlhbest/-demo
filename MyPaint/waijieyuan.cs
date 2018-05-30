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
    public partial class waijieyuan : Form
    {
        int bianshu=0;
        int i = 0;
        waijie wj = new waijie();
        //triwaijie tri = new triwaijie();
        Point[] points = null;
        public waijieyuan()
        {
            bianshu = Convert.ToInt32(Interaction.InputBox("输入多边形边数上限", "", "", 50, 50));
            points = new Point[bianshu];
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                points[i].X = e.X;
                points[i].Y = e.Y;
                i++;
            }
            else
            { 
                Graphics g = pictureBox1.CreateGraphics();
                Point[] point = new Point[points.Length+1];
               for(int i=0;i<points.Length;i++)
               {
                   point[i].X = (int)points[i].X;
                   point[i].Y = (int)points[i].Y; 
                }
               point[points.Length] = point[0];
                g.DrawLines(new Pen(Color.Red, 1), point);
                g.Dispose();
            }
        }
        //思路出现错误
        //凸多边形
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    int min=0;
        //    double R2=0;
        //    double R1 ;
        //    bool b = true;
        //    double[] mj = new double[bianshu-2];
        //    for (int i = 0; i < mj.Length; i++)
        //    {
        //        double[] dian = new double[2];
        //        dian[0] = tri.waijieyuan(points[0], points[i + 1], points[i + 2])[0];
        //        dian[1] = tri.waijieyuan(points[0], points[i + 1], points[i + 2])[1];
        //        R1 = tri.banjing(dian, points[0]);
         
        //        for (int n = 0; n < points.Length; n++)
        //        {
        //            if (n != 0 && n != i + 1 && n != i + 2)
        //            {
        //                R2 = tri.banjing(dian, points[n]);
        //                if ((int)R1 < (int)R2)
        //                {
        //                    b = false;
        //                    break;
        //                }
        //                //b = true;
        //            }

        //        }
        //        if (!b) continue;
        //        mj[i] = tri.mianji(points[0], points[i + 1], points[i + 2]);
        //    }
        //    for (int j = 0; j < mj.Length; j++)
        //    {
               
        //        double temp=mj[0];
        //        if (temp > mj[j] && mj[j]!=0)
        //        {
        //            temp = mj[j];
        //                min = j;
        //        }
        //    }
        //    double[] dian1 = new double[2];
        //    dian1[0] = tri.waijieyuan(points[0], points[min + 1], points[min + 2])[0];
        //    dian1[1] = tri.waijieyuan(points[0], points[min + 1], points[min + 2])[1];
        //    double R = tri.banjing(dian1, points[0]);
        //    label1.Text = "外接圆的X坐标:" + dian1[0] + "  " + "外接圆的Y坐标:" + dian1[1] + "  " + "外接圆的半径:" + R;
        //    Graphics gra = this.pictureBox1.CreateGraphics();

        //    gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        //    Pen pen = new Pen(Color.Pink);//画笔颜色                                

        //    gra.DrawEllipse(pen, (int)dian1[0] -(int)R, (int)dian1[1] -(int)R, (int)R * 2, (int)R * 2);//画椭圆的方法，x坐标、y坐标、宽、高，如果是100，则半径为50

 
            
        //}

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label2.Text = "X" + e.X + " " + "Y" + e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] mj =new double[bianshu];
            double R2;
            int min = 0;
            yuan[] yan = new yuan[bianshu];
            bool b=true;
            point[] point1 = new point[points.Length + 2];
            for (int q = 0; q < points.Length; q++)
            {
                point1[q].X = points[q].X;
                point1[q].Y = points[q].Y;
            }
            point1[points.Length] = point1[0];//将第一个加到最后一个上面
            point1[points.Length+1] = point1[1];//将第二个加到最后一个上面
            for (int i = 0; i < points.Length ; i++)
            {

                zhixian z1 = new zhixian();
                z1=wj.zx(point1[i], point1[i + 1]);
                zhixian z2 = new zhixian();
                z2.k = -1 / z1.k;
                z2.b = wj.zhongdian(point1[i], point1[i + 1]).Y - z2.k * wj.zhongdian(point1[i], point1[i + 1]).X;
                zhixian z3 = new zhixian();
                z3 = wj.zx(point1[i+1], point1[i +2]);
                zhixian z4 = new zhixian();
                z4.k = -1 / z3.k;
                z4.b = wj.zhongdian(point1[i + 1], point1[i + 2]).Y - z4.k * wj.zhongdian(point1[i+1], point1[i + 2]).X;
                yuan y = new yuan ();
                y = wj.waijieyuan(wj.jiaodian(z2, z4), point1[i]);
                for (int n = 0; n < points.Length; n++)
                {
                    if (n != i && n != i + 1 && n != i + 2)
                    {
                        R2 = wj.banjing(y.p, point1[n]);
                        if (y.R < R2)
                        {
                            b = false;
                            break;
                        }
                        else b = true;
                    }
                }
                if (!b) continue;
                mj[i] = y.mianji;
                yan[i] = y;
            }
             for (int j = 0; j < mj.Length; j++)
             {
                 if (paidxu(chongpai(mj)) == mj[j])
                 {
                     min = j;
                 }
             }
             label1.Text = "外接圆的X坐标:" + yan[min].p.X + "  " + "外接圆的Y坐标:" + yan[min].p.Y + "  " + "外接圆的半径:" + yan[min].R;
             Graphics gra = this.pictureBox1.CreateGraphics();

             gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

             Pen pen = new Pen(Color.Pink);//画笔颜色                                

             gra.DrawEllipse(pen, (int)yan[min].p.X - (int)yan[min].R, (int)yan[min].p.Y - (int)yan[min].R, (int)yan[min].R * 2, (int)yan[min].R * 2);//画椭圆的方法，x坐标、y坐标、宽、高，如果是100，则半径为50
 
        }
        public double[] chongpai(double[] mj)
        {
            int num=0;
            int n=0;
            double[] db ;
            for (int i = 0; i < mj.Length; i++)
            {
                if (mj[i] != 0)
                {
                    num++;
                }
            }
            db = new double[num];
            for (int j = 0; j < mj.Length; j++)
            {
                if (mj[j] != 0)
                {
                    db[n] = mj[j];
                    n++;
                }
            }
            return db;
        }
        public double paidxu(double[] mj)
        {
            for (int i = 0; i < mj.Length - 1; i++)
            {
                for (int j = mj.Length - 1; j > i; j--)
                {
                    if (mj[j] > mj[j - 1])
                    {
                        mj[j] = mj[j] + mj[j - 1];
                        mj[j - 1] = mj[j] - mj[j - 1];
                        mj[j] = mj[j] - mj[j - 1];
                    }
                }
            }
            return mj[mj.Length - 1];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] mj = new double[bianshu];
            double R2;
            int min = 0;
            yuan[] yan = new yuan[bianshu];
            bool b = true;
            point[] point1 = new point[points.Length + 3];
            for (int q = 0; q < points.Length; q++)
            {
                point1[q].X = points[q].X;
                point1[q].Y = points[q].Y;
            }
            point1[points.Length] = point1[0];//将第一个加到最后一个上面
            point1[points.Length+1]=point1[1];
            point1[points.Length + 2] = point1[2];
            for (int i = 0; i < points.Length; i++)
            {

                zhixian z1 = new zhixian();
                z1 = wj.zx(wj.zx(point1[i], point1[i + 1]), wj.zx(point1[i + 1], point1[i + 2]), point1[i + 1], point1, point1[i + 1]);
                zhixian z2 = new zhixian();
                z2 = wj.zx(wj.zx(point1[i + 1], point1[i + 2]), wj.zx(point1[i + 2], point1[i + 3]), point1[i + 2], point1, point1[i + 2]);
         
                yuan y = new yuan();
                y = wj.neiqie(wj.jiaodian(z1, z2), point1[i], point1[i + 1]);
                for (int n = 0; n < points.Length; n++)
                {
                    R2 = wj.banjing(y.p, point1[n]);
                        if (y.R > R2)
                        {
                            b = false;
                            break;
                        }
                        else b = true;
                    
                }
                if (!b) continue;
                mj[i] = y.mianji;
                yan[i] = y;
            }
            for (int j = 0; j < mj.Length; j++)
            {
                if (paidxu(chongpai(mj)) == mj[j])
                {
                    min = j;
                }
            }
            label1.Text = "外接圆的X坐标:" + yan[min].p.X + "  " + "外接圆的Y坐标:" + yan[min].p.Y + "  " + "外接圆的半径:" + yan[min].R;
            Graphics gra = this.pictureBox1.CreateGraphics();

            gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen pen = new Pen(Color.Pink);//画笔颜色                                

            gra.DrawEllipse(pen, (int)yan[min].p.X - (int)yan[min].R, (int)yan[min].p.Y - (int)yan[min].R, (int)yan[min].R * 2, (int)yan[min].R * 2);//画椭圆的方法，x坐标、y坐标、宽、高，如果是100，则半径为50
 
        }


    }
}
