using Dashboard.Forms;
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
    public partial class MtnMemoView : Form
    {
        private DataTable memoDataTable;
        private string employee_name;
        public MtnMemoView(string employee_name)
        {
            InitializeComponent();
            this.employee_name = employee_name;
        }

        private void MtnMemoView_Load(object sender, EventArgs e)
        {
            MemoGrid.ColumnHeadersDefaultCellStyle.BackColor = ThemeColor.SecondaryColor;
            MemoGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            MemoGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            MemoGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;

            loadMemos();
        }

        private void loadMemos()
        {
            int customerId = 9998;
            memoDataTable = new DataTable();
            memoDataTable.Columns.Add("time_date", typeof(DateTime));
            memoDataTable.Columns.Add("reason", typeof(string));
            memoDataTable.Columns.Add("employee_name", typeof(string));
            memoDataTable.Columns.Add("memo_text", typeof(string)); // Add "memo_text" column

            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    string query = "SELECT time_date, reason, employee_name, memo_text FROM memos WHERE customer_id = @customer_id ORDER BY time_date DESC;";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customer_id", customerId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Extract memo details here.
                                DateTime timeDate = reader.GetDateTime("time_date");
                                string reason = reader.GetString("reason");
                                string employeeName = reader.GetString("employee_name");
                                string memoText = reader.GetString("memo_text");

                                // Add a new row to the DataTable
                                memoDataTable.Rows.Add(timeDate, reason, employeeName, memoText);
                            }
                        }
                    }

                    // Bind the DataTable to the DataGridView
                    MemoGrid.DataSource = memoDataTable;

                    // Optionally, set column headers
                    MemoGrid.Columns["time_date"].HeaderText = "Date and Time";
                    MemoGrid.Columns["reason"].HeaderText = "Reason";
                    MemoGrid.Columns["employee_name"].HeaderText = "Employee Name";
                    if (MemoGrid.Columns.Contains("memo_text"))
                    {
                        MemoGrid.Columns["memo_text"].Visible = false;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void MemoGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (MemoGrid.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = MemoGrid.SelectedRows[0];
                object selectedTimeDate = selectedRow.Cells["time_date"].Value;
                object selectedReason = selectedRow.Cells["reason"].Value;
                object selectedEmployeeName = selectedRow.Cells["employee_name"].Value;

                // Find the corresponding row in the memoDataTable based on time_date, reason, and employee_name
                DataRow selectedMemoRow = memoDataTable.AsEnumerable()
                    .FirstOrDefault(row =>
                        row.Field<DateTime>("time_date") == (DateTime)selectedTimeDate &&
                        row.Field<string>("reason") == (string)selectedReason &&
                        row.Field<string>("employee_name") == (string)selectedEmployeeName);

                if (selectedMemoRow != null)
                {
                    string selectedMemoText = selectedMemoRow.Field<string>("memo_text");
                    txtMemo.Text = selectedMemoText;
                }
                else
                {
                    txtMemo.Text = "No memo text available for this row.";
                }
            }
        }

        private void btnAddInvMemo_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                MaintenanceMemo addmemo = new MaintenanceMemo(employee_name);
                addmemo.Show();
            });
        }
    }
}
