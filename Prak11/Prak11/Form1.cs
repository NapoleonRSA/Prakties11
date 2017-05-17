using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prak11
{
    public partial class Form1 : Form
    {
        public List<int> nommerList = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileNaam = "";
            string newStringIn = "";
            int lineCount = 0;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               fileNaam =  openFileDialog1.FileName;
                using (StreamReader readLine = new StreamReader(fileNaam))
                {
                    //newStringIn = readLine.ReadLine().Replace("*", "").Replace("=","").Replace(" ","");
                    //newStringIn = newStringIn.Substring(0, 2);
                    int line;
                    while ((line = Convert.ToInt32(readLine.ReadLine())) != 0)
                    {
                        nommerList.Add(line);
                    }
                    
                }
            }
            
            txtDisplay.Text = string.Join("\r\n", nommerList);
        }

        private void tbpX2_Click(object sender, EventArgs e)
        {
            foreach (int nommer in nommerList)
            {
                txtX2.AppendText(nommer +" * 2 = "+ nommer*2 +"\r\n" );
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            foreach (int nommer in nommerList)
            {
                textBox1.AppendText(nommer + " * 3 = " + nommer * 3 + "\r\n");
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            foreach (int nommer in nommerList)
            {
                textBox2.AppendText(nommer + " * 10 = " + nommer * 10 + "\r\n");
            }
        }

        private void countAndLargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "Number of values in file : " + nommerList.Count().ToString() + " Largest Value " + nommerList.Max();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileSkryf = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileSkryf = saveFileDialog1.FileName;
            }
            StreamWriter skryf = new StreamWriter(fileSkryf);

            if (tabControl1.SelectedTab == Display)
            {
                using (skryf)
                {
                    skryf.Write(txtDisplay.Text);
                }
            }

            if (tabControl1.SelectedTab == tbpX2)
            {
                using (skryf)
                {
                    skryf.Write(txtX2.Text);
                }
            }

            if (tabControl1.SelectedTab == tabPage1)
            {
                using (skryf)
                {
                    skryf.Write(textBox1.Text);
                }
            }
            if (tabControl1.SelectedTab == tabPage2)
            {
                using (skryf)
                {
                    skryf.Write(textBox2.Text);
                }
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
            txtX2.Clear();
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
