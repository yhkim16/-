using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 김영휘_과제_09_01
{
    public partial class Form1 : Form
    {
        public DirectoryInfo dinfo;
        public DirectoryInfo[] dir;
        public int dir_count;
        public string cpStirng;
        public Form1()
        {
            InitializeComponent();
            dir_count = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            FileInfo fileInfo = new FileInfo(openFileDialog1.FileName);
            dinfo = fileInfo.Directory; //current Directory
            dir = dinfo.GetDirectories(); //subDirectories
            dir_count = dir.Length + 1;

            listView1.Items.Clear();
            ListViewItem listViewItem = new ListViewItem("...", 0);
            listViewItem.SubItems.Add("");
            listViewItem.SubItems.Add("");
            listViewItem.SubItems.Add("");
            listView1.Items.Add(listViewItem); //Add ParentDirectory

            foreach (DirectoryInfo d in dir)//Add SubDirectories to ListView
            {
                ListViewItem item = new ListViewItem(d.Name.ToString(), 0);
                item.SubItems.Add(d.Attributes.ToString());//Attribute
                item.SubItems.Add("");//Size
                item.SubItems.Add(d.CreationTime.ToString());//CreationTime
                listView1.Items.Add(item);
            }

            FileInfo[] files = dinfo.GetFiles();
            foreach (FileInfo f in files)//Add Files to ListView
            {
                ListViewItem item = new ListViewItem(f.Name.ToString(), 1);
                item.SubItems.Add(f.Attributes.ToString());//Attribute
                item.SubItems.Add(f.Length.ToString());//Size
                item.SubItems.Add(f.CreationTime.ToString());//CreationTime
                listView1.Items.Add(item);
            }
            Text = dinfo.FullName.ToString();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            int index = listView1.FocusedItem.Index; //SelectedIndex
            if (index >= dir_count)
            {
                MessageBox.Show("파일을 선택했습니다.");
                return;
            }
            if (index != 0)
            {
                dinfo = dir[index - 1];
            }
            else
            {
                if (dinfo.Parent == null)
                {
                    MessageBox.Show("루트 디렉토리입니다.");
                        return;
                }
                dinfo = dinfo.Parent;
            }

            listView1.Items.Clear();
            ListViewItem listViewItem = new ListViewItem("...", 0);
            listViewItem.SubItems.Add("");
            listViewItem.SubItems.Add("");
            listViewItem.SubItems.Add("");
            listView1.Items.Add(listViewItem); //Add ParentDirectory

            dir = dinfo.GetDirectories();
            dir_count = dir.Length + 1;

            foreach (DirectoryInfo d in dir)//Add SubDirectories to ListView
            {
                ListViewItem item = new ListViewItem(d.Name.ToString(), 0);
                item.SubItems.Add(d.Attributes.ToString());//Attribute
                item.SubItems.Add("");//Size
                item.SubItems.Add(d.CreationTime.ToString());//CreationTime
                listView1.Items.Add(item);
            }

            FileInfo[] files = dinfo.GetFiles();
            foreach (FileInfo f in files)//Add Files to ListView
            {
                ListViewItem item = new ListViewItem(f.Name.ToString(), 1);
                item.SubItems.Add(f.Attributes.ToString());//Attribute
                item.SubItems.Add(f.Length.ToString());//Size
                item.SubItems.Add(f.CreationTime.ToString());//CreationTime
                listView1.Items.Add(item);
            }
            Text = dinfo.FullName.ToString();
        }

        private void 복사ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listView1.FocusedItem.Index; //SelectedIndex
            if (index >= dir_count)
            {
                cpStirng = this.Text + "\\" + listView1.FocusedItem.Text;
                return;
            }
            else
            {
                MessageBox.Show("파일만 복사할 수 있습니다");
            }
        }

        private void 붙여넣기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo(cpStirng);
            fileInfo.CopyTo(this.Text + "\\" + fileInfo.Name);

            listView1.Items.Clear();
            ListViewItem listViewItem = new ListViewItem("...", 0);
            listViewItem.SubItems.Add("");
            listViewItem.SubItems.Add("");
            listViewItem.SubItems.Add("");
            listView1.Items.Add(listViewItem); //Add ParentDirectory

            dir = dinfo.GetDirectories();
            dir_count = dir.Length + 1;

            foreach (DirectoryInfo d in dir)//Add SubDirectories to ListView
            {
                ListViewItem item = new ListViewItem(d.Name.ToString(), 0);
                item.SubItems.Add(d.Attributes.ToString());//Attribute
                item.SubItems.Add("");//Size
                item.SubItems.Add(d.CreationTime.ToString());//CreationTime
                listView1.Items.Add(item);
            }

            FileInfo[] files = dinfo.GetFiles();
            foreach (FileInfo f in files)//Add Files to ListView
            {
                ListViewItem item = new ListViewItem(f.Name.ToString(), 1);
                item.SubItems.Add(f.Attributes.ToString());//Attribute
                item.SubItems.Add(f.Length.ToString());//Size
                item.SubItems.Add(f.CreationTime.ToString());//CreationTime
                listView1.Items.Add(item);
            }
            Text = dinfo.FullName.ToString();

        }

        private void 지우기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                File.Delete(this.Text + "\\" + listView1.FocusedItem.Text);

                listView1.Items.Clear();
                ListViewItem listViewItem = new ListViewItem("...", 0);
                listViewItem.SubItems.Add("");
                listViewItem.SubItems.Add("");
                listViewItem.SubItems.Add("");
                listView1.Items.Add(listViewItem); //Add ParentDirectory

                dir = dinfo.GetDirectories();
                dir_count = dir.Length + 1;

                foreach (DirectoryInfo d in dir)//Add SubDirectories to ListView
                {
                    ListViewItem item = new ListViewItem(d.Name.ToString(), 0);
                    item.SubItems.Add(d.Attributes.ToString());//Attribute
                    item.SubItems.Add("");//Size
                    item.SubItems.Add(d.CreationTime.ToString());//CreationTime
                    listView1.Items.Add(item);
                }

                FileInfo[] files = dinfo.GetFiles();
                foreach (FileInfo f in files)//Add Files to ListView
                {
                    ListViewItem item = new ListViewItem(f.Name.ToString(), 1);
                    item.SubItems.Add(f.Attributes.ToString());//Attribute
                    item.SubItems.Add(f.Length.ToString());//Size
                    item.SubItems.Add(f.CreationTime.ToString());//CreationTime
                    listView1.Items.Add(item);
                }
            }            
        }
    }
}
