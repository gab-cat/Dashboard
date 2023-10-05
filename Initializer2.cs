using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace Dashboard
{
    public partial class Initializer2 : Form
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

        private const int ProgressBarFillDuration = 3000; // 5 seconds
        private const int ProgressBarMaximum = 100; // Maximum value for the progress bar
        private CustomProgressBar customProgressBar1;
        bool isDatabaseConnected = false;


        public Initializer2()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            Shown += Initializer_Shown;
            customProgressBar1 = new CustomProgressBar(); // Initialize the custom progress bar
            Color color = Color.FromArgb(139, 139, 177);
            customProgressBar1.ForeColor = color; // Set the foreground color (not needed since it's set in the CustomProgressBar constructor)


            customProgressBar1.Size = new Size(510, 15); // Width = 200, Height = 50

            // Set the location of the progress bar
            customProgressBar1.Location = new Point(0, 100); // X = 10, Y = 10

            Controls.Add(customProgressBar1);
            customProgressBar1.BringToFront();
            richTextBox1.GotFocus += (sender, e) => { richTextBox1.Parent.Focus(); };
        }

        private async void Initializer_Shown(object sender, EventArgs e)
        {
            customProgressBar1.Maximum = ProgressBarMaximum;
            customProgressBar1.Value = 0; // Initial value at 0

            // Fill the first half of the progress bar
            for (int i = 0; i <= ProgressBarMaximum / 2; i++)
            {
                customProgressBar1.Value = i;
                await Task.Delay(ProgressBarFillDuration / (ProgressBarMaximum / 2));
            }

            try
            {
                // Perform the database connection check here
                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    if (connection == null) 
                    {
                        throw new Exception("Unable to establish a database connection.");
                    }
                    // Create a professionally worded message with a "Liabilities and Responsibilities" link
                    string message = "This software is intended solely for legitimate business purposes. Any unauthorized use or misuse of this software may result in legal action by the company." +
                        "\n\nBy clicking 'Agree,' you acknowledge and accept the following:" +
                        "\n\nLiabilities and Responsibilities:" +
                        "\n- You are fully responsible for the appropriate and lawful use of this software within the scope of your business activities." +
                        "\n- Any misuse, unauthorized access, or violation of laws and regulations while using this software may lead to legal consequences." +
                        "\n\nPlease take a moment to review the full 'Liabilities and Responsibilities' before proceeding. Click 'Agree' to signify your understanding and acceptance.";

                    // Show a confirmation message with a "Liabilities and Responsibilities" link
                    var result = MessageBox.Show(
                        message,
                        "Software Usage Agreement",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        // await connection.OpenAsync(); // Use asynchronous connection open
                        label4.Text = "Successfully authenticated to database server   .   .   .";
                        await Task.Delay(1500);
                        // Fill the second half of the progress bar
                        label4.Text = "Establishing connection with the database server   .   .   .";
                        for (int i = customProgressBar1.Value; i <= ProgressBarMaximum; i++)
                        {
                            customProgressBar1.Value = i;
                            await Task.Delay(ProgressBarFillDuration / (ProgressBarMaximum / 2));
                        }

                        // Wait for 1 second
                        label4.Text = "Initializing software  .   .   .";
                        await Task.Delay(1000);

                        // Show the login screen
                        DatabaseHelper.CloseConnection(connection);
                        this.Hide();

                        Login loginForm = new Login();
                        loginForm.Show();
                    }
                    else
                    {
                        // User did not agree, exit the application
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                if (!isDatabaseConnected)
                {
                    // Connection failed, show an error message
                    MessageBox.Show($"An error occurred while opening the database connection: {ex.Message} The application will now terminate.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }

        }
    }
}


