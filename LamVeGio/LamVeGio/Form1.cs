using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LamVeGio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "Nhập số n bất kỳ";
        }

        void calc()
        {
            if (textBox1.Text == String.Empty)
            {
                textBox2.Text = String.Empty; 
                return;
            }

            int number;
            if (!int.TryParse(textBox1.Text, out number))
            {
                MessageBox.Show("Vui lòng nhập số nguyên.");
                textBox1.Text = String.Empty;
                return;
            }

         
            List<int> primeFactors = GetPrimeFactors(number);
            string result = string.Join("*", primeFactors);

            textBox2.Text = result;
        }

        List<int> GetPrimeFactors(int n)
        {
            List<int> primeFactors = new List<int>();

            for (int d = 2; d <= n; d++)
            {
                while (n % d == 0)
                {
                    primeFactors.Add(d);
                    n /= d;
                }
            }

            return primeFactors;

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Equals("")){
                MessageBox.Show("Chưa nhập số");
            }
            calc();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            calc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            textBox2.ResetText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult thongbao = (MessageBox.Show("Bạn muốn thoát khỏi chương trình này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information));
            if (thongbao == DialogResult.Yes)
                Application.Exit();
        }
    }
}
