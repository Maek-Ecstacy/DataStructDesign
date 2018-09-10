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
    public partial class frmDT : Form
    {
        public frmDT()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmDT_Load);
            this.Shown += new EventHandler(frmDT_Shown);
            this.FormClosed += new FormClosedEventHandler(frmDT_Closed);
        }

        private void frmDT_Closed(object sender, EventArgs e)
        {
            frmMain.objFrmDT = null;
        }

        private void frmDT_Load(object sender, EventArgs e)
        {
            dGraph = new GraphClass.GraphAdjMatrix<int>(frmMain.mGraph);
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label3.Hide();
            label4.Hide();
        }

 
        private void frmDT_Shown(object sender, EventArgs e)
        {
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void DFS(int v,int level)
        {
            int next;
            /*
            if (COUNT == 0)
            {
                COUNT++;
            }

            */
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

            temp.Text = dGraph.nodes[v].Data.ToString();
            temp.Show();
            Application.DoEvents();

            textBox1.Text += dGraph.nodes[v].Data.ToString() + "--->";
            /*
            temp2 = new Label();
            temp2.Location = temp1.Location;
            temp2.Size = temp1.Size;
            temp2.Font = temp1.Font;
            temp2.BackColor = temp1.BackColor;
            temp2.Text = dGraph.nodes[v].Data.ToString();
            this.Controls.Add(temp2);
            */
            visited[v] = true;
            System.Threading.Thread.Sleep(1000);
            
            next = dGraph.getFirstNeighbor(v);
            while (true)
            {
                if (next == -1)
                    break;
                else if(visited[next] ==false)
                    DFS(next, level + 1);
                next = dGraph.getNextNeighbor(v);
            }
            temp.Hide();
        }


 //       private int COUNT;
        private bool[] visited;
        public void DFSTraverse()
        {
            visited = new bool[dGraph.nodes.Count()];
            for (int i = 0; i < dGraph.nodes.Count(); ++i)
                visited[i] = false;
            for (int i = 0; i < dGraph.nodes.Count(); ++i)
            {
                if (visited[i] != true)
                {
  //                  COUNT = 0;
                    DFS(i, 1);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //            dGraph = new GraphClass.GraphAdjMatrix<int>(frmMain.mGraph)
            //           frmMain.mGraph.DFSTraverse
            //       label3.Show();
            //        label3.Text = dGraph.nodes[0].data.ToString();
            //      labelShow(label3, "fuck");
            //        System.Threading.Thread.Sleep(10000);
            textBox1.Text = "";
            DFSTraverse();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label3.Hide();
            label4.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = groupBox3.CreateGraphics();
            Pen p = new Pen(Brushes.Black);
            for (int i = 0; i < dGraph.nodes.Count(); ++i)
            {
                for (int j = 0; j < dGraph.nodes.Count(); ++j)
                {
                    if (dGraph.matrix[i][j] > 0)
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
                temp.Text = dGraph.nodes[v].Data.ToString();
                temp.Show();
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
            }
            else
                temp.Hide();

        }
        
        public void DFST_nonRecur()
        {
            visited = new bool[dGraph.nodes.Count()];
            for (int i = 0; i < dGraph.nodes.Count(); ++i)
                visited[i] = false;
            Stack<int> mStack = new Stack<int>(6);
            int ptr = 0;
            int level = 1;
            int Count = 0;
            while (Count != 6)
            {
                Show(ptr, level, true);
                level = level + 1;
                visited[ptr] = true;
                Count = Count + 1;
                textBox1.Text += dGraph.nodes[ptr].Data.ToString() + "--->";
                int next = dGraph.getFirstNeighbor(ptr);
                while (next != -1 && visited[next] == true)
                    next = dGraph.getNextNeighbor(ptr);

                if (next == -1)
                {
                    if (mStack.Count() != 0)
                        ptr = mStack.Pop();
                    else
                    {
                        for (int i = 0; i < 6; ++i)
                        {
                            if (visited[i] != true)
                                ptr = i;
                        }
                    }
                    Show(ptr, level, false);
                    level = level - 1;
                    continue;
                }
                int res = dGraph.getNextNeighbor(ptr);
                while (res != -1 && visited[res] != true)
                {
                    mStack.Push(res);
                    res = dGraph.getNextNeighbor(ptr);
                }
                ptr = next;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            DFST_nonRecur();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label3.Hide();
            label4.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
