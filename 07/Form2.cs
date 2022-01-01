using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 김영휘_과제_07_01
{
    public partial class Form2 : Form
    {
        private Form1 f1;
        public Form2(Form1 f)
        {

            InitializeComponent();
            f1 = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem item1 = new ListViewItem(textBox1.Text, Int32.Parse(textBox4.Text));
            item1.SubItems.Add(textBox2.Text);
            item1.SubItems.Add(textBox3.Text);
            f1.listView1.Items.Add(item1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
