using Dashboard.Forms;
using iTextSharp.text.xml;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Dashboard
{
    public partial class Login : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
                                                         (
                                                              int nLeftRect,
                                                              int nTopRect,
                                                              int nRightRect,
                                                              int nBottomRect,
                                                              int nWidthEllipse,
                                                              int nHeightEllipse
                                                          );

        Color color = Color.FromArgb(9, 19, 31);
        Color inactive = Color.FromArgb(27, 55, 90);

        private MySqlConnection connection;
        private bool updatePasswordMenu = false;
        private string tempUsername;
        private int loginAttempts;
        private bool peekActive;
        public Login()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            textBoxUsername.Focus();

            textBoxUsername.Enabled = true;
            textBoxUsername.BackColor = color;
            textBoxPassword.Enabled = true;
            textBoxPassword.BackColor = color;

            connection = DatabaseHelper.GetOpenConnection();
        }

        public Login(MySqlConnection connection)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            textBoxUsername.Focus();

            textBoxUsername.Enabled = true;
            textBoxUsername.BackColor = color;
            textBoxPassword.Enabled = true;
            textBoxPassword.BackColor = color;

            this.connection = connection;
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DatabaseHelper.CloseConnection(this.connection);


                Application.Exit();
            }
        }

        private void passwordChangeUI()
        {
            incorrect.Visible = false;
            groupBox1.Text = "Enter New Password";
            groupBox2.Text = "Re-enter New Password";
            button1.Text = "Confirm";
            label1.Text = "Set up Password";
            label2.Text = "Password must be at least 8 characters, has one uppercase letter, number and special character.";
            textBoxUsername.UseSystemPasswordChar = true;
            textBoxUsername.Focus();
            btnPeek.Visible = false;
            peekActive = false;
            textBoxPassword.UseSystemPasswordChar = true;
        }

        private void normalLoginUI()
        {
            groupBox1.Text = "Employee ID";
            groupBox2.Text = "Password";
            button1.Text = "Login";
            label1.Text = "Welcome Back!";
            label2.Text = "Please login using your Employee ID and Password.";
            textBoxUsername.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
            textBoxUsername.UseSystemPasswordChar = false;
            textBoxUsername.Focus();
            btnPeek.Visible = true;
            peekActive = false;
            btnPeek.Image = Properties.Resources.icons8_eye_50;
            textBoxPassword.UseSystemPasswordChar = true;
        }

        private Task<(string, string, string)> GetUserDetailsFromDatabaseAsync(string enteredUsername)
        {
            // Simulated synchronous method returning tuple
            (string firstName, string lastName, string role) userDetails = GetUserDetailsFromDatabase(enteredUsername);

            // Wrap the tuple in a completed Task
            return Task.FromResult(userDetails);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string enteredUsername = textBoxUsername.Text;
            string enteredPassword = textBoxPassword.Text;

            if (updatePasswordMenu)
            {
                if (enteredPassword != enteredUsername)
                {
                    MessageBox.Show("Password does not match.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                UpdatePasswordInTable(tempUsername, enteredPassword);
            }
            else
            {
                if (enteredUsername == "" || enteredPassword == "")
                {
                    textBoxUsername.Enabled = false;
                    textBoxUsername.BackColor = inactive;
                    textBoxPassword.Enabled = false;
                    textBoxPassword.BackColor = inactive;
                    btnPeek.Visible = false; 

                    await Task.Delay(1000);
                    MessageBox.Show("Username or Password is missing! Please try again.");

                    textBoxUsername.Enabled = true;
                    textBoxUsername.BackColor = color;
                    textBoxPassword.Enabled = true;
                    textBoxPassword.BackColor = color;
                    btnPeek.Visible = true;
                    peekActive = false;
                    textBoxPassword.UseSystemPasswordChar = true;
                    btnPeek.Image = Properties.Resources.icons8_eye_50;

                    return;
                }
                else
                {
                    textBoxUsername.Enabled = false;
                    textBoxUsername.BackColor = inactive;
                    textBoxPassword.Enabled = false;
                    textBoxPassword.BackColor = inactive;
                    btnPeek.Visible = false;
                    peekActive = false;
                    textBoxPassword.UseSystemPasswordChar = true;
                    btnPeek.Image = Properties.Resources.icons8_eye_50;

                    await Task.Delay(1000);
                    if (CheckLogin(enteredUsername, enteredPassword))
                    {
                        incorrect.Visible = false;

                        if (updatePasswordMenu)
                        {

                            textBoxUsername.Enabled = true;
                            textBoxUsername.BackColor = color;
                            textBoxPassword.Enabled = true;
                            textBoxPassword.BackColor = color;
                            tempUsername = enteredUsername;
                            textBoxPassword.Text = string.Empty; textBoxUsername.Text = string.Empty;

                            passwordChangeUI();
                            return;
                        }
                        /*
                        (string firstName, string lastName, string role) = GetUserDetailsFromDatabase(enteredUsername);
                        Dashboard form1 = new Dashboard(firstName, lastName, role, enteredUsername);

                        
                        this.Hide();
                        ShowLoadingForm(firstName);

                        form1.Show();
                        */

                        // Asynchronously fetch user details and wait for both tasks to complete
                        Task<(string, string, string)> userDetailsTask = GetUserDetailsFromDatabaseAsync(enteredUsername);
                        await Task.WhenAll(userDetailsTask);

                        // Retrieve user details
                        (string firstName, string lastName, string role) = await userDetailsTask;

                        Dashboard form1 = new Dashboard(firstName, lastName, role, enteredUsername);

                        // Hide the current form and show loading form
                        this.Hide();
                        ShowLoadingForm(firstName);

                        // Show the Dashboard form
                        form1.Show();

                        if (connection != null)
                        {
                            connection.Close();
                            connection.Dispose();
                        }
                        this.Close();
                    }
                    else
                    {
                        // Login failed
                        // loginAttempts--;
                        int loginAttempts = 5 - this.loginAttempts;
                        if (loginAttempts > 3)
                        {
                            incorrect.Text = "Your entered credentials is incorrect. Please try again.";
                        }
                        else if (loginAttempts == 3)
                        {
                            incorrect.Text = "You have 3 login attempts remaining.";
                        }
                        else if (loginAttempts < 3)
                        {
                            incorrect.Text = $"You have {loginAttempts} login attempts remaining. Please try again.";
                        }
                        else
                        {
                            incorrect.Text = "This profile is locked due to multiple failed login attempts. Reach out to your supervisor to reset your password.";
                            // You can also disable the login button or take other actions here.
                        }


                        textBoxUsername.Enabled = false;
                        textBoxUsername.BackColor = inactive;
                        textBoxPassword.Enabled = false;
                        textBoxPassword.BackColor = inactive;
                        btnPeek.Visible = false;
                        peekActive = false;
                        textBoxPassword.UseSystemPasswordChar = true;
                        btnPeek.Image = Properties.Resources.icons8_eye_50;
                        await Task.Delay(1000);

                        incorrect.Visible = true;

                        textBoxUsername.Enabled = true;
                        textBoxUsername.BackColor = color;
                        textBoxPassword.Enabled = true;
                        textBoxPassword.BackColor = color;
                        btnPeek.Visible = true;

                        textBoxPassword.Text = "";
                        textBoxUsername.Text = "";
                        textBoxUsername.Focus();
                    }
                }
            }
        }

        private void UpdatePasswordInTable(string username, string newPassword)
        {
            try
            {
                string salt = PasswordHashing.GenerateSalt(); 
                string hashedPassword = PasswordHashing.HashString(newPassword, salt);

                if (!IsNewPasswordValid(newPassword))
                {
                    MessageBox.Show("New password must meet the following requirements:\n" +
                                    "- At least 8-16 characters in length\n" +
                                    "- At least one uppercase letter (A-Z)\n" +
                                    "- At least one digit (0-9)\n" +
                                    "- At least one special character (!@#$%^&*)\n",
                                    "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string updateQuery = "UPDATE logins SET password = @Password, salt = @Salt, temporary_password = 0 WHERE username = @Username";

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Password", hashedPassword);
                    command.Parameters.AddWithValue("@Salt", salt);
                    command.Parameters.AddWithValue("@Username", username);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        normalLoginUI();
                        updatePasswordMenu = false;
                        textBoxPassword.Text = string.Empty; textBoxUsername.Text = string.Empty;

                        string memoText = $"Created new password for {username} {Environment.NewLine}Account is automatically unlocked.";
                        MaintenanceMemo newmemo = new MaintenanceMemo("System Initiated Account Protection", "New Password", memoText, 1);
                        newmemo.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                MessageBox.Show("An error occurred while updating the password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsNewPasswordValid(string password)
        {
            // Define a regular expression pattern that enforces the password requirements
            string pattern = "^(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*]).{8,16}$";

            // Use Regex.IsMatch to check if the password matches the pattern
            return Regex.IsMatch(password, pattern);
        }


        private bool CheckLogin(string username, string password)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                // SQL statement to check for the username and password, as well as additional conditions in the 'logins' table
                string query = "SELECT password, salt, COUNT(*) FROM logins WHERE BINARY username = @username AND employee_status = 1";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string hashedPasswordFromDB = reader.GetString(0);
                        string salt = reader.GetString(1);
                        int count = reader.GetInt32(2);
                        reader.Close();

                        bool passwordMatch = PasswordHashing.VerifyPassword(password, hashedPasswordFromDB, salt);


                        if (passwordMatch)
                        {
                            ResetLoginAttempts(username);
                            string tempPasswordQuery = "SELECT temporary_password FROM logins WHERE username = @username";
                            MySqlCommand tempPasswordCommand = new MySqlCommand(tempPasswordQuery, connection);
                            tempPasswordCommand.Parameters.AddWithValue("@username", username);
                            int tempPassword = Convert.ToInt32(tempPasswordCommand.ExecuteScalar());

                            if (tempPassword == 1)
                            {
                                updatePasswordMenu = true;
                            }
                        }
                        else
                        {
                            // Failed login, increment login attempts
                            IncrementLoginAttempts(username);

                            // Check if login attempts exceed a limit
                            this.loginAttempts = GetLoginAttempts(username);
                            if (loginAttempts >= 5)
                            {
                                LockAccount(username);
                                MessageBox.Show("This profile is locked due to multiple failed attempts. " +
                                    "Reach out to your supervisor to reset your password.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        return passwordMatch; // If passwordMatch is true, a matching record was found
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                incorrect.Visible = true;
                incorrect.Text = "Error: " + ex.Message;
                return false;
            }

            return false;
        }

        private void IncrementLoginAttempts(string username)
        {
            // Increment the login attempts for the user
            string incrementQuery = "UPDATE logins SET login_attempts = login_attempts + 1 WHERE username = @username";
            MySqlCommand incrementCommand = new MySqlCommand(incrementQuery, connection);
            incrementCommand.Parameters.AddWithValue("@username", username);
            incrementCommand.ExecuteNonQuery();
        }

        private int GetLoginAttempts(string username)
        {
            // Retrieve the current login attempts count


            string query = "SELECT login_attempts FROM logins WHERE username = @username";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);
            int loginAttempts = Convert.ToInt32(command.ExecuteScalar());

            if (loginAttempts >= 5)
            {
                this.loginAttempts = 0;
            }
            else
            {
                this.loginAttempts = 5 - loginAttempts;
            }

            
            return loginAttempts;
        }

        private void ResetLoginAttempts(string username)
        {
            // Reset the login attempts for the user
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            string resetQuery = "UPDATE logins SET login_attempts = 0, active_session = 1, active_since = @currentTime WHERE username = @username";
            MySqlCommand resetCommand = new MySqlCommand(resetQuery, connection);
            resetCommand.Parameters.AddWithValue("@username", username);
            resetCommand.Parameters.AddWithValue("@currentTime", DateTime.Now.TimeOfDay);
            resetCommand.ExecuteNonQuery();
        }

        private void LockAccount(string username)
        {
            // Lock the user account by setting employee_status to 0
            string lockQuery = "UPDATE logins SET employee_status = 0 WHERE username = @username";
            MySqlCommand lockCommand = new MySqlCommand(lockQuery, connection);
            lockCommand.Parameters.AddWithValue("@username", username);
            lockCommand.ExecuteNonQuery();
            string memoText = $"Profile {username} is locked due to multiple failed attempts.";
            MaintenanceMemo newmemo = new MaintenanceMemo("System Initiated Account Protection", "Locked Account", memoText, 1);
            newmemo.Hide();
        }

        private void ShowLoadingForm(string firstName)
        {
            LoadingForm loadingForm = new LoadingForm(firstName);
            loadingForm.StartPosition = FormStartPosition.CenterScreen;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000;
            timer.Tick += (sender, e) =>
            {
                loadingForm.Close();
                timer.Stop();
            };
            timer.Start();

            loadingForm.ShowDialog();
        }


        private (string, string, string) GetUserDetailsFromDatabase(string username)
        {
            string firstName = null;
            string lastName = null;
            string role = null;


            using (connection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    // SQL statement to retrieve the user details based on the username
                    string query = "SELECT first_name, last_name, role FROM logins WHERE username = @username";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            firstName = reader["first_name"].ToString();
                            lastName = reader["last_name"].ToString();
                            role = reader["role"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                return (firstName, lastName, role);
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit? \nConnection to database will be terminated and closed.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DatabaseHelper.CloseConnection(DatabaseHelper.GetMemoConnection());
                DatabaseHelper.CloseConnection(connection);
                Application.Exit();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        private void btnPeek_Click(object sender, EventArgs e)
        {
            if (!peekActive)
            {
                peekActive = true;
                btnPeek.Image = Properties.Resources.icons8_closed_eye_50;
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                peekActive = false;
                btnPeek.Image = Properties.Resources.icons8_eye_50;
                textBoxPassword.UseSystemPasswordChar = true;
            }
            
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connection != null)
            {
                connection.Dispose();
                connection.Close();
            }
        }

        private void textBoxUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
