//-----------------------------------------------------------------------
// <copyright file="MainWindow.cs" company="Company">
// Copyright (c) 2018 Julian and Patrick Gamauf. All rights reserved.
// </copyright>
// <summary>Represents the main window class.</summary>
// <author>Julian and Patrick Gamauf</author>
//-----------------------------------------------------------------------
namespace TextEditor
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Represents the main window class.
    /// </summary>
    public partial class MainWindow : Form
    {
        /// <summary>
        /// A value indicating whether the text of the text box has been changed or not.
        /// </summary>
        private bool textChanged;

        /// <summary>
        /// The path to the file that is currently in use.
        /// </summary>
        private string fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            this.textChanged = false;
            this.fileName = "Untitled";
            this.Text = "TextEditor" + " - " + this.fileName;

            this.OpenFileAtStartUp();
        }

        /// <summary>
        /// Check if there is a file that need to be opened when the program starts. 
        /// If yes, the file will be opened.
        /// </summary>
        private void OpenFileAtStartUp()
        {
            string[] args = Environment.GetCommandLineArgs();

            if (args != null && args.Length == 2)
            {
                this.fileName = args[1];
                this.OpenFile();
            }
        }

        /// <summary>
        /// Checks if a keyboard shortcut is used.
        /// When a known keyboard shortcut is entered, the corresponding command is executed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="k">The event arguments.</param>
        private void MainWindow_KeyDown(object sender, KeyEventArgs k)
        {
            if (k.Control && k.Shift && k.KeyCode == Keys.S)
            {
                this.SaveAsToolStripMenuItem_Click(this, new EventArgs());
            }
            else if (k.Control)
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

        /// <summary>
        /// Sets a value if the text of the text box has been changed.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void TextHasChanged(object sender, EventArgs e)
        {
            this.textChanged = true;
        }

        /// <summary>
        /// Gets the file name of a file path.
        /// </summary>
        /// <param name="path">The path of a file.</param>
        /// <returns>The name of the file.</returns>
        private string GetFileName(string path)
        {
            string[] pathArray = path.Split('\\');
            return pathArray[pathArray.Length - 1];
        }

        /// <summary>
        /// Starts a dialog that allows the user to open a file.
        /// Is called by the corresponding menu item or by a keyboard shortcut.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult askIfSave = DialogResult.None;

            if (this.textChanged == true)
            {
                askIfSave = MessageBox.Show("Do you want to save the changes?", "TextEditor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }

            if (askIfSave == DialogResult.Yes)
            {
                this.SaveFile(false);
            }

            if (askIfSave != DialogResult.Cancel)
            {
                if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.fileName = this.openFileDialog1.FileName;

                    this.OpenFile();
                }
            }
        }

        /// <summary>
        /// Opens a file and loads its contents in the text box.
        /// </summary>
        private void OpenFile()
        {
            try
            {
                if (this.CheckIfFileIsRtf(this.fileName) == true)
                {
                    this.richTextBox1.LoadFile(this.fileName, RichTextBoxStreamType.RichText);

                    // Sets the font of the richtextbox to the font of the .rtf file.
                    this.richTextBox1.HideSelection = true;
                    this.richTextBox1.SelectAll();
                    this.richTextBox1.Font = this.richTextBox1.SelectionFont;
                    this.richTextBox1.Select(this.richTextBox1.Text.Length, this.richTextBox1.Text.Length);
                    this.richTextBox1.HideSelection = false;
                    this.fontDialog1.Font = this.richTextBox1.Font;
                }
                else
                {
                    this.richTextBox1.LoadFile(this.fileName, RichTextBoxStreamType.PlainText);
                }

                this.textChanged = false;
                this.Text = "TextEditor" + " - " + this.GetFileName(this.fileName);
                this.openFileDialog1.FileName = string.Empty;
            }
            catch
            {
                MessageBox.Show("An error occured! The file couldn't be opened!", "TextEditor", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Starts a dialog that allows the user to create a new file.
        /// Is called by the corresponding menu item or by a keyboard shortcut.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult askIfSave = DialogResult.None;

            if (this.textChanged == true)
            {
                askIfSave = MessageBox.Show("Do you want to save the changes?", "TextEditor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }

            if (askIfSave == DialogResult.Yes)
            {
                this.SaveFile(false);
            }

            if (askIfSave != DialogResult.Cancel)
            {
                this.fileName = "Untitled";
                this.Text = "TextEditor" + " - " + this.fileName;
                this.richTextBox1.Text = string.Empty;
                this.textChanged = false;
            }
        }

        /// <summary>
        /// Calls the save file method.
        /// Is called by the corresponding menu item or by a keyboard shortcut.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveFile(false);
        }

        /// <summary>
        /// Saves the content of the text box to a file.
        /// </summary>
        /// <param name="saveAs">A value indicating if it is sure that the user wants to use the save as function.</param>
        private void SaveFile(bool saveAs)
        {
            DialogResult askIfSave = DialogResult.None;

            if (this.fileName == "Untitled" || saveAs == true)
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.fileName = this.saveFileDialog1.FileName;
                    this.Text = "TextEditor" + " - " + this.GetFileName(this.fileName);
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
                    if (this.CheckIfFileIsRtf(this.fileName) == true)
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

        /// <summary>
        /// Checks if a file uses the rich text format.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <returns>A value indicating whether file uses the rich text format or not.</returns>
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

        /// <summary>
        /// Calls the save file method.
        /// Is called by the corresponding menu item or by a keyboard shortcut.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveFile(true);
        }

        /// <summary>
        /// Opens a window with information about the project.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }

        /// <summary>
        /// Before closing the program, asks the user whether or not to save changes to a file.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void MainWindow_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult askIfSave = DialogResult.None;

            if (this.textChanged == true)
            {
                askIfSave = MessageBox.Show("Do you want to save the changes?", "TextEditor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }

            if (askIfSave == DialogResult.Yes)
            {
                this.SaveFile(false);
            }
            else if (askIfSave == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Starts a dialog that allows the user to change the font, font style and font size of the text box.
        /// Is called by the corresponding menu item or by a keyboard shortcut.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void FontSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.Font = this.fontDialog1.Font;
            }
        }

        /// <summary>
        /// Opens a window with the documentation of the project.
        /// Is called by the corresponding menu item or by a keyboard shortcut.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show();
        }
    }
}
