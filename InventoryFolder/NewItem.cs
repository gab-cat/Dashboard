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
    public partial class NewItem : Form
    {
        private string employee_name;
        MySqlConnection connection;
        public NewItem(string EmployeeName, MySqlConnection connection)
        {
            InitializeComponent();
            employee_name = EmployeeName;
            this.connection = connection;

            LoadCategoryAndSupplierData();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string category;
            int supplierID;
            string productName;
            decimal costPrice;
            decimal sellingPrice;
            int criticalStock;
            string description;

            try
            {
                // Retrieve values from the form controls
                category = cboxCategory.Text.ToString();
                supplierID = Convert.ToInt32(cboxSupplierID.SelectedItem);
                productName = txtProductName.Text;
                costPrice = Convert.ToDecimal(txtCostPrice.Text);
                sellingPrice = Convert.ToDecimal(txtSellingPrice.Text);
                criticalStock = Convert.ToInt32(txtCriticalStock.Text);
                description = txtDescription.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fiels cannot be empty. Please make sure to fill up all fields.\nError: " + ex , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadingScreenManager.ShowLoadingScreen(() =>
            {

                // Create an SQL INSERT statement
                string insertQuery = @"
        INSERT INTO products (product_name, description, category, supplier_id, cost_price, selling_price, quantity_in_stock, critical_quantity)
        VALUES (@productName, @description, @category, @supplierID, @costPrice, @sellingPrice, 0, @criticalStock)";

                using (connection)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    MySqlTransaction transaction = null;

                    try
                    {
                        transaction = connection.BeginTransaction();
                        using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                        {
                            // Add parameters to the SQL command
                            command.Parameters.AddWithValue("@productName", productName);
                            command.Parameters.AddWithValue("@description", description);
                            command.Parameters.AddWithValue("@category", category);
                            command.Parameters.AddWithValue("@supplierID", supplierID);
                            command.Parameters.AddWithValue("@costPrice", costPrice);
                            command.Parameters.AddWithValue("@sellingPrice", sellingPrice);
                            command.Parameters.AddWithValue("@criticalStock", criticalStock);

                            // Execute the INSERT command
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                transaction.Commit();
                                string systemMemo = $"New Product {productName} {Environment.NewLine}Added by {employee_name}. Effective as of {DateTime.Now}.";
                                AddInvMemo addmemo = new AddInvMemo(employee_name, "New Product", systemMemo);
                                addmemo.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Failed to add the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction?.Rollback();
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

            using (connection )
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

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

        private void txtCostPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.' && txtCostPrice.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtSellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.' && txtSellingPrice.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtCriticalStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
