using Dashboard.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard.CollectionFolder
{
    public partial class ServerConnections : Form
    {
        private string employee_name;
        public ServerConnections(string employee_name)
        {
            InitializeComponent();
            this.employee_name = employee_name;
            LoadActiveProcesses();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadActiveProcesses()
        {
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                string query = "SHOW PROCESSLIST"; // MySQL command to show active processes

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable processTable = new DataTable();
                        adapter.Fill(processTable);

                        // Bind the DataTable to the DataGridView
                        ConnectionsGrid.DataSource = processTable;
                    }
                }
            }
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the ConnectionsGrid
            if (ConnectionsGrid.SelectedRows.Count > 0)
            {
                // Get the process ID from the selected row
                int processId = Convert.ToInt32(ConnectionsGrid.SelectedRows[0].Cells["Id"].Value);

                using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
                {
                    string query = "KILL " + processId; // MySQL command to kill a process by ID

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        try
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                                string memo = $"Killed Process ID: {processId}{Environment.NewLine}{Environment.NewLine}Time: {DateTime.Now}{Environment.NewLine}Requested By: {employee_name}";
                                MaintenanceMemo newmemo = new MaintenanceMemo("Server Connections Manager", "Kill Session", memo, 1);
                                newmemo.Hide();
                                LoadActiveProcesses();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while killing the process: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a process to kill.", "No Process Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void KillProcessById(int processId)
        {
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                string query = "KILL " + processId; // MySQL command to kill a process by ID

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors or exceptions here
                    }
                }
            }
        }

        private void btnKillAll_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                string query = "SHOW PROCESSLIST"; // MySQL command to show active processes

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable processTable = new DataTable();
                        adapter.Fill(processTable);
                        string allProcessID = "";

                        foreach (DataRow row in processTable.Rows)
                        {
                            int processId = Convert.ToInt32(row["Id"]);
                            allProcessID = allProcessID + processId.ToString() + ", ";
                            // Kill each process by its ID
                            KillProcessById(processId);
                        }

                        // Refresh the active processes grid view
                        string memo = $"Killed all active process IDs: {allProcessID}{Environment.NewLine}{Environment.NewLine}Time: {DateTime.Now}{Environment.NewLine}Requested By: {employee_name}";
                        MaintenanceMemo newmemo = new MaintenanceMemo("Server Connections Manager", "Kill Session", memo, 1);

                        LoadActiveProcesses();
                    }
                }
            }

            MessageBox.Show("All active processes have been killed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
