namespace MyPaint
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.面积计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.平面面积ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间面积ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dEM表面积ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.距离计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.欧式距离ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绝对值距离ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.切式距离ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.明氏距离ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.马氏距离ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.球面距离ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.算法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.道格拉斯ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.多边形外接圆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tIN的生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分型图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.多边形内切圆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.判断点在多边形内ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kmeans点聚合ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.StatusStrip();
            this.toolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.凸包ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pictureBox1.Location = new System.Drawing.Point(124, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(737, 560);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.面积计算ToolStripMenuItem,
            this.距离计算ToolStripMenuItem,
            this.算法ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(873, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 面积计算ToolStripMenuItem
            // 
            this.面积计算ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.平面面积ToolStripMenuItem,
            this.空间面积ToolStripMenuItem,
            this.dEM表面积ToolStripMenuItem});
            this.面积计算ToolStripMenuItem.Name = "面积计算ToolStripMenuItem";
            this.面积计算ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.面积计算ToolStripMenuItem.Text = "面积计算";
            // 
            // 平面面积ToolStripMenuItem
            // 
            this.平面面积ToolStripMenuItem.Name = "平面面积ToolStripMenuItem";
            this.平面面积ToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.平面面积ToolStripMenuItem.Text = "平面面积";
            this.平面面积ToolStripMenuItem.Click += new System.EventHandler(this.平面面积ToolStripMenuItem_Click);
            // 
            // 空间面积ToolStripMenuItem
            // 
            this.空间面积ToolStripMenuItem.Name = "空间面积ToolStripMenuItem";
            this.空间面积ToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.空间面积ToolStripMenuItem.Text = "空间面积";
            this.空间面积ToolStripMenuItem.Click += new System.EventHandler(this.空间面积ToolStripMenuItem_Click);
            // 
            // dEM表面积ToolStripMenuItem
            // 
            this.dEM表面积ToolStripMenuItem.Name = "dEM表面积ToolStripMenuItem";
            this.dEM表面积ToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.dEM表面积ToolStripMenuItem.Text = "DEM表面积";
            this.dEM表面积ToolStripMenuItem.Click += new System.EventHandler(this.dEM表面积ToolStripMenuItem_Click);
            // 
            // 距离计算ToolStripMenuItem
            // 
            this.距离计算ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.欧式距离ToolStripMenuItem,
            this.绝对值距离ToolStripMenuItem,
            this.切式距离ToolStripMenuItem,
            this.明氏距离ToolStripMenuItem,
            this.马氏距离ToolStripMenuItem,
            this.球面距离ToolStripMenuItem});
            this.距离计算ToolStripMenuItem.Name = "距离计算ToolStripMenuItem";
            this.距离计算ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.距离计算ToolStripMenuItem.Text = "距离计算";
            // 
            // 欧式距离ToolStripMenuItem
            // 
            this.欧式距离ToolStripMenuItem.Name = "欧式距离ToolStripMenuItem";
            this.欧式距离ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.欧式距离ToolStripMenuItem.Text = "欧式距离";
            this.欧式距离ToolStripMenuItem.Click += new System.EventHandler(this.欧式距离ToolStripMenuItem_Click);
            // 
            // 绝对值距离ToolStripMenuItem
            // 
            this.绝对值距离ToolStripMenuItem.Name = "绝对值距离ToolStripMenuItem";
            this.绝对值距离ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.绝对值距离ToolStripMenuItem.Text = "绝对值距离";
            this.绝对值距离ToolStripMenuItem.Click += new System.EventHandler(this.绝对值距离ToolStripMenuItem_Click);
            // 
            // 切式距离ToolStripMenuItem
            // 
            this.切式距离ToolStripMenuItem.Name = "切式距离ToolStripMenuItem";
            this.切式距离ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.切式距离ToolStripMenuItem.Text = "切式距离";
            this.切式距离ToolStripMenuItem.Click += new System.EventHandler(this.切式距离ToolStripMenuItem_Click);
            // 
            // 明氏距离ToolStripMenuItem
            // 
            this.明氏距离ToolStripMenuItem.Name = "明氏距离ToolStripMenuItem";
            this.明氏距离ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.明氏距离ToolStripMenuItem.Text = "明氏距离";
            this.明氏距离ToolStripMenuItem.Click += new System.EventHandler(this.明氏距离ToolStripMenuItem_Click);
            // 
            // 马氏距离ToolStripMenuItem
            // 
            this.马氏距离ToolStripMenuItem.Name = "马氏距离ToolStripMenuItem";
            this.马氏距离ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.马氏距离ToolStripMenuItem.Text = "马氏距离";
            this.马氏距离ToolStripMenuItem.Click += new System.EventHandler(this.马氏距离ToolStripMenuItem_Click);
            // 
            // 球面距离ToolStripMenuItem
            // 
            this.球面距离ToolStripMenuItem.Name = "球面距离ToolStripMenuItem";
            this.球面距离ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.球面距离ToolStripMenuItem.Text = "球面距离";
            this.球面距离ToolStripMenuItem.Click += new System.EventHandler(this.球面距离ToolStripMenuItem_Click);
            // 
            // 算法ToolStripMenuItem
            // 
            this.算法ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.道格拉斯ToolStripMenuItem,
            this.多边形外接圆ToolStripMenuItem,
            this.tIN的生成ToolStripMenuItem,
            this.分型图ToolStripMenuItem,
            this.多边形内切圆ToolStripMenuItem,
            this.判断点在多边形内ToolStripMenuItem,
            this.kmeans点聚合ToolStripMenuItem,
            this.凸包ToolStripMenuItem});
            this.算法ToolStripMenuItem.Name = "算法ToolStripMenuItem";
            this.算法ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.算法ToolStripMenuItem.Text = "算法";
            // 
            // 道格拉斯ToolStripMenuItem
            // 
            this.道格拉斯ToolStripMenuItem.Name = "道格拉斯ToolStripMenuItem";
            this.道格拉斯ToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.道格拉斯ToolStripMenuItem.Text = " Douglas-Peuker算法";
            this.道格拉斯ToolStripMenuItem.Click += new System.EventHandler(this.道格拉斯ToolStripMenuItem_Click);
            // 
            // 多边形外接圆ToolStripMenuItem
            // 
            this.多边形外接圆ToolStripMenuItem.Name = "多边形外接圆ToolStripMenuItem";
            this.多边形外接圆ToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.多边形外接圆ToolStripMenuItem.Text = "多边形外接圆";
            this.多边形外接圆ToolStripMenuItem.Click += new System.EventHandler(this.多边形外接圆ToolStripMenuItem_Click);
            // 
            // tIN的生成ToolStripMenuItem
            // 
            this.tIN的生成ToolStripMenuItem.Name = "tIN的生成ToolStripMenuItem";
            this.tIN的生成ToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.tIN的生成ToolStripMenuItem.Text = "TIN的生成";
            this.tIN的生成ToolStripMenuItem.Click += new System.EventHandler(this.tIN的生成ToolStripMenuItem_Click);
            // 
            // 分型图ToolStripMenuItem
            // 
            this.分型图ToolStripMenuItem.Name = "分型图ToolStripMenuItem";
            this.分型图ToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.分型图ToolStripMenuItem.Text = "分型图";
            this.分型图ToolStripMenuItem.Click += new System.EventHandler(this.分型图ToolStripMenuItem_Click);
            // 
            // 多边形内切圆ToolStripMenuItem
            // 
            this.多边形内切圆ToolStripMenuItem.Name = "多边形内切圆ToolStripMenuItem";
            this.多边形内切圆ToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.多边形内切圆ToolStripMenuItem.Text = "多边形内切圆";
            // 
            // 判断点在多边形内ToolStripMenuItem
            // 
            this.判断点在多边形内ToolStripMenuItem.Name = "判断点在多边形内ToolStripMenuItem";
            this.判断点在多边形内ToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.判断点在多边形内ToolStripMenuItem.Text = "判断点在多边形内";
            this.判断点在多边形内ToolStripMenuItem.Click += new System.EventHandler(this.判断点在多边形内ToolStripMenuItem_Click);
            // 
            // kmeans点聚合ToolStripMenuItem
            // 
            this.kmeans点聚合ToolStripMenuItem.Name = "kmeans点聚合ToolStripMenuItem";
            this.kmeans点聚合ToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.kmeans点聚合ToolStripMenuItem.Text = "k-means点聚合";
            this.kmeans点聚合ToolStripMenuItem.Click += new System.EventHandler(this.kmeans点聚合ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "清空";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip,
            this.toolStrip2});
            this.status.Location = new System.Drawing.Point(0, 645);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(873, 25);
            this.status.TabIndex = 5;
            this.status.Text = "statusStrip1";
            // 
            // toolStrip
            // 
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(39, 20);
            this.toolStrip.Text = "坐标";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(39, 20);
            this.toolStrip2.Text = "鼠标";
            // 
            // 凸包ToolStripMenuItem
            // 
            this.凸包ToolStripMenuItem.Name = "凸包ToolStripMenuItem";
            this.凸包ToolStripMenuItem.Size = new System.Drawing.Size(227, 24);
            this.凸包ToolStripMenuItem.Text = "凸包";
            this.凸包ToolStripMenuItem.Click += new System.EventHandler(this.凸包ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 670);
            this.Controls.Add(this.status);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "计算任意多边形面积";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 面积计算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 平面面积ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空间面积ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dEM表面积ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 距离计算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 欧式距离ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绝对值距离ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 切式距离ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 明氏距离ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 马氏距离ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 球面距离ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip2;
        private System.Windows.Forms.ToolStripMenuItem 算法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 道格拉斯ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 多边形外接圆ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tIN的生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分型图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 多边形内切圆ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 判断点在多边形内ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kmeans点聚合ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 凸包ToolStripMenuItem;
    }
}

