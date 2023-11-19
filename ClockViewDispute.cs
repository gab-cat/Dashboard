using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class ClockViewDispute : Form
    {
        private MySqlConnection connection;
        private int dispute_id;
        private string username;
        private bool managerView;

        private string columnName;
        private DateTime requestedDate;
        private DateTime requestedTime;


        public ClockViewDispute(MySqlConnection connection, int dispute_id, string username, bool managerView)
        {
            InitializeComponent();
            this.connection = connection;
            this.dispute_id = dispute_id;
            this.username = username;
            this.managerView = managerView;
            this.Text = $"Dispute Request : {dispute_id}";

            btnApprove.Visible = false;
            btnDeny.Visible = false;

            LoadDisputeData();
        }

        private void ClockViewDispute_Load(object sender, EventArgs e)
        {

        }

        private void LoadDisputeData()
        {
            string query = "SELECT dispute_id, request_time, username, direct_supervisor, read_status, " +
                           "activity, original_time, requested_time, requested_date, start_end, " +
                           "reason, response, UPPER(dispute_status) AS dispute_status FROM clock_disputes " +
                           "WHERE dispute_id = @disputeId";

            using (connection)
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    command.Parameters.AddWithValue("@disputeId", dispute_id);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Assigning data from the database to textboxes
                            txtDispute_id.Text = reader["dispute_id"].ToString();
                            txtRequestDate.Text = reader["request_time"].ToString();
                            txtEmpID.Text = reader["username"].ToString();
                            txtSupID.Text = reader["direct_supervisor"].ToString();

                            this.columnName = reader["activity"].ToString() + reader["start_end"].ToString();


                            string activity = reader["activity"].ToString();
                            if (!string.IsNullOrEmpty(activity))
                            {
                                activity = char.ToUpper(activity[0]) + activity.Substring(1);
                            }

                            string startEnd = reader["start_end"].ToString().Replace("_", "");
                            if (!string.IsNullOrEmpty(startEnd))
                            {
                                startEnd = char.ToUpper(startEnd[0]) + startEnd.Substring(1);
                            }

                            txtActivity.Text = activity + " - " + startEnd;


                            txtOrigTime.Text = reader["original_time"].ToString().Substring(0, 5);

                            txtReqDate.Text = reader["requested_date"].ToString().Substring(0, 10);
                            txtReqTime.Text = reader["requested_time"].ToString().Substring(0, 5);

                            txtReason.Text = reader["reason"].ToString();
                            txtResponse.Text = reader["response"].ToString();
                            txtStatus.Text = reader["dispute_status"].ToString();

                            

                            if (txtStatus.Text == "DENIED")
                            {
                                txtStatus.ForeColor = Color.DarkRed;
                                txtResponse.ReadOnly = true;
                                txtReason.ReadOnly = true;

                            }
                            else if (txtStatus.Text == "APPROVED")
                            {
                                txtStatus.ForeColor = Color.DarkGreen;
                                txtResponse.ReadOnly = true;
                                txtReason.ReadOnly = true;
                            }
                            else if (txtStatus.Text == "PENDING")
                            {
                                if (managerView)
                                {
                                    btnApprove.Visible = true;
                                    btnDeny.Visible = true;
                                    txtStatus.Visible = false;

                                    txtResponse.ReadOnly = false;
                                    txtResponse.BackColor = SystemColors.Info;
                                    txtResponse.TabStop = true;
                                    txtResponse.Focus();
                                }
                            }
                        }
                    }
                }
            }

            (string employeeName, string supervisorName) = GetNames(username, txtSupID.Text);

            // Assign retrieved names to text boxes
            txtEmpName.Text = employeeName;
            txtSupName.Text = supervisorName;
        }

        private (string, string) GetNames(string username, string supervisor_username)
        {
            string employee_name = string.Empty;
            string supervisor_name = string.Empty;

            try
            {
                using (connection)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    string selectSupervisorNameQuery = "SELECT CONCAT(first_name, ' ', last_name) AS supervisor_name FROM logins WHERE username = @supervisor";

                    using (MySqlCommand cmdSupervisorName = new MySqlCommand(selectSupervisorNameQuery, connection))
                    {
                        cmdSupervisorName.Parameters.AddWithValue("@supervisor", supervisor_username);

                        object supervisorNameResult = cmdSupervisorName.ExecuteScalar();

                        if (supervisorNameResult != null)
                        {
                            supervisor_name = supervisorNameResult.ToString();
                        }
                    }
                    

                    // Query to get employee's name
                    string selectEmployeeNameQuery = "SELECT CONCAT(first_name, ' ', last_name) AS employee_name FROM logins WHERE username = @username";

                    using (MySqlCommand cmdEmployeeName = new MySqlCommand(selectEmployeeNameQuery, connection))
                    {
                        cmdEmployeeName.Parameters.AddWithValue("@username", username);

                        object employeeNameResult = cmdEmployeeName.ExecuteScalar();

                        if (employeeNameResult != null)
                        {
                            employee_name = employeeNameResult.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return (employee_name, supervisor_name);
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtResponse.Text.Trim())) 
            {
                MessageBox.Show("Please input the your response.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            UpdateDisputeStatusToDenied("DENIED");
        }

        private void UpdateDisputeStatusToDenied(string decision)
        {

            string response = $"SOLUTION: {DateTime.Now}{Environment.NewLine}Hello team, {Environment.NewLine}{Environment.NewLine}" +
                $"I hope this message finds you well. This request is hereby {decision}.The changes will reflect in your time card shortly. {Environment.NewLine}{Environment.NewLine}" +
                $"{txtResponse.Text}{Environment.NewLine}{Environment.NewLine}" +
                $"This request is closed.Do not reply, instead create another request. Please reach out as well to your team lead for assistance";

            string disputeID = dispute_id.ToString();

            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                MySqlTransaction transaction = null;

                string updateQuery = "UPDATE clock_disputes " +
                                        "SET dispute_status = 'Denied', read_status = 0, response = @response " +
                                        "WHERE dispute_id = @disputeID";
                try
                {
                    transaction = connection.BeginTransaction();

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@disputeID", disputeID);
                        cmd.Parameters.AddWithValue("@response", response);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            transaction.Commit();
                            txtStatus.Visible = true;
                            txtStatus.Text = "DENIED";
                            txtStatus.ForeColor = Color.DarkRed;

                            btnDeny.Visible = false;
                            btnApprove.Visible = false;
                            txtResponse.BackColor = SystemColors.ButtonFace;

                            txtResponse.Text = response;
                            txtResponse.TabStop = false;
                            txtResponse.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update dispute status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtResponse.Text.Trim()))
            {
                MessageBox.Show("Please input your response.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update dispute status to 'APPROVED' and process the approval
            UpdateDisputeStatusToApproved("APPROVED");
        }

        private void UpdateDisputeStatusToApproved(string decision)
        {
            string response = $"SOLUTION: {DateTime.Now}{Environment.NewLine}Hello team, {Environment.NewLine}{Environment.NewLine}" +
                $"I hope this message finds you well. This request is hereby {decision}. The changes will reflect in your time card shortly. {Environment.NewLine}{Environment.NewLine}" +
                $"{txtResponse.Text}{Environment.NewLine}{Environment.NewLine}" +
                $"This request is closed. Do not reply, instead create another request. Please reach out as well to your team lead for assistance";

            string disputeID = dispute_id.ToString();

            // Process approval in clockIns table
            if (!ProcessApprovalInClockIns(dispute_id))
            {
                return;
            }

            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                MySqlTransaction transaction = null;

                string updateQuery = "UPDATE clock_disputes " +
                                     "SET dispute_status = 'Approved', read_status = 0, response = @response " +
                                     "WHERE dispute_id = @disputeID";
                try
                {
                    transaction = connection.BeginTransaction();

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@disputeID", disputeID);
                        cmd.Parameters.AddWithValue("@response", response);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            transaction.Commit();
                            txtStatus.Visible = true;
                            txtStatus.Text = "APPROVED";
                            txtStatus.ForeColor = Color.DarkGreen;

                            btnDeny.Visible = false;
                            btnApprove.Visible = false;
                            txtResponse.BackColor = SystemColors.ButtonFace;

                            txtResponse.Text = response;
                            txtResponse.TabStop = false;
                            txtResponse.Focus();


                        }
                        else
                        {
                            MessageBox.Show("Failed to update dispute status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ProcessApprovalInClockIns(int disputeId)
        {
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                MySqlTransaction transaction = null;

                string getActivityQuery = "SELECT CONCAT(activity, start_end) AS columnName FROM clock_disputes WHERE dispute_id = @disputeId";

                try
                {
                    transaction = connection.BeginTransaction();

                    using (MySqlCommand getActivityCmd = new MySqlCommand(getActivityQuery, connection))
                    {
                        getActivityCmd.Parameters.AddWithValue("@disputeId", disputeId);

                        string columnName = getActivityCmd.ExecuteScalar()?.ToString();

                        if (columnName != null)
                        {
                            string updateClockInsQuery =
                                "UPDATE clockIns AS ci " +
                                $"INNER JOIN clock_disputes AS cd ON ci.username = cd.username AND ci.clockIn_date = cd.requested_date " +
                                $"SET ci.{columnName} = cd.requested_time " +
                                $"WHERE ci.username = @username AND cd.dispute_id = @disputeId";

                            using (MySqlCommand cmd = new MySqlCommand(updateClockInsQuery, connection))
                            {
                                cmd.Parameters.AddWithValue("@username", txtEmpID.Text);
                                cmd.Parameters.AddWithValue("@disputeId", disputeId);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    transaction.Commit();
                                    MessageBox.Show("Dispute is approved and requested time stamp is updated accordingly.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return true;
                                }
                                else
                                {
                                    transaction?.Rollback();
                                    MessageBox.Show($"Failed to update ClockIns table. {columnName} {txtEmpID} {disputeId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            transaction?.Rollback();
                            MessageBox.Show("Failed to retrieve column name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}

