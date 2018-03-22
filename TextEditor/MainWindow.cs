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
            if (this.textChanged == true)
            {
                // Show Save Dialog
            }

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader reader = new StreamReader(this.openFileDialog1.FileName);
                    this.richTextBox1.Text = reader.ReadToEnd();
                    reader.Close();
                }
                catch
                {
                    // Open Error Window
                }
            }
        }
    }
}
