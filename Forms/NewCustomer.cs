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
        public NewCustomer(string EmployeeName)
        {
            InitializeComponent();
            employee_name = EmployeeName;
        }

        private void addCustomer()
        {
            string address = $"{txt1.Text}, {txt2.Text}, {txt3.Text}, {txt4.Text} {txt5.Text}";
            string first_name = txtFirstname.Text;
            string last_name = txtLastname.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
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
                            string joinDate = DateTime.Now.ToString("yyyy-MM-dd"); // Format the join_date as desired

                            string confirmationMessage = $"New Customer Added.{Environment.NewLine}{Environment.NewLine}" +
                                                         $"Customer ID: {customerId}{Environment.NewLine}" +
                                                         $"First Name: {first_name}{Environment.NewLine}" +
                                                         $"Last Name: {last_name}{Environment.NewLine}" +
                                                         $"Address: {address}{Environment.NewLine}" +
                                                         $"Phone: {phone}{Environment.NewLine}" +
                                                         $"Email: {email}{Environment.NewLine}" +
                                                         $"Join Date: {joinDate}";

                            MessageBox.Show(confirmationMessage, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadingScreenManager.ShowLoadingScreen(() =>
                            {
                                AddMemo newCustomer = new AddMemo(customerId, employee_name, "New Customer", confirmationMessage);
                                newCustomer.ShowDialog();
                            });

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
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                // The code inside this block is executed while the loading animation is displayed
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
