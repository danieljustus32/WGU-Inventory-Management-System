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
        // Instantiated when clicking 'Modify' after selecting an in-house part
        public Form2(Part partToModify)
        {
            InitializeComponent();

            if (partToModify is null)
            {
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
                textBoxMachineID.Validating += textBoxMachineID_Validating;
            }
            else if (partToModify is Inhouse)
            {
                // Set window title
                this.Text = "Modify Part";
                // Bind event handlers for error-checking and fill textBoxes
                // with the properties of selected part
                radioButtonInhouse.Checked = true;
                Inhouse part = partToModify as Inhouse;
                textBoxName.Text = part.Name;
                textBoxName.Validating += textBoxName_Validating;
                textBoxInventory.Text = part.InStock.ToString();
                textBoxInventory.Validating += textBoxInventory_Validating;
                textBoxPrice.Text = part.Price.ToString();
                textBoxPrice.Validating += textBoxPrice_Validating;
                textBoxMin.Text = part.Min.ToString();
                textBoxMin.Validating += textBoxMin_Validating;
                textBoxMax.Text = part.Max.ToString();
                textBoxMax.Validating += textBoxMax_Validating;
                textBoxMachineID.Text = part.MachineID.ToString();
                textBoxMachineID.Validating += textBoxMachineID_Validating;
            }
            else
            {
                // Set window title
                this.Text = "Modify Part";
                // Bind event handlers for error-checking and fill textBoxes
                // with the properties of selected part
                radioButtonOutsourced.Checked = true;
                Outsourced part = partToModify as Outsourced;
                textBoxName.Text = part.Name;
                textBoxName.Validating += textBoxName_Validating;
                textBoxInventory.Text = part.InStock.ToString();
                textBoxInventory.Validating += textBoxInventory_Validating;
                textBoxPrice.Text = part.Price.ToString();
                textBoxPrice.Validating += textBoxPrice_Validating;
                textBoxMin.Text = part.Min.ToString();
                textBoxMin.Validating += textBoxMin_Validating;
                textBoxMax.Text = part.Max.ToString();
                textBoxMax.Validating += textBoxMax_Validating;
                textBoxMachineID.Validating += textBoxMachineID_Validating;
            }
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
                // anything *other than* what matches this regex (No digits, words are capitalized)
                if (Regex.Match(textBoxName.Text, "^[A-Z][a-z]*").Success && !Regex.Match(textBoxName.Text, "[0-9]").Success)
                {
                    textBoxName.BackColor = Color.White;
                    errorProvider1.SetError(this.textBoxName, String.Empty);
                }
                else
                {
                    textBoxName.BackColor = Color.Tomato;
                    errorProvider1.SetError(this.textBoxName, "Part's name must be text and first letter must be capitalized");
                }
            }
            else
            {
                textBoxName.BackColor = Color.White;
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
                    errorProvider1.SetError(this.textBoxInventory, "Inventory must be a positive number between 0 and 99");
                }
                else
                {
                    textBoxInventory.BackColor = Color.White;
                    errorProvider1.SetError(this.textBoxInventory, String.Empty);
                }
            }
            else
            {
                textBoxInventory.BackColor = Color.White;
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
                    errorProvider1.SetError(this.textBoxPrice, "Price must be a decimal in xx.xx or x.xx format, no need to enter a dollar sign");
                }
                else
                {
                    textBoxPrice.BackColor = Color.White;
                    errorProvider1.SetError(this.textBoxPrice, String.Empty);
                }
            }
            else
            {
                textBoxPrice.BackColor = Color.White;
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
                    errorProvider1.SetError(this.textBoxMin, "Minimum quantity on hand must be a positive number and must be less than 1000");
                }
                else
                {
                    textBoxMin.BackColor = Color.White;
                    errorProvider1.SetError(this.textBoxMin, String.Empty);
                }
            }
            else
            {
                textBoxMin.BackColor = Color.White;
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
                    errorProvider1.SetError(this.textBoxMax, "Maximum quantity on hand must be a positive number and must be less than 1000");
                }
                else
                {
                    textBoxMax.BackColor = Color.White;
                    errorProvider1.SetError(this.textBoxMax, String.Empty);
                }
            } 
            else
            {
                textBoxMax.BackColor = Color.White;
                errorProvider1.SetError(this.textBoxMax, String.Empty);
            }
        }

        private void textBoxMachineID_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxMachineID.Text != "")
            {
                if (radioButtonInhouse.Checked == true)
                {
                    if (!Regex.Match(textBoxMachineID.Text, "^[0-9]+$").Success)
                    {
                        textBoxMachineID.BackColor = Color.Tomato;
                        errorProvider1.SetError(this.textBoxMachineID, "Machine ID must be a number");
                    }
                    else
                    {
                        textBoxMachineID.BackColor = Color.White;
                        errorProvider1.SetError(this.textBoxMachineID, String.Empty);
                    }
                }
                else
                {
                    if (Regex.Match(textBoxMachineID.Text, "^[A-Z][a-z]*").Success && !Regex.Match(textBoxMachineID.Text, "[0-9]").Success)
                    {
                        textBoxMachineID.BackColor = Color.White;
                        errorProvider1.SetError(this.textBoxMachineID, String.Empty);
                    }
                    else
                    {
                        textBoxMachineID.BackColor = Color.Tomato;
                        errorProvider1.SetError(this.textBoxMachineID, "Part's name must be text and first letter must be capitalized");
                    }
                }
            }
            else
            {
                textBoxMachineID.BackColor = Color.White;
                errorProvider1.SetError(this.textBoxMachineID, String.Empty);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool formValidated = true;
            foreach (Control control in this.Controls)
            {
                // TODO: Check that all fields are filled out, check other conditions in task description as well (e.g. Inventory > Max)
                if (errorProvider1.GetError(control) != String.Empty)
                {
                    formValidated = false;
                }
                if (control.GetType() == typeof(TextBox) && control.Text  == String.Empty)
                {
                    formValidated = false;
                }
            }
            if (formValidated == true)
            {
                if (radioButtonInhouse.Checked == true)
                {
                    Inhouse partToAdd = new Inhouse(int.Parse(textBoxID.Text), textBoxName.Text, decimal.Parse(textBoxPrice.Text),
                                                    int.Parse(textBoxInventory.Text), int.Parse(textBoxMin.Text),
                                                    int.Parse(textBoxMax.Text), int.Parse(textBoxMachineID.Text));
                    Inventory.addPart(partToAdd);

                    // Hide our Add Part screen. However, since we're not instantiating a new one every time we click 'Add Part', we need to clear the form here
                    this.Hide();
                    foreach (Control control in this.Controls)
                    {
                        if (control.GetType() == typeof(TextBox))
                        {
                            control.Text = null;
                        }
                    }
                    Program.mainScreen.Show();
                }
                else
                {
                    Outsourced partToAdd = new Outsourced(int.Parse(textBoxID.Text), textBoxName.Text, decimal.Parse(textBoxPrice.Text),
                                                    int.Parse(textBoxInventory.Text), int.Parse(textBoxMin.Text),
                                                    int.Parse(textBoxMax.Text), textBoxMachineID.Text);
                    Inventory.addPart(partToAdd);

                    // Hide our Add Part screen. However, since we're not instantiating a new one every time we click 'Add Part', we need to clear the form here
                    this.Hide();
                    foreach (Control control in this.Controls)
                    {
                        if (control.GetType() == typeof(TextBox))
                        {
                            control.Text = null;
                        }
                    }
                    Program.mainScreen.Show();
                }
            } 
            else
            {
                // Set formValidated back to true for subsequent validations
                formValidated = true;
                MessageBox.Show($"Please fill out all fields and correct any errors before saving this part");
            }
        }

        private void radioButtonOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOutsourced.Checked == true)
            {
                labelMachineID.Text = "Company Name";
            }
        }

        private void radioButtonInhouse_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonInhouse.Checked == true)
            {
                labelMachineID.Text = "Machine ID";
            }
        }
    }
}
