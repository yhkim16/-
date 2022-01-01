using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 김영휘_과제_04_01
{
    public partial class Form1 : Form
    {
        ArrayList al;
        public Form1()
        {
            InitializeComponent();
            al = new ArrayList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        //입력버튼의 이벤트처리기
        private void button1_Click(object sender, EventArgs e)
        {
            ADDR_CARD card = new ADDR_CARD(); 
            // 텍스트박스의 내용을 card 객체에 저장 
            card.name = textBox1.Text;
            card.address = textBox2.Text;
            card.phone = textBox3.Text;
            // card를 ArrayList에 추가 
            al.Add(card);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool find = false;
            // 찾을 학생을 어레이리스트에서 검색
            foreach (ADDR_CARD ob2 in al) 
            { 
                if (ob2.name == textBox1.Text) 
                {
                    // 찾은 정보를 텍스트박스에 출력 
                    textBox2.Text = ob2.address;
                    textBox3.Text = ob2.phone;
                        find = true;
                }
            }
            if (find == false)
            {
                textBox2.Text = "데이터 없음";
                textBox3.Text = "데이터 없음";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 처음 버튼의 이벤트처리기  
            ADDR_CARD a = (ADDR_CARD)al[0]; // 첫 번째 학생      
            // 텍스트 박스에 출력
            textBox1.Text = a.name;
            textBox2.Text = a.address;
            textBox3.Text = a.phone;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 크리어 버튼의 이벤트처리기
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

       
    }
}
