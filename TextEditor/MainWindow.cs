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
using System.Windows.Input;
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

            this.KeyPreview = true;
            this.textChanged = false;
            this.fileName = "Untitled";
            this.Text = "TextEditor" + " - " + this.fileName;
        }

        private void MainWindow_KeyDown(object sender, System.Windows.Forms.KeyEventArgs k)
        {
            if (k.Control)
            {
                if (k.KeyCode == Keys.N)
                {
                    this.NewToolStripMenuItem_Click(this, new EventArgs());
                }
                else if (k.KeyCode == Keys.O)
                {
                    this.OpenToolStripMenuItem_Click(this, new EventArgs());
                }
                else if (k.KeyCode == Keys.S)
                {
                    this.SaveToolStripMenuItem_Click(this, new EventArgs());
                }
                else if (k.Shift && k.KeyCode == Keys.S)
                {
                    this.SaveAsToolStripMenuItem_Click(this, new EventArgs());
                }
                else if (k.KeyCode == Keys.F)
                {
                    this.FontSettingsToolStripMenuItem_Click(this, new EventArgs());
                }
                else if (k.KeyCode == Keys.H)
                {
                    this.HelpToolStripMenuItem_Click(this, new EventArgs());
                }
                else if (k.KeyCode == Keys.X)
                {
                    this.Close();
                }
            }
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
                        this.fileName = openFileDialog1.FileName;

                        if (CheckIfFileIsRtf(this.fileName) == true)
                        {
                            this.richTextBox1.LoadFile(this.fileName, RichTextBoxStreamType.RichText);

                            this.richTextBox1.HideSelection = true;
                            this.richTextBox1.SelectAll();
                            this.richTextBox1.Font = this.richTextBox1.SelectionFont;
                            this.richTextBox1.Select(this.richTextBox1.Text.Length, this.richTextBox1.Text.Length);
                            this.richTextBox1.HideSelection = false;
                            this.fontDialog1.Font = richTextBox1.Font;
                        }
                        else
                        {
                            this.richTextBox1.LoadFile(this.fileName, RichTextBoxStreamType.PlainText);
                        }

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
                    if (CheckIfFileIsRtf(this.fileName) == true)
                    {
                        this.richTextBox1.SaveFile(this.fileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        this.richTextBox1.SaveFile(this.fileName, RichTextBoxStreamType.PlainText);
                    }

                    this.textChanged = false;
                }
                catch
                {
                    MessageBox.Show("An error occured! The changes couldn't be saved!", "TextEditor", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }

            this.saveFileDialog1.FileName = string.Empty;
        }

        private bool CheckIfFileIsRtf(string path)
        {
            string[] pathArray = path.Split('.');

            if (pathArray[pathArray.Length - 1] == "rtf")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(true);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
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

        private void FontSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show();
        }
    }
}
