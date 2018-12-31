using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySaoLei
{
    /// <summary>
    /// 方格类
    /// </summary>
    public partial class Pane : Button
    {
        
        public Pane()
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = Properties.Resources.Image_normal;
        }
        /// <summary>
        /// 有无地雷
        /// </summary>
        public bool HasMine { get; set; }
        /// <summary>
        /// 周围地雷数
        /// </summary>
        public int AroundMineCount { get; set; }
        /// <summary>
        /// 方格状态
        /// </summary>
        public PaneState State { get; set; }
        /// <summary>
        /// 上一次点击的时间
        /// </summary>
        public DateTime lastTime { get; set; }
        public void Open()
        {
            this.State = PaneState.Opened;

            // 根据是否有雷显示不同的内容
            //this.Enabled = false;//表示控件是否可用
            if (this.HasMine)
            {
                this.BackgroundImage = Properties.Resources.MineBomp;
            }
            else
            {
                MineField.openNum--;
                this.lastTime = DateTime.Now;
                switch (this.AroundMineCount)
                {
                    case 0:
                        this.BackgroundImage = null;
                        break;
                    case 1:
                        this.BackgroundImage = Properties.Resources.Num1;
                        break;
                    case 2:
                        this.BackgroundImage = Properties.Resources.Num2;
                        break;
                    case 3:
                        this.BackgroundImage = Properties.Resources.Num3;
                        break;
                    case 4:
                        this.BackgroundImage = Properties.Resources.Num4;
                        break;
                    case 5:
                        this.BackgroundImage = Properties.Resources.Num5;
                        break;
                    case 6:
                        this.BackgroundImage = Properties.Resources.Num6;
                        break;
                    case 7:
                        this.BackgroundImage = Properties.Resources.Num7;
                        break;
                    case 8:
                        this.BackgroundImage = Properties.Resources.Num8;
                        break;
                }
            }
        }
        public void Mark()
        {
            MineField.flagNum--;
            this.BackgroundImage = Properties.Resources.Marked;
            this.State = PaneState.Marked;
        }
        public void Reset()
        {
            MineField.flagNum++;
            this.BackgroundImage = Properties.Resources.Image_normal;
            this.State = PaneState.Closed;
        }

    }

    public enum PaneState
    {
        Closed,
        Opened,
        Marked,
    }
}
