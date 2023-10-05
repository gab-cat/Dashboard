using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Dashboard.Forms
{
    public partial class FormOrder : Form
    {
        private int customerId;
        private string first_name;
        private string last_name;
        private string contact_email;
        private string contact_phone;
        private string address;
        private string join_date;
        private string username;
        private string role;

        private MySqlConnection connection;
      
        public int CustomerId
        {
            get { return customerId; }
            set
            {
                customerId = value;
            }
        }
        public FormOrder(int customer_id, string userName, string Role)
        {
            InitializeComponent();
            CustomerId = customer_id;
            username = userName;
            role = Role;
            loadCustomerProfile();


        }

        private void loadCustomerProfile()
        {
            loadMemos(CustomerId);
            CalculatePaymentSummary(CustomerId);
            loadIndicators(CustomerId);
            getCustomerInfo(CustomerId);
            LoadSalesHistoryForCustomer(CustomerId);
        }
        private void getCustomerInfo(int customer_id)
        {
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    string query = "SELECT customer_id, first_name, last_name, contact_email, contact_phone, address, join_date " +
                                    "FROM customers " +
                                    "WHERE customer_id = @customer_id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customer_id", customer_id);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                customerId = reader.GetInt32("customer_id");
                                first_name = reader.GetString("first_name");
                                last_name = reader.GetString("last_name");
                                contact_email = reader.GetString("contact_email");
                                contact_phone = reader.GetString("contact_phone");
                                address = reader.GetString("address");

                                if (!reader.IsDBNull(reader.GetOrdinal("join_date")))
                                {
                                    join_date = reader.GetDateTime("join_date").ToString("yyyy-MM-dd");
                                }
                                else
                                {
                                    // Handle the case where join_date is NULL in the database
                                    join_date = "N/A"; // or any other appropriate default value
                                }
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


 

            // Set UI elements here, outside the try-catch-finally block
            label2.Text = first_name + " " + last_name;
            label1.Text = "Customer ID    : " + customerId.ToString();
            textBox2.Text = contact_phone;
            textBox1.Text = contact_email;
            textBox3.Text = address;
            textBox4.Text = join_date;

            textBox1.GotFocus += (sender, e) => { this.Focus(); };
            textBox2.GotFocus += (sender, e) => { this.Focus(); };
            textBox3.GotFocus += (sender, e) => { this.Focus(); };
        }


        private void loadIndicators(int customer_id)
        {
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    // Query to retrieve indicator values based on customer ID
                    string query = "SELECT professional_firm, sms, email, phone " +
                                   "FROM indicators WHERE customer_id = @customerId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customerId", customerId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Check if indicator values were found
                            {
                                // Check checkboxes based on indicator values (1 or 0)
                                chkProfessional.Checked = Convert.ToInt32(reader["professional_firm"]) == 1;
                                chkSMS.Checked = Convert.ToInt32(reader["sms"]) == 1;
                                chkEmail.Checked = Convert.ToInt32(reader["email"]) == 1;
                                chkPhone.Checked = Convert.ToInt32(reader["phone"]) == 1;
                            }
                            else
                            {
                                // Handle the case where no indicator values were found (optional)
                                // You can clear checkboxes or show a message here if needed.
                            }

                            if (IsPastDue(customerId))
                            {
                                chkPastDue.Checked = true; // Check the checkbox if past due
                            }
                            else
                            {
                                chkPastDue.Checked = false; // Uncheck the checkbox if not past due
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

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            label1.ForeColor = ThemeColor.SecondaryColor;
            label2.ForeColor = ThemeColor.SecondaryColor;
            guna2GroupBox1.CustomBorderColor = ThemeColor.SecondaryColor;
            button1.BackColor = ThemeColor.SecondaryColor;
            button2.BackColor = ThemeColor.SecondaryColor;
            button3.BackColor = ThemeColor.SecondaryColor;
            btnCancelOrder.BackColor = Color.White;
            button5.BackColor = ThemeColor.SecondaryColor;
            button6.BackColor = ThemeColor.SecondaryColor;

            button1.ForeColor = Color.White;
            button2.ForeColor = Color.White;
            button3.ForeColor = Color.White;
            btnCancelOrder.ForeColor = ThemeColor.SecondaryColor;
            button5.ForeColor = Color.White;
            button6.ForeColor = Color.White;

            button1.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            button2.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            button3.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            btnCancelOrder.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            button5.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            button6.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            dataGridViewMemos.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.SecondaryColor;
            dataGridViewMemos.ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;


            salesData.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.SecondaryColor;
            salesData.ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;

            saleItemsGrid.ColumnHeadersDefaultCellStyle.BackColor= ThemeColor.SecondaryColor;
            saleItemsGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor= ThemeColor.SecondaryColor;

            gunaButton1.ForeColor = ThemeColor.SecondaryColor;
            gunaButton1.BorderColor = ThemeColor.SecondaryColor;
            gunaButton1.OnHoverBaseColor = ThemeColor.SecondaryColor;
            gunaButton1.OnHoverBorderColor = Color.White;
            gunaButton2.ForeColor = ThemeColor.SecondaryColor;
            gunaButton2.BorderColor = ThemeColor.SecondaryColor;
            gunaButton2.OnHoverBaseColor = ThemeColor.SecondaryColor;
            gunaButton2.OnHoverBorderColor = Color.White;

            btnReload.FillColor = ThemeColor.SecondaryColor;

        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void Copy_Click(object sender, EventArgs e)
        {

        }

        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Copy.Items.Clear();
                Copy.Items.Add("Copy");
                Copy.ItemClicked += new ToolStripItemClickedEventHandler(Copy_ItemClicked);
                Copy.Show(Cursor.Position);
            }
        }
        private void Copy_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Clipboard.SetText(label2.Text);
        }

        private void loadMemos(int customerId)
        {
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
                            // Clear existing rows and columns in the DataGridView.
                            dataGridViewMemos.Rows.Clear();
                            dataGridViewMemos.Columns.Clear();

                            // Add columns to the DataGridView.
                            dataGridViewMemos.Columns.Add("time_date", "Date and Time");
                            dataGridViewMemos.Columns.Add("reason", "Reason");
                            dataGridViewMemos.Columns.Add("employee_name", "Employee Name");

                            while (reader.Read())
                            {
                                // Extract memo details here.
                                DateTime timeDate = reader.GetDateTime("time_date");
                                string reason = reader.GetString("reason");
                                string employeeName = reader.GetString("employee_name");
                                string memoText = reader.GetString("memo_text");

                                // Add the memo details to the DataGridView.
                                dataGridViewMemos.Rows.Add(timeDate, reason, employeeName);

                                // Store the memo text in the DataGridView's Tag property for later retrieval.
                                dataGridViewMemos.Rows[dataGridViewMemos.Rows.Count - 1].Tag = memoText;
                                txtMemo.Text = "Memo: \n" + memoText;
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    // Handle any exceptions here, e.g., connection errors.
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

        private void dataGridViewMemos_SelectionChanged(object sender, EventArgs e)
        {
            // Display the selected memo's text in the txtMemo TextBox.
            if (dataGridViewMemos.SelectedRows.Count > 0)
            {
                // Check if the Tag property is not null before accessing it.
                object selectedMemoTag = dataGridViewMemos.SelectedRows[0].Tag;
                if (selectedMemoTag != null)
                {
                    string selectedMemoText = selectedMemoTag.ToString();
                    txtMemo.Text = "Memo: \n" + selectedMemoText;
                }
                else
                {
                    // Handle the case where the Tag property is null (no memo text associated).
                    txtMemo.Text = "No memo text available for this row.";
                }
            }
        }

        private void CalculatePaymentSummary(int customerId)
        {
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    string query = @"
                                    SELECT
                                        COALESCE(
                                            (SELECT SUM(payment_amount) FROM payments
                                             WHERE customer_id = @customer_id AND payment_method <> 'Refunded'), 0) AS total_paid,
                                        COALESCE(
                                            (SELECT SUM(total_amount) FROM sales
                                             WHERE customer_id = @customer_id AND payment_status <> 'Cancelled'), 0) AS total_payable;";


                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customer_id", customerId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal totalPaid = reader.GetDecimal("total_paid");
                                decimal totalPayable = reader.GetDecimal("total_payable");

                                // Calculate balance due
                                decimal balanceDue = totalPayable - totalPaid;

                                // Set the values in the TextBox controls
                                txtPayable.Text = "₱ " + totalPayable.ToString();
                                txtPayments.Text = "₱ " + totalPaid.ToString();
                                txtBalance.Text = "₱ " + balanceDue.ToString();
                            }
                            else
                            {
                                // Handle the case where no data is found
                                MessageBox.Show("No data found for the customer.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during database access
                    // MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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




        private void button5_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                // The code inside this block is executed while the loading animation is displayed
                AddMemo addmemo = new AddMemo(CustomerId, username);
                addmemo.Show(); // Show the AddMemo form as a dialog
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                // The code inside this block is executed while the loading animation is displayed
                UpdateCustomer update = new UpdateCustomer(CustomerId, username);
                update.Show(); // Show the AddMemo form as a dialog
            });
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                // The code inside this block is executed while the loading animation is displayed
                SendEmail sendEmail = new SendEmail(contact_email, username, CustomerId);
                sendEmail.Show(); // Show the AddMemo form as a dialog
            });
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                // The code inside this block is executed while the loading animation is displayed
                SendSMS smssent = new SendSMS(contact_phone, username, customerId);
                smssent.Show();
            });
        }


        private void LoadSalesHistoryForCustomer(int customerId)
        {
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    string query = "SELECT sale_date AS 'Date', sale_id AS 'Sales ID', " +
                                   "employee_name AS 'Employee', " +
                                   "total_amount AS 'Total', " +
                                   "payment_status AS 'Status' " +
                                   "FROM sales " +
                                   "WHERE customer_id = @customer_id " +
                                   "ORDER BY sale_date DESC";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customer_id", customerId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Create a DataTable to hold the sales data
                            DataTable salesTable = new DataTable();
                            salesTable.Load(reader);

                            // Create a BindingSource and bind it to the DataTable
                            BindingSource salesBindingSource = new BindingSource();
                            salesBindingSource.DataSource = salesTable;

                            // Bind the DataGridView to the BindingSource
                            salesData.DataSource = salesBindingSource;

                            salesData.Columns["Total"].DefaultCellStyle.Format = "C2";
                            salesData.Columns["Total"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-PH");

                            salesData.Columns["Date"].Width = 70; // Adjust the width as needed
                            salesData.Columns["Sales ID"].Width = 50; // Adjust the width as needed
                            salesData.Columns["Employee"].Width = 150; // Adjust the width as needed
                            salesData.Columns["Total"].Width = 100; // Adjust the width as needed
                            salesData.Columns["Status"].Width = 100; // Adjust the width as needed
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during database access.
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



        private void cancelOrder()
        {
            // Check if a row is selected in the DataGridView
            if (salesData.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = salesData.SelectedRows[0];

                // Assuming the status is in a column named "Status" (adjust this according to your actual column name)
                string status = selectedRow.Cells["Status"].Value.ToString();

                // Check if the status is already "Cancelled" or "Completed"
                if (status == "Cancelled" || status == "Completed")
                {
                    // Inform the user that the order cannot be cancelled
                    MessageBox.Show("This order is already Cancelled or Completed and cannot be cancelled again.", "Order Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Display a confirmation dialog
                    DialogResult result = MessageBox.Show("Are you sure you want to cancel this order?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // User confirmed the cancellation

                        // Assuming the sale_id is in a column named "ID" (adjust this according to your actual column name)
                        int saleId = Convert.ToInt32(selectedRow.Cells["Sales ID"].Value);
                        

                        // Get the list of products and quantities for the cancelled order
                        List<Tuple<int, int>> productsToReturn = new List<Tuple<int, int>>();
                        List<string> paymentIdsToRefund = new List<string>();

                        using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                        {
                            // Fetch the products and quantities from the sale_items table
                            string selectItemsQuery = "SELECT product_id, quantity_sold FROM sale_items WHERE sale_id = @saleId";
                            MySqlCommand selectItemsCommand = new MySqlCommand(selectItemsQuery, connection);
                            selectItemsCommand.Parameters.AddWithValue("@saleId", saleId);

                            using (MySqlDataReader reader = selectItemsCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int productId = reader.GetInt32("product_id");
                                    int quantitySold = reader.GetInt32("quantity_sold");
                                    productsToReturn.Add(new Tuple<int, int>(productId, quantitySold));
                                }
                            }
                        }


                        // Execute an SQL query to update the payment_status to "Cancelled"
                        using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                        {
                            string updateQuery = "UPDATE sales SET payment_status = 'Cancelled' WHERE sale_id = @saleId";
                            MySqlCommand command = new MySqlCommand(updateQuery, connection);
                            command.Parameters.AddWithValue("@saleId", saleId);

                            // Execute the SQL command
                            command.ExecuteNonQuery();
                        }


                        // Remove the related rows from the sale_items table
                        using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                        {
                            string deleteItemsQuery = "DELETE FROM sale_items WHERE sale_id = @saleId";
                            MySqlCommand deleteItemsCommand = new MySqlCommand(deleteItemsQuery, connection);
                            deleteItemsCommand.Parameters.AddWithValue("@saleId", saleId);

                            // Execute the SQL command to delete the rows
                            deleteItemsCommand.ExecuteNonQuery();
                        }


                        // Return the stock for each product
                        foreach (var productTuple in productsToReturn)
                        {
                            int productId = productTuple.Item1;
                            int quantitySold = productTuple.Item2;

                            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                            {
                                string updateStockQuery = "UPDATE products SET quantity_in_stock = quantity_in_stock + @quantitySold WHERE product_id = @productId";
                                MySqlCommand updateStockCommand = new MySqlCommand(updateStockQuery, connection);
                                updateStockCommand.Parameters.AddWithValue("@quantitySold", quantitySold);
                                updateStockCommand.Parameters.AddWithValue("@productId", productId);

                                // Execute the SQL command to return the stock
                                updateStockCommand.ExecuteNonQuery();
                            }
                        }

                        string memo_text = Environment.NewLine + "Order successfully cancelled for Sale ID " + saleId + Environment.NewLine + "Cancellation processed by " + username;
                        LoadingScreenManager.ShowLoadingScreen(() =>
                        {
                            // The code inside this block is executed while the loading animation is displayed
                            AddMemo memo = new AddMemo(customerId, username, "Order Cancellation", memo_text);
                            memo.Show();
                        });

                        LoadSalesHistoryForCustomer(customerId);
                    }
                }
            }
            else
            {
                // Inform the user to select a row before cancelling the order
                MessageBox.Show("Please select an order to cancel.", "Order Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadSaleItemsForSale(int salesId)
        {
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {

                    string query = "SELECT si.quantity_sold AS 'Qty', si.product_id AS 'ID', " +
                                   "p.product_name AS 'Item', si.unit_price AS 'Unit Price', " +
                                   "si.subtotal AS 'Subtotal' " +
                                   "FROM sale_items si " +
                                   "INNER JOIN products p ON si.product_id = p.product_id " +
                                   "WHERE si.sale_id = @sale_id";


                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@sale_id", salesId); // Change to @sale_id

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Create a DataTable to hold the sale items data
                            DataTable saleItemsTable = new DataTable();
                            saleItemsTable.Load(reader);

                            // Create a BindingSource and bind it to the DataTable
                            BindingSource saleItemsBindingSource = new BindingSource();
                            saleItemsBindingSource.DataSource = saleItemsTable;

                            // Bind the DataGridView to the BindingSource
                            saleItemsGrid.DataSource = saleItemsBindingSource;

                            saleItemsGrid.Columns["Unit Price"].DefaultCellStyle.Format = "C2";
                            saleItemsGrid.Columns["Unit Price"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-PH");
                            saleItemsGrid.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                            saleItemsGrid.Columns["Subtotal"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-PH");

                            saleItemsGrid.Columns["Qty"].Width = 40; // Adjust the width as needed
                            saleItemsGrid.Columns["ID"].Width = 40; // Adjust the width as needed
                            saleItemsGrid.Columns["Item"].Width = 250; // Adjust the width as needed
                            saleItemsGrid.Columns["Unit Price"].Width = 100; // Adjust the width as needed
                            saleItemsGrid.Columns["Subtotal"].Width = 100; // Adjust the width as needed
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during database access.
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

        private void salesData_SelectionChanged(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (salesData.SelectedRows.Count > 0)
            {
                // Get the selected sales_id from the first selected row
                int selectedSalesId = Convert.ToInt32(salesData.SelectedRows[0].Cells["Sales ID"].Value);
                double totalAmount = Convert.ToSingle(salesData.SelectedRows[0].Cells["Total"].Value);
                // Load sale items associated with the selected sales_id
                LoadSaleItemsForSale(selectedSalesId);
                totalAmounts(totalAmount);
            }
        }

        private void totalAmounts(double totalAmount)
        {
            grossAmount.Text = "₱ " + totalAmount.ToString("N2"); // Format as currency with two decimal places
            double vatable_amount = totalAmount / 1.12;
            double vat_amount = vatable_amount * 0.12;

            vatableAmount.Text = "₱ " + vatable_amount.ToString("N2"); // Format as currency with two decimal places
            VAT.Text = "₱ " +  vat_amount.ToString("N2"); // Format as currency with two decimal places
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Validation validation = new Validation(contact_phone, contact_email, username, customerId);
            validation.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                // The code inside this block is executed while the loading animation is displayed
                PaymentHistory payment = new PaymentHistory(CustomerId, username);
                payment.Show(); // Show the AddMemo form as a dialog
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chkPastDue.Checked == true)
            {
                MessageBox.Show("The account is currently in past due status. Please make a payment first before creating a new order.", "Create New Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Close or hide the Dashboard and FormOrder forms
            Dashboard dashboardForm = Application.OpenForms["Dashboard"] as Dashboard;
            if (dashboardForm != null)
            {
                dashboardForm.Hide(); // Close the Dashboard form
            }

            FormOrder formOrderForm = Application.OpenForms["FormOrder"] as FormOrder;
            if (formOrderForm != null)
            {
                formOrderForm.Hide(); // Close the FormOrder form
            }

            // Show the POS form
            POS newpos = new POS(customerId, username, role);
            newpos.Show();
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            cancelOrder();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {

            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                // The code inside this block is executed while the loading animation is displayed
                loadCustomerProfile(); // Show the AddMemo form as a dialog
            });

        }

        private bool IsPastDue(int customerId)
        {
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    // Query to get the earliest sale's status for the given customer
                    string query = "SELECT payment_status, sale_date " +
                                   "FROM sales " +
                                   "WHERE customer_id = @customer_id " +
                                   "AND payment_status = 'Pending' " +
                                   "ORDER BY sale_date ASC LIMIT 1";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customer_id", customerId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DateTime saleDate = reader.GetDateTime("sale_date");

                                // Check if the sale is past due (7 days after sale_date)
                                if (DateTime.Now > saleDate.AddDays(7))
                                {
                                    return true; // The sale is past due
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during database access
                    // You can log or display an error message here
                }

                return false; // Default to false if there's an issue or no matching sale
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (chkPastDue.Checked)
            {
                // Display a message box to inform the user
                MessageBox.Show("Changing the indicator here is not allowed. Update the profile instead.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Return the check state to the original state (unchecked)
                chkPastDue.Checked = false;
            }
            else
            {
                // Display a message box to inform the user
                MessageBox.Show("Changing the indicator here is not allowed. Update the profile instead.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Return the check state to the original state (checked)
                chkPastDue.Checked = true;
            }
        }

        private void chkProfessional_Click(object sender, EventArgs e)
        {
            if (chkProfessional.Checked)
            {
                // Display a message box to inform the user
                MessageBox.Show("Changing the indicator here is not allowed. Update the profile instead.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Return the check state to the original state (unchecked)
                chkProfessional.Checked = false;
            }
            else
            {
                // Display a message box to inform the user
                MessageBox.Show("Changing the indicator here is not allowed. Update the profile instead.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Return the check state to the original state (checked)
                chkProfessional.Checked = true;
            }
        }

        private void chkSMS_Click(object sender, EventArgs e)
        {
            if (chkSMS.Checked)
            {
                // Display a message box to inform the user
                MessageBox.Show("Changing the indicator here is not allowed. Update the profile instead.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Return the check state to the original state (unchecked)
                chkSMS.Checked = false;
            }
            else
            {
                // Display a message box to inform the user
                MessageBox.Show("Changing the indicator here is not allowed. Update the profile instead.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Return the check state to the original state (checked)
                chkSMS.Checked = true;
            }
        }

        private void chkEmail_Click(object sender, EventArgs e)
        {
            if (chkEmail.Checked)
            {
                // Display a message box to inform the user
                MessageBox.Show("Changing the indicator here is not allowed. Update the profile instead.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Return the check state to the original state (unchecked)
                chkEmail.Checked = false;
            }
            else
            {
                // Display a message box to inform the user
                MessageBox.Show("Changing the indicator here is not allowed. Update the profile instead.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Return the check state to the original state (checked)
                chkEmail.Checked = true;
            }
        }

        private void chkPhone_Click(object sender, EventArgs e)
        {
            if (chkPhone.Checked)
            {
                // Display a message box to inform the user
                MessageBox.Show("Changing the indicator here is not allowed. Update the profile instead.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Return the check state to the original state (unchecked)
                chkPhone.Checked = false;
            }
            else
            {
                // Display a message box to inform the user
                MessageBox.Show("Changing the indicator here is not allowed. Update the profile instead.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Return the check state to the original state (checked)
                chkPhone.Checked = true;
            }
        }
    }
}
