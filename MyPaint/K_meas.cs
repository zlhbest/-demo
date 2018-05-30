using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MyPaint
{
    /// <summary>
    /// 这里的K_means算法仅仅是二维的情况
    /// </summary>
    class K_meas
    {
        Random rod = new Random();
        int k;//指定划分的簇数  
        int repeat;//运行的次数
        public K_meas(int k, int repeat)
        {
            this.k = k;
            this.repeat = repeat;
        }
        //初始化k个质心
        public Point[][] cluster(Point[] p)
        {
            //存放旧的聚类点
            Point[] c = new Point[k];
            //存放新的聚类点
            Point[] nc = new Point[k];
            //存放最终结果
            Point[][] g;
            // 初始化聚类中心
            // 经典方法是随机选取 k 个
            // 本例中采用前 k 个作为聚类中心
            // 聚类中心的选取不影响最终结果
            for (int i = 0; i < k; i++)
            {
                c[i].X = rod.Next(400);
                c[i].Y = rod.Next(400);
            }
            // 循环聚类，更新聚类中心
            // 到聚类中心不变为止
            while (true)
            {
                // 根据聚类中心将元素分类
                g = group(p, c);
                for (int i = 0; i < g.Length;i++ )
                {
                    nc[i] = center(g[i]);
                }
                if (!equal(nc, c))
                {
                    //为下一次的聚类准备
                    c = nc;
                    nc = new Point[k];
                }
                else
                    break;
            }
            return g;

        }
        //聚类中心函数，二维点的平均值
        public Point center(Point[] P)
        {
            Point pt = new Point();
            if (P.Length != 0)
            {
                int x = 0;
                int y = 0;
                
                for (int i = 0; i < P.Length; i++)
                {
                    x += P[i].X;
                    y += P[i].Y;
                }
                pt.X = x / P.Length;
                pt.Y = y / P.Length;
              
            }
            return pt;
        }
        //根据c来将p中元素聚类返回二维数组
        public Point[][] group(Point[] p, Point[] c)
        {
            //中间变量用来分组标记
            int[] gi = new int[p.Length];
            // 考察每一个元素 pi 同聚类中心 cj 的距离
            // pi 与 cj 的距离最小则归为 j 类
            for (int i = 0; i < p.Length;i++ )
            {
                //存放距离
                double[] d = new double[c.Length];
                //计算每一个点到聚类点的距离
                for (int j = 0; j < c.Length;j++ )
                {
                    d[j] = distance(p[i], c[j]);
                }
                //找出最小的距离
                int ci = min(d);
                //标记属于哪一组
                gi[i] = ci;
            }
            //存放分组结果
            Point[][] g = new Point[c.Length][];
            //遍历每个数组中心  分组
            for (int i = 0; i < c.Length; i++)
            {
                //中间变量记录聚类后每一组的大小
                int s = 0;
                //计算每一组的长苏
                for (int j = 0; j < gi.Length; j++)
                {
                    if (gi[j] == i)
                        s++;
                }
                //存储每一组的成员
                g[i] = new Point[s];
                s = 0;
                // 根据分组标记将各元素归位
                for (int j = 0; j < gi.Length; j++)
                    if (gi[j] == i)
                    {
                        g[i][s] = p[j];
                        s++;
                    }
            }
            return g;
        }
        //计算两点间的距离
        public double distance(Point a, Point b)
        {
            double x = a.X - b.X;
            double y = a.Y - b.Y;
            return Math.Sqrt(x * x + y * y);
        }
        /*
    * 给定 double 类型数组，返回最小值得下标。
    */
        public static int min(double[] p)
        {
            int i = 0;
            double m = p[0];
            for (int j = 1; j < p.Length; j++)
            {
                if (p[j] < m)
                {
                    i = j;
                    m = p[j];
                }
            }
            return i;
        }
        /*
    * 判断两个 double 数组是否相等。 长度一样且对应位置值相同返回真。
    */
        public static bool equal(Point[] a, Point[] b)
        {
            if (a.Length != b.Length)
                return false;
            else
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i].X != b[i].X )
                        return false;
                    else if(a[i].Y != b[i].Y )
                        return false;
                }
            }
            return true;
        }
    }
}
