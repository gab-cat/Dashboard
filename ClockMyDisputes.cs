using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class ClockMyDisputes : Form
    {
        private MySqlConnection connection;
        private string username;
        private Font defaultFont = new Font("Outfit Thin", 9f);
        private Font boldRow = new Font("Outfit Thin SemiBold", 10f, FontStyle.Bold);
        private Font boldFont = new Font("Outfit Thin SemiBold", 10f, FontStyle.Bold);

        public ClockMyDisputes(MySqlConnection connection, string username)
        {
            InitializeComponent();
            this.username = username;
            this.connection = connection;

            dataGridView.Columns.Clear();
            LoadDisputes();
        }

        private void LoadDisputes()
        {
            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string selectQuery = "SELECT request_time AS 'Time Date', dispute_id AS 'Dispute ID', " +
                                     "dispute_status AS 'Status', UPPER(activity) AS 'Activity', read_status " +
                                     "FROM clock_disputes WHERE username = @username ORDER BY request_time DESC";

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    dataGridView.Columns.Clear();

                    adapter.Fill(dataTable);

                    // Display the data in the DataGridView
                    dataGridView.DataSource = dataTable;

                    // Add a button column (Review)
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
                    {
                        Text = "View",
                        UseColumnTextForButtonValue = true,
                        HeaderText = "Review",
                        Name = "Review"
                    };

                    buttonColumn.DefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
                    buttonColumn.DefaultCellStyle.ForeColor = Color.White;
                    buttonColumn.FlatStyle = FlatStyle.Flat;
                    buttonColumn.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
                    buttonColumn.FillWeight = 5;

                    // Add button column to the DataGridView
                    dataGridView.Columns.Add(buttonColumn);

                    dataGridView.Columns["Time Date"].Width = 130;
                    dataGridView.Columns["Activity"].Width = 90;
                    dataGridView.Columns["Review"].Width = 60;

                    dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    // Hide the read_status column
                    dataGridView.Columns["read_status"].Visible = false;

                    
                }
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            // Check read_status for applying font to the entire row
            if (e.RowIndex >= 0 && dataGridView.Columns["read_status"] != null)
            {
                object readStatusValue = dataGridView.Rows[e.RowIndex].Cells["read_status"].Value;

                if (readStatusValue != null && (bool)readStatusValue == false)
                {
                    dataGridView.Rows[e.RowIndex].DefaultCellStyle.Font = boldRow;
                }
                else
                {
                    dataGridView.Rows[e.RowIndex].DefaultCellStyle.Font = defaultFont;
                }
            }

            // Check if the current column is a button column
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewButtonCell buttonCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell;

                // Apply the desired style to the button cells
                buttonCell.Style.BackColor = Color.FromArgb(51, 51, 76);
                buttonCell.Style.ForeColor = Color.White;
                buttonCell.FlatStyle = FlatStyle.Flat;
                buttonCell.Style.Padding = new Padding(0, 0, 0, 0);
            }

            if (dataGridView.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString().ToUpper();

                if (status == "PENDING")
                {
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.DarkOrange;
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = boldFont;
                }
                else if (status == "APPROVED")
                {
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.DarkGreen;
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = boldFont;
                }
                else if (status == "DENIED")
                {
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.DarkRed;
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = boldFont;
                }

                e.Value = status; // Ensure it is always displayed in uppercase
            }

            dataGridView.Visible = true;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string status = dataGridView.Rows[e.RowIndex].Cells["Status"].Value.ToString().ToUpper();
            bool readStatus = Convert.ToBoolean(dataGridView.Rows[e.RowIndex].Cells["read_status"].Value);

            int disputeId = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["Dispute ID"].Value);

            if ((status == "APPROVED" || status == "DENIED") && readStatus == false)
            {

                using (connection)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    string updateReadStatusQuery = "UPDATE clock_disputes SET read_status = 1 WHERE dispute_id = @disputeID";

                    using (MySqlCommand cmd = new MySqlCommand(updateReadStatusQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@disputeID", disputeId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            ClockViewDispute viewDisputeForm = new ClockViewDispute(connection, disputeId, username, false);
                            viewDisputeForm.ShowDialog();

                            LoadDisputes();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update read status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                ClockViewDispute viewDisputeForm = new ClockViewDispute(connection, disputeId, username, false);
                viewDisputeForm.ShowDialog();

                LoadDisputes();
            }

            
        }
    }
}
