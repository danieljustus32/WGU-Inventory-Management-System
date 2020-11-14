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
    public partial class Form3 : Form
    {
        private Product loadedProduct { get; set; } = null;
        private bool formValid { get; set; }
        private BindingList<Part> partsToBeAssociated = new BindingList<Part>();

        public Form3(Product productToModify)
        {
            InitializeComponent();
            candidatePartsGridView.DataSource = Inventory.allParts;
            associatedPartsGridView.DataSource = this.partsToBeAssociated;
            

            if (productToModify is null)
            {
                // Initialize random number generator to create a part ID from 0-999999
                Random generator = new Random();
                int possibleProductID = generator.Next(0, 1000000);
                while (CheckProductID(possibleProductID))
                {
                    possibleProductID = generator.Next(0, 1000000);
                }
                textBoxID.Text = possibleProductID.ToString();
                textBoxName.TextChanged += textBoxName_TextChanged;
                textBoxInventory.TextChanged += textBoxInventory_TextChanged;
                textBoxPrice.TextChanged += textBoxPrice_TextChanged;
                textBoxMin.TextChanged += textBoxMin_TextChanged;
                textBoxMax.TextChanged += textBoxMax_TextChanged;
            }
            else if (productToModify is Product)
            {
                // Set window title
                this.Text = "Modify Part";
                loadedProduct = productToModify;
                foreach (var part in loadedProduct.associatedParts)
                {
                    partsToBeAssociated.Add(part);
                }
                // Bind event handlers for error-checking and fill textBoxes
                // with the properties of selected part
                textBoxID.Text = loadedProduct.ProductID.ToString();
                textBoxName.Text = loadedProduct.Name;
                textBoxInventory.Text = loadedProduct.InStock.ToString();
                textBoxInventory.TextChanged += textBoxInventory_TextChanged;
                textBoxPrice.Text = loadedProduct.Price.ToString();
                textBoxPrice.TextChanged += textBoxPrice_TextChanged;
                textBoxMin.Text = loadedProduct.Min.ToString();
                textBoxMin.TextChanged += textBoxMin_TextChanged;
                textBoxMax.Text = loadedProduct.Max.ToString();
                textBoxMax.TextChanged += textBoxMax_TextChanged;
            }
        }

        private bool CheckProductID(int productID)
        {
            bool found = false;
            if (Inventory.products == null)
            {
                return found;
            }
            else
            {
                foreach (var product in Inventory.products)
                {
                    if (product.ProductID == productID)
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    bool formFilled = true;
                    foreach (Control control in this.Controls)
                    {
                        // Check that no fields have been left blank
                        if (control.GetType() == typeof(TextBox) && control.Text == String.Empty && control.Name != "textBoxSearch")
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


                        Product productToAddOrModify = new Product(int.Parse(textBoxID.Text), textBoxName.Text, decimal.Parse(textBoxPrice.Text),
                                                        int.Parse(textBoxInventory.Text), int.Parse(textBoxMin.Text),
                                                        int.Parse(textBoxMax.Text));
                        if (loadedProduct != null)
                        {
                            foreach (var part in partsToBeAssociated)
                            {
                                if (!loadedProduct.associatedParts.Contains(part))
                                {
                                    loadedProduct.addAssociatedPart(part);
                                }
                            }
                            // Check to make sure the product we're about to save has at least one associated part. If not, 
                            // alert the user and do nothing.
                            if (loadedProduct.associatedParts.Count == 0)
                            {
                                MessageBox.Show("All products must have at least one associated part");
                                return;
                            }
                            // Save
                            Inventory.updateProduct(productToAddOrModify.ProductID, productToAddOrModify);
                            foreach (var part in partsToBeAssociated)
                            {
                                productToAddOrModify.addAssociatedPart(part);
                            }
                        }
                        else
                        {
                            foreach (var part in partsToBeAssociated)
                            {
                                productToAddOrModify.addAssociatedPart(part);
                            }
                            // Check to make sure the product we're about to save has at least one associated part. If not, 
                            // alert the user and do nothing.
                            if (productToAddOrModify.associatedParts.Count == 0)
                            {
                                MessageBox.Show("All products must have at least one associated part");
                                return;
                            }
                            // Save
                            Inventory.addProduct(productToAddOrModify);
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
                        // Set formFilled back to true for subsequent validations
                        formFilled = true;
                        MessageBox.Show($"Please fill out all fields before saving this part");
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(candidatePartsGridView.SelectedRows[0].Cells[0].Value.ToString());
                Part partToAdd = Inventory.lookupPart(id);
                partsToBeAssociated.Add(partToAdd);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(associatedPartsGridView.SelectedRows[0].Cells[0].Value.ToString());
                // Check if we have a product loaded that we're modifying. If so, we need to actually 
                // remove the part from its associatedParts list and then remove it from partsToBeAssociated
                if (loadedProduct != null)
                {
                    loadedProduct.removeAssociatedPart(id);
                    for (int i = 0; i < partsToBeAssociated.Count; i++)
                    {
                        if (partsToBeAssociated[i].PartID == id)
                        {
                            partsToBeAssociated.Remove(partsToBeAssociated[i]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < partsToBeAssociated.Count; i++)
                    {
                        if (partsToBeAssociated[i].PartID == id)
                        {
                            partsToBeAssociated.Remove(partsToBeAssociated[i]);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string searchValue = textBoxSearch.Text;

                foreach (DataGridViewRow row in candidatePartsGridView.Rows)
                {
                    if (Regex.Match(row.Cells[0].Value.ToString(), $"{searchValue}").Success)
                    {
                        row.Selected = true;
                        candidatePartsGridView.CurrentCell = row.Cells[0];
                        break;
                    }
                    if (Regex.Match(row.Cells[1].Value.ToString().ToLower(), $"{searchValue.ToLower()}").Success)
                    {
                        row.Selected = true;
                        candidatePartsGridView.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
