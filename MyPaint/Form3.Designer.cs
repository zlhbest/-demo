namespace MyPaint
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.二维ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.灰度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分层设色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.三维ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算表面积ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.粗糙计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.精确计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 389);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(855, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.显示ToolStripMenuItem,
            this.计算表面积ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(855, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开文件ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开文件ToolStripMenuItem
            // 
            this.打开文件ToolStripMenuItem.Name = "打开文件ToolStripMenuItem";
            this.打开文件ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.打开文件ToolStripMenuItem.Text = "打开文件";
            this.打开文件ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.二维ToolStripMenuItem,
            this.三维ToolStripMenuItem});
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.显示ToolStripMenuItem.Text = "显示";
            // 
            // 二维ToolStripMenuItem
            // 
            this.二维ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.灰度ToolStripMenuItem,
            this.分层设色ToolStripMenuItem});
            this.二维ToolStripMenuItem.Name = "二维ToolStripMenuItem";
            this.二维ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.二维ToolStripMenuItem.Text = "二维";
            // 
            // 灰度ToolStripMenuItem
            // 
            this.灰度ToolStripMenuItem.Name = "灰度ToolStripMenuItem";
            this.灰度ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.灰度ToolStripMenuItem.Text = "灰度";
            this.灰度ToolStripMenuItem.Click += new System.EventHandler(this.灰度ToolStripMenuItem_Click);
            // 
            // 分层设色ToolStripMenuItem
            // 
            this.分层设色ToolStripMenuItem.Name = "分层设色ToolStripMenuItem";
            this.分层设色ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.分层设色ToolStripMenuItem.Text = "分层设色";
            this.分层设色ToolStripMenuItem.Click += new System.EventHandler(this.分层设色ToolStripMenuItem_Click);
            // 
            // 三维ToolStripMenuItem
            // 
            this.三维ToolStripMenuItem.Name = "三维ToolStripMenuItem";
            this.三维ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.三维ToolStripMenuItem.Text = "三维";
            // 
            // 计算表面积ToolStripMenuItem
            // 
            this.计算表面积ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.粗糙计算ToolStripMenuItem,
            this.精确计算ToolStripMenuItem});
            this.计算表面积ToolStripMenuItem.Name = "计算表面积ToolStripMenuItem";
            this.计算表面积ToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.计算表面积ToolStripMenuItem.Text = "计算表面积";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(855, 361);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // 粗糙计算ToolStripMenuItem
            // 
            this.粗糙计算ToolStripMenuItem.Name = "粗糙计算ToolStripMenuItem";
            this.粗糙计算ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.粗糙计算ToolStripMenuItem.Text = "粗糙计算";
            this.粗糙计算ToolStripMenuItem.Click += new System.EventHandler(this.粗糙计算ToolStripMenuItem_Click);
            // 
            // 精确计算ToolStripMenuItem
            // 
            this.精确计算ToolStripMenuItem.Name = "精确计算ToolStripMenuItem";
            this.精确计算ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.精确计算ToolStripMenuItem.Text = "精确计算";
            this.精确计算ToolStripMenuItem.Click += new System.EventHandler(this.精确计算ToolStripMenuItem_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 411);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form3";
            this.Text = "Form3";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 二维ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 灰度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分层设色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 三维ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 计算表面积ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粗糙计算ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 精确计算ToolStripMenuItem;
    }
}