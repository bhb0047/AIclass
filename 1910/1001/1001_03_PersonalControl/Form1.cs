﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1001_03_CustomControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            label1.Text = fIleFinderUserControl1.FileName;
        }

        private void PeriodSearch1_EndDateChanged(object sender, EventArgs e)
        {
            periodSearch1.StartDate = periodSearch1.EndDate.AddDays(-7);
        }
    }
}
