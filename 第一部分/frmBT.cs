using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph
{
    public partial class frmBT : Form
    {
        public frmBT()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmBT_Load);
            this.FormClosed += new FormClosedEventHandler(frmBT_Closed);
        }

        private void frmBT_Closed(object sender, EventArgs e)
        {
            frmMain.objFrmBT = null;
        }

        private void frmBT_Load(object sender, EventArgs e)
        {
            bGraph = new GraphClass.GraphAdjMatrix<int>(frmMain.mGraph);
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label3.Hide();
            label4.Hide();
        }

        private void Show(int v, int level, bool on)
        {
            Label temp;
            switch (level)
            {
                case 1:
                    temp = label3;
                    break;
                case 2:
                    temp = label4;
                    break;
                case 3:
                    temp = label11;
                    break;
                case 4:
                    temp = label12;
                    break;
                case 5:
                    temp = label13;
                    break;
                case 6:
                    temp = label14;
                    break;
                default:
                    temp = label13;
                    break;
            }

            if (on)
            {
                temp.Text = bGraph.nodes[v].Data.ToString();
                temp.Show();
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                temp.Hide();
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
            }
        }

        private bool[] visited;
        public void BFST()
        {
            visited = new bool[bGraph.nodes.Count()];
            for (int i = 0; i < bGraph.nodes.Count(); ++i)
                visited[i] = false;
            Queue<int> mQueue = new Queue<int>(6);
            int ptr = 0;
            int head = 1;
            int rear = 1;
            mQueue.Enqueue(0);
            Show(ptr, head, true);
            Application.DoEvents();
            System.Threading.Thread.Sleep(1000);
            int Count = 0;
            while (Count != 6)
            {
                if (mQueue.Count() != 0)
                {
                    ptr = mQueue.Dequeue();
                    Show(ptr, head, false);
                    head = head + 1;
                }
                else
                {
                    for (int i = 0; i < 6; ++i)
                    {
                        if (visited[i] != true)
                        {
                            ptr = i;
                            break;
                        }
                    }
                }

                visited[ptr] = true;
                Count = Count + 1;
                textBox1.Text += bGraph.nodes[ptr].Data.ToString() + "--->";

                int next = bGraph.getFirstNeighbor(ptr);
                while (next != -1)
                {
                    if (visited[next] != true)
                    {
                        mQueue.Enqueue(next);
                        Show(next, ++rear, true);
                    }
                    next = bGraph.getNextNeighbor(ptr);
                }

                   

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            BFST();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label3.Hide();
            label4.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = groupBox3.CreateGraphics();
            Pen p = new Pen(Brushes.Black);
            for (int i = 0; i < bGraph.nodes.Count(); ++i)
            {
                for (int j = 0; j < bGraph.nodes.Count(); ++j)
                {
                    if (bGraph.matrix[i][j] > 0)
                    {
                        Point p1, p2;
                        switch (i)
                        {
                            case 0:
                                p1 = new Point(label5.Location.X, label5.Location.Y);
                                break;
                            case 1:
                                p1 = new Point(label6.Location.X, label6.Location.Y);
                                break;
                            case 2:
                                p1 = new Point(label7.Location.X, label7.Location.Y);
                                break;
                            case 3:
                                p1 = new Point(label8.Location.X, label8.Location.Y);
                                break;
                            case 4:
                                p1 = new Point(label9.Location.X, label9.Location.Y);
                                break;
                            case 5:
                                p1 = new Point(label10.Location.X, label10.Location.Y);
                                break;
                            default:
                                p1 = new Point(label5.Location.X, label5.Location.Y);
                                break;
                        }
                        switch (j)
                        {
                            case 0:
                                p2 = new Point(label5.Location.X, label5.Location.Y);
                                break;
                            case 1:
                                p2 = new Point(label6.Location.X, label6.Location.Y);
                                break;
                            case 2:
                                p2 = new Point(label7.Location.X, label7.Location.Y);
                                break;
                            case 3:
                                p2 = new Point(label8.Location.X, label8.Location.Y);
                                break;
                            case 4:
                                p2 = new Point(label9.Location.X, label9.Location.Y);
                                break;
                            case 5:
                                p2 = new Point(label10.Location.X, label10.Location.Y);
                                break;
                            default:
                                p2 = new Point(label5.Location.X, label5.Location.Y);
                                break;
                        }
                        g.DrawLine(p, p1, p2);
                    }
                }
            }
        }
    }
}
