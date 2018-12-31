using System.Threading;

namespace MySaoLei
{
    partial class LED
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.number1 = new MySaoLei.Number();
            this.number2 = new MySaoLei.Number();
            this.number3 = new MySaoLei.Number();
            this.SuspendLayout();
            // 
            // number1
            // 
            this.number1.Location = new System.Drawing.Point(59, 3);
            this.number1.Name = "number1";
            this.number1.Size = new System.Drawing.Size(22, 40);
            this.number1.TabIndex = 0;
            this.number1.Load += new System.EventHandler(this.number1_Load);
            // 
            // number2
            // 
            this.number2.Location = new System.Drawing.Point(31, 3);
            this.number2.Name = "number2";
            this.number2.Size = new System.Drawing.Size(22, 40);
            this.number2.TabIndex = 1;
            this.number2.Load += new System.EventHandler(this.number2_Load);
            // 
            // number3
            // 
            this.number3.Location = new System.Drawing.Point(3, 3);
            this.number3.Name = "number3";
            this.number3.Size = new System.Drawing.Size(22, 40);
            this.number3.TabIndex = 2;
            this.number3.Load += new System.EventHandler(this.number3_Load);
            // 
            // LED
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.number3);
            this.Controls.Add(this.number2);
            this.Controls.Add(this.number1);
            this.Name = "LED";
            this.Size = new System.Drawing.Size(85, 48);
            this.ResumeLayout(false);

        }

        #endregion

        private Number number1;
        private Number number2;
        private Number number3;

        public Thread t;
        int count;
        public System.Timers.Timer timer;

        public void test()
        {
            for (int i = 0; i < 10; i++)
            {
                Set(i);
                Thread.Sleep(500);
                Reset();
            }
        }
        public void Set(object data)
        {
            var integer = (int)data;
            if (integer > 999)
            {
                return;
            }
            if (integer > 99)
            {
                var digit1 = integer % 10;
                var digit2 = integer / 10 % 10;
                var digit3 = integer / 100;
                number1.Set(digit1);
                number2.Set(digit2);
                number3.Set(digit3);
                return;
            }
            if (integer > 9)
            {
                var digit1 = integer % 10;
                var digit2 = integer / 10;
                number1.Set(digit1);
                number2.Set(digit2);
                number3.Set(0);
                return;
            }
            if (integer >= 0)
            {
                var digit = integer;
                number1.Set(digit);
                number2.Set(0);
                number3.Set(0);
                return;
            }
            return;
        }
        public void Reset()
        {
            number1.Reset();
            number2.Reset();
            number3.Reset();
        }

        public void Timekeeping()
        {
            count = 0;
            Set(count);
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Handler);
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        public void Handler(object source, System.Timers.ElapsedEventArgs e)
        {
            Reset();
            count++;
            Set(count);
        }
    }
}
