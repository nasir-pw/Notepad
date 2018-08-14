using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        
     
      
        public Form1()
        {
            
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files (*.*)|*.*|Text Documents(*.txt)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.ShowDialog();
            System.IO.StreamReader OpenFile = new System.IO.StreamReader(openFileDialog1.FileName);
            mainTextBox.Text = OpenFile.ReadToEnd();
            OpenFile.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = "";
            if (fileName == "")
            {
                saveFileDialog1.Filter = "TEXT Documents. (*.txt)|*.txt|All files|*.*";
                DialogResult resVal = saveFileDialog1.ShowDialog();
                if (resVal == DialogResult.Cancel)
                {
                    return;
                }
                fileName = saveFileDialog1.FileName;
            }
            try
            {
                StreamWriter stWriter = new StreamWriter(fileName);
                stWriter.WriteLine(mainTextBox.Text);
                stWriter.Close();
            }
            catch
            {
                MessageBox.Show(this, "The file " + fileName + " is Read only. \n\n File Could not saved.", "Notepad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(saveFileDialog1.FileName);
            SaveFile.WriteLine(mainTextBox.Text);
            SaveFile.Close();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDocument1.DocumentName = mainTextBox.Text;
            printDialog1.Document = printDocument1;
            printDialog1.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.Copy();
        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.Paste();
        }

       

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDocument1.DocumentName = mainTextBox.Text;
            pageSetupDialog1.Document = printDocument1;
            pageSetupDialog1.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.Select();
            mainTextBox.Text = "";
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findForm f1 = new findForm();
            f1.ShowDialog();
          
            
        }
        public void find()
        {

            MessageBox.Show("M Call");
        } 

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainTextBox.Text += Convert.ToString(DateTime.Now);  
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            fontDialog1.ShowDialog();
            mainTextBox.Font = fontDialog1.Font;
            mainTextBox.ForeColor = fontDialog1.Color;
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked = !wordWrapToolStripMenuItem.Checked)
            {
                this.mainTextBox.WordWrap = true;
            }
            else
            {
                this.mainTextBox.WordWrap = false;
            }
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked = !statusBarToolStripMenuItem.Checked)
            {
                this.statusBar.Visible = true;
                
                this.statusBar.Text = DateTime.Now.ToString();
            }

            else
            {
                this.statusBar.Visible = false;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.mainTextBox.WordWrap = false;
            this.statusBar.Visible = false;
        }













        public string text { get; set; }
    }
}
