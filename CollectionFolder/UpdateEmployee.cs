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
    public partial class UpdateEmployee : Form
    {
        private bool changesMade = false;
        private List<string> changeMemos = new List<string>();
        private string employee_name, username,first_name, last_name, designation, email, supervisor, role;
        public UpdateEmployee(string EmployeeName, string role, string username, string first_name, string last_name, string designation, string email, string supervisor )
        {
            InitializeComponent();
            employee_name = EmployeeName;
            this.username = username;
            this.first_name = first_name;
            this.last_name = last_name;
            this.designation = designation;
            this.email = email;
            this.supervisor = supervisor;
            this.role = role;

            setInfo();

            // Wire up TextChanged event handlers for input fields
            txtUsername.TextChanged += InputField_TextChanged;
            txtFirstname.TextChanged += InputField_TextChanged;
            txtLastname.TextChanged += InputField_TextChanged;
            txtDesignation.TextChanged += InputField_TextChanged;
            txtEmail.TextChanged += InputField_TextChanged;
            txtSupervisor.TextChanged += InputField_TextChanged;
            button1.Enabled = false; // Disable the "Save" button initially
        }

        private void InputField_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string fieldName = GetFieldName(textBox);
            string initialValue = textBox.Tag != null ? textBox.Tag.ToString() : "";

            // Check if the current text value is different from the initial value
            if (textBox.Text != initialValue)
            {
                // Create a memo for the change
                string changeMemo = $"Changed {fieldName} from '{initialValue}' to '{textBox.Text}'";

                // Remove any previous change memo for this field (if any)
                RemoveChangeMemo(fieldName);

                // Add the new change memo
                AddChangeMemo(changeMemo);

                // Enable or disable the "Save" button based on whether changes were made
                button1.Enabled = AreThereAnyChanges();
            }
            else
            {
                // No changes for this field
                RemoveChangeMemo(fieldName);

                // Enable or disable the "Save" button based on whether changes were made
                button1.Enabled = AreThereAnyChanges();
            }
        }


        private string GetFieldName(TextBox textBox)
        {
            // You need to customize this function based on how you've named your TextBox controls.
            // For example, if your TextBoxes are named txtUsername, txtFirstName, etc.,
            // you can extract the field name like this:
            return textBox.Name.Substring(3); // Assuming your TextBoxes are named with "txt" prefix.
        }

        private void AddChangeMemo(string changeMemo)
        {
            changeMemos.Add(changeMemo); // Assuming changeMemos is a List<string> declared earlier.
        }

        private void RemoveChangeMemo(string fieldName)
        {
            changeMemos.RemoveAll(memo => memo.Contains(fieldName)); // Remove change memos containing the field name.
        }

        private bool AreThereAnyChanges()
        {
            return changeMemos.Any(); // Returns true if there are any change memos.
        }


        private void setInfo()
        {
            txtUsername.Text = username;
            txtUsername.Tag = username; // Set the Tag property

            txtFirstname.Text = first_name;
            txtFirstname.Tag = first_name; // Set the Tag property

            txtLastname.Text = last_name;
            txtLastname.Tag = last_name; // Set the Tag property

            txtDesignation.Text = designation;
            txtDesignation.Tag = designation; // Set the Tag property

            txtEmail.Text = email;
            txtEmail.Tag = email; // Set the Tag property

            txtSupervisor.Text = supervisor;
            txtSupervisor.Tag = supervisor; // Set the Tag property

            if (role == "Admin")
            {
                txtDesignation.ReadOnly = false;
                txtUsername.ReadOnly = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                UpdateEmployeeInfo(txtUsername.Text, txtFirstname.Text, txtLastname.Text, txtDesignation.Text, txtEmail.Text, txtSupervisor.Text);
        }

        private void UpdateEmployeeInfo(string username, string firstName, string lastName, string designation, string email, string supervisor)
        {
            // Construct your SQL query to update the employee's information
            string query = "UPDATE logins " +
                           "SET username = @newusername, first_name = @firstName, last_name = @lastName, role = @designation, " +
                           "employee_email = @email, direct_supervisor = @supervisor " +
                           "WHERE username = @username";

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Use parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@username", this.username);
                    command.Parameters.AddWithValue("@newusername", username);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@designation", designation);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@supervisor", supervisor);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            string changeSummaryMemo = string.Join("\n", changeMemos);

                            LoadingScreenManager.ShowLoadingScreen(() =>
                            {
                                MaintenanceMemo memo = new MaintenanceMemo(employee_name, "Update Employee Information", changeSummaryMemo);
                                memo.ShowDialog();
                            });

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated. Employee not found or no changes were made.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while updating the employee information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
