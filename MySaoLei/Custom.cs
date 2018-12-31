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
    public partial class Custom : Form
    {
        public Custom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text1 = textBox1.Text;
            var text2 = textBox2.Text;
            int row, col, bomb;
            bool isInt1 = int.TryParse(text1, out row);
            bool isInt2 = int.TryParse(text2, out col);
            if (!isInt1)
            {
                MessageBox.Show("行数输入错误。");
                return;
            }
            if (!isInt2)
            {
                MessageBox.Show("列数输入错误。");
                return;
            }
            if (row < 10 || row > 20)
            {
                MessageBox.Show("行数不在规定范围内。");
                return;
            }
            if (col < 10 || col > 50)
            {
                MessageBox.Show("地雷数不在规定范围内。");
                return;
            }
            Form1._instance.row = row;
            Form1._instance.bomb = col;
            Form1._instance.set_border(row, col);
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
