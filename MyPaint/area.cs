using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OpenTK;

namespace MyPaint
{
    class area
    {
       
        /// <summary>
        /// 计算任意多边形的面积，利用分解多边形的方法
        /// </summary>
        /// <returns></returns>
        public float pingmianji(point[] vectorPoints)
        {
            int iCycle, iCount;
            iCycle = 0;
            float iArea = 0;
            iCount = vectorPoints.Length;

            for (iCycle = 0; iCycle < iCount; iCycle++)
            {
                iArea = iArea + (float)(vectorPoints[iCycle].X * vectorPoints[(iCycle + 1) % iCount].Y - vectorPoints[(iCycle + 1) % iCount].X * vectorPoints[iCycle].Y);
            }

            return (float)Math.Abs(0.5 * iArea);
        }
        //平面三角形的面积
        public Double mianji(point a, point b, point c)
        {
            double ab = des(a, b);
            double bc = des(b, c);
            double ac = des(a, c);
            if (ab + bc > ac & ab + ac > bc & ac + bc > ab)
            {
                double s = (ab + ac + bc) / 2;
                return Math.Sqrt(s * (s - ab) * (s - ac) * (s - bc));
            }
            else return 0;

        }
        //计算平面两个点的距离
        public Double des(point a, point b)
        {
            double x = System.Math.Abs(b.X - a.X);
            double y = System.Math.Abs(b.Y - a.Y);
            return Math.Sqrt(x * x + y * y);

        }
        //空间两点的距离
        public Double dexz(Pointz a, Pointz b)
        {
            double x = System.Math.Abs(b.x - a.x);
            double y = System.Math.Abs(b.y - a.y);
            double z = System.Math.Abs(b.z - a.z);
            return Math.Sqrt(x * x + y * y+z*z);
        }
        //空间三角形的面积
        public Double mianjiz(Pointz a, Pointz b, Pointz c)
        {
            double ab = dexz(a, b);
            double bc = dexz(b, c);
            double ac = dexz(a, c);
            if (ab + bc > ac & ab + ac > bc & ac + bc > ab)
            {
                double s = (ab + ac + bc) / 2;
                return Math.Sqrt(s * (s - ab) * (s - ac) * (s - bc));
            }
            else return 0;

        }
        //计算空间多边形,仅限于凸多边形，凹多边形暂时无法计算
        public Double kongmianji(Pointz[] pointz)
        {
            double mianji = 0;
            if (pointz.Length == 3)
            {
               return mianjiz(pointz[0], pointz[1], pointz[2]);
            }
            for (int i = 2; i <pointz.Length; i++)
            {
                mianji+=mianjiz(pointz[0], pointz[i-1], pointz[i]);
            }
            return mianji;
        }
        //dem表面积的计算

    }
}
