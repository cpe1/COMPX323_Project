using System;
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
        public MongoDB mongodb;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            //settings for the oracle db
            String datasource = "oracle.cms.waikato.ac.nz:1521/teaching.cms.waikato.ac.nz";
            String userid = "COMPX323_20";
            String password = "CYVchCFW4p";
            oracle = new Oracle(datasource, userid, password);

            //settings for the mongo db
            String mongo_username = "compx323-20";
            String mongo_password = "cNTKWiq5JY7gDhsrZRi9";
            String mongo_hostname = "mongodb.cms.waikato.ac.nz";
            String database = "admin";
            int port = 27017;

            mongodb = new MongoDB(mongo_username, mongo_password, mongo_hostname, port, database);
            mongodb.databases();
            mongodb.collections();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            setupSQL();
            setupNoSQL();
        }

        private void setupSQL()
        {
            radioButton1.Checked = true;
            //get all categories
            handleCateories();

            //get all weight units
            handleWeightUnits();

            updateProducts();
        }

        public void setupNoSQL()
        {
            radioButton1NO.Checked = true;

            //get all categories
            handleCateoriesNO();

            //get all weight units
            handleWeightUnitsNO();

            updateProductsNO();
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
        private void handleWeightUnitsNO()
        {
            comboBoxWeightUnitNO.Items.Clear();
            List<String> weightUnitList = mongodb.getWeightUnits();

            foreach (String weight_unit in weightUnitList)
            {
                comboBoxWeightUnitNO.Items.Add(weight_unit);
            }
        }

        private void handleCateories()
        {
            try
            {
                List<Category> categoryList = oracle.getCategories("select * from category");
                CategoryListBox.Items.Clear();
                CategoryComboBox.Items.Clear();

                foreach (Category category in categoryList)
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

        private void handleCateoriesNO()
        {
            try
            {
                List<Category> categoryList = mongodb.getAllCategories();
                CategoryListBoxNO.Items.Clear();
                CategoryComboBoxNO.Items.Clear();

                foreach (Category category in categoryList)
                {
                    CategoryListBoxNO.Items.Add(category.name);
                    CategoryComboBoxNO.Items.Add(category.name);
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

                    if (productList.Count == 0)
                    {
                        MessageBox.Show("No results");
                        return;
                    }

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
                bool newCategory = false;

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
                else
                {
                    newCategory = true;
                }

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
                    if (newCategory)
                    {
                        oracle.Execute("insert into category values('" + category + "', '" + desciption + "')");
                    }
                    //insert the product into the database
                    String query = "insert into product values(product_sequence.NEXTVAL, '"+name+"', "+price+", '"+weight_unit+"', "+stock+", "+discount+", '"+category+"')";
                    oracle.Execute(query);

                    //Notify the user
                    MessageBox.Show("Product successfully added");
                    Clear();
                    updateProducts();
                    handleCateories();

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

        private void ClearNO()
        {
            textBoxProductNameNO.ResetText();
            numericUpDownProductPriceNO.ResetText();
            comboBoxWeightUnitNO.ResetText();
            numericUpDownProductStockNO.ResetText();
            numericUpDownProductDiscountNO.ResetText();
            CategoryComboBoxNO.ResetText();
            CategoryNameTextBoxNO.ResetText();
            CategoryDescriptionTextBoxNO.ResetText();
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

        private void updateProductsNO()
        {
            try
            {
                listBoxUpdateNO.Items.Clear();

                //get the list of products returned from the query
                List<Product> productList = mongodb.getAllProducts();

                foreach(Product product in productList)
                {
                    listBoxUpdateNO.Items.Add(product.ToString());
                }
            }catch(Exception e)
            {
                MessageBox.Show("An error occured: " + e);
                return;
            }
        }

        private void buttonClearProductNO_Click(object sender, EventArgs e)
        {
            ClearNO();
        }

        private void buttonAddProductNO_Click(object sender, EventArgs e)
        {
            try
            {
                String name = textBoxProductNameNO.Text;
                decimal price = decimal.Parse(numericUpDownProductPriceNO.Text);
                String weight_unit = comboBoxWeightUnitNO.Text;
                decimal stock = decimal.Parse(numericUpDownProductStockNO.Text);
                decimal discount = decimal.Parse(numericUpDownProductDiscountNO.Text);
                String category = "";
                String description = "";
                bool newCategory = false;

                if (CategoryComboBoxNO.Visible)
                {
                    //get the value of the chosen category
                    category = CategoryComboBoxNO.SelectedText;
                }
                else
                {
                    //get the value of the new category
                    category = CategoryNameTextBoxNO.Text;
                    description = CategoryDescriptionTextBoxNO.Text;

                    //check if the category inputs are valid
                    if (category == "" || description == "")
                    {
                        //one of them was empty so we show an error message and return
                        MessageBox.Show("Need to enter a name and description for the new category");
                        return;
                    }


                    //the category input is validated, check if it exists in the database
                    if (mongodb.checkCategory(category))
                    {
                        //it exists so we cannot add it
                        //notiy the user
                        MessageBox.Show("Category '" + category + "' already exists... You should select 'Choose Existing Category'");
                        return;
                    }
                    else
                    {
                        newCategory = true;
                    }

                }
                

                //oracle.reader.Close();
                //oracle.conn.Dispose();

                //check if any of the inputs that need validating are invalid
                if (name == "" || price == 0 || weight_unit == "" || stock == 0)
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
                    //check if we need to add the new category
                    if (newCategory)
                    {
                        //insert the category into the database
                        mongodb.insertCategory(category, description);
                    }
                    
                    //insert the product into the database
                    mongodb.insertProduct(name, price, weight_unit, stock, discount, category);

                    //Notify the user
                    MessageBox.Show("Product successfully added");
                    ClearNO();
                    updateProductsNO();
                    handleCateoriesNO();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex);
            }
        }

        private void radioButton1NO_Click(object sender, EventArgs e)
        {
            CategoryComboBoxNO.Visible = true;
            labelCategoryChooseNO.Visible = true;
            CategoryNameLabelNO.Visible = false;
            CategoryNameTextBoxNO.Visible = false;
            CategoryDescriptionLabelNO.Visible = false;
            CategoryDescriptionTextBoxNO.Visible = false;
        }

        private void radioButton2NO_Click(object sender, EventArgs e)
        {
            CategoryComboBoxNO.Visible = false;
            labelCategoryChooseNO.Visible = false;
            CategoryNameLabelNO.Visible = true;
            CategoryNameTextBoxNO.Visible = true;
            CategoryDescriptionLabelNO.Visible = true;
            CategoryDescriptionTextBoxNO.Visible = true;
        }

        private void productButtonNO_Click(object sender, EventArgs e)
        {
            try
            {
                String input = ProductTextBoxNO.Text;

                if (input == "")
                {
                    MessageBox.Show("No Input for the search");
                }
                else
                {
                    ProductListBoxNO.Items.Clear();
                    //get the list of products returned from the query
                    List<Product> productList = mongodb.getProducts("name", input);

                    
                    if(productList.Count == 0)
                    {
                        MessageBox.Show("No results");
                        return;
                    }

                    //for each product returned
                    foreach (Product product in productList)
                    {
                        ProductListBoxNO.Items.Add(product.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred\n" + ex);
            }

        }

        private void CategoryListBoxNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = CategoryListBoxNO.SelectedIndex;
            ProductListBoxNO.Items.Clear();

            String category = CategoryListBoxNO.Items[index].ToString();

            List<Product> productList = mongodb.getProducts("category", category);

            foreach (Product product in productList)
            {
                ProductListBoxNO.Items.Add(product.ToString());
            }
        }
    }
}
