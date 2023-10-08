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

namespace Dashboard.Forms
{
    public partial class FormInventory : Form
    {
        private string employee_name;
        private string role;
        private DataTable originalProductData;
        public FormInventory(string employee_name, string role)
        {
            InitializeComponent();
            this.employee_name = employee_name;
            this.role = role;
            LoadProductData();
            cboxFilter.SelectedIndex = 0;
        }
        private void LoadTheme()
        {
            ProductGrid.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.SecondaryColor;
            ProductGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            ProductGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            ProductGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;
            ProductGrid.DefaultCellStyle.SelectionForeColor = Color.White;
            ProductGrid.DefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;

            foreach (DataGridViewColumn col in ProductGrid.Columns)
            {
                col.Resizable = DataGridViewTriState.True;
            }


            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.SecondaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }

            foreach (Control btns in groupBox1.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.SecondaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }

            foreach (Control btns in groupBox2.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.SecondaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }


        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            LoadTheme();
            // Load data into originalProductData (your data loading logic here)
            originalProductData = LoadProductDatas();

            // Populate the ComboBox with categories and select "All Items" by default
            PopulateCategoryComboBox();
            cboxProductCategory.SelectedIndex = -1; // Select "All Items" by default

            // Set the DataGridView data source to the original data
            ProductGrid.DataSource = originalProductData;
        }

        private DataTable LoadProductDatas()
        {
            DataTable dataTable = new DataTable();

            // Define your SQL query to retrieve product data
            string query = @"
        SELECT product_id AS 'Product ID', product_name AS 'Product Name', 
               description AS 'Description', category AS 'Category', 
               supplier_id AS 'Supplier ID', cost_price AS 'Cost Price', 
               selling_price AS 'Selling Price', 
               quantity_in_stock AS 'Quantity in Stock', 
               critical_quantity AS 'Critical Quantity'
        FROM products";

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return dataTable;
        }

        private void LoadProductData()
        {
            // Define your SQL query to retrieve product data
            string query = @"
        SELECT product_id AS 'Product ID', product_name AS 'Product Name', 
               description AS 'Description', category AS 'Category', 
               supplier_id AS 'Supplier ID', cost_price AS 'Cost Price', 
               selling_price AS 'Selling Price', 
               quantity_in_stock AS 'Quantity in Stock', 
               critical_quantity AS 'Critical Quantity'
        FROM products";

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Bind the DataGridView to the DataTable
                            ProductGrid.DataSource = dataTable;

                            // Set column widths individually
                            ProductGrid.Columns["Product ID"].Width = 60;
                            ProductGrid.Columns["Product Name"].Width = 100;
                            ProductGrid.Columns["Description"].Width = 150;
                            ProductGrid.Columns["Category"].Width = 100;
                            ProductGrid.Columns["Supplier ID"].Width = 50;
                            ProductGrid.Columns["Cost Price"].Width = 70;
                            ProductGrid.Columns["Selling Price"].Width = 70;
                            ProductGrid.Columns["Quantity in Stock"].Width = 50;
                            ProductGrid.Columns["Critical Quantity"].Width = 50;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                NewItem form = new NewItem(employee_name);
                form.Show();
            });
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                if (ProductGrid.SelectedRows.Count > 0)
                {
                    int selectedProductID = Convert.ToInt32(ProductGrid.SelectedRows[0].Cells["Product ID"].Value);
                    DialogResult confirmationResult = MessageBox.Show("Are you sure you want to delete this product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmationResult == DialogResult.Yes)
                    {
                        // Create an SQL DELETE statement
                        string deleteQuery = "DELETE FROM products WHERE product_id = @productID";

                        using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                        {
                            try
                            {
                                using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@productID", selectedProductID);
                                    int rowsAffected = command.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to delete the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                else
                {
                    MessageBox.Show("Please select a product to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });

        }
        private void PopulateCategoryComboBox()
        {
            // Create a HashSet to store unique category values
            HashSet<string> uniqueCategories = new HashSet<string>();
            cboxProductCategory.Items.Insert(0, "All Items");

            // Iterate through the originalProductData to collect unique category values
            foreach (DataRow row in originalProductData.Rows)
            {
                if (!row.IsNull("Category"))
                {
                    uniqueCategories.Add(row.Field<string>("Category"));
                }
            }

            // Bind the HashSet to the ComboBox
            cboxProductCategory.DataSource = new BindingSource(uniqueCategories.ToList(), null);
        }

        private void cboxProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected category from the ComboBox
            string selectedCategory = cboxProductCategory.SelectedItem as string;

            // Filter the original data source based on the selected category
            DataView filteredView = originalProductData.DefaultView;

            if (selectedCategory != null)
            {
                if (selectedCategory != "All Items")
                {
                    filteredView.RowFilter = $"Category = '{selectedCategory}'";
                }
                else
                {
                    filteredView.RowFilter = string.Empty; // Show all items
                }
            }
            else
            {
                filteredView.RowFilter = string.Empty; // Show all items if no category selected
            }

            // Update the DataGridView with the filtered data
            ProductGrid.DataSource = filteredView.ToTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cboxProductCategory.SelectedIndex = -1;
        }
        private void PerformSearch()
        {
            // Get the selected filter criteria
            string selectedFilter = cboxFilter.SelectedItem as string;
            string searchKeyword = txtSearchTerm.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchKeyword))
            {
                MessageBox.Show("Please enter a search keyword.", "Empty Search Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Filter the originalProductData based on the selected filter criteria and search keyword
            DataView filteredView = originalProductData.DefaultView;

            switch (selectedFilter)
            {
                case "Product ID":
                    filteredView.RowFilter = $"[Product ID] = '{searchKeyword}'";
                    break;
                case "Category":
                    filteredView.RowFilter = $"Category LIKE '%{searchKeyword}%'";
                    break;
                case "Item Name":
                    filteredView.RowFilter = $"[Product Name] LIKE '%{searchKeyword}%'";
                    break;
                case "Supplier ID":
                    filteredView.RowFilter = $"[Supplier ID] = '{searchKeyword}'";
                    break;
                default:
                    MessageBox.Show("Invalid filter criteria selected.");
                    return;
            }

            // Update the DataGridView with the filtered data
            ProductGrid.DataSource = filteredView.ToTable();

            if (ProductGrid.Rows.Count == 0)
            {
                MessageBox.Show("No matching items found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                PerformSearch();
            });
        }

        private void txtSearchTerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadingScreenManager.ShowLoadingScreen(() =>
                {
                    PerformSearch();
                });
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {

            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                if (ProductGrid.SelectedRows.Count > 0)
                {
                    // Get the selected product's ID from the DataGridView
                    int selectedProductID = Convert.ToInt32(ProductGrid.SelectedRows[0].Cells["Product ID"].Value);

                    // Create an instance of the UpdateItem form and pass the selected product ID
                    UpdateItem updateForm = new UpdateItem(employee_name, selectedProductID);

                    // Show the UpdateItem form as a dialog
                    updateForm.Show();
                }
                else
                {
                    MessageBox.Show("Please select a product to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });

        }
    }
}
