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

            // Initialize random number generator to create a part ID from 0-999999
            Random generator = new Random();
            int possiblePartID = generator.Next(0, 1000000);
            while (CheckPartID(possiblePartID))
            {
                possiblePartID = generator.Next(0, 1000000);
            }
            textBoxID.Text = possiblePartID.ToString();
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

        private bool CheckPartID(int partID)
        {
            bool found = false;
            if (Inventory.allParts == null)
            {
                return found;
            }
            else
            {
                foreach (var part in Inventory.allParts)
                {
                    if (part.PartID == partID)
                    {
                        found = true;
                    }
                }
                return found;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainScreen = new Form1();
            mainScreen.Show();
        }

        private void textBoxName_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxName.Text != "")
            {
                // Here we clear the error from the error provider if the check returns true, and leave the error if the user enters 
                // anything *other than* what matches this regex (No digits, words are capitalized with one space between
                if (Regex.Match(textBoxName.Text, "^[A-Z][a-z]*\\s[A-Z][a-z]*\\s[A-Z][a-z]*").Success || 
                    Regex.Match(textBoxName.Text, "^[A-Z][a-z]*\\s[A-Z][a-z]*").Success || 
                    Regex.Match(textBoxName.Text, "^[A-Z][a-z]*").Success)
                {
                    textBoxName.BackColor = Color.White;
                    saveButton.Enabled = true;
                    // Clear the error, if any, in the error provider.
                    errorProvider1.SetError(this.textBoxName, String.Empty);
                }
                else
                {
                    textBoxName.BackColor = Color.Tomato;
                    saveButton.Enabled = false;
                    errorProvider1.SetError(this.textBoxName, "Part's name must only include the 26 letters of the alphabet, and each word needs to be capitalized");
                }
            }
            else
            {
                textBoxName.BackColor = Color.White;
                saveButton.Enabled = true;
                // Clear the error, if any, in the error provider.
                errorProvider1.SetError(this.textBoxName, String.Empty);
            }
        }
        
        private void textBoxInventory_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxInventory.Text != "")
            {
                if (!Regex.Match(textBoxInventory.Text, "^[0-9][0-9]*$").Success || int.Parse(textBoxInventory.Text) < 0 || int.Parse(textBoxInventory.Text) > 999)
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
            if (textBoxPrice.Text != "")
            {
                if (!Regex.Match(textBoxPrice.Text, "^[0-9]+.[0-9]{2}$").Success)
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
            if (textBoxMin.Text != "")
            {
                if (!Regex.Match(textBoxMin.Text, "^[0-9][0-9]*$").Success || int.Parse(textBoxMin.Text) < 0 || int.Parse(textBoxMin.Text) > 999)
                {
                    textBoxMin.BackColor = Color.Tomato;
                    saveButton.Enabled = false;
                    errorProvider1.SetError(this.textBoxMin, "Minimum quantity on hand must be a positive number and must be less than 1000");
                }
                else
                {
                    textBoxMin.BackColor = Color.White;
                    saveButton.Enabled = true;
                    // Clear the error, if any, in the error provider.
                    errorProvider1.SetError(this.textBoxMin, String.Empty);
                }
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
            if (textBoxMax.Text != "")
            {
                if (!Regex.Match(textBoxMax.Text, "^[0-9][0-9]*$").Success || int.Parse(textBoxMax.Text) < 0 || int.Parse(textBoxMax.Text) > 999)
                {
                    textBoxMax.BackColor = Color.Tomato;
                    saveButton.Enabled = false;
                    errorProvider1.SetError(this.textBoxMax, "Maximum quantity on hand must be a positive number and must be less than 1000");
                }
                else
                {
                    textBoxMax.BackColor = Color.White;
                    saveButton.Enabled = true;
                    // Clear the error, if any, in the error provider.
                    errorProvider1.SetError(this.textBoxMax, String.Empty);
                }
            } 
            else
            {
                textBoxMax.BackColor = Color.White;
                saveButton.Enabled = true;
                // Clear the error, if any, in the error provider.
                errorProvider1.SetError(this.textBoxMax, String.Empty);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        { 
            if (radioButtonInhouse.Checked == true)
            {
                Inhouse partToAdd = new Inhouse(int.Parse(textBoxID.Text), textBoxName.Text, decimal.Parse(textBoxPrice.Text),
                                                int.Parse(textBoxInventory.Text), int.Parse(textBoxMin.Text), 
                                                int.Parse(textBoxMax.Text), int.Parse(textBoxMachineID.Text));
                Inventory.addPart(partToAdd);
                MessageBox.Show($"Added part: {Inventory.allParts[Inventory.allParts.Count - 1].Name}");
                this.Hide();
                Program.mainScreen.Show();
            }
        }
    }
}
