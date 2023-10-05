using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Dashboard.Forms
{
    public partial class SendEmail : Form
    {
        private string email_address;
        private string employee_name;
        private int customer_id;
        public SendEmail(string emailAddress, string employeeName, int customerID)
        {
            InitializeComponent();
            this.Focus();
            this.email_address = emailAddress;
            this.employee_name = employeeName;
            this.customer_id = customerID;
            textBox1.Text = email_address;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    From = new MailAddress(fromEmail, "Gabriel Catimbang"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true, // Set this to true if your body contains HTML
                };

                message.To.Add(recipientEmail);

                client.Send(message);
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while sending the email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string recipientEmail = email_address; // Replace with the recipient's email address
            string subject = Subject.Text.ToString(); // Replace with your email subject
            string plainTextBody = textBox3.Text; // Get the plain text from the TextBox
            string htmlBody = ConvertPlainTextToHtml(plainTextBody); // Convert to HTML format

            string memoText = subject + Environment.NewLine + plainTextBody;

            string body = htmlBody + "<br /><br />" + GetEmailOutro(); // Combine with the outro
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                // The code inside this block is executed while the loading animation is displayed
                SendsEmail(recipientEmail, subject, body);
            });

            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                AddMemo emailMemo = new AddMemo(customer_id, employee_name, "Email Message", memoText);
                emailMemo.ShowDialog();
            });

        }

        private string ConvertPlainTextToHtml(string plainText)
        {
            // Replace newline characters with <br> tags
            string htmlText = plainText.Replace(Environment.NewLine, "<br />");

            // Enclose the result in HTML and BODY tags
            htmlText = "<html><body>" + htmlText + "</body></html>";

            return htmlText;
        }
        private string GetEmailOutro()
        {
            return @"
                <br /><br />
                <hr /> <!-- Horizontal line -->
                <strong>Thank you for choosing New Bernales Hardware Store as your trusted source for all your hardware needs.</strong> We appreciate your business and are always here to assist you with top-quality products and exceptional service.<br /><br />

                If you have any questions, suggestions, or require further assistance, please don't hesitate to reach out to us. Our friendly team is ready to help.<br /><br />

                <em>Stay tuned for more exciting updates and offers from the New Bernales Hardware Store! We look forward to serving you again soon.</em><br /><br />

                Best regards,<br />
                New Bernales Hardware Store<br />
                09650774515<br />
                hardwarestore@support.com";
        }
    }
}
