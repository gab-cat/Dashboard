using Dashboard.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class UpdateItem : Form
    {
        private string employee_name;
        private string EmployeeName;
        private int productId;
        private bool changesMade = false;
        public UpdateItem(string EmployeeName, int productId)
        {
            InitializeComponent();
            employee_name = EmployeeName;

            LoadCategoryAndSupplierData();
            LoadProductDetails(productId); // Load product details for editing

            // Wire up TextChanged event handlers for input fields
            txtProductName.TextChanged += InputField_TextChanged;
            txtCostPrice.TextChanged += InputField_TextChanged;
            txtSellingPrice.TextChanged += InputField_TextChanged;
            txtCriticalStock.TextChanged += InputField_TextChanged;
            txtDescription.TextChanged += InputField_TextChanged;
            button1.Enabled = false;

            this.productId = productId; // Store the product ID for updating

        }

        private void InputField_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Check if the current text value is different from the original value (stored in Tag)
            if (textBox.Text != textBox.Tag.ToString())
            {
                changesMade = true;
            }
            else
            {
                changesMade = false;
            }

            // Enable or disable the "Save" button based on whether changes were made
            button1.Enabled = changesMade;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                // Retrieve updated values from the form controls
                string category = cboxCategory.Text.ToString();
                int supplierID = Convert.ToInt32(cboxSupplierID.SelectedItem);
                string productName = txtProductName.Text;
                decimal costPrice = Convert.ToDecimal(txtCostPrice.Text);
                decimal sellingPrice = Convert.ToDecimal(txtSellingPrice.Text);
                int criticalStock = Convert.ToInt32(txtCriticalStock.Text);
                string description = txtDescription.Text;

                // Create an SQL UPDATE statement
                string updateQuery = @"
                    UPDATE products
                    SET product_name = @productName, description = @description, 
                        category = @category, supplier_id = @supplierID, 
                        cost_price = @costPrice, selling_price = @sellingPrice, 
                        critical_quantity = @criticalStock
                    WHERE product_id = @productId";

                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    try
                    {
                        using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                        {
                            // Add parameters to the SQL command
                            command.Parameters.AddWithValue("@productId", productId);
                            command.Parameters.AddWithValue("@productName", productName);
                            command.Parameters.AddWithValue("@description", description);
                            command.Parameters.AddWithValue("@category", category);
                            command.Parameters.AddWithValue("@supplierID", supplierID);
                            command.Parameters.AddWithValue("@costPrice", costPrice);
                            command.Parameters.AddWithValue("@sellingPrice", sellingPrice);
                            command.Parameters.AddWithValue("@criticalStock", criticalStock);

                            // Execute the UPDATE command
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Failed to update the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            });

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCategoryAndSupplierData()
        {
            // Initialize lists to store unique values
            List<string> uniqueCategories = new List<string>();
            List<int> uniqueSupplierIDs = new List<int>();

            // Define your SQL queries to retrieve unique values
            string categoryQuery = "SELECT DISTINCT category FROM products";
            string supplierQuery = "SELECT DISTINCT supplier_id FROM products";

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    // Fetch unique categories
                    using (MySqlCommand categoryCommand = new MySqlCommand(categoryQuery, connection))
                    {
                        using (MySqlDataReader categoryReader = categoryCommand.ExecuteReader())
                        {
                            while (categoryReader.Read())
                            {
                                string category = categoryReader.GetString("category");
                                uniqueCategories.Add(category);
                            }
                        }
                    }

                    // Fetch unique supplier IDs
                    using (MySqlCommand supplierCommand = new MySqlCommand(supplierQuery, connection))
                    {
                        using (MySqlDataReader supplierReader = supplierCommand.ExecuteReader())
                        {
                            while (supplierReader.Read())
                            {
                                int supplierID = supplierReader.GetInt32("supplier_id");
                                uniqueSupplierIDs.Add(supplierID);
                            }
                        }
                    }

                    // Bind unique categories to cboxCategory
                    cboxCategory.DataSource = uniqueCategories;

                    // Bind unique supplier IDs to cboxSupplierID
                    cboxSupplierID.DataSource = uniqueSupplierIDs;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadProductDetails(int productId)
        {
            // Create an SQL query to retrieve product details by product ID
            string query = @"
        SELECT product_name, description, category, supplier_id, cost_price, selling_price, critical_quantity
        FROM products
        WHERE product_id = @productId";

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@productId", productId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate form controls with product details
                                txtProductName.Text = reader.GetString("product_name");
                                txtDescription.Text = reader.GetString("description");
                                cboxCategory.SelectedItem = reader.GetString("category");
                                cboxSupplierID.SelectedItem = reader.GetInt32("supplier_id");
                                txtCostPrice.Text = reader.GetDecimal("cost_price").ToString();
                                txtSellingPrice.Text = reader.GetDecimal("selling_price").ToString();
                                txtCriticalStock.Text = reader.GetInt32("critical_quantity").ToString();

                                // Set the Tag property for each control with its original value
                                txtProductName.Tag = txtProductName.Text;
                                txtDescription.Tag = txtDescription.Text;
                                cboxCategory.Tag = cboxCategory.SelectedItem;
                                cboxSupplierID.Tag = cboxSupplierID.SelectedItem;
                                txtCostPrice.Tag = txtCostPrice.Text;
                                txtSellingPrice.Tag = txtSellingPrice.Text;
                                txtCriticalStock.Tag = txtCriticalStock.Text;
                            }
                            else
                            {
                                MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close(); // Close the form if the product is not found
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
