namespace COMPX323_Project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.productButton = new System.Windows.Forms.Button();
            this.ProductTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSearch = new System.Windows.Forms.TabPage();
            this.ProductListBox = new System.Windows.Forms.ListBox();
            this.CategoryListBox = new System.Windows.Forms.ListBox();
            this.tabPageAdd = new System.Windows.Forms.TabPage();
            this.buttonClearProduct = new System.Windows.Forms.Button();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.listBoxUpdate = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelCategoryChoose = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.CategoryDescriptionLabel = new System.Windows.Forms.Label();
            this.CategoryDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.CategoryNameLabel = new System.Windows.Forms.Label();
            this.CategoryNameTextBox = new System.Windows.Forms.TextBox();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownProductStock = new System.Windows.Forms.NumericUpDown();
            this.comboBoxWeightUnit = new System.Windows.Forms.ComboBox();
            this.numericUpDownProductPrice = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownProductDiscount = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPageSearch.SuspendLayout();
            this.tabPageAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProductStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProductPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProductDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // productButton
            // 
            this.productButton.Location = new System.Drawing.Point(677, 15);
            this.productButton.Name = "productButton";
            this.productButton.Size = new System.Drawing.Size(133, 25);
            this.productButton.TabIndex = 1;
            this.productButton.Text = "Search";
            this.productButton.UseVisualStyleBackColor = true;
            this.productButton.Click += new System.EventHandler(this.productButton_Click);
            // 
            // ProductTextBox
            // 
            this.ProductTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductTextBox.Location = new System.Drawing.Point(513, 15);
            this.ProductTextBox.Name = "ProductTextBox";
            this.ProductTextBox.Size = new System.Drawing.Size(158, 26);
            this.ProductTextBox.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAdd);
            this.tabControl1.Controls.Add(this.tabPageSearch);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(834, 595);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageSearch
            // 
            this.tabPageSearch.Controls.Add(this.ProductListBox);
            this.tabPageSearch.Controls.Add(this.CategoryListBox);
            this.tabPageSearch.Controls.Add(this.productButton);
            this.tabPageSearch.Controls.Add(this.ProductTextBox);
            this.tabPageSearch.Location = new System.Drawing.Point(4, 22);
            this.tabPageSearch.Name = "tabPageSearch";
            this.tabPageSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSearch.Size = new System.Drawing.Size(826, 569);
            this.tabPageSearch.TabIndex = 0;
            this.tabPageSearch.Text = "Search";
            this.tabPageSearch.UseVisualStyleBackColor = true;
            // 
            // ProductListBox
            // 
            this.ProductListBox.FormattingEnabled = true;
            this.ProductListBox.Location = new System.Drawing.Point(173, 47);
            this.ProductListBox.Name = "ProductListBox";
            this.ProductListBox.Size = new System.Drawing.Size(637, 342);
            this.ProductListBox.TabIndex = 5;
            // 
            // CategoryListBox
            // 
            this.CategoryListBox.FormattingEnabled = true;
            this.CategoryListBox.Location = new System.Drawing.Point(6, 47);
            this.CategoryListBox.Name = "CategoryListBox";
            this.CategoryListBox.Size = new System.Drawing.Size(161, 342);
            this.CategoryListBox.TabIndex = 4;
            this.CategoryListBox.SelectedIndexChanged += new System.EventHandler(this.CategoryListBox_SelectedIndexChanged);
            // 
            // tabPageAdd
            // 
            this.tabPageAdd.Controls.Add(this.buttonClearProduct);
            this.tabPageAdd.Controls.Add(this.buttonAddProduct);
            this.tabPageAdd.Controls.Add(this.listBoxUpdate);
            this.tabPageAdd.Controls.Add(this.label10);
            this.tabPageAdd.Controls.Add(this.labelCategoryChoose);
            this.tabPageAdd.Controls.Add(this.radioButton2);
            this.tabPageAdd.Controls.Add(this.radioButton1);
            this.tabPageAdd.Controls.Add(this.CategoryDescriptionLabel);
            this.tabPageAdd.Controls.Add(this.CategoryDescriptionTextBox);
            this.tabPageAdd.Controls.Add(this.CategoryNameLabel);
            this.tabPageAdd.Controls.Add(this.CategoryNameTextBox);
            this.tabPageAdd.Controls.Add(this.CategoryComboBox);
            this.tabPageAdd.Controls.Add(this.label1);
            this.tabPageAdd.Controls.Add(this.numericUpDownProductStock);
            this.tabPageAdd.Controls.Add(this.comboBoxWeightUnit);
            this.tabPageAdd.Controls.Add(this.numericUpDownProductPrice);
            this.tabPageAdd.Controls.Add(this.numericUpDownProductDiscount);
            this.tabPageAdd.Controls.Add(this.label8);
            this.tabPageAdd.Controls.Add(this.label7);
            this.tabPageAdd.Controls.Add(this.label6);
            this.tabPageAdd.Controls.Add(this.label5);
            this.tabPageAdd.Controls.Add(this.label4);
            this.tabPageAdd.Controls.Add(this.label3);
            this.tabPageAdd.Controls.Add(this.label2);
            this.tabPageAdd.Controls.Add(this.textBoxProductName);
            this.tabPageAdd.Location = new System.Drawing.Point(4, 22);
            this.tabPageAdd.Name = "tabPageAdd";
            this.tabPageAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdd.Size = new System.Drawing.Size(826, 569);
            this.tabPageAdd.TabIndex = 1;
            this.tabPageAdd.Text = "Add";
            this.tabPageAdd.UseVisualStyleBackColor = true;
            // 
            // buttonClearProduct
            // 
            this.buttonClearProduct.Location = new System.Drawing.Point(71, 446);
            this.buttonClearProduct.Name = "buttonClearProduct";
            this.buttonClearProduct.Size = new System.Drawing.Size(75, 23);
            this.buttonClearProduct.TabIndex = 32;
            this.buttonClearProduct.Text = "Clear";
            this.buttonClearProduct.UseVisualStyleBackColor = true;
            this.buttonClearProduct.Click += new System.EventHandler(this.buttonClearProduct_Click);
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(167, 446);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(75, 23);
            this.buttonAddProduct.TabIndex = 31;
            this.buttonAddProduct.Text = "Add";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // listBoxUpdate
            // 
            this.listBoxUpdate.FormattingEnabled = true;
            this.listBoxUpdate.Location = new System.Drawing.Point(307, 10);
            this.listBoxUpdate.Name = "listBoxUpdate";
            this.listBoxUpdate.Size = new System.Drawing.Size(510, 550);
            this.listBoxUpdate.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(27, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 20);
            this.label10.TabIndex = 29;
            this.label10.Text = "Product";
            // 
            // labelCategoryChoose
            // 
            this.labelCategoryChoose.AutoSize = true;
            this.labelCategoryChoose.Location = new System.Drawing.Point(93, 269);
            this.labelCategoryChoose.Name = "labelCategoryChoose";
            this.labelCategoryChoose.Size = new System.Drawing.Size(43, 13);
            this.labelCategoryChoose.TabIndex = 28;
            this.labelCategoryChoose.Text = "Choose";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(60, 312);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(121, 17);
            this.radioButton2.TabIndex = 27;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Add a new Category";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(60, 243);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(145, 17);
            this.radioButton1.TabIndex = 26;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Choose Existing Category";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // CategoryDescriptionLabel
            // 
            this.CategoryDescriptionLabel.AutoSize = true;
            this.CategoryDescriptionLabel.Location = new System.Drawing.Point(68, 374);
            this.CategoryDescriptionLabel.Name = "CategoryDescriptionLabel";
            this.CategoryDescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.CategoryDescriptionLabel.TabIndex = 25;
            this.CategoryDescriptionLabel.Text = "Description";
            this.CategoryDescriptionLabel.Visible = false;
            // 
            // CategoryDescriptionTextBox
            // 
            this.CategoryDescriptionTextBox.Location = new System.Drawing.Point(142, 371);
            this.CategoryDescriptionTextBox.Name = "CategoryDescriptionTextBox";
            this.CategoryDescriptionTextBox.Size = new System.Drawing.Size(100, 20);
            this.CategoryDescriptionTextBox.TabIndex = 24;
            this.CategoryDescriptionTextBox.Visible = false;
            // 
            // CategoryNameLabel
            // 
            this.CategoryNameLabel.AutoSize = true;
            this.CategoryNameLabel.Location = new System.Drawing.Point(93, 344);
            this.CategoryNameLabel.Name = "CategoryNameLabel";
            this.CategoryNameLabel.Size = new System.Drawing.Size(35, 13);
            this.CategoryNameLabel.TabIndex = 23;
            this.CategoryNameLabel.Text = "Name";
            this.CategoryNameLabel.Visible = false;
            // 
            // CategoryNameTextBox
            // 
            this.CategoryNameTextBox.Location = new System.Drawing.Point(142, 341);
            this.CategoryNameTextBox.Name = "CategoryNameTextBox";
            this.CategoryNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.CategoryNameTextBox.TabIndex = 22;
            this.CategoryNameTextBox.Visible = false;
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(142, 266);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(100, 21);
            this.CategoryComboBox.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Category";
            // 
            // numericUpDownProductStock
            // 
            this.numericUpDownProductStock.DecimalPlaces = 2;
            this.numericUpDownProductStock.Location = new System.Drawing.Point(130, 129);
            this.numericUpDownProductStock.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownProductStock.Name = "numericUpDownProductStock";
            this.numericUpDownProductStock.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownProductStock.TabIndex = 17;
            // 
            // comboBoxWeightUnit
            // 
            this.comboBoxWeightUnit.FormattingEnabled = true;
            this.comboBoxWeightUnit.Location = new System.Drawing.Point(130, 102);
            this.comboBoxWeightUnit.Name = "comboBoxWeightUnit";
            this.comboBoxWeightUnit.Size = new System.Drawing.Size(112, 21);
            this.comboBoxWeightUnit.TabIndex = 16;
            // 
            // numericUpDownProductPrice
            // 
            this.numericUpDownProductPrice.DecimalPlaces = 2;
            this.numericUpDownProductPrice.Location = new System.Drawing.Point(130, 76);
            this.numericUpDownProductPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownProductPrice.Name = "numericUpDownProductPrice";
            this.numericUpDownProductPrice.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownProductPrice.TabIndex = 15;
            // 
            // numericUpDownProductDiscount
            // 
            this.numericUpDownProductDiscount.DecimalPlaces = 2;
            this.numericUpDownProductDiscount.Location = new System.Drawing.Point(130, 159);
            this.numericUpDownProductDiscount.Name = "numericUpDownProductDiscount";
            this.numericUpDownProductDiscount.Size = new System.Drawing.Size(112, 20);
            this.numericUpDownProductDiscount.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Discount (%)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Stock";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Weight Unit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Price ($)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(130, 50);
            this.textBoxProductName.MaxLength = 256;
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(112, 20);
            this.textBoxProductName.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 642);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageSearch.ResumeLayout(false);
            this.tabPageSearch.PerformLayout();
            this.tabPageAdd.ResumeLayout(false);
            this.tabPageAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProductStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProductPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProductDiscount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button productButton;
        private System.Windows.Forms.TextBox ProductTextBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSearch;
        private System.Windows.Forms.TabPage tabPageAdd;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownProductDiscount;
        private System.Windows.Forms.ListBox ProductListBox;
        private System.Windows.Forms.ListBox CategoryListBox;
        private System.Windows.Forms.Label CategoryDescriptionLabel;
        private System.Windows.Forms.TextBox CategoryDescriptionTextBox;
        private System.Windows.Forms.Label CategoryNameLabel;
        private System.Windows.Forms.TextBox CategoryNameTextBox;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownProductStock;
        private System.Windows.Forms.ComboBox comboBoxWeightUnit;
        private System.Windows.Forms.NumericUpDown numericUpDownProductPrice;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelCategoryChoose;
        private System.Windows.Forms.Button buttonClearProduct;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.ListBox listBoxUpdate;
    }
}

