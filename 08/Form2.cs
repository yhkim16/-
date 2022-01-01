using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 김영휘_과제_08_01
{
    public partial class Form2 : Form
    {
        private Form1 f1;
        private int index = -1;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 form1)
        {
            InitializeComponent();
            f1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = textBox1.Text;
            string str2 = textBox2.Text;
            string str3 = f1.textBox1.Text;
            if (index == -1)
            {
                index = f1.textBox1.Text.IndexOf(str1);
                if (index == -1)
                {
                    MessageBox.Show("찾을 단어가 없습니다.");
                }
                else
                {
                    int len = textBox1.TextLength;
                    f1.textBox1.Focus();
                    f1.textBox1.Select(index, len);
                }
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();
                int len = str1.Length;
                stringBuilder.Append(str3);
                stringBuilder.Remove(index, len);
                stringBuilder.Insert(index, str2);
                f1.textBox1.Text = stringBuilder.ToString();
                index = f1.textBox1.Text.IndexOf(textBox1.Text, index);
                if (index == -1)
                {
                    MessageBox.Show("문서의 끝까지 바꾸기를 수행했습니다.");
                }
                else
                {
                    int len1 = textBox1.TextLength;
                    f1.textBox1.Focus();
                    f1.textBox1.Select(index, len1);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str1 = textBox1.Text;
            string str3 = f1.textBox1.Text;
            if (index == -1)
            {
                index = f1.textBox1.Text.IndexOf(str1);
                if (index == -1)
                {
                    MessageBox.Show("찾을 단어가 없습니다.");
                }
                else
                {
                    int len = textBox1.TextLength;
                    f1.textBox1.Focus();
                    f1.textBox1.Select(index, len);
                }
            }
            else
            {
                index = f1.textBox1.Text.IndexOf(str1, index + 1, f1.textBox1.Text.Length - index - 1);
                if (index == -1)
                {
                    MessageBox.Show("문서의 끝까지 찾기를 수행했습니다.");
                }
                else
                {
                    int len1 = textBox1.TextLength;
                    f1.textBox1.Focus();
                    f1.textBox1.Select(index, len1);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string str1 = textBox1.Text;
                string str2 = textBox2.Text;
                string str3 = f1.textBox1.Text;
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(str3);
                stringBuilder.Replace(str1, str2);
                str3 = stringBuilder.ToString();
                f1.textBox1.Text = str3;
            }
            else
            {
                MessageBox.Show("단어를 입력하세요.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
