using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MyPaint
{
    class DEMSurfacearea1
    {
        public double cellsize;
        Pointz[] points = null;
        area area1 = new area();
        //一个方格的面积
        public double fanggemianji(double cellsize)
        {
            return cellsize * cellsize;
        }
        //以栅格计算dem表面积
        public double DEMmjc(double cellsize, int shange)
        {
            return fanggemianji(cellsize) * shange;
        }
       //计算角上的面积
        public double mjjiao(double[,] ElementData, int i, int j, int cellsize)//i和j计算都要加1
        {
            points = new Pointz[4];
            points[0].x = cellsize * (i - 1) + cellsize * 1 / 2;
            points[0].y = cellsize * (j - 1) + cellsize * 1 / 2;
            points[0].z = ElementData[i - 1, j - 1];
            if (i-1 == 0 && j-1 == 0)//左下
            {
                points[1].x = cellsize * (i ) + cellsize * 1 / 2;
                points[1].y = cellsize * (j - 1) + cellsize * 1 / 2;
                points[1].z = ElementData[i , j - 1];//右下

                points[2].x = cellsize * (i - 1) + cellsize * 1 / 2;
                points[2].y = cellsize * (j ) + cellsize * 1 / 2;
                points[2].z = ElementData[i - 1, j ];//左上

                points[3].x = cellsize * (i ) + cellsize * 1 / 2;
                points[3].y = cellsize * (j ) + cellsize * 1 / 2;
                points[3].z = ElementData[i , j ];//右上
            }
            else if (i-1 == 0 && j-1 != 0)//左上
            {
                points[1].x = cellsize * (i-1) + cellsize * 1 / 2;
                points[1].y = cellsize * (j -2) + cellsize * 1 / 2;
                points[1].z = ElementData[i-1, j - 2];//左下

                points[2].x = cellsize * (i) + cellsize * 1 / 2;
                points[2].y = cellsize * (j-1) + cellsize * 1 / 2;
                points[2].z = ElementData[i , j-1];//右上

                points[3].x = cellsize * (i) + cellsize * 1 / 2;
                points[3].y = cellsize * (j-2) + cellsize * 1 / 2;
                points[3].z = ElementData[i, j-2];//右下

            }
            else if (i-1 != 0 && j-1 == 0)//右下
            {
                points[1].x = cellsize * (i - 1) + cellsize * 1 / 2;
                points[1].y = cellsize * (j) + cellsize * 1 / 2;
                points[1].z = ElementData[i - 1, j];//右上

                points[2].x = cellsize * (i - 2) + cellsize * 1 / 2;
                points[2].y = cellsize * (j - 1) + cellsize * 1 / 2;
                points[2].z = ElementData[i - 2, j - 1];//左下

                points[3].x = cellsize * (i - 2) + cellsize * 1 / 2;
                points[3].y = cellsize * (j) + cellsize * 1 / 2;
                points[3].z = ElementData[i - 2, j];//左上
            }
            else//右上
            {
                points[1].x = cellsize * (i - 2) + cellsize * 1 / 2;
                points[1].y = cellsize * (j - 1) + cellsize * 1 / 2;
                points[1].z = ElementData[i - 2, j - 1];//左上

                points[2].x = cellsize * (i - 1) + cellsize * 1 / 2;
                points[2].y = cellsize * (j - 2) + cellsize * 1 / 2;
                points[2].z = ElementData[i - 1, j - 2];//右下

                points[3].x = cellsize * (i - 2) + cellsize * 1 / 2;
                points[3].y = cellsize * (j - 2) + cellsize * 1 / 2;
                points[3].z = ElementData[i - 2, j - 2];//左下
              
            }
            return area1.mianjiz(points[0], points[1], points[3]) / 4 + area1.mianjiz(points[0], points[2], points[3]) / 4 + cellsize * cellsize * 3 / 4;
            
 
        }
        //计算边上的面积
        public double mjbian(double[,] ElementData, int i, int j, int cellsize,double RowsNum,double ColsNum)//i j +1
        {
            points = new Pointz[4];
            points[0].x = cellsize * (i - 1) + cellsize * 1 / 2;
            points[0].y = cellsize * (j - 1) + cellsize * 1 / 2;
            points[0].z = ElementData[i - 1, j - 1];
            if (i == 1&&j!=1)
            {
                points[1].x = cellsize * (i-1) + cellsize * 1 / 2;
                points[1].y = cellsize * (j -2) + cellsize * 1 / 2;
                points[1].z = ElementData[i-1, j - 2];

                points[2].x = cellsize * (i-1 ) + cellsize * 1 / 2;
                points[2].y = cellsize * (j) + cellsize * 1 / 2;
                points[2].z = ElementData[i - 1, j];

                points[3].x = cellsize * (i) + cellsize * 1 / 2;
                points[3].y = cellsize * (j-1) + cellsize * 1 / 2;
                points[3].z = ElementData[i, j-1];
      
            }
            else if (i != 1 && j == 1)
            {
                points[1].x = cellsize * (i - 2) + cellsize * 1 / 2;
                points[1].y = cellsize * (j-1 ) + cellsize * 1 / 2;
                points[1].z = ElementData[i - 2, j-1 ];

                points[2].x = cellsize * (i ) + cellsize * 1 / 2;
                points[2].y = cellsize * (j-1) + cellsize * 1 / 2;
                points[2].z = ElementData[i , j-1];

                points[3].x = cellsize * (i-1) + cellsize * 1 / 2;
                points[3].y = cellsize * (j ) + cellsize * 1 / 2;
                points[3].z = ElementData[i-1, j];
               
            }
            else if (i == RowsNum )
            {
                points[1].x = cellsize * (i - 1) + cellsize * 1 / 2;
                points[1].y = cellsize * (j ) + cellsize * 1 / 2;
                points[1].z = ElementData[i - 1, j ];

                points[2].x = cellsize * (i-1) + cellsize * 1 / 2;
                points[2].y = cellsize * (j - 2) + cellsize * 1 / 2;
                points[2].z = ElementData[i-1, j - 2];

                points[3].x = cellsize * (i - 2) + cellsize * 1 / 2;
                points[3].y = cellsize * (j-1) + cellsize * 1 / 2;
                points[3].z = ElementData[i - 2, j-1];
               
              
            }
            else {
                points[1].x = cellsize * (i - 2) + cellsize * 1 / 2;
                points[1].y = cellsize * (j - 1) + cellsize * 1 / 2;
                points[1].z = ElementData[i - 2, j - 1];

                points[2].x = cellsize * (i ) + cellsize * 1 / 2;
                points[2].y = cellsize * (j-1) + cellsize * 1 / 2;
                points[2].z = ElementData[i , j-1];

                points[3].x = cellsize * (i-1) + cellsize * 1 / 2;
                points[3].y = cellsize * (j - 2) + cellsize * 1 / 2;
                points[3].z = ElementData[i-1, j - 2];
               
            }
            return area1.mianjiz(points[0], points[1], points[3]) / 2 + area1.mianjiz(points[0], points[2], points[3]) / 2 + cellsize * cellsize /2;
        }
       //计算里面的点
        public double mjli(double[,] ElementData, int i, int j, int cellsize)
        {
            points = new Pointz[9];
            points[0].x = cellsize * (i - 1) + cellsize * 1 / 2;
            points[0].y = cellsize * (j - 1) + cellsize * 1 / 2;
            points[0].z = ElementData[i - 1, j - 1];

            points[1].x = cellsize * (i - 1) + cellsize * 1 / 2;
            points[1].y = cellsize * (j - 2) + cellsize * 1 / 2;
            points[1].z = ElementData[i - 1, j - 2];

            points[2].x = cellsize * (i - 1) + cellsize * 1 / 2;
            points[2].y = cellsize * (j ) + cellsize * 1 / 2;
            points[2].z = ElementData[i - 1, j ];

            points[3].x = cellsize * (i - 2) + cellsize * 1 / 2;
            points[3].y = cellsize * (j - 1) + cellsize * 1 / 2;
            points[3].z = ElementData[i - 2, j - 1];

            points[4].x = cellsize * (i ) + cellsize * 1 / 2;
            points[4].y = cellsize * (j - 1) + cellsize * 1 / 2;
            points[4].z = ElementData[i , j - 1];

            points[5].x = cellsize * (i - 2) + cellsize * 1 / 2;
            points[5].y = cellsize * (j - 2) + cellsize * 1 / 2;
            points[5].z = ElementData[i - 2, j - 2];

            points[6].x = cellsize * (i ) + cellsize * 1 / 2;
            points[6].y = cellsize * (j - 2) + cellsize * 1 / 2;
            points[6].z = ElementData[i , j - 2];

            points[7].x = cellsize * (i - 2) + cellsize * 1 / 2;
            points[7].y = cellsize * (j ) + cellsize * 1 / 2;
            points[7].z = ElementData[i - 2, j ];

            points[8].x = cellsize * (i ) + cellsize * 1 / 2;
            points[8].y = cellsize * (j ) + cellsize * 1 / 2;
            points[8].z = ElementData[i, j ];
            double a1 = area1.mianjiz(points[0],points[1],points[2])/4;
            double a2 = area1.mianjiz(points[0],points[2],points[3])/4;
            double a3 = area1.mianjiz(points[0],points[3],points[4])/4;
            double a4 = area1.mianjiz(points[0],points[4],points[5])/4;
            double a5 = area1.mianjiz(points[0],points[5],points[6])/4;
            double a6 = area1.mianjiz(points[0],points[6],points[7])/4;
            double a7 = area1.mianjiz(points[0],points[7],points[8])/4;
            double a8 = area1.mianjiz(points[0],points[8],points[1])/4;
            return a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8;
        }
        public double DEMmjj(DEM dem)
        {
            double sum=0;
            for (int i = 0; i < dem.ColsNum; i++)
            {
                for (int j = 0; j < dem.RowsNum; j++)
                {
                    if ((i == 0 && j == 0) || (i == 0 && j == dem.RowsNum - 1) || (i == dem.ColsNum - 1 && j == 0) || (i == dem.ColsNum - 1 && j == dem.RowsNum - 1))
                    {
                       sum+= mjjiao(dem.ElementData, i + 1, j + 1, dem.cellsize);
                    }
                    else if ((i - 1 < 0 && j != 0 && j != dem.RowsNum - 1) || (j - 1 < 0 && i != 0 && i != dem.ColsNum - 1) || (i + 1 == dem.ColsNum && j != 0 && j != dem.RowsNum - 1) || (j + 1 == dem.RowsNum && i != 0 && i != dem.ColsNum - 1))
                    {
                        sum += mjbian(dem.ElementData, i + 1, j + 1, dem.cellsize, dem.RowsNum, dem.ColsNum);
                    }
                    else {
                        sum += mjli(dem.ElementData, i + 1, j + 1, dem.cellsize);
                    }
                }
            }
            return sum;
        }

    }
}

