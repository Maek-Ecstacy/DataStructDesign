using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace MetroGraphApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            //打开地铁线路图
            metroGraphView1.OpenFromFile(Application.StartupPath + "\\MetroGraph.xml");
            this.Load += new EventHandler(FrmMain_Load);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroGraphView1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!metroGraphView1.Graph.Nodes.Contains(textBox3.Text))
            {
                MessageBox.Show("没有此起始站点", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!metroGraphView1.Graph.Nodes.Contains(textBox4.Text))
            {
                MessageBox.Show("没有此终点站点", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            metroGraphView1.FindPath(textBox3.Text, textBox4.Text);
            foreach (var link in metroGraphView1.CurPath.Links)
            {
                textBox2.Text += link.From + "---->";
            }
            textBox2.Text += textBox4.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!metroGraphView1.Graph.Nodes.Contains(textBox5.Text))
            {
                MessageBox.Show("没有此前站点", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!metroGraphView1.Graph.Nodes.Contains(textBox6.Text))
            {
                MessageBox.Show("没有此后站点", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (metroGraphView1.Graph.Nodes.Contains(textBox1.Text) && metroGraphView1.Graph.Lines.Contains(numericUpDown1.Text + "号线"))
            {
                MessageBox.Show("已存在该线路中的该站点", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MetroLine nLine;
            if (!metroGraphView1.Graph.Lines.Contains(numericUpDown1.Text + "号线"))
            {
                nLine = new MetroLine();
                nLine.Name = numericUpDown1.Text + "号线";
                nLine.Color = Color.FromArgb(new Random().Next());
                metroGraphView1.Graph.Lines.Add(nLine);
            }
            else
            {
                nLine = metroGraphView1.Graph.Lines[numericUpDown1.Text + "号线"];
            }
            MetroNode temp = new MetroNode();
            temp.Name = textBox1.Text;
            temp.X = (metroGraphView1.Graph.Nodes[textBox5.Text].X + metroGraphView1.Graph.Nodes[textBox6.Text].X) / 2;
            temp.Y = (metroGraphView1.Graph.Nodes[textBox5.Text].Y + metroGraphView1.Graph.Nodes[textBox6.Text].Y) / 2;
            temp.Links.Add(new MetroLink(nLine, metroGraphView1.Graph.Nodes[textBox5.Text], metroGraphView1.Graph.Nodes[textBox6.Text]));
            metroGraphView1.Graph.Nodes[textBox5.Text].Links.Add(new MetroLink(nLine, metroGraphView1.Graph.Nodes[textBox6.Text], temp));
            metroGraphView1.Graph.Nodes.Add(temp);

            String fileName = Application.StartupPath + "\\MetroGraph_new.xml";
            if (string.IsNullOrEmpty(fileName)) return;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<?xml version=\"1.0\" encoding=\"gb2312\"?><MetroGraph/>");

            var graphNode = doc.DocumentElement;
            metroGraphView1.AddAtrribute(graphNode, "ScrollX", metroGraphView1.ScrollX.ToString());
            metroGraphView1.AddAtrribute(graphNode, "ScrollY", metroGraphView1.ScrollY.ToString());
            metroGraphView1.AddAtrribute(graphNode, "ZoomScale", metroGraphView1.ZoomScale.ToString());

            //线路
            var linesNode = metroGraphView1.AddChildNode(graphNode, "Lines");
            foreach (var line in metroGraphView1.Graph.Lines)
            {
                var lineNode = metroGraphView1.AddChildNode(linesNode, "Line");
                metroGraphView1.AddAtrribute(lineNode, "Name", line.Name);
                metroGraphView1.AddAtrribute(lineNode, "Color", line.Color.ToArgb().ToString());
            }

            //站点
            var sitesNode = metroGraphView1.AddChildNode(graphNode, "Nodes");
            foreach (var site in metroGraphView1.Graph.Nodes)
            {
                var siteNode = metroGraphView1.AddChildNode(sitesNode, "Node");
                metroGraphView1.AddAtrribute(siteNode, "Name", site.Name);
                metroGraphView1.AddAtrribute(siteNode, "X", site.X.ToString());
                metroGraphView1.AddAtrribute(siteNode, "Y", site.Y.ToString());

                //路径
                foreach (var link in site.Links)
                {
                    var linkNode = metroGraphView1.AddChildNode(siteNode, "Link");
                    metroGraphView1.AddAtrribute(linkNode, "To", link.To.Name);
                    metroGraphView1.AddAtrribute(linkNode, "Line", link.Line.Name);
                    metroGraphView1.AddAtrribute(linkNode, "Flag", link.Flag.ToString());
                    metroGraphView1.AddAtrribute(linkNode, "Weight", link.Weight.ToString());
                }
            }

            doc.Save(fileName);

            metroGraphView1.OpenFromFile(fileName);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}