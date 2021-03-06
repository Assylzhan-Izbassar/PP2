﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1
{
    public partial class Form1 : Form
    {
        Brain Brain;

        public Form1()
        {
            InitializeComponent();
            Brain = new Brain(new MyDelegate(DisplaySender));
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Brain.Process(button.Text);
        }

        public void DisplaySender(string text)
        {
            textBox1.Text = text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
