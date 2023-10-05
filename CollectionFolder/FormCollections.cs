using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Web.UI.WebControls;
using System.Globalization;
using iTextSharp.text.pdf.draw;
using PdfiumViewer;
using System.Net.Mail;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Dashboard.Forms
{
    public partial class FormCollections : Form
    {
        private int customerId;
        private string employee_name;
        private string role;
        private bool pastdue;
        private decimal total_amount_due;
        private decimal change;


        public FormCollections(string employee_name, string role)
        {
            InitializeComponent();
            // DisplayCustomers();
            loadIndicators(customerId);
            txtSearchTerm.Focus();

            this.employee_name = employee_name;
            this.role = role;
            txtEmployee.Text = employee_name;
            txtPaymentDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            cboxFilter.SelectedIndex = 0;

            if (IsPastDue(customerId))
            {
                chkPastDue.Checked = true;
                decimal totalPastDueAmount = GetTotalPastDueAmount(customerId);
                lblTotalPastDue.Text = "₱ " + totalPastDueAmount.ToString("0.00"); // Convert decimal to string with formatting
            }
            else { chkPastDue.Checked = false; }

            ConfigureListView();


        }
        private void LoadTheme()
        {
            chkPastDue.CheckedOnColor = ThemeColor.SecondaryColor;

            CustomerGrid.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.SecondaryColor;
            CustomerGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            CustomerGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            CustomerGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;
            CustomerGrid.ThemeStyle.HeaderStyle.BackColor = ThemeColor.SecondaryColor;
            gunaGroupBox1.LineColor = ThemeColor.SecondaryColor;

            btnNotifySMS.BackColor = ThemeColor.SecondaryColor;
            btnNotifySMS.ForeColor = Color.White;
            btnNotifyEmail.BackColor = ThemeColor.SecondaryColor;
            btnNotifyEmail.ForeColor = Color.White;

            btnAddMemo.BackColor = ThemeColor.SecondaryColor;
            btnAddMemo.ForeColor = Color.White;
            btnCreatePA.BackColor = ThemeColor.SecondaryColor;
            btnCreatePA.ForeColor = Color.White;
            btnPaymentHistory.BackColor = ThemeColor.SecondaryColor;
            btnPaymentHistory.ForeColor = Color.White;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.BackColor = ThemeColor.SecondaryColor;
            btnValidate.BackColor = ThemeColor.SecondaryColor;
            btnValidate.ForeColor = Color.White;
            btnSubmitPayment.BackColor = ThemeColor.SecondaryColor;
            btnSubmitPayment.ForeColor = Color.White;
            btnNewPayment.BackColor = ThemeColor.SecondaryColor;
            btnNewPayment.ForeColor = Color.White;
            btnEmailPDF.BackColor = ThemeColor.SecondaryColor;
            btnEmailPDF.ForeColor = Color.White;

            PaymentArrGrid.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.SecondaryColor;
            PaymentArrGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            PaymentArrGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            PaymentArrGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;
            PaymentArrGrid.ThemeStyle.HeaderStyle.BackColor = ThemeColor.SecondaryColor;

        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void ConfigureDataGridViewColumns()
        {
            CustomerGrid.RowHeadersVisible = false;

            CustomerGrid.Columns["customer_id"].Width = 80;
            CustomerGrid.Columns["first_name"].Width = 100;
            CustomerGrid.Columns["last_name"].Width = 100;
            CustomerGrid.Columns["contact_email"].Width = 150;
            CustomerGrid.Columns["contact_phone"].Width = 150;
            CustomerGrid.Columns["address"].Width = 150;

            CustomerGrid.Columns["customer_id"].HeaderText = "ID";
            CustomerGrid.Columns["first_name"].HeaderText = "First Name";
            CustomerGrid.Columns["last_name"].HeaderText = "Last Name";
            CustomerGrid.Columns["contact_email"].HeaderText = "Email";
            CustomerGrid.Columns["contact_phone"].HeaderText = "Phone";
            CustomerGrid.Columns["address"].HeaderText = "Address";
        }

        private void searchCX()
        {
            try
            {
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {

                    string selectedFilter = cboxFilter.SelectedItem.ToString();
                    string searchKeyword = txtSearchTerm.Text.Trim();

                    if (string.IsNullOrWhiteSpace(searchKeyword))
                    {
                        MessageBox.Show("Please enter a search keyword.", "Empty Search Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string query = "";

                    switch (selectedFilter)
                    {
                        case "First Name":
                            query = "SELECT customer_id, first_name, last_name, contact_email, contact_phone, address FROM customers WHERE first_name LIKE @Keyword";
                            break;

                        case "Last Name":
                            query = "SELECT customer_id, first_name, last_name, contact_email, contact_phone, address FROM customers WHERE last_name LIKE @Keyword";
                            break;

                        case "Customer ID":
                            query = "SELECT customer_id, first_name, last_name, contact_email, contact_phone, address FROM customers WHERE customer_id LIKE @Keyword";
                            break;

                        case "Phone Number":
                            query = "SELECT customer_id, first_name, last_name, contact_email, contact_phone, address FROM customers WHERE contact_phone LIKE @Keyword";
                            break;

                        case "Email Address":
                            query = "SELECT customer_id, first_name, last_name, contact_email, contact_phone, address FROM customers WHERE contact_email LIKE @Keyword";
                            break;

                        case "Address":
                            query = "SELECT customer_id, first_name, last_name, contact_email, contact_phone, address FROM customers WHERE address LIKE @Keyword";
                            break;

                        default:
                            MessageBox.Show("Invalid filter criteria selected.");
                            return;
                    }

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Keyword", "%" + searchKeyword + "%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = dataTable;
                            CustomerGrid.DataSource = bindingSource;
                        }
                    }
                }

                ConfigureDataGridViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void txtSearchTerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                LoadingScreenManager.ShowLoadingScreen(() =>
                {
                    searchCX();
                    e.SuppressKeyPress = true;
                });

            }
        }

        private void CustomerGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (CustomerGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = CustomerGrid.SelectedRows[0];

                // Get the data from the selected row
                string firstName = selectedRow.Cells["first_name"].Value.ToString();
                string lastName = selectedRow.Cells["last_name"].Value.ToString();
                string contactEmail = selectedRow.Cells["contact_email"].Value.ToString();
                string contactPhone = selectedRow.Cells["contact_phone"].Value.ToString();
                string address = selectedRow.Cells["address"].Value.ToString();
                int selectedCustomerId = Convert.ToInt32(selectedRow.Cells["customer_id"].Value);

                // Display the data in the text boxes
                txtName.Text = firstName + " " + lastName;
                txtPhone.Text = contactPhone;
                txtEmail.Text = contactEmail;
                txtAddress.Text = address;

                // Set the customerId variable
                customerId = selectedCustomerId;
                comboBox1.SelectedIndex = 0;

                if (IsPastDue(customerId))
                {
                    chkPastDue.Checked = true;
                    lblTotalPastDue.ForeColor = Color.DarkRed;
                    btnNotifyEmail.Enabled = true;
                    btnNotifySMS.Enabled = true;
                }
                else 
                { 
                    chkPastDue.Checked = false;
                    lblTotalPastDue.ForeColor = Color.DarkGray;
                    btnNotifyEmail.Enabled = false;
                    btnNotifySMS.Enabled = false;
                }

                loadIndicators(customerId);
                lblTotalPastDue.Text = "₱ " + GetTotalPastDueAmount(customerId).ToString("0.00");
                CalculatePaymentSummary(customerId);
                LoadSaleIDsAndAmountDue(customerId);
                clearPaymentInfo();
                PopulateListViewForCustomer(customerId, comboBox1.SelectedItem.ToString());
            }
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
        private decimal GetTotalPastDueAmount(int customerId)
        {
            decimal totalPastDueAmount = 0;

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    // Query to get all past due sales for the given customer
                    string query = "SELECT total_amount " +
                                   "FROM sales " +
                                   "WHERE customer_id = @customer_id " +
                                   "AND payment_status = 'Pending' " +
                                   "AND DATE_ADD(sale_date, INTERVAL 7 DAY) <= NOW()";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customer_id", customerId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                decimal totalAmount = reader.GetDecimal("total_amount");

                                // Add the total amount of each past-due sale
                                totalPastDueAmount += totalAmount;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during database access
                    // You can log or display an error message here
                }
            }

            return totalPastDueAmount;
        }

        private void chkPastDue_Click(object sender, EventArgs e)
        {
            if (chkPastDue.Checked)
            {
                // Display a message box to inform the user
                MessageBox.Show("Changing the indicator here is not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Return the check state to the original state (unchecked)
                chkPastDue.Checked = false;
            }
            else
            {
                // Display a message box to inform the user
                MessageBox.Show("Changing the indicator here is not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Return the check state to the original state (checked)
                chkPastDue.Checked = true;
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                // The code inside this block is executed while the loading animation is displayed
                PaymentHistory payment = new PaymentHistory(customerId, employee_name);
                payment.Show(); // Show the AddMemo form as a dialog
            });
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                // The code inside this block is executed while the loading animation is displayed
                UpdateCustomer update = new UpdateCustomer(customerId, employee_name);
                update.Show(); // Show the AddMemo form as a dialog
            });
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            string phone = txtPhone.Text;
            string email = txtEmail.Text;

            Validation validation = new Validation( phone, email, employee_name, customerId);
            validation.ShowDialog();
        }

        private void btnAddMemo_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                // The code inside this block is executed while the loading animation is displayed
                AddMemo addmemo = new AddMemo(customerId, employee_name);
                addmemo.Show(); // Show the AddMemo form as a dialog
            });
        }

        List<int> saleIds = new List<int>();
        private void LoadSaleIDsAndAmountDue(int customerId)
        {
            saleIds.Clear();
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    // Query to retrieve sale IDs and total amount due for pending sales of the selected customer
                    string query = @"
                SELECT sale_id, total_amount
                FROM sales
                WHERE customer_id = @customerId
                AND payment_status = 'Pending'";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customerId", customerId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Create lists to store sale IDs and total amounts
                            // List<int> saleIds = new List<int>();
                            

                            while (reader.Read())
                            {
                                int saleId = reader.GetInt32("sale_id");
                                decimal totalAmount = reader.GetDecimal("total_amount");

                                saleIds.Add(saleId);
                                totalAmounts.Add(totalAmount);
                            }

                            // Populate the ComboBox with sale IDs
                            cboxSaleID.DataSource = saleIds;
                            // Populate the TextBox with the total amount due for the first sale (if any)
                            if (totalAmounts.Count > 0)
                            {
                                txtAmountDue.Text = "₱ " + totalAmounts[0].ToString("0.00");
                            }
                            else
                            {
                                txtAmountDue.Text = "₱ 0.00"; // No pending sales found
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

        List<decimal> totalAmounts = new List<decimal>();

        private void cboxSaleID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if there are items in the ComboBox
            if (cboxSaleID.Items.Count > 0)
            {
                // Get the selected sale ID from the ComboBox
                int selectedIndex = cboxSaleID.SelectedIndex;

                // Check if the selected index is valid
                if (selectedIndex >= 0 && selectedIndex < totalAmounts.Count)
                {
                    // Retrieve the corresponding total amount due from the list
                    decimal selectedAmount = totalAmounts[selectedIndex];
                    

                    // Update the txtAmountDue TextBox with the selected amount
                    txtAmountDue.Text = "₱ " + selectedAmount.ToString("0.00");
                }
                if (decimal.TryParse(txtCashCredit.Text.Replace("₱ ", ""), out decimal cashCreditAmount))
                {
                    decimal totalAmountDue = 0; // Initialize with zero if totalAmounts is not available
                    if (cboxSaleID.SelectedIndex >= 0 && cboxSaleID.SelectedIndex < totalAmounts.Count)
                    {
                        totalAmountDue = totalAmounts[cboxSaleID.SelectedIndex];
                    }
                    decimal changeAmount = cashCreditAmount - totalAmountDue;

                    total_amount_due = totalAmountDue;
                    change = changeAmount;
                }
            }
        }

        private void txtCashCredit_TextChanged(object sender, EventArgs e)
        {
            // Parse the text in txtCashCredit to a decimal value
            if (decimal.TryParse(txtCashCredit.Text.Replace("₱ ", ""), out decimal cashCreditAmount))
            {
                // Calculate the change by subtracting the total amount due
                decimal totalAmountDue = 0; // Initialize with zero if totalAmounts is not available
                if (cboxSaleID.SelectedIndex >= 0 && cboxSaleID.SelectedIndex < totalAmounts.Count)
                {
                    totalAmountDue = totalAmounts[cboxSaleID.SelectedIndex];
                }
                decimal changeAmount = cashCreditAmount - totalAmountDue;

                total_amount_due = totalAmountDue;
                change = changeAmount;

                // Update the txtChange TextBox with the calculated change amount
                txtChange.Text = "₱ " + changeAmount.ToString("0.00");
            }
            else
            {
                // Handle the case where the entered text is not a valid decimal value
                txtChange.Text = "₱ 0.00"; // Display 0.00 as the change
            }
        }

        private void btnSubmitPayment_Click(object sender, EventArgs e)
        {

            if (cboxPaymentMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the payment method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtCashCredit.Text == string.Empty)
            {
                MessageBox.Show("Please add the payment amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal paymentAmounts;
            decimal.TryParse(txtCashCredit.Text.Replace("₱ ", ""), out paymentAmounts);

            if (paymentAmounts < total_amount_due)
            {
                MessageBox.Show("Payment cannot be less than the amount due.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the selected sale ID from the cboxSaleID ComboBox
            if (cboxSaleID.SelectedIndex >= 0 && cboxSaleID.SelectedIndex < totalAmounts.Count)
            {
                int selectedSaleId = (int)cboxSaleID.SelectedItem;

                // Get the payment amount from txtCashCredit (assuming it's the entered payment amount)
                if (decimal.TryParse(txtAmountDue.Text.Replace("₱ ", ""), out decimal paymentAmount))
                {


                    // Get the selected payment method from cboxPaymentMethod
                    string paymentMethod = cboxPaymentMethod.SelectedItem.ToString();


                    LoadingScreenManager.ShowLoadingScreen(() =>
                    {
                        SendPaymentToDatabase(customerId, selectedSaleId, paymentAmount, paymentMethod);
                    });

                    LoadingScreenManager.ShowLoadingScreen(() =>
                    {
                        // The code inside this block is executed while the loading animation is displayed
                        AddMemo memo = new AddMemo(customerId, employee_name, "Make Payment", "Payment via " + paymentMethod + " of " + txtCashCredit.Text + " is successfully posted.");
                        memo.Show();
                    });

                    if (cboxPaymentMethod.SelectedIndex != 0)
                    {
                        AddMemo memo1 = new AddMemo(customerId, employee_name);
                        memo1.Show();
                    }

                    // You may want to update the UI or show a success message here
                    MessageBox.Show("Payment successfully processed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnSubmitPayment.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please enter a valid payment amount.", "Invalid Payment Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid sale ID.", "Invalid Sale ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SendPaymentToDatabase(int customerId, int saleId, decimal paymentAmount, string paymentMethod)
        {
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    // Start a transaction to ensure data consistency
                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        // Step 1: Update sale status to "Paid"
                        string updateQuery = "UPDATE sales SET payment_status = 'Completed' WHERE sale_id = @saleId";

                        using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection, transaction))
                        {
                            updateCommand.Parameters.AddWithValue("@saleId", saleId);
                            updateCommand.ExecuteNonQuery();
                        }

                        // Step 2: Insert a new payment row
                        string insertQuery = @"
                    INSERT INTO payments (customer_id, sales_id, payment_date, payment_amount, payment_method, payment_id)
                    VALUES (@customerId, @saleId, @paymentDate, @paymentAmount, @paymentMethod, @paymentId)";

                        using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection, transaction))
                        {
                            // Generate the payment ID (current date + 4 random digits)
                            string paymentId = DateTime.Now.ToString("yyyyMMdd") + new Random().Next(0000, 9999).ToString();
                            txtPaymentID.Text = paymentId;

                            // Set parameters for the insert query
                            insertCommand.Parameters.AddWithValue("@customerId", customerId);
                            insertCommand.Parameters.AddWithValue("@saleId", saleId);
                            insertCommand.Parameters.AddWithValue("@paymentDate", DateTime.Now);
                            insertCommand.Parameters.AddWithValue("@paymentAmount", paymentAmount);
                            insertCommand.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                            insertCommand.Parameters.AddWithValue("@paymentId", paymentId);

                            insertCommand.ExecuteNonQuery();
                        }

                        // Commit the transaction to save changes
                        transaction.Commit();

                        
                        GenerateReceiptPDF(customerId, txtPaymentID.Text, txtName.Text, saleId.ToString(), DateTime.Now, paymentAmount, paymentMethod, txtCashCredit.Text, txtChange.Text, employee_name);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during database access
                    // You can log or display an error message here
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboxPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxPaymentMethod.SelectedIndex >= 1) // Check if a payment method other than cash is selected
            {
                // Set txtCashCredit as read-only
                txtCashCredit.ReadOnly = true;

                // Get the selected sale ID from cboxSaleID (assuming it's the selected sale)
                if (cboxSaleID.SelectedIndex >= 0 && cboxSaleID.SelectedIndex < totalAmounts.Count)
                {
                    // Fill txtCashCredit with the total amount due for the selected sale
                    txtCashCredit.Text = "₱ " + totalAmounts[cboxSaleID.SelectedIndex].ToString("0.00");
                }
                else
                {
                    // Handle the case where there's no selected sale ID or totalAmounts is not available
                    txtCashCredit.Text = "₱ 0.00";
                }
            }
            else
            {
                // If cash is selected, allow user input and clear the text box
                txtCashCredit.ReadOnly = false;
                txtCashCredit.Clear();
            }
        }
        private void clearPaymentInfo()
        {
            txtPaymentID.Text = string.Empty;
            txtCashCredit.Enabled = true;
            txtCashCredit.Text = string.Empty;
            cboxSaleID.SelectedIndex = -1;
            cboxPaymentMethod.SelectedIndex = -1;
            txtAmountDue.Text = string.Empty;
            txtCashCredit.Text = string.Empty;
            txtChange.Text = string.Empty;
        }

        private void btnNewPayment_Click(object sender, EventArgs e)
        {
            clearPaymentInfo();
            btnSubmitPayment.Enabled = true;
        }

        private void GenerateReceiptPDF(int customerId, string paymentId, string customerName, string saleId, DateTime paymentDate, decimal dueAmount, string paymentMethod, string cashCreditAmount, string change, string employeeName)
        {
            decimal vatRate = 0.12m; // 12% VAT rate
            decimal vatableAmount = dueAmount / (1 + vatRate);
            decimal vatAmount = dueAmount - vatableAmount;

            // Define your custom margins (left, right, top, bottom)
            float leftMargin = 10f;     // Adjust the value as needed
            float rightMargin = 10f;    // Adjust the value as needed
            float topMargin = 5f;      // Adjust the value as needed
            float bottomMargin = 10f;   // Adjust the value as needed

            // Create a new document with custom margins
            Document doc = new Document(new iTextSharp.text.Rectangle(PageSize.A4.Width / 2, PageSize.A4.Height / 4));
            doc.SetMargins(leftMargin, rightMargin, topMargin, bottomMargin);

            try
            {
                // Set the directory where receipts will be stored
                string receiptDirectory = "Receipts";
                Directory.CreateDirectory(receiptDirectory); // Create the directory if it doesn't exist

                // Set the file path for the PDF using the naming convention (customer_id)_(payment_id).pdf
                string filePath = Path.Combine(receiptDirectory, $"{customerId}_{paymentId}.pdf");

                // Create a FileStream to write the PDF file
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                    var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);

                    // Open the document for writing
                    doc.Open();

                    // Receipt Header
                    Paragraph header = new Paragraph("New Bernales Hardware Store", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12));
                    header.Alignment = Element.ALIGN_CENTER;
                    doc.Add(header);
                    

                    // Create a table for customer information
                    PdfPTable customerInfoTable = new PdfPTable(2);
                    customerInfoTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerInfoTable.WidthPercentage = 100;
                    customerInfoTable.SetWidths(new float[] { 4f, 6f });

                    customerInfoTable.AddCell(new Phrase("Payment ID:", boldFont));
                    customerInfoTable.AddCell(new Phrase(paymentId, boldFont));

                    customerInfoTable.AddCell(new Phrase("Customer Name:", boldFont));
                    customerInfoTable.AddCell(new Phrase(customerName, normalFont));

                    customerInfoTable.AddCell(new Phrase("Sale ID:", boldFont));
                    customerInfoTable.AddCell(new Phrase(saleId, normalFont));

                    customerInfoTable.AddCell(new Phrase("Payment Date:", boldFont));
                    customerInfoTable.AddCell(new Phrase(paymentDate.ToString("yyyy-MM-dd"), normalFont));

                    customerInfoTable.AddCell(new Phrase("Due Amount:", boldFont));
                    customerInfoTable.AddCell(new Phrase($"{dueAmount.ToString("0.00")}", boldFont));

                    customerInfoTable.AddCell(new Phrase("Vatable Amount:", boldFont));
                    customerInfoTable.AddCell(new Phrase($"{vatableAmount.ToString("0.00")}", normalFont));

                    customerInfoTable.AddCell(new Phrase("VAT Amount:", boldFont));
                    customerInfoTable.AddCell(new Phrase($"{vatAmount.ToString("0.00")}", normalFont));

                    doc.Add(customerInfoTable);

                    // Payment Details
                    PdfPTable paymentDetailsTable = new PdfPTable(2);
                    paymentDetailsTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    paymentDetailsTable.SpacingBefore = 5f; // Add spacing before the table
                    paymentDetailsTable.WidthPercentage = 100;
                    paymentDetailsTable.SetWidths(new float[] { 4f, 6f });

                    if (paymentMethod == "Cash")
                    {
                        paymentDetailsTable.AddCell(new Phrase("Pay Method:", boldFont));
                        paymentDetailsTable.AddCell(new Phrase(paymentMethod, normalFont));

                        paymentDetailsTable.AddCell(new Phrase("Cash Amount:", boldFont));
                        paymentDetailsTable.AddCell(new Phrase($"{cashCreditAmount}", boldFont));

                        paymentDetailsTable.AddCell(new Phrase("Change:", boldFont));
                        paymentDetailsTable.AddCell(new Phrase($"{change}", boldFont));
                    }
                    else
                    {
                        paymentDetailsTable.AddCell(new Phrase("Payment Method:", boldFont));
                        paymentDetailsTable.AddCell(new Phrase(paymentMethod, normalFont));

                        paymentDetailsTable.AddCell(new Phrase("Credit Amount:", boldFont));
                        paymentDetailsTable.AddCell(new Phrase($"{cashCreditAmount}", normalFont));
                    }

                    doc.Add(paymentDetailsTable);

                    // Employee Name
                    // Create a table for employee information
                    PdfPTable employeeTable = new PdfPTable(2);
                    employeeTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    employeeTable.WidthPercentage = 100;

                    // Add "Processed by" in the first cell
                    employeeTable.AddCell(new Phrase("Processed by: ", boldFont));

                    // Create a cell for the employee name with a bottom border
                    PdfPCell employeeNameCell = new PdfPCell(new Phrase(employeeName, normalFont));
                    employeeNameCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    employeeNameCell.Colspan = 2; // Span both columns
                    employeeTable.AddCell(employeeNameCell);

                    doc.Add(employeeTable);

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



        private void txtCashCredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the input is not a digit and not a period
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Handled the event, no processing for this character
            }
            // Check if it's a period, and if it is, check if there's already one in the TextBox
            else if (e.KeyChar == '.' && txtCashCredit.Text.Contains("."))
            {
                e.Handled = true; // If there's already a period, handle the event so another one isn't written
            }
        }

        private void ConfigureListView()
        {
            // Set the view of the ListView to Details
            listInvoice.View = System.Windows.Forms.View.Details;

            // Define columns for the ListView
            listInvoice.Columns.Add("File Name", 200); // Column 1: File Name
            listInvoice.Columns.Add("Date Created", 150); // Column 2: Date Created

        }

        private void PopulateListViewForCustomer(int customerId, string selectedType)
        {
            // Clear existing items in the ListView
            listInvoice.Items.Clear();

            // Determine the directory path based on the selected type
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string directoryPath = (selectedType == "Invoices") ? Path.Combine(baseDirectory, "Invoices") : Path.Combine(baseDirectory, "Receipts");

            // Check if the directory exists
            if (Directory.Exists(directoryPath))
            {
                // Get a list of PDF files in the directory
                string[] pdfFiles = Directory.GetFiles(directoryPath, "*.pdf");

                // Filter PDF files for the specified customer ID
                var customerPdfFiles = pdfFiles
                    .Where(pdfFile => Path.GetFileName(pdfFile).StartsWith($"{customerId}_"));

                // Iterate through each PDF file for the customer and add it to the ListView
                foreach (string pdfFile in customerPdfFiles)
                {
                    // Get the file name without the directory path
                    string fileName = Path.GetFileName(pdfFile);

                    // Get the creation date of the file
                    DateTime fileCreationDate = File.GetCreationTime(pdfFile);

                    // Create a ListViewItem with the file name and creation date
                    ListViewItem item = new ListViewItem(new string[] { fileName, fileCreationDate.ToString("yyyy-MM-dd HH:mm:ss") });

                    // Add the ListViewItem to the ListView
                    listInvoice.Items.Add(item);
                }
            }
            else
            {
                // Handle the case where the directory doesn't exist
                MessageBox.Show($"The {selectedType} directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Get the selected type from the ComboBox
            string selectedType = comboBox1.SelectedItem.ToString();

            // Populate the ListView based on the selected customer ID and type
            PopulateListViewForCustomer(customerId, selectedType);
        }


        private void listInvoice_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listInvoice.SelectedItems.Count > 0)
            {
                // Get the selected item's text, which is the file name
                string fileName = listInvoice.SelectedItems[0].Text;

                // Determine the directory path based on the selected type (Invoices or Receipts)
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string selectedType = (comboBox1.SelectedIndex == 0) ? "Invoices" : "Receipts";
                string directoryPath = Path.Combine(baseDirectory, selectedType);

                // Construct the full file path
                string filePath = Path.Combine(directoryPath, fileName);

                // Check if the file exists before opening it
                if (File.Exists(filePath))
                {
                    // Open the file using the default associated program
                    System.Diagnostics.Process.Start(filePath);
                }
                else
                {
                    MessageBox.Show($"The selected file '{fileName}' does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEmailPDF_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                if (listInvoice.SelectedItems.Count > 0)
                {
                    // Get the selected item's text, which is the file name
                    string fileName = listInvoice.SelectedItems[0].Text;

                    string fromEmail = "gabriel.catimbang30@gmail.com";
                    string fromPassword = "dzfh ejih ihxr vpdd";

                    // Determine the directory path based on the selected type (Invoices or Receipts)
                    string selectedType = (comboBox1.SelectedIndex == 0) ? "Invoices" : "Receipts";
                    string directoryPath = Path.Combine(Application.StartupPath, selectedType);

                    // Construct the full file path
                    string filePath = Path.Combine(directoryPath, fileName);

                    // Check if the file exists before proceeding
                    if (File.Exists(filePath))
                    {
                        // Get the recipient's email address (replace with your logic to fetch the email)
                        string recipientEmail = txtEmail.Text; // Replace with your logic to fetch the recipient's email

                        // Email subject and body
                        string subject = "Invoice Attached";
                        string plainTextBody = "Please find the attached invoice.";

                        try
                        {
                            // Create a new MailMessage
                            MailMessage message = new MailMessage
                            {
                                From = new MailAddress(fromEmail, "Contact Center"),
                                Subject = subject,
                                Body = plainTextBody,
                                IsBodyHtml = false, // Set to false for plain text body
                            };

                            // Add recipient's email address
                            message.To.Add(recipientEmail);

                            // Attach the invoice PDF file
                            Attachment attachment = new Attachment(filePath);
                            message.Attachments.Add(attachment);

                            // Create and configure the SMTP client
                            SmtpClient client = new SmtpClient("smtp.gmail.com")
                            {
                                Port = 587,
                                Credentials = new NetworkCredential(fromEmail, fromPassword),
                                EnableSsl = true,
                            };

                            // Send the email
                            client.Send(message);

                            if (comboBox1.SelectedIndex == 0)
                            {
                                AddMemo newmemo = new AddMemo(customerId, employee_name, "Email Invoice Copy", "Sent PDF copy of invoice via email" + Environment.NewLine + fileName);
                                newmemo.ShowDialog();
                            }
                            if (comboBox1.SelectedIndex == 1)
                            {
                                AddMemo newmemo = new AddMemo(customerId, employee_name, "Email Receipt Copy", "Sent PDF copy of receipt via email" + Environment.NewLine + fileName);
                                newmemo.ShowDialog();
                            }


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while sending the email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"The selected file '{fileName}' does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an invoice to email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void btnNotifyEmail_Click(object sender, EventArgs e)
        {
            // Check if a customer is selected in your CustomerGrid
            if (CustomerGrid.SelectedRows.Count > 0)
            {
                // Get the selected customer's ID (assuming your DataGridView is bound to a data source)
                int selectedCustomerId = customerId;
                string pastDue = lblTotalPastDue.Text;

                string fromEmail = "gabriel.catimbang30@gmail.com";
                string fromPassword = "dzfh ejih ihxr vpdd";

                // Retrieve the customer's email address based on the selectedCustomerId (replace with your logic)
                string recipientEmail = txtEmail.Text;

                if (!string.IsNullOrEmpty(recipientEmail))
                {
                    // Compose the email subject and body with the past due amount information
                    string subject = "Past Due Amount Notification";
                    string body = $"Dear Customer,\n\nThis is a reminder that you have a past due amount of {pastDue}. Please make the payment at your earliest convenience.\n\nSincerely,\nCollections Department - New Bernales Hardware Store";

                    try
                    {
                        // Create a new MailMessage
                        MailMessage message = new MailMessage
                        {
                            From = new MailAddress(fromEmail, "Contact Center"),
                            Subject = subject,
                            Body = body,
                            IsBodyHtml = false, // Set to false for plain text body
                        };

                        // Add recipient's email address
                        message.To.Add(recipientEmail);

                        // Create and configure the SMTP client
                        SmtpClient client = new SmtpClient("smtp.gmail.com")
                        {
                            Port = 587,
                            Credentials = new NetworkCredential(fromEmail, fromPassword),
                            EnableSsl = true,
                        };

                        // Send the email
                        client.Send(message);

                        LoadingScreenManager.ShowLoadingScreen(() =>
                        {
                            // The code inside this block is executed while the loading animation is displayed
                            AddMemo newmemo = new AddMemo(customerId, employee_name, "Past Due Payment Notification", "Notified CX of past due amount via email." + Environment.NewLine + body);
                            newmemo.ShowDialog();
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while sending the email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Customer's email address not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to notify.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
