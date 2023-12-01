using Dashboard.Forms;
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

namespace Dashboard
{
    public partial class NewCustomer : Form
    {
        private string employee_name;
        MySqlConnection connection;
        public NewCustomer(string EmployeeName, MySqlConnection connection)
        {
            InitializeComponent();
            employee_name = EmployeeName;
            this.connection = connection;
        }

        private void addCustomer()
        {
            string address = $"{txt1.Text}, {txt2.Text}, {txt3.Text}, {txt4.Text} {txt5.Text}";
            string first_name = txtFirstname.Text;
            string last_name = txtLastname.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;

            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                MySqlTransaction transaction = null;

                try
                {
                    transaction = connection.BeginTransaction();

                    string query = "INSERT INTO customers (address, first_name, last_name, contact_phone, contact_email, join_date) " +
                                   "VALUES (@address, @first_name, @last_name, @phone, @email, NOW()); SELECT LAST_INSERT_ID();";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@address", address);
                        command.Parameters.AddWithValue("@first_name", first_name);
                        command.Parameters.AddWithValue("@last_name", last_name);
                        command.Parameters.AddWithValue("@phone", phone);
                        command.Parameters.AddWithValue("@email", email);

                        int customerId = Convert.ToInt32(command.ExecuteScalar());

                        if (customerId > 0)
                        {
                            string joinDate = DateTime.Now.ToString("yyyy-MM-dd"); 

                            string confirmationMessage = $"New Customer Added.{Environment.NewLine}{Environment.NewLine}" +
                                                         $"Customer ID: {customerId}{Environment.NewLine}" +
                                                         $"First Name: {first_name}{Environment.NewLine}" +
                                                         $"Last Name: {last_name}{Environment.NewLine}" +
                                                         $"Address: {address}{Environment.NewLine}" +
                                                         $"Phone: {phone}{Environment.NewLine}" +
                                                         $"Email: {email}{Environment.NewLine}" +
                                                         $"Join Date: {joinDate}";

                            MessageBox.Show(confirmationMessage, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            transaction.Commit();
                            AddMemo newCustomer = new AddMemo(customerId, employee_name, "New Customer", confirmationMessage);
                            newCustomer.ShowDialog();

                            
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No rows inserted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFirstname.Text.Trim()) || String.IsNullOrEmpty(txtLastname.Text.Trim()) ||
                String.IsNullOrEmpty(txtPhone.Text.Trim()) || String.IsNullOrEmpty(txtEmail.Text.Trim()) )
            {
                MessageBox.Show("Customer information fields cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(txt1.Text.Trim()) || String.IsNullOrEmpty(txt2.Text.Trim()) || String.IsNullOrEmpty(txt3.Text.Trim())
                || String.IsNullOrEmpty(txt4.Text.Trim()) || String.IsNullOrEmpty(txt5.Text.Trim()))
            {
                MessageBox.Show("Customer Address information fields cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                addCustomer();
            });

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaGroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
