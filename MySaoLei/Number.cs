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
    public partial class Number : UserControl
    {
        public Number()
        {
            InitializeComponent();
            pictureBoxes[0] = pictureBox1;
            pictureBoxes[1] = pictureBox2;
            pictureBoxes[2] = pictureBox3;
            pictureBoxes[3] = pictureBox4;
            pictureBoxes[4] = pictureBox5;
            pictureBoxes[5] = pictureBox6;
            pictureBoxes[6] = pictureBox7;
        }

        int[,] num = new int[10, 7] {
            { 1, 0, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 1, 0, 1 },
            { 1, 1, 1, 0, 1, 1, 0 },
            { 1, 1, 1, 0, 1, 0, 1 },
            { 0, 1, 0, 1, 1, 0, 1 },
            { 1, 1, 1, 1, 0, 0, 1 },
            { 1, 1, 1, 1, 0, 1, 1 },
            { 1, 0, 0, 0, 1, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 0, 1 }
        };
        PictureBox[] pictureBoxes = new PictureBox[7];

        private void NixieTube_Load(object sender, EventArgs e)
        {

        }

        public void test()
        {
            for (int i = 0; i < 10; i++)
            {
                Set(i);
                Thread.Sleep(1000);
                Reset();
            }
        }

        public void Set(object data)
        {
            int digit = (int)data;
            //Reset();
            //MessageBox.Show(digit.ToString());
            for (int i = 0; i < 7; i++)
            {
                if (num[digit, i] == 1)
                {
                    switch (i)
                    {
                        case 0:
                            this.pictureBoxes[i].Image = global::MySaoLei.Properties.Resources.horizon_light;
                            //pictureBoxes[i].BackgroundImage = Properties.Resources.horizon_light;
                            break;
                        case 1:
                            this.pictureBoxes[i].Image = global::MySaoLei.Properties.Resources.horizon_light;
                            //pictureBoxes[i].BackgroundImage = Properties.Resources.horizon_light;
                            break;
                        case 2:
                            this.pictureBoxes[i].Image = global::MySaoLei.Properties.Resources.horizon_light;
                            //pictureBoxes[i].BackgroundImage = Properties.Resources.horizon_light;
                            break;
                        case 3:
                            this.pictureBoxes[i].Image = global::MySaoLei.Properties.Resources.vertical_light;
                            //pictureBoxes[i].BackgroundImage = Properties.Resources.vertical_light;
                            break;
                        case 4:
                            this.pictureBoxes[i].Image = global::MySaoLei.Properties.Resources.vertical_light;
                            //pictureBoxes[i].BackgroundImage = Properties.Resources.vertical_light;
                            break;
                        case 5:
                            this.pictureBoxes[i].Image = global::MySaoLei.Properties.Resources.vertical_light;
                            //pictureBoxes[i].BackgroundImage = Properties.Resources.vertical_light;
                            break;
                        case 6:
                            this.pictureBoxes[i].Image = global::MySaoLei.Properties.Resources.vertical_light;
                            //pictureBoxes[i].BackgroundImage = Properties.Resources.vertical_light;
                            break;
                    }
                }
            }
        }
        public void Reset()
        {
            for (int i = 0; i < 3; i++)
            {
                pictureBoxes[i].Image = Properties.Resources.horizon_dark;
            }
            for (int i = 3; i < 7; i++)
            {
                pictureBoxes[i].Image = Properties.Resources.vertical_dark;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
