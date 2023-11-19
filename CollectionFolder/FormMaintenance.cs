using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dashboard.CollectionFolder;
using System.Collections;
using System.Transactions;

namespace Dashboard.Forms
{
    public partial class FormMaintenance : Form
    {
        private string employee_name;
        private string role;
        private string username;
        MySqlConnection connection;
        private ServerConnections serverConnectionsForm;
        private MtnMemoView memoViewForm;
        public FormMaintenance(string employee_name, string role, MySqlConnection connection, string username)
        {
            InitializeComponent();
            this.employee_name = employee_name;
            this.username = username;
            Console.WriteLine(username + " " + role);
            this.role = role;
            this.connection = connection;
            LoadEmployeeData();
        }

        private void FormMaintenance_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void LoadTheme()
        {
            EmployeeGrid.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.SecondaryColor;
            EmployeeGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            EmployeeGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            EmployeeGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;
            EmployeeGrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            EmployeeGrid.DefaultCellStyle.SelectionBackColor = SystemColors.Info;

            foreach (Control btns in groupBox1.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.SecondaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }

            foreach (Control btns in groupBox2.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.SecondaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }

            btnDelete.BackColor = Color.White;
            btnDelete.ForeColor = ThemeColor.SecondaryColor;
            btnDelete.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            btnDeleteSupplier.BackColor = Color.White;
            btnDeleteSupplier.ForeColor = ThemeColor.SecondaryColor;
            btnDeleteSupplier.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            chkNewProfile.CheckedOnColor = ThemeColor.SecondaryColor;

        }

        private void LoadEmployeeData()
        {
            // Define your SQL query to retrieve employee data
            string query = null;

            if (role == "Admin")
            {
                query = @"SELECT
                            l.username AS Username,
                            l.first_name AS 'First Name',
                            l.last_name AS 'Last Name',
                            CASE
                                WHEN l.employee_status = 1 THEN 'ACTIVE'
                                ELSE 'INACTIVE'
                            END AS Status,
                            l.role AS Role,
                            l.employee_email AS 'Employee Email',
                            CONCAT(d.first_name, ' ', d.last_name) AS 'Direct Supervisor'
                        FROM
                            logins AS l
                        LEFT JOIN
                            logins AS d ON l.direct_supervisor = d.username
                        ORDER BY
                            l.username";
            }
            else
            {
                query = @"SELECT
                    l.username AS Username,
                    l.first_name AS 'First Name',
                    l.last_name AS 'Last Name',
                    CASE
                        WHEN l.employee_status = 1 THEN 'ACTIVE'
                        ELSE 'INACTIVE'
                    END AS Status,
                    l.role AS Role,
                    l.employee_email AS 'Employee Email',
                    CONCAT(d.first_name, ' ', d.last_name) AS 'Direct Supervisor'
                FROM
                    logins AS l
                LEFT JOIN
                    logins AS d ON l.direct_supervisor = d.username
                WHERE
                    l.direct_supervisor = @username
                ORDER BY
                    l.username";

            }

            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                try
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        if (role != "Admin")
                        {
                            command.Parameters.AddWithValue("@username", username);
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable employeeData = new DataTable();
                            adapter.Fill(employeeData);

                            // Bind the DataGridView to the DataTable
                            EmployeeGrid.DataSource = employeeData;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void checkActiveSession(string username)
        {
            string selectQuery = "SELECT active_session, active_since FROM logins WHERE username = @username";

            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                try
                {
                    using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int activeSession = reader.GetInt32("active_session");
                                TimeSpan activeSince = reader.GetTimeSpan("active_since");

                                if (activeSession == 1)
                                {
                                    lblLogIn.Visible = true;
                                    lblTime.Visible = true;
                                    lblTime.Text = "Timestamp: " + activeSince.ToString(); // Modify as needed
                                    btnForceLogout.Visible = true;
                                    btnForceLogout.Enabled = true;
                                }
                                else
                                {
                                    lblLogIn.Visible = false;
                                    lblTime.Visible = false;

                                    btnForceLogout.Visible = false;
                                    btnForceLogout.Enabled = false;
                                }
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

        private void EmployeeGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (!chkNewProfile.Checked)
            {
                if (EmployeeGrid.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = EmployeeGrid.SelectedRows[0];

                    txtUsername.Text = selectedRow.Cells["Username"].Value.ToString();
                    txtFirstName.Text = selectedRow.Cells["First Name"].Value.ToString();
                    txtLastName.Text = selectedRow.Cells["Last Name"].Value.ToString();
                    txtRole.Text = selectedRow.Cells["Role"].Value.ToString();
                    txtEmailAddress.Text = selectedRow.Cells["Employee Email"].Value.ToString();
                    txtSupervisor.Text = selectedRow.Cells["Direct Supervisor"].Value.ToString();
                    txtStatus.Text = selectedRow.Cells["Status"].Value.ToString();

                    if (txtStatus.Text == "ACTIVE")
                    {
                        txtStatus.ForeColor = Color.DarkGreen;
                        ActivateProfile.Text = "Deactivate Profile";
                    }
                    else
                    {
                        txtStatus.ForeColor = Color.DarkRed;
                        ActivateProfile.Text = "Activate Profile";
                        btnResetPassword.Enabled = false;
                    }

                    if (txtUsername.Text == "admin")
                    {
                        btnDelete.Enabled = false;
                        ActivateProfile.Enabled = false;
                        btnResetPassword.Enabled = false;
                    }
                    else
                    {
                        btnDelete.Enabled = true;
                        ActivateProfile.Enabled = true;
                        btnResetPassword.Enabled = true;
                    }

                    checkActiveSession(txtUsername.Text);
                }
            }

        }

        private void chkNewProfile_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNewProfile.Checked)
            {
                // When "New Profile" is checked, enable textboxes and clear their content
                EnableTextboxes();
                ClearTextboxes();
                btnUpdate.Text = "New Profile";
                btnDelete.Enabled = false;
                btnServerConnections.Enabled = false;
                btnResetPassword.Enabled = false;
                btnOpenLogs.Enabled = false;
                ActivateProfile.Enabled = false;
            }
            else
            {
                // When "New Profile" is unchecked, disable textboxes and set the button text back to "Update"
                EnableTextboxes();
                btnUpdate.Text = "Update";
                DisableTextBoxes();
                btnDelete.Enabled = true;
                btnServerConnections.Enabled = true;
                btnResetPassword.Enabled = true;
                btnOpenLogs.Enabled = true;
                ActivateProfile.Enabled = true;

                if (EmployeeGrid.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = EmployeeGrid.SelectedRows[0];

                    txtUsername.Text = selectedRow.Cells["Username"].Value.ToString();
                    txtFirstName.Text = selectedRow.Cells["First Name"].Value.ToString();
                    txtLastName.Text = selectedRow.Cells["Last Name"].Value.ToString();
                    txtRole.Text = selectedRow.Cells["Role"].Value.ToString();
                    txtEmailAddress.Text = selectedRow.Cells["Employee Email"].Value.ToString();
                    txtSupervisor.Text = selectedRow.Cells["Direct Supervisor"].Value.ToString();
                    txtStatus.Text = selectedRow.Cells["Status"].Value.ToString();

                    if (txtStatus.Text == "ACTIVE")
                    {
                        txtStatus.ForeColor = Color.DarkGreen;
                        ActivateProfile.Text = "Deactivate Profile";
                    }
                    else
                    {
                        txtStatus.ForeColor = Color.DarkRed;
                        ActivateProfile.Text = "Activate Profile";
                        btnResetPassword.Enabled = false;
                    }

                    if (txtUsername.Text == "admin")
                    {
                        btnDelete.Enabled = false;
                        ActivateProfile.Enabled = false;
                        btnResetPassword.Enabled = false;
                    }
                    else
                    {
                        btnDelete.Enabled = true;
                        ActivateProfile.Enabled = true;
                        btnResetPassword.Enabled = true;
                    }

                }
            }
        }
        private void EnableTextboxes()
        {
            txtRole.DropDownStyle = ComboBoxStyle.DropDownList;
            txtUsername.ReadOnly = false;
            txtFirstName.ReadOnly = false;
            txtLastName.ReadOnly = false;
            txtRole.Enabled = true;
            txtEmailAddress.ReadOnly = false;
            txtSupervisor.ReadOnly = false;
            txtStatus.ReadOnly = false;

            txtUsername.BackColor = Color.Linen;
            txtFirstName.BackColor = Color.Linen;
            txtLastName.BackColor = Color.Linen;
            txtRole.BackColor = Color.Linen;
            txtEmailAddress.BackColor = Color.Linen;
            txtSupervisor.BackColor = Color.Linen;
            txtStatus.BackColor = Color.Linen;
        }

        private void DisableTextBoxes()
        {
            txtRole.DropDownStyle = ComboBoxStyle.DropDown;
            txtUsername.ReadOnly = true;
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtRole.Enabled = false;
            txtEmailAddress.ReadOnly = true;
            txtSupervisor.ReadOnly = true;
            txtStatus.ReadOnly = true;

            txtUsername.BackColor = SystemColors.Menu;
            txtFirstName.BackColor = SystemColors.Menu;
            txtLastName.BackColor = SystemColors.Menu;
            txtRole.BackColor = SystemColors.Menu;
            txtEmailAddress.BackColor = SystemColors.Menu;
            txtSupervisor.BackColor = SystemColors.Menu;
            txtStatus.BackColor = SystemColors.Menu;
        }

        private void ClearTextboxes()
        {
            txtUsername.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtRole.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
            txtSupervisor.Text = string.Empty;
            txtStatus.Text = string.Empty;
        }

        private string GenerateRandomPassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$";
            var random = new Random();
            var password = new string(Enumerable.Repeat(validChars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return password;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (chkNewProfile.Checked)
            {
                if (txtUsername.Text == string.Empty ||
                    txtFirstName.Text == string.Empty ||
                    txtLastName.Text == string.Empty ||
                    txtEmailAddress.Text == string.Empty ||
                    txtSupervisor.Text == string.Empty ||
                    txtRole.SelectedIndex == 0 )
                {
                    MessageBox.Show("A field cannot be empty. Please make sure to fill out all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                LoadingScreenManager.ShowLoadingScreen(() =>
                {
                    createNewProfile();
                    chkNewProfile.Checked = false;
                });
            }
            else
            {
                UpdateEmployee update = new UpdateEmployee(employee_name, role, txtUsername.Text, txtFirstName.Text, txtLastName.Text, txtRole.Text, txtEmailAddress.Text, txtSupervisor.Text, connection);
                update.ShowDialog();
            }
        }

        private void createNewProfile()
        {
            string username = txtUsername.Text;
            string password = GenerateRandomPassword(8); // Randomly generated password
            string salt = PasswordHashing.GenerateSalt(); // Generate a new salt for the password
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string role = txtRole.Text;
            string emailAddress = txtEmailAddress.Text;
            string supervisor = txtSupervisor.Text;
            int status = 1; 

            string hashedPassword = PasswordHashing.HashString(password, salt);

            // Construct your SQL query and execute it
            string query = "INSERT INTO logins (username, password, salt, first_name, last_name, role, employee_email, direct_supervisor, employee_status) " +
                           $"VALUES (@username, @password, @salt, @firstName, @lastName, @role, @emailAddress, @supervisor, @status)";

            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                MySqlTransaction transaction = null;

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", hashedPassword);
                    command.Parameters.AddWithValue("@salt", salt);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@role", role);
                    command.Parameters.AddWithValue("@emailAddress", emailAddress);
                    command.Parameters.AddWithValue("@supervisor", supervisor);
                    command.Parameters.AddWithValue("@status", status);

                    try
                    {
                        transaction = connection.BeginTransaction();

                        command.ExecuteNonQuery();

                        // Send an email with the new user details
                        string emailSubject = "New User Profile Created";
                        string emailBody = $"Username: <strong>{username}</strong><br>Password: <strong>{password}</strong><br>First Name: <strong>{firstName}</strong><br>Last Name: <strong>{lastName}</strong><br>Role: <strong>{role}</strong><br>Email Address: <strong>{emailAddress}</strong><br>Supervisor: <strong>{supervisor}</strong>";
                        string outro = "<br><br><i>Please use the temporary password to log in at OrderMAX. Once logged in, you will be able to set up your own password.</i><br><i>This is a system-generated message. Do not reply.</i>";

                        
                        string systemText = $"Requested by : {employee_name}{Environment.NewLine}{Environment.NewLine}Username: {username}{Environment.NewLine}Password: XXXXXXXX{Environment.NewLine}First Name: {firstName}{Environment.NewLine}Last Name: {lastName}{Environment.NewLine}Role: {role}{Environment.NewLine}Email Address: {emailAddress}{Environment.NewLine}Supervisor: {supervisor}";



                        SendsEmail(emailAddress, emailSubject, emailBody + outro);

                        MaintenanceMemo nm = new MaintenanceMemo("System Profiles Manager" ,"New User Profile", systemText, 1);
                        nm.Hide();

                        transaction.Commit();
                        LoadEmployeeData();
                    }
                    catch (Exception ex)
                    {
                        transaction?.Rollback();
                        MessageBox.Show("An error occurred while creating a new profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void SendsEmail(string recipientEmail, string subject, string body)
        {
            try
            {
                string fromEmail = "gabriel.catimbang30@gmail.com";
                string fromPassword = "dzfh ejih ihxr vpdd";

                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromEmail, fromPassword),
                    EnableSsl = true,
                };

                MailMessage message = new MailMessage
                {
                    From = new MailAddress(fromEmail, "OrderMAX Help Desk"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                message.To.Add(recipientEmail);

                client.Send(message);

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while sending the email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtStatus.Text != "INACTIVE")
            {
                MessageBox.Show("Please disable first the account before deleting it. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EmployeeGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = EmployeeGrid.SelectedRows[0];
                string usernameToDelete = selectedRow.Cells["Username"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    LoadingScreenManager.ShowLoadingScreen(() =>
                    {
                        DeleteEmployee(usernameToDelete);
                    });
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to delete.", "No Employee Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DeleteEmployee(string username)
        {
            string deleteQuery = "DELETE FROM logins WHERE username = @Username";

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

                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            transaction.Commit();
                            LoadEmployeeData();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ActivateProfile_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                if (EmployeeGrid.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = EmployeeGrid.SelectedRows[0];
                    string username = txtUsername.Text;
                    string emailAddress = txtEmailAddress.Text;
                    int currentStatus;

                    if (string.Equals(selectedRow.Cells["Status"].Value.ToString(), "ACTIVE", StringComparison.OrdinalIgnoreCase))
                    {
                        currentStatus = 1;
                    }
                    else
                    {
                        currentStatus = 0;
                    }


                    int newStatus = currentStatus == 0 ? 1 : 0;
                    UpdateEmployeeStatus(username, newStatus);
                    if (newStatus == 1)
                    {
                        ResetPassword(username, emailAddress);
                    }
                    string statusText;
                    if (newStatus == 0)
                    {
                        statusText = "INACTIVE/DISABLED";
                    }
                    else
                    {
                        statusText = "ACTIVE";
                    }
                    MessageBox.Show($"Employee profile is now {statusText}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select an employee to activate/deactivate.", "No Employee Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            });

        }

        private void UpdateEmployeeStatus(string username, int newStatus)
        {
            string updateQuery = "UPDATE logins SET employee_status = @Status WHERE username = @Username";

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
                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Status", newStatus);
                        command.Parameters.AddWithValue("@Username", username);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            string statusText = newStatus == 1 ? "Active" : "Inactive";


                            transaction.Commit();
                            // Refresh the DataGridView to reflect the changes
                            LoadEmployeeData();
                        }
                        else
                        {
                            transaction?.Rollback();
                            MessageBox.Show("Failed to update employee profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void ResetPassword(string username, string emailAddress)
        {
            // Generate a new random password and salt
            string newPassword = GenerateRandomPassword(8);
            string salt = PasswordHashing.GenerateSalt();

            // Hash the new password with the generated salt
            string hashedPassword = PasswordHashing.HashString(newPassword, salt);

            string updateQuery = "UPDATE logins SET password = @password, salt = @salt, temporary_password = 1, login_attempts = 0 WHERE username = @username";

            using (this.connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                MySqlTransaction transaction = null;

                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@password", hashedPassword);
                    command.Parameters.AddWithValue("@salt", salt);
                    command.Parameters.AddWithValue("@username", username);

                    try
                    {
                        transaction = connection.BeginTransaction();

                        command.ExecuteNonQuery();

                        transaction.Commit();

                        string emailSubject = "Temporary Password Reset";
                        string emailBody = $"Your temporary password has been reset to: <strong>{newPassword}</strong>";
                        string outro = "<br><br><i>Please use the temporary password to log in at OrderMAX. Once logged in, you will be able to set up your own password.</i><br><i>This is a system-generated message. Do not reply.</i>";

                        SendsEmail(emailAddress, emailSubject, emailBody + outro);
                    }
                    catch (Exception ex)
                    {
                        transaction?.Rollback();
                        MessageBox.Show("An error occurred while resetting the password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {

            if (txtStatus.Text == "INACTIVE")
            {
                MessageBox.Show("Please activate the profile instead. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmationResult = MessageBox.Show($"Are you sure you want to reset the password for {txtFirstName.Text + " " + txtLastName.Text }?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmationResult == DialogResult.Yes)
            {
                LoadingScreenManager.ShowLoadingScreen(() =>
                {
                    ResetPassword(txtUsername.Text, txtEmailAddress.Text);
                });
            }
        }

        private void btnOpenLogs_Click(object sender, EventArgs e)
        {
            if (memoViewForm != null && !memoViewForm.IsDisposed)
            {
                memoViewForm.Focus();
                memoViewForm.BringToFront();
            }
            else
            {
                memoViewForm = new MtnMemoView(employee_name);
                memoViewForm.Show();
            }
        }

        private void btnServerConnections_Click(object sender, EventArgs e)
        {
            if (serverConnectionsForm != null && !serverConnectionsForm.IsDisposed)
            {
                serverConnectionsForm.Focus();
                serverConnectionsForm.BringToFront();
            }
            else
            {
                serverConnectionsForm = new ServerConnections(employee_name, connection);
                serverConnectionsForm.Show();
            }
        }

        private void btnForceLogout_Click(object sender, EventArgs e)
        {

            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                using (MySqlConnection connection = this.connection)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    string updateQuery = "UPDATE logins SET active_session = 0 WHERE username = @username";
                    MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);

                    cmd.ExecuteNonQuery();
                }
                lblLogIn.Visible = false;
                lblTime.Visible = false;

                btnForceLogout.Visible = false;
                btnForceLogout.Enabled = false;
            });

        }
    }
}
