namespace Dashboard
{
    partial class Clock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clock));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSunday = new System.Windows.Forms.Label();
            this.lblTuesday = new System.Windows.Forms.Label();
            this.lblWednesday = new System.Windows.Forms.Label();
            this.lblMonday = new System.Windows.Forms.Label();
            this.lblSaturday = new System.Windows.Forms.Label();
            this.lblThursday = new System.Windows.Forms.Label();
            this.lblFriday = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.btnCloseChildForm = new Guna.UI.WinForms.GunaAdvenceButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaButton2 = new Guna.UI.WinForms.GunaButton();
            this.gunaButton3 = new Guna.UI.WinForms.GunaButton();
            this.gunaButton4 = new Guna.UI.WinForms.GunaButton();
            this.timestampGrid = new Guna.UI.WinForms.GunaDataGridView();
            this.Activity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Limit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPullout = new Guna.UI.WinForms.GunaAdvenceTileButton();
            this.btnUnscheduled = new Guna.UI.WinForms.GunaAdvenceTileButton();
            this.btnOvertime = new Guna.UI.WinForms.GunaAdvenceTileButton();
            this.btnBio = new Guna.UI.WinForms.GunaAdvenceTileButton();
            this.btnBreak2 = new Guna.UI.WinForms.GunaAdvenceTileButton();
            this.btnLunch = new Guna.UI.WinForms.GunaAdvenceTileButton();
            this.btnBreak1 = new Guna.UI.WinForms.GunaAdvenceTileButton();
            this.btnStartEnd = new Guna.UI.WinForms.GunaAdvenceTileButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblOvertime = new System.Windows.Forms.Label();
            this.lblStartEnd = new System.Windows.Forms.Label();
            this.lblBio = new System.Windows.Forms.Label();
            this.lblPullout = new System.Windows.Forms.Label();
            this.lblUnscheduled = new System.Windows.Forms.Label();
            this.lblLunch = new System.Windows.Forms.Label();
            this.lblBreak2 = new System.Windows.Forms.Label();
            this.lblBreak1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timestampGrid)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblClock);
            this.panel1.Controls.Add(this.btnCloseChildForm);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 196);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblSunday);
            this.panel2.Controls.Add(this.lblTuesday);
            this.panel2.Controls.Add(this.lblWednesday);
            this.panel2.Controls.Add(this.lblMonday);
            this.panel2.Controls.Add(this.lblSaturday);
            this.panel2.Controls.Add(this.lblThursday);
            this.panel2.Controls.Add(this.lblFriday);
            this.panel2.Location = new System.Drawing.Point(4, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 28);
            this.panel2.TabIndex = 12;
            // 
            // lblSunday
            // 
            this.lblSunday.AutoSize = true;
            this.lblSunday.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F);
            this.lblSunday.ForeColor = System.Drawing.Color.Gray;
            this.lblSunday.Location = new System.Drawing.Point(0, 1);
            this.lblSunday.Name = "lblSunday";
            this.lblSunday.Size = new System.Drawing.Size(58, 16);
            this.lblSunday.TabIndex = 1;
            this.lblSunday.Text = "SUNDAY";
            this.lblSunday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTuesday
            // 
            this.lblTuesday.AutoSize = true;
            this.lblTuesday.ForeColor = System.Drawing.Color.Gray;
            this.lblTuesday.Location = new System.Drawing.Point(133, 1);
            this.lblTuesday.Name = "lblTuesday";
            this.lblTuesday.Size = new System.Drawing.Size(65, 16);
            this.lblTuesday.TabIndex = 3;
            this.lblTuesday.Text = "TUESDAY";
            this.lblTuesday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWednesday
            // 
            this.lblWednesday.AutoSize = true;
            this.lblWednesday.ForeColor = System.Drawing.Color.Gray;
            this.lblWednesday.Location = new System.Drawing.Point(204, 1);
            this.lblWednesday.Name = "lblWednesday";
            this.lblWednesday.Size = new System.Drawing.Size(88, 16);
            this.lblWednesday.TabIndex = 4;
            this.lblWednesday.Text = "WEDNESDAY";
            this.lblWednesday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonday
            // 
            this.lblMonday.AutoSize = true;
            this.lblMonday.ForeColor = System.Drawing.Color.Gray;
            this.lblMonday.Location = new System.Drawing.Point(64, 1);
            this.lblMonday.Name = "lblMonday";
            this.lblMonday.Size = new System.Drawing.Size(63, 16);
            this.lblMonday.TabIndex = 2;
            this.lblMonday.Text = "MONDAY";
            this.lblMonday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSaturday
            // 
            this.lblSaturday.AutoSize = true;
            this.lblSaturday.ForeColor = System.Drawing.Color.Gray;
            this.lblSaturday.Location = new System.Drawing.Point(435, 1);
            this.lblSaturday.Name = "lblSaturday";
            this.lblSaturday.Size = new System.Drawing.Size(72, 16);
            this.lblSaturday.TabIndex = 7;
            this.lblSaturday.Text = "SATURDAY";
            this.lblSaturday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThursday
            // 
            this.lblThursday.AutoSize = true;
            this.lblThursday.ForeColor = System.Drawing.Color.Gray;
            this.lblThursday.Location = new System.Drawing.Point(298, 1);
            this.lblThursday.Name = "lblThursday";
            this.lblThursday.Size = new System.Drawing.Size(74, 16);
            this.lblThursday.TabIndex = 5;
            this.lblThursday.Text = "THURSDAY";
            this.lblThursday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFriday
            // 
            this.lblFriday.AutoSize = true;
            this.lblFriday.ForeColor = System.Drawing.Color.Gray;
            this.lblFriday.Location = new System.Drawing.Point(378, 1);
            this.lblFriday.Name = "lblFriday";
            this.lblFriday.Size = new System.Drawing.Size(51, 16);
            this.lblFriday.TabIndex = 6;
            this.lblFriday.Text = "FRIDAY";
            this.lblFriday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Outfit Thin SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(0, 162);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(518, 20);
            this.lblDate.TabIndex = 11;
            this.lblDate.Text = "November 20, 2023";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClock
            // 
            this.lblClock.Font = new System.Drawing.Font("Outfit Thin SemiBold", 52F, System.Drawing.FontStyle.Bold);
            this.lblClock.Location = new System.Drawing.Point(0, 65);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(518, 88);
            this.lblClock.TabIndex = 8;
            this.lblClock.Text = "00:00:00";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCloseChildForm
            // 
            this.btnCloseChildForm.AnimationHoverSpeed = 0.07F;
            this.btnCloseChildForm.AnimationSpeed = 0.03F;
            this.btnCloseChildForm.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseChildForm.BaseColor = System.Drawing.Color.Transparent;
            this.btnCloseChildForm.BorderColor = System.Drawing.Color.Black;
            this.btnCloseChildForm.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnCloseChildForm.CheckedBorderColor = System.Drawing.Color.Transparent;
            this.btnCloseChildForm.CheckedForeColor = System.Drawing.Color.White;
            this.btnCloseChildForm.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnCloseChildForm.CheckedImage")));
            this.btnCloseChildForm.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnCloseChildForm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCloseChildForm.FocusedColor = System.Drawing.Color.Empty;
            this.btnCloseChildForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCloseChildForm.ForeColor = System.Drawing.Color.White;
            this.btnCloseChildForm.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseChildForm.Image")));
            this.btnCloseChildForm.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCloseChildForm.ImageSize = new System.Drawing.Size(35, 35);
            this.btnCloseChildForm.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnCloseChildForm.Location = new System.Drawing.Point(480, 2);
            this.btnCloseChildForm.Name = "btnCloseChildForm";
            this.btnCloseChildForm.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnCloseChildForm.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnCloseChildForm.OnHoverForeColor = System.Drawing.Color.White;
            this.btnCloseChildForm.OnHoverImage = null;
            this.btnCloseChildForm.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnCloseChildForm.OnPressedColor = System.Drawing.Color.Black;
            this.btnCloseChildForm.Radius = 15;
            this.btnCloseChildForm.Size = new System.Drawing.Size(35, 35);
            this.btnCloseChildForm.TabIndex = 10;
            this.btnCloseChildForm.Click += new System.EventHandler(this.btnCloseChildForm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Outfit Thin", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clock";
            // 
            // gunaButton2
            // 
            this.gunaButton2.AnimationHoverSpeed = 0.07F;
            this.gunaButton2.AnimationSpeed = 0.03F;
            this.gunaButton2.BackColor = System.Drawing.Color.Transparent;
            this.gunaButton2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.gunaButton2.BorderColor = System.Drawing.Color.Black;
            this.gunaButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton2.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaButton2.ForeColor = System.Drawing.Color.White;
            this.gunaButton2.Image = null;
            this.gunaButton2.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton2.Location = new System.Drawing.Point(407, 495);
            this.gunaButton2.Name = "gunaButton2";
            this.gunaButton2.OnHoverBaseColor = System.Drawing.Color.DimGray;
            this.gunaButton2.OnHoverBorderColor = System.Drawing.Color.DimGray;
            this.gunaButton2.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton2.OnHoverImage = null;
            this.gunaButton2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton2.Radius = 5;
            this.gunaButton2.Size = new System.Drawing.Size(103, 29);
            this.gunaButton2.TabIndex = 10;
            this.gunaButton2.Text = "My Time Card";
            this.gunaButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gunaButton3
            // 
            this.gunaButton3.AnimationHoverSpeed = 0.07F;
            this.gunaButton3.AnimationSpeed = 0.03F;
            this.gunaButton3.BackColor = System.Drawing.Color.Transparent;
            this.gunaButton3.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.gunaButton3.BorderColor = System.Drawing.Color.Black;
            this.gunaButton3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton3.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaButton3.ForeColor = System.Drawing.Color.White;
            this.gunaButton3.Image = null;
            this.gunaButton3.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton3.Location = new System.Drawing.Point(305, 495);
            this.gunaButton3.Name = "gunaButton3";
            this.gunaButton3.OnHoverBaseColor = System.Drawing.Color.DimGray;
            this.gunaButton3.OnHoverBorderColor = System.Drawing.Color.DimGray;
            this.gunaButton3.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton3.OnHoverImage = null;
            this.gunaButton3.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton3.Radius = 5;
            this.gunaButton3.Size = new System.Drawing.Size(99, 29);
            this.gunaButton3.TabIndex = 11;
            this.gunaButton3.Text = "Dispute";
            this.gunaButton3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gunaButton4
            // 
            this.gunaButton4.AnimationHoverSpeed = 0.07F;
            this.gunaButton4.AnimationSpeed = 0.03F;
            this.gunaButton4.BackColor = System.Drawing.Color.Transparent;
            this.gunaButton4.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.gunaButton4.BorderColor = System.Drawing.Color.Black;
            this.gunaButton4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton4.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaButton4.ForeColor = System.Drawing.Color.White;
            this.gunaButton4.Image = null;
            this.gunaButton4.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton4.Location = new System.Drawing.Point(6, 495);
            this.gunaButton4.Name = "gunaButton4";
            this.gunaButton4.OnHoverBaseColor = System.Drawing.Color.DimGray;
            this.gunaButton4.OnHoverBorderColor = System.Drawing.Color.DimGray;
            this.gunaButton4.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton4.OnHoverImage = null;
            this.gunaButton4.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton4.Radius = 5;
            this.gunaButton4.Size = new System.Drawing.Size(99, 29);
            this.gunaButton4.TabIndex = 12;
            this.gunaButton4.Text = "My Disputes";
            this.gunaButton4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timestampGrid
            // 
            this.timestampGrid.AllowUserToAddRows = false;
            this.timestampGrid.AllowUserToDeleteRows = false;
            this.timestampGrid.AllowUserToResizeColumns = false;
            this.timestampGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.timestampGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.timestampGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.timestampGrid.BackgroundColor = System.Drawing.Color.White;
            this.timestampGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timestampGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.timestampGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Outfit Thin Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.timestampGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.timestampGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Activity,
            this.StartTime,
            this.EndTime,
            this.Limit,
            this.Duration,
            this.Remarks});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.timestampGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.timestampGrid.EnableHeadersVisualStyles = false;
            this.timestampGrid.GridColor = System.Drawing.Color.White;
            this.timestampGrid.Location = new System.Drawing.Point(8, 347);
            this.timestampGrid.Name = "timestampGrid";
            this.timestampGrid.ReadOnly = true;
            this.timestampGrid.RowHeadersVisible = false;
            this.timestampGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.timestampGrid.Size = new System.Drawing.Size(502, 144);
            this.timestampGrid.TabIndex = 13;
            this.timestampGrid.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.timestampGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.timestampGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.timestampGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.timestampGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.timestampGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.timestampGrid.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.timestampGrid.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.timestampGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.timestampGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.timestampGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Outfit Thin Medium", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timestampGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.timestampGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.timestampGrid.ThemeStyle.HeaderStyle.Height = 23;
            this.timestampGrid.ThemeStyle.ReadOnly = true;
            this.timestampGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.timestampGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.timestampGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timestampGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.timestampGrid.ThemeStyle.RowsStyle.Height = 22;
            this.timestampGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.White;
            this.timestampGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // Activity
            // 
            this.Activity.FillWeight = 91.37056F;
            this.Activity.HeaderText = "Activity";
            this.Activity.Name = "Activity";
            this.Activity.ReadOnly = true;
            // 
            // StartTime
            // 
            this.StartTime.FillWeight = 92.23377F;
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            // 
            // EndTime
            // 
            this.EndTime.FillWeight = 85.19596F;
            this.EndTime.HeaderText = "End Time";
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            // 
            // Limit
            // 
            this.Limit.FillWeight = 87.93515F;
            this.Limit.HeaderText = "Limit";
            this.Limit.Name = "Limit";
            this.Limit.ReadOnly = true;
            // 
            // Duration
            // 
            this.Duration.FillWeight = 83.12939F;
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            // 
            // Remarks
            // 
            this.Remarks.FillWeight = 160.1352F;
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            // 
            // btnPullout
            // 
            this.btnPullout.AnimationHoverSpeed = 0.07F;
            this.btnPullout.AnimationSpeed = 0.03F;
            this.btnPullout.BackColor = System.Drawing.Color.Transparent;
            this.btnPullout.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnPullout.BorderColor = System.Drawing.Color.Black;
            this.btnPullout.CheckedBaseColor = System.Drawing.Color.DarkRed;
            this.btnPullout.CheckedBorderColor = System.Drawing.Color.DarkRed;
            this.btnPullout.CheckedForeColor = System.Drawing.Color.White;
            this.btnPullout.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnPullout.CheckedImage")));
            this.btnPullout.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnPullout.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPullout.Enabled = false;
            this.btnPullout.FocusedColor = System.Drawing.Color.Empty;
            this.btnPullout.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPullout.ForeColor = System.Drawing.Color.White;
            this.btnPullout.Image = ((System.Drawing.Image)(resources.GetObject("btnPullout.Image")));
            this.btnPullout.ImageSize = new System.Drawing.Size(15, 15);
            this.btnPullout.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnPullout.Location = new System.Drawing.Point(387, 75);
            this.btnPullout.Name = "btnPullout";
            this.btnPullout.OnHoverBaseColor = System.Drawing.Color.DimGray;
            this.btnPullout.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnPullout.OnHoverForeColor = System.Drawing.Color.White;
            this.btnPullout.OnHoverImage = null;
            this.btnPullout.OnHoverLineColor = System.Drawing.Color.DimGray;
            this.btnPullout.OnPressedColor = System.Drawing.Color.Black;
            this.btnPullout.Radius = 10;
            this.btnPullout.Size = new System.Drawing.Size(122, 66);
            this.btnPullout.TabIndex = 8;
            this.btnPullout.Text = "Pull Out";
            this.btnPullout.Click += new System.EventHandler(this.btnPullout_Click);
            // 
            // btnUnscheduled
            // 
            this.btnUnscheduled.AnimationHoverSpeed = 0.07F;
            this.btnUnscheduled.AnimationSpeed = 0.03F;
            this.btnUnscheduled.BackColor = System.Drawing.Color.Transparent;
            this.btnUnscheduled.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnUnscheduled.BorderColor = System.Drawing.Color.Black;
            this.btnUnscheduled.CheckedBaseColor = System.Drawing.Color.DarkRed;
            this.btnUnscheduled.CheckedBorderColor = System.Drawing.Color.DarkRed;
            this.btnUnscheduled.CheckedForeColor = System.Drawing.Color.White;
            this.btnUnscheduled.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnUnscheduled.CheckedImage")));
            this.btnUnscheduled.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnUnscheduled.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnUnscheduled.Enabled = false;
            this.btnUnscheduled.FocusedColor = System.Drawing.Color.Empty;
            this.btnUnscheduled.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnscheduled.ForeColor = System.Drawing.Color.White;
            this.btnUnscheduled.Image = global::Dashboard.Properties.Resources.icons8_play_30;
            this.btnUnscheduled.ImageSize = new System.Drawing.Size(15, 15);
            this.btnUnscheduled.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnUnscheduled.Location = new System.Drawing.Point(259, 75);
            this.btnUnscheduled.Name = "btnUnscheduled";
            this.btnUnscheduled.OnHoverBaseColor = System.Drawing.Color.DimGray;
            this.btnUnscheduled.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnUnscheduled.OnHoverForeColor = System.Drawing.Color.White;
            this.btnUnscheduled.OnHoverImage = null;
            this.btnUnscheduled.OnHoverLineColor = System.Drawing.Color.DimGray;
            this.btnUnscheduled.OnPressedColor = System.Drawing.Color.Black;
            this.btnUnscheduled.Radius = 10;
            this.btnUnscheduled.Size = new System.Drawing.Size(122, 66);
            this.btnUnscheduled.TabIndex = 7;
            this.btnUnscheduled.Text = "Unscheduled";
            this.btnUnscheduled.Click += new System.EventHandler(this.btnUnscheduled_Click);
            // 
            // btnOvertime
            // 
            this.btnOvertime.AnimationHoverSpeed = 0.07F;
            this.btnOvertime.AnimationSpeed = 0.03F;
            this.btnOvertime.BackColor = System.Drawing.Color.Transparent;
            this.btnOvertime.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnOvertime.BorderColor = System.Drawing.Color.Black;
            this.btnOvertime.CheckedBaseColor = System.Drawing.Color.DarkRed;
            this.btnOvertime.CheckedBorderColor = System.Drawing.Color.DarkRed;
            this.btnOvertime.CheckedForeColor = System.Drawing.Color.White;
            this.btnOvertime.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnOvertime.CheckedImage")));
            this.btnOvertime.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnOvertime.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOvertime.Enabled = false;
            this.btnOvertime.FocusedColor = System.Drawing.Color.Empty;
            this.btnOvertime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOvertime.ForeColor = System.Drawing.Color.White;
            this.btnOvertime.Image = global::Dashboard.Properties.Resources.icons8_play_30;
            this.btnOvertime.ImageSize = new System.Drawing.Size(15, 15);
            this.btnOvertime.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnOvertime.Location = new System.Drawing.Point(131, 75);
            this.btnOvertime.Name = "btnOvertime";
            this.btnOvertime.OnHoverBaseColor = System.Drawing.Color.DimGray;
            this.btnOvertime.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnOvertime.OnHoverForeColor = System.Drawing.Color.White;
            this.btnOvertime.OnHoverImage = null;
            this.btnOvertime.OnHoverLineColor = System.Drawing.Color.DimGray;
            this.btnOvertime.OnPressedColor = System.Drawing.Color.Black;
            this.btnOvertime.Radius = 10;
            this.btnOvertime.Size = new System.Drawing.Size(122, 66);
            this.btnOvertime.TabIndex = 6;
            this.btnOvertime.Text = "Overtime";
            this.btnOvertime.Click += new System.EventHandler(this.btnOvertime_Click);
            // 
            // btnBio
            // 
            this.btnBio.AnimationHoverSpeed = 0.07F;
            this.btnBio.AnimationSpeed = 0.03F;
            this.btnBio.BackColor = System.Drawing.Color.Transparent;
            this.btnBio.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnBio.BorderColor = System.Drawing.Color.Black;
            this.btnBio.CheckedBaseColor = System.Drawing.Color.DarkRed;
            this.btnBio.CheckedBorderColor = System.Drawing.Color.DarkRed;
            this.btnBio.CheckedForeColor = System.Drawing.Color.White;
            this.btnBio.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnBio.CheckedImage")));
            this.btnBio.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnBio.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBio.Enabled = false;
            this.btnBio.FocusedColor = System.Drawing.Color.Empty;
            this.btnBio.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBio.ForeColor = System.Drawing.Color.White;
            this.btnBio.Image = ((System.Drawing.Image)(resources.GetObject("btnBio.Image")));
            this.btnBio.ImageSize = new System.Drawing.Size(15, 15);
            this.btnBio.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnBio.Location = new System.Drawing.Point(3, 75);
            this.btnBio.Name = "btnBio";
            this.btnBio.OnHoverBaseColor = System.Drawing.Color.DimGray;
            this.btnBio.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnBio.OnHoverForeColor = System.Drawing.Color.White;
            this.btnBio.OnHoverImage = null;
            this.btnBio.OnHoverLineColor = System.Drawing.Color.DimGray;
            this.btnBio.OnPressedColor = System.Drawing.Color.Black;
            this.btnBio.Radius = 10;
            this.btnBio.Size = new System.Drawing.Size(122, 66);
            this.btnBio.TabIndex = 5;
            this.btnBio.Text = "Bio Break";
            this.btnBio.Click += new System.EventHandler(this.btnBio_Click);
            // 
            // btnBreak2
            // 
            this.btnBreak2.AnimationHoverSpeed = 0.07F;
            this.btnBreak2.AnimationSpeed = 0.03F;
            this.btnBreak2.BackColor = System.Drawing.Color.Transparent;
            this.btnBreak2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnBreak2.BorderColor = System.Drawing.Color.Black;
            this.btnBreak2.CheckedBaseColor = System.Drawing.Color.DarkRed;
            this.btnBreak2.CheckedBorderColor = System.Drawing.Color.DarkRed;
            this.btnBreak2.CheckedForeColor = System.Drawing.Color.White;
            this.btnBreak2.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnBreak2.CheckedImage")));
            this.btnBreak2.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnBreak2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBreak2.Enabled = false;
            this.btnBreak2.FocusedColor = System.Drawing.Color.Empty;
            this.btnBreak2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBreak2.ForeColor = System.Drawing.Color.White;
            this.btnBreak2.Image = ((System.Drawing.Image)(resources.GetObject("btnBreak2.Image")));
            this.btnBreak2.ImageSize = new System.Drawing.Size(15, 15);
            this.btnBreak2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnBreak2.Location = new System.Drawing.Point(387, 3);
            this.btnBreak2.Name = "btnBreak2";
            this.btnBreak2.OnHoverBaseColor = System.Drawing.Color.DimGray;
            this.btnBreak2.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnBreak2.OnHoverForeColor = System.Drawing.Color.White;
            this.btnBreak2.OnHoverImage = null;
            this.btnBreak2.OnHoverLineColor = System.Drawing.Color.DimGray;
            this.btnBreak2.OnPressedColor = System.Drawing.Color.Black;
            this.btnBreak2.Radius = 10;
            this.btnBreak2.Size = new System.Drawing.Size(122, 66);
            this.btnBreak2.TabIndex = 4;
            this.btnBreak2.Text = "Break 2";
            this.btnBreak2.Click += new System.EventHandler(this.btnBreak2_Click);
            // 
            // btnLunch
            // 
            this.btnLunch.AnimationHoverSpeed = 0.07F;
            this.btnLunch.AnimationSpeed = 0.03F;
            this.btnLunch.BackColor = System.Drawing.Color.Transparent;
            this.btnLunch.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnLunch.BorderColor = System.Drawing.Color.Black;
            this.btnLunch.CheckedBaseColor = System.Drawing.Color.DarkRed;
            this.btnLunch.CheckedBorderColor = System.Drawing.Color.DarkRed;
            this.btnLunch.CheckedForeColor = System.Drawing.Color.White;
            this.btnLunch.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnLunch.CheckedImage")));
            this.btnLunch.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnLunch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLunch.Enabled = false;
            this.btnLunch.FocusedColor = System.Drawing.Color.Empty;
            this.btnLunch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLunch.ForeColor = System.Drawing.Color.White;
            this.btnLunch.Image = ((System.Drawing.Image)(resources.GetObject("btnLunch.Image")));
            this.btnLunch.ImageSize = new System.Drawing.Size(15, 15);
            this.btnLunch.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnLunch.Location = new System.Drawing.Point(259, 3);
            this.btnLunch.Name = "btnLunch";
            this.btnLunch.OnHoverBaseColor = System.Drawing.Color.DimGray;
            this.btnLunch.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLunch.OnHoverForeColor = System.Drawing.Color.White;
            this.btnLunch.OnHoverImage = null;
            this.btnLunch.OnHoverLineColor = System.Drawing.Color.DimGray;
            this.btnLunch.OnPressedColor = System.Drawing.Color.Black;
            this.btnLunch.Radius = 10;
            this.btnLunch.Size = new System.Drawing.Size(122, 66);
            this.btnLunch.TabIndex = 3;
            this.btnLunch.Text = "Lunch";
            this.btnLunch.Click += new System.EventHandler(this.btnLunch_Click);
            // 
            // btnBreak1
            // 
            this.btnBreak1.AnimationHoverSpeed = 0.07F;
            this.btnBreak1.AnimationSpeed = 0.03F;
            this.btnBreak1.BackColor = System.Drawing.Color.Transparent;
            this.btnBreak1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnBreak1.BorderColor = System.Drawing.Color.Black;
            this.btnBreak1.CheckedBaseColor = System.Drawing.Color.DarkRed;
            this.btnBreak1.CheckedBorderColor = System.Drawing.Color.DarkRed;
            this.btnBreak1.CheckedForeColor = System.Drawing.Color.White;
            this.btnBreak1.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnBreak1.CheckedImage")));
            this.btnBreak1.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnBreak1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBreak1.Enabled = false;
            this.btnBreak1.FocusedColor = System.Drawing.Color.Empty;
            this.btnBreak1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBreak1.ForeColor = System.Drawing.Color.White;
            this.btnBreak1.Image = ((System.Drawing.Image)(resources.GetObject("btnBreak1.Image")));
            this.btnBreak1.ImageSize = new System.Drawing.Size(15, 15);
            this.btnBreak1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnBreak1.Location = new System.Drawing.Point(131, 3);
            this.btnBreak1.Name = "btnBreak1";
            this.btnBreak1.OnHoverBaseColor = System.Drawing.Color.DimGray;
            this.btnBreak1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnBreak1.OnHoverForeColor = System.Drawing.Color.White;
            this.btnBreak1.OnHoverImage = null;
            this.btnBreak1.OnHoverLineColor = System.Drawing.Color.DimGray;
            this.btnBreak1.OnPressedColor = System.Drawing.Color.Black;
            this.btnBreak1.Radius = 10;
            this.btnBreak1.Size = new System.Drawing.Size(122, 66);
            this.btnBreak1.TabIndex = 2;
            this.btnBreak1.Text = "Break 1";
            this.btnBreak1.Click += new System.EventHandler(this.btnBreak1_Click);
            // 
            // btnStartEnd
            // 
            this.btnStartEnd.AnimationHoverSpeed = 0.07F;
            this.btnStartEnd.AnimationSpeed = 0.03F;
            this.btnStartEnd.BackColor = System.Drawing.Color.Transparent;
            this.btnStartEnd.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnStartEnd.BorderColor = System.Drawing.Color.Black;
            this.btnStartEnd.CheckedBaseColor = System.Drawing.Color.DarkRed;
            this.btnStartEnd.CheckedBorderColor = System.Drawing.Color.DarkRed;
            this.btnStartEnd.CheckedForeColor = System.Drawing.Color.White;
            this.btnStartEnd.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnStartEnd.CheckedImage")));
            this.btnStartEnd.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnStartEnd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStartEnd.FocusedColor = System.Drawing.Color.Empty;
            this.btnStartEnd.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartEnd.ForeColor = System.Drawing.Color.White;
            this.btnStartEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnStartEnd.Image")));
            this.btnStartEnd.ImageSize = new System.Drawing.Size(15, 15);
            this.btnStartEnd.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnStartEnd.Location = new System.Drawing.Point(3, 3);
            this.btnStartEnd.Name = "btnStartEnd";
            this.btnStartEnd.OnHoverBaseColor = System.Drawing.Color.DimGray;
            this.btnStartEnd.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnStartEnd.OnHoverForeColor = System.Drawing.Color.White;
            this.btnStartEnd.OnHoverImage = null;
            this.btnStartEnd.OnHoverLineColor = System.Drawing.Color.DimGray;
            this.btnStartEnd.OnPressedColor = System.Drawing.Color.Black;
            this.btnStartEnd.Radius = 10;
            this.btnStartEnd.Size = new System.Drawing.Size(122, 66);
            this.btnStartEnd.TabIndex = 1;
            this.btnStartEnd.Text = "Start Shift";
            this.btnStartEnd.Click += new System.EventHandler(this.btnStartEnd_Click);
            this.btnStartEnd.MouseEnter += new System.EventHandler(this.btnStartEnd_MouseEnter);
            this.btnStartEnd.MouseLeave += new System.EventHandler(this.btnStartEnd_MouseLeave);
            this.btnStartEnd.MouseHover += new System.EventHandler(this.btnStartEnd_MouseHover);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.lblOvertime);
            this.panel3.Controls.Add(this.lblStartEnd);
            this.panel3.Controls.Add(this.lblBio);
            this.panel3.Controls.Add(this.lblPullout);
            this.panel3.Controls.Add(this.lblUnscheduled);
            this.panel3.Controls.Add(this.lblLunch);
            this.panel3.Controls.Add(this.lblBreak2);
            this.panel3.Controls.Add(this.lblBreak1);
            this.panel3.Controls.Add(this.btnStartEnd);
            this.panel3.Controls.Add(this.btnBreak1);
            this.panel3.Controls.Add(this.btnLunch);
            this.panel3.Controls.Add(this.btnBreak2);
            this.panel3.Controls.Add(this.btnBio);
            this.panel3.Controls.Add(this.btnPullout);
            this.panel3.Controls.Add(this.btnOvertime);
            this.panel3.Controls.Add(this.btnUnscheduled);
            this.panel3.Location = new System.Drawing.Point(2, 198);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(516, 151);
            this.panel3.TabIndex = 14;
            // 
            // lblOvertime
            // 
            this.lblOvertime.AutoSize = true;
            this.lblOvertime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(86)))));
            this.lblOvertime.Enabled = false;
            this.lblOvertime.Font = new System.Drawing.Font("Outfit Thin Light", 8.25F);
            this.lblOvertime.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblOvertime.Location = new System.Drawing.Point(176, 125);
            this.lblOvertime.Name = "lblOvertime";
            this.lblOvertime.Size = new System.Drawing.Size(32, 14);
            this.lblOvertime.TabIndex = 20;
            this.lblOvertime.Text = "4 hrs";
            // 
            // lblStartEnd
            // 
            this.lblStartEnd.AutoSize = true;
            this.lblStartEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.lblStartEnd.Font = new System.Drawing.Font("Outfit Thin Light", 8.25F);
            this.lblStartEnd.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblStartEnd.Location = new System.Drawing.Point(49, 52);
            this.lblStartEnd.Name = "lblStartEnd";
            this.lblStartEnd.Size = new System.Drawing.Size(31, 14);
            this.lblStartEnd.TabIndex = 13;
            this.lblStartEnd.Text = "9 hrs";
            // 
            // lblBio
            // 
            this.lblBio.AutoSize = true;
            this.lblBio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(86)))));
            this.lblBio.Enabled = false;
            this.lblBio.Font = new System.Drawing.Font("Outfit Thin Light", 8.25F);
            this.lblBio.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblBio.Location = new System.Drawing.Point(46, 124);
            this.lblBio.Name = "lblBio";
            this.lblBio.Size = new System.Drawing.Size(37, 14);
            this.lblBio.TabIndex = 19;
            this.lblBio.Text = "5 mins";
            // 
            // lblPullout
            // 
            this.lblPullout.AutoSize = true;
            this.lblPullout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(86)))));
            this.lblPullout.Enabled = false;
            this.lblPullout.Font = new System.Drawing.Font("Outfit Thin Light", 8.25F);
            this.lblPullout.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblPullout.Location = new System.Drawing.Point(426, 125);
            this.lblPullout.Name = "lblPullout";
            this.lblPullout.Size = new System.Drawing.Size(44, 14);
            this.lblPullout.TabIndex = 18;
            this.lblPullout.Text = "30 mins";
            // 
            // lblUnscheduled
            // 
            this.lblUnscheduled.AutoSize = true;
            this.lblUnscheduled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(86)))));
            this.lblUnscheduled.Enabled = false;
            this.lblUnscheduled.Font = new System.Drawing.Font("Outfit Thin Light", 8.25F);
            this.lblUnscheduled.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblUnscheduled.Location = new System.Drawing.Point(302, 125);
            this.lblUnscheduled.Name = "lblUnscheduled";
            this.lblUnscheduled.Size = new System.Drawing.Size(36, 14);
            this.lblUnscheduled.TabIndex = 17;
            this.lblUnscheduled.Text = "Break";
            // 
            // lblLunch
            // 
            this.lblLunch.AutoSize = true;
            this.lblLunch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(86)))));
            this.lblLunch.Enabled = false;
            this.lblLunch.Font = new System.Drawing.Font("Outfit Thin Light", 8.25F);
            this.lblLunch.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblLunch.Location = new System.Drawing.Point(298, 52);
            this.lblLunch.Name = "lblLunch";
            this.lblLunch.Size = new System.Drawing.Size(44, 14);
            this.lblLunch.TabIndex = 16;
            this.lblLunch.Text = "60 mins";
            // 
            // lblBreak2
            // 
            this.lblBreak2.AutoSize = true;
            this.lblBreak2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(86)))));
            this.lblBreak2.Enabled = false;
            this.lblBreak2.Font = new System.Drawing.Font("Outfit Thin Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreak2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblBreak2.Location = new System.Drawing.Point(428, 52);
            this.lblBreak2.Name = "lblBreak2";
            this.lblBreak2.Size = new System.Drawing.Size(41, 14);
            this.lblBreak2.TabIndex = 15;
            this.lblBreak2.Text = "15 mins";
            // 
            // lblBreak1
            // 
            this.lblBreak1.AutoSize = true;
            this.lblBreak1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(86)))));
            this.lblBreak1.Enabled = false;
            this.lblBreak1.Font = new System.Drawing.Font("Outfit Thin Light", 8.25F);
            this.lblBreak1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblBreak1.Location = new System.Drawing.Point(172, 52);
            this.lblBreak1.Name = "lblBreak1";
            this.lblBreak1.Size = new System.Drawing.Size(41, 14);
            this.lblBreak1.TabIndex = 14;
            this.lblBreak1.Text = "15 mins";
            // 
            // Clock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(518, 536);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.timestampGrid);
            this.Controls.Add(this.gunaButton4);
            this.Controls.Add(this.gunaButton3);
            this.Controls.Add(this.gunaButton2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Clock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clock";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timestampGrid)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaAdvenceButton btnCloseChildForm;
        private System.Windows.Forms.Label lblSunday;
        private System.Windows.Forms.Label lblMonday;
        private System.Windows.Forms.Label lblTuesday;
        private System.Windows.Forms.Label lblWednesday;
        private System.Windows.Forms.Label lblThursday;
        private System.Windows.Forms.Label lblFriday;
        private System.Windows.Forms.Label lblSaturday;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Label lblDate;
        private Guna.UI.WinForms.GunaAdvenceTileButton btnStartEnd;
        private Guna.UI.WinForms.GunaAdvenceTileButton btnBreak1;
        private Guna.UI.WinForms.GunaAdvenceTileButton btnLunch;
        private Guna.UI.WinForms.GunaAdvenceTileButton btnBreak2;
        private Guna.UI.WinForms.GunaAdvenceTileButton btnPullout;
        private Guna.UI.WinForms.GunaAdvenceTileButton btnUnscheduled;
        private Guna.UI.WinForms.GunaAdvenceTileButton btnOvertime;
        private Guna.UI.WinForms.GunaAdvenceTileButton btnBio;
        private Guna.UI.WinForms.GunaButton gunaButton2;
        private Guna.UI.WinForms.GunaButton gunaButton3;
        private Guna.UI.WinForms.GunaButton gunaButton4;
        private Guna.UI.WinForms.GunaDataGridView timestampGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblBio;
        private System.Windows.Forms.Label lblPullout;
        private System.Windows.Forms.Label lblUnscheduled;
        private System.Windows.Forms.Label lblLunch;
        private System.Windows.Forms.Label lblBreak2;
        private System.Windows.Forms.Label lblBreak1;
        private System.Windows.Forms.Label lblStartEnd;
        private System.Windows.Forms.Label lblOvertime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activity;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Limit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
    }
}