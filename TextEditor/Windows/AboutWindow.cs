//-----------------------------------------------------------------------
// <copyright file="AboutWindow.cs" company="Company">
// Copyright (c) 2018 Julian and Patrick Gamauf. All rights reserved.
// </copyright>
// <summary>Represents the about window class.</summary>
// <author>Julian and Patrick Gamauf</author>
//-----------------------------------------------------------------------
namespace TextEditor
{
    using System.Diagnostics;
    using System.Windows.Forms;

    /// <summary>
    /// Represents the about window class.
    /// </summary>
    public partial class AboutWindow : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutWindow"/> class.
        /// </summary>
        public AboutWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Opens the website of the project.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://github.com/JulianG97/TextEditor");
            }
            catch
            {
                MessageBox.Show("An error occured! The website couldn't be opened!", "TextEditor", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
