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
    public partial class MaintenanceMemo : Form
    {
        private int hiddenMemo;
        private string memoText;
        private MySqlConnection connection = DatabaseHelper.GetMemoConnection();

        public MaintenanceMemo(string employee_name)
        {
            InitializeComponent();
            this.Focus();
            txtCustomerID.Text = 9998.ToString();
            txtCustomerID.Visible = false;
            txtEmployee.Text = employee_name;
            txtTimeStamp.Text = DateTime.Now.ToString();
            txtSystemText.Text = string.Empty;
        }

        public MaintenanceMemo(string employee_name, string reason, string systemText)
        {
            InitializeComponent();
            this.Focus();
            txtCustomerID.Text = 9998.ToString();
            txtCustomerID.Visible = false;
            txtEmployee.Text = employee_name;
            txtTimeStamp.Text = DateTime.Now.ToString();
            txtSystemText.Text = systemText;
            txtreason.DropDownStyle = ComboBoxStyle.DropDown;
            txtreason.Text = reason;
            txtreason.Enabled = false;
        }
        public MaintenanceMemo(string text, string reason, string systemText, int a)
        {
            hiddenMemo = 1;
            InitializeComponent();
            this.Focus();
            txtCustomerID.Text = 9998.ToString();
            txtCustomerID.Visible = false;
            txtEmployee.Text = "SYSTEM";
            txtTimeStamp.Text = DateTime.Now.ToString();
            txtSystemText.Text = text;
            txtreason.DropDownStyle = ComboBoxStyle.DropDown;
            txtreason.Text = reason;
            txtUserText.Text = systemText;
            sendMemo();
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

            sendMemo();

        }

        private void sendMemo()
        {
            if (txtSystemText.Text == string.Empty)
            {
                memoText = txtUserText.Text;
            }
            else
            {
                memoText = txtSystemText.Text + Environment.NewLine + Environment.NewLine + txtUserText.Text;
            }

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
                        command.Parameters.AddWithValue("@memo_text", memoText);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();
                        if (hiddenMemo != 1)
                        {
                            if (rowsAffected > 0)
                            {
                                transaction.Commit();
                                MessageBox.Show("Memo inserted successfully. The form will now close.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (connection != null)
                                {
                                    connection.Dispose();
                                    connection.Close();
                                }
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Failed to insert memo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            this.Close();
                        }


                    }

                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    if (hiddenMemo != 1)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        private void MaintenanceMemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connection != null)
            {
                connection.Dispose();
                connection.Close();
            }
        }
    }
}
