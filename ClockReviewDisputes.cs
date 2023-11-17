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
    public partial class ClockReviewDisputes : Form
    {
        private MySqlConnection connection;
        private string username;
        private Font boldFont = new Font("Outfit Thin SemiBold", 10f, FontStyle.Bold);
        public ClockReviewDisputes(MySqlConnection connection, string username)
        {
            InitializeComponent();
            this.connection = connection;
            this.username = username;

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

                string selectQuery = "SELECT cd.request_time AS 'Time Date', cd.dispute_id AS 'Dispute ID', " +
                                     "cd.dispute_status AS 'Status', CONCAT(l.first_name, ' ', l.last_name) AS 'Employee Name' " +
                                     "FROM clock_disputes cd " +
                                     "INNER JOIN logins l ON cd.username = l.username " +
                                     "WHERE cd.direct_supervisor = @directSupervisor " +
                                     "ORDER BY cd.request_time DESC";

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@directSupervisor", username); // Use direct_supervisor instead of username
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
                    dataGridView.Columns["Dispute ID"].Width = 70;
                    dataGridView.Columns["Employee Name"].Width = 140;
                    dataGridView.Columns["Status"].Width = 90;
                    dataGridView.Columns["Review"].Width = 50;

                    dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
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
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView.Columns["Review"].Index) // Assuming "Review" is the button column
            {
                // Get the dispute_id from the selected row
                int disputeId = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["Dispute ID"].Value);

                // Pass the dispute_id to the ClockViewDispute form
                ClockViewDispute viewDisputeForm = new ClockViewDispute(connection, disputeId, username, true);
                viewDisputeForm.ShowDialog(); // Show the ClockViewDispute form with the selected dispute_id

                LoadDisputes();
            }
        }
    }
}
