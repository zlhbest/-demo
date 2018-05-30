using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MyPaint
{
    class Koch
    {
        public void kochf(double x1, double y1, double x2, double y2, int depth, Graphics g)
        {
            if (depth <= 1)
            {
                Point point1 = new Point();
                point1.X = (int)x1; point1.Y = (int)y1;
                Point point2 = new Point();
                point2.X = (int)x2; point2.Y = (int)y2;
                g.DrawLine(new Pen(Color.Red, 1), point1, point2);
            }
            else {
                double x4 = x1 * 2 / 3 + x2 * 1 / 3;
                double y4 = y1 * 2 / 3 + y2 * 1 / 3;
                double x5 = x1 * 1 / 3 + x2 * 2 / 3;
                double y5 = y1 * 1 / 3 + y2 * 2 / 3;
                double x6 = (x4 + x5) / 2 + (y4 - y5) * Math.Sqrt(3) / 2;
                double y6 = (y4 + y5) / 2 + (x5 - x4) * Math.Sqrt(3) / 2;
                kochf(x1, y1, x4, y4, depth - 1, g);
                kochf(x4, y4, x6, y6, depth - 1, g);
                kochf(x5, y5, x2, y2, depth - 1, g);
                kochf(x6, y6, x5, y5, depth - 1, g);
            }
     
        }
        public void paint(Graphics g, int depth)
        {
            kochf(280.0, 10.0, 164.5, 210.0, depth, g);
            kochf(164.5,210.0,395.5,210.0, depth, g);
            kochf(395.5,210.0,280.0,10.0, depth, g);
        }
    }
}
