namespace MySaoLei
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.难度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.初级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始新游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束本局游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.led2 = new MySaoLei.LED();
            this.led1 = new MySaoLei.LED();
            this.mineField1 = new MySaoLei.MineField();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.难度ToolStripMenuItem,
            this.自定义ToolStripMenuItem,
            this.开始新游戏ToolStripMenuItem,
            this.结束本局游戏ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(423, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 难度ToolStripMenuItem
            // 
            this.难度ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.初级ToolStripMenuItem,
            this.中级ToolStripMenuItem,
            this.高级ToolStripMenuItem});
            this.难度ToolStripMenuItem.Name = "难度ToolStripMenuItem";
            this.难度ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.难度ToolStripMenuItem.Text = "难度";
            // 
            // 初级ToolStripMenuItem
            // 
            this.初级ToolStripMenuItem.Name = "初级ToolStripMenuItem";
            this.初级ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.初级ToolStripMenuItem.Text = "初级";
            this.初级ToolStripMenuItem.Click += new System.EventHandler(this.初级ToolStripMenuItem_Click);
            // 
            // 中级ToolStripMenuItem
            // 
            this.中级ToolStripMenuItem.Name = "中级ToolStripMenuItem";
            this.中级ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.中级ToolStripMenuItem.Text = "中级";
            this.中级ToolStripMenuItem.Click += new System.EventHandler(this.中级ToolStripMenuItem_Click);
            // 
            // 高级ToolStripMenuItem
            // 
            this.高级ToolStripMenuItem.Name = "高级ToolStripMenuItem";
            this.高级ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.高级ToolStripMenuItem.Text = "高级";
            this.高级ToolStripMenuItem.Click += new System.EventHandler(this.高级ToolStripMenuItem_Click);
            // 
            // 自定义ToolStripMenuItem
            // 
            this.自定义ToolStripMenuItem.Name = "自定义ToolStripMenuItem";
            this.自定义ToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.自定义ToolStripMenuItem.Text = "自定义";
            this.自定义ToolStripMenuItem.Click += new System.EventHandler(this.自定义ToolStripMenuItem_Click);
            // 
            // 开始新游戏ToolStripMenuItem
            // 
            this.开始新游戏ToolStripMenuItem.Name = "开始新游戏ToolStripMenuItem";
            this.开始新游戏ToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.开始新游戏ToolStripMenuItem.Text = "开始新游戏";
            this.开始新游戏ToolStripMenuItem.Click += new System.EventHandler(this.开始新游戏ToolStripMenuItem_Click);
            // 
            // 结束本局游戏ToolStripMenuItem
            // 
            this.结束本局游戏ToolStripMenuItem.Name = "结束本局游戏ToolStripMenuItem";
            this.结束本局游戏ToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.结束本局游戏ToolStripMenuItem.Text = "结束本局游戏";
            this.结束本局游戏ToolStripMenuItem.Click += new System.EventHandler(this.结束本局游戏ToolStripMenuItem_Click);
            // 
            // led2
            // 
            this.led2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.led2.Location = new System.Drawing.Point(280, 39);
            this.led2.Margin = new System.Windows.Forms.Padding(5);
            this.led2.Name = "led2";
            this.led2.Size = new System.Drawing.Size(109, 60);
            this.led2.TabIndex = 5;
            this.led2.Load += new System.EventHandler(this.led2_Load);
            // 
            // led1
            // 
            this.led1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.led1.Location = new System.Drawing.Point(31, 39);
            this.led1.Margin = new System.Windows.Forms.Padding(5);
            this.led1.Name = "led1";
            this.led1.Size = new System.Drawing.Size(109, 60);
            this.led1.TabIndex = 4;
            // 
            // mineField1
            // 
            this.mineField1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mineField1.Location = new System.Drawing.Point(30, 120);
            this.mineField1.Margin = new System.Windows.Forms.Padding(5);
            this.mineField1.Name = "mineField1";
            this.mineField1.Size = new System.Drawing.Size(350, 350);
            this.mineField1.TabIndex = 2;
            this.mineField1.Load += new System.EventHandler(this.mineField1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(423, 523);
            this.Controls.Add(this.led2);
            this.Controls.Add(this.led1);
            this.Controls.Add(this.mineField1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "扫雷";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MineField mineField1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 难度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 初级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自定义ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始新游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束本局游戏ToolStripMenuItem;
        public LED led1;
        public LED led2;
    }
}

