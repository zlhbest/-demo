using System;
using System.Collections.Generic;
using System.Text;

namespace MyPaint
{
    class DEMSurfacearea
    {
        public double cellsize;
        //一个方格的面积
        public double fanggemianji(double cellsize)
        {
            return cellsize * cellsize;
        }
        //以栅格计算dem表面积
        public double DEMmj(double cellsize, int shange)
        {
            return fanggemianji(cellsize)*shange;
        }

    }
}
