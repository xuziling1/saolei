using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySaoLei
{
    public partial class Form1 : Form
    {
        public  int row = 5;
        public  int bomb = 5;
        public  int mode = 0;
        public int isExitThread = 0;
        public static Form1 _instance;

        public object SystemBox { get; private set; }

        public Form1()
        {
            _instance = this;
            InitializeComponent();
        }

        /// <summary>
        /// 改变窗口大小
        /// </summary>
        /// <param name="ROW"></param>
        /// <param name="BOMB"></param>
        public void set_border(int ROW,int BOMB)
        {
            //MessageBox.Show("set_border");
            if (Form1._instance.mineField1.gameState == 0 && isExitThread != 0)
            {
                Form1._instance.led2.timer.Close();
                Form1._instance.led2.t.Abort();
                Form1._instance.isExitThread = 0;
            }
            Form1._instance.led1.Reset();
            Form1._instance.led2.Reset();

            row = ROW;
            bomb = BOMB;
            //MessageBox.Show(this.Width.ToString());
            this.mineField1.Height = this.mineField1.Width = row * 30;
            this.led1.Location = new Point(30, 35);
            this.led2.Location = new Point(row * 30 + 60 - 130, 35);
            this.Width = row * 30 + 60;//设置this.Width和this.Height的两行代码必须放在控件之后
            this.Height = row * 30 + 150;
            //this.mineField1.Location.X = 20;
            this.mineField1.Init(0, row, bomb);

        }
        /// <summary>
        /// 重新定义雷区格子数量和雷的数量
        /// </summary>
        /// <param name="mode">选定模式</param>
        /// <param name="row">行列数</param>
        /// <param name="bomb">雷数</param>
        private void mineField1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Form1._instance.mineField1.gameState.ToString());
            set_border(10, 10);
            
        }

        private void 初级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Form1._instance.mineField1.gameState.ToString());
            set_border(10, 10);
        }

        private void 中级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            set_border(15, 30);
        }

        private void 高级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            set_border(20, 50);
        }

        private void 自定义ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Custom c = new Custom();
            c.Show();
            //set_border(row, bomb);
        }

        private void 开始新游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Form1._instance.mineField1.gameState == 0 && isExitThread != 0)
            {
                Form1._instance.led2.timer.Close();
                Form1._instance.led2.t.Abort();
                Form1._instance.isExitThread = 0;
            }
            led1.Reset();
            led2.Reset();
            //this.led2.Timekeeping();
            this.mineField1.Init(1,row,bomb);
        }

        private void 结束本局游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Form1._instance.mineField1.gameState == 0 && isExitThread != 0)
            {
                Form1._instance.led2.timer.Close();
                Form1._instance.led2.t.Abort();
                Form1._instance.isExitThread = 0;
            }
            this.mineField1.DisplayAll();
            foreach (Pane pane in this.mineField1.Controls)
            {
                pane.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void led2_Load(object sender, EventArgs e)
        {

        }
    }
}
