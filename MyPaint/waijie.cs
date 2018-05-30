using System;
using System.Collections.Generic;
using System.Text;

namespace MyPaint
{
    class waijie
    {
        //取线段的中点
        public point zhongdian(point a, point b)
        {
            point c = new point();
            c.X = (a.X + b.X) / 2;
            c.Y = (a.Y + b.Y) / 2;
            return c;
        }
        //算直线的k,b
        public zhixian zx(point a, point b)
        {
            zhixian zhix = new zhixian();
            zhix.k = (b.Y - a.Y) / (b.X - a.X);
            zhix.b = a.Y - zhix.k * a.X;
            return zhix;
        }
        //求两直线垂直k1和k2相乘=-1
        public point jiaodian(zhixian a, zhixian b)
        {
            point p = new point();
            p.X = (a.b - b.b) / (b.k - a.k);
            p.Y = a.k * p.X + a.b;
            return p;
        }
        public bool jiaodian(zhixian a, zhixian b,point c)
        {
            point p = new point();
            p.X = (a.b - b.b) / (b.k - a.k);
            p.Y = a.k * p.X + a.b;
            if (p.X == c.X && p.Y == c.Y) return false;
            else return  true;
        }
        public yuan waijieyuan(point a, point b)
        {
            yuan y = new yuan();
            y.p = a;
            y.R = banjing(y.p, b);
            y.mianji = y.R * y.R * Math.PI ;
            return y;
 
        }
        //角平分线
        public zhixian zx(zhixian a,zhixian b, point c,point[] p,point d)
        {
            zhixian zhix = new zhixian();
            zhix.k = (a.k * b.k - 1 + Math.Sqrt(((1 - a.k * b.k) * (1 - a.k * b.k)) + ((a.k + b.k) * (a.k + b.k)))) / (a.k + b.k);
            zhix.b = c.Y - zhix.k * c.X;
            if (zxjgd(zhix, p, d)) return zhix;
            else
            {
                zhix.k = (a.k * b.k - 1 - Math.Sqrt(((1 - a.k * b.k) * (1 - a.k * b.k)) + ((a.k + b.k) * (a.k + b.k)))) / (a.k + b.k);
                zhix.b = c.Y - zhix.k * c.X;
                return zhix;
            }
        }
        public bool zxjgd(zhixian a, point[] p,point b)
        {
            bool Bool=true;
            for (int i = 0; i < p.Length-2; i++)
            {
                if (!jiaodian(a, zx(p[i], p[i + 1]), b)) Bool = false;
            }
            return Bool;//如果焦点不是本点输出true
        }
        public  double PointToSegDist(zhixian a,point c)
        {
            double b = a.k * c.X - c.Y + a.b;
            double d = Math.Sqrt(a.k * a.k + 1);
            return Math.Abs(b/d);
        }
        //计算内切圆
        public yuan neiqie(point dian, point b, point c)
        {
            yuan y = new yuan();
            y.p.X = dian.X;
            y.p.Y = dian.Y;
            y.R = PointToSegDist(zx(b,c), dian);
            y.mianji = y.R * y.R * Math.PI;
            return y;
        }
       
        public double banjing(point a, point b)
        {
            double zong = 0;
            Double xy = 0, xy2 = 0;
            xy = (a.X - b.X) * (a.X - b.X);
            xy2 = (a.Y - b.Y) * (a.Y - b.Y);
            zong = xy + xy2;
            return Math.Sqrt(zong);

        }


    }
}
