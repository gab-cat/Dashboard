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

            lblLastUpdate.ForeColor = ThemeColor.SecondaryColor;
            lblProductName.ForeColor = ThemeColor.SecondaryColor;
            button1.OnHoverBaseColor = ThemeColor.SecondaryColor;

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
                                        AddInvMemo addmemo = new AddInvMemo(employee_name, "Delete Product",systemMemo);
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
            // Check if there is a selected row in the ProductGrid
            if (ProductGrid.SelectedRows.Count > 0)
            {
                // Get the product_id and product name from the selected row
                int productId = Convert.ToInt32(ProductGrid.SelectedRows[0].Cells["Product ID"].Value);
                string productName = Convert.ToString(ProductGrid.SelectedRows[0].Cells["Product Name"].Value);

                // Load the price history for the selected product
                LoadPriceHistoryForSelectedProduct(productId, productName);
            }
            else
            {
                // Clear the DataGridView and TextBox if no row is selected
                dgvPriceHistory.DataSource = null;
                lblProductName.Text = "";
                lblLastUpdate.Text = "Last Update: N/A";
                txtMemoPH.Text = "";
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
    }
}
