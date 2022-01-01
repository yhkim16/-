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
    public partial class Form1 : Form
    {
        public DataTable tbl;
        public Form1()
        {
            InitializeComponent();
            tbl = new DataTable("mem");

            DataColumn name = new DataColumn();
            name.DataType = Type.GetType("System.String");
            name.ColumnName = "M_NAME";
            name.AllowDBNull = false;
            tbl.Columns.Add(name);

            DataColumn age = new DataColumn();
            age.DataType = Type.GetType("System.Int32");
            age.ColumnName = "M_AGE";
            age.AllowDBNull = false;
            tbl.Columns.Add(age);

            DataColumn phone = new DataColumn();
            phone.DataType = Type.GetType("System.String");
            phone.ColumnName = "M_CELLPHONE";
            phone.AllowDBNull = false;
            tbl.Columns.Add(phone);

            DataColumn sex = new DataColumn();
            sex.DataType = Type.GetType("System.String");
            sex.ColumnName = "M_SEX";
            sex.AllowDBNull = false;
            tbl.Columns.Add(sex);

            DataColumn school = new DataColumn();
            school.DataType = Type.GetType("System.String");
            school.ColumnName = "M_HIGHSCHOOL";
            school.AllowDBNull = false;
            tbl.Columns.Add(school);

            dataGridView1.DataSource = tbl;

        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 대화상자ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataView dataView = new DataView(tbl);
            dataView.RowFilter = textBox1.Text;
            dataGridView2.DataSource = dataView;
        }
    }
}
