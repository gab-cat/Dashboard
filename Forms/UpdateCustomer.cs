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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Dashboard
{
    public partial class UpdateCustomer : Form
    {
        private int CustomerId;
        private string EmployeeName;
        private bool changesMade = false;
        private bool originalProfessionalChecked;
        private bool originalSmsChecked;
        private bool originalEmailChecked;
        private bool originalPhoneChecked;
        private MySqlConnection connection;

        public UpdateCustomer(int customer_id, string employee_name, MySqlConnection connection)
        {
            InitializeComponent();
            this.Focus();
            CustomerId = customer_id;
            EmployeeName = employee_name;
            this.connection = connection;
            loadCustomerInfo(CustomerId);
            loadIndicators(CustomerId);

            // Wire up TextChanged event handlers for input fields
            txt1.TextChanged += InputField_TextChanged;
            txtFirstname.TextChanged += InputField_TextChanged;
            txtLastname.TextChanged += InputField_TextChanged;
            txtPhone.TextChanged += InputField_TextChanged;
            txtEmail.TextChanged += InputField_TextChanged;

            button1.Enabled = false;

        }

        private void InputField_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox.Text != textBox.Tag.ToString())
            {
                changesMade = true;
            }
            else
            {
                changesMade = false;
            }

            // Enable or disable the "Save" button based on whether changes were made
            button1.Enabled = changesMade;
        }

        private void loadCustomerInfo(int customer_id)
        {

            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                try
                {
                    // Query to retrieve customer information based on customer ID
                    string query = "SELECT address, first_name, last_name, contact_phone, contact_email " +
                                   "FROM customers WHERE customer_id = @customerId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customerId", customer_id);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) 
                            {
                                // Populate the text boxes with retrieved information
                                txt1.Text = reader["address"].ToString();
                                txt1.Tag = txt1.Text; 
                                txtFirstname.Text = reader["first_name"].ToString();
                                txtFirstname.Tag = txtFirstname.Text; 
                                txtLastname.Text = reader["last_name"].ToString();
                                txtLastname.Tag = txtLastname.Text; 
                                txtPhone.Text = reader["contact_phone"].ToString();
                                txtPhone.Tag = txtPhone.Text; 
                                txtEmail.Text = reader["contact_email"].ToString();
                                txtEmail.Tag = txtEmail.Text; 
                            }
                            else
                            {
                                MessageBox.Show("Customer with the provided ID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void loadIndicators(int customer_id)
        {
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                try
                {
                    // Query to retrieve indicator values based on customer ID
                    string query = "SELECT professional_firm, sms, email, phone " +
                                   "FROM indicators WHERE customer_id = @customerId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customerId", customer_id);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) 
                            {
                                originalProfessionalChecked = Convert.ToInt32(reader["professional_firm"]) == 1;
                                originalSmsChecked = Convert.ToInt32(reader["sms"]) == 1;
                                originalEmailChecked = Convert.ToInt32(reader["email"]) == 1;
                                originalPhoneChecked = Convert.ToInt32(reader["phone"]) == 1;

                                // Check checkboxes based on indicator values (1 or 0)
                                chkProfessional.Checked = originalProfessionalChecked;
                                chkSMS.Checked = originalSmsChecked;
                                chkEmail.Checked = originalEmailChecked;
                                chkPhone.Checked = originalPhoneChecked;
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
            }
        }


        private void updateCustomerInfo()
        {
            string address = txt1.Text;
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

                    // Check if the customer already exists based on customer ID
                    string checkExistingQuery = "SELECT COUNT(*) FROM customers WHERE customer_id = @customerId";
                    using (MySqlCommand checkExistingCommand = new MySqlCommand(checkExistingQuery, connection))
                    {
                        checkExistingCommand.Parameters.AddWithValue("@customerId", CustomerId);
                        int existingCustomerCount = Convert.ToInt32(checkExistingCommand.ExecuteScalar());

                        if (existingCustomerCount > 0) 
                        {
                            // Track changes in customer information
                            List<string> changedFields = new List<string>();
                            StringBuilder memoText = new StringBuilder();

                            string updateQuery = "UPDATE customers SET ";
                            if (address != txt1.Tag.ToString()) 
                            {
                                updateQuery += "address = @address, ";
                                changedFields.Add($"Changed Address from '{txt1.Tag.ToString()}' to '{address}'");
                            }
                            if (first_name != txtFirstname.Tag.ToString()) 
                            {
                                updateQuery += "first_name = @first_name, ";
                                changedFields.Add($"Changed First Name from '{txtFirstname.Tag.ToString()}' to '{first_name}'");
                            }
                            if (last_name != txtLastname.Tag.ToString())
                            {
                                updateQuery += "last_name = @last_name, ";
                                changedFields.Add($"Changed Last Name from '{txtLastname.Tag.ToString()}' to '{last_name}'");
                            }
                            if (phone != txtPhone.Tag.ToString()) 
                            {
                                updateQuery += "contact_phone = @phone, ";
                                changedFields.Add($"Changed Phone from '{txtPhone.Tag.ToString()}' to '{phone}'");
                            }
                            if (email != txtEmail.Tag.ToString())
                            {
                                updateQuery += "contact_email = @email, ";
                                changedFields.Add($"Changed Email from '{txtEmail.Tag.ToString()}' to '{email}'");
                            }

                            if (changedFields.Count > 0)
                            {
                                updateQuery = updateQuery.TrimEnd(',', ' ');
                                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery + " WHERE customer_id = @customerId", connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@customerId", CustomerId);
                                    updateCommand.Parameters.AddWithValue("@address", address);
                                    updateCommand.Parameters.AddWithValue("@first_name", first_name);
                                    updateCommand.Parameters.AddWithValue("@last_name", last_name);
                                    updateCommand.Parameters.AddWithValue("@phone", phone);
                                    updateCommand.Parameters.AddWithValue("@email", email);

                                    int rowsAffected = updateCommand.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        // Construct the memo text
                                        memoText.AppendLine("Data updated successfully.");
                                        memoText.AppendLine("Customer ID: " + CustomerId);
                                        memoText.AppendLine(string.Join("\n", changedFields));

                                        transaction.Commit();
                                        AddMemo updateProfile = new AddMemo(CustomerId, EmployeeName, "Updated Profile", memoText.ToString());
                                        updateProfile.ShowDialog();
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("No rows updated in the customers table.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("No changes detected in customer information.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Customer with the provided ID does not exist. Cannot update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void updateIndicators()
        {
            if (chkEmail.Checked || chkPhone.Checked || chkProfessional.Checked || chkSMS.Checked || chkEmail.Checked == false || chkPhone.Checked == false || chkProfessional.Checked == false || chkSMS.Checked == false)
            {
                // Track changes in indicator values
                List<string> changedIndicators = new List<string>();
                StringBuilder user_text = new StringBuilder();
                StringBuilder user_text1 = new StringBuilder();

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

                        string checkExistingQuery = "SELECT indicator_id, professional_firm, sms, email, phone FROM indicators WHERE customer_id = @customerId";
                        using (MySqlCommand checkExistingCommand = new MySqlCommand(checkExistingQuery, connection))
                        {
                            checkExistingCommand.Parameters.AddWithValue("@customerId", CustomerId);
                            MySqlDataReader reader = checkExistingCommand.ExecuteReader(); 

                            if (reader.Read()) // Customer already exists in indicators table
                            {
                                int existingIndicatorId = Convert.ToInt32(reader["indicator_id"]);
                                bool existingProfessional = Convert.ToInt32(reader["professional_firm"]) == 1;
                                bool existingSMS = Convert.ToInt32(reader["sms"]) == 1;
                                bool existingEmail = Convert.ToInt32(reader["email"]) == 1;
                                bool existingPhone = Convert.ToInt32(reader["phone"]) == 1;

                                // Check changes and update indicators
                                if (chkProfessional.Checked != existingProfessional)
                                {
                                    changedIndicators.Add(chkProfessional.Checked ? "Professional/Firm identifier, checked" : "Professional/Firm identifier, unchecked");
                                    user_text.AppendLine(chkProfessional.Checked ? "Professional/Firm identifier, checked." : "Professional/Firm identifier, unchecked.");
                                }
                                if (chkSMS.Checked != existingSMS)
                                {
                                    changedIndicators.Add(chkSMS.Checked ? "SMS Preference, checked" : "SMS Preference, unchecked");
                                    user_text.AppendLine(chkSMS.Checked ? "SMS Preference, checked." : "SMS Preference, unchecked.");
                                }
                                if (chkEmail.Checked != existingEmail)
                                {
                                    changedIndicators.Add(chkEmail.Checked ? "Email Preference, checked" : "Email Preference, unchecked");
                                    user_text.AppendLine(chkEmail.Checked ? "Email Preference, checked." : "Email Preference, unchecked.");
                                }
                                if (chkPhone.Checked != existingPhone)
                                {
                                    changedIndicators.Add(chkPhone.Checked ? "Phone Preference, checked" : "Phone Preference, unchecked");
                                    user_text.AppendLine(chkPhone.Checked ? "Phone Preference, checked." : "Phone Preference, unchecked.");
                                }

                                reader.Close(); 

                                // Update the existing row with new indicator values
                                string updateQuery = "UPDATE indicators SET professional_firm = @professional, sms = @sms, email = @email, phone = @phone " +
                                                     "WHERE indicator_id = @indicatorId";
                                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@professional", chkProfessional.Checked ? 1 : 0);
                                    updateCommand.Parameters.AddWithValue("@sms", chkSMS.Checked ? 1 : 0);
                                    updateCommand.Parameters.AddWithValue("@email", chkEmail.Checked ? 1 : 0);
                                    updateCommand.Parameters.AddWithValue("@phone", chkPhone.Checked ? 1 : 0);
                                    updateCommand.Parameters.AddWithValue("@indicatorId", existingIndicatorId);

                                    int rowsAffected = updateCommand.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        transaction.Commit();
                                        AddMemo updateIndicators = new AddMemo(CustomerId, EmployeeName, "Updated Indicators", user_text.ToString());
                                        updateIndicators.ShowDialog();
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("No rows updated in indicators table.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else // Customer doesn't exist in indicators table
                            {
                                reader.Close(); // Close the reader when no data is found
                                if (chkProfessional.Checked) user_text1.AppendLine("Professional / Firm identifier, checked. ");
                                if (chkSMS.Checked) user_text1.AppendLine("SMS Preference, checked, checked. ");
                                if (chkEmail.Checked) user_text1.AppendLine("Email Preference, checked. ");
                                if (chkPhone.Checked) user_text1.AppendLine("Phone Preferencer, checked. ");

                                // Insert a new row for the customer with indicator values
                                string insertQuery = "INSERT INTO indicators (customer_id, professional_firm, sms, email, phone) " +
                                                     "VALUES (@customerId, @professional, @sms, @email, @phone)";
                                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@customerId", CustomerId);
                                    insertCommand.Parameters.AddWithValue("@professional", chkProfessional.Checked ? 1 : 0);
                                    insertCommand.Parameters.AddWithValue("@sms", chkSMS.Checked ? 1 : 0);
                                    insertCommand.Parameters.AddWithValue("@email", chkEmail.Checked ? 1 : 0);
                                    insertCommand.Parameters.AddWithValue("@phone", chkPhone.Checked ? 1 : 0);

                                    int rowsInserted = insertCommand.ExecuteNonQuery();

                                    if (rowsInserted > 0)
                                    {
                                        transaction.Commit();
                                        AddMemo newIndicators = new AddMemo(CustomerId, EmployeeName, "Added Indicators", user_text1.ToString());
                                        newIndicators.ShowDialog();
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("No rows inserted in indicators table.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction?.Rollback();
                        MessageBox.Show("An error occurred while updating indicators: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                updateCustomerInfo();
                updateIndicators();
            });


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkProfessional_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProfessional.Checked != originalProfessionalChecked ||
                chkSMS.Checked != originalSmsChecked ||
                chkEmail.Checked != originalEmailChecked ||
                chkPhone.Checked != originalPhoneChecked)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void chkEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProfessional.Checked != originalProfessionalChecked ||
                chkSMS.Checked != originalSmsChecked ||
                chkEmail.Checked != originalEmailChecked ||
                chkPhone.Checked != originalPhoneChecked)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void chkSMS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProfessional.Checked != originalProfessionalChecked ||
                chkSMS.Checked != originalSmsChecked ||
                chkEmail.Checked != originalEmailChecked ||
                chkPhone.Checked != originalPhoneChecked)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void chkPhone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProfessional.Checked != originalProfessionalChecked ||
                chkSMS.Checked != originalSmsChecked ||
                chkEmail.Checked != originalEmailChecked ||
                chkPhone.Checked != originalPhoneChecked)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
    }
}
    
    
    

