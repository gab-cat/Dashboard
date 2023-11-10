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

namespace Dashboard
{
    public partial class Clock : Form
    {
        private Guna.UI.WinForms.GunaAdvenceTileButton lastClickedButton = null;
        private bool clockedIn = false;
        private bool activeButton = false;
        private bool break1, lunch, break2, bio, overtime, unsch, pullout= false;

        private Color defaultColor = Color.FromArgb(51, 51, 76);
        private Color disabledColor = Color.FromArgb(70, 70, 86);



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
                    label.Font = new Font("Outfit Thin Light", 9.749999f, FontStyle.Regular);
                    label.ForeColor = Color.Gray;
                }
            }

            // Highlight the font for the current day
            Label highlightedLabel = Controls.Find("lbl" + currentDayOfWeek, true).FirstOrDefault() as Label;
            if (highlightedLabel != null)
            {
                highlightedLabel.Font = new Font("Outfit Thin", 9.749999f, FontStyle.Bold);
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
            if (!clockedIn)
            {
                timestampGrid.Rows.Clear();

                string startTime = DateTime.Now.ToString("HH:mm");
                timestampGrid.Rows.Add("Shift", startTime, "", "9 hrs");

                clockedIn = true;
                enableButtons();
                btnStartEnd.BaseColor = Color.DarkRed;
                btnStartEnd.Image = Properties.Resources.icons8_stop_50;
                // lblStartEnd.BackColor = Color.DarkRed;
                btnStartEnd.Text = "End Shift";
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
            }
            else
            {
                button.BaseColor = Color.DarkRed;
                label.BackColor = Color.DarkRed;
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
                button.Image = Properties.Resources.icons8_stop_50;
                button.Enabled = true; // Enable the previously clicked button
                label.Enabled = true;
                label.ForeColor = SystemColors.AppWorkspace;
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



        private void btnBreak1_Click(object sender, EventArgs e)
        {
            if (break1)
            {
                MessageBox.Show("You already taken that activity. Please choose another. For assistance, reach out to your supervisor.", "Toggle Activity");
                activeButton = false;
                return;
            }

            if (!activeButton) ActivityButton_Click(sender, e, "Break 1", TimeSpan.FromMinutes(15), "15 mins");
            else
            {
                EndActivityButton_Click(sender, e, "Break 1", TimeSpan.FromMinutes(15));
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

            if (!activeButton) ActivityButton_Click(sender, e, "Break 2", TimeSpan.FromMinutes(15), "15 mins");
            else
            {
                EndActivityButton_Click(sender, e, "Break 2", TimeSpan.FromMinutes(15));
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

            if (!activeButton) ActivityButton_Click(sender, e, "Bio Break", TimeSpan.FromMinutes(5), "5 mins");
            else
            {
                EndActivityButton_Click(sender, e, "Bio Break", TimeSpan.FromMinutes(5));
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

            if (!activeButton) ActivityButton_Click(sender, e, "Overtime", TimeSpan.FromMinutes(240), "4 hrs");
            else
            {
                EndActivityButton_Click(sender, e, "Overtime", TimeSpan.FromMinutes(240));
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

            if (!activeButton) ActivityButton_Click(sender, e, "Unscheduled Break", TimeSpan.FromMinutes(1), "N/A");
            else
            {
                EndActivityButton_Click(sender, e, "Unscheduled Break", TimeSpan.FromMinutes(240));
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

            if (!activeButton) ActivityButton_Click(sender, e, "Pull Out", TimeSpan.FromMinutes(30), "30 mins");
            else
            {
                EndActivityButton_Click(sender, e, "Pull Out", TimeSpan.FromMinutes(30));
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
