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
    public partial class frmList : Form
    {
        public frmList()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(frmList_Closed);
        }

        private void frmList_Closed(object sender, EventArgs e)
        {
            frmMain.objFrmList = null;
        }

        private void frmList_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GraphClass.GraphAdjList<int> gList = new GraphClass.GraphAdjList<int>(frmMain.mGraph);
            foreach(GraphClass.VexNode<int> adj in gList.adjList)
            {
                textBox1.Text += adj.data.data.ToString();
                for(GraphClass.adjListNode<int> i = adj.FirstAdj; i!= null;i = i.Next)
                {
                    textBox1.Text += "--->" + gList.adjList[i.Adjvex].data.data.ToString();
                }
                textBox1.Text += "\r\n";
            }
        }
    }
}
