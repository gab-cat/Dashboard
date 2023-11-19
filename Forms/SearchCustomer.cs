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
    public partial class SearchCustomer : Form
    {

        public int SelectedCustomerId { get; private set; }
        private string employee_name;
        private MySqlConnection connection;
        public SearchCustomer(string EmployeeName, MySqlConnection connection)
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
            employee_name = EmployeeName;
            this.connection = connection;
            textBox1.Focus();
        }

        private void DisplayCustomers()
        {

            using (connection)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                try
                {

                    string query = "SELECT customer_id, first_name, last_name, contact_email, contact_phone, address FROM customers";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = dataTable;
                            dataGridView1.DataSource = bindingSource;
                        }
                    }


                    ConfigureDataGridViewColumns();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void SearchCustomer_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            searchCX();
        }

        private void searchCX()
        {
            try
            {
                using (connection)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    string selectedFilter = comboBox1.SelectedItem.ToString();
                    string searchKeyword = textBox1.Text.Trim();

                    if (string.IsNullOrWhiteSpace(searchKeyword))
                    {
                        MessageBox.Show("Please enter a search keyword.", "Empty Search Box", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string query = "";

                    switch (selectedFilter)
                    {
                        case "First Name":
                            query = "SELECT customer_id, first_name, last_name, contact_email, contact_phone, address FROM customers WHERE first_name LIKE @Keyword";
                            break;

                        case "Last Name":
                            query = "SELECT customer_id, first_name, last_name, contact_email, contact_phone, address FROM customers WHERE last_name LIKE @Keyword";
                            break;

                        case "Customer ID":
                            query = "SELECT customer_id, first_name, last_name, contact_email, contact_phone, address FROM customers WHERE customer_id LIKE @Keyword";
                            break;

                        case "Phone Number":
                            query = "SELECT customer_id, first_name, last_name, contact_email, contact_phone, address FROM customers WHERE contact_phone LIKE @Keyword";
                            break;

                        case "Email Address":
                            query = "SELECT customer_id, first_name, last_name, contact_email, contact_phone, address FROM customers WHERE contact_email LIKE @Keyword";
                            break;

                        case "Address":
                            query = "SELECT customer_id, first_name, last_name, contact_email, contact_phone, address FROM customers WHERE address LIKE @Keyword";
                            break;

                        default:
                            MessageBox.Show("Invalid filter criteria selected.");
                            return;
                    }

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Keyword", "%" + searchKeyword + "%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = dataTable;
                            dataGridView1.DataSource = bindingSource;
                        }
                    }
                }

                ConfigureDataGridViewColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void ConfigureDataGridViewColumns()
        {
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns["customer_id"].Width = 40;
            dataGridView1.Columns["first_name"].Width = 100;
            dataGridView1.Columns["last_name"].Width = 100;
            dataGridView1.Columns["contact_email"].Width = 150;
            dataGridView1.Columns["contact_phone"].Width = 100;
            dataGridView1.Columns["address"].Width = 200;

            dataGridView1.Columns["customer_id"].HeaderText = "ID";
            dataGridView1.Columns["first_name"].HeaderText = "First Name";
            dataGridView1.Columns["last_name"].HeaderText = "Last Name";
            dataGridView1.Columns["contact_email"].HeaderText = "Email Address";
            dataGridView1.Columns["contact_phone"].HeaderText = "Phone Number";
            dataGridView1.Columns["address"].HeaderText = "Address";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchCX();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisplayCustomers();
            comboBox1.SelectedIndex = 0;
            textBox1.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            NewCustomer newcx = new NewCustomer(employee_name, connection);
            newcx.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow.Cells["customer_id"].Value != null)
                {
                    SelectedCustomerId = Convert.ToInt32(selectedRow.Cells["customer_id"].Value);

                }
            }
            else
            {
                SelectedCustomerId = -1; // No customer selected
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                SelectedCustomerId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                this.DialogResult = DialogResult.OK; 
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == -1)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                Rectangle buttonRect = new Rectangle(
                    e.CellBounds.X + e.CellBounds.Width - 22,
                    e.CellBounds.Y + 2,
                    20,
                    e.CellBounds.Height - 4
                );

                ControlPaint.DrawButton(e.Graphics, buttonRect, ButtonState.Normal);
                TextRenderer.DrawText(
                    e.Graphics,
                    "Your Button Text",
                    e.CellStyle.Font,
                    buttonRect,
                    e.CellStyle.ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchCX();
                e.SuppressKeyPress = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }
    }
}
