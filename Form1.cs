/******************************************************************************
Program:     Notsudoku
File:        Form1.cs

Purpose:     This file contains the "event" methods that are attached to the
             Form objects as well as the methods that implement the Sudoku
             puzzle game variant.
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;

namespace Notsudoku
{
    public partial class Form1 : Form
    {
        private string[] values;    // contains tokenized game values
        public static string[] savedEasyArray = new string[17];    // contains a started easy puzzle and its solution
        public static string[] savedMediumArray = new string[49];    // contains a started medium puzzle and its solution
        public static string[] savedHardArray = new string[97];    // contains a started hard puzzle and its solution
        public static string[] savedInitEasyArray = new string[17];    // contains the initial state of a saved easy puzzle and its solution
        public static string[] savedInitMediumArray = new string[49];    // contains the initial state of a saved medium puzzle and its solution
        public static string[] savedInitHardArray = new string[97];    // contains the initial state of a saved hard puzzle and its solution
        private string gameMode = "";    // represents the selected game mode difficulty
        private int hintCounter = 0;    // represents the number of hints that the player used
        private static System.Timers.Timer aTimer;    // timer
        private static Stopwatch swatch = new Stopwatch();    // keeps track of the time spent on each easy game
        private static Stopwatch swatch2 = new Stopwatch();    // keeps track of the time spent on each medium game
        private static Stopwatch swatch3 = new Stopwatch();    // keeps track of the time spent on each hard game
        string elapsedTime;    // used to show the amount of time the easy game was played
        string elapsedTime2;    // used to show the amount of time the medium game was played
        string elapsedTime3;    // used to show the amount of time the hard game was played
        List<TimeSpan> easyTimes = new List<TimeSpan>();    // represents a log of the times needed to complete the easy games
        List<TimeSpan> mediumTimes = new List<TimeSpan>();    // represents a log of the times needed to complete the medium games
        List<TimeSpan> hardTimes = new List<TimeSpan>();    // represents a log of the times needed to complete the hard games
        bool easyStarted = false;
        bool mediumStarted = false;
        bool hardStarted = false;

        public Form1()
        {
            SetTimer();
            InitializeComponent();
        }

        #region Called functions
        /******************************************************************************
        Function:  CheckForWin

        Use:       checks the TextBoxes of the current puzzle to see if the player has
                   won the game

        Arguments: none

        Returns:   nothing
        ******************************************************************************/
        private void CheckForWin()
        {
            // If the player is attempting to solve an easy puzzle, check the
            // TextBoxes to see if the player has won.
            if (gameMode == "easy")
            {
                // Compare the numbers in the TextBoxes to the solution of the puzzle.
                if (textBox17.Text == values[9] && textBox18.Text == values[10] && textBox19.Text == values[11] &&
                    textBox24.Text == values[12] && textBox25.Text == values[13] && textBox26.Text == values[14] && 
                    textBox31.Text == values[15] && textBox32.Text == values[16] && textBox33.Text == values[17])
                {
                    swatch.Stop();
                    
                    easyTimes.Add(swatch.Elapsed);
                    easyTimes.Sort();

                    // Get the elapsed time as a TimeSpan value.
                    TimeSpan ts = swatch.Elapsed;

                    // Format and display the TimeSpan value.
                    elapsedTime = String.Format("{0:0}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

                    double avg = 0;

                    // Calculate the average time needed to complete an easy game.
                    for (int i = 0; i < easyTimes.Count(); i++)
                    {
                        avg += easyTimes.ElementAt(i).TotalSeconds;
                    }

                    avg /= easyTimes.Count();
                    TimeSpan avgTimeSpan = TimeSpan.FromSeconds(avg);

                    // Format and display the average time needed to complete an easy game.
                    string avgTime = String.Format("{0:0}:{1:00}:{2:00}", avgTimeSpan.Hours, avgTimeSpan.Minutes, avgTimeSpan.Seconds);

                    // Format and display the best time to complete an easy game.
                    string bestTime = String.Format("{0:0}:{1:00}:{2:00}", easyTimes[0].Hours, easyTimes[0].Minutes, easyTimes[0].Seconds);

                    // Display a congratulatory message.
                    string message = String.Format("You won!\nDifficulty: Easy\nElapsed time: {0}\nAverage time: {1}\nBest time: {2}\nHints used: {3}\n\nPress OK to reset the game.", elapsedTime, avgTime, bestTime, hintCounter);
                    if(elapsedTime == bestTime) message = String.Format("You won!\nDifficulty: Easy\nElapsed time: {0}\nAverage time: {1}\nBest time: {2} (New record!)\nHints used: {3}\n\nPress OK to reset the game.", elapsedTime, avgTime, bestTime, hintCounter);
                    MessageBox.Show(message, Form1.ActiveForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset("easy");
                    return;
                }
            }

            // If the player is attempting to solve a medium puzzle, check the
            // TextBoxes to see if the player has won.
            else if (gameMode == "medium")
            {
                // Compare the numbers in the TextBoxes to the solution of the puzzle.
                if (textBox9.Text == values[25] && textBox10.Text == values[26] && textBox11.Text == values[27] && textBox12.Text == values[28] && textBox13.Text == values[29] &&
                    textBox16.Text == values[30] && textBox17.Text == values[31] && textBox18.Text == values[32] && textBox19.Text == values[33] && textBox20.Text == values[34] &&
                    textBox23.Text == values[35] && textBox24.Text == values[36] && textBox25.Text == values[37] && textBox26.Text == values[38] && textBox27.Text == values[39] &&
                    textBox30.Text == values[40] && textBox31.Text == values[41] && textBox32.Text == values[42] && textBox33.Text == values[43] && textBox34.Text == values[44] &&
                    textBox37.Text == values[45] && textBox38.Text == values[46] && textBox39.Text == values[47] && textBox40.Text == values[48] && textBox41.Text == values[49])
                {
                    swatch2.Stop();

                    mediumTimes.Add(swatch2.Elapsed);
                    mediumTimes.Sort();

                    // Get the elapsed time as a TimeSpan value.
                    TimeSpan ts = swatch2.Elapsed;

                    // Format and display the TimeSpan value.
                    elapsedTime = String.Format("{0:0}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

                    double avg = 0;

                    // Calculate the average time needed to complete a medium game.
                    for (int i = 0; i < mediumTimes.Count(); i++)
                    {
                        avg += mediumTimes.ElementAt(i).TotalSeconds;
                    }

                    avg /= mediumTimes.Count();
                    TimeSpan avgTimeSpan = TimeSpan.FromSeconds(avg);

                    // Format and display the average time needed to complete a medium game.
                    string avgTime = String.Format("{0:0}:{1:00}:{2:00}", avgTimeSpan.Hours, avgTimeSpan.Minutes, avgTimeSpan.Seconds);

                    // Format and display the best time to complete a medium game.
                    string bestTime = String.Format("{0:0}:{1:00}:{2:00}", mediumTimes[0].Hours, mediumTimes[0].Minutes, mediumTimes[0].Seconds);

                    // Display a congratulatory message.
                    string message = String.Format("You won!\nDifficulty: Medium\nElapsed time: {0}\nAverage time: {1}\nBest time: {2}\nHints used: {3}\n\nPress OK to reset the game.", elapsedTime, avgTime, bestTime, hintCounter);
                    if (elapsedTime == bestTime) message = String.Format("You won!\nDifficulty: Medium\nElapsed time: {0}\nAverage time: {1}\nBest time: {2} (New record!)\nHints used: {3}\n\nPress OK to reset the game.", elapsedTime, avgTime, bestTime, hintCounter);
                    MessageBox.Show(message, Form1.ActiveForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset("medium");
                    return;
                }
            }

            // If the player is attempting to solve a hard puzzle, check the
            // TextBoxes to see if the player has won.
            else if (gameMode == "hard")
            {
                // Compare the numbers in the TextBoxes to the solution of the puzzle.
                if (textBox1.Text == values[49] && textBox2.Text == values[50] && textBox3.Text == values[51] && textBox4.Text == values[52] && textBox5.Text == values[53] && textBox6.Text == values[54] && textBox7.Text == values[55] &&
                    textBox8.Text == values[56] && textBox9.Text == values[57] && textBox10.Text == values[58] && textBox11.Text == values[59] && textBox12.Text == values[60] && textBox13.Text == values[61] && textBox14.Text == values[62] &&
                    textBox15.Text == values[63] && textBox16.Text == values[64] && textBox17.Text == values[65] && textBox18.Text == values[66] && textBox19.Text == values[67] && textBox20.Text == values[68] && textBox21.Text == values[69] &&
                    textBox22.Text == values[70] && textBox23.Text == values[71] && textBox24.Text == values[72] && textBox25.Text == values[73] && textBox26.Text == values[74] && textBox27.Text == values[75] && textBox28.Text == values[76] &&
                    textBox29.Text == values[77] && textBox30.Text == values[78] && textBox31.Text == values[79] && textBox32.Text == values[80] && textBox33.Text == values[81] && textBox34.Text == values[82] && textBox35.Text == values[83] &&
                    textBox36.Text == values[84] && textBox37.Text == values[85] && textBox38.Text == values[86] && textBox39.Text == values[87] && textBox40.Text == values[88] && textBox41.Text == values[89] && textBox42.Text == values[90] &&
                    textBox43.Text == values[91] && textBox44.Text == values[92] && textBox45.Text == values[93] && textBox46.Text == values[94] && textBox47.Text == values[95] && textBox48.Text == values[96] && textBox49.Text == values[97])
                {
                    swatch3.Stop();

                    hardTimes.Add(swatch3.Elapsed);
                    hardTimes.Sort();

                    // Get the elapsed time as a TimeSpan value.
                    TimeSpan ts = swatch3.Elapsed;

                    // Format and display the TimeSpan value.
                    elapsedTime = String.Format("{0:0}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

                    double avg = 0;

                    // Calculate the average time needed to complete a hard game.
                    for (int i = 0; i < hardTimes.Count(); i++)
                    {
                        avg += hardTimes.ElementAt(i).TotalSeconds;
                    }

                    avg /= hardTimes.Count();
                    TimeSpan avgTimeSpan = TimeSpan.FromSeconds(avg);

                    // Format and display the average time needed to complete a hard game.
                    string avgTime = String.Format("{0:0}:{1:00}:{2:00}", avgTimeSpan.Hours, avgTimeSpan.Minutes, avgTimeSpan.Seconds);

                    // Format and display the best time to complete a hard game.
                    string bestTime = String.Format("{0:0}:{1:00}:{2:00}", hardTimes[0].Hours, hardTimes[0].Minutes, hardTimes[0].Seconds);

                    // Display a congratulatory message.
                    string message = String.Format("You won!\nDifficulty: Hard\nElapsed time: {0}\nAverage time: {1}\nBest time: {2}\nHints used: {3}\n\nPress OK to reset the game.", elapsedTime, avgTime, bestTime, hintCounter);
                    if (elapsedTime == bestTime) message = String.Format("You won!\nDifficulty: Hard\nElapsed time: {0}\nAverage time: {1}\nBest time: {2} (New record!)\nHints used: {3}\n\nPress OK to reset the game.", elapsedTime, avgTime, bestTime, hintCounter);
                    MessageBox.Show(message, Form1.ActiveForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset("hard");
                    return;
                }
            }

            else
            {
                return;
            }
        }

        /******************************************************************************
        Function:  Reset

        Use:       completely resets the puzzle game

        Arguments: a string named buttonClicked, which represents the puzzle game mode
                   to reset

        Returns:   nothing
        ******************************************************************************/
        private void Reset(string buttonClicked)
        {
            // If the player resets an easy puzzle or wins an easy puzzle game, then
            // restart the Stopwatch and clear the array of strings for the easy puzzle
            // game mode.
            if (gameMode == "easy" && buttonClicked != "medium" && buttonClicked != "hard")
            {
                swatch.Restart();

                for (int i = 0; i < savedEasyArray.Length; i++)
                {
                    savedEasyArray[i] = "";
                }
                for (int i = 0; i < savedInitEasyArray.Length; i++)
                {
                    savedInitEasyArray[i] = "";
                }
                easyStarted = false;
            }

            // If the player resets a medium puzzle or wins a medium puzzle game, then
            // restart the Stopwatch and clear the array of strings for the medium
            // puzzle game mode.
            if (gameMode == "medium" && buttonClicked != "easy" && buttonClicked != "hard")
            {
                swatch2.Restart();

                for (int i = 0; i < savedMediumArray.Length; i++)
                {
                    savedMediumArray[i] = "";
                }
                for (int i = 0; i < savedInitMediumArray.Length; i++)
                {
                    savedInitMediumArray[i] = "";
                }
                mediumStarted = false;
            }

            // If the player resets a hard puzzle or wins a hard puzzle game, then
            // restart the Stopwatch and clear the array of strings for the hard puzzle
            // game mode.
            if (gameMode == "hard" && buttonClicked != "easy" && buttonClicked != "medium")
            {
                swatch3.Restart();

                for (int i = 0; i < savedHardArray.Length; i++)
                {
                    savedHardArray[i] = "";
                }
                for (int i = 0; i < savedInitHardArray.Length; i++)
                {
                    savedInitHardArray[i] = "";
                }
                hardStarted = false;
            }

            // Stop the stopwatches.
            timerDisplay.Text = "0:00:00";
            swatch.Stop();
            swatch2.Stop();
            swatch3.Stop();

            // Reset the number of hints used.
            hintCounter = 0;

            // Reset the puzzle game mode.
            gameMode = "";

            // Reset the row values and colors.
            derivedRowValue0.ForeColor = Color.Red;
            derivedRowValue1.ForeColor = Color.Red;
            derivedRowValue2.ForeColor = Color.Red;
            derivedRowValue3.ForeColor = Color.Red;
            derivedRowValue4.ForeColor = Color.Red;
            derivedRowValue5.ForeColor = Color.Red;
            derivedRowValue6.ForeColor = Color.Red;
            derivedRowValue7.ForeColor = Color.Red;
            derivedRowValue8.ForeColor = Color.Red;
            derivedRowValue0.Text = "00";
            derivedRowValue1.Text = "00";
            derivedRowValue2.Text = "00";
            derivedRowValue3.Text = "00";
            derivedRowValue4.Text = "00";
            derivedRowValue5.Text = "00";
            derivedRowValue6.Text = "00";
            derivedRowValue7.Text = "00";
            derivedRowValue8.Text = "00";
            totalRowValue0.Text = "00";
            totalRowValue1.Text = "00";
            totalRowValue2.Text = "00";
            totalRowValue3.Text = "00";
            totalRowValue4.Text = "00";
            totalRowValue5.Text = "00";
            totalRowValue6.Text = "00";
            totalRowValue7.Text = "00";
            totalRowValue8.Text = "00";

            // Reset the column values and colors.
            derivedColValue1.ForeColor = Color.Red;
            derivedColValue2.ForeColor = Color.Red;
            derivedColValue3.ForeColor = Color.Red;
            derivedColValue4.ForeColor = Color.Red;
            derivedColValue5.ForeColor = Color.Red;
            derivedColValue6.ForeColor = Color.Red;
            derivedColValue7.ForeColor = Color.Red;
            derivedColValue1.Text = "00";
            derivedColValue2.Text = "00";
            derivedColValue3.Text = "00";
            derivedColValue4.Text = "00";
            derivedColValue5.Text = "00";
            derivedColValue6.Text = "00";
            derivedColValue7.Text = "00";
            totalColValue1.Text = "00";
            totalColValue2.Text = "00";
            totalColValue3.Text = "00";
            totalColValue4.Text = "00";
            totalColValue5.Text = "00";
            totalColValue6.Text = "00";
            totalColValue7.Text = "00";

            // Reset the TextBoxes text.
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
            textBox29.Text = "";
            textBox30.Text = "";
            textBox31.Text = "";
            textBox32.Text = "";
            textBox33.Text = "";
            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            textBox37.Text = "";
            textBox38.Text = "";
            textBox39.Text = "";
            textBox40.Text = "";
            textBox41.Text = "";
            textBox42.Text = "";
            textBox43.Text = "";
            textBox44.Text = "";
            textBox45.Text = "";
            textBox46.Text = "";
            textBox47.Text = "";
            textBox48.Text = "";
            textBox49.Text = "";

            // Reset the TextBoxes states.
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;
            textBox11.ReadOnly = false;
            textBox12.ReadOnly = false;
            textBox13.ReadOnly = false;
            textBox14.ReadOnly = false;
            textBox15.ReadOnly = false;
            textBox16.ReadOnly = false;
            textBox17.ReadOnly = false;
            textBox18.ReadOnly = false;
            textBox19.ReadOnly = false;
            textBox20.ReadOnly = false;
            textBox21.ReadOnly = false;
            textBox22.ReadOnly = false;
            textBox23.ReadOnly = false;
            textBox24.ReadOnly = false;
            textBox25.ReadOnly = false;
            textBox26.ReadOnly = false;
            textBox27.ReadOnly = false;
            textBox28.ReadOnly = false;
            textBox29.ReadOnly = false;
            textBox30.ReadOnly = false;
            textBox31.ReadOnly = false;
            textBox32.ReadOnly = false;
            textBox33.ReadOnly = false;
            textBox34.ReadOnly = false;
            textBox35.ReadOnly = false;
            textBox36.ReadOnly = false;
            textBox37.ReadOnly = false;
            textBox38.ReadOnly = false;
            textBox39.ReadOnly = false;
            textBox40.ReadOnly = false;
            textBox41.ReadOnly = false;
            textBox42.ReadOnly = false;
            textBox43.ReadOnly = false;
            textBox44.ReadOnly = false;
            textBox45.ReadOnly = false;
            textBox46.ReadOnly = false;
            textBox47.ReadOnly = false;
            textBox48.ReadOnly = false;
            textBox49.ReadOnly = false;

            // Reset the TextBoxes font.
            textBox1.Font = new Font(textBox1.Font, FontStyle.Regular);
            textBox2.Font = new Font(textBox2.Font, FontStyle.Regular);
            textBox3.Font = new Font(textBox3.Font, FontStyle.Regular);
            textBox4.Font = new Font(textBox4.Font, FontStyle.Regular);
            textBox5.Font = new Font(textBox5.Font, FontStyle.Regular);
            textBox6.Font = new Font(textBox6.Font, FontStyle.Regular);
            textBox7.Font = new Font(textBox7.Font, FontStyle.Regular);
            textBox8.Font = new Font(textBox8.Font, FontStyle.Regular);
            textBox9.Font = new Font(textBox9.Font, FontStyle.Regular);
            textBox10.Font = new Font(textBox10.Font, FontStyle.Regular);
            textBox11.Font = new Font(textBox11.Font, FontStyle.Regular);
            textBox12.Font = new Font(textBox12.Font, FontStyle.Regular);
            textBox13.Font = new Font(textBox13.Font, FontStyle.Regular);
            textBox14.Font = new Font(textBox14.Font, FontStyle.Regular);
            textBox15.Font = new Font(textBox15.Font, FontStyle.Regular);
            textBox16.Font = new Font(textBox16.Font, FontStyle.Regular);
            textBox17.Font = new Font(textBox17.Font, FontStyle.Regular);
            textBox18.Font = new Font(textBox18.Font, FontStyle.Regular);
            textBox19.Font = new Font(textBox19.Font, FontStyle.Regular);
            textBox20.Font = new Font(textBox20.Font, FontStyle.Regular);
            textBox21.Font = new Font(textBox21.Font, FontStyle.Regular);
            textBox22.Font = new Font(textBox22.Font, FontStyle.Regular);
            textBox23.Font = new Font(textBox23.Font, FontStyle.Regular);
            textBox24.Font = new Font(textBox24.Font, FontStyle.Regular);
            textBox25.Font = new Font(textBox25.Font, FontStyle.Regular);
            textBox26.Font = new Font(textBox26.Font, FontStyle.Regular);
            textBox27.Font = new Font(textBox27.Font, FontStyle.Regular);
            textBox28.Font = new Font(textBox28.Font, FontStyle.Regular);
            textBox29.Font = new Font(textBox29.Font, FontStyle.Regular);
            textBox30.Font = new Font(textBox30.Font, FontStyle.Regular);
            textBox31.Font = new Font(textBox31.Font, FontStyle.Regular);
            textBox32.Font = new Font(textBox32.Font, FontStyle.Regular);
            textBox33.Font = new Font(textBox33.Font, FontStyle.Regular);
            textBox34.Font = new Font(textBox34.Font, FontStyle.Regular);
            textBox35.Font = new Font(textBox35.Font, FontStyle.Regular);
            textBox36.Font = new Font(textBox36.Font, FontStyle.Regular);
            textBox37.Font = new Font(textBox37.Font, FontStyle.Regular);
            textBox38.Font = new Font(textBox38.Font, FontStyle.Regular);
            textBox39.Font = new Font(textBox39.Font, FontStyle.Regular);
            textBox40.Font = new Font(textBox40.Font, FontStyle.Regular);
            textBox41.Font = new Font(textBox41.Font, FontStyle.Regular);
            textBox42.Font = new Font(textBox42.Font, FontStyle.Regular);
            textBox43.Font = new Font(textBox43.Font, FontStyle.Regular);
            textBox44.Font = new Font(textBox44.Font, FontStyle.Regular);
            textBox45.Font = new Font(textBox45.Font, FontStyle.Regular);
            textBox46.Font = new Font(textBox46.Font, FontStyle.Regular);
            textBox47.Font = new Font(textBox47.Font, FontStyle.Regular);
            textBox48.Font = new Font(textBox48.Font, FontStyle.Regular);
            textBox49.Font = new Font(textBox49.Font, FontStyle.Regular);

            // Reset the TextBoxes BackColors.
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            textBox5.BackColor = Color.White;
            textBox6.BackColor = Color.White;
            textBox7.BackColor = Color.White;
            textBox8.BackColor = Color.White;
            textBox9.BackColor = Color.White;
            textBox10.BackColor = Color.White;
            textBox11.BackColor = Color.White;
            textBox12.BackColor = Color.White;
            textBox13.BackColor = Color.White;
            textBox14.BackColor = Color.White;
            textBox15.BackColor = Color.White;
            textBox16.BackColor = Color.White;
            textBox17.BackColor = Color.White;
            textBox18.BackColor = Color.White;
            textBox19.BackColor = Color.White;
            textBox20.BackColor = Color.White;
            textBox21.BackColor = Color.White;
            textBox22.BackColor = Color.White;
            textBox23.BackColor = Color.White;
            textBox24.BackColor = Color.White;
            textBox25.BackColor = Color.White;
            textBox26.BackColor = Color.White;
            textBox27.BackColor = Color.White;
            textBox28.BackColor = Color.White;
            textBox29.BackColor = Color.White;
            textBox30.BackColor = Color.White;
            textBox31.BackColor = Color.White;
            textBox32.BackColor = Color.White;
            textBox33.BackColor = Color.White;
            textBox34.BackColor = Color.White;
            textBox35.BackColor = Color.White;
            textBox36.BackColor = Color.White;
            textBox37.BackColor = Color.White;
            textBox38.BackColor = Color.White;
            textBox39.BackColor = Color.White;
            textBox40.BackColor = Color.White;
            textBox41.BackColor = Color.White;
            textBox42.BackColor = Color.White;
            textBox43.BackColor = Color.White;
            textBox44.BackColor = Color.White;
            textBox45.BackColor = Color.White;
            textBox46.BackColor = Color.White;
            textBox47.BackColor = Color.White;
            textBox48.BackColor = Color.White;
            textBox49.BackColor = Color.White;

            // Reset the "Check" button.
            checkButton.Text = "Check";
        }

        /******************************************************************************
        Function:  textBoxChanged

        Use:       processes the changes to the TextBoxes for the puzzle game

        Arguments: none

        Returns:   nothing
        ******************************************************************************/
        private void textBoxChanged()
        {
            // Make sure that all the TextBoxes contain integers.
            if (int.TryParse("0" + textBox1.Text, out int value) && int.TryParse("0" + textBox2.Text, out value) && int.TryParse("0" + textBox3.Text, out value)
            && int.TryParse("0" + textBox4.Text, out value) && int.TryParse("0" + textBox5.Text, out value) && int.TryParse("0" + textBox6.Text, out value) && int.TryParse("0" + textBox7.Text, out value)
            && int.TryParse("0" + textBox8.Text, out value) && int.TryParse("0" + textBox9.Text, out value) && int.TryParse("0" + textBox10.Text, out value) && int.TryParse("0" + textBox11.Text, out value)
            && int.TryParse("0" + textBox12.Text, out value) && int.TryParse("0" + textBox13.Text, out value) && int.TryParse("0" + textBox14.Text, out value) && int.TryParse("0" + textBox15.Text, out value)
            && int.TryParse("0" + textBox16.Text, out value) && int.TryParse("0" + textBox17.Text, out value) && int.TryParse("0" + textBox18.Text, out value) && int.TryParse("0" + textBox19.Text, out value)
            && int.TryParse("0" + textBox20.Text, out value) && int.TryParse("0" + textBox21.Text, out value) && int.TryParse("0" + textBox22.Text, out value) && int.TryParse("0" + textBox23.Text, out value)
            && int.TryParse("0" + textBox24.Text, out value) && int.TryParse("0" + textBox25.Text, out value) && int.TryParse("0" + textBox26.Text, out value) && int.TryParse("0" + textBox27.Text, out value)
            && int.TryParse("0" + textBox28.Text, out value) && int.TryParse("0" + textBox29.Text, out value) && int.TryParse("0" + textBox30.Text, out value) && int.TryParse("0" + textBox31.Text, out value)
            && int.TryParse("0" + textBox32.Text, out value) && int.TryParse("0" + textBox33.Text, out value) && int.TryParse("0" + textBox34.Text, out value) && int.TryParse("0" + textBox35.Text, out value)
            && int.TryParse("0" + textBox36.Text, out value) && int.TryParse("0" + textBox37.Text, out value) && int.TryParse("0" + textBox38.Text, out value) && int.TryParse("0" + textBox39.Text, out value)
            && int.TryParse("0" + textBox40.Text, out value) && int.TryParse("0" + textBox41.Text, out value) && int.TryParse("0" + textBox42.Text, out value) && int.TryParse("0" + textBox43.Text, out value)
            && int.TryParse("0" + textBox44.Text, out value) && int.TryParse("0" + textBox45.Text, out value) && int.TryParse("0" + textBox46.Text, out value) && int.TryParse("0" + textBox47.Text, out value)
            && int.TryParse("0" + textBox48.Text, out value) && int.TryParse("0" + textBox49.Text, out value))
            {
                // For the easy puzzle game mode, set the array of strings to the
                // TextBox values and calculate the row, column, and diagonal totals.
                if (gameMode == "easy")
                {
                    savedEasyArray[0] = textBox17.Text;
                    savedEasyArray[1] = textBox18.Text;
                    savedEasyArray[2] = textBox19.Text;
                    savedEasyArray[3] = textBox24.Text;
                    savedEasyArray[4] = textBox25.Text;
                    savedEasyArray[5] = textBox26.Text;
                    savedEasyArray[6] = textBox31.Text;
                    savedEasyArray[7] = textBox32.Text;
                    savedEasyArray[8] = textBox33.Text;

                    // Calculate the current row totals.
                    derivedRowValue3.Text = "" + (int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox18.Text) + int.Parse("0" + textBox19.Text));
                    derivedRowValue4.Text = "" + (int.Parse("0" + textBox24.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox26.Text));
                    derivedRowValue5.Text = "" + (int.Parse("0" + textBox31.Text) + int.Parse("0" + textBox32.Text) + int.Parse("0" + textBox33.Text));
                    
                    // Calculate the current column totals.
                    derivedColValue3.Text = "" + (int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox24.Text) + int.Parse("0" + textBox31.Text));
                    derivedColValue4.Text = "" + (int.Parse("0" + textBox18.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox32.Text));
                    derivedColValue5.Text = "" + (int.Parse("0" + textBox19.Text) + int.Parse("0" + textBox26.Text) + int.Parse("0" + textBox33.Text));
                    
                    // Calculate the current diagonal totals.
                    derivedRowValue6.Text = "" + (int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox33.Text));
                    derivedRowValue2.Text = "" + (int.Parse("0" + textBox31.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox19.Text));
                }

                // For the medium puzzle game mode, set the array of strings to the
                // TextBox values and calculate the row, column, and diagonal totals.
                if (gameMode == "medium")
                {
                    savedMediumArray[0] = textBox9.Text;
                    savedMediumArray[1] = textBox10.Text;
                    savedMediumArray[2] = textBox11.Text;
                    savedMediumArray[3] = textBox12.Text;
                    savedMediumArray[4] = textBox13.Text;
                    savedMediumArray[5] = textBox16.Text;
                    savedMediumArray[6] = textBox17.Text;
                    savedMediumArray[7] = textBox18.Text;
                    savedMediumArray[8] = textBox19.Text;
                    savedMediumArray[9] = textBox20.Text;
                    savedMediumArray[10] = textBox23.Text;
                    savedMediumArray[11] = textBox24.Text;
                    savedMediumArray[12] = textBox25.Text;
                    savedMediumArray[13] = textBox26.Text;
                    savedMediumArray[14] = textBox27.Text;
                    savedMediumArray[15] = textBox30.Text;
                    savedMediumArray[16] = textBox31.Text;
                    savedMediumArray[17] = textBox32.Text;
                    savedMediumArray[18] = textBox33.Text;
                    savedMediumArray[19] = textBox34.Text;
                    savedMediumArray[20] = textBox37.Text;
                    savedMediumArray[21] = textBox38.Text;
                    savedMediumArray[22] = textBox39.Text;
                    savedMediumArray[23] = textBox40.Text;
                    savedMediumArray[24] = textBox41.Text;

                    // Calculate the current row totals.
                    derivedRowValue2.Text = "" + (int.Parse("0" + textBox9.Text) + int.Parse("0" + textBox10.Text) + int.Parse("0" + textBox11.Text) + int.Parse("0" + textBox12.Text) + int.Parse("0" + textBox13.Text));
                    derivedRowValue3.Text = "" + (int.Parse("0" + textBox16.Text) + int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox18.Text) + int.Parse("0" + textBox19.Text) + int.Parse("0" + textBox20.Text));
                    derivedRowValue4.Text = "" + (int.Parse("0" + textBox23.Text) + int.Parse("0" + textBox24.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox26.Text) + int.Parse("0" + textBox27.Text));
                    derivedRowValue5.Text = "" + (int.Parse("0" + textBox30.Text) + int.Parse("0" + textBox31.Text) + int.Parse("0" + textBox32.Text) + int.Parse("0" + textBox33.Text) + int.Parse("0" + textBox34.Text));
                    derivedRowValue6.Text = "" + (int.Parse("0" + textBox37.Text) + int.Parse("0" + textBox38.Text) + int.Parse("0" + textBox39.Text) + int.Parse("0" + textBox40.Text) + int.Parse("0" + textBox41.Text));
                    
                    // Calculate the current column totals.
                    derivedColValue2.Text = "" + (int.Parse("0" + textBox9.Text) + int.Parse("0" + textBox16.Text) + int.Parse("0" + textBox23.Text) + int.Parse("0" + textBox30.Text) + int.Parse("0" + textBox37.Text));
                    derivedColValue3.Text = "" + (int.Parse("0" + textBox10.Text) + int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox24.Text) + int.Parse("0" + textBox31.Text) + int.Parse("0" + textBox38.Text));
                    derivedColValue4.Text = "" + (int.Parse("0" + textBox11.Text) + int.Parse("0" + textBox18.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox32.Text) + int.Parse("0" + textBox39.Text));
                    derivedColValue5.Text = "" + (int.Parse("0" + textBox12.Text) + int.Parse("0" + textBox19.Text) + int.Parse("0" + textBox26.Text) + int.Parse("0" + textBox33.Text) + int.Parse("0" + textBox40.Text));
                    derivedColValue6.Text = "" + (int.Parse("0" + textBox13.Text) + int.Parse("0" + textBox20.Text) + int.Parse("0" + textBox27.Text) + int.Parse("0" + textBox34.Text) + int.Parse("0" + textBox41.Text));
                    
                    // Calculate the current diagonal totals.
                    derivedRowValue1.Text = "" + (int.Parse("0" + textBox37.Text) + int.Parse("0" + textBox31.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox19.Text) + int.Parse("0" + textBox13.Text));
                    derivedRowValue7.Text = "" + (int.Parse("0" + textBox9.Text) + int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox33.Text) + int.Parse("0" + textBox41.Text));
                }

                // For the hard puzzle game mode, set the array of strings to the
                // TextBox values and calculate the row, column, and diagonal totals.
                if (gameMode == "hard")
                {
                    savedHardArray[0] = textBox1.Text;
                    savedHardArray[1] = textBox2.Text;
                    savedHardArray[2] = textBox3.Text;
                    savedHardArray[3] = textBox4.Text;
                    savedHardArray[4] = textBox5.Text;
                    savedHardArray[5] = textBox6.Text;
                    savedHardArray[6] = textBox7.Text;
                    savedHardArray[7] = textBox8.Text;
                    savedHardArray[8] = textBox9.Text;
                    savedHardArray[9] = textBox10.Text;
                    savedHardArray[10] = textBox11.Text;
                    savedHardArray[11] = textBox12.Text;
                    savedHardArray[12] = textBox13.Text;
                    savedHardArray[13] = textBox14.Text;
                    savedHardArray[14] = textBox15.Text;
                    savedHardArray[15] = textBox16.Text;
                    savedHardArray[16] = textBox17.Text;
                    savedHardArray[17] = textBox18.Text;
                    savedHardArray[18] = textBox19.Text;
                    savedHardArray[19] = textBox20.Text;
                    savedHardArray[20] = textBox21.Text;
                    savedHardArray[21] = textBox22.Text;
                    savedHardArray[22] = textBox23.Text;
                    savedHardArray[23] = textBox24.Text;
                    savedHardArray[24] = textBox25.Text;
                    savedHardArray[25] = textBox26.Text;
                    savedHardArray[26] = textBox27.Text;
                    savedHardArray[27] = textBox28.Text;
                    savedHardArray[28] = textBox29.Text;
                    savedHardArray[29] = textBox30.Text;
                    savedHardArray[30] = textBox31.Text;
                    savedHardArray[31] = textBox32.Text;
                    savedHardArray[32] = textBox33.Text;
                    savedHardArray[33] = textBox34.Text;
                    savedHardArray[34] = textBox35.Text;
                    savedHardArray[35] = textBox36.Text;
                    savedHardArray[36] = textBox37.Text;
                    savedHardArray[37] = textBox38.Text;
                    savedHardArray[38] = textBox39.Text;
                    savedHardArray[39] = textBox40.Text;
                    savedHardArray[40] = textBox41.Text;
                    savedHardArray[41] = textBox42.Text;
                    savedHardArray[42] = textBox43.Text;
                    savedHardArray[43] = textBox44.Text;
                    savedHardArray[44] = textBox45.Text;
                    savedHardArray[45] = textBox46.Text;
                    savedHardArray[46] = textBox47.Text;
                    savedHardArray[47] = textBox48.Text;
                    savedHardArray[48] = textBox49.Text;

                    // Calculate the current row totals.
                    derivedRowValue1.Text = "" + (int.Parse("0" + textBox1.Text) + int.Parse("0" + textBox2.Text) + int.Parse("0" + textBox3.Text) + int.Parse("0" + textBox4.Text) + int.Parse("0" + textBox5.Text) + int.Parse("0" + textBox6.Text) + int.Parse("0" + textBox7.Text));
                    derivedRowValue2.Text = "" + (int.Parse("0" + textBox8.Text) + int.Parse("0" + textBox9.Text) + int.Parse("0" + textBox10.Text) + int.Parse("0" + textBox11.Text) + int.Parse("0" + textBox12.Text) + int.Parse("0" + textBox13.Text) + int.Parse("0" + textBox14.Text));
                    derivedRowValue3.Text = "" + (int.Parse("0" + textBox15.Text) + int.Parse("0" + textBox16.Text) + int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox18.Text) + int.Parse("0" + textBox19.Text) + int.Parse("0" + textBox20.Text) + int.Parse("0" + textBox21.Text));
                    derivedRowValue4.Text = "" + (int.Parse("0" + textBox22.Text) + int.Parse("0" + textBox23.Text) + int.Parse("0" + textBox24.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox26.Text) + int.Parse("0" + textBox27.Text) + int.Parse("0" + textBox28.Text));
                    derivedRowValue5.Text = "" + (int.Parse("0" + textBox29.Text) + int.Parse("0" + textBox30.Text) + int.Parse("0" + textBox31.Text) + int.Parse("0" + textBox32.Text) + int.Parse("0" + textBox33.Text) + int.Parse("0" + textBox34.Text) + int.Parse("0" + textBox35.Text));
                    derivedRowValue6.Text = "" + (int.Parse("0" + textBox36.Text) + int.Parse("0" + textBox37.Text) + int.Parse("0" + textBox38.Text) + int.Parse("0" + textBox39.Text) + int.Parse("0" + textBox40.Text) + int.Parse("0" + textBox41.Text) + int.Parse("0" + textBox42.Text));
                    derivedRowValue7.Text = "" + (int.Parse("0" + textBox43.Text) + int.Parse("0" + textBox44.Text) + int.Parse("0" + textBox45.Text) + int.Parse("0" + textBox46.Text) + int.Parse("0" + textBox47.Text) + int.Parse("0" + textBox48.Text) + int.Parse("0" + textBox49.Text));
                    
                    // Calculate the current column totals.
                    derivedColValue1.Text = "" + (int.Parse("0" + textBox1.Text) + int.Parse("0" + textBox8.Text) + int.Parse("0" + textBox15.Text) + int.Parse("0" + textBox22.Text) + int.Parse("0" + textBox29.Text) + int.Parse("0" + textBox36.Text) + int.Parse("0" + textBox43.Text));
                    derivedColValue2.Text = "" + (int.Parse("0" + textBox2.Text) + int.Parse("0" + textBox9.Text) + int.Parse("0" + textBox16.Text) + int.Parse("0" + textBox23.Text) + int.Parse("0" + textBox30.Text) + int.Parse("0" + textBox37.Text) + int.Parse("0" + textBox44.Text));
                    derivedColValue3.Text = "" + (int.Parse("0" + textBox3.Text) + int.Parse("0" + textBox10.Text) + int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox24.Text) + int.Parse("0" + textBox31.Text) + int.Parse("0" + textBox38.Text) + int.Parse("0" + textBox45.Text));
                    derivedColValue4.Text = "" + (int.Parse("0" + textBox4.Text) + int.Parse("0" + textBox11.Text) + int.Parse("0" + textBox18.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox32.Text) + int.Parse("0" + textBox39.Text) + int.Parse("0" + textBox46.Text));
                    derivedColValue5.Text = "" + (int.Parse("0" + textBox5.Text) + int.Parse("0" + textBox12.Text) + int.Parse("0" + textBox19.Text) + int.Parse("0" + textBox26.Text) + int.Parse("0" + textBox33.Text) + int.Parse("0" + textBox40.Text) + int.Parse("0" + textBox47.Text));
                    derivedColValue6.Text = "" + (int.Parse("0" + textBox6.Text) + int.Parse("0" + textBox13.Text) + int.Parse("0" + textBox20.Text) + int.Parse("0" + textBox27.Text) + int.Parse("0" + textBox34.Text) + int.Parse("0" + textBox41.Text) + int.Parse("0" + textBox48.Text));
                    derivedColValue7.Text = "" + (int.Parse("0" + textBox7.Text) + int.Parse("0" + textBox14.Text) + int.Parse("0" + textBox21.Text) + int.Parse("0" + textBox28.Text) + int.Parse("0" + textBox35.Text) + int.Parse("0" + textBox42.Text) + int.Parse("0" + textBox49.Text));
                    
                    // Calculate the current diagonal totals.
                    derivedRowValue0.Text = "" + (int.Parse("0" + textBox43.Text) + int.Parse("0" + textBox37.Text) + int.Parse("0" + textBox31.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox19.Text) + int.Parse("0" + textBox13.Text) + int.Parse("0" + textBox7.Text));
                    derivedRowValue8.Text = "" + (int.Parse("0" + textBox1.Text) + int.Parse("0" + textBox9.Text) + int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox33.Text) + int.Parse("0" + textBox41.Text) + int.Parse("0" + textBox49.Text));
                }

                // If the current row, column, or diagonal total value is equal to its
                // respective solution value, then make the text of that value green.
                // Otherwise, make the text of that value red.
                if (derivedRowValue0.Text == totalRowValue0.Text && derivedRowValue0.Text != "0") derivedRowValue0.ForeColor = Color.Green;
                else derivedRowValue0.ForeColor = Color.Red;
                if (derivedRowValue1.Text == totalRowValue1.Text && derivedRowValue1.Text != "0") derivedRowValue1.ForeColor = Color.Green;
                else derivedRowValue1.ForeColor = Color.Red;
                if (derivedRowValue2.Text == totalRowValue2.Text && derivedRowValue2.Text != "0") derivedRowValue2.ForeColor = Color.Green;
                else derivedRowValue2.ForeColor = Color.Red;
                if (derivedRowValue3.Text == totalRowValue3.Text && derivedRowValue3.Text != "0") derivedRowValue3.ForeColor = Color.Green;
                else derivedRowValue3.ForeColor = Color.Red;
                if (derivedRowValue4.Text == totalRowValue4.Text && derivedRowValue4.Text != "0") derivedRowValue4.ForeColor = Color.Green;
                else derivedRowValue4.ForeColor = Color.Red;
                if (derivedRowValue5.Text == totalRowValue5.Text && derivedRowValue5.Text != "0") derivedRowValue5.ForeColor = Color.Green;
                else derivedRowValue5.ForeColor = Color.Red;
                if (derivedRowValue6.Text == totalRowValue6.Text && derivedRowValue6.Text != "0") derivedRowValue6.ForeColor = Color.Green;
                else derivedRowValue6.ForeColor = Color.Red;
                if (derivedRowValue7.Text == totalRowValue7.Text && derivedRowValue7.Text != "0") derivedRowValue7.ForeColor = Color.Green;
                else derivedRowValue7.ForeColor = Color.Red;
                if (derivedRowValue8.Text == totalRowValue8.Text && derivedRowValue8.Text != "0") derivedRowValue8.ForeColor = Color.Green;
                else derivedRowValue8.ForeColor = Color.Red;
                if (derivedColValue1.Text == totalColValue1.Text && derivedColValue1.Text != "0") derivedColValue1.ForeColor = Color.Green;
                else derivedColValue1.ForeColor = Color.Red;
                if (derivedColValue2.Text == totalColValue2.Text && derivedColValue2.Text != "0") derivedColValue2.ForeColor = Color.Green;
                else derivedColValue2.ForeColor = Color.Red;
                if (derivedColValue3.Text == totalColValue3.Text && derivedColValue3.Text != "0") derivedColValue3.ForeColor = Color.Green;
                else derivedColValue3.ForeColor = Color.Red;
                if (derivedColValue4.Text == totalColValue4.Text && derivedColValue4.Text != "0") derivedColValue4.ForeColor = Color.Green;
                else derivedColValue4.ForeColor = Color.Red;
                if (derivedColValue5.Text == totalColValue5.Text && derivedColValue5.Text != "0") derivedColValue5.ForeColor = Color.Green;
                else derivedColValue5.ForeColor = Color.Red;
                if (derivedColValue6.Text == totalColValue6.Text && derivedColValue6.Text != "0") derivedColValue6.ForeColor = Color.Green;
                else derivedColValue6.ForeColor = Color.Red;
                if (derivedColValue7.Text == totalColValue7.Text && derivedColValue7.Text != "0") derivedColValue7.ForeColor = Color.Green;
                else derivedColValue7.ForeColor = Color.Red;

                CheckForWin();
            }
            
            // If a TextBox contains a non-integer value, then display an error
            // message.
            else
            {
                MessageBox.Show("Fields can only contain integer values.", Form1.ActiveForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Timer functions
        /******************************************************************************
        Function:  SetTimer

        Use:       creates a timer with a one second interval

        Arguments: none

        Returns:   nothing
        ******************************************************************************/
        private void SetTimer()
        {
            // Create a timer with a one second interval.
            aTimer = new System.Timers.Timer(1000);

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        /******************************************************************************
        Function:   OnTimedEvent

        Use:        formats and displays the elapsed time of a puzzle game as a
                    TimeSpan value

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // For an easy puzzle, get the elapsed time then format and display that
            // time as a TimeSpan value.
            if (gameMode == "easy")
            {
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = swatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:0}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

                timerDisplay.Text = elapsedTime;
            }

            // For a medium puzzle, get the elapsed time then format and display that
            // time as a TimeSpan value.
            if (gameMode == "medium")
            {
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = swatch2.Elapsed;

                // Format and display the TimeSpan value.
                elapsedTime2 = String.Format("{0:0}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

                timerDisplay.Text = elapsedTime2;
            }

            // For a hard puzzle, get the elapsed time then format and display that
            // time as a TimeSpan value.
            if (gameMode == "hard")
            {
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = swatch3.Elapsed;

                // Format and display the TimeSpan value.
                elapsedTime3 = String.Format("{0:0}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);

                timerDisplay.Text = elapsedTime3;
            }
        }
        #endregion

        #region gameModeButtons
        /******************************************************************************
        Function:   easyButton_Click

        Use:        sets up an easy puzzle game

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void easyButton_Click(object sender, EventArgs e)
        {
            // Initialize an easy puzzle game
            Reset("easy");
            gameMode = "easy";
            values = Tokenize.TokenizeFile(gameMode).ToArray();    // 0-8: player values | 9-17: solution values
            savedEasyArray = values.ToArray();
            if (!easyStarted) savedInitEasyArray = values.ToArray();
            swatch.Start();

            // Set the TextBoxes based on game state (initial or started)
            if (values[0] != "0") { textBox17.Text = values[0]; }
            if (values[1] != "0") { textBox18.Text = values[1]; }
            if (values[2] != "0") { textBox19.Text = values[2]; }
            if (values[3] != "0") { textBox24.Text = values[3]; }
            if (values[4] != "0") { textBox25.Text = values[4]; }
            if (values[5] != "0") { textBox26.Text = values[5]; }
            if (values[6] != "0") { textBox31.Text = values[6]; }
            if (values[7] != "0") { textBox32.Text = values[7]; }
            if (values[8] != "0") { textBox33.Text = values[8]; }
            if (values[0] != "0" && !easyStarted) { textBox17.Text = values[0]; textBox17.ReadOnly = true; textBox17.Font = new Font(textBox17.Font, FontStyle.Bold); }
            if (values[1] != "0" && !easyStarted) { textBox18.Text = values[1]; textBox18.ReadOnly = true; textBox18.Font = new Font(textBox18.Font, FontStyle.Bold); }
            if (values[2] != "0" && !easyStarted) { textBox19.Text = values[2]; textBox19.ReadOnly = true; textBox19.Font = new Font(textBox19.Font, FontStyle.Bold); }
            if (values[3] != "0" && !easyStarted) { textBox24.Text = values[3]; textBox24.ReadOnly = true; textBox24.Font = new Font(textBox24.Font, FontStyle.Bold); }
            if (values[4] != "0" && !easyStarted) { textBox25.Text = values[4]; textBox25.ReadOnly = true; textBox25.Font = new Font(textBox25.Font, FontStyle.Bold); }
            if (values[5] != "0" && !easyStarted) { textBox26.Text = values[5]; textBox26.ReadOnly = true; textBox26.Font = new Font(textBox26.Font, FontStyle.Bold); }
            if (values[6] != "0" && !easyStarted) { textBox31.Text = values[6]; textBox31.ReadOnly = true; textBox31.Font = new Font(textBox31.Font, FontStyle.Bold); }
            if (values[7] != "0" && !easyStarted) { textBox32.Text = values[7]; textBox32.ReadOnly = true; textBox32.Font = new Font(textBox32.Font, FontStyle.Bold); }
            if (values[8] != "0" && !easyStarted) { textBox33.Text = values[8]; textBox33.ReadOnly = true; textBox33.Font = new Font(textBox33.Font, FontStyle.Bold); }
            if (easyStarted)
            {
                if (savedInitEasyArray[0] != "0") { textBox17.Text = values[0]; textBox17.ReadOnly = true; textBox17.Font = new Font(textBox17.Font, FontStyle.Bold); }
                if (savedInitEasyArray[1] != "0") { textBox18.Text = values[1]; textBox18.ReadOnly = true; textBox18.Font = new Font(textBox18.Font, FontStyle.Bold); }
                if (savedInitEasyArray[2] != "0") { textBox19.Text = values[2]; textBox19.ReadOnly = true; textBox19.Font = new Font(textBox19.Font, FontStyle.Bold); }
                if (savedInitEasyArray[3] != "0") { textBox24.Text = values[3]; textBox24.ReadOnly = true; textBox24.Font = new Font(textBox24.Font, FontStyle.Bold); }
                if (savedInitEasyArray[4] != "0") { textBox25.Text = values[4]; textBox25.ReadOnly = true; textBox25.Font = new Font(textBox25.Font, FontStyle.Bold); }
                if (savedInitEasyArray[5] != "0") { textBox26.Text = values[5]; textBox26.ReadOnly = true; textBox26.Font = new Font(textBox26.Font, FontStyle.Bold); }
                if (savedInitEasyArray[6] != "0") { textBox31.Text = values[6]; textBox31.ReadOnly = true; textBox31.Font = new Font(textBox31.Font, FontStyle.Bold); }
                if (savedInitEasyArray[7] != "0") { textBox32.Text = values[7]; textBox32.ReadOnly = true; textBox32.Font = new Font(textBox32.Font, FontStyle.Bold); }
                if (savedInitEasyArray[8] != "0") { textBox33.Text = values[8]; textBox33.ReadOnly = true; textBox33.Font = new Font(textBox33.Font, FontStyle.Bold); }
            }

            // easy game has been initialized
            easyStarted = true;

            // Calculate the solution row totals.
            totalRowValue3.Text = "" + (int.Parse(values[9]) + int.Parse(values[10]) + int.Parse(values[11]));
            totalRowValue4.Text = "" + (int.Parse(values[12]) + int.Parse(values[13]) + int.Parse(values[14]));
            totalRowValue5.Text = "" + (int.Parse(values[15]) + int.Parse(values[16]) + int.Parse(values[17]));
            
            // Calculate the solution column totals
            totalColValue3.Text = "" + (int.Parse(values[9]) + int.Parse(values[12]) + int.Parse(values[15]));
            totalColValue4.Text = "" + (int.Parse(values[10]) + int.Parse(values[13]) + int.Parse(values[16]));
            totalColValue5.Text = "" + (int.Parse(values[11]) + int.Parse(values[14]) + int.Parse(values[17]));
            
            // Calculate the solution diagonal totals.
            totalRowValue2.Text = "" + (int.Parse(values[15]) + int.Parse(values[13]) + int.Parse(values[11]));
            totalRowValue6.Text = "" + (int.Parse(values[9]) + int.Parse(values[13]) + int.Parse(values[17]));

            // Change the visibility.
            derivedRowValue0.Visible = false;
            derivedRowValue1.Visible = false;
            derivedRowValue7.Visible = false;
            derivedRowValue8.Visible = false;
            totalRowValue0.Visible = false;
            totalRowValue1.Visible = false;
            totalRowValue7.Visible = false;
            totalRowValue8.Visible = false;

            derivedColValue1.Visible = false;
            derivedColValue2.Visible = false;
            derivedColValue6.Visible = false;
            derivedColValue7.Visible = false;
            totalColValue1.Visible = false;
            totalColValue2.Visible = false;
            totalColValue6.Visible = false;
            totalColValue7.Visible = false;

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
            textBox15.Visible = false;
            textBox16.Visible = false;
            textBox20.Visible = false;
            textBox21.Visible = false;
            textBox22.Visible = false;
            textBox23.Visible = false;
            textBox27.Visible = false;
            textBox28.Visible = false;
            textBox29.Visible = false;
            textBox30.Visible = false;
            textBox34.Visible = false;
            textBox35.Visible = false;
            textBox36.Visible = false;
            textBox37.Visible = false;
            textBox38.Visible = false;
            textBox39.Visible = false;
            textBox40.Visible = false;
            textBox41.Visible = false;
            textBox42.Visible = false;
            textBox43.Visible = false;
            textBox44.Visible = false;
            textBox45.Visible = false;
            textBox46.Visible = false;
            textBox47.Visible = false;
            textBox48.Visible = false;
            textBox49.Visible = false;
        }

        /******************************************************************************
        Function:   mediumButton_Click

        Use:        sets up a medium puzzle game

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void mediumButton_Click(object sender, EventArgs e)
        {
            // Initialize an easy puzzle game
            Reset("medium");
            gameMode = "medium";
            values = Tokenize.TokenizeFile(gameMode).ToArray();    // 0-24: player values | 25-49: solution values
            savedMediumArray = values.ToArray();
            if(!mediumStarted) savedInitMediumArray = values.ToArray();
            swatch2.Start();

            // Set the TextBoxes based on game state (initial or started)
            if (values[0] != "0") { textBox9.Text = values[0]; }
            if (values[1] != "0") { textBox10.Text = values[1]; }
            if (values[2] != "0") { textBox11.Text = values[2]; }
            if (values[3] != "0") { textBox12.Text = values[3]; }
            if (values[4] != "0") { textBox13.Text = values[4]; }
            if (values[5] != "0") { textBox16.Text = values[5]; }
            if (values[6] != "0") { textBox17.Text = values[6]; }
            if (values[7] != "0") { textBox18.Text = values[7]; }
            if (values[8] != "0") { textBox19.Text = values[8]; }
            if (values[9] != "0") { textBox20.Text = values[9]; }
            if (values[10] != "0") { textBox23.Text = values[10]; }
            if (values[11] != "0") { textBox24.Text = values[11]; }
            if (values[12] != "0") { textBox25.Text = values[12]; }
            if (values[13] != "0") { textBox26.Text = values[13]; }
            if (values[14] != "0") { textBox27.Text = values[14]; }
            if (values[15] != "0") { textBox30.Text = values[15]; }
            if (values[16] != "0") { textBox31.Text = values[16]; }
            if (values[17] != "0") { textBox32.Text = values[17]; }
            if (values[18] != "0") { textBox33.Text = values[18]; }
            if (values[19] != "0") { textBox34.Text = values[19]; }
            if (values[20] != "0") { textBox37.Text = values[20]; }
            if (values[21] != "0") { textBox38.Text = values[21]; }
            if (values[22] != "0") { textBox39.Text = values[22]; }
            if (values[23] != "0") { textBox40.Text = values[23]; }
            if (values[24] != "0") { textBox41.Text = values[24]; }
            if (values[0] != "0" && !mediumStarted) { textBox9.ReadOnly = true; textBox9.Font = new Font(textBox9.Font, FontStyle.Bold); }
            if (values[1] != "0" && !mediumStarted) {  textBox10.ReadOnly = true; textBox10.Font = new Font(textBox10.Font, FontStyle.Bold); }
            if (values[2] != "0" && !mediumStarted) {  textBox11.ReadOnly = true; textBox11.Font = new Font(textBox11.Font, FontStyle.Bold); }
            if (values[3] != "0" && !mediumStarted) {  textBox12.ReadOnly = true; textBox12.Font = new Font(textBox12.Font, FontStyle.Bold); }
            if (values[4] != "0" && !mediumStarted) {  textBox13.ReadOnly = true; textBox13.Font = new Font(textBox13.Font, FontStyle.Bold); }
            if (values[5] != "0" && !mediumStarted) {  textBox16.ReadOnly = true; textBox16.Font = new Font(textBox16.Font, FontStyle.Bold); }
            if (values[6] != "0" && !mediumStarted) {  textBox17.ReadOnly = true; textBox17.Font = new Font(textBox17.Font, FontStyle.Bold); }
            if (values[7] != "0" && !mediumStarted) {  textBox18.ReadOnly = true; textBox18.Font = new Font(textBox18.Font, FontStyle.Bold); }
            if (values[8] != "0" && !mediumStarted) {  textBox19.ReadOnly = true; textBox19.Font = new Font(textBox19.Font, FontStyle.Bold); }
            if (values[9] != "0" && !mediumStarted) {  textBox20.ReadOnly = true; textBox20.Font = new Font(textBox20.Font, FontStyle.Bold); }
            if (values[10] != "0" && !mediumStarted) { textBox23.ReadOnly = true; textBox23.Font = new Font(textBox23.Font, FontStyle.Bold); }
            if (values[11] != "0" && !mediumStarted) { textBox24.ReadOnly = true; textBox24.Font = new Font(textBox24.Font, FontStyle.Bold); }
            if (values[12] != "0" && !mediumStarted) { textBox25.ReadOnly = true; textBox25.Font = new Font(textBox25.Font, FontStyle.Bold); }
            if (values[13] != "0" && !mediumStarted) { textBox26.ReadOnly = true; textBox26.Font = new Font(textBox26.Font, FontStyle.Bold); }
            if (values[14] != "0" && !mediumStarted) { textBox27.ReadOnly = true; textBox27.Font = new Font(textBox27.Font, FontStyle.Bold); }
            if (values[15] != "0" && !mediumStarted) { textBox30.ReadOnly = true; textBox30.Font = new Font(textBox30.Font, FontStyle.Bold); }
            if (values[16] != "0" && !mediumStarted) { textBox31.ReadOnly = true; textBox31.Font = new Font(textBox31.Font, FontStyle.Bold); }
            if (values[17] != "0" && !mediumStarted) { textBox32.ReadOnly = true; textBox32.Font = new Font(textBox32.Font, FontStyle.Bold); }
            if (values[18] != "0" && !mediumStarted) { textBox33.ReadOnly = true; textBox33.Font = new Font(textBox33.Font, FontStyle.Bold); }
            if (values[19] != "0" && !mediumStarted) { textBox34.ReadOnly = true; textBox34.Font = new Font(textBox34.Font, FontStyle.Bold); }
            if (values[20] != "0" && !mediumStarted) { textBox37.ReadOnly = true; textBox37.Font = new Font(textBox37.Font, FontStyle.Bold); }
            if (values[21] != "0" && !mediumStarted) { textBox38.ReadOnly = true; textBox38.Font = new Font(textBox38.Font, FontStyle.Bold); }
            if (values[22] != "0" && !mediumStarted) { textBox39.ReadOnly = true; textBox39.Font = new Font(textBox39.Font, FontStyle.Bold); }
            if (values[23] != "0" && !mediumStarted) { textBox40.ReadOnly = true; textBox40.Font = new Font(textBox40.Font, FontStyle.Bold); }
            if (values[24] != "0" && !mediumStarted) { textBox41.ReadOnly = true; textBox41.Font = new Font(textBox41.Font, FontStyle.Bold); }
            if (mediumStarted)
            {
                if (savedInitMediumArray[0] != "0") { textBox9.ReadOnly = true; textBox9.Font = new Font(textBox9.Font, FontStyle.Bold); }
                if (savedInitMediumArray[1] != "0") { textBox10.ReadOnly = true; textBox10.Font = new Font(textBox10.Font, FontStyle.Bold); }
                if (savedInitMediumArray[2] != "0") { textBox11.ReadOnly = true; textBox11.Font = new Font(textBox11.Font, FontStyle.Bold); }
                if (savedInitMediumArray[3] != "0") { textBox12.ReadOnly = true; textBox12.Font = new Font(textBox12.Font, FontStyle.Bold); }
                if (savedInitMediumArray[4] != "0") { textBox13.ReadOnly = true; textBox13.Font = new Font(textBox13.Font, FontStyle.Bold); }
                if (savedInitMediumArray[5] != "0") { textBox16.ReadOnly = true; textBox16.Font = new Font(textBox16.Font, FontStyle.Bold); }
                if (savedInitMediumArray[6] != "0") { textBox17.ReadOnly = true; textBox17.Font = new Font(textBox17.Font, FontStyle.Bold); }
                if (savedInitMediumArray[7] != "0") { textBox18.ReadOnly = true; textBox18.Font = new Font(textBox18.Font, FontStyle.Bold); }
                if (savedInitMediumArray[8] != "0") { textBox19.ReadOnly = true; textBox19.Font = new Font(textBox19.Font, FontStyle.Bold); }
                if (savedInitMediumArray[9] != "0") { textBox20.ReadOnly = true; textBox20.Font = new Font(textBox20.Font, FontStyle.Bold); }
                if (savedInitMediumArray[10] != "0") { textBox23.ReadOnly = true; textBox23.Font = new Font(textBox23.Font, FontStyle.Bold); }
                if (savedInitMediumArray[11] != "0") { textBox24.ReadOnly = true; textBox24.Font = new Font(textBox24.Font, FontStyle.Bold); }
                if (savedInitMediumArray[12] != "0") { textBox25.ReadOnly = true; textBox25.Font = new Font(textBox25.Font, FontStyle.Bold); }
                if (savedInitMediumArray[13] != "0") { textBox26.ReadOnly = true; textBox26.Font = new Font(textBox26.Font, FontStyle.Bold); }
                if (savedInitMediumArray[14] != "0") { textBox27.ReadOnly = true; textBox27.Font = new Font(textBox27.Font, FontStyle.Bold); }
                if (savedInitMediumArray[15] != "0") { textBox30.ReadOnly = true; textBox30.Font = new Font(textBox30.Font, FontStyle.Bold); }
                if (savedInitMediumArray[16] != "0") { textBox31.ReadOnly = true; textBox31.Font = new Font(textBox31.Font, FontStyle.Bold); }
                if (savedInitMediumArray[17] != "0") { textBox32.ReadOnly = true; textBox32.Font = new Font(textBox32.Font, FontStyle.Bold); }
                if (savedInitMediumArray[18] != "0") { textBox33.ReadOnly = true; textBox33.Font = new Font(textBox33.Font, FontStyle.Bold); }
                if (savedInitMediumArray[19] != "0") { textBox34.ReadOnly = true; textBox34.Font = new Font(textBox34.Font, FontStyle.Bold); }
                if (savedInitMediumArray[20] != "0") { textBox37.ReadOnly = true; textBox37.Font = new Font(textBox37.Font, FontStyle.Bold); }
                if (savedInitMediumArray[21] != "0") { textBox38.ReadOnly = true; textBox38.Font = new Font(textBox38.Font, FontStyle.Bold); }
                if (savedInitMediumArray[22] != "0") { textBox39.ReadOnly = true; textBox39.Font = new Font(textBox39.Font, FontStyle.Bold); }
                if (savedInitMediumArray[23] != "0") { textBox40.ReadOnly = true; textBox40.Font = new Font(textBox40.Font, FontStyle.Bold); }
                if (savedInitMediumArray[24] != "0") { textBox41.ReadOnly = true; textBox41.Font = new Font(textBox41.Font, FontStyle.Bold); }
            }

            // medium game has been initialized
            mediumStarted = true;

            // Calculate the solution row totals.
            totalRowValue2.Text = "" + (int.Parse(values[25]) + int.Parse(values[26]) + int.Parse(values[27]) + int.Parse(values[28]) + int.Parse(values[29]));
            totalRowValue3.Text = "" + (int.Parse(values[30]) + int.Parse(values[31]) + int.Parse(values[32]) + int.Parse(values[33]) + int.Parse(values[34]));
            totalRowValue4.Text = "" + (int.Parse(values[35]) + int.Parse(values[36]) + int.Parse(values[37]) + int.Parse(values[38]) + int.Parse(values[39]));
            totalRowValue5.Text = "" + (int.Parse(values[40]) + int.Parse(values[41]) + int.Parse(values[42]) + int.Parse(values[43]) + int.Parse(values[44]));
            totalRowValue6.Text = "" + (int.Parse(values[45]) + int.Parse(values[46]) + int.Parse(values[47]) + int.Parse(values[48]) + int.Parse(values[49]));
            
            // Calculate the solution column totals.
            totalColValue2.Text = "" + (int.Parse(values[25]) + int.Parse(values[30]) + int.Parse(values[35]) + int.Parse(values[40]) + int.Parse(values[45]));
            totalColValue3.Text = "" + (int.Parse(values[26]) + int.Parse(values[31]) + int.Parse(values[36]) + int.Parse(values[41]) + int.Parse(values[46]));
            totalColValue4.Text = "" + (int.Parse(values[27]) + int.Parse(values[32]) + int.Parse(values[37]) + int.Parse(values[42]) + int.Parse(values[47]));
            totalColValue5.Text = "" + (int.Parse(values[28]) + int.Parse(values[33]) + int.Parse(values[38]) + int.Parse(values[43]) + int.Parse(values[48]));
            totalColValue6.Text = "" + (int.Parse(values[29]) + int.Parse(values[34]) + int.Parse(values[39]) + int.Parse(values[44]) + int.Parse(values[49]));
            
            // Calculate the solution diagonal totals.
            totalRowValue1.Text = "" + (int.Parse(values[45]) + int.Parse(values[41]) + int.Parse(values[37]) + int.Parse(values[33]) + int.Parse(values[29]));
            totalRowValue7.Text = "" + (int.Parse(values[25]) + int.Parse(values[31]) + int.Parse(values[37]) + int.Parse(values[43]) + int.Parse(values[49]));

            // Change the visibility.
            derivedRowValue0.Visible = false;
            derivedRowValue1.Visible = true;
            derivedRowValue5.Visible = true;
            derivedRowValue6.Visible = true;
            derivedRowValue7.Visible = true;
            derivedRowValue8.Visible = false;
            totalRowValue0.Visible = false;
            totalRowValue1.Visible = true;
            totalRowValue5.Visible = true;
            totalRowValue6.Visible = true;
            totalRowValue7.Visible = true;
            totalRowValue8.Visible = false;

            derivedColValue1.Visible = false;
            derivedColValue2.Visible = true;
            derivedColValue6.Visible = true;
            derivedColValue7.Visible = false;
            totalColValue1.Visible = false;
            totalColValue2.Visible = true;
            totalColValue6.Visible = true;
            totalColValue7.Visible = false;

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = true;
            textBox10.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
            textBox13.Visible = true;
            textBox14.Visible = false;
            textBox15.Visible = false;
            textBox16.Visible = true;
            textBox20.Visible = true;
            textBox21.Visible = false;
            textBox22.Visible = false;
            textBox23.Visible = true;
            textBox27.Visible = true;
            textBox28.Visible = false;
            textBox29.Visible = false;
            textBox30.Visible = true;
            textBox33.Visible = true;
            textBox34.Visible = true;
            textBox35.Visible = false;
            textBox36.Visible = false;
            textBox37.Visible = true;
            textBox38.Visible = true;
            textBox39.Visible = true;
            textBox40.Visible = true;
            textBox41.Visible = true;
            textBox42.Visible = false;
            textBox43.Visible = false;
            textBox44.Visible = false;
            textBox45.Visible = false;
            textBox46.Visible = false;
            textBox47.Visible = false;
            textBox48.Visible = false;
            textBox49.Visible = false;
        }

        /******************************************************************************
        Function:   hardButton_Click

        Use:        sets up a hard puzzle game

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void hardButton_Click(object sender, EventArgs e)
        {
            // Initialize an easy puzzle game
            Reset("hard");
            gameMode = "hard";
            values = Tokenize.TokenizeFile(gameMode).ToArray();    // 0-48: player values | 49-97: solution values
            savedHardArray = values.ToArray();
            if (!hardStarted) savedInitHardArray = values.ToArray();
            swatch3.Start();

            // Set the TextBoxes based on game state (initial or started)
            if (values[0] != "0") { textBox1.Text = values[0]; }
            if (values[1] != "0") { textBox2.Text = values[1]; }
            if (values[2] != "0") { textBox3.Text = values[2]; }
            if (values[3] != "0") { textBox4.Text = values[3]; }
            if (values[4] != "0") { textBox5.Text = values[4]; }
            if (values[5] != "0") { textBox6.Text = values[5]; }
            if (values[6] != "0") { textBox7.Text = values[6]; }
            if (values[7] != "0") { textBox8.Text = values[7]; }
            if (values[8] != "0") { textBox9.Text = values[8]; }
            if (values[9] != "0") { textBox10.Text = values[9]; }
            if (values[10] != "0") { textBox11.Text = values[10]; }
            if (values[11] != "0") { textBox12.Text = values[11]; }
            if (values[12] != "0") { textBox13.Text = values[12]; }
            if (values[13] != "0") { textBox14.Text = values[13]; }
            if (values[14] != "0") { textBox15.Text = values[14]; }
            if (values[15] != "0") { textBox16.Text = values[15]; }
            if (values[16] != "0") { textBox17.Text = values[16]; }
            if (values[17] != "0") { textBox18.Text = values[17]; }
            if (values[18] != "0") { textBox19.Text = values[18]; }
            if (values[19] != "0") { textBox20.Text = values[19]; }
            if (values[20] != "0") { textBox21.Text = values[20]; }
            if (values[21] != "0") { textBox22.Text = values[21]; }
            if (values[22] != "0") { textBox23.Text = values[22]; }
            if (values[23] != "0") { textBox24.Text = values[23]; }
            if (values[24] != "0") { textBox25.Text = values[24]; }
            if (values[25] != "0") { textBox26.Text = values[25]; }
            if (values[26] != "0") { textBox27.Text = values[26]; }
            if (values[27] != "0") { textBox28.Text = values[27]; }
            if (values[28] != "0") { textBox29.Text = values[28]; }
            if (values[29] != "0") { textBox30.Text = values[29]; }
            if (values[30] != "0") { textBox31.Text = values[30]; }
            if (values[31] != "0") { textBox32.Text = values[31]; }
            if (values[32] != "0") { textBox33.Text = values[32]; }
            if (values[33] != "0") { textBox34.Text = values[33]; }
            if (values[34] != "0") { textBox35.Text = values[34]; }
            if (values[35] != "0") { textBox36.Text = values[35]; }
            if (values[36] != "0") { textBox37.Text = values[36]; }
            if (values[37] != "0") { textBox38.Text = values[37]; }
            if (values[38] != "0") { textBox39.Text = values[38]; }
            if (values[39] != "0") { textBox40.Text = values[39]; }
            if (values[40] != "0") { textBox41.Text = values[40]; }
            if (values[41] != "0") { textBox42.Text = values[41]; }
            if (values[42] != "0") { textBox43.Text = values[42]; }
            if (values[43] != "0") { textBox44.Text = values[43]; }
            if (values[44] != "0") { textBox45.Text = values[44]; }
            if (values[45] != "0") { textBox46.Text = values[45]; }
            if (values[46] != "0") { textBox47.Text = values[46]; }
            if (values[47] != "0") { textBox48.Text = values[47]; }
            if (values[48] != "0") { textBox49.Text = values[48]; }
            if (values[0] != "0" && !hardStarted) { textBox1.ReadOnly = true; textBox1.Font = new Font(textBox1.Font, FontStyle.Bold); }
            if (values[1] != "0" && !hardStarted) { textBox2.ReadOnly = true; textBox2.Font = new Font(textBox2.Font, FontStyle.Bold); }
            if (values[2] != "0" && !hardStarted) { textBox3.ReadOnly = true; textBox3.Font = new Font(textBox3.Font, FontStyle.Bold); }
            if (values[3] != "0" && !hardStarted) { textBox4.ReadOnly = true; textBox4.Font = new Font(textBox4.Font, FontStyle.Bold); }
            if (values[4] != "0" && !hardStarted) { textBox5.ReadOnly = true; textBox5.Font = new Font(textBox5.Font, FontStyle.Bold); }
            if (values[5] != "0" && !hardStarted) { textBox6.ReadOnly = true; textBox6.Font = new Font(textBox6.Font, FontStyle.Bold); }
            if (values[6] != "0" && !hardStarted) { textBox7.ReadOnly = true; textBox7.Font = new Font(textBox7.Font, FontStyle.Bold); }
            if (values[7] != "0" && !hardStarted) { textBox8.ReadOnly = true; textBox8.Font = new Font(textBox8.Font, FontStyle.Bold); }
            if (values[8] != "0" && !hardStarted) { textBox9.ReadOnly = true; textBox9.Font = new Font(textBox9.Font, FontStyle.Bold); }
            if (values[9] != "0" && !hardStarted) { textBox10.ReadOnly = true; textBox10.Font = new Font(textBox10.Font, FontStyle.Bold); }
            if (values[10] != "0" && !hardStarted) { textBox11.ReadOnly = true; textBox11.Font = new Font(textBox11.Font, FontStyle.Bold); }
            if (values[11] != "0" && !hardStarted) { textBox12.ReadOnly = true; textBox12.Font = new Font(textBox12.Font, FontStyle.Bold); }
            if (values[12] != "0" && !hardStarted) { textBox13.ReadOnly = true; textBox13.Font = new Font(textBox13.Font, FontStyle.Bold); }
            if (values[13] != "0" && !hardStarted) { textBox14.ReadOnly = true; textBox14.Font = new Font(textBox14.Font, FontStyle.Bold); }
            if (values[14] != "0" && !hardStarted) { textBox15.ReadOnly = true; textBox15.Font = new Font(textBox15.Font, FontStyle.Bold); }
            if (values[15] != "0" && !hardStarted) { textBox16.ReadOnly = true; textBox16.Font = new Font(textBox16.Font, FontStyle.Bold); }
            if (values[16] != "0" && !hardStarted) { textBox17.ReadOnly = true; textBox17.Font = new Font(textBox17.Font, FontStyle.Bold); }
            if (values[17] != "0" && !hardStarted) { textBox18.ReadOnly = true; textBox18.Font = new Font(textBox18.Font, FontStyle.Bold); }
            if (values[18] != "0" && !hardStarted) { textBox19.ReadOnly = true; textBox19.Font = new Font(textBox19.Font, FontStyle.Bold); }
            if (values[19] != "0" && !hardStarted) { textBox20.ReadOnly = true; textBox20.Font = new Font(textBox20.Font, FontStyle.Bold); }
            if (values[20] != "0" && !hardStarted) { textBox21.ReadOnly = true; textBox21.Font = new Font(textBox21.Font, FontStyle.Bold); }
            if (values[21] != "0" && !hardStarted) { textBox22.ReadOnly = true; textBox22.Font = new Font(textBox22.Font, FontStyle.Bold); }
            if (values[22] != "0" && !hardStarted) { textBox23.ReadOnly = true; textBox23.Font = new Font(textBox23.Font, FontStyle.Bold); }
            if (values[23] != "0" && !hardStarted) { textBox24.ReadOnly = true; textBox24.Font = new Font(textBox24.Font, FontStyle.Bold); }
            if (values[24] != "0" && !hardStarted) { textBox25.ReadOnly = true; textBox25.Font = new Font(textBox25.Font, FontStyle.Bold); }
            if (values[25] != "0" && !hardStarted) { textBox26.ReadOnly = true; textBox26.Font = new Font(textBox26.Font, FontStyle.Bold); }
            if (values[26] != "0" && !hardStarted) { textBox27.ReadOnly = true; textBox27.Font = new Font(textBox27.Font, FontStyle.Bold); }
            if (values[27] != "0" && !hardStarted) { textBox28.ReadOnly = true; textBox28.Font = new Font(textBox28.Font, FontStyle.Bold); }
            if (values[28] != "0" && !hardStarted) { textBox29.ReadOnly = true; textBox29.Font = new Font(textBox29.Font, FontStyle.Bold); }
            if (values[29] != "0" && !hardStarted) { textBox30.ReadOnly = true; textBox30.Font = new Font(textBox30.Font, FontStyle.Bold); }
            if (values[30] != "0" && !hardStarted) { textBox31.ReadOnly = true; textBox31.Font = new Font(textBox31.Font, FontStyle.Bold); }
            if (values[31] != "0" && !hardStarted) { textBox32.ReadOnly = true; textBox32.Font = new Font(textBox32.Font, FontStyle.Bold); }
            if (values[32] != "0" && !hardStarted) { textBox33.ReadOnly = true; textBox33.Font = new Font(textBox33.Font, FontStyle.Bold); }
            if (values[33] != "0" && !hardStarted) { textBox34.ReadOnly = true; textBox34.Font = new Font(textBox34.Font, FontStyle.Bold); }
            if (values[34] != "0" && !hardStarted) { textBox35.ReadOnly = true; textBox35.Font = new Font(textBox35.Font, FontStyle.Bold); }
            if (values[35] != "0" && !hardStarted) { textBox36.ReadOnly = true; textBox36.Font = new Font(textBox36.Font, FontStyle.Bold); }
            if (values[36] != "0" && !hardStarted) { textBox37.ReadOnly = true; textBox37.Font = new Font(textBox37.Font, FontStyle.Bold); }
            if (values[37] != "0" && !hardStarted) { textBox38.ReadOnly = true; textBox38.Font = new Font(textBox38.Font, FontStyle.Bold); }
            if (values[38] != "0" && !hardStarted) { textBox39.ReadOnly = true; textBox39.Font = new Font(textBox39.Font, FontStyle.Bold); }
            if (values[39] != "0" && !hardStarted) { textBox40.ReadOnly = true; textBox40.Font = new Font(textBox40.Font, FontStyle.Bold); }
            if (values[40] != "0" && !hardStarted) { textBox41.ReadOnly = true; textBox41.Font = new Font(textBox41.Font, FontStyle.Bold); }
            if (values[41] != "0" && !hardStarted) { textBox42.ReadOnly = true; textBox42.Font = new Font(textBox42.Font, FontStyle.Bold); }
            if (values[42] != "0" && !hardStarted) { textBox43.ReadOnly = true; textBox43.Font = new Font(textBox43.Font, FontStyle.Bold); }
            if (values[43] != "0" && !hardStarted) { textBox44.ReadOnly = true; textBox44.Font = new Font(textBox44.Font, FontStyle.Bold); }
            if (values[44] != "0" && !hardStarted) { textBox45.ReadOnly = true; textBox45.Font = new Font(textBox45.Font, FontStyle.Bold); }
            if (values[45] != "0" && !hardStarted) { textBox46.ReadOnly = true; textBox46.Font = new Font(textBox46.Font, FontStyle.Bold); }
            if (values[46] != "0" && !hardStarted) { textBox47.ReadOnly = true; textBox47.Font = new Font(textBox47.Font, FontStyle.Bold); }
            if (values[47] != "0" && !hardStarted) { textBox48.ReadOnly = true; textBox48.Font = new Font(textBox48.Font, FontStyle.Bold); }
            if (values[48] != "0" && !hardStarted) { textBox49.ReadOnly = true; textBox49.Font = new Font(textBox49.Font, FontStyle.Bold); }
            if(hardStarted)
            {
                if (savedInitHardArray[0] != "0") { textBox1.ReadOnly = true; textBox1.Font = new Font(textBox1.Font, FontStyle.Bold); }
                if (savedInitHardArray[1] != "0") { textBox2.ReadOnly = true; textBox2.Font = new Font(textBox2.Font, FontStyle.Bold); }
                if (savedInitHardArray[2] != "0") { textBox3.ReadOnly = true; textBox3.Font = new Font(textBox3.Font, FontStyle.Bold); }
                if (savedInitHardArray[3] != "0") { textBox4.ReadOnly = true; textBox4.Font = new Font(textBox4.Font, FontStyle.Bold); }
                if (savedInitHardArray[4] != "0") { textBox5.ReadOnly = true; textBox5.Font = new Font(textBox5.Font, FontStyle.Bold); }
                if (savedInitHardArray[5] != "0") { textBox6.ReadOnly = true; textBox6.Font = new Font(textBox6.Font, FontStyle.Bold); }
                if (savedInitHardArray[6] != "0") { textBox7.ReadOnly = true; textBox7.Font = new Font(textBox7.Font, FontStyle.Bold); }
                if (savedInitHardArray[7] != "0") { textBox8.ReadOnly = true; textBox8.Font = new Font(textBox8.Font, FontStyle.Bold); }
                if (savedInitHardArray[8] != "0") { textBox9.ReadOnly = true; textBox9.Font = new Font(textBox9.Font, FontStyle.Bold); }
                if (savedInitHardArray[9] != "0") { textBox10.ReadOnly = true; textBox10.Font = new Font(textBox10.Font, FontStyle.Bold); }
                if (savedInitHardArray[10] != "0") { textBox11.ReadOnly = true; textBox11.Font = new Font(textBox11.Font, FontStyle.Bold); }
                if (savedInitHardArray[11] != "0") { textBox12.ReadOnly = true; textBox12.Font = new Font(textBox12.Font, FontStyle.Bold); }
                if (savedInitHardArray[12] != "0") { textBox13.ReadOnly = true; textBox13.Font = new Font(textBox13.Font, FontStyle.Bold); }
                if (savedInitHardArray[13] != "0") { textBox14.ReadOnly = true; textBox14.Font = new Font(textBox14.Font, FontStyle.Bold); }
                if (savedInitHardArray[14] != "0") { textBox15.ReadOnly = true; textBox15.Font = new Font(textBox15.Font, FontStyle.Bold); }
                if (savedInitHardArray[15] != "0") { textBox16.ReadOnly = true; textBox16.Font = new Font(textBox16.Font, FontStyle.Bold); }
                if (savedInitHardArray[16] != "0") { textBox17.ReadOnly = true; textBox17.Font = new Font(textBox17.Font, FontStyle.Bold); }
                if (savedInitHardArray[17] != "0") { textBox18.ReadOnly = true; textBox18.Font = new Font(textBox18.Font, FontStyle.Bold); }
                if (savedInitHardArray[18] != "0") { textBox19.ReadOnly = true; textBox19.Font = new Font(textBox19.Font, FontStyle.Bold); }
                if (savedInitHardArray[19] != "0") { textBox20.ReadOnly = true; textBox20.Font = new Font(textBox20.Font, FontStyle.Bold); }
                if (savedInitHardArray[20] != "0") { textBox21.ReadOnly = true; textBox21.Font = new Font(textBox21.Font, FontStyle.Bold); }
                if (savedInitHardArray[21] != "0") { textBox22.ReadOnly = true; textBox22.Font = new Font(textBox22.Font, FontStyle.Bold); }
                if (savedInitHardArray[22] != "0") { textBox23.ReadOnly = true; textBox23.Font = new Font(textBox23.Font, FontStyle.Bold); }
                if (savedInitHardArray[23] != "0") { textBox24.ReadOnly = true; textBox24.Font = new Font(textBox24.Font, FontStyle.Bold); }
                if (savedInitHardArray[24] != "0") { textBox25.ReadOnly = true; textBox25.Font = new Font(textBox25.Font, FontStyle.Bold); }
                if (savedInitHardArray[25] != "0") { textBox26.ReadOnly = true; textBox26.Font = new Font(textBox26.Font, FontStyle.Bold); }
                if (savedInitHardArray[26] != "0") { textBox27.ReadOnly = true; textBox27.Font = new Font(textBox27.Font, FontStyle.Bold); }
                if (savedInitHardArray[27] != "0") { textBox28.ReadOnly = true; textBox28.Font = new Font(textBox28.Font, FontStyle.Bold); }
                if (savedInitHardArray[28] != "0") { textBox29.ReadOnly = true; textBox29.Font = new Font(textBox29.Font, FontStyle.Bold); }
                if (savedInitHardArray[29] != "0") { textBox30.ReadOnly = true; textBox30.Font = new Font(textBox30.Font, FontStyle.Bold); }
                if (savedInitHardArray[30] != "0") { textBox31.ReadOnly = true; textBox31.Font = new Font(textBox31.Font, FontStyle.Bold); }
                if (savedInitHardArray[31] != "0") { textBox32.ReadOnly = true; textBox32.Font = new Font(textBox32.Font, FontStyle.Bold); }
                if (savedInitHardArray[32] != "0") { textBox33.ReadOnly = true; textBox33.Font = new Font(textBox33.Font, FontStyle.Bold); }
                if (savedInitHardArray[33] != "0") { textBox34.ReadOnly = true; textBox34.Font = new Font(textBox34.Font, FontStyle.Bold); }
                if (savedInitHardArray[34] != "0") { textBox35.ReadOnly = true; textBox35.Font = new Font(textBox35.Font, FontStyle.Bold); }
                if (savedInitHardArray[35] != "0") { textBox36.ReadOnly = true; textBox36.Font = new Font(textBox36.Font, FontStyle.Bold); }
                if (savedInitHardArray[36] != "0") { textBox37.ReadOnly = true; textBox37.Font = new Font(textBox37.Font, FontStyle.Bold); }
                if (savedInitHardArray[37] != "0") { textBox38.ReadOnly = true; textBox38.Font = new Font(textBox38.Font, FontStyle.Bold); }
                if (savedInitHardArray[38] != "0") { textBox39.ReadOnly = true; textBox39.Font = new Font(textBox39.Font, FontStyle.Bold); }
                if (savedInitHardArray[39] != "0") { textBox40.ReadOnly = true; textBox40.Font = new Font(textBox40.Font, FontStyle.Bold); }
                if (savedInitHardArray[40] != "0") { textBox41.ReadOnly = true; textBox41.Font = new Font(textBox41.Font, FontStyle.Bold); }
                if (savedInitHardArray[41] != "0") { textBox42.ReadOnly = true; textBox42.Font = new Font(textBox42.Font, FontStyle.Bold); }
                if (savedInitHardArray[42] != "0") { textBox43.ReadOnly = true; textBox43.Font = new Font(textBox43.Font, FontStyle.Bold); }
                if (savedInitHardArray[43] != "0") { textBox44.ReadOnly = true; textBox44.Font = new Font(textBox44.Font, FontStyle.Bold); }
                if (savedInitHardArray[44] != "0") { textBox45.ReadOnly = true; textBox45.Font = new Font(textBox45.Font, FontStyle.Bold); }
                if (savedInitHardArray[45] != "0") { textBox46.ReadOnly = true; textBox46.Font = new Font(textBox46.Font, FontStyle.Bold); }
                if (savedInitHardArray[46] != "0") { textBox47.ReadOnly = true; textBox47.Font = new Font(textBox47.Font, FontStyle.Bold); }
                if (savedInitHardArray[47] != "0") { textBox48.ReadOnly = true; textBox48.Font = new Font(textBox48.Font, FontStyle.Bold); }
                if (savedInitHardArray[48] != "0") { textBox49.ReadOnly = true; textBox49.Font = new Font(textBox49.Font, FontStyle.Bold); }
            }

            // hard game has been initialized
            hardStarted = true;

            // Calculate the solution row totals.
            totalRowValue1.Text = "" + (int.Parse(values[49]) + int.Parse(values[50]) + int.Parse(values[51]) + int.Parse(values[52]) + int.Parse(values[53]) + int.Parse(values[54]) + int.Parse(values[55]));
            totalRowValue2.Text = "" + (int.Parse(values[56]) + int.Parse(values[57]) + int.Parse(values[58]) + int.Parse(values[59]) + int.Parse(values[60]) + int.Parse(values[61]) + int.Parse(values[62]));
            totalRowValue3.Text = "" + (int.Parse(values[63]) + int.Parse(values[64]) + int.Parse(values[65]) + int.Parse(values[66]) + int.Parse(values[67]) + int.Parse(values[68]) + int.Parse(values[69]));
            totalRowValue4.Text = "" + (int.Parse(values[70]) + int.Parse(values[71]) + int.Parse(values[72]) + int.Parse(values[73]) + int.Parse(values[74]) + int.Parse(values[75]) + int.Parse(values[76]));
            totalRowValue5.Text = "" + (int.Parse(values[77]) + int.Parse(values[78]) + int.Parse(values[79]) + int.Parse(values[80]) + int.Parse(values[81]) + int.Parse(values[82]) + int.Parse(values[83]));
            totalRowValue6.Text = "" + (int.Parse(values[84]) + int.Parse(values[85]) + int.Parse(values[86]) + int.Parse(values[87]) + int.Parse(values[88]) + int.Parse(values[89]) + int.Parse(values[90]));
            totalRowValue7.Text = "" + (int.Parse(values[91]) + int.Parse(values[92]) + int.Parse(values[93]) + int.Parse(values[94]) + int.Parse(values[95]) + int.Parse(values[96]) + int.Parse(values[97]));
            
            // Calculate the solution column totals.
            totalColValue1.Text = "" + (int.Parse(values[49]) + int.Parse(values[56]) + int.Parse(values[63]) + int.Parse(values[70]) + int.Parse(values[77]) + int.Parse(values[84]) + int.Parse(values[91]));
            totalColValue2.Text = "" + (int.Parse(values[50]) + int.Parse(values[57]) + int.Parse(values[64]) + int.Parse(values[71]) + int.Parse(values[78]) + int.Parse(values[85]) + int.Parse(values[92]));
            totalColValue3.Text = "" + (int.Parse(values[51]) + int.Parse(values[58]) + int.Parse(values[65]) + int.Parse(values[72]) + int.Parse(values[79]) + int.Parse(values[86]) + int.Parse(values[93]));
            totalColValue4.Text = "" + (int.Parse(values[52]) + int.Parse(values[59]) + int.Parse(values[66]) + int.Parse(values[73]) + int.Parse(values[80]) + int.Parse(values[87]) + int.Parse(values[94]));
            totalColValue5.Text = "" + (int.Parse(values[53]) + int.Parse(values[60]) + int.Parse(values[67]) + int.Parse(values[74]) + int.Parse(values[81]) + int.Parse(values[88]) + int.Parse(values[95]));
            totalColValue6.Text = "" + (int.Parse(values[54]) + int.Parse(values[61]) + int.Parse(values[68]) + int.Parse(values[75]) + int.Parse(values[82]) + int.Parse(values[89]) + int.Parse(values[96]));
            totalColValue7.Text = "" + (int.Parse(values[55]) + int.Parse(values[62]) + int.Parse(values[69]) + int.Parse(values[76]) + int.Parse(values[83]) + int.Parse(values[90]) + int.Parse(values[97]));
            
            // Calculate the solution diagonal totals.
            totalRowValue0.Text = "" + (int.Parse(values[91]) + int.Parse(values[85]) + int.Parse(values[79]) + int.Parse(values[73]) + int.Parse(values[67]) + int.Parse(values[61]) + int.Parse(values[55]));
            totalRowValue8.Text = "" + (int.Parse(values[49]) + int.Parse(values[57]) + int.Parse(values[65]) + int.Parse(values[73]) + int.Parse(values[81]) + int.Parse(values[89]) + int.Parse(values[97]));

            // Change the visibility.
            derivedRowValue0.Visible = true;
            derivedRowValue1.Visible = true;
            derivedRowValue2.Visible = true;
            derivedRowValue7.Visible = true;
            derivedRowValue6.Visible = true;
            derivedRowValue8.Visible = true;
            totalRowValue0.Visible = true;
            totalRowValue1.Visible = true;
            totalRowValue2.Visible = true;
            totalRowValue6.Visible = true;
            totalRowValue7.Visible = true;
            totalRowValue8.Visible = true;

            derivedColValue1.Visible = true;
            derivedColValue2.Visible = true;
            derivedColValue6.Visible = true;
            derivedColValue7.Visible = true;
            totalColValue1.Visible = true;
            totalColValue2.Visible = true;
            totalColValue6.Visible = true;
            totalColValue7.Visible = true;

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
            textBox13.Visible = true;
            textBox14.Visible = true;
            textBox15.Visible = true;
            textBox16.Visible = true;
            textBox20.Visible = true;
            textBox21.Visible = true;
            textBox22.Visible = true;
            textBox23.Visible = true;
            textBox27.Visible = true;
            textBox28.Visible = true;
            textBox29.Visible = true;
            textBox30.Visible = true;
            textBox34.Visible = true;
            textBox35.Visible = true;
            textBox36.Visible = true;
            textBox37.Visible = true;
            textBox38.Visible = true;
            textBox39.Visible = true;
            textBox40.Visible = true;
            textBox41.Visible = true;
            textBox42.Visible = true;
            textBox43.Visible = true;
            textBox44.Visible = true;
            textBox45.Visible = true;
            textBox46.Visible = true;
            textBox47.Visible = true;
            textBox48.Visible = true;
            textBox49.Visible = true;
        }
        #endregion

        #region sideButtons
        /******************************************************************************
        Function:   hintButton_Click

        Use:        gives the player a solution value to the puzzle game

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void hintButton_Click(object sender, EventArgs e)
        {
            hintCounter++;    // Increment the number of hints used.
            
            // Give the player a solution value for an easy puzzle game.
            if (gameMode == "easy")
            {
                if (textBox17.Text != values[9]) textBox17.Text = values[9];
                else if (textBox18.Text != values[10]) textBox18.Text = values[10];
                else if (textBox19.Text != values[11]) textBox19.Text = values[11];
                else if (textBox24.Text != values[12]) textBox24.Text = values[12];
                else if (textBox25.Text != values[13]) textBox25.Text = values[13];
                else if (textBox26.Text != values[14]) textBox26.Text = values[14];
                else if (textBox31.Text != values[15]) textBox31.Text = values[15];
                else if (textBox32.Text != values[16]) textBox32.Text = values[16];
                else if (textBox33.Text != values[17]) textBox33.Text = values[17];
                else MessageBox.Show("All fields are correct!", Form1.ActiveForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Give the player a solution value for a medium puzzle game.
            else if (gameMode == "medium")
            {
                if (textBox9.Text != values[25]) textBox9.Text = values[25];
                else if (textBox10.Text != values[26]) textBox10.Text = values[26];
                else if (textBox11.Text != values[27]) textBox11.Text = values[27];
                else if (textBox12.Text != values[28]) textBox12.Text = values[28];
                else if (textBox13.Text != values[29]) textBox13.Text = values[29];
                else if (textBox16.Text != values[30]) textBox16.Text = values[30];
                else if (textBox17.Text != values[31]) textBox17.Text = values[31];
                else if (textBox18.Text != values[32]) textBox18.Text = values[32];
                else if (textBox19.Text != values[33]) textBox19.Text = values[33];
                else if (textBox20.Text != values[34]) textBox20.Text = values[34];
                else if (textBox23.Text != values[35]) textBox23.Text = values[35];
                else if (textBox24.Text != values[36]) textBox24.Text = values[36];
                else if (textBox25.Text != values[37]) textBox25.Text = values[37];
                else if (textBox26.Text != values[38]) textBox26.Text = values[38];
                else if (textBox27.Text != values[39]) textBox27.Text = values[39];
                else if (textBox30.Text != values[40]) textBox30.Text = values[40];
                else if (textBox31.Text != values[41]) textBox31.Text = values[41];
                else if (textBox32.Text != values[42]) textBox32.Text = values[42];
                else if (textBox33.Text != values[43]) textBox33.Text = values[43];
                else if (textBox34.Text != values[44]) textBox34.Text = values[44];
                else if (textBox37.Text != values[45]) textBox37.Text = values[45];
                else if (textBox38.Text != values[46]) textBox38.Text = values[46];
                else if (textBox39.Text != values[47]) textBox39.Text = values[47];
                else if (textBox40.Text != values[48]) textBox40.Text = values[48];
                else if (textBox41.Text != values[49]) textBox41.Text = values[49];
                else MessageBox.Show("All fields are correct!", Form1.ActiveForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Give the player a solution value for a hard puzzle game.
            else if (gameMode == "hard")
            {
                if (textBox1.Text != values[49]) textBox1.Text = values[49];
                else if (textBox2.Text != values[50]) textBox2.Text = values[50];
                else if (textBox3.Text != values[51]) textBox3.Text = values[51];
                else if (textBox4.Text != values[52]) textBox4.Text = values[52];
                else if (textBox5.Text != values[53]) textBox5.Text = values[53];
                else if (textBox6.Text != values[54]) textBox6.Text = values[54];
                else if (textBox7.Text != values[55]) textBox7.Text = values[55];
                else if (textBox8.Text != values[56]) textBox8.Text = values[56];
                else if (textBox9.Text != values[57]) textBox9.Text = values[57];
                else if (textBox10.Text != values[58]) textBox10.Text = values[58];
                else if (textBox11.Text != values[59]) textBox11.Text = values[59];
                else if (textBox12.Text != values[60]) textBox12.Text = values[60];
                else if (textBox13.Text != values[61]) textBox13.Text = values[61];
                else if (textBox14.Text != values[62]) textBox14.Text = values[62];
                else if (textBox15.Text != values[63]) textBox15.Text = values[63];
                else if (textBox16.Text != values[64]) textBox16.Text = values[64];
                else if (textBox17.Text != values[65]) textBox17.Text = values[65];
                else if (textBox18.Text != values[66]) textBox18.Text = values[66];
                else if (textBox19.Text != values[67]) textBox19.Text = values[67];
                else if (textBox20.Text != values[68]) textBox20.Text = values[68];
                else if (textBox21.Text != values[69]) textBox21.Text = values[69];
                else if (textBox22.Text != values[70]) textBox22.Text = values[70];
                else if (textBox23.Text != values[71]) textBox23.Text = values[71];
                else if (textBox24.Text != values[72]) textBox24.Text = values[72];
                else if (textBox25.Text != values[73]) textBox25.Text = values[73];
                else if (textBox26.Text != values[74]) textBox26.Text = values[74];
                else if (textBox27.Text != values[75]) textBox27.Text = values[75];
                else if (textBox28.Text != values[76]) textBox28.Text = values[76];
                else if (textBox29.Text != values[77]) textBox29.Text = values[77];
                else if (textBox30.Text != values[78]) textBox30.Text = values[78];
                else if (textBox31.Text != values[79]) textBox31.Text = values[79];
                else if (textBox32.Text != values[80]) textBox32.Text = values[80];
                else if (textBox33.Text != values[81]) textBox33.Text = values[81];
                else if (textBox34.Text != values[82]) textBox34.Text = values[82];
                else if (textBox35.Text != values[83]) textBox35.Text = values[83];
                else if (textBox36.Text != values[84]) textBox36.Text = values[84];
                else if (textBox37.Text != values[85]) textBox37.Text = values[85];
                else if (textBox38.Text != values[86]) textBox38.Text = values[86];
                else if (textBox39.Text != values[87]) textBox39.Text = values[87];
                else if (textBox40.Text != values[88]) textBox40.Text = values[88];
                else if (textBox41.Text != values[89]) textBox41.Text = values[89];
                else if (textBox42.Text != values[90]) textBox42.Text = values[90];
                else if (textBox43.Text != values[91]) textBox43.Text = values[91];
                else if (textBox44.Text != values[92]) textBox44.Text = values[92];
                else if (textBox45.Text != values[93]) textBox45.Text = values[93];
                else if (textBox46.Text != values[94]) textBox46.Text = values[94];
                else if (textBox47.Text != values[95]) textBox47.Text = values[95];
                else if (textBox48.Text != values[96]) textBox48.Text = values[96];
                else if (textBox49.Text != values[97]) textBox49.Text = values[97];
                else MessageBox.Show("All fields are correct!", Form1.ActiveForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // If a puzzle game mode is not selected, then display an error message.
            else
            {
                hintCounter = 0;
                MessageBox.Show("Please start a game first.", Form1.ActiveForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /******************************************************************************
        Function:   checkButton_Click

        Use:        checks the player's answers

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void checkButton_Click(object sender, EventArgs e)
        {
            // Check the player's answers for each row, column and diagonal value for
            // an easy puzzle game.
            if (gameMode == "easy" && checkButton.Text == "Check")
            {
                checkButton.Text = "OK";

                // Check the player's answers for the first row.
                if ((textBox17.Text != values[9] || textBox18.Text != values[10] || textBox19.Text != values[11]) &&
                    (int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox18.Text) + int.Parse("0" + textBox19.Text) != int.Parse(values[9]) + int.Parse(values[10]) + int.Parse(values[11])))
                {
                    textBox17.BackColor = Color.Red;
                    textBox18.BackColor = Color.Red;
                    textBox19.BackColor = Color.Red;
                }

                // Check the player's answers for the second row.
                if ((textBox24.Text != values[12] || textBox25.Text != values[13] || textBox26.Text != values[14]) &&
                    (int.Parse("0" + textBox24.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox26.Text) != int.Parse(values[12]) + int.Parse(values[13]) + int.Parse(values[14])))
                {
                    textBox24.BackColor = Color.Red;
                    textBox25.BackColor = Color.Red;
                    textBox26.BackColor = Color.Red;
                }

                // Check the player's answers for the third row.
                if ((textBox31.Text != values[15] || textBox32.Text != values[16] || textBox33.Text != values[17]) &&
                    (int.Parse("0" + textBox31.Text) + int.Parse("0" + textBox32.Text) + int.Parse("0" + textBox33.Text) != int.Parse(values[15]) + int.Parse(values[16]) + int.Parse(values[17])))
                {
                    textBox31.BackColor = Color.Red;
                    textBox32.BackColor = Color.Red;
                    textBox33.BackColor = Color.Red;
                }

                // Check the player's answers for the first column.
                if ((textBox17.Text != values[9] || textBox24.Text != values[12] || textBox31.Text != values[15]) &&
                    (int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox24.Text) + int.Parse("0" + textBox31.Text) != int.Parse(values[9]) + int.Parse(values[12]) + int.Parse(values[15])))
                {
                    textBox17.BackColor = Color.Red;
                    textBox24.BackColor = Color.Red;
                    textBox31.BackColor = Color.Red;
                }

                // Check the player's answers for the second column.
                if ((textBox18.Text != values[10] || textBox25.Text != values[13] || textBox32.Text != values[16]) &&
                    (int.Parse("0" + textBox18.Text) + int.Parse("0" + textBox24.Text) + int.Parse("0" + textBox32.Text) != int.Parse(values[10]) + int.Parse(values[13]) + int.Parse(values[16])))
                {
                    textBox18.BackColor = Color.Red;
                    textBox25.BackColor = Color.Red;
                    textBox32.BackColor = Color.Red;
                }

                // Check the player's answers for the third column.
                if ((textBox19.Text != values[11] || textBox26.Text != values[14] || textBox33.Text != values[17]) &&
                    (int.Parse("0" + textBox19.Text) + int.Parse("0" + textBox26.Text) + int.Parse("0" + textBox33.Text) != int.Parse(values[11]) + int.Parse(values[14]) + int.Parse(values[17])))
                {
                    textBox19.BackColor = Color.Red;
                    textBox26.BackColor = Color.Red;
                    textBox33.BackColor = Color.Red;
                }

                // Check the player's answers for the first diagonal.
                if ((textBox18.Text != values[9] || textBox25.Text != values[13] || textBox32.Text != values[17]) &&
                    (int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox33.Text) != int.Parse(values[9]) + int.Parse(values[13]) + int.Parse(values[17])))
                {
                    textBox17.BackColor = Color.Red;
                    textBox25.BackColor = Color.Red;
                    textBox33.BackColor = Color.Red;
                }

                // Check the player's answers for the second diagonal.
                if ((textBox19.Text != values[11] || textBox25.Text != values[13] || textBox31.Text != values[15]) &&
                    (int.Parse("0" + textBox31.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox19.Text) != int.Parse(values[11]) + int.Parse(values[13]) + int.Parse(values[15])))
                {
                    textBox31.BackColor = Color.Red;
                    textBox25.BackColor = Color.Red;
                    textBox19.BackColor = Color.Red;
                }
            }

            // Check the player's answers for each row, column and diagonal value for
            // a medium puzzle game.
            else if (gameMode == "medium" && checkButton.Text == "Check")
            {
                checkButton.Text = "OK";

                // Check the player's answers for the first row.
                if ((textBox9.Text != values[25] || textBox10.Text != values[26] || textBox11.Text != values[27] || textBox12.Text != values[28] || textBox13.Text != values[29]) &&
                   ((int.Parse("0" + textBox9.Text) + int.Parse("0" + textBox10.Text) + int.Parse("0" + textBox11.Text) + int.Parse("0" + textBox12.Text) + int.Parse("0" + textBox13.Text)) != (int.Parse(values[25]) + int.Parse(values[26]) + int.Parse(values[27]) + int.Parse(values[28]) + int.Parse(values[29]))))
                {
                    textBox9.BackColor = Color.Red;
                    textBox10.BackColor = Color.Red;
                    textBox11.BackColor = Color.Red;
                    textBox12.BackColor = Color.Red;
                    textBox13.BackColor = Color.Red;
                }

                // Check the player's answers for the second row.
                if ((textBox16.Text != values[30] || textBox17.Text != values[31] || textBox18.Text != values[32] || textBox19.Text != values[33] || textBox20.Text != values[34]) &&
                   ((int.Parse("0" + textBox16.Text) + int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox18.Text) + int.Parse("0" + textBox19.Text) + int.Parse("0" + textBox20.Text)) != (int.Parse(values[30]) + int.Parse(values[31]) + int.Parse(values[32]) + int.Parse(values[33]) + int.Parse(values[34]))))
                {
                    textBox16.BackColor = Color.Red;
                    textBox17.BackColor = Color.Red;
                    textBox18.BackColor = Color.Red;
                    textBox19.BackColor = Color.Red;
                    textBox20.BackColor = Color.Red;
                }

                // Check the player's answers for the third row.
                if ((textBox23.Text != values[35] || textBox24.Text != values[36] || textBox25.Text != values[37] || textBox26.Text != values[38] || textBox27.Text != values[39]) &&
                   ((int.Parse("0" + textBox23.Text) + int.Parse("0" + textBox24.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox26.Text) + int.Parse("0" + textBox27.Text)) != (int.Parse(values[35]) + int.Parse(values[36]) + int.Parse(values[37]) + int.Parse(values[38]) + int.Parse(values[39]))))
                {
                    textBox23.BackColor = Color.Red;
                    textBox24.BackColor = Color.Red;
                    textBox25.BackColor = Color.Red;
                    textBox26.BackColor = Color.Red;
                    textBox27.BackColor = Color.Red;
                }

                // Check the player's answers for the fourth row.
                if ((textBox30.Text != values[40] || textBox31.Text != values[41] || textBox32.Text != values[42] || textBox33.Text != values[43] || textBox34.Text != values[44]) &&
                   ((int.Parse("0" + textBox30.Text) + int.Parse("0" + textBox31.Text) + int.Parse("0" + textBox32.Text) + int.Parse("0" + textBox33.Text) + int.Parse("0" + textBox34.Text)) != (int.Parse(values[40]) + int.Parse(values[41]) + int.Parse(values[42]) + int.Parse(values[43]) + int.Parse(values[45]))))
                {
                    textBox30.BackColor = Color.Red;
                    textBox31.BackColor = Color.Red;
                    textBox32.BackColor = Color.Red;
                    textBox33.BackColor = Color.Red;
                    textBox34.BackColor = Color.Red;
                }

                // Check the player's answers for the fifth row.
                if ((textBox37.Text != values[45] || textBox38.Text != values[46] || textBox39.Text != values[47] || textBox40.Text != values[48] || textBox41.Text != values[49]) &&
                   ((int.Parse("0" + textBox37.Text) + int.Parse("0" + textBox38.Text) + int.Parse("0" + textBox39.Text) + int.Parse("0" + textBox40.Text) + int.Parse("0" + textBox41.Text)) != (int.Parse(values[45]) + int.Parse(values[46]) + int.Parse(values[47]) + int.Parse(values[48]) + int.Parse(values[49]))))
                {
                    textBox37.BackColor = Color.Red;
                    textBox38.BackColor = Color.Red;
                    textBox39.BackColor = Color.Red;
                    textBox40.BackColor = Color.Red;
                    textBox41.BackColor = Color.Red;
                }

                // Check the player's answers for the first column.
                if ((textBox9.Text != values[25] || textBox16.Text != values[30] || textBox23.Text != values[35] || textBox30.Text != values[40] || textBox37.Text != values[45]) &&
                   ((int.Parse("0" + textBox9.Text) + int.Parse("0" + textBox16.Text) + int.Parse("0" + textBox23.Text) + int.Parse("0" + textBox30.Text) + int.Parse("0" + textBox37.Text)) != (int.Parse(values[25]) + int.Parse(values[30]) + int.Parse(values[35]) + int.Parse(values[40]) + int.Parse(values[45]))))
                {
                    textBox9.BackColor = Color.Red;
                    textBox16.BackColor = Color.Red;
                    textBox23.BackColor = Color.Red;
                    textBox30.BackColor = Color.Red;
                    textBox37.BackColor = Color.Red;
                }

                // Check the player's answers for the second column.
                if ((textBox10.Text != values[26] || textBox17.Text != values[31] || textBox24.Text != values[36] || textBox31.Text != values[41] || textBox38.Text != values[46]) &&
                   ((int.Parse("0" + textBox10.Text) + int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox24.Text) + int.Parse("0" + textBox31.Text) + int.Parse("0" + textBox38.Text)) != (int.Parse(values[26]) + int.Parse(values[31]) + int.Parse(values[36]) + int.Parse(values[41]) + int.Parse(values[46]))))
                {
                    textBox10.BackColor = Color.Red;
                    textBox17.BackColor = Color.Red;
                    textBox24.BackColor = Color.Red;
                    textBox31.BackColor = Color.Red;
                    textBox38.BackColor = Color.Red;
                }

                // Check the player's answers for the third column.
                if ((textBox11.Text != values[27] || textBox18.Text != values[32] || textBox25.Text != values[37] || textBox32.Text != values[42] || textBox39.Text != values[47]) &&
                   ((int.Parse("0" + textBox11.Text) + int.Parse("0" + textBox18.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox32.Text) + int.Parse("0" + textBox39.Text)) != (int.Parse(values[27]) + int.Parse(values[32]) + int.Parse(values[37]) + int.Parse(values[42]) + int.Parse(values[47]))))
                {
                    textBox11.BackColor = Color.Red;
                    textBox18.BackColor = Color.Red;
                    textBox25.BackColor = Color.Red;
                    textBox32.BackColor = Color.Red;
                    textBox39.BackColor = Color.Red;
                }

                // Check the player's answers for the fourth column.
                if ((textBox12.Text != values[28] || textBox19.Text != values[33] || textBox26.Text != values[38] || textBox33.Text != values[43] || textBox40.Text != values[48]) &&
                   ((int.Parse("0" + textBox12.Text) + int.Parse("0" + textBox19.Text) + int.Parse("0" + textBox26.Text) + int.Parse("0" + textBox33.Text) + int.Parse("0" + textBox40.Text)) != (int.Parse(values[28]) + int.Parse(values[33]) + int.Parse(values[38]) + int.Parse(values[43]) + int.Parse(values[48]))))
                {
                    textBox12.BackColor = Color.Red;
                    textBox19.BackColor = Color.Red;
                    textBox26.BackColor = Color.Red;
                    textBox33.BackColor = Color.Red;
                    textBox40.BackColor = Color.Red;
                }

                // Check the player's answers for the fifth column.
                if ((textBox13.Text != values[29] || textBox20.Text != values[34] || textBox27.Text != values[39] || textBox34.Text != values[44] || textBox41.Text != values[49]) &&
                   ((int.Parse("0" + textBox13.Text) + int.Parse("0" + textBox20.Text) + int.Parse("0" + textBox27.Text) + int.Parse("0" + textBox34.Text) + int.Parse("0" + textBox41.Text)) != (int.Parse(values[29]) + int.Parse(values[34]) + int.Parse(values[39]) + int.Parse(values[44]) + int.Parse(values[49]))))
                {
                    textBox13.BackColor = Color.Red;
                    textBox20.BackColor = Color.Red;
                    textBox27.BackColor = Color.Red;
                    textBox34.BackColor = Color.Red;
                    textBox41.BackColor = Color.Red;
                }

                // Check the player's answers for the first diagonal.
                if ((textBox37.Text != values[45] || textBox31.Text != values[41] || textBox25.Text != values[37] || textBox19.Text != values[33] || textBox13.Text != values[29]) &&
                   ((int.Parse("0" + textBox37.Text) + int.Parse("0" + textBox31.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox19.Text) + int.Parse("0" + textBox13.Text)) != (int.Parse(values[45]) + int.Parse(values[41]) + int.Parse(values[37]) + int.Parse(values[33]) + int.Parse(values[29]))))
                {
                    textBox37.BackColor = Color.Red;
                    textBox31.BackColor = Color.Red;
                    textBox25.BackColor = Color.Red;
                    textBox19.BackColor = Color.Red;
                    textBox13.BackColor = Color.Red;
                }

                // Check the player's answers for the second diagonal.
                if ((textBox9.Text != values[25] || textBox17.Text != values[31] || textBox25.Text != values[37] || textBox33.Text != values[43] || textBox41.Text != values[49]) &&
                   ((int.Parse("0" + textBox9.Text) + int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox33.Text) + int.Parse("0" + textBox41.Text)) != (int.Parse(values[25]) + int.Parse(values[31]) + int.Parse(values[37]) + int.Parse(values[43]) + int.Parse(values[49]))))
                {
                    textBox9.BackColor = Color.Red;
                    textBox17.BackColor = Color.Red;
                    textBox25.BackColor = Color.Red;
                    textBox33.BackColor = Color.Red;
                    textBox41.BackColor = Color.Red;
                }
            }

            // Check the player's answers for each row, column and diagonal value for
            // a hard puzzle game.
            else if (gameMode == "hard" && checkButton.Text == "Check")
            {
                checkButton.Text = "OK";

                // Check the player's answers for the first row.
                if ((textBox1.Text != values[49] || textBox2.Text != values[50] || textBox3.Text != values[51] || textBox4.Text != values[52] || textBox5.Text != values[53] || textBox6.Text != values[54] || textBox7.Text != values[55]) &&
                   ((int.Parse("0" + textBox1.Text) + int.Parse("0" + textBox2.Text) + int.Parse("0" + textBox3.Text) + int.Parse("0" + textBox4.Text) + int.Parse("0" + textBox5.Text) + int.Parse("0" + textBox6.Text) + int.Parse("0" + textBox7.Text)) != (int.Parse(values[49]) + int.Parse(values[50]) + int.Parse(values[51]) + int.Parse(values[52]) + int.Parse(values[53]) + int.Parse(values[54]) + int.Parse(values[55]))))
                {
                    textBox1.BackColor = Color.Red;
                    textBox2.BackColor = Color.Red;
                    textBox3.BackColor = Color.Red;
                    textBox4.BackColor = Color.Red;
                    textBox5.BackColor = Color.Red;
                    textBox6.BackColor = Color.Red;
                    textBox7.BackColor = Color.Red;
                }

                // Check the player's answers for the second row.
                if ((textBox8.Text != values[56] || textBox9.Text != values[57] || textBox10.Text != values[58] || textBox11.Text != values[59] || textBox12.Text != values[60] || textBox13.Text != values[61] || textBox14.Text != values[62]) &&
                   ((int.Parse("0" + textBox8.Text) + int.Parse("0" + textBox9.Text) + int.Parse("0" + textBox10.Text) + int.Parse("0" + textBox11.Text) + int.Parse("0" + textBox12.Text) + int.Parse("0" + textBox13.Text) + int.Parse("0" + textBox14.Text)) != (int.Parse(values[56]) + int.Parse(values[57]) + int.Parse(values[58]) + int.Parse(values[59]) + int.Parse(values[60]) + int.Parse(values[61]) + int.Parse(values[62]))))
                {
                    textBox8.BackColor = Color.Red;
                    textBox9.BackColor = Color.Red;
                    textBox10.BackColor = Color.Red;
                    textBox11.BackColor = Color.Red;
                    textBox12.BackColor = Color.Red;
                    textBox13.BackColor = Color.Red;
                    textBox14.BackColor = Color.Red;
                }

                // Check the player's answers for the third row.
                if ((textBox15.Text != values[63] || textBox16.Text != values[64] || textBox17.Text != values[65] || textBox18.Text != values[66] || textBox19.Text != values[67] || textBox20.Text != values[68] || textBox21.Text != values[69]) &&
                   ((int.Parse("0" + textBox15.Text) + int.Parse("0" + textBox16.Text) + int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox18.Text) + int.Parse("0" + textBox19.Text) + int.Parse("0" + textBox20.Text) + int.Parse("0" + textBox21.Text)) != (int.Parse(values[63]) + int.Parse(values[64]) + int.Parse(values[65]) + int.Parse(values[66]) + int.Parse(values[67]) + int.Parse(values[68]) + int.Parse(values[69]))))
                {
                    textBox15.BackColor = Color.Red;
                    textBox16.BackColor = Color.Red;
                    textBox17.BackColor = Color.Red;
                    textBox18.BackColor = Color.Red;
                    textBox19.BackColor = Color.Red;
                    textBox20.BackColor = Color.Red;
                    textBox21.BackColor = Color.Red;
                }

                // Check the player's answers for the fourth row.
                if ((textBox22.Text != values[70] || textBox23.Text != values[71] || textBox24.Text != values[72] || textBox25.Text != values[73] || textBox26.Text != values[74] || textBox27.Text != values[75] || textBox28.Text != values[76]) &&
                   ((int.Parse("0" + textBox22.Text) + int.Parse("0" + textBox23.Text) + int.Parse("0" + textBox24.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox26.Text) + int.Parse("0" + textBox27.Text) + int.Parse("0" + textBox28.Text)) != (int.Parse(values[70]) + int.Parse(values[71]) + int.Parse(values[72]) + int.Parse(values[73]) + int.Parse(values[74]) + int.Parse(values[75]) + int.Parse(values[76]))))
                {
                    textBox22.BackColor = Color.Red;
                    textBox23.BackColor = Color.Red;
                    textBox24.BackColor = Color.Red;
                    textBox25.BackColor = Color.Red;
                    textBox26.BackColor = Color.Red;
                    textBox27.BackColor = Color.Red;
                    textBox28.BackColor = Color.Red;
                }

                // Check the player's answers for the fifth row.
                if ((textBox29.Text != values[77] || textBox30.Text != values[78] || textBox31.Text != values[79] || textBox32.Text != values[80] || textBox33.Text != values[81] || textBox34.Text != values[82] || textBox35.Text != values[83]) &&
                   ((int.Parse("0" + textBox29.Text) + int.Parse("0" + textBox30.Text) + int.Parse("0" + textBox31.Text) + int.Parse("0" + textBox32.Text) + int.Parse("0" + textBox33.Text) + int.Parse("0" + textBox34.Text) + int.Parse("0" + textBox35.Text)) != (int.Parse(values[77]) + int.Parse(values[78]) + int.Parse(values[79]) + int.Parse(values[80]) + int.Parse(values[81]) + int.Parse(values[82]) + int.Parse(values[83]))))
                {
                    textBox29.BackColor = Color.Red;
                    textBox30.BackColor = Color.Red;
                    textBox31.BackColor = Color.Red;
                    textBox32.BackColor = Color.Red;
                    textBox22.BackColor = Color.Red;
                    textBox34.BackColor = Color.Red;
                    textBox35.BackColor = Color.Red;
                }

                // Check the player's answers for the sixth row.
                if ((textBox36.Text != values[84] || textBox37.Text != values[85] || textBox38.Text != values[86] || textBox39.Text != values[87] || textBox40.Text != values[88] || textBox41.Text != values[89] || textBox42.Text != values[90]) &&
                   ((int.Parse("0" + textBox36.Text) + int.Parse("0" + textBox37.Text) + int.Parse("0" + textBox38.Text) + int.Parse("0" + textBox39.Text) + int.Parse("0" + textBox40.Text) + int.Parse("0" + textBox41.Text) + int.Parse("0" + textBox42.Text)) != (int.Parse(values[84]) + int.Parse(values[85]) + int.Parse(values[86]) + int.Parse(values[87]) + int.Parse(values[88]) + int.Parse(values[89]) + int.Parse(values[90]))))
                {
                    textBox36.BackColor = Color.Red;
                    textBox37.BackColor = Color.Red;
                    textBox38.BackColor = Color.Red;
                    textBox39.BackColor = Color.Red;
                    textBox40.BackColor = Color.Red;
                    textBox41.BackColor = Color.Red;
                    textBox42.BackColor = Color.Red;
                }

                // Check the player's answers for the seventh row.
                if ((textBox43.Text != values[91] || textBox44.Text != values[92] || textBox45.Text != values[93] || textBox46.Text != values[94] || textBox47.Text != values[95] || textBox48.Text != values[96] || textBox49.Text != values[97]) &&
                   ((int.Parse("0" + textBox43.Text) + int.Parse("0" + textBox44.Text) + int.Parse("0" + textBox45.Text) + int.Parse("0" + textBox46.Text) + int.Parse("0" + textBox47.Text) + int.Parse("0" + textBox48.Text) + int.Parse("0" + textBox49.Text)) != (int.Parse(values[91]) + int.Parse(values[92]) + int.Parse(values[93]) + int.Parse(values[94]) + int.Parse(values[95]) + int.Parse(values[96]) + int.Parse(values[97]))))
                {
                    textBox43.BackColor = Color.Red;
                    textBox44.BackColor = Color.Red;
                    textBox45.BackColor = Color.Red;
                    textBox46.BackColor = Color.Red;
                    textBox47.BackColor = Color.Red;
                    textBox48.BackColor = Color.Red;
                    textBox49.BackColor = Color.Red;
                }

                // Check the player's answers for the first column.
                if ((textBox1.Text != values[49] || textBox8.Text != values[56] || textBox15.Text != values[63] || textBox22.Text != values[70] || textBox29.Text != values[77] || textBox36.Text != values[84] || textBox43.Text != values[91]) &&
                   ((int.Parse("0" + textBox1.Text) + int.Parse("0" + textBox8.Text) + int.Parse("0" + textBox15.Text) + int.Parse("0" + textBox22.Text) + int.Parse("0" + textBox29.Text) + int.Parse("0" + textBox36.Text) + int.Parse("0" + textBox43.Text)) != (int.Parse(values[49]) + int.Parse(values[56]) + int.Parse(values[63]) + int.Parse(values[70]) + int.Parse(values[77]) + int.Parse(values[84]) + int.Parse(values[91]))))
                {
                    textBox1.BackColor = Color.Red;
                    textBox8.BackColor = Color.Red;
                    textBox15.BackColor = Color.Red;
                    textBox22.BackColor = Color.Red;
                    textBox29.BackColor = Color.Red;
                    textBox36.BackColor = Color.Red;
                    textBox43.BackColor = Color.Red;
                }

                // Check the player's answers for the second column.
                if ((textBox2.Text != values[50] || textBox9.Text != values[57] || textBox16.Text != values[64] || textBox23.Text != values[71] || textBox30.Text != values[78] || textBox37.Text != values[85] || textBox44.Text != values[92]) &&
                   ((int.Parse("0" + textBox2.Text) + int.Parse("0" + textBox10.Text) + int.Parse("0" + textBox16.Text) + int.Parse("0" + textBox23.Text) + int.Parse("0" + textBox30.Text) + int.Parse("0" + textBox37.Text) + int.Parse("0" + textBox44.Text)) != (int.Parse(values[50]) + int.Parse(values[57]) + int.Parse(values[64]) + int.Parse(values[71]) + int.Parse(values[78]) + int.Parse(values[85]) + int.Parse(values[92]))))
                {
                    textBox2.BackColor = Color.Red;
                    textBox9.BackColor = Color.Red;
                    textBox16.BackColor = Color.Red;
                    textBox23.BackColor = Color.Red;
                    textBox30.BackColor = Color.Red;
                    textBox37.BackColor = Color.Red;
                    textBox44.BackColor = Color.Red;
                }

                // Check the player's answers for the third column.
                if ((textBox3.Text != values[51] || textBox10.Text != values[58] || textBox17.Text != values[65] || textBox24.Text != values[72] || textBox31.Text != values[79] || textBox38.Text != values[86] || textBox45.Text != values[93]) &&
                   ((int.Parse("0" + textBox3.Text) + int.Parse("0" + textBox10.Text) + int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox24.Text) + int.Parse("0" + textBox31.Text) + int.Parse("0" + textBox38.Text) + int.Parse("0" + textBox45.Text)) != (int.Parse(values[51]) + int.Parse(values[58]) + int.Parse(values[65]) + int.Parse(values[72]) + int.Parse(values[79]) + int.Parse(values[86]) + int.Parse(values[93]))))
                {
                    textBox3.BackColor = Color.Red;
                    textBox10.BackColor = Color.Red;
                    textBox17.BackColor = Color.Red;
                    textBox24.BackColor = Color.Red;
                    textBox31.BackColor = Color.Red;
                    textBox38.BackColor = Color.Red;
                    textBox45.BackColor = Color.Red;
                }

                // Check the player's answers for the fourth column.
                if ((textBox4.Text != values[52] || textBox11.Text != values[59] || textBox18.Text != values[66] || textBox25.Text != values[73] || textBox32.Text != values[80] || textBox39.Text != values[87] || textBox46.Text != values[94]) &&
                   ((int.Parse("0" + textBox4.Text) + int.Parse("0" + textBox11.Text) + int.Parse("0" + textBox18.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox32.Text) + int.Parse("0" + textBox39.Text) + int.Parse("0" + textBox46.Text)) != (int.Parse(values[52]) + int.Parse(values[59]) + int.Parse(values[66]) + int.Parse(values[73]) + int.Parse(values[80]) + int.Parse(values[87]) + int.Parse(values[94]))))
                {
                    textBox4.BackColor = Color.Red;
                    textBox11.BackColor = Color.Red;
                    textBox18.BackColor = Color.Red;
                    textBox25.BackColor = Color.Red;
                    textBox32.BackColor = Color.Red;
                    textBox39.BackColor = Color.Red;
                    textBox46.BackColor = Color.Red;
                }

                // Check the player's answers for the fifth column.
                if ((textBox5.Text != values[53] || textBox12.Text != values[60] || textBox19.Text != values[67] || textBox26.Text != values[74] || textBox33.Text != values[81] || textBox40.Text != values[88] || textBox47.Text != values[95]) &&
                   ((int.Parse("0" + textBox5.Text) + int.Parse("0" + textBox12.Text) + int.Parse("0" + textBox19.Text) + int.Parse("0" + textBox26.Text) + int.Parse("0" + textBox33.Text) + int.Parse("0" + textBox40.Text) + int.Parse("0" + textBox47.Text)) != (int.Parse(values[53]) + int.Parse(values[60]) + int.Parse(values[67]) + int.Parse(values[74]) + int.Parse(values[81]) + int.Parse(values[88]) + int.Parse(values[95]))))
                {
                    textBox5.BackColor = Color.Red;
                    textBox12.BackColor = Color.Red;
                    textBox19.BackColor = Color.Red;
                    textBox26.BackColor = Color.Red;
                    textBox33.BackColor = Color.Red;
                    textBox40.BackColor = Color.Red;
                    textBox47.BackColor = Color.Red;
                }

                // Check the player's answers for the sixth column.
                if ((textBox6.Text != values[54] || textBox13.Text != values[61] || textBox20.Text != values[68] || textBox27.Text != values[75] || textBox34.Text != values[82] || textBox41.Text != values[89] || textBox48.Text != values[96]) &&
                   ((int.Parse("0" + textBox6.Text) + int.Parse("0" + textBox13.Text) + int.Parse("0" + textBox20.Text) + int.Parse("0" + textBox27.Text) + int.Parse("0" + textBox34.Text) + int.Parse("0" + textBox41.Text) + int.Parse("0" + textBox48.Text)) != (int.Parse(values[54]) + int.Parse(values[61]) + int.Parse(values[68]) + int.Parse(values[75]) + int.Parse(values[82]) + int.Parse(values[89]) + int.Parse(values[96]))))
                {
                    textBox6.BackColor = Color.Red;
                    textBox13.BackColor = Color.Red;
                    textBox20.BackColor = Color.Red;
                    textBox27.BackColor = Color.Red;
                    textBox34.BackColor = Color.Red;
                    textBox41.BackColor = Color.Red;
                    textBox48.BackColor = Color.Red;
                }

                // Check the player's answers for the seventh column.
                if ((textBox7.Text != values[55] || textBox14.Text != values[62] || textBox21.Text != values[69] || textBox28.Text != values[76] || textBox35.Text != values[83] || textBox42.Text != values[90] || textBox49.Text != values[97]) &&
                   ((int.Parse("0" + textBox7.Text) + int.Parse("0" + textBox14.Text) + int.Parse("0" + textBox21.Text) + int.Parse("0" + textBox28.Text) + int.Parse("0" + textBox35.Text) + int.Parse("0" + textBox42.Text) + int.Parse("0" + textBox49.Text)) != (int.Parse(values[55]) + int.Parse(values[62]) + int.Parse(values[69]) + int.Parse(values[76]) + int.Parse(values[83]) + int.Parse(values[90]) + int.Parse(values[97]))))
                {
                    textBox7.BackColor = Color.Red;
                    textBox14.BackColor = Color.Red;
                    textBox21.BackColor = Color.Red;
                    textBox28.BackColor = Color.Red;
                    textBox35.BackColor = Color.Red;
                    textBox42.BackColor = Color.Red;
                    textBox49.BackColor = Color.Red;
                }

                // Check the player's answers for the first diagonal.
                if ((textBox43.Text != values[91] || textBox37.Text != values[85] || textBox31.Text != values[79] || textBox25.Text != values[73] || textBox19.Text != values[67] || textBox13.Text != values[61] || textBox7.Text != values[55]) &&
                   ((int.Parse("0" + textBox43.Text) + int.Parse("0" + textBox37.Text) + int.Parse("0" + textBox31.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox19.Text) + int.Parse("0" + textBox13.Text) + int.Parse("0" + textBox7.Text)) != (int.Parse(values[91]) + int.Parse(values[85]) + int.Parse(values[79]) + int.Parse(values[73]) + int.Parse(values[67]) + int.Parse(values[61]) + int.Parse(values[55]))))
                {
                    textBox43.BackColor = Color.Red;
                    textBox37.BackColor = Color.Red;
                    textBox31.BackColor = Color.Red;
                    textBox25.BackColor = Color.Red;
                    textBox19.BackColor = Color.Red;
                    textBox13.BackColor = Color.Red;
                    textBox7.BackColor = Color.Red;
                }

                // Check the player's answers for the second diagonal.
                if ((textBox1.Text != values[49] || textBox9.Text != values[57] || textBox17.Text != values[65] || textBox25.Text != values[73] || textBox33.Text != values[81] || textBox41.Text != values[89] || textBox49.Text != values[97]) &&
                   ((int.Parse("0" + textBox1.Text) + int.Parse("0" + textBox9.Text) + int.Parse("0" + textBox17.Text) + int.Parse("0" + textBox25.Text) + int.Parse("0" + textBox33.Text) + int.Parse("0" + textBox41.Text) + int.Parse("0" + textBox49.Text)) != (int.Parse(values[49]) + int.Parse(values[57]) + int.Parse(values[65]) + int.Parse(values[73]) + int.Parse(values[81]) + int.Parse(values[89]) + int.Parse(values[97]))))
                {
                    textBox1.BackColor = Color.Red;
                    textBox9.BackColor = Color.Red;
                    textBox17.BackColor = Color.Red;
                    textBox25.BackColor = Color.Red;
                    textBox33.BackColor = Color.Red;
                    textBox41.BackColor = Color.Red;
                    textBox49.BackColor = Color.Red;
                }
            }

            // If a puzzle game mode is not selected, then reset the TextBoxes
            // BackColor and display an error message.
            else
            {
                checkButton.Text = "Check";
                textBox1.BackColor = Color.White;
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
                textBox6.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox8.BackColor = Color.White;
                textBox9.BackColor = Color.White;
                textBox10.BackColor = Color.White;
                textBox11.BackColor = Color.White;
                textBox12.BackColor = Color.White;
                textBox13.BackColor = Color.White;
                textBox14.BackColor = Color.White;
                textBox15.BackColor = Color.White;
                textBox16.BackColor = Color.White;
                textBox17.BackColor = Color.White;
                textBox18.BackColor = Color.White;
                textBox19.BackColor = Color.White;
                textBox20.BackColor = Color.White;
                textBox21.BackColor = Color.White;
                textBox22.BackColor = Color.White;
                textBox23.BackColor = Color.White;
                textBox24.BackColor = Color.White;
                textBox25.BackColor = Color.White;
                textBox26.BackColor = Color.White;
                textBox27.BackColor = Color.White;
                textBox28.BackColor = Color.White;
                textBox29.BackColor = Color.White;
                textBox30.BackColor = Color.White;
                textBox31.BackColor = Color.White;
                textBox32.BackColor = Color.White;
                textBox33.BackColor = Color.White;
                textBox34.BackColor = Color.White;
                textBox35.BackColor = Color.White;
                textBox36.BackColor = Color.White;
                textBox37.BackColor = Color.White;
                textBox38.BackColor = Color.White;
                textBox39.BackColor = Color.White;
                textBox40.BackColor = Color.White;
                textBox41.BackColor = Color.White;
                textBox42.BackColor = Color.White;
                textBox43.BackColor = Color.White;
                textBox44.BackColor = Color.White;
                textBox45.BackColor = Color.White;
                textBox46.BackColor = Color.White;
                textBox47.BackColor = Color.White;
                textBox48.BackColor = Color.White;
                textBox49.BackColor = Color.White;
                if (gameMode == "") MessageBox.Show("Please start a game first.", Form1.ActiveForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /******************************************************************************
        Function:   pauseButton_Click

        Use:        pauses the puzzle game

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (gameMode != "")
            {
                // Stop the Stopwatches.
                if (pauseButton.Text == "Pause")
                {
                    pauseButton.Text = "Play";
                    groupBox5.Visible = true;
                    easyButton.Enabled = false;
                    mediumButton.Enabled = false;
                    hardButton.Enabled = false;
                    if (gameMode == "easy") swatch.Stop();
                    if (gameMode == "medium") swatch2.Stop();
                    if (gameMode == "hard") swatch3.Stop();
                }

                // Resume the Stopwatches.
                else
                {
                    pauseButton.Text = "Pause";
                    groupBox5.Visible = false;
                    easyButton.Enabled = true;
                    mediumButton.Enabled = true;
                    hardButton.Enabled = true;
                    if (gameMode == "easy") swatch.Start();
                    if (gameMode == "medium") swatch2.Start();
                    if (gameMode == "hard") swatch3.Start();
                }
            }

            // If a puzzle game mode is not selected, then display an error message.
            else MessageBox.Show("Please start a game first.", Form1.ActiveForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /******************************************************************************
        Function:   resetButton_Click

        Use:        calls the Reset method to reset the puzzle game

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void resetButton_Click(object sender, EventArgs e)
        {
            Reset("");
        }
        #endregion

        #region textBox_TextChanged Events
        /******************************************************************************
        Function:   textBox1_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox2_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox3_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox4_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox5_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox6_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }


        /******************************************************************************
        Function:   textBox7_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox8_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox9_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox10_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox11_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox12_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox13_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox14_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox15_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox16_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox17_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox18_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox19_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox20_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox21_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox22_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox23_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox24_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox25_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox26_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox27_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox28_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox29_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox30_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox31_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox32_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox33_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox34_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox34_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox35_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox36_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox36_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox37_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox37_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox38_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox38_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox39_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox39_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox40_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox41_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox41_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox42_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox42_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox43_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox44_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox44_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox45_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox45_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox46_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox46_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox47_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox47_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox48_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox48_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }

        /******************************************************************************
        Function:   textBox49_TextChanged

        Use:        calls the textBoxChanged method to processes the changes to the
                    TextBox

        Arguments:  1) an object named sender that represents the sender of the event
                    2) an EventArgs named args that represents the event data

        Returns:    nothing
        ******************************************************************************/
        private void textBox49_TextChanged(object sender, EventArgs e)
        {
            textBoxChanged();
        }
        #endregion

        /******************************************************************************
       Function:   button1_Click (Help button)

       Use:        shows a help message

       Arguments:  1) an object named sender that represents the sender of the event
                   2) an EventArgs named args that represents the event data

       Returns:    nothing
       ******************************************************************************/
        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Hello!\n\nTo play this game, just keep these few things in mind:\n\n1. Fields must add up by row, column, and diagonally, and be in the correct order.\n\n2. You can track your progress using the 'check' button and the totals displayed at the ends of each row/column/diagonal.\n\n3. If you need help, you may use a hint, but keep in mind: the number of hints you used will be displayed at the end of the game.\n\n4. Current progress will be saved if you switch to another difficulty. To reset a game, use the reset button, or start a new game in that difficulty. Starting a new game will retrieve initial values from a random pre-made game file.\n\n5. Games are timed, so if you want to take a break, use the pause button!\n\n6. Enjoy!";
            MessageBox.Show(message, Form1.ActiveForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}