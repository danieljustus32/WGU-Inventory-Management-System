using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace C968_PA_Task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            partsGridView.DataSource = Inventory.allParts;
            productGridView.DataSource = Inventory.products;
        }

        private void addButton1_Click(object sender, EventArgs e)
        {
            Form3 addProductScreen = new Form3(null);
            this.Hide();
            addProductScreen.Show();
        }

        private void modifyButton1_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (productGridView.SelectedRows.Count > 0)
            {
                id = int.Parse(productGridView.SelectedRows[0].Cells[0].Value.ToString());
            }
            Form3 modifyProductScreen = new Form3(Inventory.lookupProduct(id));
            this.Hide();
            modifyProductScreen.Show();
        }

        private void deleteButton2_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (partsGridView.SelectedRows.Count > 0)
            {
                id = int.Parse(partsGridView.SelectedRows[0].Cells[0].Value.ToString());
            }
            Part partToDelete = Inventory.lookupPart(id);
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete part {id}?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Inventory.deletePart(partToDelete);
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 addPartScreen = new Form2(null);
            addPartScreen.Show();
        }

        private void modifyButton2_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (partsGridView.SelectedRows.Count > 0)
            {
                id = int.Parse(partsGridView.SelectedRows[0].Cells[0].Value.ToString());
            }
            Form2 modifyPartScreen = new Form2(Inventory.lookupPart(id));
            this.Hide();
            modifyPartScreen.Show();
        }

        private void buttonSearchParts_Click(object sender, EventArgs e)
        {
            string searchValue = textBoxSearchParts.Text;

            try
            {
                foreach (DataGridViewRow row in partsGridView.Rows)
                {
                    if (Regex.Match(row.Cells[0].Value.ToString(), $"{searchValue}").Success)
                    {
                        row.Selected = true;
                        partsGridView.CurrentCell = row.Cells[0];
                        break;
                    }
                    if (Regex.Match(row.Cells[1].Value.ToString().ToLower(), $"{searchValue.ToLower()}").Success)
                    {
                        row.Selected = true;
                        partsGridView.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void buttonSearchProducts_Click(object sender, EventArgs e)
        {
            string searchValue = textBoxSearchProducts.Text;

            try
            {
                foreach (DataGridViewRow row in productGridView.Rows)
                {
                    if (Regex.Match(row.Cells[0].Value.ToString(), $"{searchValue}").Success)
                    {
                        row.Selected = true;
                        productGridView.CurrentCell = row.Cells[0];
                        break;
                    }
                    if (Regex.Match(row.Cells[1].Value.ToString().ToLower(), $"{searchValue.ToLower()}").Success)
                    {
                        row.Selected = true;
                        productGridView.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void deleteButton1_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (productGridView.SelectedRows.Count > 0)
            {
                id = int.Parse(productGridView.SelectedRows[0].Cells[0].Value.ToString());
            }
            Product productToDelete = Inventory.lookupProduct(id);
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete product {id}?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Inventory.removeProduct(productToDelete.ProductID);
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
}
