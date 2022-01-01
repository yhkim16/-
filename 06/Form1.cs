using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 김영휘_과제_06_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void 입력ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item1 = new ListViewItem(textBox1.Text, comboBox2.SelectedIndex);
            item1.SubItems.Add(comboBox1.Text);
            item1.SubItems.Add(textBox3.Text);
            item1.SubItems.Add(textBox4.Text);
            listView1.Items.Add(item1);
        }

        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = listView1.SelectedIndices[0];
            for (int j = 0; j <= listView1.SelectedItems.Count; j++)
            {
                listView1.Items.RemoveAt(i);
            }
        }

        private void 정렬ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Sorting = SortOrder.Ascending;
            listView1.Sorting = SortOrder.None;
        }

        private void 큰아이콘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void 아이콘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void 간단히ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void 자세히ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }
    }
}
