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

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void passwordChangeUI()
        {
            groupBox1.Text = "Enter New Password";
            groupBox2.Text = "Re-enter New Password";
            button1.Text = "Confirm";
            label1.Text = "Set up Password";
            label2.Text = "Password must be at least 8 characters, has one uppercase letter, number and special character.";
            textBoxUsername.UseSystemPasswordChar = true;
            textBoxUsername.Focus();

        }

        private void normalLoginUI()
        {
            groupBox1.Text = "Employee ID";
            groupBox2.Text = "Password";
            button1.Text = "Login";
            label1.Text = "Welcome Back!";
            label2.Text = "Please login using your Employee ID and Password.";
            textBoxUsername.UseSystemPasswordChar = false;
            textBoxUsername.Focus();
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

                    await Task.Delay(1000);
                    MessageBox.Show("Username or Password is missing! Please try again.");

                    textBoxUsername.Enabled = true;
                    textBoxUsername.BackColor = color;
                    textBoxPassword.Enabled = true;
                    textBoxPassword.BackColor = color;

                    return;
                }
                else
                {
                    textBoxUsername.Enabled = false;
                    textBoxUsername.BackColor = inactive;
                    textBoxPassword.Enabled = false;
                    textBoxPassword.BackColor = inactive;
                    await Task.Delay(1000);
                    if (CheckLogin(enteredUsername, enteredPassword))
                    {
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
                            


                        connection.Close();
                        (string firstName, string lastName, string role) = GetUserDetailsFromDatabase(enteredUsername);




                        Dashboard form1 = new Dashboard(firstName, lastName, role);

                        this.Hide();
                        ShowLoadingForm(firstName);

                        form1.Show();
                        this.Close();
                    }
                    else
                    {
                        textBoxUsername.Enabled = false;
                        textBoxUsername.BackColor = inactive;
                        textBoxPassword.Enabled = false;
                        textBoxPassword.BackColor = inactive;
                        await Task.Delay(1000);

                        incorrect.Visible = true;

                        textBoxUsername.Enabled = true;
                        textBoxUsername.BackColor = color;
                        textBoxPassword.Enabled = true;
                        textBoxPassword.BackColor = color;

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
                // Check if the new password meets the validation requirements
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


                // SQL statement to update the password and set temporary_password to 0
                string updateQuery = "UPDATE logins SET password = @Password, temporary_password = 0 WHERE username = @Username";

                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Password", newPassword);
                    command.Parameters.AddWithValue("@Username", username);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        normalLoginUI();
                        updatePasswordMenu = false;
                        textBoxPassword.Text = string.Empty; textBoxUsername.Text = string.Empty;
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
                if (connection == null)
                {
                    return false;
                }

                // SQL statement to check for the username and password, as well as additional conditions in the 'logins' table
                string query = "SELECT COUNT(*) FROM logins WHERE username = @username AND password = @password AND employee_status = 1";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    string tempPasswordQuery = "SELECT temporary_password FROM logins WHERE username = @username";
                    MySqlCommand tempPasswordCommand = new MySqlCommand(tempPasswordQuery, connection);
                    tempPasswordCommand.Parameters.AddWithValue("@username", username);
                    int tempPassword = Convert.ToInt32(tempPasswordCommand.ExecuteScalar());

                    if (tempPassword == 1)
                    {
                        updatePasswordMenu = true;
                    }
                }

                return count > 0; // If count > 0, a matching record was found
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                incorrect.Visible = true;
                incorrect.Text = "Server cannot be reached. \nPlease check your connection and restart the app.";
                return false;
            }
        }


        private void ShowLoadingForm(string firstName)
        {
            LoadingForm loadingForm = new LoadingForm(firstName);
            loadingForm.StartPosition = FormStartPosition.CenterScreen;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000;
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


            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    if (connection == null)
                    {
                        return (firstName, lastName, role);
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
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
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
    }
}
