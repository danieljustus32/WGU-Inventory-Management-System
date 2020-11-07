using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace C968_PA_Task
{
    public partial class Form2 : Form
    {
        private Part loadedPart { get; set; } = null;
        private bool formValid { get; set; }
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
                textBoxName.TextChanged += textBoxName_TextChanged;
                textBoxInventory.TextChanged += textBoxInventory_TextChanged;
                textBoxPrice.TextChanged += textBoxPrice_TextChanged;
                textBoxMin.TextChanged += textBoxMin_TextChanged;
                textBoxMax.TextChanged += textBoxMax_TextChanged;
                textBoxMachineID.TextChanged += textBoxMachineID_TextChanged;
            }
            else if (partToModify is Inhouse)
            {
                // Set window title
                this.Text = "Modify Part";
                loadedPart = partToModify;
                // Bind event handlers for error-checking and fill textBoxes
                // with the properties of selected part
                radioButtonInhouse.Checked = true;
                Inhouse part = partToModify as Inhouse;
                textBoxID.Text = part.PartID.ToString();
                textBoxName.Text = part.Name;
                textBoxInventory.Text = part.InStock.ToString();
                textBoxInventory.TextChanged += textBoxInventory_TextChanged;
                textBoxPrice.Text = part.Price.ToString();
                textBoxPrice.TextChanged += textBoxPrice_TextChanged;
                textBoxMin.Text = part.Min.ToString();
                textBoxMin.TextChanged += textBoxMin_TextChanged;
                textBoxMax.Text = part.Max.ToString();
                textBoxMax.TextChanged += textBoxMax_TextChanged;
                textBoxMachineID.Text = part.MachineID.ToString();
                textBoxMachineID.TextChanged += textBoxMachineID_TextChanged;
            }
            else
            {
                // Set window title
                this.Text = "Modify Part";
                loadedPart = partToModify;
                // Bind event handlers for error-checking and fill textBoxes
                // with the properties of selected part
                radioButtonOutsourced.Checked = true;
                Outsourced part = partToModify as Outsourced;
                textBoxID.Text = part.PartID.ToString();
                textBoxName.Text = part.Name;
                textBoxInventory.Text = part.InStock.ToString();
                textBoxInventory.TextChanged += textBoxInventory_TextChanged;
                textBoxPrice.Text = part.Price.ToString();
                textBoxPrice.TextChanged += textBoxPrice_TextChanged;
                textBoxMin.Text = part.Min.ToString();
                textBoxMin.TextChanged += textBoxMin_TextChanged;
                textBoxMax.Text = part.Max.ToString();
                textBoxMax.TextChanged += textBoxMax_TextChanged;
                textBoxMachineID.Text = part.CompanyName.ToString();
                textBoxMachineID.TextChanged += textBoxMachineID_TextChanged;            }
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

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text != "")
            {
                // Here we clear the error from the error provider if the check returns true, and leave the error if the user enters 
                // anything *other than* what matches this regex (No digits, words are capitalized)
                if (Regex.Match(textBoxName.Text, "^[A-Z][a-z]*").Success && !Regex.Match(textBoxName.Text, "[0-9]").Success)
                {
                    textBoxName.BackColor = Color.White;
                    errorProvider1.SetError(this.textBoxName, String.Empty);
                    saveButton.Enabled = true;
                }
                else
                {
                    textBoxName.BackColor = Color.Tomato;
                    errorProvider1.SetError(this.textBoxName, "Part's name must be text, first letter must be capitalized, and name cannot contain a number");
                    saveButton.Enabled = false;
                }
            }
            else
            {
                textBoxName.BackColor = Color.White;
                errorProvider1.SetError(this.textBoxName, String.Empty);
                saveButton.Enabled = true;
            }
        }
        
        private void textBoxInventory_TextChanged(object sender, EventArgs e)
        {
            if (textBoxInventory.Text != "")
            {
                if (!Regex.Match(textBoxInventory.Text, "^[0-9][0-9]*$").Success || int.Parse(textBoxInventory.Text) < 0 || int.Parse(textBoxInventory.Text) > 999)
                {
                    textBoxInventory.BackColor = Color.Tomato;
                    errorProvider1.SetError(this.textBoxInventory, "Inventory must be a positive number between 0 and 99");
                    saveButton.Enabled = false;
                }
                else
                {
                    textBoxInventory.BackColor = Color.White;
                    errorProvider1.SetError(this.textBoxInventory, String.Empty);
                    saveButton.Enabled = true;
                }
            }
            else
            {
                textBoxInventory.BackColor = Color.White;
                errorProvider1.SetError(this.textBoxInventory, String.Empty);
                saveButton.Enabled = true;
            }
        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPrice.Text != "")
            {
                if (!Regex.Match(textBoxPrice.Text, "^[0-9]+.[0-9]{2}$").Success)
                {
                    textBoxPrice.BackColor = Color.Tomato;
                    errorProvider1.SetError(this.textBoxPrice, "Price must be a decimal in xx.xx or x.xx format, no need to enter a dollar sign");
                    saveButton.Enabled = false;
                }
                else
                {
                    textBoxPrice.BackColor = Color.White;
                    errorProvider1.SetError(this.textBoxPrice, String.Empty);
                    saveButton.Enabled = true;
                }
            }
            else
            {
                textBoxPrice.BackColor = Color.White;
                errorProvider1.SetError(this.textBoxPrice, String.Empty);
                saveButton.Enabled = true;
            }
        }

        private void textBoxMin_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMin.Text != "")
            {
                if (!Regex.Match(textBoxMin.Text, "^[0-9][0-9]*$").Success || int.Parse(textBoxMin.Text) < 0 || int.Parse(textBoxMin.Text) > 999)
                {
                    textBoxMin.BackColor = Color.Tomato;
                    errorProvider1.SetError(this.textBoxMin, "Minimum quantity on hand must be a positive number and must be less than 1000");
                    saveButton.Enabled = false;
                }
                else
                {
                    textBoxMin.BackColor = Color.White;
                    errorProvider1.SetError(this.textBoxMin, String.Empty);
                    saveButton.Enabled = true;
                }
            }
            else
            {
                textBoxMin.BackColor = Color.White;
                errorProvider1.SetError(this.textBoxMin, String.Empty);
                saveButton.Enabled = true;
            }
        }

        private void textBoxMax_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMax.Text != "")
            {
                if (!Regex.Match(textBoxMax.Text, "^[0-9][0-9]*$").Success || int.Parse(textBoxMax.Text) < 0 || int.Parse(textBoxMax.Text) > 999)
                {
                    textBoxMax.BackColor = Color.Tomato;
                    errorProvider1.SetError(this.textBoxMax, "Maximum quantity on hand must be a positive number and must be less than 1000");
                    saveButton.Enabled = false;
                }
                else
                {
                    textBoxMax.BackColor = Color.White;
                    errorProvider1.SetError(this.textBoxMax, String.Empty);
                    saveButton.Enabled = true;
                }
            } 
            else
            {
                textBoxMax.BackColor = Color.White;
                errorProvider1.SetError(this.textBoxMax, String.Empty);
                saveButton.Enabled = true;
            }
        }

        private void textBoxMachineID_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMachineID.Text != "")
            {
                if (radioButtonInhouse.Checked == true)
                {
                    if (!Regex.Match(textBoxMachineID.Text, "^[0-9]+$").Success)
                    {
                        textBoxMachineID.BackColor = Color.Tomato;
                        errorProvider1.SetError(this.textBoxMachineID, "Machine ID must be a number");
                        saveButton.Enabled = false;
                    }
                    else
                    {
                        textBoxMachineID.BackColor = Color.White;
                        errorProvider1.SetError(this.textBoxMachineID, String.Empty);
                        saveButton.Enabled = true;
                    }
                }
                else
                {
                    if (Regex.Match(textBoxMachineID.Text, "^[A-Z][a-z]*").Success && !Regex.Match(textBoxMachineID.Text, "[0-9]").Success)
                    {
                        textBoxMachineID.BackColor = Color.White;
                        errorProvider1.SetError(this.textBoxMachineID, String.Empty);
                        saveButton.Enabled = true;
                    }
                    else
                    {
                        textBoxMachineID.BackColor = Color.Tomato;
                        errorProvider1.SetError(this.textBoxMachineID, "Company name must be text, first letter must be capitalized and name cannot contain a number");
                        saveButton.Enabled = false;
                    }
                }
            }
            else
            {
                textBoxMachineID.BackColor = Color.White;
                errorProvider1.SetError(this.textBoxMachineID, String.Empty);
                saveButton.Enabled = true;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool formFilled = true;
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(TextBox) && control.Text  == String.Empty)
                {
                    formFilled = false;
                }
            }
            if (formFilled == true)
            {
                // Check that min is less than or equal to max
                if (int.Parse(textBoxMin.Text) > int.Parse(textBoxMax.Text))
                {
                    MessageBox.Show("Minimum inventory on hand must be less than or equal to maximum inventory on hand");
                    return;
                }

                // Check that inventory falls between min and max values
                if (int.Parse(textBoxInventory.Text) < int.Parse(textBoxMin.Text) || int.Parse(textBoxInventory.Text) > int.Parse(textBoxMax.Text))
                {
                    MessageBox.Show("Please ensure inventory on hand is at least equal to minimum on-hand value and less than or equal to maximum on-hand value");
                    return;
                }

                if (radioButtonInhouse.Checked == true)
                {
                    Inhouse partToAddOrModify = new Inhouse(int.Parse(textBoxID.Text), textBoxName.Text, decimal.Parse(textBoxPrice.Text),
                                                    int.Parse(textBoxInventory.Text), int.Parse(textBoxMin.Text),
                                                    int.Parse(textBoxMax.Text), int.Parse(textBoxMachineID.Text));
                    if (loadedPart != null)
                    {
                        Inventory.updatePart(partToAddOrModify.PartID, partToAddOrModify);
                    }
                    else
                    {
                        Inventory.addPart(partToAddOrModify);
                    }

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
                    Outsourced partToAddOrModify = new Outsourced(int.Parse(textBoxID.Text), textBoxName.Text, decimal.Parse(textBoxPrice.Text),
                                                    int.Parse(textBoxInventory.Text), int.Parse(textBoxMin.Text),
                                                    int.Parse(textBoxMax.Text), textBoxMachineID.Text);
                    if (loadedPart != null)
                    {
                        Inventory.updatePart(partToAddOrModify.PartID, partToAddOrModify);
                    }
                    else
                    {
                        Inventory.addPart(partToAddOrModify);
                    }

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
                // Set formFilled back to true for subsequent validations
                formFilled = true;
                MessageBox.Show($"Please fill out all fields before saving this part");
            }
        }

        private void radioButtonOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOutsourced.Checked == true)
            {
                labelMachineID.Text = "Company Name";
                textBoxMachineID.Text = "";
            }
        }

        private void radioButtonInhouse_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonInhouse.Checked == true)
            {
                labelMachineID.Text = "Machine ID";
                textBoxMachineID.Text = "";
            }
        }
    }
}
