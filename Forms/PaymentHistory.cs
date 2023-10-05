using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Dashboard.Forms
{
    public partial class PaymentHistory : Form
    {
        private int customer_id;
        private string employee_name;
        public PaymentHistory(int CustomerId, string EmployeeName)
        {   
            InitializeComponent();
            customer_id = CustomerId;
            employee_name = EmployeeName;
            LoadPaymentDataForCustomer(customer_id);
            this.Focus();
        }

        private void loadPaymentData(int customerId)
        {

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    string query = "SELECT payment_id AS 'Transaction ID', payment_date AS 'Date', payment_amount AS 'Amount', payment_method AS 'Method' " +
                                   "FROM payments " +
                                   "WHERE customer_id = @customer_id " + 
                                   "ORDER BY payment_date DESC";


                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customer_id", customerId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Create a DataTable to hold the payment data
                            DataTable paymentTable = new DataTable();
                            paymentTable.Load(reader);

                            // Create a BindingSource and bind it to the DataTable
                            BindingSource paymentBindingSource = new BindingSource();
                            paymentBindingSource.DataSource = paymentTable;

                            // Bind the DataGridView to the BindingSource
                            paymentData.DataSource = paymentBindingSource;
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

        public void RefundPayment(string paymentId)
        {
            string amount = paymentData.SelectedRows[0].Cells["Amount"].Value.ToString();
            string payment_date = paymentData.SelectedRows[0].Cells["Date"].Value.ToString();
            string method = paymentData.SelectedRows[0].Cells["Method"].Value.ToString();

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                MySqlTransaction transaction = null;
                try
                {
                    // Begin a transaction to ensure data consistency
                    transaction = connection.BeginTransaction();

                    // Update the payments table to set payment_method to 'Refunded'
                    string updatePaymentsQuery = "UPDATE payments SET payment_method = 'Refunded' WHERE payment_id = @payment_id";
                    using (MySqlCommand updatePaymentsCommand = new MySqlCommand(updatePaymentsQuery, connection, transaction))
                    {
                        updatePaymentsCommand.Parameters.AddWithValue("@payment_id", paymentId);
                        int rowsAffectedPayments = updatePaymentsCommand.ExecuteNonQuery();

                        if (rowsAffectedPayments > 0)
                        {
                            // Step 1: Retrieve the sales_id associated with the payment_id
                            string retrieveSalesIdQuery = "SELECT sales_id FROM payments WHERE payment_id = @payment_id";
                            using (MySqlCommand retrieveSalesIdCommand = new MySqlCommand(retrieveSalesIdQuery, connection, transaction))
                            {
                                retrieveSalesIdCommand.Parameters.AddWithValue("@payment_id", paymentId);
                                object salesIdResult = retrieveSalesIdCommand.ExecuteScalar();

                                if (salesIdResult != null)
                                {
                                    int salesId = Convert.ToInt32(salesIdResult);

                                    // Step 2: Update the sales table to set payment_status to 'Pending'
                                    string updateSalesQuery = "UPDATE sales SET payment_status = 'Pending' WHERE sale_id = @sales_id";
                                    using (MySqlCommand updateSalesCommand = new MySqlCommand(updateSalesQuery, connection, transaction))
                                    {
                                        updateSalesCommand.Parameters.AddWithValue("@sales_id", salesId);
                                        int rowsAffectedSales = updateSalesCommand.ExecuteNonQuery();

                                        if (rowsAffectedSales > 0)
                                        {
                                            // Payment refund succeeded, proceed with adding memos and refreshing data
                                            string text = "=== System Generated Text ====" + Environment.NewLine;
                                            string text1 = "Successfully refunded Transaction ID: " + paymentId + Environment.NewLine;
                                            string text2 = "Original Payment Amount : ₱" + amount + Environment.NewLine;
                                            string text3 = "Original Payment Date : " + payment_date + Environment.NewLine;
                                            string text4 = "Refund Method : " + method + Environment.NewLine;
                                            string text5 = "=== User Memo is required ===";
                                            string info = text + text1 + text2 + text3 + text4 + text5;
                                            LoadingScreenManager.ShowLoadingScreen(() =>
                                            {
                                                AddMemo memo = new AddMemo(customer_id, employee_name, "Payment Refund", info);
                                                memo.ShowDialog(); 
                                            });

                                            LoadingScreenManager.ShowLoadingScreen(() =>
                                            {
                                                AddMemo memo = new AddMemo(customer_id, employee_name);
                                                memo.ShowDialog();
                                            });

                                            LoadPaymentDataForCustomer(customer_id); 
                                        }
                                        else
                                        {
                                            MessageBox.Show("Payment refund failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Payment not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Payment refund failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback the transaction to ensure data consistency
                    transaction?.Rollback();

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


        private void LoadPaymentDataForCustomer(int customerId)
        {
            // Clear any existing data in the DataGridView
            paymentData.DataSource = null;
            loadPaymentData(customerId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (paymentData.SelectedRows.Count > 0)
            {
                string transactionId = paymentData.SelectedRows[0].Cells["Transaction ID"].Value.ToString();
                string method = paymentData.SelectedRows[0].Cells["Method"].Value.ToString();

                // Check if the payment has already been refunded
                if (method.ToLower() == "refunded")
                {
                    MessageBox.Show("This payment has already been refunded and cannot be refunded again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return; 
                }

                // Ask for confirmation before refunding
                DialogResult result = MessageBox.Show("Are you sure you want to refund this payment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    RefundPayment(transactionId);
                }
            }
            else
            {
                MessageBox.Show("Please select a transaction to refund.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
