using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 김영휘16037010_과제01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("버튼 클릭", "메시지", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
