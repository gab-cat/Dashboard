using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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

        private async void button1_Click(object sender, EventArgs e)
        {
            string enteredUsername = textBoxUsername.Text;
            string enteredPassword = textBoxPassword.Text;



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

        private bool CheckLogin(string username, string password)
        {
            try
            {
                if (connection == null)
                {
                    return false;
                }

                // SQL statement to check for the username and password in the 'logins' table
                string query = "SELECT COUNT(*) FROM logins WHERE username = @username AND password = @password";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                int count = Convert.ToInt32(command.ExecuteScalar());

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
