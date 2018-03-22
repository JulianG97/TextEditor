using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
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
            this.fileName = "Untitled";
            this.Text = "TextEditor" + " - " + this.fileName;
        }

        private void TextHasChanged(object sender, EventArgs e)
        {
            this.textChanged = true;
        }

        private string GetFileName(string path)
        {
            string[] pathArray = path.Split('\\');
            return pathArray[pathArray.Length - 1];
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
                SaveFile(false);
            }

            if (askIfSave != DialogResult.Cancel)
            {
                if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StreamReader reader = new StreamReader(this.openFileDialog1.FileName);
                        this.richTextBox1.Text = reader.ReadToEnd();
                        reader.Close();

                        this.fileName = openFileDialog1.FileName;
                        this.textChanged = false;
                        this.Text = "TextEditor" + " - " + GetFileName(this.fileName);
                        this.openFileDialog1.FileName = string.Empty;
                    }
                    catch
                    {
                        MessageBox.Show("An error occured! The file couldn't be opened!", "TextEditor", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult askIfSave = DialogResult.None;

            if (this.textChanged == true)
            {
                askIfSave = MessageBox.Show("Do you want to save the changes?", "TextEditor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }

            if (askIfSave == DialogResult.Yes)
            {
                SaveFile(false);
            }

            if (askIfSave != DialogResult.Cancel)
            {
                this.fileName = "Untitled";
                this.Text = "TextEditor" + " - " + this.fileName;
                this.richTextBox1.Text = string.Empty;
                this.textChanged = false;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(false);
        }

        private void SaveFile(bool saveAs)
        {
            DialogResult askIfSave = DialogResult.None;

            if (this.fileName == "Untitled" || saveAs == true)
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.fileName = this.saveFileDialog1.FileName;
                    this.Text = "TextEditor" + " - " + GetFileName(this.fileName);
                }
                else
                {
                    askIfSave = DialogResult.Cancel;
                }
            }

            if (askIfSave != DialogResult.Cancel)
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

            this.saveFileDialog1.FileName = string.Empty;
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(true);
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show();
        }

        private void MainWindow_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult askIfSave = DialogResult.None;

            if (this.textChanged == true)
            {
                askIfSave = MessageBox.Show("Do you want to save the changes?", "TextEditor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }

            if (askIfSave == DialogResult.Yes)
            {
                SaveFile(false);
            }
            else if (askIfSave == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
