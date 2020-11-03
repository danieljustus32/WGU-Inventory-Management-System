using System;
using System.Windows.Forms;

namespace C968_PA_Task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

        }

        private void addButton1_Click(object sender, EventArgs e)
        {

        }

        private void modifyButton1_Click(object sender, EventArgs e)
        {

        }

        private void deleteButton2_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.addorModifyPartScreen.Show();
        }
    }
}
