using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MyPaint
{
    public partial class Form3 : Form
    {
        Bitmap image = null;
        DEM dem = new DEM();
        DEMSurfacearea1 DS = new DEMSurfacearea1();
        string erwei = "";
        private string filename = "";
        public Form3()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 读入文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //新建文件对话框
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "(*.txt)|*.txt|(*.grd)|*.grd|(*.*)|*.*";//允许文件打开的格式
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.CheckFileExists)
                    {
                        this.filename = openFileDialog.FileName;
                        StreamReader streamReader = new StreamReader(this.filename);
                        string text = streamReader.ReadLine();
                        if ((text = streamReader.ReadLine()) != null)
                        {
                            this.dem.RowsNum = Double.Parse(text.Split(' ')[0]);
                            this.dem.ColsNum = Double.Parse(text.Split(' ')[1]);
                        }
                        this.dem.ElementData = new double[(int)this.dem.RowsNum, (int)this.dem.ColsNum];//创建好矩阵
                        this.dem.cellsize = (int)(1001.0 / this.dem.ColsNum);//将对象单元的方块写出来
                        if ((text = streamReader.ReadLine()) != null)
                        {
                            this.dem.Xmin = Double.Parse(text.Split(' ')[0]);
                            this.dem.Xmax = Double.Parse(text.Split(' ')[1]);
                        }
                        if ((text = streamReader.ReadLine()) != null)
                        {
                            this.dem.Ymin = Double.Parse(text.Split(' ')[0]);
                            this.dem.Ymax = Double.Parse(text.Split(' ')[1]);
                        }
                        if ((text = streamReader.ReadLine()) != null)
                        {
                            this.dem.Zmin = Double.Parse(text.Split(' ')[0]);
                            this.dem.Zmax = Double.Parse(text.Split(' ')[1]);
                        }
                        int num = 0;
                        int num2 = 0;
                        int length = this.dem.ElementData.GetLength(1);
                        while ((text = streamReader.ReadLine()) != null)
                        {
                            if (num2 < length)
                            {
                                for (int i = 0; i < text.Split(' ').Length; i++)
                                {
                                    this.dem.ElementData[num, num2] = Double.Parse(text.Split(' ')[i]);
                                    num2++;
                                }
                            }
                            else
                            {
                                num2 = 0;
                                num++;
                            }
                        }
                        MessageBox.Show("文件读入完毕");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 用来绘制dem
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="TYdirectionAngle"></param>
        /// <param name="TYheightAngle"></param>
        private void DEMshow(Graphics g, bool x, double TYdirectionAngle, double TYheightAngle)
        {
            double num = this.dem.Zmax - this.dem.Zmin;//将dem的高差差值计算出来
            SolidBrush brush = null;
            double[] array = new double[20];//用来存储分层后的dem的z值
            double[,] array2 = new double[3, 3];
            List<double> list = new List<double>();
            List<double> list2 = new List<double>();
            int num2 = Convert.ToInt32(num / 20.0);//存储z值得分层区间
            for (int i = 1; i <= 20; i++)
            {
                array[i - 1] = this.dem.Zmin + (double)(i * num2);//分层设色所用
            }
            int num3 = 0;
            while ((double)num3 < this.dem.RowsNum)//用来行数的循环
            {
                int num4 = 0;
                while ((double)num4 < this.dem.ColsNum)//用来列数的循环
                {
                    double num5 = this.dem.ElementData[num3, num4] - this.dem.Zmin;
                    Rectangle rect = new Rectangle(num4 * this.dem.cellsize, num3 * this.dem.cellsize, this.dem.cellsize, this.dem.cellsize);//定义一个方形的大小
                    if (!x)
                    {
                        if (erwei == "huidu")
                        {
                            double num6 = num5 * 255.0 / num;
                            if (num6 > 255.0)
                            {
                                num6 = 255.0;
                            }
                            else if (num6 < 0.0)
                            {
                                num6 = 0.0;
                            }
                            brush = new SolidBrush(Color.FromArgb(255 - (int)num6, Color.Black));
                        }
                        else if (erwei == "fenceng")
                        {
                            brush = new SolidBrush(this.FindColor_DEM(num5, array));
                        }
                        g.FillRectangle(brush, rect);
                    }
                    else
                    {

                    }
                    num4++;
                }
                num3++;
            }
        }
        /// <summary>
        /// 颜色的分层
        /// </summary>
        /// <param name="depthValue"></param>
        /// <param name="HeightArray"></param>
        /// <returns></returns>
        private Color FindColor_DEM(double depthValue, double[] HeightArray)
        {
            Color result;
            if (depthValue <= this.dem.Zmin)
            {
                result = Color.FromArgb(0, 0, 255);
            }
            else if (depthValue > this.dem.Zmin && depthValue <= HeightArray[0])
            {
                result = Color.FromArgb(173, 246, 177);
            }
            else if (depthValue > HeightArray[0] && depthValue <= HeightArray[1])
            {
                result = Color.FromArgb(183, 246, 237);
            }
            else if (depthValue > HeightArray[1] && depthValue <= HeightArray[2])
            {
                result = Color.FromArgb(186, 254, 197);
            }
            else if (depthValue > HeightArray[2] && depthValue <= HeightArray[3])
            {
                result = Color.FromArgb(227, 255, 183);
            }
            else if (depthValue > HeightArray[3] && depthValue <= HeightArray[4])
            {
                result = Color.FromArgb(252, 255, 184);
            }
            else if (depthValue > HeightArray[4] && depthValue <= HeightArray[5])
            {
                result = Color.FromArgb(187, 223, 113);
            }
            else if (depthValue > HeightArray[5] && depthValue <= HeightArray[6])
            {
                result = Color.FromArgb(44, 177, 52);
            }
            else if (depthValue > HeightArray[6] && depthValue <= HeightArray[7])
            {
                result = Color.FromArgb(0, 133, 64);
            }
            else if (depthValue > HeightArray[7] && depthValue <= HeightArray[8])
            {
                result = Color.FromArgb(158, 164, 40);
            }
            else if (depthValue > HeightArray[8] && depthValue <= HeightArray[9])
            {
                result = Color.FromArgb(241, 187, 19);
            }
            else if (depthValue > HeightArray[10] && depthValue <= HeightArray[11])
            {
                result = Color.FromArgb(219, 103, 0);
            }
            else if (depthValue > HeightArray[11] && depthValue <= HeightArray[12])
            {
                result = Color.FromArgb(179, 43, 3);
            }
            else if (depthValue > HeightArray[12] && depthValue <= HeightArray[13])
            {
                result = Color.FromArgb(122, 10, 0);
            }
            else if (depthValue > HeightArray[13] && depthValue <= HeightArray[14])
            {
                result = Color.FromArgb(117, 25, 0);
            }
            else if (depthValue > HeightArray[14] && depthValue <= HeightArray[15])
            {
                result = Color.FromArgb(109, 44, 12);
            }
            else if (depthValue > HeightArray[15] && depthValue <= HeightArray[16])
            {
                result = Color.FromArgb(210, 82, 0);
            }
            else if (depthValue > HeightArray[16] && depthValue <= HeightArray[17])
            {
                result = Color.FromArgb(132, 81, 52);
            }
            else if (depthValue > HeightArray[17] && depthValue <= HeightArray[18])
            {
                result = Color.FromArgb(167, 149, 135);
            }
            else if (depthValue > HeightArray[18] && depthValue <= HeightArray[19])
            {
                result = Color.FromArgb(206, 202, 203);
            }
            else if (depthValue > HeightArray[19])
            {
                result = Color.FromArgb(241, 231, 242);
            }
            else
            {
                result = Color.White;
            }
            return result;
        }
        private void 分层设色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                erwei = "fenceng";
                image = new Bitmap((int)(this.dem.ColsNum * (double)this.dem.cellsize), (int)(this.dem.RowsNum * (double)this.dem.cellsize));
                Graphics graphics = Graphics.FromImage(image);
                this.DEMshow(graphics, false, 0.0, 0.0);
                this.pictureBox1.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入数据");
            }
        }
        private void 灰度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                erwei = "huidu";
                image = new Bitmap((int)(this.dem.ColsNum * (double)this.dem.cellsize), (int)(this.dem.RowsNum * (double)this.dem.cellsize));
                Graphics graphics = Graphics.FromImage(image);
                this.DEMshow(graphics, false, 0.0, 0.0);
                this.pictureBox1.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show("请先输入数据");
            }
        }

        private void 粗糙计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DEM以方格计算表面积为："+DS.DEMmjc(Convert.ToDouble(dem.cellsize),(int)dem.RowsNum*(int)dem.ColsNum));
        }

        private void 精确计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           MessageBox.Show( "精确dem表面积："+DS.DEMmjj(dem));
        }

       
    }
}
