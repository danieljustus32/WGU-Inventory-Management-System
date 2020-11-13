namespace C968_PA_Task
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IMSLabel = new System.Windows.Forms.Label();
            this.buttonSearchProducts = new System.Windows.Forms.Button();
            this.textBoxSearchProducts = new System.Windows.Forms.TextBox();
            this.addButton1 = new System.Windows.Forms.Button();
            this.modifyButton1 = new System.Windows.Forms.Button();
            this.deleteButton1 = new System.Windows.Forms.Button();
            this.addButton2 = new System.Windows.Forms.Button();
            this.modifyButton2 = new System.Windows.Forms.Button();
            this.deleteButton2 = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.buttonSearchParts = new System.Windows.Forms.Button();
            this.textBoxSearchParts = new System.Windows.Forms.TextBox();
            this.partsGridView = new System.Windows.Forms.DataGridView();
            this.productGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.partsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // IMSLabel
            // 
            this.IMSLabel.AutoSize = true;
            this.IMSLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IMSLabel.Location = new System.Drawing.Point(40, 9);
            this.IMSLabel.Name = "IMSLabel";
            this.IMSLabel.Size = new System.Drawing.Size(227, 21);
            this.IMSLabel.TabIndex = 0;
            this.IMSLabel.Text = "Inventory Management System";
            // 
            // buttonSearchProducts
            // 
            this.buttonSearchProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearchProducts.Location = new System.Drawing.Point(998, 75);
            this.buttonSearchProducts.Name = "buttonSearchProducts";
            this.buttonSearchProducts.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchProducts.TabIndex = 1;
            this.buttonSearchProducts.Text = "Search";
            this.buttonSearchProducts.UseVisualStyleBackColor = true;
            this.buttonSearchProducts.Click += new System.EventHandler(this.buttonSearchProducts_Click);
            // 
            // textBoxSearchProducts
            // 
            this.textBoxSearchProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchProducts.Location = new System.Drawing.Point(1079, 75);
            this.textBoxSearchProducts.Name = "textBoxSearchProducts";
            this.textBoxSearchProducts.PlaceholderText = "Search by product ID or name...";
            this.textBoxSearchProducts.Size = new System.Drawing.Size(262, 23);
            this.textBoxSearchProducts.TabIndex = 2;
            // 
            // addButton1
            // 
            this.addButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton1.Location = new System.Drawing.Point(1162, 500);
            this.addButton1.Name = "addButton1";
            this.addButton1.Size = new System.Drawing.Size(54, 29);
            this.addButton1.TabIndex = 3;
            this.addButton1.Text = "Add";
            this.addButton1.UseVisualStyleBackColor = true;
            this.addButton1.Click += new System.EventHandler(this.addButton1_Click);
            // 
            // modifyButton1
            // 
            this.modifyButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.modifyButton1.Location = new System.Drawing.Point(1222, 500);
            this.modifyButton1.Name = "modifyButton1";
            this.modifyButton1.Size = new System.Drawing.Size(58, 29);
            this.modifyButton1.TabIndex = 4;
            this.modifyButton1.Text = "Modify";
            this.modifyButton1.UseVisualStyleBackColor = true;
            this.modifyButton1.Click += new System.EventHandler(this.modifyButton1_Click);
            // 
            // deleteButton1
            // 
            this.deleteButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton1.Location = new System.Drawing.Point(1286, 500);
            this.deleteButton1.Name = "deleteButton1";
            this.deleteButton1.Size = new System.Drawing.Size(55, 29);
            this.deleteButton1.TabIndex = 5;
            this.deleteButton1.Text = "Delete";
            this.deleteButton1.UseVisualStyleBackColor = true;
            this.deleteButton1.Click += new System.EventHandler(this.deleteButton1_Click);
            // 
            // addButton2
            // 
            this.addButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton2.Location = new System.Drawing.Point(499, 500);
            this.addButton2.Name = "addButton2";
            this.addButton2.Size = new System.Drawing.Size(54, 29);
            this.addButton2.TabIndex = 3;
            this.addButton2.Text = "Add";
            this.addButton2.UseVisualStyleBackColor = true;
            this.addButton2.Click += new System.EventHandler(this.addButton2_Click);
            // 
            // modifyButton2
            // 
            this.modifyButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.modifyButton2.Location = new System.Drawing.Point(559, 500);
            this.modifyButton2.Name = "modifyButton2";
            this.modifyButton2.Size = new System.Drawing.Size(58, 29);
            this.modifyButton2.TabIndex = 4;
            this.modifyButton2.Text = "Modify";
            this.modifyButton2.UseVisualStyleBackColor = true;
            this.modifyButton2.Click += new System.EventHandler(this.modifyButton2_Click);
            // 
            // deleteButton2
            // 
            this.deleteButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton2.Location = new System.Drawing.Point(623, 500);
            this.deleteButton2.Name = "deleteButton2";
            this.deleteButton2.Size = new System.Drawing.Size(55, 29);
            this.deleteButton2.TabIndex = 5;
            this.deleteButton2.Text = "Delete";
            this.deleteButton2.UseVisualStyleBackColor = true;
            this.deleteButton2.Click += new System.EventHandler(this.deleteButton2_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Location = new System.Drawing.Point(1266, 559);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 32);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // buttonSearchParts
            // 
            this.buttonSearchParts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearchParts.Location = new System.Drawing.Point(335, 75);
            this.buttonSearchParts.Name = "buttonSearchParts";
            this.buttonSearchParts.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchParts.TabIndex = 1;
            this.buttonSearchParts.Text = "Search";
            this.buttonSearchParts.UseVisualStyleBackColor = true;
            this.buttonSearchParts.Click += new System.EventHandler(this.buttonSearchParts_Click);
            // 
            // textBoxSearchParts
            // 
            this.textBoxSearchParts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchParts.Location = new System.Drawing.Point(416, 75);
            this.textBoxSearchParts.Name = "textBoxSearchParts";
            this.textBoxSearchParts.PlaceholderText = "Search by part ID or name...";
            this.textBoxSearchParts.Size = new System.Drawing.Size(262, 23);
            this.textBoxSearchParts.TabIndex = 2;
            // 
            // partsGridView
            // 
            this.partsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.partsGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.partsGridView.Location = new System.Drawing.Point(40, 112);
            this.partsGridView.MultiSelect = false;
            this.partsGridView.Name = "partsGridView";
            this.partsGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.partsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.partsGridView.Size = new System.Drawing.Size(638, 348);
            this.partsGridView.TabIndex = 8;
            this.partsGridView.Text = "dataGridView1";
            // 
            // productGridView
            // 
            this.productGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.productGridView.Location = new System.Drawing.Point(703, 112);
            this.productGridView.Name = "productGridView";
            this.productGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.productGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productGridView.Size = new System.Drawing.Size(638, 348);
            this.productGridView.TabIndex = 8;
            this.productGridView.Text = "dataGridView1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(40, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Parts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(703, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Products";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1386, 622);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productGridView);
            this.Controls.Add(this.partsGridView);
            this.Controls.Add(this.textBoxSearchParts);
            this.Controls.Add(this.buttonSearchParts);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.deleteButton2);
            this.Controls.Add(this.modifyButton2);
            this.Controls.Add(this.addButton2);
            this.Controls.Add(this.deleteButton1);
            this.Controls.Add(this.modifyButton1);
            this.Controls.Add(this.addButton1);
            this.Controls.Add(this.textBoxSearchProducts);
            this.Controls.Add(this.buttonSearchProducts);
            this.Controls.Add(this.IMSLabel);
            this.Name = "Form1";
            this.Text = "Inventory Management System";
            ((System.ComponentModel.ISupportInitialize)(this.partsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IMSLabel;
        private System.Windows.Forms.Button buttonSearchProducts;
        private System.Windows.Forms.TextBox textBoxSearchProducts;
        private System.Windows.Forms.Button addButton1;
        private System.Windows.Forms.Button modifyButton1;
        private System.Windows.Forms.Button deleteButton1;
        private System.Windows.Forms.Button addButton2;
        private System.Windows.Forms.Button modifyButton2;
        private System.Windows.Forms.Button deleteButton2;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button buttonSearchParts;
        private System.Windows.Forms.TextBox textBoxSearchParts;
        private System.Windows.Forms.DataGridView partsGridView;
        private System.Windows.Forms.DataGridView productGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

