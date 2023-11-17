using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dashboard
{
    public partial class ClockTimeCard : Form
    {
        private MySqlConnection connection;
        private string employeeName;
        private DateTime currentDate = DateTime.Now.Date;
        private string activity;
        private string ind = null;
        public ClockTimeCard(MySqlConnection connection, string employeeName)
        {
            InitializeComponent();
            this.connection = connection;
            this.employeeName = employeeName;

            dateTimePicker1.Value = DateTime.Now.Date;
            txtDate.Text = currentDate.ToString("yyyy-MM-dd");
            DisplayTimeInOut(employeeName, txtDate.Text);
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ClockTimeCard_Load(object sender, EventArgs e)
        {

        }

        private void DisplayTimeInOut(string employeeName, string selectedDate)
        {
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string selectQuery = "SELECT * FROM clockIns WHERE username = @username AND clockIn_date = @date";

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@username", employeeName);
                    cmd.Parameters.AddWithValue("@date", selectedDate);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cboxActivity.Enabled = true;

                            // Display shift start and end times
                            DisplayTimeInTextbox("shift_start", "shift_end", reader);

                            // Display break times
                            DisplayTimeInTextbox("break1_start", "break1_end", reader);
                            DisplayTimeInTextbox("lunch_start", "lunch_end", reader);
                            DisplayTimeInTextbox("break2_start", "break2_end", reader);

                            // Display other activity times
                            DisplayTimeInTextbox("biobreak_start", "biobreak_end", reader);
                            DisplayTimeInTextbox("overtime_start", "overtime_end", reader);
                            DisplayTimeInTextbox("unscheduled_start", "unscheduled_end", reader);
                            DisplayTimeInTextbox("pullout_start", "pullout_end", reader);

                            txtshift_start.Enabled = true;
                            txtshift_end.Enabled = true;
                            txtbreak1_start.Enabled = true;
                            txtbreak1_end.Enabled = true;
                            txtlunch_start.Enabled = true;
                            txtlunch_end.Enabled = true;
                            txtbreak2_start.Enabled = true;
                            txtbreak2_end.Enabled = true;
                            txtbiobreak_start.Enabled = true;
                            txtbiobreak_end.Enabled = true;
                            txtovertime_start.Enabled = true;
                            txtovertime_end.Enabled = true;
                            txtunscheduled_start.Enabled = true;
                            txtunscheduled_end.Enabled = true;
                            txtpullout_start.Enabled = true;
                            txtpullout_end.Enabled = true;
                        }
                        else
                        {
                            // Handle the case when no record is found for the given employee and date
                            // MessageBox.Show("No records found for the selected date and employee.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtshift_start.Text = string.Empty;
                            txtshift_end.Text = string.Empty;
                            txtbreak1_start.Text = string.Empty;
                            txtbreak1_end.Text = string.Empty;
                            txtlunch_start.Text = string.Empty;
                            txtlunch_end.Text = string.Empty;
                            txtbreak2_start.Text = string.Empty;
                            txtbreak2_end.Text = string.Empty;
                            txtbiobreak_start.Text = string.Empty;
                            txtbiobreak_end.Text = string.Empty;
                            txtovertime_start.Text = string.Empty;
                            txtovertime_end.Text = string.Empty;
                            txtunscheduled_start.Text = string.Empty;
                            txtunscheduled_end.Text = string.Empty;
                            txtpullout_start.Text = string.Empty;
                            txtpullout_end.Text = string.Empty;

                            txtshift_start.Enabled = false;
                            txtshift_end.Enabled = false;
                            txtbreak1_start.Enabled = false;
                            txtbreak1_end.Enabled = false;
                            txtlunch_start.Enabled = false;
                            txtlunch_end.Enabled = false;
                            txtbreak2_start.Enabled = false;
                            txtbreak2_end.Enabled = false;
                            txtbiobreak_start.Enabled = false;
                            txtbiobreak_end.Enabled = false;
                            txtovertime_start.Enabled = false;
                            txtovertime_end.Enabled = false;
                            txtunscheduled_start.Enabled = false;
                            txtunscheduled_end.Enabled = false;
                            txtpullout_start.Enabled = false;
                            txtpullout_end.Enabled = false;


                            btnSubmit.Enabled = false;
                            cboxActivity.Enabled = false;
                        }
                    }
                }
            }
        }

        private void DisplayTimeInTextbox(string startTimeColumn, string endTimeColumn, MySqlDataReader reader)
        {
            // Example: startTimeColumn = "shift_start", endTimeColumn = "shift_end"
            string startTime = reader[startTimeColumn] != DBNull.Value ? ((TimeSpan)reader[startTimeColumn]).ToString("hh\\:mm") : "";
            string endTime = reader[endTimeColumn] != DBNull.Value ? ((TimeSpan)reader[endTimeColumn]).ToString("hh\\:mm") : "";

            // Example: textbox names are "txtshift_start" and "txtshift_end"
            Label startTextbox = Controls.Find("txt" + startTimeColumn, true).FirstOrDefault() as Label;
            Label endTextbox = Controls.Find("txt" + endTimeColumn, true).FirstOrDefault() as Label;

            if (startTextbox != null)
            {
                startTextbox.Text = startTime;
            }
            else
            {
                startTextbox.Text = "00:00";
            }

            if (endTextbox != null)
            {
                endTextbox.Text = endTime;
            }
            else
            {
                endTextbox.Text = "00:00";
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            txtDate.Text = selectedDate.ToString("yyyy-MM-dd");


            DisplayTimeInOut(employeeName, txtDate.Text);

            rbEnd.Enabled = false;
            rbStart.Enabled = false;
            txtTime.Enabled = false;
            txtReason.Enabled = false;

            cboxActivity.SelectedIndex = -1;
            rbStart.Checked = false;
            rbEnd.Checked = false;
            txtReason.Text = string.Empty;
        }

        private void cboxActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            activity = cboxActivity.Text.Trim().ToLower();
            rbEnd.Enabled = true;
            rbStart.Enabled = true;
            txtTime.Enabled = true;
            txtReason.Enabled = true;

            if (rbStart.Checked)
            {
                this.ind = "_start";
                string startTimeColumn = activity + ind;

                Label startTextbox = Controls.Find("txt" + startTimeColumn, true).FirstOrDefault() as Label;
                txtTime.Text = startTextbox?.Text;
            }
            else if (rbEnd.Checked)
            {
                this.ind = "_end";
                string endTimeColumn = activity + ind;

                Label endTextbox = Controls.Find("txt" + endTimeColumn, true).FirstOrDefault() as Label;
                txtTime.Text = endTextbox?.Text;
            }
            else
            {
                txtTime.Text = "00:00";
            }
        }

        private bool IsValidTimeFormat(string time)
        {
            // HH:mm format check
            return Regex.IsMatch(time, @"^([01]?[0-9]|2[0-3]):[0-5][0-9]$");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string reasonText = txtReason.Text.Trim();

            if (activity == null || ind == null || String.IsNullOrWhiteSpace(reasonText) ||! IsValidTimeFormat(txtTime.Text))
            {
                MessageBox.Show("No fields should be empty. Please fill out all fields and try again.", "Invalid Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string columnToChange = activity + ind;
            Label label = Controls.Find("txt" + columnToChange, true).FirstOrDefault() as Label;


            string startEnd;
            if (rbEnd.Checked == true)
            {
                startEnd = "End Time";
            }
            else
            {
                startEnd = "Start Time";
            }


            string message = "Please confirm that you want to file the dispute for your timestamp.\n" +
                             $"Activity             : {cboxActivity.Text}\n" +
                             $"Clock Activity   : {startEnd}\n" +
                             $"Original Time  : {label.Text}\n" +
                             $"Updated Time : {txtTime.Text}\n" +
                             $"Reason : {txtReason.Text}\n\n" +
                             "Your request will be forwarded to the manager for review. Please provide truthful and accurate information.\n" +
                             "Thank you for your cooperation.\n\n" +
                             "By clicking \"Yes\", you are acknowledging that the information provided is accurate to the best of your knowledge.";


            DialogResult result =  MessageBox.Show(message, "Dispute Request", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                string timeString = label.Text;

                string format = "HH:mm";

                DateTime timeValue;
                DateTime dateValue = dateTimePicker1.Value.Date; // Get the date part

                if (DateTime.TryParseExact(timeString, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out timeValue))
                {
                    DateTime dateTimeValue = dateValue.Add(timeValue.TimeOfDay); // Combine date and time
                    sendDispute(startEnd, dateTimeValue);
                }
                else
                {
                    bool success = DateTime.TryParseExact("00:00", format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out timeValue);
                    if (success)
                    {
                        DateTime dateTimeValue = dateValue.Add(timeValue.TimeOfDay); // Combine date and time
                        sendDispute(startEnd, dateTimeValue);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Time Format");
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void sendDispute(string startEnd, DateTime originalTime)
        {
            try
            {
                string directSupervisor = GetDirectSupervisor(employeeName); // Implement method to get direct supervisor
                if (directSupervisor == null)
                {
                    return;
                }
                DateTime requestTime = DateTime.Now;

                if (startEnd == "Start Time")
                {
                    startEnd = "_start";
                }
                else
                {
                    startEnd = "_end";
                }

                // Insert the dispute request into the database
                using (connection)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    string insertQuery = "INSERT INTO clock_disputes (username, direct_supervisor, read_status, activity, original_time, requested_time, start_end, reason, dispute_status, requested_date) " +
                                         "VALUES (@username, @directSupervisor, @readStatus, @activity, @originalTime, @requestedTime, @startEnd, @reason, @disputeStatus, @requestedDate)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", employeeName);
                        cmd.Parameters.AddWithValue("@directSupervisor", directSupervisor);
                        cmd.Parameters.AddWithValue("@readStatus", true); // Assuming default read status is false
                        cmd.Parameters.AddWithValue("@activity", cboxActivity.Text.ToLower());
                        cmd.Parameters.AddWithValue("@originalTime", originalTime);
                        cmd.Parameters.AddWithValue("@requestedTime", txtTime.Text);
                        cmd.Parameters.AddWithValue("@startEnd", startEnd);
                        cmd.Parameters.AddWithValue("@reason", txtReason.Text);
                        cmd.Parameters.AddWithValue("@disputeStatus", "Pending");
                        cmd.Parameters.AddWithValue("@requestedDate", dateTimePicker1.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Your request has been sent. Kindly wait for the request to be reviewed by your manager. You will be notified once this is approved or denied", "Request Processed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            rbEnd.Checked = false;
                            rbStart.Checked = false;
                            cboxActivity.SelectedIndex = -1;
                            txtTime.Text = string.Empty;
                            txtReason.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Failed to send the request. Please try again.", "Request Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetDirectSupervisor(string employeeName)
        {
            string supervisor = string.Empty;

            try
            {
                using (connection)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    string selectQuery = "SELECT direct_supervisor FROM logins WHERE username = @username";

                    using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", employeeName);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            supervisor = result.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Direct supervisor not found for the given username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving direct supervisor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return supervisor;
        }


        private void rbStart_CheckedChanged(object sender, EventArgs e)
        {
            this.ind = "_start";
            string startTimeColumn = activity + ind;

            Label startTextbox = Controls.Find("txt" + startTimeColumn, true).FirstOrDefault() as Label;
            if (startTextbox != null)
            {
                txtTime.Text = startTextbox.Text;
            }
            
        }

        private void rbEnd_Click(object sender, EventArgs e)
        {
            this.ind = "_end";
            string endTimeColumn = activity + ind;

            Label endTextbox = Controls.Find("txt" + endTimeColumn, true).FirstOrDefault() as Label;
            if (endTextbox != null)
            {
                txtTime.Text = endTextbox.Text;
            }
        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtReason.Text.Trim())) 
            {
                btnSubmit.Enabled = false;
            }
            else
            {
                btnSubmit.Enabled = true;
            }
        }

        private void txtTime_KeyDown(object sender, KeyEventArgs e)
        {
            // Allow numeric keys, backspace, colon, and navigation keys (arrows, Home, End, etc.)
            if (!((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                  (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
                  e.KeyCode == Keys.Back ||
                  e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                  e.KeyCode == Keys.Home || e.KeyCode == Keys.End ||
                  e.KeyCode == Keys.Delete || e.KeyCode == Keys.OemPeriod))
            {
                // Suppress the key press if it's not a valid key
                e.SuppressKeyPress = true;
            }

            // Automatically insert a colon after the 2nd character
            if (txtTime.TextLength == 2 && e.KeyCode != Keys.Back)
            {
                txtTime.Text += ":";
                txtTime.SelectionStart = txtTime.TextLength;
            }

            // Limit the character input to 5 characters
            // Limit the character input to 5 characters
            if (txtTime.TextLength >= 5 && e.KeyCode != Keys.Back && e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
            {
                e.SuppressKeyPress = true;
            }
        }


        private void doubleClick(Label label, string ind, int index)
        {
            if (ind == "start")
            {
                rbStart.Checked = true;
                txtTime.Text = label.Text;

                cboxActivity.SelectedIndex = index;
                rbStart.Enabled = true;
                rbEnd.Enabled = true;
                txtTime.Enabled = true;
                txtReason.Enabled = true;
            }
            else
            {
                rbEnd.Checked = true;
                txtTime.Text = label.Text;

                cboxActivity.SelectedIndex = index;
                rbStart.Enabled = true;
                rbEnd.Enabled = true;
                txtTime.Enabled = true;
                txtReason.Enabled = true;
            }
        }

        private void txtshift_start_DoubleClick(object sender, EventArgs e)
        {
            doubleClick(txtshift_start, "start", 0);
        }

        private void txtshift_end_DoubleClick(object sender, EventArgs e)
        {
            doubleClick(txtshift_end, "end", 0);
        }

        private void txtbreak1_start_DoubleClick(object sender, EventArgs e)
        {
            doubleClick(txtbreak1_start, "start", 1);
        }

        private void txtbreak1_end_DoubleClick(object sender, EventArgs e)
        {
            doubleClick(txtbreak1_end, "end", 1);
        }

        private void txtlunch_start_DoubleClick(object sender, EventArgs e)
        {
            doubleClick(txtlunch_start, "start", 2);
        }

        private void txtlunch_end_DoubleClick(object sender, EventArgs e)
        {
            doubleClick(txtlunch_end, "end", 2);
        }

        private void txtbreak2_start_DoubleClick(object sender, EventArgs e)
        {
            doubleClick(txtbreak2_start, "start", 3);
        }

        private void txtbreak2_end_DoubleClick(object sender, EventArgs e)
        {
            doubleClick(txtbreak2_end, "end", 3);
        }

        private void txtbiobreak_start_DoubleClick(object sender, EventArgs e)
        {
            doubleClick(txtbiobreak_start, "start", 4);
        }

        private void txtbiobreak_end_DoubleClick(object sender, EventArgs e)
        {
            doubleClick(txtbiobreak_end, "end", 4);
        }

        private void txtovertime_start_DoubleClick(object sender, EventArgs e)
        {
            doubleClick(txtovertime_start, "start", 5);
        }

        private void txtovertime_end_DoubleClick(object sender, EventArgs e)
        {
            doubleClick(txtovertime_end, "end", 5);
        }

        private void txtunscheduled_start_DoubleClick(object sender, EventArgs e)
        {
            doubleClick(txtunscheduled_start, "start", 6);
        }

        private void txtunscheduled_end_DoubleClick(object sender, EventArgs e)
        {
            doubleClick(txtunscheduled_end, "end", 6);
        }

        private void txtpullout_start_DoubleClick(object sender, EventArgs e)
        {
            doubleClick(txtpullout_start, "start", 7);
        }

        private void txtpullout_end_DoubleClick(object sender, EventArgs e)
        {
            doubleClick(txtpullout_end, "end", 7);
        }
    }
}
