//-----------------------------------------------------------------------
// <copyright file="MainWindow.Designer.cs" company="Company">
// Copyright (c) 2018 Julian and Patrick Gamauf. All rights reserved.
// </copyright>
// <summary>Represents the main window designer class.</summary>
// <author>Julian and Patrick Gamauf</author>
//-----------------------------------------------------------------------
namespace TextEditor
{
    /// <summary>
    /// Represents the main window designer class.
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// The menu of the program.
        /// </summary>
        private System.Windows.Forms.MenuStrip menu;

        /// <summary>
        /// The create a new file menu item.
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;

        /// <summary>
        /// The open a file menu item.
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;

        /// <summary>
        /// The save a file menu item.
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;

        /// <summary>
        /// The save a file as menu item.
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;

        /// <summary>
        /// The about menu item.
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;

        /// <summary>
        /// The font settings menu item.
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;

        /// <summary>
        /// The help menu item.
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;

        /// <summary>
        /// The text box.
        /// </summary>
        private System.Windows.Forms.RichTextBox richTextBox1;

        /// <summary>
        /// The open a file dialog.
        /// </summary>
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        /// <summary>
        /// The save a file as dialog.
        /// </summary>
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

        /// <summary>
        /// The change font dialog.
        /// </summary>
        private System.Windows.Forms.FontDialog fontDialog1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            
            // menu         
            this.menu.BackColor = System.Drawing.SystemColors.Control;
            this.menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] 
            {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem,
            });

            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1220, 40);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";

            // newToolStripMenuItem
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(75, 36);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);

            // openToolStripMenuItem
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(86, 36);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);

            // saveToolStripMenuItem
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(77, 36);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);

            // saveAsToolStripMenuItem
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(109, 36);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);

            // settingsToolStripMenuItem
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(168, 36);
            this.settingsToolStripMenuItem.Text = "Font Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.FontSettingsToolStripMenuItem_Click);

            // helpToolStripMenuItem
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(77, 36);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);

            // aboutToolStripMenuItem
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(92, 36);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);

            // openFileDialog1
            this.openFileDialog1.Filter = "Text files (*.txt)|*.txt|Rich text format (*.rtf)|*.rtf|All files (*.*)|*.*";

            // saveFileDialog1
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "Text files (*.txt)|*.txt|Rich text format (*.rtf)|*.rtf|All files (*.*)|*.*";

            // fontDialog1
            this.fontDialog1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);

            // richTextBox1
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right);
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.richTextBox1.Location = new System.Drawing.Point(0, 43);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1215, 602);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = string.Empty;
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.TextChanged += new System.EventHandler(this.TextHasChanged);

            // MainWindow
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 648);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menu);
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.KeyPreview = true;
            this.MainMenuStrip = this.menu;
            this.Name = "MainWindow";
            this.Text = "TextEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}