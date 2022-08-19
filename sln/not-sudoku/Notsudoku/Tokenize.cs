/******************************************************************************
Program:     Notsudoku
File:        Backend.cs

Purpose:     This file contains the GetFile and TokenizeFile methods, which
             respectively chooses a random puzzle file of a selected difficulty
             and tokenizes that file to get the puzzle and its solution.
******************************************************************************/

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notsudoku
{
    class Tokenize
    {
        /******************************************************************************
        Function:  GetFile

        Use:       reads the directory.txt file line-by-line to randomly choose a
                   puzzle file of the selected difficulty

        Arguments: a string named gamemode, which represents the selected difficulty of
                   the puzzle

        Returns:   a string, which is the path to the randomly chosen puzzle file of
                   the selected difficulty
        ******************************************************************************/
        private static string GetFile(string gamemode)
        {
            string token;
            List<string> filenames = new List<string>();

            using (StreamReader inFile = new StreamReader("../../puzzles/directory.txt"))
            {
                token = inFile.ReadLine();    // Read the first line of the file.

                while (token != null)
                {
                    if (token.Contains(gamemode)) filenames.Add(token);

                    token = inFile.ReadLine();    // Read the next line of the file.
                }
            }

            var random = new Random();
            int index = random.Next(filenames.Count);    // Randomly choose a puzzle file of the selected difficulty.
            return filenames[index];
        }

        /******************************************************************************
        Function:  TokenizeFile

        Use:       reads puzzle file line-by-line then tokenizes the line to get the
                   puzzle and its solution of the selected difficulty

        Arguments: a string named gamemode, which represents the selected difficulty of
                   the puzzle

        Returns:   a List of strings, which contains the puzzle and its solution of the
                   selected difficulty
        ******************************************************************************/
        public static List<string> TokenizeFile(string gamemode)
        {
            string token;
            bool arrayEmpty = true;
            List<string> chars = new List<string>();

            // If the selected difficulty was "easy", then check to see of the array of
            // strings for the easy game mode is empty.
            if (gamemode == "easy")
            {
                for (int i = 0; i < Form1.savedEasyArray.Length; i++)
                {
                    if (Form1.savedEasyArray[i] != null && Form1.savedEasyArray[i] != "")
                    {
                        arrayEmpty = false;
                    }
                }
            }

            // If the selected difficulty was "medium", then check to see of the array
            // of strings for the medium game mode is empty.
            if (gamemode == "medium")
            {
                for (int i = 0; i < Form1.savedMediumArray.Length; i++)
                {
                    if (Form1.savedMediumArray[i] != null && Form1.savedMediumArray[i] != "")
                    {
                        arrayEmpty = false;
                    }
                }
            }

            // If the selected difficulty was "hard", then check to see of the array of
            // strings for the hard game mode is empty.
            if (gamemode == "hard")
            {
                for (int i = 0; i < Form1.savedHardArray.Length; i++)
                {
                    if (Form1.savedHardArray[i] != null && Form1.savedHardArray[i] != "")
                    {
                        arrayEmpty = false;
                    }
                }
            }

            // If the array of strings for the selected difficulty is empty, then
            // tokenize the puzzle file to get the puzzle and its solution.
            if (arrayEmpty)
            {
                using (StreamReader inFile = new StreamReader("../../puzzles/" + GetFile(gamemode)))
                {
                    token = inFile.ReadLine();    // Read the first line of the file.

                    while (token != null)
                    {
                        char[] tokens = token.ToCharArray();

                        // Add the numbers of the puzzle and its solution to the
                        // character array.
                        for (int i = 0; i < tokens.Length; i++)
                        {
                            chars.Add(tokens[i].ToString());
                        }

                        token = inFile.ReadLine();    // Read the next line of the file.
                    }
                }

                return chars;
            }

            // Convert the array of strings of the selected difficulty to a List of
            // strings.
            else
            {
                if (gamemode == "easy") chars = Form1.savedEasyArray.ToList();
                if (gamemode == "medium") chars = Form1.savedMediumArray.ToList();
                if (gamemode == "hard") chars = Form1.savedHardArray.ToList();

                return chars;
            }
        }
    }
}