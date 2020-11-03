using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace C968_PA_Task
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBoxName.Validating += textBoxName_Validating;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainScreen = new Form1();
            mainScreen.Show();
        }

        private void textBoxName_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxName.Text == "Invalid")
            {
                textBoxName.BackColor = Color.Tomato;
            }
            if (textBoxName.Text == "Valid")
            {
                textBoxName.BackColor = Color.White;
            }
        }

        private void textBoxName_Validated(object sender, CancelEventArgs e)
        {
           
        }
    }
}
