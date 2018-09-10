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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mGraph = new GraphClass.GraphAdjMatrix<int>(6);
            for(int i = 0;i<6;++i)
            {
                GraphClass.Node<int> temp = new GraphClass.Node<int>(i + 1);
                mGraph.nodes.Add(temp);
            }
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int res = mGraph.SetEdge(int.Parse(numericUpDown1.Text) - 1, int.Parse(numericUpDown2.Text) - 1);
            if(res < 0)
                MessageBox.Show("插入位置非法", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int res = mGraph.DelEdge(int.Parse(numericUpDown3.Text) - 1, int.Parse(numericUpDown4.Text) - 1);
            if (res < 0)
                MessageBox.Show("删除位置非法", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = groupBox3.CreateGraphics();
            Pen p = new Pen(Brushes.Black);
            g.Clear(groupBox3.BackColor);
            for (int i = 0; i < mGraph.nodes.Count(); ++i)
            {
                for(int j = 0;j<mGraph.nodes.Count();++j)
                {
                    if(mGraph.matrix[i][j]>0)
                    {
                        Point p1, p2;
                        switch(i)
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

        public static frmDT objFrmDT = null;
        private void button5_Click(object sender, EventArgs e)
        {
            if(objFrmDT == null)
            {
                objFrmDT = new frmDT();
                objFrmDT.Show();
            }
            else
            {
                objFrmDT.Activate();
                objFrmDT.WindowState = FormWindowState.Normal;
            }
        }

        public static frmBT objFrmBT = null;
        private void button6_Click(object sender, EventArgs e)
        {
            if (objFrmBT == null)
            {
                objFrmBT = new frmBT();
                objFrmBT.Show();
            }
            else
            {
                objFrmBT.Activate();
                objFrmBT.WindowState = FormWindowState.Normal;
            }
        }

        public static frmList objFrmList = null;
        private void button7_Click(object sender, EventArgs e)
        {

            if (objFrmList == null)
            {
                objFrmList = new frmList();
                objFrmList.Show();
            }
            else
            {
                objFrmList.Activate();
                objFrmList.WindowState = FormWindowState.Normal;
            }
        }
    }
}
