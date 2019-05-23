﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace COMPX323_Project
{
    public partial class Form1 : Form
    {
        public Oracle oracle;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            String datasource = "oracle.cms.waikato.ac.nz:1521/teaching.cms.waikato.ac.nz";
            String userid = "COMPX323_20";
            String password = "CYVchCFW4p";
            oracle = new Oracle(datasource, userid, password);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            //get all categories
            handleCateories();

            //get all weight units
            handleWeightUnits();

            updateProducts();
        }

        private void handleWeightUnits()
        {
            comboBoxWeightUnit.Items.Clear();
            List<String> weightUnitList = oracle.getWeightUnits();

            foreach(String weight_unit in weightUnitList)
            {
                comboBoxWeightUnit.Items.Add(weight_unit);
            }
        }

        private void handleCateories()
        {
            try
            {
                List<Category> categoryList = oracle.getCategories("select * from category");
                CategoryListBox.Refresh();

                foreach(Category category in categoryList)
                {
                    CategoryListBox.Items.Add(category.name);
                    CategoryComboBox.Items.Add(category.name);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred\n" + e);
            }
        }

        private void productButton_Click(object sender, EventArgs e)
        {
            try
            {
                String input = ProductTextBox.Text;

                if (input == "")
                {
                    MessageBox.Show("No Input for the search");
                }
                else
                {
                    ProductListBox.Items.Clear();
                    //get the list of products returned from the query
                    List<Product> productList = oracle.getProducts("select * from product where lower(name) like lower('%"+input+"%')");

                    //for each product returned
                    foreach (Product product in productList)
                    {
                        ProductListBox.Items.Add(product.ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occurred\n" + ex);
            }

        }

        private void CategoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = CategoryListBox.SelectedIndex;
            ProductListBox.Items.Clear();

            String category = CategoryListBox.Items[index].ToString();

            List<Product> productList = oracle.getProducts(
                "select serial_number, product.name, price, weight_unit, stock, discount " +
                "from product, category " +
                "where product.category_name = category.name "+
                "and lower(category.name) like lower('%"+category+"%')");

            foreach (Product product in productList)
            {
                ProductListBox.Items.Add(product.ToString());
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            CategoryComboBox.Visible = true;
            labelCategoryChoose.Visible = true;
            CategoryNameLabel.Visible = false;
            CategoryNameTextBox.Visible = false;
            CategoryDescriptionLabel.Visible = false;
            CategoryDescriptionTextBox.Visible = false;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            CategoryComboBox.Visible = false;
            labelCategoryChoose.Visible = false;
            CategoryNameLabel.Visible = true;
            CategoryNameTextBox.Visible = true;
            CategoryDescriptionLabel.Visible = true;
            CategoryDescriptionTextBox.Visible = true;
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                String name = textBoxProductName.Text;
                decimal price = decimal.Parse(numericUpDownProductPrice.Text);
                String weight_unit = comboBoxWeightUnit.Text;
                decimal stock = decimal.Parse(numericUpDownProductStock.Text);
                decimal discount = decimal.Parse(numericUpDownProductDiscount.Text);
                String category = "";
                String desciption = "";

                if (CategoryComboBox.Visible)
                {
                    //get the value of the chosen category
                    category = CategoryComboBox.SelectedText;
                }
                else
                {
                    //get the value of the new category
                    category = CategoryNameTextBox.Text;
                    desciption = CategoryDescriptionTextBox.Text;

                    //check if the category inputs are valid
                    if (category == "" || desciption == "")
                    {
                        //one of them was empty so we show an error message and return
                        MessageBox.Show("Need to enter a name and description for the new category");
                        return;
                    }
                }

                //the category input is validated, check if it exists in the database
                if (oracle.checkCategory(category))
                {
                    //it exists so we cannot add it
                    //notiy the user
                    MessageBox.Show("Category '" + category + "' already exists... You should select 'Choose Existing Category'");
                    return;
                }

                //it doesnt exists so we can insert it into the database
                oracle.Execute("insert into category values('" + category + "', '" + desciption + "')");

                oracle.reader.Close();
                oracle.conn.Dispose();
                    
                //check if any of the inputs that need validating are invalid
                if(name == "" || price == 0 || weight_unit == "" || stock == 0)
                {
                    //one or more inputs were invalid so we show the values to the user
                    MessageBox.Show(
                        "Invalid Input : " +
                        "\nname: " + name + " -> Cannot be empty" +
                        "\nprice: " + price.ToString() + " -> Cannot be zero " +
                        "\nweight_unit: " + weight_unit + " -> Need to select one " +
                        "\nstock: " + stock.ToString() + " -> Cannot be zero "
                        );
                    return;
                }
                else
                {
                    //all inputs were valid
                    //insert the product into the database
                    String query = "insert into product values(product_sequence.NEXTVAL, '"+name+"', "+price+", '"+weight_unit+"', "+stock+", "+discount+", '"+category+"')";
                    oracle.Execute(query);

                    //Notify the user
                    MessageBox.Show("Product successfully added");
                    Clear();
                    updateProducts();
                    
                }
            }
            catch(Exception ex){
                //if an error occurs at any moment
                Console.WriteLine(ex);
                MessageBox.Show("Product not successfully added");
                return;
            }
        }


        private void Clear()
        {
            textBoxProductName.ResetText();
            numericUpDownProductPrice.ResetText();
            comboBoxWeightUnit.ResetText();
            numericUpDownProductStock.ResetText();
            numericUpDownProductDiscount.ResetText();
            CategoryComboBox.ResetText();
            CategoryNameTextBox.ResetText();
            CategoryDescriptionTextBox.ResetText();
        }

        private void buttonClearProduct_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void updateProducts()
        {
            try
            {
                listBoxUpdate.Items.Clear();
                //get the list of products returned from the query
                List<Product> productList = oracle.getProducts("select * from product");

                //for each product returned
                foreach (Product product in productList)
                {
                    listBoxUpdate.Items.Add(product.ToString());
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("An error occured");
                return;
            }
        }
    }
}
