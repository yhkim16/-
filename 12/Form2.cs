using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 김영휘_과제_12_01
{
    public partial class Form2 : Form
    {
        public Form1 f1;
        public Form2()
        {
            InitializeComponent();
            
        }
        public Form2(Form1 form1)
        {
            InitializeComponent();
            f1 = form1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow dataRow = f1.tbl.NewRow();
            dataRow["M_NAME"] = textBox1.Text;
            dataRow["M_AGE"] = Int32.Parse(textBox2.Text);
            dataRow["M_CELLPHONE"] = textBox3.Text;
            dataRow["M_SEX"] = textBox4.Text;
            dataRow["M_HIGHSCHOOL"] = textBox5.Text;
            f1.tbl.Rows.Add(dataRow);

        }
    }
}
