using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using Font = iTextSharp.text.Font;
using System.Globalization;

namespace Dashboard.Forms
{
    public partial class POS : Form
    {
        private Dictionary<string, int> productStockData = new Dictionary<string, int>();
        private readonly string pendingOrderFilePath = "pendingOrder.json";
        private bool orderOngoing = false;
        private int customer_id;
        private string employee_name;
        private string role;
        private int new_sale_id;
        private decimal discount_amount;
        private bool orderCreated = false;
        private decimal discountPercent;
        private string supervisor_name;
        private decimal total_amount;
        private string transaction_id;

        private void AddItemToOrder(OrderItem item)
        {
            // Update the in-memory product data (decrement stock)
            UpdateProductStock(item.ProductID, item.Quantity * -1);

            // Add the item to the order data structure
            orderItems.Add(item);

            // Update the order grid
            UpdateOrderGrid();
        }

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

        private void UpdateProductStock(string productID, int quantityChange)
        {
            if (productStockData.ContainsKey(productID))
            {
                // Update the stock value based on the quantity change
                productStockData[productID] += quantityChange;
            }
        }

        private bool isItemAddingEnabled = true;
        private List<OrderItem> orderItems = new List<OrderItem>();
        private DataTable orderDataTable; // Add a DataTable for the order
        private int sale_id;
        private bool isDiscountApplied = false;

        public POS(int CustomerId, string EmployeeName, string Role)
        {
            InitializeComponent();
            orderGrid.AutoGenerateColumns = true;
            InitializeOrderDataTable(); // Initialize the order DataTable

            customer_id = CustomerId;
            employee_name = EmployeeName;
            role = Role;

            txt_Name.Text = EmployeeName;
            txt_Role.Text = Role;
            TimeDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");

            // Disable item adding and hide the transaction ID textbox initially
            btnAddItem.Enabled = false;
            txtTransactionID.Text = "NO TRANSACTION YET";
            orderGrid.AllowUserToDeleteRows = true;
            orderGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }




        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public void AddToOrder(OrderItem item)
        {
            // Add the item to the order data structure
            // Deduct the stock when an item is added to the order
            UpdateProductStock(item.ProductID, item.Quantity * -1);

            orderItems.Add(item);

            // Update the order grid
            UpdateOrderGrid();
        }

        private void InitializeOrderDataTable()
        {
            // Initialize the order DataTable with columns
            orderDataTable = new DataTable();
            orderDataTable.Columns.Add("#", typeof(int));
            orderDataTable.Columns.Add("Product ID", typeof(string));
            orderDataTable.Columns.Add("Item", typeof(string));
            orderDataTable.Columns.Add("Description", typeof(string));
            orderDataTable.Columns.Add("Price", typeof(decimal));
            orderDataTable.Columns.Add("Quantity", typeof(int));
            orderDataTable.Columns.Add("Subtotal", typeof(decimal));

            // Bind the order DataTable to the DataGridView
            orderGrid.DataSource = orderDataTable;

            // Set custom column widths
            orderGrid.Columns["#"].Width = 25; // Set the width for the "#" column
            orderGrid.Columns["Product ID"].Width = 65; // Set the width for the "Product ID" column
            orderGrid.Columns["Item"].Width = 135; // Set the width for the "Item" column
            orderGrid.Columns["Description"].Width = 245; // Set the width for the "Description" column
            orderGrid.Columns["Price"].Width = 65; // Set the width for the "Price" column
            orderGrid.Columns["Quantity"].Width = 70; // Set the width for the "Quantity" column
            orderGrid.Columns["Subtotal"].Width = 70; // Set the width for the "Subtotal" column
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isDiscountApplied)
            {
                MessageBox.Show("A discount has already been applied to this order. The order is final. For modifications/changes, please create another order.", "Add Item to Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataGridViewButtonColumn btnXColumn = (DataGridViewButtonColumn)orderGrid.Columns["btnXColumn"];
            btnXColumn.DisplayIndex = orderGrid.Columns.Count - 1;

            AddItems addItems = new AddItems(productStockData);
            addItems.PendingOrder = AddItems.pendingOrder;
            // Subscribe to the ItemAdded event
            addItems.ItemAdded += AddItems_ItemAdded;

            addItems.ShowDialog();


        }

        private void POS_Load(object sender, EventArgs e)
        {
            
        }


        private void AddItems_ItemAdded(object sender, ItemAddedEventArgs e)
        {

            if (!isItemAddingEnabled)
            {
                MessageBox.Show("Item adding is no longer allowed after applying the discount.", "Item Adding Disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Add the item to the order data structure
            AddToOrder(new OrderItem
            {
                ProductID = e.ProductID,
                ItemName = e.ItemName,
                Description = e.Description,
                Price = e.Price,
                Quantity = e.Quantity,
                Subtotal = e.Subtotal
            });

            // Clear the previous selection
            orderGrid.ClearSelection();

            // Update the order grid
            UpdateOrderGrid();
            UpdateTotalOrderAmount();

            // Select the newly added row
            int rowIndex = orderGrid.Rows.Count - 1;
            orderGrid.Rows[rowIndex].Selected = true;

            // Display data in text boxes
            txtProductId.Text = e.ProductID;
            txtDescription.Text = e.Description;
            txtQuantity.Text = e.Quantity.ToString();
            txtUnitPrice.Text = e.Price.ToString("0.00");
            txtSubtotal.Text = e.Subtotal.ToString("0.00");
        }

        private void UpdateOrderGrid()
        {
            // Clear the existing data in the order DataTable
            orderDataTable.Rows.Clear();

            // Iterate through the order items and add them to the order DataTable
            int index = 1;
            foreach (OrderItem item in orderItems)
            {
                orderDataTable.Rows.Add(index, item.ProductID, item.ItemName, item.Description, item.Price, item.Quantity, item.Subtotal);
                index++;
            }

            // Calculate and update the total order amount
            UpdateTotalOrderAmount();
        }


        private void orderGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (orderGrid.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = orderGrid.SelectedRows[0];

                // Get data from the selected row
                string productID = selectedRow.Cells["Product ID"].Value.ToString();
                string description = selectedRow.Cells["Description"].Value.ToString();
                int quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
                decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
                decimal subtotal = Convert.ToDecimal(selectedRow.Cells["Subtotal"].Value);

                // Update the text boxes
                txtProductId.Text = productID;
                txtDescription.Text = description;
                txtQuantity.Text = quantity.ToString();
                txtUnitPrice.Text = price.ToString("0.00");
                txtSubtotal.Text = subtotal.ToString("0.00");
            }
            else
            {
                // Clear the text boxes if no row is selected
                txtProductId.Text = "";
                txtDescription.Text = "";
                txtQuantity.Text = "";
                txtUnitPrice.Text = "";
                txtSubtotal.Text = "";
            }
        }

        private void orderGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == orderGrid.Columns["btnXColumn"].Index && e.RowIndex >= 0)
            {
                if (isDiscountApplied)
                {
                    MessageBox.Show("A discount has already been applied to this order. The order is final. For modifications/changes, please create another order.", "Cancel Item from Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // "X" button in the btnXColumn was clicked
                // Get the selected row
                DataGridViewRow selectedRow = orderGrid.Rows[e.RowIndex];

                // Get the product ID of the item to be removed
                string productIDToRemove = selectedRow.Cells["Product ID"].Value.ToString();

                // Find the item in the orderItems list
                OrderItem itemToRemove = orderItems.FirstOrDefault(item => item.ProductID == productIDToRemove);

                if (itemToRemove != null)
                {
                    // Increment the stock for the product when removing the item
                    UpdateProductStock(itemToRemove.ProductID, itemToRemove.Quantity);

                    // Remove the item from the orderItems list
                    orderItems.Remove(itemToRemove);
                }

                // Remove the selected row from the DataGridView
                orderGrid.Rows.Remove(selectedRow);

                // Update the order grid and total order amount
                UpdateTotalOrderAmount();
                UpdateOrderGrid();

                // Remove the item from the pending order JSON file
                if (AddItems.pendingOrder.ContainsKey(productIDToRemove))
                {
                    AddItems.pendingOrder.Remove(productIDToRemove);
                    // Save the updated pending order data to the JSON file
                    SavePendingOrderToFile(AddItems.pendingOrder);
                }
            }
        }

        private void BacktoForm_Click(object sender, EventArgs e)
        {
            if (!orderCreated)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to go back to the main menu?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                    {
                        using (MySqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // Check if a sale_id has been generated
                                if (sale_id > 0)
                                {
                                    // Delete the sale_id row from the sales table
                                    string deleteQuery = "DELETE FROM sales WHERE sale_id = @sale_id";
                                    MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection, transaction);
                                    deleteCommand.Parameters.AddWithValue("@sale_id", sale_id);
                                    deleteCommand.ExecuteNonQuery();
                                }

                                // Commit the transaction
                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                // Handle any exceptions that may occur during the transaction
                                transaction.Rollback();
                                MessageBox.Show("An error occurred while canceling the transaction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
                // Close the current POS form
         this.Close();

                // Show the previously hidden Dashboard and FormOrder forms
         Dashboard dashboardForm = Application.OpenForms["Dashboard"] as Dashboard;
         if (dashboardForm != null)
         {
            dashboardForm.Show(); // Show the Dashboard form
         }

         FormOrder formOrderForm = Application.OpenForms["FormOrder"] as FormOrder;
         if (formOrderForm != null)
         {
         formOrderForm.Show(); // Show the FormOrder form
          }
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void GenerateTransactionID()
        {
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                // Create a new transaction
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Query to get the last product_id from the sales table
                        string query = "SELECT MAX(sale_id) FROM sales";
                        MySqlCommand command = new MySqlCommand(query, connection, transaction);

                        // Get the last sale_id or default to 0 if the table is empty
                        int lastSaleID = Convert.ToInt32(command.ExecuteScalar());
                        int newSaleID = lastSaleID + 1;
                        new_sale_id = newSaleID;

                        sale_id = newSaleID;

                        // Get the current date in the format "YYYYMMDD"
                        string currentDate = DateTime.Now.ToString("yyyyMMdd");

                        // Set the transaction ID in the format "YYYYMMDD + sale_id"
                        string transactionID = currentDate + newSaleID.ToString();
                        transaction_id = transactionID;

                        // Set the transaction ID in your textbox (assuming you have a textbox named "txtTransactionID")
                        txtTransactionID.Text = transactionID;

                        // Insert the new sale_id into the sales table
                        string insertQuery = "INSERT INTO sales (sale_id) VALUES (@sale_id)";
                        MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection, transaction);
                        insertCommand.Parameters.AddWithValue("@sale_id", newSaleID);
                        insertCommand.ExecuteNonQuery();

                        // Commit the transaction
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that may occur during the transaction
                        transaction.Rollback();
                        MessageBox.Show("An error occurred while generating the transaction ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            if (orderOngoing)
            {
                MessageBox.Show("You already have an active order Transaction.", "New Transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            orderCreated = false;

            orderOngoing = true;

            // Clear the pending order data in memory
            AddItems.pendingOrder.Clear();

            // Save the empty pending order data to the JSON file
            SavePendingOrderToFile(AddItems.pendingOrder);

            // Enable item adding and show the transaction ID textbox
            isItemAddingEnabled = true;
            btnAddItem.Enabled = true;
            txtTransactionID.Visible = true;
            btnDiscount.Enabled = true;
            btnCreateOrder.Enabled = true;

            // Call the method to generate the transaction ID
            GenerateTransactionID();
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            // Check if a discount has already been applied
            if (isDiscountApplied)
            {
                MessageBox.Show("A discount has already been applied to this order.", "Discount Applied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Prompt the user for username and password
            string username = Interaction.InputBox("Enter Supervisor's Username:\n\n" +
                "Warning: Only Supervisors are allowed to add a discount to orders. Once the discount is applied, the order will be final and can no longer be modified. " +
                "Please proceed with caution.", "Authentication");
            // Prompt the user for password with a password input box
            string password = PromptForPassword("Enter Supervisor's Password:");

            // Check the username and password in your logins table (You need to implement this part)
            bool isAuthenticated = CheckAuthentication(username, password);

            if (isAuthenticated)
            {
                // Get the user's role from the logins table (You need to implement this part)
                string userRole = GetUserRole(username);

                // Check if the user is an Admin or Manager to apply a discount
                if (userRole == "Admin" || userRole == "Manager")
                {
                    // Prompt the user to enter a discount percentage
                    string discountInput = Interaction.InputBox("Enter discount percentage:", "Discount");

                    if (decimal.TryParse(discountInput, out decimal discountPercentage) && discountPercentage >= 0)
                    {
                        // Check if the discount percentage is valid
                        if (discountPercentage <= 100)
                        {
                            // Calculate the discount amount based on the percentage
                            decimal totalAmount = decimal.Parse(lblTotalAmount.Text);
                            total_amount = totalAmount;


                            discountPercent = discountPercentage;
                            decimal discountAmount = (discountPercentage / 100) * totalAmount;

                            // Apply the discount to the total amount
                            totalAmount -= discountAmount;

                            supervisor_name = username;

                            txtDiscount.Text = discountAmount.ToString("0.00");
                            discount_amount = discountAmount;
                            // Update the total amount display
                            lblTotalAmount.Text = totalAmount.ToString("0.00");
                            txttotal.Text = lblTotalAmount.Text;

                            // Calculate VAT and vatable amount (assuming VAT rate is 12%, you can adjust this rate accordingly)
                            decimal vatRate = 0.12m; // 12% VAT rate
                            decimal vatableAmount = totalAmount / (1 + vatRate);
                            decimal vatAmount = totalAmount - vatableAmount;

                            // Update the vatable amount and VAT text boxes
                            txtVatable.Text = vatableAmount.ToString("0.00");
                            txtVAT.Text = vatAmount.ToString("0.00");

                            // Disable item adding after applying the discount
                            isItemAddingEnabled = false;

                            // Set the flag to indicate that a discount has been applied
                            isDiscountApplied = true;

                            // Update the order grid and total order amount
                            // UpdateOrderGrid();
                            ApplyDiscountToOrderItems(discountPercentage);

                            // Display a message indicating that the discount has been applied
                            MessageBox.Show($"Discount of {discountPercentage}% applied successfully.", "Discount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Invalid discount percentage. Please enter a value between 0 and 100.", "Discount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid discount input. Please enter a valid percentage.", "Discount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You do not have permission to apply a discount.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Authentication failed. Please check your username and password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyDiscountToOrderItems(decimal discountPercentage)
        {
            foreach (DataGridViewRow row in orderGrid.Rows)
            {
                if (row.Cells["Price"] is DataGridViewTextBoxCell priceCell &&
                    row.Cells["Quantity"] is DataGridViewTextBoxCell quantityCell &&
                    row.Cells["Subtotal"] is DataGridViewTextBoxCell subtotalCell) // Add this line
                {
                    if (decimal.TryParse(priceCell.Value.ToString(), out decimal originalPrice) &&
                        int.TryParse(quantityCell.Value.ToString(), out int quantity))
                    {
                        decimal discountedPrice = originalPrice - (originalPrice * (discountPercentage / 100));
                        priceCell.Value = discountedPrice.ToString("0.00");
                        priceCell.Style.ForeColor = Color.Blue;

                        int rowIndex = row.Index;
                        if (rowIndex >= 0 && rowIndex < orderItems.Count)
                        {
                            orderItems[rowIndex].Price = discountedPrice;

                            decimal subtotal = discountedPrice * quantity;
                            subtotalCell.Value = subtotal.ToString("0.00"); // Change the text color of the "Subtotal" cell
                            subtotalCell.Style.ForeColor = Color.Blue; // Change the subtotal text color to blue

                            orderItems[rowIndex].Subtotal = subtotal;
                        }
                    }
                }
            }
        }

        private string PromptForPassword(string promptText)
        {
            string password = "";
            using (Form prompt = new Form())
            {
                prompt.Width = 500;
                prompt.Height = 150;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = promptText;
                prompt.StartPosition = FormStartPosition.CenterScreen;

                Label textLabel = new Label() { Left = 50, Top = 20, Text = "Password:" };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400, UseSystemPasswordChar = true };
                Button confirmation = new Button() { Text = "OK", Left = 350, Width = 100, Top = 80, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };

                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    password = textBox.Text;
                }
            }
            return password;
        }

        private bool CheckAuthentication(string username, string password)
        {
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                // Query to check username and password in your logins table
                string query = "SELECT COUNT(*) FROM logins WHERE username = @username AND password = @password";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                // Execute the query to check authentication
                int count = Convert.ToInt32(command.ExecuteScalar());

                // Return true if authentication is successful (count is 1), false otherwise
                return (count == 1);
            }
        }

        private string GetUserRole(string username)
        {
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                // Query to get the user's role based on their username
                string query = "SELECT role FROM logins WHERE username = @username";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                // Execute the query to retrieve the user's role
                object role = command.ExecuteScalar();

                // Check if a role was found, and return it as a string
                if (role != null)
                {
                    return role.ToString();
                }
                else
                {
                    // Return "Employee" as the default role if not found
                    return "Employee";
                }
            }
        }

        private void UpdateTotalOrderAmount()
        {
            decimal totalAmount = 0;

            // Calculate the total order amount based on the items in the order
            foreach (OrderItem item in orderItems)
            {
                totalAmount += item.Subtotal;
            }

            // Calculate VAT and vatable amount (assuming VAT rate is 12%, you can adjust this rate accordingly)
            decimal vatRate = 0.12m; // 12% VAT rate
            decimal vatableAmount = totalAmount / (1 + vatRate);
            decimal vatAmount = totalAmount - vatableAmount;

            // Update the total order amount display
            lblTotalAmount.Text = totalAmount.ToString("0.00");
            txttotal.Text = lblTotalAmount.Text;

            // Update the vatable amount and VAT text boxes
            txtVatable.Text = vatableAmount.ToString("0.00");
            txtVAT.Text = vatAmount.ToString("0.00");
        }

        private void POS_FormClosed(object sender, FormClosedEventArgs e)
        {
            productStockData.Clear();

        }

        private void POS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                // Trigger the click event of the btnNewTransaction button
                btnNewTransaction.PerformClick();
                e.Handled = true; // Prevent further processing of the F1 key press
            }
            if (e.KeyCode == Keys.F2)
            {
                // Trigger the click event of the btnNewTransaction button
                btnAddItem.PerformClick();
                e.Handled = true; // Prevent further processing of the F1 key press
            }
            if (e.KeyCode == Keys.F3)
            {
                // Trigger the click event of the btnNewTransaction button
                btnDiscount.PerformClick();
                e.Handled = true; // Prevent further processing of the F1 key press
            }
            if (e.KeyCode == Keys.F4)
            {
                // Trigger the click event of the btnNewTransaction button
                btnCreateOrder.PerformClick();
                e.Handled = true; // Prevent further processing of the F1 key press
            }
            if (e.KeyCode == Keys.F5)
            {
                // Trigger the click event of the btnNewTransaction button
                BacktoForm.PerformClick();
                e.Handled = true; // Prevent further processing of the F1 key press
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to create this order?", "Confirm Order Creation: " + new_sale_id.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // User confirmed, proceed to create the order

                if (!isDiscountApplied)
                {
                    if (decimal.TryParse(lblTotalAmount.Text, out decimal totalAmount))
                    {
                        total_amount = totalAmount;
                    }
                }


                CreateOrder(customer_id, employee_name);
                txtTransactionID.Text = "No Transaction";

                string memotext = "Successfully created a new order " + new_sale_id + " for customer ID: " + customer_id;
                

                LoadingScreenManager.ShowLoadingScreen(() =>
                {
                    // The code inside this block is executed while the loading animation is displayed
                    AddMemo memo = new AddMemo(customer_id, employee_name, "Create Order", memotext);
                    memo.ShowDialog();

                    if (isDiscountApplied == true)
                    {
                        string discountmemo = Environment.NewLine + "Manager Discretion: " + supervisor_name + Environment.NewLine + "Applied " + discountPercent + "% discount for Sale ID: " + new_sale_id + Environment.NewLine +
                            "Total discount applied for current sale is ₱ " + discount_amount;
                            // The code inside this block is executed while the loading animation is displayed
                            AddMemo memo1 = new AddMemo(customer_id, employee_name, "Discount Added", discountmemo);
                            memo1.ShowDialog();
                    }
                });

                isDiscountApplied = false;
                orderOngoing = false;

                btnAddItem.Enabled = false;
                btnDiscount.Enabled = false;
                btnCreateOrder.Enabled = false;

            }
        }
        private void CreateOrder(int customerId, string employeeName)
        {
            orderCreated = true;
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updateSaleQuery = "UPDATE sales " +
                                                "SET customer_id = @customer_id, " +
                                                "employee_name = @employee_name, " +
                                                "sale_date = @sale_date, " +
                                                "total_amount = @total_amount, " +
                                                "payment_status = @payment_status, " +
                                                "discount = @discount " +
                                                "WHERE sale_id = @sale_id";

                        string totalAmountString = lblTotalAmount.Text;
                        decimal totalAmount = decimal.Parse(totalAmountString);
                        string insertSaleId = new_sale_id.ToString();
                        

                        MySqlCommand insertSaleCommand = new MySqlCommand(updateSaleQuery, connection, transaction);
                        
                        insertSaleCommand.Parameters.AddWithValue("@customer_id", customerId);
                        insertSaleCommand.Parameters.AddWithValue("@employee_name", employeeName);
                        insertSaleCommand.Parameters.AddWithValue("@sale_date", DateTime.Now); // Use the current date
                        insertSaleCommand.Parameters.AddWithValue("@total_amount", totalAmount); // Use the current date
                        insertSaleCommand.Parameters.AddWithValue("@payment_status", "Pending"); // Default payment status
                        insertSaleCommand.Parameters.AddWithValue("@discount", discount_amount);
                        insertSaleCommand.Parameters.AddWithValue("@sale_id", insertSaleId);

                        insertSaleCommand.ExecuteNonQuery();

                        // Retrieve the auto-generated sale_id for the newly created sale
                        // int saleId = (int)insertSaleCommand.LastInsertedId;

                        // Iterate through the order items and insert them into the sale_items table
                        foreach (OrderItem item in orderItems)
                        {
                            string insertSaleItemQuery = "INSERT INTO sale_items (sale_id, product_id, sale_date, quantity_sold, unit_price, subtotal) " +
                                "VALUES (@sale_id, @product_id, @sale_date, @quantity_sold, @unit_price, @subtotal)";

                            MySqlCommand insertSaleItemCommand = new MySqlCommand(insertSaleItemQuery, connection, transaction);
                            insertSaleItemCommand.Parameters.AddWithValue("@sale_id", insertSaleId);
                            insertSaleItemCommand.Parameters.AddWithValue("@product_id", item.ProductID);
                            insertSaleItemCommand.Parameters.AddWithValue("@sale_date", DateTime.Now); // Use the current date
                            insertSaleItemCommand.Parameters.AddWithValue("@quantity_sold", item.Quantity);
                            insertSaleItemCommand.Parameters.AddWithValue("@unit_price", item.Price);
                            insertSaleItemCommand.Parameters.AddWithValue("@subtotal", item.Subtotal);

                            insertSaleItemCommand.ExecuteNonQuery();

                            // Deduct the quantity_in_stock in the products table
                            string updateProductStockQuery = "UPDATE products " +
                                                             "SET quantity_in_stock = quantity_in_stock - @quantity_sold " +
                                                             "WHERE product_id = @product_id";

                            MySqlCommand updateProductStockCommand = new MySqlCommand(updateProductStockQuery, connection, transaction);
                            updateProductStockCommand.Parameters.AddWithValue("@product_id", item.ProductID);
                            updateProductStockCommand.Parameters.AddWithValue("@quantity_sold", item.Quantity);

                            // Execute the update query for product stock
                            updateProductStockCommand.ExecuteNonQuery();
                        }

                        // Commit the transaction
                        transaction.Commit();
                        

                        // Display a success message to the user
                        MessageBox.Show("Order created successfully.", "Order Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GenerateOrderSummaryPDF(customer_id, transaction_id);

                        orderItems.Clear();
                        UpdateOrderGrid();
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that may occur during the transaction
                        transaction.Rollback();
                        MessageBox.Show("An error occurred while creating the order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void GenerateOrderSummaryPDF(int customerId, string saleId)
        {
            // Define your custom margins (left, right, top, bottom)
            float leftMargin = 20f;    // Adjust the value as needed
            float rightMargin = 20f;   // Adjust the value as needed
            float topMargin = 10f;     // Adjust the value as needed
            float bottomMargin = 10f;  // Adjust the value as needed

            // Create a new document with custom margins
            Document doc = new Document(new iTextSharp.text.Rectangle(PageSize.A4.Rotate().Width / 2, PageSize.A4.Height));
            doc.SetMargins(leftMargin, rightMargin, topMargin, bottomMargin);

            try
            {
                // Set the directory where invoices will be stored
                string invoiceDirectory = "Invoices";
                Directory.CreateDirectory(invoiceDirectory); // Create the directory if it doesn't exist

                // Set the file path for the PDF using the transaction ID as the filename
                string filePath = Path.Combine(invoiceDirectory, $"{customerId}_{saleId}.pdf");

                // Create a FileStream to write the PDF file
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
                    var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                    // Open the document for writing
                    doc.Open();

                    // Create a table cell for the business name with a black background and white text
                    PdfPCell businessNameCell = new PdfPCell(new Phrase("New Bernales Hardware Store", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24)));
                    businessNameCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    businessNameCell.BackgroundColor = BaseColor.BLACK; // Set the background color to black
                    businessNameCell.BorderColor = BaseColor.WHITE; // Set the border color to white
                    businessNameCell.Padding = 10; // Add padding for better appearance
                    businessNameCell.VerticalAlignment = Element.ALIGN_MIDDLE; // Center vertically



                    // Create a table with a single cell and remove its border
                    PdfPTable businessNameTable = new PdfPTable(1);
                    businessNameTable.DefaultCell.Border = PdfPCell.NO_BORDER;
                    businessNameTable.WidthPercentage = 100; // Set table width to 100% of the page

                    // Add the business name cell to the table
                    businessNameTable.AddCell(businessNameCell);

                    // Set the text color to white
                    businessNameCell.Phrase.Font.Color = BaseColor.WHITE;

                    // Add the table to the document
                    doc.Add(businessNameTable);

                    // Create a PdfPTable for the contact information
                    PdfPTable contactInfoTable = new PdfPTable(1);
                    contactInfoTable.WidthPercentage = 100;

                    // Create PdfPCell for each line of contact information
                    string[] contactInfoLines = new string[]
                    {
                        "Sagrada, Pili, Camarines Sur 4418",
                        "Phone: (123) 456-7890",
                        "Email: info@newbernaleshardwarestore.com",
                        "Website: www.newbernaleshardwarestore.com"
                    };

                    foreach (string line in contactInfoLines)
                    {
                        PdfPCell cell2 = new PdfPCell(new Phrase(line, normalFont));
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        contactInfoTable.AddCell(cell2);
                    }

                    // Add the contactInfoTable to the document
                    doc.Add(contactInfoTable);


                    // Create a table with one cell
                    PdfPTable orderedtable = new PdfPTable(1);
                    orderedtable.WidthPercentage = 100; // 100% width
                    orderedtable.SpacingBefore = 12f;

                    // Create a PdfPCell to hold your paragraph
                    PdfPCell cell = new PdfPCell();
                    cell.Border = PdfPCell.BOTTOM_BORDER; // Bottom border only

                    // Create the Paragraph
                    Paragraph orderTitle = new Paragraph("I. ORDER INVOICE FORM", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11));
                    orderTitle.Alignment = Element.ALIGN_LEFT; // Align the title to the left
                    cell.AddElement(orderTitle);
                    orderedtable.AddCell(cell);
                    doc.Add(orderedtable);

                    //doc.Add(new Chunk(new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1)));

                    // Customer Information
                    PdfPTable customerInfoTable = new PdfPTable(2);
                    customerInfoTable.SpacingBefore = 0;
                    customerInfoTable.SpacingAfter = 5;
                    customerInfoTable.WidthPercentage = 100;
                    customerInfoTable.SetWidths(new float[] { 3f, 7f });
                    customerInfoTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    // Customer ID
                    cell = new PdfPCell(new Phrase("Customer ID         :", boldFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerInfoTable.AddCell(cell);

                    cell = new PdfPCell(new Phrase(customerId.ToString(), normalFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerInfoTable.AddCell(cell);

                    // Transaction Date
                    cell = new PdfPCell(new Phrase("Transaction Date :", boldFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerInfoTable.AddCell(cell);

                    cell = new PdfPCell(new Phrase(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), normalFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerInfoTable.AddCell(cell);

                    // Transaction ID
                    cell = new PdfPCell(new Phrase("Transaction ID     :", boldFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerInfoTable.AddCell(cell);

                    cell = new PdfPCell(new Phrase(saleId, normalFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerInfoTable.AddCell(cell);

                    // Add the customerInfoTable to the document
                    doc.Add(customerInfoTable);

                    // Create a table with one cell
                    PdfPTable cxtable = new PdfPTable(1);
                    cxtable.WidthPercentage = 100; // 100% width
                    

                    // Create a PdfPCell to hold your paragraph
                    cell = new PdfPCell();
                    cell.Border = PdfPCell.BOTTOM_BORDER; // Bottom border only

                    Paragraph cxTitle = new Paragraph("II. CUSTOMER PROFILE", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11));
                    cxTitle.Alignment = Element.ALIGN_LEFT; // Align the title to the left
                    cell.AddElement(cxTitle);
                    cxtable.AddCell(cell);
                    doc.Add(cxtable);

                    // Retrieve customer data based on customer_id (replace with actual data retrieval code)
                    string customerFirstName;
                    string customerLastName;
                    string customerPhone;
                    string customerEmail;
                    string customerAddress;

                    // Call the function to retrieve customer information
                    getCustomerInfo(customer_id, out customerFirstName, out customerLastName, out customerPhone, out customerEmail, out customerAddress);

                    // Create a table for customer information
                    PdfPTable customerTable = new PdfPTable(2);
                    customerTable.SpacingBefore = 0;
                    customerTable.SpacingAfter = 5;
                    customerTable.WidthPercentage = 100;
                    customerTable.SetWidths(new float[] { 3f, 7f });
                    customerTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    // PdfPCell cell;

                    // First Name
                    cell = new PdfPCell(new Phrase("First Name            :", boldFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerTable.AddCell(cell);

                    cell = new PdfPCell(new Phrase(customerFirstName, normalFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerTable.AddCell(cell);

                    // Last Name
                    cell = new PdfPCell(new Phrase("Last Name            :", boldFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerTable.AddCell(cell);

                    cell = new PdfPCell(new Phrase(customerLastName, normalFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerTable.AddCell(cell);

                    // Contact Phone
                    cell = new PdfPCell(new Phrase("Contact Phone     :", boldFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerTable.AddCell(cell);

                    cell = new PdfPCell(new Phrase(customerPhone, normalFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerTable.AddCell(cell);

                    // Contact Email
                    cell = new PdfPCell(new Phrase("Contact Email      :", boldFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerTable.AddCell(cell);

                    cell = new PdfPCell(new Phrase(customerEmail, normalFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerTable.AddCell(cell);

                    // Address
                    cell = new PdfPCell(new Phrase("Address                :", boldFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerTable.AddCell(cell);

                    cell = new PdfPCell(new Phrase(customerAddress, normalFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerTable.AddCell(cell);

                    // Add the customer table to the document
                    doc.Add(customerTable);


                    // Create a table with one cell
                    PdfPTable purchasetable = new PdfPTable(1);
                    purchasetable.WidthPercentage = 100; // 100% width

                    // Create a PdfPCell to hold your paragraph
                    cell = new PdfPCell();
                    cell.Border = PdfPCell.BOTTOM_BORDER; // Bottom border only

                    Paragraph purchaseTitle = new Paragraph("III. PURCHASE SUMMARY", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11));
                    purchaseTitle.Alignment = Element.ALIGN_LEFT; // Align the title to the left
                    cell.AddElement(purchaseTitle);
                    purchasetable.AddCell(cell);
                    doc.Add(purchasetable);

                    // Table for purchased items
                    PdfPTable table = new PdfPTable(4); // 5 columns for Quantity, Description, Unit Price, Subtotal, and Discount
                    table.WidthPercentage = 100;
                    table.SpacingBefore = 5f;
                    table.SetWidths(new float[] { 1f, 7f, 1.5f, 1.5f });
                    table.AddCell(new PdfPCell(new Phrase("Qty", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase("Description", boldFont)) { HorizontalAlignment = Element.ALIGN_LEFT });
                    table.AddCell(new PdfPCell(new Phrase("Unit Price", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    table.AddCell(new PdfPCell(new Phrase("Subtotal", boldFont)) { HorizontalAlignment = Element.ALIGN_CENTER });

                    // Add your order items to the table
                    foreach (OrderItem item in orderItems)
                    {
                        // Create a cell with the normalFont for text alignment and formatting
                        PdfPCell quantityCell = new PdfPCell(new Phrase(item.Quantity.ToString(), normalFont));
                        quantityCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        quantityCell.VerticalAlignment = Element.ALIGN_MIDDLE; // Add this line
                        table.AddCell(quantityCell);

                        PdfPCell descriptionCell = new PdfPCell(new Phrase(item.ItemName, normalFont));
                        descriptionCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        descriptionCell.VerticalAlignment = Element.ALIGN_MIDDLE; // Add this line
                        table.AddCell(descriptionCell);

                        // Format price and subtotal using normalFont
                        PdfPCell priceCell = new PdfPCell(new Phrase(item.Price.ToString("C", new CultureInfo("en-PH")), normalFont));
                        priceCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        priceCell.VerticalAlignment = Element.ALIGN_MIDDLE; // Add this line
                        table.AddCell(priceCell);

                        PdfPCell subtotalCell = new PdfPCell(new Phrase(item.Subtotal.ToString("C", new CultureInfo("en-PH")), normalFont));
                        subtotalCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        subtotalCell.VerticalAlignment = Element.ALIGN_MIDDLE; // Add this line
                        table.AddCell(subtotalCell);
                    }

                    table.SpacingAfter = 10f;
                    // Add the table to the document
                    doc.Add(table);

                    // Total Amount
                    decimal amountAfterDiscount = total_amount - discount_amount;
                    decimal vatRateTotal = 0.12m; // Assuming a 12% VAT rate for the total amount
                    decimal vatAmountTotal = amountAfterDiscount * vatRateTotal;
                    decimal vatableAmountTotal = amountAfterDiscount - vatAmountTotal;

                    // Use a different font that supports the peso sign (e.g., Arial)
                    var pesoFont = FontFactory.GetFont("Calibri", 10);


                    // Create a table for the total amount, discount, amount after discount, vatable amount, and VAT amount
                    PdfPTable summaryTable = new PdfPTable(3); // Use 3 columns
                    summaryTable.WidthPercentage = 100;
                    summaryTable.SetWidths(new float[] { 8.2f, 0.3f, 1.5f }); // Adjust column widths as needed
                    summaryTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    if (isDiscountApplied)
                    {
                        // Total Amount
                        cell = new PdfPCell(new Phrase("Amount Before Discount  :", boldFont));
                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        summaryTable.AddCell(cell);

                        // Peso sign
                        cell = new PdfPCell(new Phrase("P", pesoFont)); // Use Unicode character for ₱
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                        summaryTable.AddCell(cell);

                        // Total Amount Value
                        cell = new PdfPCell(new Phrase(total_amount.ToString("0.00"), normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                        summaryTable.AddCell(cell);

                        // Discount Amount
                        cell = new PdfPCell(new Phrase("Discount Amount  :", boldFont));
                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        summaryTable.AddCell(cell);

                        // Peso sign
                        cell = new PdfPCell(new Phrase("P", pesoFont)); // Use Unicode character for ₱
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                        summaryTable.AddCell(cell);

                        // Discount Amount Value
                        cell = new PdfPCell(new Phrase(discount_amount.ToString("0.00"), normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                        summaryTable.AddCell(cell);
                    }



                    var redFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.RED); // Create a red font

                    // Amount After Discount
                    cell = new PdfPCell(new Phrase("Total Amount Due  :", redFont));
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    summaryTable.AddCell(cell);

                    // Peso sign
                    cell = new PdfPCell(new Phrase("P", redFont)); // Use Unicode character for ₱
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    summaryTable.AddCell(cell);

                    // Amount After Discount Value
                    cell = new PdfPCell(new Phrase(amountAfterDiscount.ToString("0.00"), redFont)); // Use the red font
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    summaryTable.AddCell(cell);

                    DateTime paymentDueDate = DateTime.Now.AddDays(7);


                    // Vatable Amount (if needed)
                    cell = new PdfPCell(new Phrase("Vatable Amount  :", boldFont));
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    summaryTable.AddCell(cell);

                    // Peso sign
                    cell = new PdfPCell(new Phrase("P", pesoFont)); // Use Unicode character for ₱
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    summaryTable.AddCell(cell);

                    // Vatable Amount Value (if needed)
                    cell = new PdfPCell(new Phrase(vatableAmountTotal.ToString("0.00"), normalFont));
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    summaryTable.AddCell(cell);

                    // VAT Amount (if needed)
                    cell = new PdfPCell(new Phrase("VAT Amount  :", boldFont));
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    summaryTable.AddCell(cell);

                    // Peso sign
                    cell = new PdfPCell(new Phrase("P", pesoFont)); // Use Unicode character for ₱
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    summaryTable.AddCell(cell);

                    // VAT Amount Value (if needed)
                    cell = new PdfPCell(new Phrase(vatAmountTotal.ToString("0.00"), normalFont));
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    summaryTable.AddCell(cell);

                    // Payment Due Date
                    cell = new PdfPCell(new Phrase("Payment Due Date  :", redFont));
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    summaryTable.AddCell(cell);

                    // Peso sign (for alignment)
                    cell = new PdfPCell(new Phrase(" ", redFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    summaryTable.AddCell(cell);

                    // Payment Due Date Value (7 days from the current date)
                    cell = new PdfPCell(new Phrase(paymentDueDate.ToString("yyyy-MM-dd"), redFont));
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    summaryTable.AddCell(cell);

                    // Add the table to the document
                    doc.Add(summaryTable);


                    // Create a table with one cell
                    PdfPTable confirmation = new PdfPTable(1);
                    confirmation.WidthPercentage = 100; // 100% width
                    confirmation.SpacingAfter = 10f;

                    // Create a PdfPCell to hold your paragraph
                    cell = new PdfPCell();
                    cell.Border = PdfPCell.BOTTOM_BORDER; // Bottom border only

                    Paragraph confirmationTitle = new Paragraph("IV. CONFIRMATION", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11));
                    confirmationTitle.Alignment = Element.ALIGN_LEFT; // Align the title to the left
                    cell.AddElement(confirmationTitle);
                    confirmation.AddCell(cell);
                    doc.Add(confirmation);


                    // Create a table for the processed by and received by information
                    PdfPTable signatureTable = new PdfPTable(2);
                    signatureTable.WidthPercentage = 100;
                    signatureTable.SpacingBefore = 5f;
                    signatureTable.SetWidths(new float[] { 7f, 3f });
                    signatureTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    // Processed by
                    cell = new PdfPCell(new Phrase("Processed by  :", boldFont));
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell.Border = PdfPCell.NO_BORDER;
                    signatureTable.AddCell(cell);

                    // Create a nested table for the employee name and date
                    PdfPTable processedByTable = new PdfPTable(1);
                    processedByTable.DefaultCell.Border = PdfPCell.NO_BORDER;

                    // Add employee name (replace with your employee name variable)
                    cell = new PdfPCell(new Phrase("\n" + employee_name, normalFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = PdfPCell.BOTTOM_BORDER;
                    processedByTable.AddCell(cell);

                    // Add the current date
                    cell = new PdfPCell(new Phrase(DateTime.Now.ToString("yyyy-MM-dd"), normalFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = PdfPCell.BOTTOM_BORDER;
                    processedByTable.AddCell(cell);

                    // Add the nested table to the "Processed by" section
                    cell = new PdfPCell(processedByTable);
                    cell.Border = PdfPCell.NO_BORDER;
                    signatureTable.AddCell(cell);


                    // Received by
                    cell = new PdfPCell(new Phrase("Received by  :", boldFont));
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell.Border = PdfPCell.NO_BORDER;
                    signatureTable.AddCell(cell);

                    // Create a nested table for the employee name and date
                    PdfPTable receivedByTable = new PdfPTable(1);
                    receivedByTable.DefaultCell.Border = PdfPCell.NO_BORDER;

                    // Add empty lines for "Received by" (two lines)
                    cell = new PdfPCell(new Phrase("\n ", normalFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = PdfPCell.BOTTOM_BORDER; // Only the bottom border
                    receivedByTable.AddCell(cell);

                    // Add empty lines for "Received by" (two lines)
                    cell = new PdfPCell(new Phrase(" ", normalFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = PdfPCell.BOTTOM_BORDER; // Only the bottom border
                    receivedByTable.AddCell(cell);

                    // Add the nested table to the "Processed by" section
                    cell = new PdfPCell(receivedByTable);
                    cell.Border = PdfPCell.NO_BORDER;
                    signatureTable.AddCell(cell);


                    // Add the signature table to the document
                    doc.Add(signatureTable);


                    // Create a table with one cell
                    PdfPTable reminderTable = new PdfPTable(1);
                    reminderTable.WidthPercentage = 100; // 100% width

                    // Create a PdfPCell to hold your paragraph
                    cell = new PdfPCell();
                    cell.Border = PdfPCell.BOTTOM_BORDER; // Bottom border only

                    Paragraph reminderTitle = new Paragraph("V. REMINDERS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12));
                    reminderTitle.Alignment = Element.ALIGN_LEFT; // Align the title to the left
                    cell.AddElement(reminderTitle);
                    reminderTable.AddCell(cell);
                    doc.Add(reminderTable);


                    Font footerFont = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 7);


                    // Add the footer text to the document
                    string footerText = @"
                Payment Terms:
                - Payment is due upon receipt.
                - Late payments may incur additional charges.
                - For any payment-related inquiries, please contact our accounts department.

                Return Policy:
                - Goods once sold are not returnable.
                - If you have received damaged or incorrect items, please contact us within 7 days for a replacement or refund.

                Customer Support:
                - For any questions or assistance, please feel free to contact our customer support team.
                - Phone: [Your Contact Number]
                - Email: [Your Support Email]

                Thank you for choosing New Bernales Hardware Store! We appreciate your business.
";

                    Paragraph footerParagraph = new Paragraph(footerText, footerFont);
                    footerParagraph.Alignment = Element.ALIGN_LEFT;

                    doc.Add(footerParagraph);
                    doc.Add(new Chunk(new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1)));

                    // Close the document
                    doc.Close();

                    // Display the PDF in a print preview dialog
                    System.Diagnostics.Process.Start(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while generating the PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void getCustomerInfo(int customer_id, out string first_name, out string last_name, out string contact_phone, out string contact_email, out string address)
        {
            first_name = "";
            last_name = "";
            contact_phone = "";
            contact_email = "";
            address = "";

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    string query = "SELECT first_name, last_name, contact_email, contact_phone, address " +
                                    "FROM customers " +
                                    "WHERE customer_id = @customer_id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customer_id", customer_id);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                first_name = reader.GetString("first_name");
                                last_name = reader.GetString("last_name");
                                contact_email = reader.GetString("contact_email");
                                contact_phone = reader.GetString("contact_phone");
                                address = reader.GetString("address");
                            }
                            else
                            {
                                // Handle the case where the customer with the specified ID was not found.
                                // You can display an error message or perform other actions.
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during database access.
                    // You can display an error message or perform other error-handling actions.
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}
