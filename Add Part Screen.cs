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
            textBoxInventory.Validating += textBoxInventory_Validating;
            textBoxPrice.Validating += textBoxPrice_Validating;
            textBoxMin.Validating += textBoxMin_Validating;
            textBoxMax.Validating += textBoxMax_Validating;

        }

        // Instantiated when clicking 'Modify' after selecting an in-house part
        public Form2(Inhouse partToModify)
        {
            InitializeComponent();
            // Set window title
            this.Text = "Modify Part";
            // Bind event handlers for error-checking and fill textBoxes
            // with the properties of selected part
            radioButtonInhouse.Checked = true;
            textBoxName.Text = partToModify.Name;
            textBoxName.Validating += textBoxName_Validating;
            textBoxInventory.Text = partToModify.InStock.ToString();
            textBoxInventory.Validating += textBoxInventory_Validating;
            textBoxPrice.Text = partToModify.Price.ToString();
            textBoxPrice.Validating += textBoxPrice_Validating;
            textBoxMin.Text = partToModify.Min.ToString();
            textBoxMin.Validating += textBoxMin_Validating;
            textBoxMax.Text = partToModify.Max.ToString();
            textBoxMax.Validating += textBoxMax_Validating;
        }

        // Instantiated when clicking 'Modify' after selecting an outsourced part
        public Form2(Outsourced partToModify)
        {
            InitializeComponent();
            // Set window title
            this.Text = "Modify Part";
            // Bind event handlers for error-checking and fill textBoxes
            // with the properties of selected part
            radioButtonOutsourced.Checked = true;
            textBoxName.Text = partToModify.Name;
            textBoxName.Validating += textBoxName_Validating;
            textBoxInventory.Text = partToModify.InStock.ToString();
            textBoxInventory.Validating += textBoxInventory_Validating;
            textBoxPrice.Text = partToModify.Price.ToString();
            textBoxPrice.Validating += textBoxPrice_Validating;
            textBoxMin.Text = partToModify.Min.ToString();
            textBoxMin.Validating += textBoxMin_Validating;
            textBoxMax.Text = partToModify.Max.ToString();
            textBoxMax.Validating += textBoxMax_Validating;
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
        
        private void textBoxInventory_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.Match(textBoxInventory.Text, "^[0-9][0-9]*$").Success || int.Parse(textBoxInventory.Text) < 0 || int.Parse(textBoxInventory.Text) > 99)
            {
                textBoxInventory.BackColor = Color.Tomato;
                saveButton.Enabled = false;
                errorProvider1.SetError(this.textBoxInventory, "Inventory must be a positive number between 0 and 99");
            }
            else
            {
                textBoxInventory.BackColor = Color.White;
                saveButton.Enabled = true;
                // Clear the error, if any, in the error provider.
                errorProvider1.SetError(this.textBoxInventory, String.Empty);
            }
        }

        private void textBoxPrice_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.Match(textBoxPrice.Text, "^[0-9][0-9]*$").Success)
            {
                textBoxPrice.BackColor = Color.Tomato;
                saveButton.Enabled = false;
                errorProvider1.SetError(this.textBoxPrice, "Price must be a decimal in xx.xx or x.xx format, no need to enter a dollar sign");
            }
            else
            {
                textBoxPrice.BackColor = Color.White;
                saveButton.Enabled = true;
                // Clear the error, if any, in the error provider.
                errorProvider1.SetError(this.textBoxPrice, String.Empty);
            }
        }

        private void textBoxMin_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.Match(textBoxMin.Text, "^[0-9][0-9]*$").Success)
            {
                textBoxMin.BackColor = Color.Tomato;
                saveButton.Enabled = false;
                errorProvider1.SetError(this.textBoxMin, "Minimum quantity on hand must be a number and must be greater than or equal to 0");
            }
            else
            {
                textBoxMin.BackColor = Color.White;
                saveButton.Enabled = true;
                // Clear the error, if any, in the error provider.
                errorProvider1.SetError(this.textBoxMin, String.Empty);
            }
        }

        private void textBoxMax_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.Match(textBoxMax.Text, "^[0-9][0-9]*$").Success)
            {
                textBoxMax.BackColor = Color.Tomato;
                saveButton.Enabled = false;
                errorProvider1.SetError(this.textBoxMax, "Maximum quantity on hand must be a number and must be less than 1000");
            }
            else
            {
                textBoxMax.BackColor = Color.White;
                saveButton.Enabled = true;
                // Clear the error, if any, in the error provider.
                errorProvider1.SetError(this.textBoxMax, String.Empty);
            }
        }
    }
}
