using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Guna.UI.WinForms;
using System.Globalization;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using System.Diagnostics;
using iTextSharp.text.pdf.parser.clipper;
using Twilio.TwiML.Voice;

namespace Dashboard
{
    public partial class Clock : Form
    {
        private Guna.UI.WinForms.GunaAdvenceTileButton lastClickedButton = null;
        private bool clockedIn = false;
        private bool activeButton = false;
        private bool break1, lunch, break2, bio, overtime, unsch, pullout= false;
        private string employee_name = "admina";
        private Form activeForm;

        private Color defaultColor = Color.FromArgb(51, 51, 76);
        private Color disabledColor = Color.FromArgb(70, 70, 86);

        private MySqlConnection connection = DatabaseHelper.GetOpenConnection();

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


        public Clock()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            // Set up the timer to update the clock every second
            Timer timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += Timer_Tick;
            timer.Start();

            // Initial update of the clock and date
            UpdateClock();
            UpdateDate();
            UpdateDayHighlight();

            CheckClockOutStatus();

            panelDesktopPane.Visible = false;
            panel4.Visible = true;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the clock, date, and day highlight every second
            UpdateClock();
        }

        private void UpdateClock()
        {
            // Display the current time in lblClock
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void UpdateDate()
        {
            // Display the current date in lblDate
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
        }

        private void UpdateDayHighlight()
        {
            // Highlight the label for the current day of the week
            string currentDayOfWeek = DateTime.Now.DayOfWeek.ToString();

            // Reset font styles for all days
            foreach (Control control in panel2.Controls)
            {
                if (control is Label label && label.Name.StartsWith("lbl"))
                {
                    label.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999f, FontStyle.Regular);
                    label.ForeColor = Color.Gray;
                }
            }

            // Highlight the font for the current day
            Label highlightedLabel = Controls.Find("lbl" + currentDayOfWeek, true).FirstOrDefault() as Label;
            if (highlightedLabel != null)
            {
                highlightedLabel.Font = new System.Drawing.Font("Outfit Thin", 9.749999f, FontStyle.Bold);
                highlightedLabel.ForeColor = Color.White;
            }
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnStartEnd_MouseLeave(object sender, EventArgs e)
        {
            if (clockedIn)
            {
                if (activeButton) lblStartEnd.BackColor = Color.FromArgb(127, 37, 37);
                if (!activeButton) lblStartEnd.BackColor = Color.DarkRed; 
            }
            else
            {
                lblStartEnd.BackColor = Color.FromArgb(51, 51, 76);
            }
        }

        private void btnStartEnd_MouseEnter(object sender, EventArgs e)
        {
            lblStartEnd.BackColor = Color.DimGray;
        }

        private void btnStartEnd_MouseHover(object sender, EventArgs e)
        {
            lblStartEnd.BackColor = Color.DimGray;
        }

        private void btnStartEnd_Click(object sender, EventArgs e)
        {
            // Check if the employee has already clocked out
            string clockOutStatusMessage = CheckClockOutStatus();
            if (!string.IsNullOrEmpty(clockOutStatusMessage))
            {
                MessageBox.Show(clockOutStatusMessage, "Clock Out Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!clockedIn)
            {
                timestampGrid.Rows.Clear();

                string startTime = DateTime.Now.ToString("HH:mm");
                timestampGrid.Rows.Add("Shift", startTime, "", "9 hrs");

                InsertClockInRecord("Shift", startTime, null);

                clockedIn = true;
                enableButtons();
                btnStartEnd.BaseColor = Color.DarkRed;
                btnStartEnd.Image = Properties.Resources.icons8_stop_50;
                // lblStartEnd.BackColor = Color.DarkRed;
                btnStartEnd.Text = "End Shift";
                lblStartEnd.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                endShift();

                clockedIn = false;
                disableButtons();
                btnStartEnd.BaseColor = defaultColor;
                btnStartEnd.Image = Properties.Resources.icons8_play_30;
                lblStartEnd.BackColor = defaultColor;
                btnStartEnd.Text = "Start Shift";
            }

        }

        private void endShift()
        {
            string endTime = DateTime.Now.ToString("HH:mm");
            int shiftRowIndex = GetRowIndex("Shift");

            InsertClockOutRecord("Shift", endTime);

            if (shiftRowIndex >= 0)
            {
                // Update EndTime
                timestampGrid.Rows[shiftRowIndex].Cells["EndTime"].Value = endTime;

                // Calculate Duration
                string startTimeStr = timestampGrid.Rows[shiftRowIndex].Cells["StartTime"].Value.ToString();
                DateTime startTime = DateTime.ParseExact(startTimeStr, "HH:mm", CultureInfo.InvariantCulture);
                DateTime endTimeDT = DateTime.ParseExact(endTime, "HH:mm", CultureInfo.InvariantCulture);
                TimeSpan duration = endTimeDT - startTime;
                string durationStr = duration.ToString("hh\\:mm");

                timestampGrid.Rows[shiftRowIndex].Cells["Duration"].Value = durationStr;

                // Calculate Remarks
                int limitHours = 9;
                TimeSpan limit = new TimeSpan(limitHours, 0, 0);

                if (duration < limit)
                {
                    TimeSpan undertime = limit - duration;
                    string undertimeStr = undertime.ToString(@"hh\:mm");
                    timestampGrid.Rows[shiftRowIndex].Cells["Remarks"].Value = $"Undertime: {undertimeStr}";
                }
                else
                {
                    timestampGrid.Rows[shiftRowIndex].Cells["Remarks"].Value = "";
                }
            }
        }

        private int GetRowIndex(string activity)
        {
            // Find the row index in timestampGrid based on the activity
            foreach (DataGridViewRow row in timestampGrid.Rows)
            {
                if (row.Cells["Activity"].Value != null && row.Cells["Activity"].Value.ToString() == activity)
                {
                    return row.Index;
                }
            }
            return -1;
        }

        private void enableButtons()
        {
            foreach (Control control in panel3.Controls)
            {
                if (control is Guna.UI.WinForms.GunaAdvenceTileButton button1)
                {
                    button1.MouseEnter += new EventHandler(button_MouseEnter);
                    button1.MouseLeave += new EventHandler(button_MouseLeave);
                    
                }

                    if (control is Guna.UI.WinForms.GunaAdvenceTileButton button && button.Name != "btnStartEnd")
                {
                    button.Enabled = true;
                    button.Click += button_Click;
                }
                else if (control is Label label)
                {
                    label.Enabled = true;
                    label.BackColor = defaultColor;
                }
            }
        }

        private void disableButtons()
        {
            foreach (Control control in panel3.Controls)
            {


                if (control is Guna.UI.WinForms.GunaAdvenceTileButton button && button.Name != "btnStartEnd")
                {
                    button.Enabled = false;
                }
                else if (control is Label label)
                {
                    label.Enabled = false;
                    label.BackColor = disabledColor;
                }
            }
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            var button = sender as Guna.UI.WinForms.GunaAdvenceTileButton;
            button.BaseColor = Color.DimGray;

            var labelName = "lbl" + button.Name.Substring(3);
            var label = panel3.Controls[labelName] as Label;
            label.BackColor = Color.DimGray;
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {


            var button = sender as Guna.UI.WinForms.GunaAdvenceTileButton;
            var labelName = "lbl" + button.Name.Substring(3);
            var label = panel3.Controls[labelName] as Label;

            if (!activeButton)
            {
                button.BaseColor = defaultColor; // replace with your default color
                label.BackColor = defaultColor;
                button.Image = Properties.Resources.icons8_play_30;
            }
            else
            {
                button.BaseColor = Color.DarkRed;
                label.BackColor = Color.DarkRed;
                button.Image = Properties.Resources.icons8_stop_50;
            }


            if (clockedIn)
            {
                btnStartEnd.BaseColor = Color.DarkRed;
                if (!activeButton) lblStartEnd.BackColor = Color.DarkRed;
                if (activeButton) lblStartEnd.BackColor = Color.FromArgb(127, 37, 37);
            }
            else
            {
                btnStartEnd.BaseColor = defaultColor;
                lblStartEnd.BackColor = Color.FromArgb(51, 51, 76);
            }

        }

        
        private void SetButtonStyles(GunaAdvenceTileButton button, Label label)
        {
            label.BackColor = Color.DarkRed;
            label.Enabled = true;
            label.ForeColor = SystemColors.AppWorkspace;
            button.BaseColor = Color.DarkRed;
            button.Image = Properties.Resources.icons8_stop_50;
            button.Enabled = true; // Enable the clicked button
        }

        private void ResetButtonStyles(GunaAdvenceTileButton button, Label label)
        {
            if (button != null)
            {
                button.BaseColor = defaultColor;
                button.Image = Properties.Resources.icons8_play_30;
                button.Enabled = true; // Enable the previously clicked button
            }

            if (label != null)
            {
                label.BackColor = defaultColor;
                label.ForeColor = SystemColors.AppWorkspace;

                label.Enabled = true;
                label.ForeColor = Color.WhiteSmoke;
            }
        }

        
        private void button_Click(object sender, EventArgs e)
        {


            if (activeButton) 
            {
                foreach (Control control in panel3.Controls)
                {
                    if (control is Guna.UI.WinForms.GunaAdvenceTileButton button1)
                    {
                        button1.Enabled = false;
                    }
                    else if (control is Label labell)
                    {
                        labell.Enabled = false;
                        labell.BackColor = disabledColor;
                        
                    }
                }
            }
            else
            {
                foreach (Control control in panel3.Controls)
                {
                    if (control is Guna.UI.WinForms.GunaAdvenceTileButton button1)
                    {
                        button1.Enabled = true;
                    }
                    else if (control is Label label1)
                    {
                        label1.Enabled = true;
                        label1.BackColor = defaultColor;
                        
                    }
                }
            }

            var button = sender as Guna.UI.WinForms.GunaAdvenceTileButton;
            var labelName = "lbl" + button.Name.Substring(3);
            var label = panel3.Controls[labelName] as Label;

            if (button == lastClickedButton)
            {
                // Clicked the same button again
                ResetButtonStyles(button, label);
                lastClickedButton = null;

            }
            else
            {
                // Clicked a different button
                ResetButtonStyles(lastClickedButton, null);
                SetButtonStyles(button, label);
                lastClickedButton = button;

            }

            if (activeButton)
            {
                lblStartEnd.BackColor = Color.FromArgb(127, 37, 37);
            }
            else
            {
                lblStartEnd.BackColor = Color.DarkRed;
            }


        }


        private void ActivityButton_Click(object sender, EventArgs e, string activity, TimeSpan limit, string Limit)
        {
            var button = sender as Guna.UI.WinForms.GunaAdvenceTileButton;

            if (!button.Enabled)
            {
                // Button is already disabled, do nothing
                return;
            }

            if (!clockedIn)
            {
                MessageBox.Show("Please start the shift first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Add activity and start time to timestampGrid
            string startTime = DateTime.Now.ToString("HH:mm");
            timestampGrid.Rows.Add(activity, startTime, "", Limit);

            InsertClockInRecord(activity, startTime, limit);

            // Disable other buttons
            foreach (Control control in panel3.Controls)
            {
                if (control is Guna.UI.WinForms.GunaAdvenceTileButton otherButton && otherButton != button)
                {
                    otherButton.Enabled = false;
                }
                else if (control is Label label)
                {
                    label.Enabled = false;
                    label.BackColor = disabledColor;
                }
            }

            button.BaseColor = Color.DarkRed;
            button.Image = Properties.Resources.icons8_stop_50;

            // Attach the event handler for the activity button
            button.Click += (s, ev) => EndActivityButton_Click(s, ev, activity, limit);

            lastClickedButton = button;
        }


        private void EndActivityButton_Click(object sender, EventArgs e, string activity, TimeSpan limit)
        {
            var button = sender as Guna.UI.WinForms.GunaAdvenceTileButton;
            var labelName = "lbl" + button.Name.Substring(3);
            var label = panel3.Controls[labelName] as Label;

            // Update end time
            int activityRowIndex = GetRowIndex(activity);
            if (activityRowIndex >= 0)
            {
                string endTime = DateTime.Now.ToString("HH:mm");
                timestampGrid.Rows[activityRowIndex].Cells["EndTime"].Value = endTime;

                UpdateClockOutRecord(activity, endTime, limit);

                // Calculate duration
                string startTimeStr = timestampGrid.Rows[activityRowIndex].Cells["StartTime"].Value.ToString();
                DateTime startTime = DateTime.ParseExact(startTimeStr, "HH:mm", CultureInfo.InvariantCulture);
                DateTime endTimeDT = DateTime.ParseExact(endTime, "HH:mm", CultureInfo.InvariantCulture);
                TimeSpan duration = endTimeDT - startTime;
                string durationStr = duration.ToString("hh\\:mm");
                timestampGrid.Rows[activityRowIndex].Cells["Duration"].Value = durationStr;

                // Calculate remarks
                if (duration < limit)
                {
                    TimeSpan undertime = limit - duration;
                    string undertimeStr = undertime.ToString(@"hh\:mm");
                    timestampGrid.Rows[activityRowIndex].Cells["Remarks"].Value = $"Undertime: {undertimeStr}";
                }
                else if (limit < duration)
                {
                    TimeSpan overtime = duration - limit;
                    string overtimeStr = overtime.ToString(@"hh\:mm");
                    timestampGrid.Rows[activityRowIndex].Cells["Remarks"].Value = $"Overtime: {overtimeStr}";
                }
                else
                {
                    timestampGrid.Rows[activityRowIndex].Cells["Remarks"].Value = "On Time";
                }
            }

            // Reset button styles
            button.BaseColor = defaultColor;
            button.Image = Properties.Resources.icons8_play_30;

            // Enable other buttons
            foreach (Control control in panel3.Controls)
            {
                if (control is Guna.UI.WinForms.GunaAdvenceTileButton otherButton && otherButton != button)
                {
                    otherButton.Enabled = true;
                }
                else if (control is Label otherLabel)
                {
                    otherLabel.Enabled = true;
                    otherLabel.BackColor = defaultColor;
                }
            }

            // Detach the event handler
            button.Click -= new EventHandler((s, ev) => EndActivityButton_Click(s, ev, "ActivityName", TimeSpan.Zero));


            
            lastClickedButton = null;
        }

        private void InsertClockInRecord(string activity, string startTime, TimeSpan? limit)
        {
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                if (activity == "Shift")
                {
                    // Insert a new record for "Shift"
                    string insertQuery = "INSERT INTO clockIns (username, clockIn_date, clockIn_active, " +
                                        $"{activity.ToLower()}_start, {activity.ToLower()}_end) " +
                                        "VALUES (@username, @date, @active, @start, @end)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", employee_name);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@active", true);
                        cmd.Parameters.AddWithValue("@start", startTime);
                        cmd.Parameters.AddWithValue("@end", DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Update the existing "Shift" record
                    activity = activity.ToLower();
                    string updateQuery = $"UPDATE clockIns " +
                                         $"SET {activity.ToLower()}_start = @start, current_activity = @activity " +
                                         $"WHERE username = @username AND clockIn_date = @date";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@start", startTime);
                        cmd.Parameters.AddWithValue("@username", employee_name);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@activity", activity);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


        private void UpdateClockOutRecord(string activity, string endTime, TimeSpan limit)
        {
            using (connection)
            {
                if (connection.State != ConnectionState.Open) 
                {
                    connection.Open();
                }
                
                string updateQuery = $"UPDATE clockIns SET {activity.ToLower()}_end = @end, current_activity = null WHERE " +
                                     "username = @username AND clockIn_date = @date";

                using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@end", endTime);
                    cmd.Parameters.AddWithValue("@username", employee_name);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void InsertClockOutRecord(string activity, string endTime)
        {
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string updateQuery = $"UPDATE clockIns " +
                                     $"SET clockIn_active = @active, {activity.ToLower()}_end = @end " +
                                     $"WHERE username = @username AND clockIn_date = @date";

                using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@active", false);
                    cmd.Parameters.AddWithValue("@end", endTime);
                    cmd.Parameters.AddWithValue("@username", employee_name);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private string CheckClockOutStatus()
        {
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string selectQuery = "SELECT * " +
                                     "FROM clockIns " +
                                     "WHERE username = @username AND clockIn_date = @date";

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@username", employee_name);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int clockInActive = Convert.ToInt32(reader["clockIn_active"]);

                            if (clockInActive == 0)
                            {
                                // Add shift activity to timestamp grid
                                string startTime = ((TimeSpan)reader["shift_start"]).ToString(@"hh\:mm"); 
                                string endTime = ((TimeSpan)reader["shift_end"]).ToString(@"hh\:mm"); 

                                timestampGrid.Rows.Clear();

                                timestampGrid.Rows.Add("Shift", startTime, endTime, "9 hrs");
                                UpdateDurationAndRemarks("Shift", startTime, endTime, "9 hrs");


                                // Add other activities to timestamp grid
                                foreach (var activity in GetActivityColumns())
                                {
                                    string activityName = activity.Key;
                                    string startColumnName = activity.Value + "_start";
                                    string endColumnName = activity.Value + "_end";

                                    if (reader[startColumnName] != DBNull.Value)
                                    {
                                        // Use TimeSpan.ToString for TimeSpan values
                                        string start = ((TimeSpan)reader[startColumnName]).ToString(@"hh\:mm");
                                        string end = reader[endColumnName] != DBNull.Value ? ((TimeSpan)reader[endColumnName]).ToString(@"hh\:mm") : "";


                                        timestampGrid.Rows.Add(activityName, start, end, GetLimitString(activityName));
                                        if (end != "")
                                        {
                                            UpdateDurationAndRemarks(activityName, start, end, GetLimitString(activityName));
                                        }

                                    }
                                }

                                return "You have already clocked out for the day. Your shift is over. Please reach out to your supervisor for assistance.";
                            }
                            else if (clockInActive == 1)
                            {
                                clockedIn = true;
                                enableButtons();
                                btnStartEnd.BaseColor = Color.DarkRed;
                                btnStartEnd.Image = Properties.Resources.icons8_stop_50;
                                lblStartEnd.BackColor = Color.DarkRed;
                                btnStartEnd.Text = "End Shift";
                                lblStartEnd.ForeColor = Color.WhiteSmoke;

                                timestampGrid.Rows.Clear();

                                // Add shift activity to timestamp grid
                                string startTime = ((TimeSpan)reader["shift_start"]).ToString(@"hh\:mm"); //Convert.ToString(reader["shift_start"]).ToString(@"hh\:mm");
                                timestampGrid.Rows.Add("Shift", startTime, "", "9 hrs");

                                // Add other activities to timestamp grid
                                foreach (var activity in GetActivityColumns())
                                {
                                    string activityName = activity.Key;
                                    string startColumnName = activity.Value + "_start";
                                    string endColumnName = activity.Value + "_end";

                                    if (reader[startColumnName] != DBNull.Value)
                                    {
                                        // Use TimeSpan.ToString for TimeSpan values
                                        string start = ((TimeSpan)reader[startColumnName]).ToString(@"hh\:mm");
                                        string end = reader[endColumnName] != DBNull.Value ? ((TimeSpan)reader[endColumnName]).ToString(@"hh\:mm") : "";
                                        

                                        timestampGrid.Rows.Add(activityName, start, end, GetLimitString(activityName));
                                        if (end != "")
                                        {
                                            UpdateDurationAndRemarks(activityName, start, end, GetLimitString(activityName));
                                        }

                                    }
                                }

                                string currentActivity = Convert.ToString(reader["current_activity"]);
                                if (!string.IsNullOrEmpty(currentActivity))
                                {
                                    activeButton = true;
                                    lastClickedButton = panel3.Controls["btn" + currentActivity] as Guna.UI.WinForms.GunaAdvenceTileButton;

                                    ActivateButton(currentActivity);
                                }

                                return null;
                            }
                        }
                    }
                }
            }

            return null; // No clock-out status issue
        }

        private void ActivateButton(string activity)
        {
            // Disable other buttons
            activity = char.ToUpper(activity[0]) + activity.Substring(1).ToLower();


            foreach (Control control in panel3.Controls)
            {
                if (control is Guna.UI.WinForms.GunaAdvenceTileButton button)
                {
                    if (button.Name == "btn" + activity)
                    {
                        // Activate the button corresponding to the current activity
                        button.BaseColor = Color.DarkRed;
                        button.Image = Properties.Resources.icons8_stop_50;
                        lastClickedButton = button;
                        button.Enabled = true;
                        
                    }
                    else
                    {
                        button.Enabled = false;
                    }
                }
                else if (control is Label label)
                {
                    if (label.Name == "lbl" + activity)
                    {
                        label.Enabled = true;
                        label.ForeColor = Color.WhiteSmoke;
                        label.BackColor = Color.DarkRed;
                    }
                    else
                    {
                        label.Enabled = false;
                        label.BackColor = disabledColor;
                    }

                }
            }
            lblStartEnd.BackColor = Color.FromArgb(127, 37, 37);
            lblStartEnd.ForeColor = Color.WhiteSmoke;
        }

        private void UpdateDurationAndRemarks(string activity, string startTime, string endTime, string limit)
        {
            int activityRowIndex = GetRowIndex(activity);
            if (activityRowIndex >= 0)
            {
                timestampGrid.Rows[activityRowIndex].Cells["EndTime"].Value = endTime;

                // Set flags to true if there is an end time
                switch (activity)
                {
                    case "Break 1":
                        break1 = endTime != "";
                        break;
                    case "Lunch":
                        lunch = endTime != "";
                        break;
                    case "Break 2":
                        break2 = endTime != "";
                        break;
                    case "Bio Break":
                        bio = endTime != "";
                        break;
                    case "Overtime":
                        overtime = endTime != "";
                        break;
                    case "Unscheduled Break":
                        unsch = endTime != "";
                        break;
                    case "Pull Out":
                        pullout = endTime != "";
                        break;
                    default:
                        break;
                }

                // Calculate duration
                DateTime startTimeDT = DateTime.ParseExact(startTime, "HH:mm", CultureInfo.InvariantCulture);
                DateTime endTimeDT = DateTime.ParseExact(endTime, "HH:mm", CultureInfo.InvariantCulture);
                TimeSpan duration = endTimeDT - startTimeDT;
                string durationStr = duration.ToString("hh\\:mm");
                timestampGrid.Rows[activityRowIndex].Cells["Duration"].Value = durationStr;

                // Calculate remarks
                TimeSpan limitTime = TimeSpan.Zero;
                if (limit != "N/A")
                {
                    limitTime = TimeSpan.FromMinutes(double.Parse(limit.Split(' ')[0])); // Assuming the limit format is "X mins"
                }

                if (activity == "Shift")
                {
                    limitTime = TimeSpan.FromHours(9);
                }

                if (duration < limitTime)
                {
                    TimeSpan undertime = limitTime - duration;
                    string undertimeStr = undertime.ToString(@"hh\:mm");
                    timestampGrid.Rows[activityRowIndex].Cells["Remarks"].Value = $"Undertime: {undertimeStr}";
                }
                else if (limitTime < duration)
                {
                    TimeSpan overtime = duration - limitTime;
                    string overtimeStr = overtime.ToString(@"hh\:mm");
                    timestampGrid.Rows[activityRowIndex].Cells["Remarks"].Value = $"Overtime: {overtimeStr}";
                }
                else
                {
                    timestampGrid.Rows[activityRowIndex].Cells["Remarks"].Value = "On Time";
                }
            }
        }

        private Dictionary<string, string> GetActivityColumns()
        {
            // Define the mapping between activity names and their corresponding columns
            return new Dictionary<string, string>
    {
        {"Break 1", "break1"},
        {"Lunch", "lunch"},
        {"Break 2", "break2"},
        {"Bio Break", "biobreak"},
        {"Overtime", "overtime"},
        {"Unscheduled Break", "unscheduled"},
        {"Pull Out", "pullout"}
    };
        }

        private string GetLimitString(string activityName)
        {
            // Define the limit for each activity
            Dictionary<string, string> activityLimits = new Dictionary<string, string>
    {
        {"Break 1", "15 mins"},
        {"Lunch", "60 mins"},
        {"Break 2", "15 mins"},
        {"Bio Break", "5 mins"},
        {"Overtime", "4 hrs"},
        {"Unscheduled Break", "N/A"},
        {"Pull Out", "30 mins"}
    };

            return activityLimits.ContainsKey(activityName) ? activityLimits[activityName] : "";
        }

        private void btnBreak1_Click(object sender, EventArgs e)
        {
            if (break1)
            {
                MessageBox.Show("You already taken that activity. Please choose another. For assistance, reach out to your supervisor.", "Toggle Activity");
                activeButton = false;
                return;
            }

            if (!activeButton) ActivityButton_Click(sender, e, "Break1", TimeSpan.FromMinutes(15), "15 mins");
            else
            {
                EndActivityButton_Click(sender, e, "Break1", TimeSpan.FromMinutes(15));
                break1 = true;
            }

            if (activeButton)
            {
                activeButton = false;
            }
            else
            {
                activeButton = true;
            }
        }

        private void Clock_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        private void panelDesktopPane_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTimeCard_Click(object sender, EventArgs e)
        {

            Form childForm = new ClockTimeCard();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            this.panelDesktopPane.Visible = true;
            this.panelDesktopPane.BringToFront();
            childForm.BringToFront();
            childForm.Show();

            btnClose.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            panelDesktopPane.Visible = false;
            panelDesktopPane.SendToBack();

            btnClose.Visible = false;
        }

        private void btnLunch_Click(object sender, EventArgs e)
        {
            if (lunch)
            {
                MessageBox.Show("You already taken that activity. Please choose another. For assistance, reach out to your supervisor.", "Toggle Activity");
                activeButton = false;
                return;
            }

            if (!activeButton) ActivityButton_Click(sender, e, "Lunch", TimeSpan.FromMinutes(60), "60 mins");
            else
            {
                EndActivityButton_Click(sender, e, "Lunch", TimeSpan.FromMinutes(60));
                lunch = true;
            }

            if (activeButton)
            {
                activeButton = false;
            }
            else
            {
                activeButton = true;
            }
        }

        private void btnBreak2_Click(object sender, EventArgs e)
        {
            if (break2)
            {
                MessageBox.Show("You already taken that activity. Please choose another. For assistance, reach out to your supervisor.", "Toggle Activity");
                activeButton = false;
                return;
            }

            if (!activeButton) ActivityButton_Click(sender, e, "Break2", TimeSpan.FromMinutes(15), "15 mins");
            else
            {
                EndActivityButton_Click(sender, e, "Break2", TimeSpan.FromMinutes(15));
                break2 = true;
            }

            if (activeButton)
            {
                activeButton = false;
            }
            else
            {
                activeButton = true;
            }
        }

        private void btnBio_Click(object sender, EventArgs e)
        {
            if (bio)
            {
                MessageBox.Show("You've already taken that activity today. Please choose another activity. For assistance, reach out to your supervisor.", "Toggle Activity");
                activeButton = false;
                return;
            }

            if (!activeButton) ActivityButton_Click(sender, e, "BioBreak", TimeSpan.FromMinutes(5), "5 mins");
            else
            {
                EndActivityButton_Click(sender, e, "BioBreak", TimeSpan.FromMinutes(5));
                bio = true;
            }

            if (activeButton)
            {
                activeButton = false;
            }
            else
            {
                activeButton = true;
            }
        }


        private void btnOvertime_Click(object sender, EventArgs e)
        {
            if (overtime)
            {
                MessageBox.Show("You already taken that activity. Please choose another. For assistance, reach out to your supervisor.", "Toggle Activity");
                activeButton = false;
                return;
            }

            if (!activeButton) ActivityButton_Click(sender, e, "Overtime", TimeSpan.FromMinutes(1), "4 hrs");
            else
            {
                EndActivityButton_Click(sender, e, "Overtime", TimeSpan.FromMinutes(1));
                overtime = true;
            }

            if (activeButton)
            {
                activeButton = false;
            }
            else
            {
                activeButton = true;
            }
        }

        private void btnUnscheduled_Click(object sender, EventArgs e)
        {
            if (unsch)
            {
                MessageBox.Show("You already taken that activity. Please choose another. For assistance, reach out to your supervisor.", "Toggle Activity");
                activeButton = false;
                return;
            }

            if (!activeButton) ActivityButton_Click(sender, e, "Unscheduled", TimeSpan.FromMinutes(1), "N/A");
            else
            {
                EndActivityButton_Click(sender, e, "Unscheduled", TimeSpan.FromMinutes(240));
                unsch = true;
            }

            if (activeButton)
            {
                activeButton = false;
            }
            else
            {
                activeButton = true;
            }
        }

        private void btnPullout_Click(object sender, EventArgs e)
        {
            if (pullout)
            {
                MessageBox.Show("You already taken that activity. Please choose another. For assistance, reach out to your supervisor.", "Toggle Activity");
                activeButton = false;
                return;
            }

            if (!activeButton) ActivityButton_Click(sender, e, "PullOut", TimeSpan.FromMinutes(30), "30 mins");
            else
            {
                EndActivityButton_Click(sender, e, "PullOut", TimeSpan.FromMinutes(30));
                pullout = true;
            }

            if (activeButton)
            {
                activeButton = false;
            }
            else
            {
                activeButton = true;
            }
        }
    }
}
