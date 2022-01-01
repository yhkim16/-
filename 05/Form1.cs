using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 김영휘_과제_05_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem item1 = new ListViewItem(textBox1.Text, int.Parse(textBox5.Text));
            item1.SubItems.Add(textBox2.Text);
            item1.SubItems.Add(textBox3.Text);
            item1.SubItems.Add(textBox4.Text);
            listView1.Items.Add(item1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = listView1.SelectedIndices[0];
            for (int j = 0; j <= listView1.SelectedItems.Count; j++)
            {
                listView1.Items.RemoveAt(i);
            }
               
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Sorting = SortOrder.Ascending;
            listView1.Sorting = SortOrder.None;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = listView1.SelectedIndices[0];
            listView1.Items.RemoveAt(i);
            ListViewItem item1 = new ListViewItem(textBox1.Text, int.Parse(textBox5.Text));
            item1.SubItems.Add(textBox2.Text);
            item1.SubItems.Add(textBox3.Text);
            item1.SubItems.Add(textBox4.Text);
            listView1.Items.Insert(i, item1);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }
    }
}
