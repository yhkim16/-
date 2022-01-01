using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 김영휘_과제_13_01
{
    
    public partial class Form1 : Form
    {
        private int drawMode; //그리기모드
        private Point startPoint; //시작점
        private Point nowPoint; //현재점
        private ArrayList saveData; //그림객체정보저장
        private Pen backPen = new Pen(Color.White);
        private Pen myPen = new Pen(Color.Black);
        public Form1()
        {
            InitializeComponent();
            drawMode = 1;
            saveData = new ArrayList();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            ResizeRedraw = true;
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 선ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawMode = 1;
        }

        private void 사각형ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawMode = 2;
        }

        private void 원ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawMode = 3;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            Cursor = Cursors.Cross;
            nowPoint = new Point(e.X, e.Y);
            startPoint = nowPoint;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            
            Graphics graphics = CreateGraphics();

            Rectangle rect;
            /*switch (drawMode)
            {
                case 1://선
                    graphics.DrawLine(backPen, startPoint, nowPoint);
                    break;
                case 2://사각형
                    rect = new Rectangle(startPoint.X, startPoint.Y, nowPoint.X - startPoint.X, nowPoint.Y - startPoint.Y);
                    graphics.DrawRectangle(backPen, rect);
                    break;
                case 3://원
                    rect = new Rectangle(startPoint.X, startPoint.Y, nowPoint.X - startPoint.X, nowPoint.Y - startPoint.Y);
                    graphics.DrawEllipse(backPen, rect);
                    break;
                default:
                    break;
            }*/
            
            nowPoint = new Point(e.X, e.Y);
            switch (drawMode)
            {
                case 1://선
                    graphics.DrawLine(myPen, startPoint, nowPoint);
                    break;
                case 2://사각형
                    rect = new Rectangle(startPoint.X, startPoint.Y, nowPoint.X - startPoint.X, nowPoint.Y - startPoint.Y);
                    graphics.DrawRectangle(myPen, rect);
                    break;
                case 3://원
                    rect = new Rectangle(startPoint.X, startPoint.Y, nowPoint.X - startPoint.X, nowPoint.Y - startPoint.Y);
                    graphics.DrawEllipse(myPen, rect);
                    break;
                default:
                    break;
            }
            Invalidate();

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            
            saveData.Add(new Data(startPoint, nowPoint, drawMode));
            Cursor = Cursors.Arrow;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            foreach (Data d in saveData)
            {
                d.drawData(g);
            }
        }

        private void 읽기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            saveData.Clear();
            saveData = (ArrayList)bf.Deserialize(fs);
            fs.Close();
            Invalidate();
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();

            FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, saveData);
            fs.Close();
        }
    }
    [Serializable]
    class Data
    {
        public Point startPoint;
        public Point endPoint;
        public int drawMode;
        
        //생성자
        public Data(Point x, Point y, int dMode)
        {
            startPoint = x;
            endPoint = y;
            drawMode = dMode;
        }
        //도형 그리기 메서드
        public void drawData(Graphics g)
        {
            Rectangle rect;
            switch (drawMode)
            {
                case 1://선
                    g.DrawLine(new Pen(Color.Black), startPoint, endPoint);
                    break;
                case 2://사각형
                    rect = new Rectangle(startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
                    g.DrawRectangle(new Pen(Color.Black), rect);
                    break;
                case 3://원
                    rect = new Rectangle(startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
                    g.DrawEllipse(new Pen(Color.Black), rect);
                    break;
                default:
                    break;
            }
        }
    }
}
