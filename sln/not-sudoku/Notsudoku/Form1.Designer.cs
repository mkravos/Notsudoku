/******************************************************************************
Program:     Notsudoku
File:        Form1.Designer.cs

Purpose:     This file defines the Form items.
******************************************************************************/

namespace Notsudoku
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.hardButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.textBox34 = new System.Windows.Forms.TextBox();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.textBox41 = new System.Windows.Forms.TextBox();
            this.textBox48 = new System.Windows.Forms.TextBox();
            this.textBox42 = new System.Windows.Forms.TextBox();
            this.textBox49 = new System.Windows.Forms.TextBox();
            this.textBox36 = new System.Windows.Forms.TextBox();
            this.textBox37 = new System.Windows.Forms.TextBox();
            this.textBox43 = new System.Windows.Forms.TextBox();
            this.textBox38 = new System.Windows.Forms.TextBox();
            this.textBox44 = new System.Windows.Forms.TextBox();
            this.textBox39 = new System.Windows.Forms.TextBox();
            this.textBox47 = new System.Windows.Forms.TextBox();
            this.textBox45 = new System.Windows.Forms.TextBox();
            this.textBox40 = new System.Windows.Forms.TextBox();
            this.textBox46 = new System.Windows.Forms.TextBox();
            this.easyButton = new System.Windows.Forms.Button();
            this.hintButton = new System.Windows.Forms.Button();
            this.mediumButton = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.totalRowValue8 = new System.Windows.Forms.Label();
            this.derivedRowValue8 = new System.Windows.Forms.Label();
            this.totalRowValue7 = new System.Windows.Forms.Label();
            this.derivedRowValue7 = new System.Windows.Forms.Label();
            this.totalRowValue6 = new System.Windows.Forms.Label();
            this.derivedRowValue6 = new System.Windows.Forms.Label();
            this.totalRowValue5 = new System.Windows.Forms.Label();
            this.derivedRowValue5 = new System.Windows.Forms.Label();
            this.totalRowValue4 = new System.Windows.Forms.Label();
            this.derivedRowValue4 = new System.Windows.Forms.Label();
            this.totalRowValue3 = new System.Windows.Forms.Label();
            this.derivedRowValue3 = new System.Windows.Forms.Label();
            this.totalRowValue2 = new System.Windows.Forms.Label();
            this.derivedRowValue2 = new System.Windows.Forms.Label();
            this.totalRowValue1 = new System.Windows.Forms.Label();
            this.derivedRowValue1 = new System.Windows.Forms.Label();
            this.totalRowValue0 = new System.Windows.Forms.Label();
            this.derivedRowValue0 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.totalColValue7 = new System.Windows.Forms.Label();
            this.derivedColValue7 = new System.Windows.Forms.Label();
            this.totalColValue6 = new System.Windows.Forms.Label();
            this.derivedColValue6 = new System.Windows.Forms.Label();
            this.totalColValue5 = new System.Windows.Forms.Label();
            this.derivedColValue5 = new System.Windows.Forms.Label();
            this.totalColValue4 = new System.Windows.Forms.Label();
            this.derivedColValue4 = new System.Windows.Forms.Label();
            this.totalColValue2 = new System.Windows.Forms.Label();
            this.derivedColValue2 = new System.Windows.Forms.Label();
            this.totalColValue3 = new System.Windows.Forms.Label();
            this.derivedColValue3 = new System.Windows.Forms.Label();
            this.totalColValue1 = new System.Windows.Forms.Label();
            this.derivedColValue1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.timerDisplay = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(17, 67);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(31, 20);
            this.textBox1.TabIndex = 34;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // hardButton
            // 
            this.hardButton.Location = new System.Drawing.Point(202, 8);
            this.hardButton.Margin = new System.Windows.Forms.Padding(2);
            this.hardButton.Name = "hardButton";
            this.hardButton.Size = new System.Drawing.Size(50, 27);
            this.hardButton.TabIndex = 85;
            this.hardButton.Text = "Hard";
            this.hardButton.UseVisualStyleBackColor = true;
            this.hardButton.Click += new System.EventHandler(this.hardButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(51, 67);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(31, 20);
            this.textBox2.TabIndex = 37;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.Visible = false;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(85, 67);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(31, 20);
            this.textBox3.TabIndex = 40;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.Visible = false;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(119, 67);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(31, 20);
            this.textBox4.TabIndex = 43;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.Visible = false;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(153, 67);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(31, 20);
            this.textBox5.TabIndex = 44;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox5.Visible = false;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(187, 67);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(31, 20);
            this.textBox6.TabIndex = 59;
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox6.Visible = false;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(221, 67);
            this.textBox7.Margin = new System.Windows.Forms.Padding(2);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(31, 20);
            this.textBox7.TabIndex = 60;
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox7.Visible = false;
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(17, 109);
            this.textBox15.Margin = new System.Windows.Forms.Padding(2);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(31, 20);
            this.textBox15.TabIndex = 35;
            this.textBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox15.Visible = false;
            this.textBox15.TextChanged += new System.EventHandler(this.textBox15_TextChanged);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(17, 88);
            this.textBox8.Margin = new System.Windows.Forms.Padding(2);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(31, 20);
            this.textBox8.TabIndex = 36;
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox8.Visible = false;
            this.textBox8.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(51, 88);
            this.textBox9.Margin = new System.Windows.Forms.Padding(2);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(31, 20);
            this.textBox9.TabIndex = 38;
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox9.Visible = false;
            this.textBox9.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(51, 109);
            this.textBox16.Margin = new System.Windows.Forms.Padding(2);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(31, 20);
            this.textBox16.TabIndex = 39;
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox16.Visible = false;
            this.textBox16.TextChanged += new System.EventHandler(this.textBox16_TextChanged);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(85, 88);
            this.textBox10.Margin = new System.Windows.Forms.Padding(2);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(31, 20);
            this.textBox10.TabIndex = 41;
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox10.Visible = false;
            this.textBox10.TextChanged += new System.EventHandler(this.textBox10_TextChanged);
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(85, 109);
            this.textBox17.Margin = new System.Windows.Forms.Padding(2);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(31, 20);
            this.textBox17.TabIndex = 42;
            this.textBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox17.TextChanged += new System.EventHandler(this.textBox17_TextChanged);
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(17, 130);
            this.textBox22.Margin = new System.Windows.Forms.Padding(2);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(31, 20);
            this.textBox22.TabIndex = 45;
            this.textBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox22.Visible = false;
            this.textBox22.TextChanged += new System.EventHandler(this.textBox22_TextChanged);
            // 
            // textBox29
            // 
            this.textBox29.Location = new System.Drawing.Point(17, 151);
            this.textBox29.Margin = new System.Windows.Forms.Padding(2);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(31, 20);
            this.textBox29.TabIndex = 46;
            this.textBox29.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox29.Visible = false;
            this.textBox29.TextChanged += new System.EventHandler(this.textBox29_TextChanged);
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(51, 130);
            this.textBox23.Margin = new System.Windows.Forms.Padding(2);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(31, 20);
            this.textBox23.TabIndex = 47;
            this.textBox23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox23.Visible = false;
            this.textBox23.TextChanged += new System.EventHandler(this.textBox23_TextChanged);
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(85, 130);
            this.textBox24.Margin = new System.Windows.Forms.Padding(2);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(31, 20);
            this.textBox24.TabIndex = 48;
            this.textBox24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox24.TextChanged += new System.EventHandler(this.textBox24_TextChanged);
            // 
            // textBox30
            // 
            this.textBox30.Location = new System.Drawing.Point(51, 151);
            this.textBox30.Margin = new System.Windows.Forms.Padding(2);
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new System.Drawing.Size(31, 20);
            this.textBox30.TabIndex = 49;
            this.textBox30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox30.Visible = false;
            this.textBox30.TextChanged += new System.EventHandler(this.textBox30_TextChanged);
            // 
            // textBox31
            // 
            this.textBox31.Location = new System.Drawing.Point(85, 151);
            this.textBox31.Margin = new System.Windows.Forms.Padding(2);
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new System.Drawing.Size(31, 20);
            this.textBox31.TabIndex = 50;
            this.textBox31.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox31.TextChanged += new System.EventHandler(this.textBox31_TextChanged);
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(119, 88);
            this.textBox11.Margin = new System.Windows.Forms.Padding(2);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(31, 20);
            this.textBox11.TabIndex = 51;
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox11.Visible = false;
            this.textBox11.TextChanged += new System.EventHandler(this.textBox11_TextChanged);
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(153, 88);
            this.textBox12.Margin = new System.Windows.Forms.Padding(2);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(31, 20);
            this.textBox12.TabIndex = 52;
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox12.Visible = false;
            this.textBox12.TextChanged += new System.EventHandler(this.textBox12_TextChanged);
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(119, 109);
            this.textBox18.Margin = new System.Windows.Forms.Padding(2);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(31, 20);
            this.textBox18.TabIndex = 53;
            this.textBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox18.TextChanged += new System.EventHandler(this.textBox18_TextChanged);
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(153, 109);
            this.textBox19.Margin = new System.Windows.Forms.Padding(2);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(31, 20);
            this.textBox19.TabIndex = 54;
            this.textBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox19.TextChanged += new System.EventHandler(this.textBox19_TextChanged);
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(119, 130);
            this.textBox25.Margin = new System.Windows.Forms.Padding(2);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(31, 20);
            this.textBox25.TabIndex = 55;
            this.textBox25.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox25.TextChanged += new System.EventHandler(this.textBox25_TextChanged);
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(153, 130);
            this.textBox26.Margin = new System.Windows.Forms.Padding(2);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(31, 20);
            this.textBox26.TabIndex = 56;
            this.textBox26.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox26.TextChanged += new System.EventHandler(this.textBox26_TextChanged);
            // 
            // textBox32
            // 
            this.textBox32.Location = new System.Drawing.Point(119, 151);
            this.textBox32.Margin = new System.Windows.Forms.Padding(2);
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(31, 20);
            this.textBox32.TabIndex = 57;
            this.textBox32.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox32.TextChanged += new System.EventHandler(this.textBox32_TextChanged);
            // 
            // textBox33
            // 
            this.textBox33.Location = new System.Drawing.Point(153, 151);
            this.textBox33.Margin = new System.Windows.Forms.Padding(2);
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new System.Drawing.Size(31, 20);
            this.textBox33.TabIndex = 58;
            this.textBox33.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox33.TextChanged += new System.EventHandler(this.textBox33_TextChanged);
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(187, 88);
            this.textBox13.Margin = new System.Windows.Forms.Padding(2);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(31, 20);
            this.textBox13.TabIndex = 61;
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox13.Visible = false;
            this.textBox13.TextChanged += new System.EventHandler(this.textBox13_TextChanged);
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(221, 88);
            this.textBox14.Margin = new System.Windows.Forms.Padding(2);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(31, 20);
            this.textBox14.TabIndex = 62;
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox14.Visible = false;
            this.textBox14.TextChanged += new System.EventHandler(this.textBox14_TextChanged);
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(187, 109);
            this.textBox20.Margin = new System.Windows.Forms.Padding(2);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(31, 20);
            this.textBox20.TabIndex = 63;
            this.textBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox20.Visible = false;
            this.textBox20.TextChanged += new System.EventHandler(this.textBox20_TextChanged);
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(221, 109);
            this.textBox21.Margin = new System.Windows.Forms.Padding(2);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(31, 20);
            this.textBox21.TabIndex = 64;
            this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox21.Visible = false;
            this.textBox21.TextChanged += new System.EventHandler(this.textBox21_TextChanged);
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(187, 130);
            this.textBox27.Margin = new System.Windows.Forms.Padding(2);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(31, 20);
            this.textBox27.TabIndex = 65;
            this.textBox27.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox27.Visible = false;
            this.textBox27.TextChanged += new System.EventHandler(this.textBox27_TextChanged);
            // 
            // textBox28
            // 
            this.textBox28.Location = new System.Drawing.Point(221, 130);
            this.textBox28.Margin = new System.Windows.Forms.Padding(2);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(31, 20);
            this.textBox28.TabIndex = 66;
            this.textBox28.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox28.Visible = false;
            this.textBox28.TextChanged += new System.EventHandler(this.textBox28_TextChanged);
            // 
            // textBox34
            // 
            this.textBox34.Location = new System.Drawing.Point(187, 151);
            this.textBox34.Margin = new System.Windows.Forms.Padding(2);
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new System.Drawing.Size(31, 20);
            this.textBox34.TabIndex = 67;
            this.textBox34.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox34.Visible = false;
            this.textBox34.TextChanged += new System.EventHandler(this.textBox34_TextChanged);
            // 
            // textBox35
            // 
            this.textBox35.Location = new System.Drawing.Point(221, 151);
            this.textBox35.Margin = new System.Windows.Forms.Padding(2);
            this.textBox35.Name = "textBox35";
            this.textBox35.Size = new System.Drawing.Size(31, 20);
            this.textBox35.TabIndex = 68;
            this.textBox35.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox35.Visible = false;
            this.textBox35.TextChanged += new System.EventHandler(this.textBox35_TextChanged);
            // 
            // textBox41
            // 
            this.textBox41.Location = new System.Drawing.Point(187, 172);
            this.textBox41.Margin = new System.Windows.Forms.Padding(2);
            this.textBox41.Name = "textBox41";
            this.textBox41.Size = new System.Drawing.Size(31, 20);
            this.textBox41.TabIndex = 69;
            this.textBox41.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox41.Visible = false;
            this.textBox41.TextChanged += new System.EventHandler(this.textBox41_TextChanged);
            // 
            // textBox48
            // 
            this.textBox48.Location = new System.Drawing.Point(187, 193);
            this.textBox48.Margin = new System.Windows.Forms.Padding(2);
            this.textBox48.Name = "textBox48";
            this.textBox48.Size = new System.Drawing.Size(31, 20);
            this.textBox48.TabIndex = 70;
            this.textBox48.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox48.Visible = false;
            this.textBox48.TextChanged += new System.EventHandler(this.textBox48_TextChanged);
            // 
            // textBox42
            // 
            this.textBox42.Location = new System.Drawing.Point(221, 172);
            this.textBox42.Margin = new System.Windows.Forms.Padding(2);
            this.textBox42.Name = "textBox42";
            this.textBox42.Size = new System.Drawing.Size(31, 20);
            this.textBox42.TabIndex = 71;
            this.textBox42.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox42.Visible = false;
            this.textBox42.TextChanged += new System.EventHandler(this.textBox42_TextChanged);
            // 
            // textBox49
            // 
            this.textBox49.Location = new System.Drawing.Point(221, 193);
            this.textBox49.Margin = new System.Windows.Forms.Padding(2);
            this.textBox49.Name = "textBox49";
            this.textBox49.Size = new System.Drawing.Size(31, 20);
            this.textBox49.TabIndex = 72;
            this.textBox49.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox49.Visible = false;
            this.textBox49.TextChanged += new System.EventHandler(this.textBox49_TextChanged);
            // 
            // textBox36
            // 
            this.textBox36.Location = new System.Drawing.Point(17, 172);
            this.textBox36.Margin = new System.Windows.Forms.Padding(2);
            this.textBox36.Name = "textBox36";
            this.textBox36.Size = new System.Drawing.Size(31, 20);
            this.textBox36.TabIndex = 73;
            this.textBox36.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox36.Visible = false;
            this.textBox36.TextChanged += new System.EventHandler(this.textBox36_TextChanged);
            // 
            // textBox37
            // 
            this.textBox37.Location = new System.Drawing.Point(51, 172);
            this.textBox37.Margin = new System.Windows.Forms.Padding(2);
            this.textBox37.Name = "textBox37";
            this.textBox37.Size = new System.Drawing.Size(31, 20);
            this.textBox37.TabIndex = 74;
            this.textBox37.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox37.Visible = false;
            this.textBox37.TextChanged += new System.EventHandler(this.textBox37_TextChanged);
            // 
            // textBox43
            // 
            this.textBox43.Location = new System.Drawing.Point(17, 193);
            this.textBox43.Margin = new System.Windows.Forms.Padding(2);
            this.textBox43.Name = "textBox43";
            this.textBox43.Size = new System.Drawing.Size(31, 20);
            this.textBox43.TabIndex = 75;
            this.textBox43.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox43.Visible = false;
            this.textBox43.TextChanged += new System.EventHandler(this.textBox43_TextChanged);
            // 
            // textBox38
            // 
            this.textBox38.Location = new System.Drawing.Point(85, 172);
            this.textBox38.Margin = new System.Windows.Forms.Padding(2);
            this.textBox38.Name = "textBox38";
            this.textBox38.Size = new System.Drawing.Size(31, 20);
            this.textBox38.TabIndex = 76;
            this.textBox38.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox38.Visible = false;
            this.textBox38.TextChanged += new System.EventHandler(this.textBox38_TextChanged);
            // 
            // textBox44
            // 
            this.textBox44.Location = new System.Drawing.Point(51, 193);
            this.textBox44.Margin = new System.Windows.Forms.Padding(2);
            this.textBox44.Name = "textBox44";
            this.textBox44.Size = new System.Drawing.Size(31, 20);
            this.textBox44.TabIndex = 77;
            this.textBox44.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox44.Visible = false;
            this.textBox44.TextChanged += new System.EventHandler(this.textBox44_TextChanged);
            // 
            // textBox39
            // 
            this.textBox39.Location = new System.Drawing.Point(119, 172);
            this.textBox39.Margin = new System.Windows.Forms.Padding(2);
            this.textBox39.Name = "textBox39";
            this.textBox39.Size = new System.Drawing.Size(31, 20);
            this.textBox39.TabIndex = 78;
            this.textBox39.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox39.Visible = false;
            this.textBox39.TextChanged += new System.EventHandler(this.textBox39_TextChanged);
            // 
            // textBox47
            // 
            this.textBox47.Location = new System.Drawing.Point(153, 193);
            this.textBox47.Margin = new System.Windows.Forms.Padding(2);
            this.textBox47.Name = "textBox47";
            this.textBox47.Size = new System.Drawing.Size(31, 20);
            this.textBox47.TabIndex = 79;
            this.textBox47.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox47.Visible = false;
            this.textBox47.TextChanged += new System.EventHandler(this.textBox47_TextChanged);
            // 
            // textBox45
            // 
            this.textBox45.Location = new System.Drawing.Point(85, 193);
            this.textBox45.Margin = new System.Windows.Forms.Padding(2);
            this.textBox45.Name = "textBox45";
            this.textBox45.Size = new System.Drawing.Size(31, 20);
            this.textBox45.TabIndex = 80;
            this.textBox45.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox45.Visible = false;
            this.textBox45.TextChanged += new System.EventHandler(this.textBox45_TextChanged);
            // 
            // textBox40
            // 
            this.textBox40.Location = new System.Drawing.Point(153, 172);
            this.textBox40.Margin = new System.Windows.Forms.Padding(2);
            this.textBox40.Name = "textBox40";
            this.textBox40.Size = new System.Drawing.Size(31, 20);
            this.textBox40.TabIndex = 81;
            this.textBox40.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox40.Visible = false;
            this.textBox40.TextChanged += new System.EventHandler(this.textBox40_TextChanged);
            // 
            // textBox46
            // 
            this.textBox46.Location = new System.Drawing.Point(119, 193);
            this.textBox46.Margin = new System.Windows.Forms.Padding(2);
            this.textBox46.Name = "textBox46";
            this.textBox46.Size = new System.Drawing.Size(31, 20);
            this.textBox46.TabIndex = 82;
            this.textBox46.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox46.Visible = false;
            this.textBox46.TextChanged += new System.EventHandler(this.textBox46_TextChanged);
            // 
            // easyButton
            // 
            this.easyButton.Location = new System.Drawing.Point(85, 8);
            this.easyButton.Margin = new System.Windows.Forms.Padding(2);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(50, 27);
            this.easyButton.TabIndex = 83;
            this.easyButton.Text = "Easy";
            this.easyButton.UseVisualStyleBackColor = true;
            this.easyButton.Click += new System.EventHandler(this.easyButton_Click);
            // 
            // hintButton
            // 
            this.hintButton.Location = new System.Drawing.Point(317, 70);
            this.hintButton.Margin = new System.Windows.Forms.Padding(2);
            this.hintButton.Name = "hintButton";
            this.hintButton.Size = new System.Drawing.Size(50, 21);
            this.hintButton.TabIndex = 86;
            this.hintButton.Text = "Hint";
            this.hintButton.UseVisualStyleBackColor = true;
            this.hintButton.Click += new System.EventHandler(this.hintButton_Click);
            // 
            // mediumButton
            // 
            this.mediumButton.Location = new System.Drawing.Point(139, 8);
            this.mediumButton.Margin = new System.Windows.Forms.Padding(2);
            this.mediumButton.Name = "mediumButton";
            this.mediumButton.Size = new System.Drawing.Size(59, 27);
            this.mediumButton.TabIndex = 84;
            this.mediumButton.Text = "Medium";
            this.mediumButton.UseVisualStyleBackColor = true;
            this.mediumButton.Click += new System.EventHandler(this.mediumButton_Click);
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(317, 95);
            this.checkButton.Margin = new System.Windows.Forms.Padding(2);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(50, 21);
            this.checkButton.TabIndex = 87;
            this.checkButton.Text = "Check";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 193);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.totalRowValue8);
            this.groupBox2.Controls.Add(this.derivedRowValue8);
            this.groupBox2.Controls.Add(this.totalRowValue7);
            this.groupBox2.Controls.Add(this.derivedRowValue7);
            this.groupBox2.Controls.Add(this.totalRowValue6);
            this.groupBox2.Controls.Add(this.derivedRowValue6);
            this.groupBox2.Controls.Add(this.totalRowValue5);
            this.groupBox2.Controls.Add(this.derivedRowValue5);
            this.groupBox2.Controls.Add(this.totalRowValue4);
            this.groupBox2.Controls.Add(this.derivedRowValue4);
            this.groupBox2.Controls.Add(this.totalRowValue3);
            this.groupBox2.Controls.Add(this.derivedRowValue3);
            this.groupBox2.Controls.Add(this.totalRowValue2);
            this.groupBox2.Controls.Add(this.derivedRowValue2);
            this.groupBox2.Controls.Add(this.totalRowValue1);
            this.groupBox2.Controls.Add(this.derivedRowValue1);
            this.groupBox2.Controls.Add(this.totalRowValue0);
            this.groupBox2.Controls.Add(this.derivedRowValue0);
            this.groupBox2.Location = new System.Drawing.Point(260, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(52, 193);
            this.groupBox2.TabIndex = 89;
            this.groupBox2.TabStop = false;
            // 
            // totalRowValue8
            // 
            this.totalRowValue8.AutoSize = true;
            this.totalRowValue8.Location = new System.Drawing.Point(28, 175);
            this.totalRowValue8.Name = "totalRowValue8";
            this.totalRowValue8.Size = new System.Drawing.Size(19, 13);
            this.totalRowValue8.TabIndex = 108;
            this.totalRowValue8.Text = "00";
            this.totalRowValue8.Visible = false;
            // 
            // derivedRowValue8
            // 
            this.derivedRowValue8.AutoSize = true;
            this.derivedRowValue8.ForeColor = System.Drawing.Color.Green;
            this.derivedRowValue8.Location = new System.Drawing.Point(5, 175);
            this.derivedRowValue8.Name = "derivedRowValue8";
            this.derivedRowValue8.Size = new System.Drawing.Size(19, 13);
            this.derivedRowValue8.TabIndex = 107;
            this.derivedRowValue8.Text = "00";
            this.derivedRowValue8.Visible = false;
            // 
            // totalRowValue7
            // 
            this.totalRowValue7.AutoSize = true;
            this.totalRowValue7.Location = new System.Drawing.Point(28, 156);
            this.totalRowValue7.Name = "totalRowValue7";
            this.totalRowValue7.Size = new System.Drawing.Size(19, 13);
            this.totalRowValue7.TabIndex = 106;
            this.totalRowValue7.Text = "00";
            this.totalRowValue7.Visible = false;
            // 
            // derivedRowValue7
            // 
            this.derivedRowValue7.AutoSize = true;
            this.derivedRowValue7.ForeColor = System.Drawing.Color.Green;
            this.derivedRowValue7.Location = new System.Drawing.Point(5, 156);
            this.derivedRowValue7.Name = "derivedRowValue7";
            this.derivedRowValue7.Size = new System.Drawing.Size(19, 13);
            this.derivedRowValue7.TabIndex = 105;
            this.derivedRowValue7.Text = "00";
            this.derivedRowValue7.Visible = false;
            // 
            // totalRowValue6
            // 
            this.totalRowValue6.AutoSize = true;
            this.totalRowValue6.Location = new System.Drawing.Point(28, 136);
            this.totalRowValue6.Name = "totalRowValue6";
            this.totalRowValue6.Size = new System.Drawing.Size(19, 13);
            this.totalRowValue6.TabIndex = 104;
            this.totalRowValue6.Text = "00";
            // 
            // derivedRowValue6
            // 
            this.derivedRowValue6.AutoSize = true;
            this.derivedRowValue6.ForeColor = System.Drawing.Color.Green;
            this.derivedRowValue6.Location = new System.Drawing.Point(5, 136);
            this.derivedRowValue6.Name = "derivedRowValue6";
            this.derivedRowValue6.Size = new System.Drawing.Size(19, 13);
            this.derivedRowValue6.TabIndex = 103;
            this.derivedRowValue6.Text = "00";
            // 
            // totalRowValue5
            // 
            this.totalRowValue5.AutoSize = true;
            this.totalRowValue5.Location = new System.Drawing.Point(28, 115);
            this.totalRowValue5.Name = "totalRowValue5";
            this.totalRowValue5.Size = new System.Drawing.Size(19, 13);
            this.totalRowValue5.TabIndex = 102;
            this.totalRowValue5.Text = "00";
            // 
            // derivedRowValue5
            // 
            this.derivedRowValue5.AutoSize = true;
            this.derivedRowValue5.ForeColor = System.Drawing.Color.Green;
            this.derivedRowValue5.Location = new System.Drawing.Point(5, 115);
            this.derivedRowValue5.Name = "derivedRowValue5";
            this.derivedRowValue5.Size = new System.Drawing.Size(19, 13);
            this.derivedRowValue5.TabIndex = 101;
            this.derivedRowValue5.Text = "00";
            // 
            // totalRowValue4
            // 
            this.totalRowValue4.AutoSize = true;
            this.totalRowValue4.Location = new System.Drawing.Point(28, 94);
            this.totalRowValue4.Name = "totalRowValue4";
            this.totalRowValue4.Size = new System.Drawing.Size(19, 13);
            this.totalRowValue4.TabIndex = 100;
            this.totalRowValue4.Text = "00";
            // 
            // derivedRowValue4
            // 
            this.derivedRowValue4.AutoSize = true;
            this.derivedRowValue4.ForeColor = System.Drawing.Color.Green;
            this.derivedRowValue4.Location = new System.Drawing.Point(5, 94);
            this.derivedRowValue4.Name = "derivedRowValue4";
            this.derivedRowValue4.Size = new System.Drawing.Size(19, 13);
            this.derivedRowValue4.TabIndex = 99;
            this.derivedRowValue4.Text = "00";
            // 
            // totalRowValue3
            // 
            this.totalRowValue3.AutoSize = true;
            this.totalRowValue3.Location = new System.Drawing.Point(28, 73);
            this.totalRowValue3.Name = "totalRowValue3";
            this.totalRowValue3.Size = new System.Drawing.Size(19, 13);
            this.totalRowValue3.TabIndex = 98;
            this.totalRowValue3.Text = "00";
            // 
            // derivedRowValue3
            // 
            this.derivedRowValue3.AutoSize = true;
            this.derivedRowValue3.ForeColor = System.Drawing.Color.Green;
            this.derivedRowValue3.Location = new System.Drawing.Point(5, 73);
            this.derivedRowValue3.Name = "derivedRowValue3";
            this.derivedRowValue3.Size = new System.Drawing.Size(19, 13);
            this.derivedRowValue3.TabIndex = 97;
            this.derivedRowValue3.Text = "00";
            // 
            // totalRowValue2
            // 
            this.totalRowValue2.AutoSize = true;
            this.totalRowValue2.Location = new System.Drawing.Point(28, 52);
            this.totalRowValue2.Name = "totalRowValue2";
            this.totalRowValue2.Size = new System.Drawing.Size(19, 13);
            this.totalRowValue2.TabIndex = 96;
            this.totalRowValue2.Text = "00";
            // 
            // derivedRowValue2
            // 
            this.derivedRowValue2.AutoSize = true;
            this.derivedRowValue2.ForeColor = System.Drawing.Color.Green;
            this.derivedRowValue2.Location = new System.Drawing.Point(5, 52);
            this.derivedRowValue2.Name = "derivedRowValue2";
            this.derivedRowValue2.Size = new System.Drawing.Size(19, 13);
            this.derivedRowValue2.TabIndex = 95;
            this.derivedRowValue2.Text = "00";
            // 
            // totalRowValue1
            // 
            this.totalRowValue1.AutoSize = true;
            this.totalRowValue1.Location = new System.Drawing.Point(28, 31);
            this.totalRowValue1.Name = "totalRowValue1";
            this.totalRowValue1.Size = new System.Drawing.Size(19, 13);
            this.totalRowValue1.TabIndex = 94;
            this.totalRowValue1.Text = "00";
            this.totalRowValue1.Visible = false;
            // 
            // derivedRowValue1
            // 
            this.derivedRowValue1.AutoSize = true;
            this.derivedRowValue1.ForeColor = System.Drawing.Color.Green;
            this.derivedRowValue1.Location = new System.Drawing.Point(5, 31);
            this.derivedRowValue1.Name = "derivedRowValue1";
            this.derivedRowValue1.Size = new System.Drawing.Size(19, 13);
            this.derivedRowValue1.TabIndex = 93;
            this.derivedRowValue1.Text = "00";
            this.derivedRowValue1.Visible = false;
            // 
            // totalRowValue0
            // 
            this.totalRowValue0.AutoSize = true;
            this.totalRowValue0.Location = new System.Drawing.Point(28, 10);
            this.totalRowValue0.Name = "totalRowValue0";
            this.totalRowValue0.Size = new System.Drawing.Size(19, 13);
            this.totalRowValue0.TabIndex = 92;
            this.totalRowValue0.Text = "00";
            this.totalRowValue0.Visible = false;
            // 
            // derivedRowValue0
            // 
            this.derivedRowValue0.AutoSize = true;
            this.derivedRowValue0.ForeColor = System.Drawing.Color.Green;
            this.derivedRowValue0.Location = new System.Drawing.Point(5, 10);
            this.derivedRowValue0.Name = "derivedRowValue0";
            this.derivedRowValue0.Size = new System.Drawing.Size(19, 13);
            this.derivedRowValue0.TabIndex = 91;
            this.derivedRowValue0.Text = "00";
            this.derivedRowValue0.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.totalColValue7);
            this.groupBox3.Controls.Add(this.derivedColValue7);
            this.groupBox3.Controls.Add(this.totalColValue6);
            this.groupBox3.Controls.Add(this.derivedColValue6);
            this.groupBox3.Controls.Add(this.totalColValue5);
            this.groupBox3.Controls.Add(this.derivedColValue5);
            this.groupBox3.Controls.Add(this.totalColValue4);
            this.groupBox3.Controls.Add(this.derivedColValue4);
            this.groupBox3.Controls.Add(this.totalColValue2);
            this.groupBox3.Controls.Add(this.derivedColValue2);
            this.groupBox3.Controls.Add(this.totalColValue3);
            this.groupBox3.Controls.Add(this.derivedColValue3);
            this.groupBox3.Controls.Add(this.totalColValue1);
            this.groupBox3.Controls.Add(this.derivedColValue1);
            this.groupBox3.Location = new System.Drawing.Point(12, 228);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(246, 52);
            this.groupBox3.TabIndex = 90;
            this.groupBox3.TabStop = false;
            // 
            // totalColValue7
            // 
            this.totalColValue7.AutoSize = true;
            this.totalColValue7.Location = new System.Drawing.Point(214, 32);
            this.totalColValue7.Name = "totalColValue7";
            this.totalColValue7.Size = new System.Drawing.Size(19, 13);
            this.totalColValue7.TabIndex = 118;
            this.totalColValue7.Text = "00";
            this.totalColValue7.Visible = false;
            // 
            // derivedColValue7
            // 
            this.derivedColValue7.AutoSize = true;
            this.derivedColValue7.ForeColor = System.Drawing.Color.Green;
            this.derivedColValue7.Location = new System.Drawing.Point(214, 12);
            this.derivedColValue7.Name = "derivedColValue7";
            this.derivedColValue7.Size = new System.Drawing.Size(19, 13);
            this.derivedColValue7.TabIndex = 117;
            this.derivedColValue7.Text = "00";
            this.derivedColValue7.Visible = false;
            // 
            // totalColValue6
            // 
            this.totalColValue6.AutoSize = true;
            this.totalColValue6.Location = new System.Drawing.Point(180, 32);
            this.totalColValue6.Name = "totalColValue6";
            this.totalColValue6.Size = new System.Drawing.Size(19, 13);
            this.totalColValue6.TabIndex = 116;
            this.totalColValue6.Text = "00";
            this.totalColValue6.Visible = false;
            // 
            // derivedColValue6
            // 
            this.derivedColValue6.AutoSize = true;
            this.derivedColValue6.ForeColor = System.Drawing.Color.Green;
            this.derivedColValue6.Location = new System.Drawing.Point(180, 12);
            this.derivedColValue6.Name = "derivedColValue6";
            this.derivedColValue6.Size = new System.Drawing.Size(19, 13);
            this.derivedColValue6.TabIndex = 115;
            this.derivedColValue6.Text = "00";
            this.derivedColValue6.Visible = false;
            // 
            // totalColValue5
            // 
            this.totalColValue5.AutoSize = true;
            this.totalColValue5.Location = new System.Drawing.Point(146, 32);
            this.totalColValue5.Name = "totalColValue5";
            this.totalColValue5.Size = new System.Drawing.Size(19, 13);
            this.totalColValue5.TabIndex = 114;
            this.totalColValue5.Text = "00";
            // 
            // derivedColValue5
            // 
            this.derivedColValue5.AutoSize = true;
            this.derivedColValue5.ForeColor = System.Drawing.Color.Green;
            this.derivedColValue5.Location = new System.Drawing.Point(146, 12);
            this.derivedColValue5.Name = "derivedColValue5";
            this.derivedColValue5.Size = new System.Drawing.Size(19, 13);
            this.derivedColValue5.TabIndex = 113;
            this.derivedColValue5.Text = "00";
            // 
            // totalColValue4
            // 
            this.totalColValue4.AutoSize = true;
            this.totalColValue4.Location = new System.Drawing.Point(112, 32);
            this.totalColValue4.Name = "totalColValue4";
            this.totalColValue4.Size = new System.Drawing.Size(19, 13);
            this.totalColValue4.TabIndex = 112;
            this.totalColValue4.Text = "00";
            // 
            // derivedColValue4
            // 
            this.derivedColValue4.AutoSize = true;
            this.derivedColValue4.ForeColor = System.Drawing.Color.Green;
            this.derivedColValue4.Location = new System.Drawing.Point(112, 12);
            this.derivedColValue4.Name = "derivedColValue4";
            this.derivedColValue4.Size = new System.Drawing.Size(19, 13);
            this.derivedColValue4.TabIndex = 111;
            this.derivedColValue4.Text = "00";
            // 
            // totalColValue2
            // 
            this.totalColValue2.AutoSize = true;
            this.totalColValue2.Location = new System.Drawing.Point(44, 32);
            this.totalColValue2.Name = "totalColValue2";
            this.totalColValue2.Size = new System.Drawing.Size(19, 13);
            this.totalColValue2.TabIndex = 110;
            this.totalColValue2.Text = "00";
            this.totalColValue2.Visible = false;
            // 
            // derivedColValue2
            // 
            this.derivedColValue2.AutoSize = true;
            this.derivedColValue2.ForeColor = System.Drawing.Color.Green;
            this.derivedColValue2.Location = new System.Drawing.Point(44, 12);
            this.derivedColValue2.Name = "derivedColValue2";
            this.derivedColValue2.Size = new System.Drawing.Size(19, 13);
            this.derivedColValue2.TabIndex = 109;
            this.derivedColValue2.Text = "00";
            this.derivedColValue2.Visible = false;
            // 
            // totalColValue3
            // 
            this.totalColValue3.AutoSize = true;
            this.totalColValue3.Location = new System.Drawing.Point(78, 32);
            this.totalColValue3.Name = "totalColValue3";
            this.totalColValue3.Size = new System.Drawing.Size(19, 13);
            this.totalColValue3.TabIndex = 108;
            this.totalColValue3.Text = "00";
            // 
            // derivedColValue3
            // 
            this.derivedColValue3.AutoSize = true;
            this.derivedColValue3.ForeColor = System.Drawing.Color.Green;
            this.derivedColValue3.Location = new System.Drawing.Point(78, 12);
            this.derivedColValue3.Name = "derivedColValue3";
            this.derivedColValue3.Size = new System.Drawing.Size(19, 13);
            this.derivedColValue3.TabIndex = 107;
            this.derivedColValue3.Text = "00";
            // 
            // totalColValue1
            // 
            this.totalColValue1.AutoSize = true;
            this.totalColValue1.Location = new System.Drawing.Point(10, 32);
            this.totalColValue1.Name = "totalColValue1";
            this.totalColValue1.Size = new System.Drawing.Size(19, 13);
            this.totalColValue1.TabIndex = 106;
            this.totalColValue1.Text = "00";
            this.totalColValue1.Visible = false;
            // 
            // derivedColValue1
            // 
            this.derivedColValue1.AutoSize = true;
            this.derivedColValue1.ForeColor = System.Drawing.Color.Green;
            this.derivedColValue1.Location = new System.Drawing.Point(10, 12);
            this.derivedColValue1.Name = "derivedColValue1";
            this.derivedColValue1.Size = new System.Drawing.Size(19, 13);
            this.derivedColValue1.TabIndex = 105;
            this.derivedColValue1.Text = "00";
            this.derivedColValue1.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.timerDisplay);
            this.groupBox4.Location = new System.Drawing.Point(260, 228);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(52, 52);
            this.groupBox4.TabIndex = 90;
            this.groupBox4.TabStop = false;
            // 
            // timerDisplay
            // 
            this.timerDisplay.AutoSize = true;
            this.timerDisplay.Location = new System.Drawing.Point(5, 22);
            this.timerDisplay.Name = "timerDisplay";
            this.timerDisplay.Size = new System.Drawing.Size(43, 13);
            this.timerDisplay.TabIndex = 95;
            this.timerDisplay.Text = "0:00:00";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(317, 45);
            this.resetButton.Margin = new System.Windows.Forms.Padding(2);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(50, 21);
            this.resetButton.TabIndex = 93;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(317, 8);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(2);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(50, 27);
            this.pauseButton.TabIndex = 92;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 94;
            this.label1.Text = "New Game:";
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(12, 40);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(354, 240);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Game Paused";
            this.groupBox5.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 27);
            this.button1.TabIndex = 95;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 290);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.hardButton);
            this.Controls.Add(this.mediumButton);
            this.Controls.Add(this.easyButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.hintButton);
            this.Controls.Add(this.textBox46);
            this.Controls.Add(this.textBox40);
            this.Controls.Add(this.textBox45);
            this.Controls.Add(this.textBox47);
            this.Controls.Add(this.textBox39);
            this.Controls.Add(this.textBox44);
            this.Controls.Add(this.textBox38);
            this.Controls.Add(this.textBox43);
            this.Controls.Add(this.textBox37);
            this.Controls.Add(this.textBox36);
            this.Controls.Add(this.textBox49);
            this.Controls.Add(this.textBox42);
            this.Controls.Add(this.textBox48);
            this.Controls.Add(this.textBox41);
            this.Controls.Add(this.textBox35);
            this.Controls.Add(this.textBox34);
            this.Controls.Add(this.textBox28);
            this.Controls.Add(this.textBox27);
            this.Controls.Add(this.textBox21);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox33);
            this.Controls.Add(this.textBox32);
            this.Controls.Add(this.textBox26);
            this.Controls.Add(this.textBox25);
            this.Controls.Add(this.textBox19);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox31);
            this.Controls.Add(this.textBox30);
            this.Controls.Add(this.textBox24);
            this.Controls.Add(this.textBox23);
            this.Controls.Add(this.textBox29);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Notsudoku";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button hardButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox textBox29;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.TextBox textBox30;
        private System.Windows.Forms.TextBox textBox31;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.TextBox textBox32;
        private System.Windows.Forms.TextBox textBox33;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox27;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.TextBox textBox34;
        private System.Windows.Forms.TextBox textBox35;
        private System.Windows.Forms.TextBox textBox41;
        private System.Windows.Forms.TextBox textBox48;
        private System.Windows.Forms.TextBox textBox42;
        private System.Windows.Forms.TextBox textBox49;
        private System.Windows.Forms.TextBox textBox36;
        private System.Windows.Forms.TextBox textBox37;
        private System.Windows.Forms.TextBox textBox43;
        private System.Windows.Forms.TextBox textBox38;
        private System.Windows.Forms.TextBox textBox44;
        private System.Windows.Forms.TextBox textBox39;
        private System.Windows.Forms.TextBox textBox47;
        private System.Windows.Forms.TextBox textBox45;
        private System.Windows.Forms.TextBox textBox40;
        private System.Windows.Forms.TextBox textBox46;
        private System.Windows.Forms.Button easyButton;
        private System.Windows.Forms.Button hintButton;
        private System.Windows.Forms.Button mediumButton;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label derivedRowValue0;
        private System.Windows.Forms.Label totalRowValue0;
        private System.Windows.Forms.Label totalRowValue6;
        private System.Windows.Forms.Label derivedRowValue6;
        private System.Windows.Forms.Label totalRowValue5;
        private System.Windows.Forms.Label derivedRowValue5;
        private System.Windows.Forms.Label totalRowValue4;
        private System.Windows.Forms.Label derivedRowValue4;
        private System.Windows.Forms.Label totalRowValue3;
        private System.Windows.Forms.Label derivedRowValue3;
        private System.Windows.Forms.Label totalRowValue2;
        private System.Windows.Forms.Label derivedRowValue2;
        private System.Windows.Forms.Label totalRowValue1;
        private System.Windows.Forms.Label derivedRowValue1;
        private System.Windows.Forms.Label totalColValue7;
        private System.Windows.Forms.Label derivedColValue7;
        private System.Windows.Forms.Label totalColValue6;
        private System.Windows.Forms.Label derivedColValue6;
        private System.Windows.Forms.Label totalColValue5;
        private System.Windows.Forms.Label derivedColValue5;
        private System.Windows.Forms.Label totalColValue4;
        private System.Windows.Forms.Label derivedColValue4;
        private System.Windows.Forms.Label totalColValue2;
        private System.Windows.Forms.Label derivedColValue2;
        private System.Windows.Forms.Label totalColValue3;
        private System.Windows.Forms.Label derivedColValue3;
        private System.Windows.Forms.Label totalColValue1;
        private System.Windows.Forms.Label derivedColValue1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label timerDisplay;
        private System.Windows.Forms.Label totalRowValue8;
        private System.Windows.Forms.Label derivedRowValue8;
        private System.Windows.Forms.Label totalRowValue7;
        private System.Windows.Forms.Label derivedRowValue7;
        private System.Windows.Forms.Button button1;
    }
}