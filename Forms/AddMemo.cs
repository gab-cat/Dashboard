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

namespace Dashboard.Forms
{
    public partial class AddMemo : Form
    {

        public AddMemo(int customer_id, string employee_name)
        {
            InitializeComponent();
            this.Focus();
            txtCustomerID.Text = customer_id.ToString();
            txtEmployee.Text = employee_name;
            txtTimeStamp.Text = DateTime.Now.ToString();

        }

        public AddMemo(int customer_id, string employee_name, string reason, string user_text)
        {
            InitializeComponent();
            this.Focus();
            txtCustomerID.Text = customer_id.ToString();
            txtEmployee.Text = employee_name;
            txtTimeStamp.Text = DateTime.Now.ToString();
            txtreason.DropDownStyle = ComboBoxStyle.DropDown;
            txtreason.Text = reason;
            txtUserText.Text = user_text;

            txtreason.Enabled = false;
            txtUserText.Enabled = false;
            button2.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtreason.SelectedIndex = -1;
            txtUserText.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtreason.Text == string.Empty || txtUserText.Text == string.Empty)
            {
                MessageBox.Show("Please select a reason and provide memo text.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    // Define the SQL query to insert a memo
                    string query = @"
                INSERT INTO memos (customer_id, time_date, reason, employee_name, memo_text)
                VALUES (@customer_id, @time_date, @reason, @employee_name, @memo_text);
            ";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Set parameters for the query
                        command.Parameters.AddWithValue("@customer_id", int.Parse(txtCustomerID.Text));
                        command.Parameters.AddWithValue("@time_date", DateTime.Parse(txtTimeStamp.Text));
                        command.Parameters.AddWithValue("@reason", txtreason.Text);
                        command.Parameters.AddWithValue("@employee_name", txtEmployee.Text);
                        command.Parameters.AddWithValue("@memo_text", txtUserText.Text);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Memo inserted successfully. The form will now close.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Close the form
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to insert memo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
