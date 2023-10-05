using Dashboard.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Dashboard
{
    public partial class Dashboard : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(
                                                              int nLeftRect,
                                                              int nTopRect,
                                                              int nRightRect,
                                                              int nBottomRect,
                                                              int nWidthEllipse,
                                                             int nHeightEllipse

                                                          );

        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public string username;
        public int customer_id;
        private string role;
        public Dashboard(string firstName, string lastName, string role)
        {
            
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            userData(firstName, lastName, role);
            dailySales(); charts(); criticalStock();
            username = firstName + " " + lastName;
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            label15.BringToFront();

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);



        private void userData(string firstName, string lastName, string role)
        {
            TimeDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            txt_Name.Text = firstName + " " + lastName;
            txt_Role.Text = role;
            this.role = role;
            if (role == "Cashier")
            {
                btnInventory.Visible = false;
                btnReport.Visible = false;
                btnMaintenance.Visible = false;
            }
        }

        private void dailySales()
        {
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {
                    string sqlQuery = "SELECT DATE_FORMAT(payment_date, '%m-%d') AS date, SUM(payment_amount) AS total_sales FROM payments WHERE payment_date BETWEEN DATE_SUB(CURDATE(), INTERVAL 6 DAY) AND CURDATE() GROUP BY DATE_FORMAT(payment_date, '%m-%d')";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    double averageSales = CalculateAverageSales(dataTable);

                    connection.Close();

                    chart1.Series.Clear();
                    chart1.Series.Add("TotalSales");
                    chart1.Series["TotalSales"].ChartType = SeriesChartType.Bar;

                    chart1.Series["TotalSales"].Points.DataBind(dataTable.DefaultView, "date", "total_sales", null);

                    chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

                    chart1.Legends.Clear();

                    foreach (DataPoint point in chart1.Series["TotalSales"].Points)
                    {
                        double sales = point.YValues[0];
                        string label = "₱" + sales.ToString("#,0");
                        point.Label = label;
                        point.Color = (sales < averageSales) ? System.Drawing.Color.Red : System.Drawing.Color.Green;
                    }

                    chart1.Invalidate();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (connection != null)
                    {
                        connection.Close();
                    }
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

        private double CalculateAverageSales(DataTable dataTable)
        {
            double averageSales = 0.0;

            if (dataTable.Rows.Count > 0)
            {
                var totalSalesColumn = dataTable.Columns["total_sales"];
                if (totalSalesColumn != null)
                {
                    Type dataType = totalSalesColumn.DataType;
                    if (dataType == typeof(double) || dataType == typeof(decimal) || dataType == typeof(float))
                    {
                        averageSales = dataTable.AsEnumerable().Average(row => Convert.ToDouble(row["total_sales"]));
                    }
                }
            }

            return averageSales;
        }

        private void charts()
        {
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {

                    DateTime currentDate = DateTime.Now;
                    int currentMonth = currentDate.Month;
                    int currentYear = currentDate.Year;

                    string formattedAmount = GetTotalRevenue(connection, currentMonth, currentYear);
                    if (!string.IsNullOrEmpty(formattedAmount))
                    {
                        txtRevenue.Text = formattedAmount;
                    }

                    int totalSalesCount = GetTotalSales(connection, currentMonth, currentYear);
                    txtSales.Text = totalSalesCount.ToString();

                    int totalCustomersCount = GetTotalCustomers(connection, currentMonth, currentYear);
                    if (totalCustomersCount > 0)
                    {
                        txtCustomer.Text = totalCustomersCount.ToString();
                    }
                    else
                    {
                        txtCustomer.Text = "No customers joined this month.";
                    }

                    int totalItemsSold = GetTotalItemsSold(connection, currentMonth, currentYear);
                    txtItem.Text = totalItemsSold.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private string GetTotalRevenue(MySqlConnection connection, int month, int year)
        {
            using (MySqlCommand command = new MySqlCommand("SELECT SUM(payment_amount) AS TotalPaymentAmount FROM payments WHERE MONTH(payment_date) = @Month AND YEAR(payment_date) = @Year", connection))
            {
                command.Parameters.AddWithValue("@Month", month);
                command.Parameters.AddWithValue("@Year", year);
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    double totalPaymentAmount = Convert.ToDouble(result);
                    return "₱ " + totalPaymentAmount.ToString("#,0");
                }

                return null;
            }
        }

        private int GetTotalSales(MySqlConnection connection, int month, int year)
        {
            using (MySqlCommand command = new MySqlCommand("SELECT COUNT(*) AS TotalSalesCount FROM sales WHERE MONTH(sale_date) = @Month AND YEAR(sale_date) = @Year", connection))
            {
                command.Parameters.AddWithValue("@Month", month);
                command.Parameters.AddWithValue("@Year", year);
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }

                return 0;
            }
        }

        private int GetTotalCustomers(MySqlConnection connection, int month, int year)
        {
            using (MySqlCommand command = new MySqlCommand("SELECT COUNT(*) AS TotalCustomersCount FROM customers WHERE MONTH(join_date) = @Month AND YEAR(join_date) = @Year", connection))
            {
                command.Parameters.AddWithValue("@Month", month);
                command.Parameters.AddWithValue("@Year", year);
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }

                return 0;
            }
        }

        private int GetTotalItemsSold(MySqlConnection connection, int month, int year)
        {
            using (MySqlCommand command = new MySqlCommand("SELECT SUM(quantity_sold) AS TotalItemsSold FROM sale_items WHERE MONTH(sale_date) = @Month AND YEAR(sale_date) = @Year", connection))
            {
                command.Parameters.AddWithValue("@Month", month);
                command.Parameters.AddWithValue("@Year", year);
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }

                return 0;
            }
        }

        private void criticalStock()
        {
            using (MySqlConnection connection = DatabaseHelper.GetOpenConnection())
            {
                try
                {

                    string query = "SELECT product_id, quantity_in_stock, product_name, category FROM products WHERE quantity_in_stock <= critical_quantity";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            BindingSource bindingSource = new BindingSource();
                            bindingSource.DataSource = dataTable;
                            guna2DataGridView1.DataSource = bindingSource;
                        }
                    }

                    CustomizeDataGridViewColumns();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CustomizeDataGridViewColumns()
        {
            guna2DataGridView1.Columns["product_id"].Width = 60;
            guna2DataGridView1.Columns["quantity_in_stock"].Width = 50;
            guna2DataGridView1.Columns["product_name"].Width = 270;
            guna2DataGridView1.Columns["category"].Width = 150;

            guna2DataGridView1.Columns["product_id"].HeaderText = "ID";
            guna2DataGridView1.Columns["quantity_in_stock"].HeaderText = "Qty";
            guna2DataGridView1.Columns["product_name"].HeaderText = "Product Name";
            guna2DataGridView1.Columns["category"].HeaderText = "Category";

            guna2DataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = guna2DataGridView1.ColumnHeadersDefaultCellStyle.BackColor;
        }


        private void gunaLabel11_Click(object sender, EventArgs e)
        {

        }

        private void gunaCircleProgressBar2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close(); // Close the form
                ShowLoadingForm(username);
                Login newlogin = new Login();

                newlogin.ShowDialog();
            }
        }

        private void ShowLoadingForm(string firstName)
        {
            LoadingForm loadingForm = new LoadingForm(firstName, 1);
            loadingForm.StartPosition = FormStartPosition.CenterScreen;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000;
            timer.Tick += (sender, e) =>
            {
                loadingForm.Close();
                timer.Stop();
            };
            timer.Start();

            loadingForm.ShowDialog();
        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // METHODS //

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;

                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Outfit Thin SemiBold", 12.5F, FontStyle.Bold, GraphicsUnit.Point);
                    panelTitleBar.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    currentButton.BackColor = ThemeColor.SecondaryColor;
                    btnCloseChildForm.Visible = true;
                    btnCloseChildForm.OnHoverBaseColor = color;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Outfit Thin", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {

            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
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
            lblTitle.Text = childForm.Text;

        }

        private int OpenChildFormOrder(Form childForm, object btnSender, int customer_id, string username)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
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
            lblTitle.Text = childForm.Text;
            return customer_id;
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
            panelDesktopPane.Visible = false;
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Dashboard";
            panelTitleBar.BackColor = Color.FromArgb(51, 51, 76);
            panelLogo.BackColor = Color.FromArgb(35, 35, 52);
            currentButton = null;
            btnCloseChildForm.Visible = false;

            btnOrder.Enabled = true;
            btnPay.Enabled = true;
            btnInventory.Enabled = true;
            btnReport.Enabled = true;
            btnMaintenance.Enabled = true;
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                SearchCustomer search = new SearchCustomer(username);
                // The code inside this block is executed while the loading animation is displayed
                if (search.ShowDialog() == DialogResult.OK)
                {
                    int customer_id = search.SelectedCustomerId;
                    // Pass the customer_id to the FormOrder constructor
                    OpenChildFormOrder(new Forms.FormOrder(customer_id, username, role), sender, customer_id, username); // Provide customer_id here
                    lblTitle.Text = "Create Order";

                    btnPay.Enabled = false;
                    btnInventory.Enabled = false;
                    btnReport.Enabled = false;
                    btnMaintenance.Enabled = false;
                }
            });
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            LoadingScreenManager.ShowLoadingScreen(() =>
            {
                OpenChildForm(new Forms.FormCollections(username, role), sender);
                    lblTitle.Text = "Collections";
                    btnOrder.Enabled = false;
                    btnInventory.Enabled = false;
                    btnReport.Enabled = false;
                    btnMaintenance.Enabled = false;
            });
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Forms.FormOrder(), sender);
            lblTitle.Text = "Inventory";
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Forms.FormOrder(), sender);
            lblTitle.Text = "Reporting";
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Forms.FormOrder(), sender);
            lblTitle.Text = "Maintenance";
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
            panelDesktopPane.Visible = false;
        }

        private void close_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
            panelDesktopPane.Visible = false;
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            charts();
        }

        private void panelDesktopPane_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
