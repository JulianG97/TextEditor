//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Company">
// Copyright (c) 2018 Julian and Patrick Gamauf. All rights reserved.
// </copyright>
// <summary>Represents the program class.</summary>
// <author>Julian and Patrick Gamauf</author>
//-----------------------------------------------------------------------
namespace TextEditor
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Represents the program class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The entry point of the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainWindow mainWindow = new MainWindow();
            Application.Run(mainWindow);
        }
    }
}
