using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;

namespace Dashboard.Forms
{
    public partial class Validation : Form
    {
        string phone_number;
        string email;
        string textcode;
        int customer_id;
        string employee_name;
        private static readonly Random random = new Random();
        public Validation(string PhoneNumber, string Email, string EmployeeName, int CustomerID)
        {
            InitializeComponent();
            phone_number = PhoneNumber;
            email = Email;
            customer_id = CustomerID;
            employee_name = EmployeeName;

            lblEmail.Text = "(" + email + ")";
            lblNumber.Text = "(" + phone_number + ")";
            textcode = GenerateRandom6DigitNumber().ToString();
        }

        public static int GenerateRandom6DigitNumber()
        {

            // Generate a random number between 100,000 (inclusive) and 999,999 (exclusive)
            return random.Next(100000, 1000000);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioEmail.Checked)
            {

                string recipientEmail = email; 
                string subject = "Text Code Validation"; 
                string plainTextBody = "Please do not share this with anyone unless a verified contact center employee. Your OTP is " + textcode +
                                        ". Please provide it only to a contact center employee. If you did not request this code, please contact us for your assistance.";



                string htmlBody = ConvertPlainTextToHtml(plainTextBody); // Convert to HTML format

                string memoText = subject + Environment.NewLine + plainTextBody;

                string body = htmlBody;
                LoadingScreenManager.ShowLoadingScreen(() =>
                {
                    SendsEmail(recipientEmail, subject, body);
                });

                groupBox1.Enabled = false;
                groupBox2.Enabled = true;



            }
            if (radioSMS.Checked)
            {

                    sendMessage();
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;

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
                    From = new MailAddress(fromEmail, "Contact Center"),
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

        private string ConvertPlainTextToHtml(string plainText)
        {
            // Replace newline characters with <br> tags
            string htmlText = plainText.Replace(Environment.NewLine, "<br />");

            // Enclose the result in HTML and BODY tags
            htmlText = "<html><body>" + htmlText + "</body></html>";

            return htmlText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == textcode)
            {
                label2.Visible = true;
                label2.Text = "Validated.";
                label2.ForeColor = Color.DarkGreen;
                groupBox3.Enabled = true;
                button3.Enabled = true;
                groupBox2.Enabled = false;
            }
            else
            {
                label2.Visible = true;
                label2.Text = "Incorrect!";
                label2.ForeColor = Color.DarkRed;
            }
        }


        private void sendMessage()
        {
            string phoneNumber = phone_number;
            string body = "Your OTP is " + textcode;
            string outro = ". If you did not request this code, please contact us for your assistance.";

            string message = body + outro;

            try
            {
                // Specify the full path to the ADB executable
                // string adbPath = @"C:\platform-tools\adb.exe";
                string adbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "platform-tools", "adb.exe");

                // Construct the ADB command
                string adbCommand = $"shell service call isms 7 i32 0 s16 \"com.android.mms.service\" s16 \"{phoneNumber}\" s16 \"null\" s16 \"'{message}'\" s16 \"null\" s16 \"null\"";

                // Execute the ADB command
                Process process = new Process();
                process.StartInfo.FileName = adbPath;
                process.StartInfo.Arguments = adbCommand;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                process.WaitForExit();

                // Check the exit code to determine if the message was sent successfully
                int exitCode = process.ExitCode;
                if (exitCode == 0)
                {
                    // disable then enable
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Failed to send SMS. Please check your ADB setup and permissions.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioEmail.Checked)
            {
                LoadingScreenManager.ShowLoadingScreen(() =>
                {
                    AddMemo newmemo = new AddMemo(customer_id, employee_name, "Validation Sucessful", "Validated via email sent to " + email);
                    newmemo.ShowDialog();
                });
            }
            if (radioSMS.Checked)
            {
                LoadingScreenManager.ShowLoadingScreen(() =>
                {
                    AddMemo newmemo = new AddMemo(customer_id, employee_name, "Validation Sucessful", "Validated via text sent to " + phone_number);
                    newmemo.ShowDialog();
                });
            }

            this.Close();
        }

    }
}
