using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.PeerToPeer;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Dashboard.Forms
{
    public partial class SendSMS : Form
    {
        private string phone_number;
        private string employee_name;
        private int customer_id;

        public SendSMS(string phoneNumber, string employeeName, int customerID)
        {
            InitializeComponent();
            this.Focus();
            this.phone_number = phoneNumber;
            this.employee_name = employeeName;
            this.customer_id = customerID;
            textBox1.Text = phoneNumber;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sendMessage()
        {
            string phoneNumber = textBox1.Text;
            string subject = Subject.Text.ToString() + Environment.NewLine;
            string body = textBox3.Text;
            // string outro = "If you have any questions or need assistance, don't hesitate to reach out. Have a fantastic day!";

            string message = subject + body;

            try
            {
                // Specify the full path to the ADB executable
                string adbPath = @"C:\platform-tools\adb.exe"; // Replace with the actual path on your system.

                // Construct the ADB command
                string adbCommand = $"shell service call isms 7 i32 0 s16 \"com.android.mms.service\" s16 \"{phoneNumber}\" s16 \"null\" s16 \"'{message}'\" s16 \"null\" s16 \"null\"";

                // Construct the ADB command to read the message from the text file
                //string adbCommand = $"shell service call isms 7 i32 0 s16 \"com.android.mms.service\" s16 \"{phoneNumber}\" s16 \"null\" s16 \"$(cat {tempFileName})\" s16 \"null\" s16 \"null\"";

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
                    LoadingScreenManager.ShowLoadingScreen(() =>
                    {
                        // The code inside this block is executed while the loading animation is displayed
                        AddMemo memo = new AddMemo(customer_id, employee_name, "SMS Message", Subject.Text + Environment.NewLine + body);
                        memo.ShowDialog();
                    });
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

        private void button1_Click(object sender, EventArgs e)
        {
            sendMessage();

            this.Close();

        }

    }
}
