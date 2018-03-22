using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace TextEditor
{
    public partial class MainWindow : Form
    {
        private bool textChanged;
        private string fileName;

        public MainWindow()
        {
            InitializeComponent();
            this.textChanged = false;
        }

        private void TextHasChanged(object sender, EventArgs e)
        {
            this.textChanged = true;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult askIfSave = DialogResult.None;

            if (this.textChanged == true)
            {
                askIfSave = MessageBox.Show("Do you want to save the changes?", "TextEditor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }

            if (askIfSave == DialogResult.Yes)
            {
                try
                {
                    StreamWriter writer = new StreamWriter(fileName);
                    writer.Write(this.richTextBox1.Text);
                    writer.Close();

                    this.textChanged = false;
                }
                catch
                {
                    MessageBox.Show("An error occured! The changes couldn't be saved!", "TextEditor", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader reader = new StreamReader(this.openFileDialog1.FileName);
                    this.richTextBox1.Text = reader.ReadToEnd();
                    reader.Close();

                    this.fileName = openFileDialog1.FileName;
                    this.textChanged = false;
                }
                catch
                {
                    MessageBox.Show("An error occured! The file couldn't be opened!", "TextEditor", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.printDialog1.AllowSomePages = true;
            this.printDialog1.ShowHelp = true;
            this.printDialog1.Document = new System.Drawing.Printing.PrintDocument();
        }
    }
}
