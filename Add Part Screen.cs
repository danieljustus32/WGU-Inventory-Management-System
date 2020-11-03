using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
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
            if (!Regex.Match(textBoxName.Text, "^[A-Z][a-zA-Z]*$").Success)
            {
                textBoxName.BackColor = Color.Tomato;
                saveButton.Enabled = false;
                errorProvider1.SetError(this.textBoxName, "Name must not include numbers or whitespace, and must begin with a capital letter");
            } else
            {
                textBoxName.BackColor = Color.White;
                saveButton.Enabled = true;
                // Clear the error, if any, in the error provider.
                errorProvider1.SetError(this.textBoxName, String.Empty);
            }
        }

        private void textBoxName_Validated(object sender, CancelEventArgs e)
        {
           
        }
    }
}
