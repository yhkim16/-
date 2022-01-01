using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 김영휘_과제_10_01
{
    public partial class Form1 : Form
    {
        public ArrayList al = new ArrayList();
        public int index = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ADDR_CARD addr = new ADDR_CARD(textBox1.Text, textBox2.Text, textBox3.Text);
            al.Add(addr);
            index = al.Count + 1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool find = false;
            // 찾을 학생을 어레이리스트에서 검색
            index = 0;
            int i = 0;
            foreach (ADDR_CARD ob2 in al)
            {
                if (ob2.name == textBox1.Text)
                {
                    // 찾은 정보를 텍스트박스에 출력 
                    textBox2.Text = ob2.number;
                    textBox3.Text = ob2.major;
                    find = true;
                    index = i + 1;
                }
                i++;
            }
            if (find == false)
            {
                textBox2.Text = "데이터 없음";
                textBox3.Text = "데이터 없음";
                index = al.Count;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ADDR_CARD a;
            if (index >= al.Count)
            {
                a =  (ADDR_CARD)al[0];
                textBox1.Text = a.name;
                textBox2.Text = a.number;
                textBox3.Text = a.major;
                index = 0;
            }
            else
            {
                a = (ADDR_CARD)al[index];
                textBox1.Text = a.name;
                textBox2.Text = a.number;
                textBox3.Text = a.major;
            }
            index++;
        }

        private void 읽기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            if (DialogResult.Cancel == openFileDialog1.ShowDialog())
            {
                return;
            }
            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            al.Clear();
            al = (ArrayList)bf.Deserialize(fs);
            ADDR_CARD a = (ADDR_CARD)al[0];
            textBox1.Text = a.name;
            textBox2.Text = a.number;
            textBox3.Text = a.major;
            index = 1;
            fs.Close();
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Cancel == saveFileDialog1.ShowDialog())
            {
                return;
            }
            FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, al);
            fs.Close();
        }
    }
}
