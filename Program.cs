/******************************************************************************
Program:     Notsudoku
File:        Program.cs

Purpose:     This program creates a Sudoku puzzle game variant, where the
             objective is to make sure the sum of the numbers found in every
             row, column, and diagonal adds up to pre-determined values,
             instead of arranging the numbers 1 through 9 in every row, column,
             and "box".
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notsudoku
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}