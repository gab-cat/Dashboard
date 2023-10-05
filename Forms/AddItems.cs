using Microsoft.VisualBasic;
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
using Newtonsoft.Json;
using System.IO;

namespace Dashboard.Forms
{
    public partial class AddItems : Form
    {
        public Dictionary<string, int> PendingOrder
        {
            get { return pendingOrder; }
            set { pendingOrder = value; }
        }

        private readonly string pendingOrderFilePath = "pendingOrder.json";
        private Dictionary<string, int> productStockData;
        public static Dictionary<string, int> pendingOrder = new Dictionary<string, int>(); // Track pending order quantities

        // Save the pending order data to a JSON file
        private void SavePendingOrderToFile(Dictionary<string, int> pendingOrder)
        {
            string jsonData = JsonConvert.SerializeObject(pendingOrder);
            File.WriteAllText(pendingOrderFilePath, jsonData);
        }

        // Load the pending order data from a JSON file
        private Dictionary<string, int> LoadPendingOrderFromFile()
        {
            if (File.Exists(pendingOrderFilePath))
            {
                string jsonData = File.ReadAllText(pendingOrderFilePath);
                return JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonData);
            }
            return new Dictionary<string, int>();
        }


        private DataTable orderDataTable = new DataTable();
        public event EventHandler<ItemAddedEventArgs> ItemAdded;
        public AddItems(Dictionary<string, int> productStockData)
        {
            InitializeComponent();

            // Initialize the order DataTable
            orderDataTable.Columns.Add("#", typeof(int));
            orderDataTable.Columns.Add("Product ID", typeof(string));
            orderDataTable.Columns.Add("Item", typeof(string));
            orderDataTable.Columns.Add("Description", typeof(string));
            orderDataTable.Columns.Add("Price", typeof(decimal));
            orderDataTable.Columns.Add("Quantity", typeof(int));
            orderDataTable.Columns.Add("Subtotal", typeof(decimal));

            pendingOrder = LoadPendingOrderFromFile();
            this.productStockData = productStockData;

            comboBoxFilter.SelectedIndex = 0;
        }

        private void AddItems_Load(object sender, EventArgs e)
        {
            loadProducts();
        }

        private void loadProducts()
        {
            // Create a SQL query to retrieve the data from the products table
            string query = "SELECT product_id, product_name, description, selling_price, quantity_in_stock " +
                           "FROM products";

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Add a row number column at the first position
                    dataTable.Columns.Add("#", typeof(int));
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        dataTable.Rows[i]["#"] = i + 1;
                    }

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Move the '#' column to the first position
                    dataGridView1.Columns["#"].DisplayIndex = 0;

                    // Set specific widths for columns

                    dataGridView1.Columns["#"].Width = 30; 
                    dataGridView1.Columns["product_id"].Width = 70; 
                    dataGridView1.Columns["product_name"].Width = 130; 
                    dataGridView1.Columns["description"].Width = 290; 
                    dataGridView1.Columns["selling_price"].Width = 70; 
                    dataGridView1.Columns["quantity_in_stock"].Width = 50; 

                    dataGridView1.Columns["#"].HeaderText = "#"; 
                    dataGridView1.Columns["product_id"].HeaderText = "Product ID"; 
                    dataGridView1.Columns["product_name"].HeaderText = "Item"; 
                    dataGridView1.Columns["description"].HeaderText = "Description"; 
                    dataGridView1.Columns["selling_price"].HeaderText = "Price"; 
                    dataGridView1.Columns["quantity_in_stock"].HeaderText = "Stock"; 

                    // Update stock values based on the pending order
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string productID = row.Cells["product_id"].Value.ToString();
                        if (pendingOrder.ContainsKey(productID))
                        {
                            int currentStock = Convert.ToInt32(row.Cells["quantity_in_stock"].Value);
                            int pendingQuantity = pendingOrder[productID];
                            int updatedStock = currentStock - pendingQuantity;
                            row.Cells["quantity_in_stock"].Value = updatedStock;
                        }
                    }

                    DataGridViewButtonColumn btnAddColumn = (DataGridViewButtonColumn)dataGridView1.Columns["btnAddColumn"];
                    btnAddColumn.DisplayIndex = dataGridView1.Columns.Count - 1;

                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; 
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; 
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["btnAddColumn"].Index)
            {
                AddItemToOrder();
            }
        }

        private void AddItemToOrder()
        {
            DataRow selectedRow = ((DataRowView)dataGridView1.CurrentRow.DataBoundItem).Row;
            int availableStock = Convert.ToInt32(selectedRow["quantity_in_stock"]);

            int quantity;
            while (true)
            {
                // Prompt the user to enter the quantity
                if (!int.TryParse(Interaction.InputBox("Enter Quantity:"), out quantity))
                {
                    // User entered an invalid quantity (not an integer)
                    MessageBox.Show("Please enter a valid quantity (a positive whole number).");
                    continue; 
                }

                if (quantity <= 0)
                {
                    // User entered a non-positive quantity
                    break;
                }

                if (quantity > availableStock)
                {
                    // User entered a quantity greater than the available stock
                    MessageBox.Show("Quantity exceeds available stock. Please enter a smaller quantity.");
                    continue; 
                }

                string productID = selectedRow["product_id"].ToString();
                string itemName = selectedRow["product_name"].ToString();
                string description = selectedRow["description"].ToString();
                decimal price = Convert.ToDecimal(selectedRow["selling_price"]);

                // Calculate subtotal
                decimal subtotal = price * quantity;

                // Add the selected item to the order DataTable
                orderDataTable.Rows.Add(orderDataTable.Rows.Count + 1, productID, itemName, description, price, quantity, subtotal);

                // Raise the ItemAdded event to notify the POS form
                if (ItemAdded != null)
                {
                    ItemAdded(this, new ItemAddedEventArgs(productID, itemName, description, price, quantity, subtotal));
                }

                // Track the pending order quantity
                if (pendingOrder.ContainsKey(productID))
                {
                    pendingOrder[productID] += quantity;
                }
                else
                {
                    pendingOrder.Add(productID, quantity);
                }

                // Update the stock count displayed in the DataGridView
                selectedRow["quantity_in_stock"] = availableStock - quantity;

                // Save the updated pending order data to file
                SavePendingOrderToFile(pendingOrder);

                break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBoxFilter.SelectedIndex = 0;
            txtSearchTerm.Text = string.Empty;
            loadProducts();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string filter = comboBoxFilter.SelectedItem.ToString();
            string searchTerm = txtSearchTerm.Text.Trim();

            // Create a SQL query to retrieve the data based on the selected filter and search term
            string query = "SELECT product_id, product_name, description, selling_price, quantity_in_stock " +
                           "FROM products ";

            if (filter == "Product ID")
            {
                query += $"WHERE product_id = '{searchTerm}'";
            }
            else if (filter == "Name")
            {
                query += $"WHERE product_name LIKE '%{searchTerm}%'";
            }

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Add a row number column at the first position
                    dataTable.Columns.Add("#", typeof(int));
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        dataTable.Rows[i]["#"] = i + 1;
                    }

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;

                    // Move the '#' column to the first position
                    dataGridView1.Columns["#"].DisplayIndex = 0;

                    // Set specific widths for columns

                    dataGridView1.Columns["#"].Width = 30; 
                    dataGridView1.Columns["product_id"].Width = 70; 
                    dataGridView1.Columns["product_name"].Width = 130; 
                    dataGridView1.Columns["description"].Width = 290; 
                    dataGridView1.Columns["selling_price"].Width = 70; 
                    dataGridView1.Columns["quantity_in_stock"].Width = 50; 

                    dataGridView1.Columns["#"].HeaderText = "#"; 
                    dataGridView1.Columns["product_id"].HeaderText = "Product ID"; 
                    dataGridView1.Columns["product_name"].HeaderText = "Item"; 
                    dataGridView1.Columns["description"].HeaderText = "Description"; 
                    dataGridView1.Columns["selling_price"].HeaderText = "Price"; 
                    dataGridView1.Columns["quantity_in_stock"].HeaderText = "Stock"; 

                    DataGridViewButtonColumn btnAddColumn = (DataGridViewButtonColumn)dataGridView1.Columns["btnAddColumn"];
                    btnAddColumn.DisplayIndex = dataGridView1.Columns.Count - 1;

                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange; 
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; 
                }
            }
        }
    }
}
