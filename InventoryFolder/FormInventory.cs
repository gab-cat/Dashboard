using iTextSharp.text;
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
        private int product_id;
        private string employee_name;
        private string role;
        private DataTable originalProductData;
        private DataTable priceHistoryTable;
        private DataTable memoDataTable;

        public FormInventory(string employee_name, string role)
        {
            InitializeComponent();
            this.employee_name = employee_name;
            this.role = role;
            LoadProductData();

            loadMemos();
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

            dgvPriceHistory.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.SecondaryColor;
            dgvPriceHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPriceHistory.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvPriceHistory.ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;

            dataGridViewMemos.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.SecondaryColor;
            dataGridViewMemos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewMemos.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewMemos.ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;

            StockGrid.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.SecondaryColor;
            StockGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            StockGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            StockGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;

            lblLastUpdate.ForeColor = ThemeColor.SecondaryColor;
            lblProductName.ForeColor = ThemeColor.SecondaryColor;
            button1.OnHoverBaseColor = ThemeColor.SecondaryColor;

            chkRestock.CheckedOnColor = ThemeColor.SecondaryColor;

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


            btnDeleteProduct.BackColor = Color.White;
            btnDeleteProduct.ForeColor = ThemeColor.SecondaryColor;
            btnDeleteProduct.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            btnDeleteStockItem.BackColor = Color.White;
            btnDeleteStockItem.ForeColor = ThemeColor.SecondaryColor;
            btnDeleteStockItem.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            btnClear.BackColor = Color.White;
            btnClear.ForeColor = ThemeColor.SecondaryColor;
            btnClear.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            btnRemoveStocks.BackColor = Color.White;
            btnRemoveStocks.ForeColor = ThemeColor.SecondaryColor;
            btnRemoveStocks.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            button2.BackColor = Color.White;
            button2.ForeColor = ThemeColor.SecondaryColor;
            button2.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

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

            // Add columns to StockGrid
            StockGrid.Columns.Add("Product ID","ID");            
            StockGrid.Columns.Add("Product Name", "Product");      
            StockGrid.Columns.Add("Add/Sub", "Add/Sub");
            StockGrid.Columns.Add("Quantity", "Qty");              
            StockGrid.Columns.Add("Current Stock", "Current");     
            StockGrid.Columns.Add("After Stock", "After");         

            // Set column widths
            StockGrid.Columns["Product ID"].Width = 50;
            StockGrid.Columns["Product Name"].Width = 110;
            StockGrid.Columns["Add/Sub"].Width = 50;
            StockGrid.Columns["Quantity"].Width = 50;
            StockGrid.Columns["Current Stock"].Width = 50;
            StockGrid.Columns["After Stock"].Width = 50;
        }

        private DataTable LoadProductDatas()
        {
            DataTable dataTable = new DataTable();

            string query = @"
    SELECT product_id AS 'Product ID', product_name AS 'Product Name', 
           description AS 'Description', category AS 'Category', 
           supplier_id AS 'Supplier ID', cost_price AS 'Cost Price', 
           selling_price AS 'Selling Price', 
           quantity_in_stock AS 'Quantity in Stock', 
           critical_quantity AS 'Critical Quantity'
    FROM products
    ORDER BY CASE
             WHEN quantity_in_stock < critical_quantity THEN 0
             ELSE 1
           END ASC, product_id ASC"; // Order by critical quantity condition and then by Product ID in ascending order

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
            string query = @"
    SELECT product_id AS 'Product ID', product_name AS 'Product Name', 
           description AS 'Description', category AS 'Category', 
           supplier_id AS 'Supplier ID', cost_price AS 'Cost Price', 
           selling_price AS 'Selling Price', 
           quantity_in_stock AS 'Quantity in Stock', 
           critical_quantity AS 'Critical Quantity'
    FROM products
    ORDER BY CASE
             WHEN quantity_in_stock < critical_quantity THEN 0
             ELSE 1
           END ASC, product_id ASC"; // Order by critical quantity condition and then by Product ID in ascending order

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
            if (ProductGrid.SelectedRows.Count > 0)
            {
                LoadingScreenManager.ShowLoadingScreen(() =>
                {
                    int selectedProductID = Convert.ToInt32(ProductGrid.SelectedRows[0].Cells["Product ID"].Value);
                    string productName = Convert.ToString(ProductGrid.SelectedRows[0].Cells["Product Name"].Value);

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
                                        string systemMemo = $"Product ID {selectedProductID} ({productName}) was deleted.";
                                        AddInvMemo addmemo = new AddInvMemo(employee_name, "Delete Product", systemMemo);
                                        addmemo.Show();
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
                });
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                txtSearchTerm.Text = "No matching items found";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearchTerm.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchKeyword))
            {
                MessageBox.Show("Please enter a search keyword.", "Empty Search Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                PerformSearch();
            });
        }

        private void txtSearchTerm_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                string searchKeyword = txtSearchTerm.Text.Trim();
                if (string.IsNullOrWhiteSpace(searchKeyword))
                {
                    MessageBox.Show("Please enter a search keyword.", "Empty Search Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoadingScreenManager.ShowLoadingScreen(() =>
                {
                    PerformSearch();
                });
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {

            if (ProductGrid.SelectedRows.Count > 0)
            {
                LoadingScreenManager.ShowLoadingScreen(() =>
                {
                    // Get the selected product's ID from the DataGridView
                    int selectedProductID = Convert.ToInt32(ProductGrid.SelectedRows[0].Cells["Product ID"].Value);

                    // Create an instance of the UpdateItem form and pass the selected product ID
                    UpdateItem updateForm = new UpdateItem(employee_name, selectedProductID);

                    // Show the UpdateItem form as a dialog
                    updateForm.Show();
                });
            }
            else
            {
                MessageBox.Show("Please select a product to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable LoadPriceHistory(int productId)
        {
            // Create a DataTable to store the price history data
            DataTable priceHistoryTable = new DataTable();

            // Define your SQL query to retrieve price history data for the selected product
            string query = @"
        SELECT effective_date, price, employee_name, user_text
        FROM price_history
        WHERE product_id = @productId
        ORDER BY effective_date DESC"; // Order by effective_date in descending order

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@productId", productId);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            // Fill the DataTable with price history data
                            adapter.Fill(priceHistoryTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return priceHistoryTable;
        }

        private void LoadPriceHistoryForSelectedProduct(int productId, string productName)
        {
            // Initialize the DataTable and load the price history data
            priceHistoryTable = new DataTable();
            priceHistoryTable = LoadPriceHistory(productId);

            // Bind the DataGridView to the DataTable
            dgvPriceHistory.DataSource = priceHistoryTable;

            // Set column headers (you can customize these as needed)
            dgvPriceHistory.Columns["effective_date"].HeaderText = "Effective Date";
            dgvPriceHistory.Columns["price"].HeaderText = "Price";
            dgvPriceHistory.Columns["employee_name"].HeaderText = "Employee Name"; // Add this line to set the column header

            // Hide the user_text column in the DataGridView
            dgvPriceHistory.Columns["user_text"].Visible = false;

            // Display the product name in lblProductName
            lblProductName.Text = productName;

            // Check if there are any rows in the price history
            if (priceHistoryTable.Rows.Count > 0)
            {
                // Get the latest effective_date from the first row
                DateTime latestDate = (DateTime)priceHistoryTable.Rows[0]["effective_date"];
                lblLastUpdate.Text = "Last Update: " + latestDate.ToString("yyyy-MM-dd HH:mm:ss");

                // Display the user_text for the latest row in txtMemo
                string latestUserText = priceHistoryTable.Rows[0]["user_text"].ToString();
                string latestEmployeeName = priceHistoryTable.Rows[0]["employee_name"].ToString();
                txtMemoPH.Text = "Processed by: " + Environment.NewLine + latestEmployeeName + Environment.NewLine + Environment.NewLine + latestUserText;
            }
            else
            {
                lblLastUpdate.Text = "Last Update: N/A"; // No price history available
                txtMemoPH.Text = ""; // Clear txtMemo when there's no price history
            }
        }


        private void ProductGrid_SelectionChanged(object sender, EventArgs e)
        {
            // Price History
            if (ProductGrid.SelectedRows.Count > 0)
            {
                int productId = Convert.ToInt32(ProductGrid.SelectedRows[0].Cells["Product ID"].Value);
                string productName = Convert.ToString(ProductGrid.SelectedRows[0].Cells["Product Name"].Value);
                LoadPriceHistoryForSelectedProduct(productId, productName);
            }
            else
            {
                dgvPriceHistory.DataSource = null;
                lblProductName.Text = "";
                lblLastUpdate.Text = "Last Update: N/A";
                txtMemoPH.Text = "";
            }

            // Stock Management
            if (ProductGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = ProductGrid.SelectedRows[0];


                string quantityInStock = selectedRow.Cells["Quantity in Stock"].Value.ToString();
                string costPrice = selectedRow.Cells["Cost Price"].Value.ToString();
                string sellingPrice = selectedRow.Cells["Selling Price"].Value.ToString();
                string productName = selectedRow.Cells["Product Name"].Value.ToString();
                string productID = selectedRow.Cells["Product ID"].Value.ToString();
                string category = selectedRow.Cells["Category"].Value.ToString();

                txtQuantityInStock.Text = quantityInStock;
                txtCostPrice.Text = "₱ " +costPrice;
                txtSellingPrice.Text = "₱ " + sellingPrice;
                txtProductName.Text = productName;
                txtProductID.Text = productID;
                txtCategory.Text = category;
            }
            else
            {
                txtQuantityInStock.Text = "";
                txtCostPrice.Text = "";
                txtSellingPrice.Text = "";
            }

            if (chkRestock.Checked == true)
            {
                txtQuantity.Focus();
            }

        }

        private void dgvPriceHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPriceHistory.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dgvPriceHistory.SelectedRows[0].Index;
                if (selectedRowIndex >= 0 && selectedRowIndex < priceHistoryTable.Rows.Count)
                {
                    string userText = priceHistoryTable.Rows[selectedRowIndex]["user_text"].ToString();
                    string employeeName = priceHistoryTable.Rows[selectedRowIndex]["employee_name"].ToString();

                    txtMemoPH.Text = "Processed by: " + Environment.NewLine + employeeName + Environment.NewLine + Environment.NewLine + userText;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cboxProductCategory.SelectedIndex = -1;
        }

        private void loadMemos()
        {
            int customerId = 9999;
            memoDataTable = new DataTable();
            memoDataTable.Columns.Add("time_date", typeof(DateTime));
            memoDataTable.Columns.Add("reason", typeof(string));
            memoDataTable.Columns.Add("employee_name", typeof(string));
            memoDataTable.Columns.Add("memo_text", typeof(string)); // Add "memo_text" column

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    string query = "SELECT time_date, reason, employee_name, memo_text FROM memos WHERE customer_id = @customer_id ORDER BY time_date DESC;";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customer_id", customerId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Extract memo details here.
                                DateTime timeDate = reader.GetDateTime("time_date");
                                string reason = reader.GetString("reason");
                                string employeeName = reader.GetString("employee_name");
                                string memoText = reader.GetString("memo_text");

                                // Add a new row to the DataTable
                                memoDataTable.Rows.Add(timeDate, reason, employeeName, memoText);
                            }
                        }
                    }

                    // Bind the DataTable to the DataGridView
                    dataGridViewMemos.DataSource = memoDataTable;

                    // Optionally, set column headers
                    dataGridViewMemos.Columns["time_date"].HeaderText = "Date and Time";
                    dataGridViewMemos.Columns["reason"].HeaderText = "Reason";
                    dataGridViewMemos.Columns["employee_name"].HeaderText = "Employee Name";
                    if (dataGridViewMemos.Columns.Contains("memo_text"))
                    {
                        dataGridViewMemos.Columns["memo_text"].Visible = false;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void btnAddInvMemo_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                AddInvMemo addmemo = new AddInvMemo(employee_name);
                addmemo.Show();
            });
        }

        private void dataGridViewMemos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewMemos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewMemos.SelectedRows[0];
                object selectedTimeDate = selectedRow.Cells["time_date"].Value;
                object selectedReason = selectedRow.Cells["reason"].Value;
                object selectedEmployeeName = selectedRow.Cells["employee_name"].Value;

                // Find the corresponding row in the memoDataTable based on time_date, reason, and employee_name
                DataRow selectedMemoRow = memoDataTable.AsEnumerable()
                    .FirstOrDefault(row =>
                        row.Field<DateTime>("time_date") == (DateTime)selectedTimeDate &&
                        row.Field<string>("reason") == (string)selectedReason &&
                        row.Field<string>("employee_name") == (string)selectedEmployeeName);

                if (selectedMemoRow != null)
                {
                    string selectedMemoText = selectedMemoRow.Field<string>("memo_text");
                    txtMemo.Text = selectedMemoText;
                }
                else
                {
                    txtMemo.Text = "No memo text available for this row.";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StringBuilder restockBuilder = new StringBuilder();
            StringBuilder removedStocksBuilder = new StringBuilder();

            // Iterate through the rows in StockGrid
            foreach (DataGridViewRow row in StockGrid.Rows)
            {
                // Check if the row is not a new row and has valid data
                if (!row.IsNewRow &&
                    row.Cells["Product ID"].Value != null &&
                    row.Cells["Product Name"].Value != null &&
                    row.Cells["Current Stock"].Value != null &&
                    row.Cells["After Stock"].Value != null)
                {
                    // Get the product ID, product name, current stock, and after stock values
                    int productID = Convert.ToInt32(row.Cells["Product ID"].Value);
                    string productName = row.Cells["Product Name"].Value.ToString();
                    int currentStock = Convert.ToInt32(row.Cells["Current Stock"].Value);
                    int afterStock = Convert.ToInt32(row.Cells["After Stock"].Value);

                    // Check if the quantity increased or decreased
                    if (afterStock > currentStock)
                    {
                        string updateInfo = $"[{productID}] {productName}: {currentStock} -> {afterStock}{Environment.NewLine}";
                        restockBuilder.Append(updateInfo);
                    }
                    else if (afterStock < currentStock)
                    {
                        string updateInfo = $"[{productID}] {productName}: {currentStock} -> {afterStock}{Environment.NewLine}";
                        removedStocksBuilder.Append(updateInfo);
                    }

                    UpdateProductStock(productID, afterStock);
                }
            }

            // Get the complete system text for restock and removed stocks
            string restockText = restockBuilder.ToString();
            string removedStocksText = removedStocksBuilder.ToString();

            originalProductData = LoadProductDatas();
            ProductGrid.DataSource = originalProductData;

            // Show a dialog to save the system text or perform any other actions
            if (!string.IsNullOrEmpty(restockText) || !string.IsNullOrEmpty(removedStocksText))
            {
                StringBuilder systemTextBuilder = new StringBuilder();

                if (!string.IsNullOrEmpty(restockText))
                {
                    systemTextBuilder.AppendLine("Restock:");
                    systemTextBuilder.AppendLine(restockText);
                }

                if (!string.IsNullOrEmpty(removedStocksText))
                {
                    systemTextBuilder.AppendLine("Removed Stocks:");
                    systemTextBuilder.AppendLine(removedStocksText);
                }

                string systemText = systemTextBuilder.ToString();

                AddInvMemo addmemo = new AddInvMemo(employee_name, systemText);
                addmemo.ShowDialog();
            }

            StockGrid.Rows.Clear();
            addedProductIds.Clear();
        }

        private void UpdateProductStock(int productID, int afterStock)
        {
            // Define your SQL update query to update the product stock
            string updateQuery = "UPDATE products SET quantity_in_stock = @afterStock WHERE product_id = @productID";

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        // Set parameters for the update query
                        command.Parameters.AddWithValue("@afterStock", afterStock);
                        command.Parameters.AddWithValue("@productID", productID);

                        // Execute the update query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Update successful

                        }
                        else
                        {
                            // Update failed
                            MessageBox.Show($"Failed to update product ID {productID} stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboxColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColumn = cboxColumn.SelectedItem as string;

            if (selectedColumn == "Date")
            {
                // Filter the unique instances for the "Date" column (consider only the date part, not time)
                var uniqueDates = memoDataTable.AsEnumerable()
                    .Select(row => row.Field<DateTime>("time_date").Date)
                    .Distinct()
                    .ToList();

                // Bind unique dates to cboxUnique
                cboxUnique.DataSource = uniqueDates;
            }
            else if (selectedColumn == "Reason")
            {
                // Filter the unique instances for the "Reason" column
                var uniqueReasons = memoDataTable.AsEnumerable()
                    .Select(row => row.Field<string>("reason"))
                    .Distinct()
                    .ToList();

                // Bind unique reasons to cboxUnique
                cboxUnique.DataSource = uniqueReasons;
            }
            else if (selectedColumn == "Employee Name")
            {
                // Filter the unique instances for the "Employee Name" column
                var uniqueEmployeeNames = memoDataTable.AsEnumerable()
                    .Select(row => row.Field<string>("employee_name"))
                    .Distinct()
                    .ToList();

                // Bind unique employee names to cboxUnique
                cboxUnique.DataSource = uniqueEmployeeNames;
            }
            else
            {
                // Handle other columns or invalid selections here
                cboxUnique.DataSource = null; // Clear the cboxUnique data source
            }
        }

        private void cboxUnique_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColumn = cboxColumn.SelectedItem as string;
            object selectedValue = cboxUnique.SelectedItem;

            if (selectedColumn == "Date" && selectedValue is DateTime selectedDate)
            {
                // Filter the DataGridView based on the selected date (date part only)
                var filteredRows = memoDataTable.AsEnumerable()
                    .Where(row => row.Field<DateTime>("time_date").Date == selectedDate.Date)
                    .CopyToDataTable();

                dataGridViewMemos.DataSource = filteredRows;
            }
            else if (selectedColumn == "Reason" && selectedValue is string selectedReason)
            {
                // Filter the DataGridView based on the selected reason
                var filteredRows = memoDataTable.AsEnumerable()
                    .Where(row => row.Field<string>("reason") == selectedReason)
                    .CopyToDataTable();

                dataGridViewMemos.DataSource = filteredRows;
            }
            else if (selectedColumn == "Employee Name" && selectedValue is string selectedEmployee)
            {
                // Filter the DataGridView based on the selected employee name
                var filteredRows = memoDataTable.AsEnumerable()
                    .Where(row => row.Field<string>("employee_name") == selectedEmployee)
                    .CopyToDataTable();

                dataGridViewMemos.DataSource = filteredRows;
            }
            else
            {
                // Handle other columns or invalid selections here
                dataGridViewMemos.DataSource = null; // Clear the DataGridView data source
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cboxColumn.SelectedIndex = -1;
            cboxUnique.SelectedIndex = -1;
            dataGridViewMemos.DataSource = memoDataTable;
            dataGridViewMemos.Columns["time_date"].HeaderText = "Date and Time";
            dataGridViewMemos.Columns["reason"].HeaderText = "Reason";
            dataGridViewMemos.Columns["employee_name"].HeaderText = "Employee Name";
            if (dataGridViewMemos.Columns.Contains("memo_text"))
            {
                dataGridViewMemos.Columns["memo_text"].Visible = false;
            }
        }

        private void txtSearchTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if "Product ID" or "Supplier ID" is selected in cboxFilter
            string selectedFilter = cboxFilter.SelectedItem as string;

            if (selectedFilter == "Product ID" || selectedFilter == "Supplier ID")
            {
                // Allow only numbers and the Backspace key (for deleting)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Suppress the character input
                }
            }
        }

        private void ProductGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Check if the row is not a header and there are cells in the "Quantity in Stock" and "Critical Quantity" columns
            if (e.RowIndex >= 0 && ProductGrid.Rows[e.RowIndex].Cells["Quantity in Stock"].Value != null &&
                ProductGrid.Rows[e.RowIndex].Cells["Critical Quantity"].Value != null)
            {
                // Parse the values from the cells
                int quantityInStock = Convert.ToInt32(ProductGrid.Rows[e.RowIndex].Cells["Quantity in Stock"].Value);
                int criticalQuantity = Convert.ToInt32(ProductGrid.Rows[e.RowIndex].Cells["Critical Quantity"].Value);

                // Compare the quantity in stock with the critical quantity
                if (quantityInStock < criticalQuantity)
                {
                    // If it's less, set the row's font color to red and bold
                    ProductGrid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    ProductGrid.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font(ProductGrid.Font, FontStyle.Bold);
                }
                else
                {
                    // If it's not less, reset the row's font color and style
                    ProductGrid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = ProductGrid.DefaultCellStyle.ForeColor;
                    ProductGrid.Rows[e.RowIndex].DefaultCellStyle.Font = ProductGrid.DefaultCellStyle.Font;
                }
            }
        }


        HashSet<int> addedProductIds = new HashSet<int>();

        private void HandleStockChange(string action)
        {
            if (ProductGrid.SelectedRows.Count > 0)
            {
                // Get the selected row from the ProductGrid
                DataGridViewRow selectedRow = ProductGrid.SelectedRows[0];

                // Get the product ID, name, and quantity from the selected row
                int productId = Convert.ToInt32(selectedRow.Cells["Product ID"].Value);

                // Check if the product ID is already in the HashSet (indicating it's already in the StockGrid)
                if (addedProductIds.Contains(productId))
                {
                    MessageBox.Show("Product with ID " + productId + " is already in the StockGrid.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit the method to prevent adding duplicate entries
                }

                string productName = selectedRow.Cells["Product Name"].Value.ToString();
                int quantityChange;

                // Ensure the quantity input is a valid integer
                if (int.TryParse(txtQuantity.Text, out quantityChange))
                {
                    int currentStock = Convert.ToInt32(selectedRow.Cells["Quantity in Stock"].Value);

                    // Check if the action is "Subtract" and if subtracting would make the stock negative
                    if (action == "Subtract" && quantityChange > currentStock)
                    {
                        MessageBox.Show("Cannot subtract more than the current stock.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Calculate the new stock quantity based on the action (add or subtract)
                        int newStock = action == "Add" ? currentStock + quantityChange : currentStock - quantityChange;

                        // Add a new row to the StockGrid
                        StockGrid.Rows.Add(productId, productName, action, quantityChange, currentStock, newStock);

                        // Add the product ID to the HashSet to mark it as added
                        addedProductIds.Add(productId);

                        txtQuantity.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuantity.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please select a product from the ProductGrid.", "No Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            HandleStockChange("Add");
            txtQuantity.Focus();
        }

        private void btnRemoveStocks_Click(object sender, EventArgs e)
        {
            HandleStockChange("Subtract");
            txtQuantity.Focus();
        }

        private void btnDeleteStockItem_Click(object sender, EventArgs e)
        {
            if (StockGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = StockGrid.SelectedRows[0];
                int productId = Convert.ToInt32(selectedRow.Cells["Product ID"].Value);

                addedProductIds.Remove(productId);

                StockGrid.Rows.Remove(selectedRow);
            }
            else
            {
                MessageBox.Show("Please select a stock item to delete.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            StockGrid.Rows.Clear();
            addedProductIds.Clear();
        }

        private void cboxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchTerm.Text = string.Empty;
            txtSearchTerm.Focus();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void ProductGrid_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // Check if the column being sorted is the "Critical Quantity" column
            if (e.Column.Name == "Critical Quantity")
            {
                // Get the cell values for the two rows being compared
                object value1 = e.CellValue1;
                object value2 = e.CellValue2;

                // Check if both values are not null
                if (value1 != null && value2 != null)
                {
                    int criticalQuantity1 = Convert.ToInt32(value1);
                    int criticalQuantity2 = Convert.ToInt32(value2);

                    // Compare the critical quantities in reverse order (higher critical quantity at the top)
                    e.SortResult = criticalQuantity2.CompareTo(criticalQuantity1);

                    // If the critical quantities are equal, use the default comparison for Product ID
                    if (e.SortResult == 0 && e.Column.Name == "Critical Quantity")
                    {
                        e.SortResult = Convert.ToInt32(ProductGrid.Rows[e.RowIndex1].Cells["Product ID"].Value)
                            .CompareTo(Convert.ToInt32(ProductGrid.Rows[e.RowIndex2].Cells["Product ID"].Value));
                    }

                    // Set Handled to true to indicate that the comparison has been handled
                    e.Handled = true;
                }
            }
        }

        private void chkRestock_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRestock.Checked == true)
            {
                btnRemoveStocks.Enabled = false;
            }
            if (chkRestock.Checked == false)
            {
                btnRemoveStocks.Enabled = true;
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (chkRestock.Checked == true)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    HandleStockChange("Add");
                    txtQuantity.Focus();
                    e.Handled = true;
                }
            }

        }
    }
}
