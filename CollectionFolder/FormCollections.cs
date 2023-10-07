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
using System.Diagnostics;

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
        List<int> saleIds = new List<int>();


        public FormCollections(string employee_name, string role)
        {
            InitializeComponent();
            // loadIndicators(customerId);
            txtSearchTerm.Focus();

            this.employee_name = employee_name;
            this.role = role;

            txtEmployee.Text = employee_name;
            txtPaymentDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            cboxFilter.SelectedIndex = 0;

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
            button1.ForeColor = Color.White;
            button1.BackColor = ThemeColor.SecondaryColor;
            button2.ForeColor = Color.White;
            button2.BackColor = ThemeColor.SecondaryColor;

            btnAddMemo.BackColor = ThemeColor.SecondaryColor;
            btnAddMemo.ForeColor = Color.White;
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

                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }


                return false; 
            }
        }
        private decimal GetTotalPastDueAmount(int customerId)
        {
            decimal totalPastDueAmount = 0;

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
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

                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }

            return totalPastDueAmount;
        }

        private void chkPastDue_Click(object sender, EventArgs e)
        {
            if (chkPastDue.Checked)
            {
                MessageBox.Show("Changing the indicator here is not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                chkPastDue.Checked = false;
            }
            else
            {
                MessageBox.Show("Changing the indicator here is not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                                MessageBox.Show("No data found for the customer.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

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
                PaymentHistory payment = new PaymentHistory(customerId, employee_name);
                payment.Show(); 
            });
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            { 
                UpdateCustomer update = new UpdateCustomer(customerId, employee_name);
                update.Show(); 
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
                AddMemo addmemo = new AddMemo(customerId, employee_name);
                addmemo.Show(); 
            });
        }

       
        private void LoadSaleIDsAndAmountDue(int customerId)
        {
            saleIds.Clear();
            totalAmounts.Clear();
            cboxSaleID.DataSource = null;
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
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
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

                txtChange.Text = "₱ " + changeAmount.ToString("0.00");
            }
            else
            {
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
                        AddMemo memo = new AddMemo(customerId, employee_name, "Make Payment", "Payment via " + paymentMethod + " of " + txtCashCredit.Text + " is successfully posted.");
                        memo.Show();
                    });

                    if (cboxPaymentMethod.SelectedIndex != 0)
                    {
                        AddMemo memo1 = new AddMemo(customerId, employee_name);
                        memo1.Show();
                    }

                    SendPaymentConfirmationEmail(customerId, txtEmail.Text, paymentAmount, paymentMethod);
                    SendPaymentConfirmation();

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
                        transaction.Commit();
                        GenerateReceiptPDF(customerId, txtPaymentID.Text, txtName.Text, saleId.ToString(), DateTime.Now, paymentAmount, paymentMethod, txtCashCredit.Text, txtChange.Text, employee_name);
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

        private void cboxPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxPaymentMethod.SelectedIndex >= 1) 
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
                    txtCashCredit.Text = "₱ 0.00";
                }
            }
            else
            {
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

            float leftMargin = 10f;     
            float rightMargin = 10f;    
            float topMargin = 5f;      
            float bottomMargin = 10f;   

            // Create a new document with custom margins
            Document doc = new Document(new iTextSharp.text.Rectangle(PageSize.A4.Width / 2, PageSize.A4.Height / 4));
            doc.SetMargins(leftMargin, rightMargin, topMargin, bottomMargin);

            try
            {
                // Set the directory where receipts will be stored
                string receiptDirectory = "Receipts";
                Directory.CreateDirectory(receiptDirectory); 
                string filePath = Path.Combine(receiptDirectory, $"{customerId}_{paymentId}.pdf");

                // Create a FileStream to write the PDF file
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                    var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                    var redFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.RED);

                    doc.Open();

                    // Receipt Header
                    Paragraph header = new Paragraph("NEW BERNALES HARDWARE STORE", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12));
                    header.Alignment = Element.ALIGN_CENTER;
                    doc.Add(header);
                    

                    // Create a table for customer information
                    PdfPTable customerInfoTable = new PdfPTable(2);
                    customerInfoTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    customerInfoTable.WidthPercentage = 100;
                    customerInfoTable.SpacingBefore = 10f;
                    customerInfoTable.SetWidths(new float[] { 4f, 6f });

                    // Create a PdfPCell with a top border
                    PdfPCell topBorderCell = new PdfPCell(new Phrase("Payment ID           :", redFont));
                    topBorderCell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    customerInfoTable.AddCell(topBorderCell);
                    PdfPCell paymentIdCell = new PdfPCell(new Phrase(paymentId, redFont));
                    paymentIdCell.Border = iTextSharp.text.Rectangle.TOP_BORDER;
                    customerInfoTable.AddCell(paymentIdCell);

                    customerInfoTable.AddCell(new Phrase("Customer Name   :", boldFont));
                    customerInfoTable.AddCell(new Phrase(customerName, normalFont));

                    customerInfoTable.AddCell(new Phrase("Sale ID                   :", boldFont));
                    customerInfoTable.AddCell(new Phrase(saleId, normalFont));

                    customerInfoTable.AddCell(new Phrase("Payment Date       :", boldFont));
                    customerInfoTable.AddCell(new Phrase(paymentDate.ToString("yyyy-MM-dd"), normalFont));

                    customerInfoTable.AddCell(new Phrase("Due Amount         :", redFont));
                    customerInfoTable.AddCell(new Phrase($"{dueAmount.ToString("0.00")}", redFont));

                    customerInfoTable.AddCell(new Phrase("Vatable Amount   :", boldFont));
                    customerInfoTable.AddCell(new Phrase($"{vatableAmount.ToString("0.00")}", normalFont));

                    customerInfoTable.AddCell(new Phrase("VAT Amount         :", boldFont));
                    customerInfoTable.AddCell(new Phrase($"{vatAmount.ToString("0.00")}", normalFont));

                    doc.Add(customerInfoTable);

                    // Payment Details
                    PdfPTable paymentDetailsTable = new PdfPTable(2);
                    paymentDetailsTable.DefaultCell.Border = iTextSharp.text.Rectangle.BOX;
                    paymentDetailsTable.SpacingBefore = 5f;
                    paymentDetailsTable.SpacingAfter = 5f;
                    paymentDetailsTable.WidthPercentage = 100;
                    paymentDetailsTable.SetWidths(new float[] { 4f, 6f });

                    if (paymentMethod == "Cash")
                    {
                        paymentDetailsTable.AddCell(new Phrase("Pay Method", boldFont));
                        paymentDetailsTable.AddCell(new Phrase(paymentMethod, normalFont));

                        paymentDetailsTable.AddCell(new Phrase("Cash Amount", boldFont));
                        paymentDetailsTable.AddCell(new Phrase($"{cashCreditAmount}", boldFont));

                        paymentDetailsTable.AddCell(new Phrase("Change", boldFont));
                        paymentDetailsTable.AddCell(new Phrase(change, boldFont));
                    }
                    else
                    {
                        paymentDetailsTable.AddCell(new Phrase("Payment Method", boldFont));
                        paymentDetailsTable.AddCell(new Phrase(paymentMethod, normalFont));

                        paymentDetailsTable.AddCell(new Phrase("Credit Amount", boldFont));
                        paymentDetailsTable.AddCell(new Phrase($"{cashCreditAmount}", normalFont));
                    }

                    doc.Add(paymentDetailsTable);

                    // Create a table for employee information
                    PdfPTable employeeTable = new PdfPTable(2);
                    employeeTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    employeeTable.HorizontalAlignment = Element.ALIGN_RIGHT;
                    employeeTable.WidthPercentage = 100;
                    paymentDetailsTable.SetWidths(new float[] { 4f, 6f });

                    PdfPCell employeeCell = new PdfPCell(new Phrase("Processed by:", boldFont));
                    employeeCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    employeeCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                    employeeTable.AddCell(employeeCell);

                    PdfPCell employeeNameCell = new PdfPCell(new Phrase(employeeName, normalFont));
                    employeeNameCell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
                    employeeNameCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    employeeNameCell.Colspan = 2;
                    employeeTable.AddCell(employeeNameCell);

                    doc.Add(employeeTable);

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
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; 
            }
            else if (e.KeyChar == '.' && txtCashCredit.Text.Contains("."))
            {
                e.Handled = true; 
            }
        }

        private void ConfigureListView()
        {
            // Set the view of the ListView to Details
            listInvoice.View = System.Windows.Forms.View.Details;
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


            if (Directory.Exists(directoryPath))
            {
                string[] pdfFiles = Directory.GetFiles(directoryPath, "*.pdf");
                var customerPdfFiles = pdfFiles
                    .Where(pdfFile => Path.GetFileName(pdfFile).StartsWith($"{customerId}_"));

                // Iterate through each PDF file for the customer and add it to the ListView
                foreach (string pdfFile in customerPdfFiles)
                {
                    string fileName = Path.GetFileName(pdfFile);
                    DateTime fileCreationDate = File.GetCreationTime(pdfFile);
                    ListViewItem item = new ListViewItem(new string[] { fileName, fileCreationDate.ToString("yyyy-MM-dd HH:mm:ss") });
                    listInvoice.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show($"The {selectedType} directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected type from the ComboBox
            string selectedType = comboBox1.SelectedItem.ToString();
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

                if (File.Exists(filePath))
                {
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
                    if (File.Exists(filePath))
                    {
                        string recipientEmail = txtEmail.Text; 
                        string subject = "Invoice Attached";
                        string plainTextBody = "Please find the attached invoice.";

                        try
                        {
                            MailMessage message = new MailMessage
                            {
                                From = new MailAddress(fromEmail, "Contact Center"),
                                Subject = subject,
                                Body = plainTextBody,
                                IsBodyHtml = false, 
                            };

                            message.To.Add(recipientEmail);

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
            if (CustomerGrid.SelectedRows.Count > 0)
            {
                int selectedCustomerId = customerId;
                string pastDue = lblTotalPastDue.Text;

                string fromEmail = "gabriel.catimbang30@gmail.com";
                string fromPassword = "dzfh ejih ihxr vpdd";

                string recipientEmail = txtEmail.Text;

                if (!string.IsNullOrEmpty(recipientEmail))
                {
                    string subject = "Past Due Amount Notification";
                    string body = $"Dear Mr./Ms. {txtName.Text} ,\n\nGood day! This is a reminder that you have a past due amount of {pastDue}. Please make the payment at your earliest convenience.\n\nSincerely,\nCollections Department - New Bernales Hardware Store";

                    try
                    {
                        MailMessage message = new MailMessage
                        {
                            From = new MailAddress(fromEmail, "Contact Center"),
                            Subject = subject,
                            Body = body,
                            IsBodyHtml = false, // Set to false for plain text body
                        };

                        message.To.Add(recipientEmail);

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

        private void SendPaymentConfirmationEmail(int customerId, string recipientEmail, decimal paymentAmount, string paymentMethod)
        {
            string fromEmail = "gabriel.catimbang30@gmail.com";
            string fromPassword = "dzfh ejih ihxr vpdd";

            string subject = "Payment Confirmation";
            string body = $"Dear Mr./Ms. {txtName.Text},\n\nGood day! This email is to confirm the receipt of your payment of ₱ {paymentAmount.ToString("0.00")} via {paymentMethod}.\n\nThank you for your prompt payment.\n\nSincerely,\nCollections Department - New Bernales Hardware Store";

            try
            {
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(fromEmail, "Contact Center"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false, 
                };

                message.To.Add(recipientEmail);

                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromEmail, fromPassword),
                    EnableSsl = true,
                };

                
                client.Send(message);


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while sending the email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendTextMessage(string phoneNumber, string message)
        {
            try
            {
                // Specify the full path to the ADB executable
                string adbPath = Path.Combine(Application.StartupPath, "platform-tools", "adb.exe");

                // Construct the ADB command
                string adbCommand = $"shell service call isms 7 i32 0 s16 \"com.android.mms.service\" s16 \"{phoneNumber}\" s16 \"null\" s16 \"'{message}'\" s16 \"null\" s16 \"null\"";

                // Execute the ADB command
                Process process = new Process();
                process.StartInfo.FileName = adbPath;
                process.StartInfo.Arguments = adbCommand;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                process.WaitForExit();

                // Check the exit code to determine if the message was sent successfully
                int exitCode = process.ExitCode;
                if (exitCode == 0)
                {
                    MessageBox.Show("SMS sent successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to send SMS. Please check your ADB setup and permissions.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendPastDueNotification()
        {
            string phoneNumber = txtPhone.Text;
            string body = $"Mr./Ms. {txtName.Text}. This is a reminder that you have a past due amount of {lblTotalPastDue.Text}. Please make the payment at your earliest convenience.";

            SendTextMessage(phoneNumber, body);
        }

        private void SendPaymentConfirmation()
        {
            string phoneNumber = txtPhone.Text;
            string body = $"Mr./Ms. {txtName.Text}, your payment of {txtAmountDue.Text} via {cboxPaymentMethod.Text} is posted. Thank you for your prompt payment.";

            SendTextMessage(phoneNumber, body);
        }

        private void btnNotifySMS_Click(object sender, EventArgs e)
        {
            SendPastDueNotification();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                searchCX();
            });
        }

        private void FormCollections_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void GetPaymentInfo(string paymentId)
        {
            // Define your SQL query to fetch payment information and customer name
            string query = @"
        SELECT p.customer_id, p.sales_id, p.payment_date, p.payment_amount, p.payment_method, 
               CONCAT(c.first_name, ' ', c.last_name) AS customer_name
        FROM payments p
        LEFT JOIN customers c ON p.customer_id = c.customer_id
        WHERE p.payment_id = @paymentId";

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@paymentId", paymentId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve payment information
                                int customerId = reader.GetInt32("customer_id");
                                int saleId = reader.GetInt32("sales_id");
                                DateTime paymentDate = reader.GetDateTime("payment_date");
                                decimal paymentAmount = reader.GetDecimal("payment_amount");
                                string paymentMethod = reader.GetString("payment_method");
                                string customerName = reader.GetString("customer_name");

                                // Display information in TextBox controls
                                txtCustomerID.Text = customerId.ToString();
                                txtSaleID.Text = saleId.ToString();
                                txtSearchPaymentDate.Text = paymentDate.ToString("yyyy-MM-dd");
                                txtSearchAmountPaid.Text = $"₱ {paymentAmount.ToString("0.00")}";
                                txtMethodStatus.Text = paymentMethod;
                                txtCustomerName.Text = customerName;
                            }
                            else
                            {
                                txtCustomerID.Text = null;
                                txtSaleID.Text = null;
                                txtSearchPaymentDate.Text = null;
                                txtSearchAmountPaid.Text = null;
                                txtMethodStatus.Text = null;
                                txtCustomerName.Text = null;
                                txtPaymentSearch.Text = "Payment ID not found";
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

        private void button2_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                GetPaymentInfo(txtPaymentSearch.Text);
            });
        }

        private void txtPaymentSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                LoadingScreenManager.ShowLoadingScreen(() =>
                {
                    GetPaymentInfo(txtPaymentSearch.Text.Trim());
                    e.SuppressKeyPress = true;
                });

            }
        }
    }
}
