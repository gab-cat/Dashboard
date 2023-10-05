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
            UpdateProductStock(item.ProductID, item.Quantity * -1);
            orderItems.Add(item);
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
                productStockData[productID] += quantityChange;
            }
        }

        private bool isItemAddingEnabled = true;
        private List<OrderItem> orderItems = new List<OrderItem>();
        private DataTable orderDataTable; 
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
            orderGrid.Columns["#"].Width = 25; 
            orderGrid.Columns["Product ID"].Width = 65; 
            orderGrid.Columns["Item"].Width = 135; 
            orderGrid.Columns["Description"].Width = 245;
            orderGrid.Columns["Price"].Width = 65; 
            orderGrid.Columns["Quantity"].Width = 70; 
            orderGrid.Columns["Subtotal"].Width = 70; 
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

            orderGrid.ClearSelection();
            UpdateOrderGrid();
            UpdateTotalOrderAmount();
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
                DataGridViewRow selectedRow = orderGrid.Rows[e.RowIndex];
                string productIDToRemove = selectedRow.Cells["Product ID"].Value.ToString();
                OrderItem itemToRemove = orderItems.FirstOrDefault(item => item.ProductID == productIDToRemove);

                if (itemToRemove != null)
                {
                    UpdateProductStock(itemToRemove.ProductID, itemToRemove.Quantity);
                    orderItems.Remove(itemToRemove);
                }

                orderGrid.Rows.Remove(selectedRow);

                // Update the order grid and total order amount
                UpdateTotalOrderAmount();
                UpdateOrderGrid();

                // Remove the item from the pending order JSON file
                if (AddItems.pendingOrder.ContainsKey(productIDToRemove))
                {
                    AddItems.pendingOrder.Remove(productIDToRemove);
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
                                    string deleteQuery = "DELETE FROM sales WHERE sale_id = @sale_id";
                                    MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection, transaction);
                                    deleteCommand.Parameters.AddWithValue("@sale_id", sale_id);
                                    deleteCommand.ExecuteNonQuery();
                                }
                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("An error occurred while canceling the transaction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
         this.Close();

         // Show the previously hidden Dashboard and FormOrder forms
         Dashboard dashboardForm = Application.OpenForms["Dashboard"] as Dashboard;
         if (dashboardForm != null)
         {
            dashboardForm.Show(); 
         }

         FormOrder formOrderForm = Application.OpenForms["FormOrder"] as FormOrder;
         if (formOrderForm != null)
         {
         formOrderForm.Show(); 
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
                        string currentDate = DateTime.Now.ToString("yyyyMMdd");
                        string transactionID = currentDate + newSaleID.ToString();
                        transaction_id = transactionID;
                        txtTransactionID.Text = transactionID;

                        // Insert the new sale_id into the sales table
                        string insertQuery = "INSERT INTO sales (sale_id) VALUES (@sale_id)";
                        MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection, transaction);
                        insertCommand.Parameters.AddWithValue("@sale_id", newSaleID);
                        insertCommand.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
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

            AddItems.pendingOrder.Clear();

            // Save the empty pending order data to the JSON file
            SavePendingOrderToFile(AddItems.pendingOrder);
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

            bool isAuthenticated = CheckAuthentication(username, password);

            if (isAuthenticated)
            {
                string userRole = GetUserRole(username);

                // Check if the user is an Admin or Manager to apply a discount
                if (userRole == "Admin" || userRole == "Manager")
                {
                    string discountInput = Interaction.InputBox("Enter discount percentage:", "Discount");

                    if (decimal.TryParse(discountInput, out decimal discountPercentage) && discountPercentage >= 0)
                    {
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

                            // Calculate VAT and vatable amount 
                            decimal vatRate = 0.12m; // 12% VAT rate
                            decimal vatableAmount = totalAmount / (1 + vatRate);
                            decimal vatAmount = totalAmount - vatableAmount;

                            // Update the vatable amount and VAT text boxes
                            txtVatable.Text = vatableAmount.ToString("0.00");
                            txtVAT.Text = vatAmount.ToString("0.00");

                            isItemAddingEnabled = false;

                            isDiscountApplied = true;

                            ApplyDiscountToOrderItems(discountPercentage);

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
                    row.Cells["Subtotal"] is DataGridViewTextBoxCell subtotalCell) 
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
                            subtotalCell.Value = subtotal.ToString("0.00"); 
                            subtotalCell.Style.ForeColor = Color.Blue; 

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
                string query = "SELECT COUNT(*) FROM logins WHERE username = @username AND password = @password";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                int count = Convert.ToInt32(command.ExecuteScalar());

                return (count == 1);
            }
        }

        private string GetUserRole(string username)
        {
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                string query = "SELECT role FROM logins WHERE username = @username";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                object role = command.ExecuteScalar();
                if (role != null)
                {
                    return role.ToString();
                }
                else
                {
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

            // Calculate VAT and vatable amount
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
                btnNewTransaction.PerformClick();
                e.Handled = true; 
            }
            if (e.KeyCode == Keys.F2)
            {
                btnAddItem.PerformClick();
                e.Handled = true; 
            }
            if (e.KeyCode == Keys.F3)
            {
                btnDiscount.PerformClick();
                e.Handled = true; 
            }
            if (e.KeyCode == Keys.F4)
            {
                btnCreateOrder.PerformClick();
                e.Handled = true; 
            }
            if (e.KeyCode == Keys.F5)
            {
                BacktoForm.PerformClick();
                e.Handled = true; 
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
                    AddMemo memo = new AddMemo(customer_id, employee_name, "Create Order", memotext);
                    memo.ShowDialog();

                    if (isDiscountApplied == true)
                    {
                        string discountmemo = Environment.NewLine + "Manager Discretion: " + supervisor_name + Environment.NewLine + "Applied " + discountPercent + "% discount for Sale ID: " + new_sale_id + Environment.NewLine +
                            "Total discount applied for current sale is ₱ " + discount_amount;
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
                        insertSaleCommand.Parameters.AddWithValue("@sale_date", DateTime.Now); 
                        insertSaleCommand.Parameters.AddWithValue("@total_amount", totalAmount); 
                        insertSaleCommand.Parameters.AddWithValue("@payment_status", "Pending"); 
                        insertSaleCommand.Parameters.AddWithValue("@discount", discount_amount);
                        insertSaleCommand.Parameters.AddWithValue("@sale_id", insertSaleId);

                        insertSaleCommand.ExecuteNonQuery();

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
                            updateProductStockCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
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
            float leftMargin = 20f;    
            float rightMargin = 20f;   
            float topMargin = 10f;     
            float bottomMargin = 10f;  
            Document doc = new Document(new iTextSharp.text.Rectangle(PageSize.A4.Rotate().Width / 2, PageSize.A4.Height));
            doc.SetMargins(leftMargin, rightMargin, topMargin, bottomMargin);

            try
            {
                string invoiceDirectory = "Invoices";
                Directory.CreateDirectory(invoiceDirectory); // Create the directory if it doesn't exist
                string filePath = Path.Combine(invoiceDirectory, $"{customerId}_{saleId}.pdf");

                // Create a FileStream to write the PDF file
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
                    var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 9);

                    doc.Open();

                    // Create a table cell for the business name
                    PdfPCell businessNameCell = new PdfPCell(new Phrase("New Bernales Hardware Store", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24)));
                    businessNameCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    businessNameCell.BackgroundColor = BaseColor.BLACK; 
                    businessNameCell.BorderColor = BaseColor.WHITE; 
                    businessNameCell.Padding = 10; 
                    businessNameCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                    // Create a table with a single cell and remove its border
                    PdfPTable businessNameTable = new PdfPTable(1);
                    businessNameTable.DefaultCell.Border = PdfPCell.NO_BORDER;
                    businessNameTable.WidthPercentage = 100; 

                    businessNameTable.AddCell(businessNameCell);
                    businessNameCell.Phrase.Font.Color = BaseColor.WHITE;

                    doc.Add(businessNameTable);

                    // Create a PdfPTable for the contact information
                    PdfPTable contactInfoTable = new PdfPTable(1);
                    contactInfoTable.WidthPercentage = 100;
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
                    doc.Add(contactInfoTable);



                    PdfPTable orderedtable = new PdfPTable(1);
                    orderedtable.WidthPercentage = 100; 
                    orderedtable.SpacingBefore = 12f;

                    PdfPCell cell = new PdfPCell();
                    cell.Border = PdfPCell.BOTTOM_BORDER; 

                    // Create the Paragraph
                    Paragraph orderTitle = new Paragraph("I. ORDER INVOICE FORM", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11));
                    orderTitle.Alignment = Element.ALIGN_LEFT; 
                    cell.AddElement(orderTitle);
                    orderedtable.AddCell(cell);
                    doc.Add(orderedtable);


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
                    cell.Border = PdfPCell.BOTTOM_BORDER; 

                    Paragraph cxTitle = new Paragraph("II. CUSTOMER PROFILE", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11));
                    cxTitle.Alignment = Element.ALIGN_LEFT;
                    cell.AddElement(cxTitle);
                    cxtable.AddCell(cell);
                    doc.Add(cxtable);

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
                    cell.Border = PdfPCell.BOTTOM_BORDER;

                    Paragraph purchaseTitle = new Paragraph("III. PURCHASE SUMMARY", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11));
                    purchaseTitle.Alignment = Element.ALIGN_LEFT; 
                    cell.AddElement(purchaseTitle);
                    purchasetable.AddCell(cell);
                    doc.Add(purchasetable);

                    // Table for purchased items
                    PdfPTable table = new PdfPTable(4); 
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
                        PdfPCell quantityCell = new PdfPCell(new Phrase(item.Quantity.ToString(), normalFont));
                        quantityCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        quantityCell.VerticalAlignment = Element.ALIGN_MIDDLE; 
                        table.AddCell(quantityCell);

                        PdfPCell descriptionCell = new PdfPCell(new Phrase(item.ItemName, normalFont));
                        descriptionCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        descriptionCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        table.AddCell(descriptionCell);

                        // Format price and subtotal using normalFont
                        PdfPCell priceCell = new PdfPCell(new Phrase(item.Price.ToString("C", new CultureInfo("en-PH")), normalFont));
                        priceCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        priceCell.VerticalAlignment = Element.ALIGN_MIDDLE; 
                        table.AddCell(priceCell);

                        PdfPCell subtotalCell = new PdfPCell(new Phrase(item.Subtotal.ToString("C", new CultureInfo("en-PH")), normalFont));
                        subtotalCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        subtotalCell.VerticalAlignment = Element.ALIGN_MIDDLE; 
                        table.AddCell(subtotalCell);
                    }

                    table.SpacingAfter = 10f;
                    doc.Add(table);

                    // Total Amount
                    decimal amountAfterDiscount = total_amount - discount_amount;
                    decimal vatRateTotal = 0.12m; 
                    decimal vatAmountTotal = amountAfterDiscount * vatRateTotal;
                    decimal vatableAmountTotal = amountAfterDiscount - vatAmountTotal;
                    var pesoFont = FontFactory.GetFont("Calibri", 10);


                    // Create a table for the total amount, discount, amount after discount, vatable amount, and VAT amount
                    PdfPTable summaryTable = new PdfPTable(3); 
                    summaryTable.WidthPercentage = 100;
                    summaryTable.SetWidths(new float[] { 8.2f, 0.3f, 1.5f }); 
                    summaryTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    if (isDiscountApplied)
                    {
                        // Total Amount
                        cell = new PdfPCell(new Phrase("Amount Before Discount  :", boldFont));
                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                        summaryTable.AddCell(cell);

                        // Peso sign
                        cell = new PdfPCell(new Phrase("P", pesoFont)); 
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
                        cell = new PdfPCell(new Phrase("P", pesoFont));
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                        cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                        summaryTable.AddCell(cell);

                        // Discount Amount Value
                        cell = new PdfPCell(new Phrase(discount_amount.ToString("0.00"), normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                        summaryTable.AddCell(cell);
                    }



                    var redFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.RED); 

                    // Amount After Discount
                    cell = new PdfPCell(new Phrase("Total Amount Due  :", redFont));
                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    summaryTable.AddCell(cell);

                    // Peso sign
                    cell = new PdfPCell(new Phrase("P", redFont)); 
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    summaryTable.AddCell(cell);

                    // Amount After Discount Value
                    cell = new PdfPCell(new Phrase(amountAfterDiscount.ToString("0.00"), redFont)); 
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
                    cell = new PdfPCell(new Phrase("P", pesoFont)); 
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
                    cell = new PdfPCell(new Phrase("P", pesoFont)); 
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
                    confirmation.WidthPercentage = 100; 
                    confirmation.SpacingAfter = 10f;

                    // Create a PdfPCell to hold your paragraph
                    cell = new PdfPCell();
                    cell.Border = PdfPCell.BOTTOM_BORDER; 

                    Paragraph confirmationTitle = new Paragraph("IV. CONFIRMATION", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11));
                    confirmationTitle.Alignment = Element.ALIGN_LEFT; 
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

                    // Add empty lines for "Received by" 
                    cell = new PdfPCell(new Phrase("\n ", normalFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = PdfPCell.BOTTOM_BORDER; 
                    receivedByTable.AddCell(cell);

                    // Add empty lines for "Received by" 
                    cell = new PdfPCell(new Phrase(" ", normalFont));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    cell.Border = PdfPCell.BOTTOM_BORDER; 
                    receivedByTable.AddCell(cell);

                    // Add the nested table to the "Processed by" section
                    cell = new PdfPCell(receivedByTable);
                    cell.Border = PdfPCell.NO_BORDER;
                    signatureTable.AddCell(cell);


                    // Add the signature table to the document
                    doc.Add(signatureTable);


                    // Create a table with one cell
                    PdfPTable reminderTable = new PdfPTable(1);
                    reminderTable.WidthPercentage = 100; 

                    // Create a PdfPCell to hold your paragraph
                    cell = new PdfPCell();
                    cell.Border = PdfPCell.BOTTOM_BORDER; 

                    Paragraph reminderTitle = new Paragraph("V. REMINDERS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12));
                    reminderTitle.Alignment = Element.ALIGN_LEFT; 
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
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
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
