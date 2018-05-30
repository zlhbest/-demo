using System;
using System.Collections.Generic;
using System.Text;

namespace MyPaint
{
    class DEM
    {
        public double RowsNum;//行数
        public double ColsNum;//列数
        public double Xmin;//x的最小值
        public double Xmax;//x的最大值
        public double Ymin;//Y的最小值
        public double Ymax;//Y的最大值
        public double Zmin;//Z的最小值
        public double Zmax;//Z的最大值
        public double[,] ElementData;//用来存点的
        public int cellsize; //有个栅格的大小
    }
}
