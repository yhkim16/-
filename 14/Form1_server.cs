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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 김영휘_과제_14_01
{
    public partial class Form1 : Form
    {
        private Pen pen;
        private Brush whitebrush,blackbrush;
        //none:바둑돌없음,black:흑돌,white:백돌
        enum SITE { none, black, white};
        SITE[,] m_board = new SITE[21, 22];
        bool m_turn; //흑돌:false,백돌:true

        public const int port = 7000;
        TcpListener listener = null;
        Socket client = null;
        public NetworkStream ns;
        StreamWriter strWriter = null;
        StreamReader strReader = null;
        Thread th = null;
        Thread th1 = null;
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black);
            blackbrush = new SolidBrush(Color.Black);
            whitebrush = new SolidBrush(Color.White);
            m_turn = false;//흑돌:false
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < 21; i++)
            {
                g.DrawLine(pen, 10, 34 + i * 20, 410, 34 + i * 20);
                //34:메뉴스트립의높이(24)+10
                g.DrawLine(pen, 10 + i * 20, 34, 10 + i * 20, 434);
                //424:메뉴스트립의높이(24)+400
            }
            for (int x = 0; x < 21; x++)
                for (int y = 0; y < 22; y++)
                    DrawSite(x, y, m_board[x, y]);
        }
        void DrawSite(int x, int y, SITE dol)
        {
            Graphics g = this.CreateGraphics();
            if (dol!=SITE.none)
            {
                if (dol == SITE.black)
                    g.FillEllipse(blackbrush, x * 20 + 2, y * 20 + 2, 16, 16);
                if (dol == SITE.white)
                    g.FillEllipse(whitebrush, x * 20 + 2, y * 20 + 2, 16, 16);

            }
            //Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_turn == true)//흑돌:false
            {
                if (e.Button != MouseButtons.Left)
                    return;

                int ax, ay;
                ax = e.X / 20; ay = e.Y / 20;
                if ((ax < 0) || (ax >= 21) || (ay < 0) || (ay >= 22)) return;
                if (m_board[ax, ay] != SITE.none) return;
                if (client == null) return;


                m_board[ax, ay] = SITE.white;
                try
                {
                    if (client != null)
                    {
                        strWriter.WriteLine(ax);
                        strWriter.WriteLine(ay);
                        strWriter.Flush();
                        Console.WriteLine("{0}, {1} 전송", ax, ay);
                    }
                    
                    
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                DrawSite(ax, ay, m_board[ax, ay]);
                //바둑돌을그린다.
                m_turn = !m_turn;
                //th1.Start();
                

            }
        }

        private void 새게잉ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 21; x++)
                for (int y = 0; y < 22; y++)
                    m_board[x, y] = SITE.none;
            m_turn = false;//흑돌:false
            Invalidate();
            try
            {
                listener.Stop();
                if (client != null)
                {
                    if (client.Connected)
                    {
                        //클라이언트가접속된상태라면
                        client.Close(); // 통신소켓을닫습니다.
                        
                        ns.Close();
                    }
                }
                //서버소켓을닫습니다.
            }
            catch (Exception ex)
            {
                //예외메시지출력
                Console.WriteLine(ex.Message);
            }

        }

        private void 서버시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            th = new Thread(new ThreadStart(SAccept));
            th1 = new Thread(new ThreadStart(Receive));
            th.Start();
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                listener.Stop();
                if (client != null)
                {
                    if (client.Connected)
                    {
                        //클라이언트가접속된상태라면
                        client.Close(); // 통신소켓을닫습니다.
                        if (th.IsAlive) // 서버 시작 스레드가실행중이라면
                            th.Abort();// 스레드종료
                        if (th1.IsAlive)
                            th1.Abort();
                        ns.Close();
                    }
                }
                //서버소켓을닫습니다.
            }
            catch (Exception ex)
            {
                //예외메시지출력
                Console.WriteLine(ex.Message);
            }
            Close();
        }
        public void SAccept()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, port);
            listener = new TcpListener(ipep);
            

            try
            {

                listener.Start();
                client = listener.AcceptSocket();
                if (client.Connected)
                {
                    Console.WriteLine("클라이언트 연결");
                    ns = new NetworkStream(client);
                    strWriter = new StreamWriter(ns);
                    strReader = new StreamReader(ns);
                    th1.Start();
                }

            }
            catch (Exception e)
            {
                if (client != null)
                {
                    if (client.Connected)
                    {
                        //클라이언트가접속된상태라면
                        client.Close(); // 통신소켓을닫습니다.

                        listener.Stop();
                        ns.Close();
                    }
                }
                Console.WriteLine(e.Message);
            }
        }
        public void Receive()
        {
            int ax, ay;
            try
            {
                while (client != null && client.Connected)
                {
                    if (m_turn == false)
                    {
                        ax = Int32.Parse(strReader.ReadLine());
                        ay = Int32.Parse(strReader.ReadLine());
                        Console.WriteLine("{0}, {1} 수신", ax, ay);
                        m_board[ax, ay] = SITE.black;
                        DrawSite(ax, ay, m_board[ax, ay]);
                        m_turn = true;//흑돌:false
                    }
                }
            }
            catch(Exception e)
            {
                if (client != null)
                {
                    if (client.Connected)
                    {
                        //클라이언트가접속된상태라면
                        client.Close(); // 통신소켓을닫습니다.

                        listener.Stop();
                        ns.Close();
                    }
                }
                //서버소켓을닫습니다.
                Console.WriteLine(e.Message);
            }
        }
    }
}
