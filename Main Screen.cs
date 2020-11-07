using System;
using System.Windows.Forms;

namespace C968_PA_Task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            partsGridView.DataSource = Inventory.allParts;
        }

        private void addButton1_Click(object sender, EventArgs e)
        {

        }

        private void modifyButton1_Click(object sender, EventArgs e)
        {

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

        }
    }
}
