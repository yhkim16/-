using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace 김영휘_과제_14_02
{
    public partial class Form2 : Form
    {
        Form1 form;
        TcpClient listener = null;
        Socket server = null;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 f1)
        {
            InitializeComponent();
            form = f1;
            listener = form.listener;

        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                listener = new TcpClient(textBox1.Text.Trim(), Int32.Parse(textBox2.Text));

                server = listener.Client;
                form.server = listener.Client;
                if (server.Connected)
                {
                    Console.WriteLine("서버 연결");
                    form.ns = listener.GetStream();
                    form.strWriter = new StreamWriter(form.ns);
                    form.strReader = new StreamReader(form.ns);
                    form.th.Start();
                    Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
