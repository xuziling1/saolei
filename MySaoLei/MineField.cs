using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MySaoLei
{
    public partial class MineField : UserControl
    {
        public int gameState = 0;
        /// <summary>
        /// 已经翻开的安全格子数量（倒数）
        /// </summary>
        public static int openNum = 0;
        /// <summary>
        /// 插的旗的数量（倒数）
        /// </summary>
        public static int flagNum = 0;
        public MineField()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 初始化雷区
        /// </summary>
        /// <param name="paneLineNum">边长</param>
        /// <param name="mineCount">地雷数</param>
        public void Init(int isFirstTime,int paneLineNum, int mineCount)
        {
            //MessageBox.Show("Init");
            //Form1._instance.led2
            openNum = paneLineNum * paneLineNum - mineCount;//已翻开0个方格
            flagNum = mineCount;
            int t = paneLineNum * paneLineNum;
            //初始化制定数量的方格
            //if(isFirstTime!=0)
            this.Controls.Clear();
            for (int i = 0; i < paneLineNum * paneLineNum; i++)
             {
                    Pane pane = new Pane();
                    pane.MouseDown += new MouseEventHandler(pane_MouseDown);
                    this.Controls.Add(pane);
             }

            //布局位置
            this.LayoutPanes();
            //随机布雷
            this.LayMines(mineCount);
            //设置四周地雷数
            foreach (Pane p in this.Controls)
            {
                p.AroundMineCount = this.GetMineCountAround(p);
            }
        }
        /// <summary>
        /// 获取当前方格四周地雷数量
        /// </summary>
        /// <param name="pane">当前方格</param>
        /// <returns></returns>
        private int GetMineCountAround(Pane pane)
        {
            int result = 0;
            List<Pane> panes = this.GetPanesAround(pane);
            foreach (Pane p in panes)
            {
                if (p.HasMine)
                {
                    result++;
                }
            }
            return result;
        }

        /// <summary>
        /// 获取与当前方格相邻的所有方格。（结果应该是3～8个）
        /// </summary>
        /// <param name="pane">当前方格</param>
        /// <returns></returns>
        private List<Pane> GetPanesAround(Pane pane)
        {
            List<Pane> result = new List<Pane>();

            // 通过递归明示当前方格四周的所有方格
            int paneHeight = this.GetPaneSize().Height;
            int paneWidth = this.GetPaneSize().Width;
            foreach (Pane p in this.Controls)
            {
                // 第一行：找出与当前方格平行的相邻方格（1或2）
                // 第二行：找出与当前方格垂直的相邻方格（1或2）
                // 第三四行：找出与当前方格斜对角的相邻方格（1或2或3或4）
                if (Math.Abs(p.Top - pane.Top) == 0 && Math.Abs(p.Left - pane.Left) == paneWidth
                    || Math.Abs(p.Left - pane.Left) == 0 && Math.Abs(p.Top - pane.Top) == paneHeight
                    || Math.Abs(p.Top - pane.Top) == paneHeight && Math.Abs(p.Left - pane.Left) == paneWidth
                    || Math.Abs(p.Left - pane.Left) == paneWidth && Math.Abs(p.Top - pane.Top) == paneHeight)
                {
                    result.Add(p);
                }
            }
            return result;
        }
        /// <summary>
        /// 方格尺寸
        /// </summary>
        /// <returns></returns>
        private Size GetPaneSize()
        {
            if (this.Controls.Count == 0)
            {
                return new Size();
            }
            else
            {
                int paneNumber = (int)Math.Sqrt(this.Controls.Count);
                int paneWidth = this.Width / paneNumber;
                int paneHeight = this.Height / paneNumber;
                return new Size(paneWidth, paneHeight);
            }
        }

        private void pane_MouseDown(object sender, MouseEventArgs e)
        {
            Pane pane = sender as Pane;
            if (openNum == this.Controls.Count - Form1._instance.bomb && flagNum == Form1._instance.bomb)
            {
                Form1._instance.led2.t = new Thread(Form1._instance.led2.Timekeeping);
                Form1._instance.led2.t.Start();
                Form1._instance.isExitThread = 1;
            }
            if (e.Button == MouseButtons.Left && pane.State == PaneState.Opened)
            {
                TimeSpan span = DateTime.Now - pane.lastTime;
                pane.lastTime = DateTime.Now;
                //MessageBox.Show(span.ToString());
                if (span.Milliseconds<=1000)
                {
                    //MessageBox.Show(span.ToString());
                    List<Pane> panesAround = this.GetPanesAround(pane);
                    int cnt = 0;
                    foreach (Pane p in panesAround)
                    {
                        if (p.State == PaneState.Marked) cnt++;
                    }
                    //MessageBox.Show(cnt.ToString()+" "+ pane.AroundMineCount.ToString());
                    if (cnt == pane.AroundMineCount)
                    {
                        foreach (Pane p in panesAround)
                        {
                            if (p.State == PaneState.Closed )
                            {
                                if (p.HasMine)
                                {
                                    Form1._instance.led1.Reset();
                                    Form1._instance.led1.Set(flagNum);
                                    this.MineSweeppingFailed();
                                }
                                else
                                {
                                    this.DisplayAround(p);
                                }
                            }
                        }
                    }
                }
            }
            if (e.Button == MouseButtons.Left && pane.State == PaneState.Closed)
            {
                if (pane.HasMine)
                {
                    Form1._instance.led1.Reset();
                    Form1._instance.led1.Set(flagNum);
                    this.MineSweeppingFailed();
                }
                else
                {
                    this.DisplayAround(pane);
                }
            }
            else if(e.Button == MouseButtons.Right )
            {
                if (pane.State == PaneState.Marked)
                {
                    pane.Reset();//取消小红旗标记
                }
                else if(pane.State == PaneState.Closed)
                {
                    pane.Mark(); //插个小红旗做标记
                }
            }
            Form1._instance.led1.Reset();
            Form1._instance.led1.Set(flagNum);
            if (openNum == 0 && flagNum == 0) this.MineSweeppingSuccessfully();
        }

        /// <summary>
        /// 显示所有雷区
        /// </summary>
        public void DisplayAll()
        {
            foreach (Pane pane in this.Controls)
            {
                if (pane.State != PaneState.Opened)
                {
                    pane.Open();
                }
            }
        }
        /// <summary>
        /// 显示周围(只做展示不进行判断)
        /// </summary>
        /// <param name="pane">中心格子</param>
        public void DisplayAround(Pane pane)
        {
            if(pane.State == PaneState.Opened || pane.HasMine)
            {
                return;
            }
            pane.Open();// 明示当前方格
            if (this.GetMineCountAround(pane) > 0) return;
            // 通过递归明示当前方格四周的所有方格
            List<Pane> panesAround = this.GetPanesAround(pane);
            foreach (Pane p in panesAround)
            {
                // 如果该方格四周没有相邻的地雷，则递归
                if (this.GetMineCountAround(p) == 0)
                {
                    this.DisplayAround(p);
                }
                else
                {
                    if (p.State != PaneState.Opened && !p.HasMine)
                    {
                        p.Open();
                    }

                }
            }
        }
        /// <summary>
        /// 随机布雷
        /// </summary>
        /// <param name="mineCount"></param>
        private void LayMines(int mineCount)
        {
            Random ran = new Random();
            for(int i=0;i<mineCount;)
            {
                int index = ran.Next(0, this.Controls.Count);
                Pane pane = (Pane)this.Controls[index];
                if (pane.HasMine == true) continue;
                else
                {
                    pane.HasMine = true;
                    i++;
                }
            }
        }

        /// <summary>
        /// 布局所有格子
        /// </summary>
        private void LayoutPanes()
        {
            if(this.Controls.Count==0)
            {
                return;
            }
            int paneLineNum = (int)Math.Sqrt(this.Controls.Count);
            int paneHeight = this.GetPaneSize().Height;
            int paneWidth = this.GetPaneSize().Width;
            int cnt = 0;
            int paneTop = 0;
            int paneLeft = 0;
            for(int i=0;i<paneLineNum;i++)
            {
                paneTop = i * paneHeight;
                for(int j=0;j<paneLineNum;j++)
                {
                    paneLeft = j * paneWidth;
                    Pane pane =this.Controls[cnt] as Pane;
                    pane.Size = new Size(paneWidth, paneHeight);//设置大小
                    pane.Location = new Point(paneLeft, paneTop);//设置位置
                    cnt++;
                }
            }
        }

        private void MineField_SizeChanged(object sender, EventArgs e)
        {
            this.LayoutPanes();
        }

        private void MineSweeppingFailed()
        {
            this.DisplayAll();
            if (this.gameState == 0 && Form1._instance.isExitThread != 0)
            {
                Form1._instance.led2.timer.Close();
                Form1._instance.led2.t.Abort();
                Form1._instance.isExitThread = 0;
            }
            foreach (Pane pane in this.Controls)
            {
                pane.Enabled = false;
            }
            MessageBox.Show("Lose!");
            
        }
        
        private void MineSweeppingSuccessfully()
        {
            foreach (Pane pane in this.Controls)
            {
                pane.Enabled = false;
            }
            MessageBox.Show("You win!");
        }

        private void MineField_Load(object sender, EventArgs e)
        {

        }
    }
    
}
