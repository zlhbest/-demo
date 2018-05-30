using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class tubaop : Form
    {
        const int DotRadius = 4;

        bool hasStarted;
        Stack<Point> sp;//stack for points
        List<Point> lp, clp;//points
        List<Point> slp, cslp;//sorted points

        Bitmap bmp;

        private int GlobalIndex;

        public tubaop()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hasStarted = false;
            timer1.Enabled = false;
            tssLabel.Text = "点击窗口，添加点，至少5个";
            btn_Next.Enabled = false;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (hasStarted)
                return;
            if (lp == null)
                lp = new System.Collections.Generic.List<Point>();
            lp.Add(new Point(e.X, e.Y));
            Graphics g = pictureBox1.CreateGraphics();
            g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(e.X - DotRadius, e.Y - DotRadius, 2 * DotRadius, 2 * DotRadius));
            g.Dispose();

            tssLabel.Text = string.Format("点({0},{1})添加完成。", e.X, e.Y);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            tsslocal.Text = string.Format("当前位置：({0},{1})", e.X, e.Y);
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (lp == null || lp.Count < 5)
                return;
            clp = new List<Point>(lp.ToArray());
            btn_Next.Enabled = true;
            btn_Start.Enabled = false;
            hasStarted = true;
            tssLabel.Text = "开始构造";
            SortPoints();
            cslp = new List<Point>(slp.ToArray());
            Redraw();
            timer1.Enabled = true;
        }

        private void MarkPoints(Bitmap b, List<Point> mps)
        {
            Graphics g = Graphics.FromImage(b);
            int i = 0;
            foreach (Point p in mps)
            {
                g.DrawString("p" + i.ToString(), this.Font, new SolidBrush(Color.Orange), p);
                i++;
            }

            g.Dispose();
        }

        /// <summary>
        /// Y值最大的点，Y相同情况下，X值最小
        /// </summary>
        private Point FindBasePoint(List<Point> _lp)
        {
            Point p = _lp[0];
            for (int i = 1; i < _lp.Count; i++)
            {
                if (p.Y < _lp[i].Y)//Y值应最大
                    p = _lp[i];
                if ((p.Y == _lp[i].Y) && (p.X > _lp[i].X))//Y值相等的情况下X值最小
                    p = _lp[i];
            }
            return p;
        }

        /// <summary>
        /// 让指定的点闪动
        /// </summary>
        /// <param name="p">指定的点</param>
        private void FlashPoint(Point p)
        {
            Graphics g = pictureBox1.CreateGraphics();
            for (int i = 0; i < 3; i++)
            {
                g.FillEllipse(new SolidBrush(Color.Yellow), new Rectangle(p.X - DotRadius, p.Y - DotRadius, 2 * DotRadius, 2 * DotRadius));
                System.Threading.Thread.Sleep(80);
                g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(p.X - DotRadius, p.Y - DotRadius, 2 * DotRadius, 2 * DotRadius));
                System.Threading.Thread.Sleep(80);
            }
            g.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sp == null)
                sp = new Stack<Point>();
            if (sp.Count == 0)//将p0,p1,p2放入其中
            {
                for (int i = 0; i < 3; i++)
                {
                    sp.Push(slp[0]);
                    slp.Remove(slp[0]);
                }
                listBox1.Items.Add("初始三点p0,p1,p2入栈");
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                GlobalIndex = 3;
                Redraw();
                timer1.Enabled = false;
                return;
            }

            if (slp.Count != 0)
            {
                sp.Push(slp[0]);
                listBox1.Items.Add("p" + GlobalIndex.ToString() + "入栈");
                FlashPoint(sp.Peek());
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                GlobalIndex++;
                slp.Remove(slp[0]);

                Point p0, p1, p2;
                p2 = sp.Pop();
                p1 = sp.Pop();
                p0 = sp.Peek();
                sp.Push(p1);
                sp.Push(p2);
                int sb = 1;
                while (!IsTurnLeft(p0, p1, p2))
                {
                    p2 = sp.Pop();
                    FlashPoint(sp.Pop());
                    listBox1.Items.Add("p" + (GlobalIndex - 1 - sb).ToString() + "出栈");
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    sb++;

                    p1 = sp.Pop();
                    p0 = sp.Peek();
                    sp.Push(p1);
                    sp.Push(p2);
                }
                Redraw();
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
                btn_Next.Enabled = false;
                listBox1.Items.Add("演示完成！");
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawLine(new Pen(Color.Green), FindBasePoint(clp), sp.Peek());
                g.Dispose();
            }

        }

        private void Redraw()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            MarkPoints(bmp, cslp);
            foreach (Point p in clp)
            {
                g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(p.X - DotRadius, p.Y - DotRadius, 2 * DotRadius, 2 * DotRadius));
            }
            if (sp != null)
                g.DrawLines(new Pen(Color.Green), sp.ToArray());
            g.Dispose();
            pictureBox1.Image = bmp;
        }

        //value Range [0,Pi)
        private double GetAngleToXAxis(Point basePoint, Point askPoint)
        {
            //once base point has been found, b is large than d
            int a, b, c, d;
            a = basePoint.X;
            b = basePoint.Y;
            c = askPoint.X;
            d = askPoint.Y;
            double dist = Math.Sqrt((c - a) * (c - a) + (d - b) * (d - b));
            return Math.Acos((c - a) / dist);
        }

        private bool IsTurnLeft(Point p0, Point p1, Point p2)
        {
            int t = (p1.X - p0.X) * (p0.Y - p2.Y) - (p2.X - p0.X) * (p0.Y - p1.Y);
            return (t >= 0);
        }

        private void SortPoints()
        {
            //remove base point
            slp = new List<Point>(lp.Count);
            Point bp = FindBasePoint(lp);
            slp.Add(bp);
            lp.Remove(bp);
            Point[] pArr = lp.ToArray();
            int i, j, n = lp.Count;
            for (i = 0; i < n - 1; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    if (GetAngleToXAxis(bp, pArr[i]) > GetAngleToXAxis(bp, pArr[j]))
                    {
                        Point tp = pArr[i];
                        pArr[i] = pArr[j];
                        pArr[j] = tp;
                    }
                }
            }
            slp.AddRange(pArr);
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.Black);
            g.Dispose();
            lp = null;
            clp = null;
            slp = null;
            cslp = null;
            sp = null;
            hasStarted = false;
            btn_Start.Enabled = true;
            GlobalIndex = 0;
            listBox1.Items.Clear();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
