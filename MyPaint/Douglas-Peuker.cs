using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace MyPaint
{

    public partial class Douglas_Peuker : Form

    {
        string filename;
        ArrayList myar = new ArrayList();//存入原始数据  
        ArrayList newar = new ArrayList(); //存入抽稀后的数据 
        public struct zuobiao//坐标数据
        {
            public double x;
            public double y;  
        }
       public struct canshu//记录直线参数
       {
           public double k;
           public double b;
       }

        public Douglas_Peuker()
        {
            
            InitializeComponent();
        }
        public canshu xielv(zuobiao shou, zuobiao wei)//求斜率  
        {
            double k, b;
            canshu newcs = new canshu();
            k = (wei.y - shou.y) / (wei.x - shou.x);
            b = shou.y - k * shou.x;
            newcs.k = k;
            newcs.b = b;
            return newcs;
        }
        public double distance(zuobiao dot, canshu cs)//求点到直线距离  
        {
            double dis = (Math.Abs(cs.k * dot.x - dot.y + cs.b)) / Math.Sqrt(cs.k * cs.k + 1);
            return dis;
        }
        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int i = 0;
            if (e.Button == MouseButtons.Right)
            {
                Graphics g = pictureBox1.CreateGraphics();
                Point[] point = new Point[myar.Count];
                foreach (zuobiao z in myar)
                {
                    point[i].X = (int)z.x;
                    point[i].Y = (int)z.y;
                    i++;
                }
                g.DrawLines(new Pen(Color.Red, 1), point);
                g.Dispose();
            }
            else
            {
                zuobiao zb;
                zb.x = e.X;
                zb.y = e.Y;
                myar.Add(zb);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //新建文件对话框
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "(*.txt)|*.txt|(*.*)|*.*";//允许文件打开的格式
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.CheckFileExists)
                    {
                        this.filename = openFileDialog.FileName;
                        StreamReader streamReader = new StreamReader(this.filename);
                        string txt ="";
                        while ((txt = streamReader.ReadLine()) != null)
                        {
                       
                            zuobiao zb;
                            zb.x = Convert.ToInt32(txt.Split(' ')[0]);
                            zb.y = Convert.ToInt32(txt.Split(' ')[1]);
                            myar.Add(zb);
                        }

                    }
                    else 
                    {
                        MessageBox.Show("文件读入完毕");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Douglas(int number1, int number2)
        { 
           int max=0;//定义拥有最大距离值的点的编号  
           canshu myc = new canshu();  
          myc= xielv((zuobiao)myar[number1], (zuobiao)myar[number2-1]);  
           double maxx = distance((zuobiao)myar[number1+1], myc);//假设第二个点为最大距离点  
           double yuzhi = Convert.ToInt32(textBox1.Text);//设阈值  
               for (int i = number1 + 1; i < number2 - 1; i++)//从第二个点遍历到最后一个点前方的点  
               {  
                   if (distance((zuobiao)myar[i], myc) > yuzhi && distance((zuobiao)myar[i], myc) >= maxx)//找出拥有最大距离的点  
                   {  
                       max = i;  
                       maxx = distance((zuobiao)myar[i], myc);  
                   }  
               }  
           if(max==0)//若不存在最大距离点，则只将首尾点存入arraylist，结束这一次的道格拉斯抽稀  
           {
              
               newar.Add((zuobiao)myar[number2-1]);  
               return;  
           }  
           else if (number1 + 1 == max&&number2-2!=max)//如果第二个点是最大距离点，则以下一个点和尾点作为参数进行道格拉斯抽稀释  
           {  
               Douglas(max+1, number2);      
           }  
           else if (number2 - 2 == max&&number1+1!=max)//<span style="font-family: Arial;">如果倒数第二个点是最大距离点，则以首点和倒数第三点作为参数进行道格拉斯抽稀  lt;/span>            
           {  
               Douglas(0, max+1);                
           }  
           else if (number1 + 1 == max && number2 - 2 == max)//如果首点尾点夹住最大距离点，则将最大距离点和尾点存入arraylist  
           {  
               newar.Add((zuobiao)myar[max]);  
               newar.Add((zuobiao)myar[max+1]);  
               return;  
           }  
           else  
           {  
               Douglas(number1, max+1);  
               Douglas(max, number2);  
           }  
            
       }

        private void button1_Click(object sender, EventArgs e)
        {
            newar.Add((zuobiao)myar[0]);
            Douglas(0, myar.Count);
            Graphics g = pictureBox1.CreateGraphics();
            int i = 0;
            Point[] point = new Point[newar.Count];
            foreach (zuobiao z in newar)
            {
               
                point[i].X = (int)z.x;
                point[i].Y = (int)z.y;
                i++;
            }
            g.DrawLines(new Pen(Color.Blue, 1), point);
            g.Dispose();
        }  
       

    }
}
