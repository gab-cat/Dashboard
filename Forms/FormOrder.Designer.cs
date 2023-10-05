namespace Dashboard.Forms
{
    partial class FormOrder
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrder));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Copy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.gunaButton2 = new Guna.UI.WinForms.GunaButton();
            this.gunaButton1 = new Guna.UI.WinForms.GunaButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.chkPastDue = new System.Windows.Forms.CheckBox();
            this.chkPhone = new System.Windows.Forms.CheckBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.txtPayments = new System.Windows.Forms.TextBox();
            this.txtPayable = new System.Windows.Forms.TextBox();
            this.txtBalance1 = new System.Windows.Forms.Label();
            this.txtPayable1 = new System.Windows.Forms.Label();
            this.txtPayments1 = new System.Windows.Forms.Label();
            this.chkEmail = new System.Windows.Forms.CheckBox();
            this.chkSMS = new System.Windows.Forms.CheckBox();
            this.chkProfessional = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewMemos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.salesData = new Guna.UI2.WinForms.Guna2DataGridView();
            this.saleItemsGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.VAT = new System.Windows.Forms.TextBox();
            this.vatableAmount = new System.Windows.Forms.TextBox();
            this.grossAmount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnReload = new Guna.UI2.WinForms.Guna2Button();
            this.Copy.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMemos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleItemsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Outfit Thin", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(17, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "CX ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ContextMenuStrip = this.Copy;
            this.label2.Font = new System.Drawing.Font("Outfit Thin Medium", 20F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label2_MouseUp);
            // 
            // Copy
            // 
            this.Copy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(103, 26);
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Phone Number :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(15, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Email Address    :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(17, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Address :";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.CausesValidation = false;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(131, 170);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(257, 19);
            this.textBox1.TabIndex = 7;
            this.textBox1.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.CausesValidation = false;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox2.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(131, 141);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(257, 19);
            this.textBox2.TabIndex = 8;
            this.textBox2.TabStop = false;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderRadius = 7;
            this.guna2GroupBox1.Controls.Add(this.gunaButton2);
            this.guna2GroupBox1.Controls.Add(this.gunaButton1);
            this.guna2GroupBox1.Controls.Add(this.textBox4);
            this.guna2GroupBox1.Controls.Add(this.label8);
            this.guna2GroupBox1.Controls.Add(this.textBox3);
            this.guna2GroupBox1.Controls.Add(this.label2);
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.Controls.Add(this.textBox2);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.Controls.Add(this.textBox1);
            this.guna2GroupBox1.Controls.Add(this.label4);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(29, 24);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(397, 290);
            this.guna2GroupBox1.TabIndex = 10;
            this.guna2GroupBox1.Text = "Customer Profile Tool";
            // 
            // gunaButton2
            // 
            this.gunaButton2.AnimationHoverSpeed = 0.07F;
            this.gunaButton2.AnimationSpeed = 0.03F;
            this.gunaButton2.BackColor = System.Drawing.Color.Transparent;
            this.gunaButton2.BaseColor = System.Drawing.Color.White;
            this.gunaButton2.BorderColor = System.Drawing.Color.Transparent;
            this.gunaButton2.BorderSize = 1;
            this.gunaButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton2.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaButton2.ForeColor = System.Drawing.Color.Black;
            this.gunaButton2.Image = null;
            this.gunaButton2.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton2.Location = new System.Drawing.Point(319, 7);
            this.gunaButton2.Name = "gunaButton2";
            this.gunaButton2.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.gunaButton2.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton2.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton2.OnHoverImage = null;
            this.gunaButton2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton2.Radius = 7;
            this.gunaButton2.Size = new System.Drawing.Size(72, 26);
            this.gunaButton2.TabIndex = 22;
            this.gunaButton2.Text = "Email";
            this.gunaButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaButton2.Click += new System.EventHandler(this.gunaButton2_Click);
            // 
            // gunaButton1
            // 
            this.gunaButton1.AnimationHoverSpeed = 0.07F;
            this.gunaButton1.AnimationSpeed = 0.03F;
            this.gunaButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaButton1.BaseColor = System.Drawing.Color.White;
            this.gunaButton1.BorderColor = System.Drawing.Color.Transparent;
            this.gunaButton1.BorderSize = 1;
            this.gunaButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaButton1.ForeColor = System.Drawing.Color.Black;
            this.gunaButton1.Image = null;
            this.gunaButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton1.Location = new System.Drawing.Point(243, 7);
            this.gunaButton1.Name = "gunaButton1";
            this.gunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.gunaButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton1.OnHoverImage = null;
            this.gunaButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton1.Radius = 7;
            this.gunaButton1.Size = new System.Drawing.Size(72, 26);
            this.gunaButton1.TabIndex = 21;
            this.gunaButton1.Text = "SMS";
            this.gunaButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaButton1.Click += new System.EventHandler(this.gunaButton1_Click);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.CausesValidation = false;
            this.textBox4.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox4.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.Black;
            this.textBox4.Location = new System.Drawing.Point(131, 113);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(257, 19);
            this.textBox4.TabIndex = 11;
            this.textBox4.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(15, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "Customer since  :";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.CausesValidation = false;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox3.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.Black;
            this.textBox3.Location = new System.Drawing.Point(91, 199);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(297, 70);
            this.textBox3.TabIndex = 10;
            this.textBox3.TabStop = false;
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.BorderRadius = 7;
            this.guna2GroupBox2.Controls.Add(this.chkPastDue);
            this.guna2GroupBox2.Controls.Add(this.chkPhone);
            this.guna2GroupBox2.Controls.Add(this.txtBalance);
            this.guna2GroupBox2.Controls.Add(this.txtPayments);
            this.guna2GroupBox2.Controls.Add(this.txtPayable);
            this.guna2GroupBox2.Controls.Add(this.txtBalance1);
            this.guna2GroupBox2.Controls.Add(this.txtPayable1);
            this.guna2GroupBox2.Controls.Add(this.txtPayments1);
            this.guna2GroupBox2.Controls.Add(this.chkEmail);
            this.guna2GroupBox2.Controls.Add(this.chkSMS);
            this.guna2GroupBox2.Controls.Add(this.chkProfessional);
            this.guna2GroupBox2.CustomBorderThickness = new System.Windows.Forms.Padding(0);
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox2.Location = new System.Drawing.Point(29, 320);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(397, 90);
            this.guna2GroupBox2.TabIndex = 15;
            // 
            // chkPastDue
            // 
            this.chkPastDue.AutoSize = true;
            this.chkPastDue.Location = new System.Drawing.Point(240, 13);
            this.chkPastDue.Name = "chkPastDue";
            this.chkPastDue.Size = new System.Drawing.Size(72, 19);
            this.chkPastDue.TabIndex = 16;
            this.chkPastDue.Text = "Past Due";
            this.chkPastDue.UseVisualStyleBackColor = true;
            this.chkPastDue.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // chkPhone
            // 
            this.chkPhone.AutoSize = true;
            this.chkPhone.Location = new System.Drawing.Point(348, 59);
            this.chkPhone.Name = "chkPhone";
            this.chkPhone.Size = new System.Drawing.Size(46, 19);
            this.chkPhone.TabIndex = 15;
            this.chkPhone.TabStop = false;
            this.chkPhone.Text = "Call";
            this.chkPhone.UseVisualStyleBackColor = true;
            this.chkPhone.Click += new System.EventHandler(this.chkPhone_Click);
            // 
            // txtBalance
            // 
            this.txtBalance.BackColor = System.Drawing.SystemColors.Menu;
            this.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBalance.CausesValidation = false;
            this.txtBalance.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtBalance.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.ForeColor = System.Drawing.Color.Black;
            this.txtBalance.Location = new System.Drawing.Point(121, 61);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(113, 19);
            this.txtBalance.TabIndex = 14;
            this.txtBalance.TabStop = false;
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPayments
            // 
            this.txtPayments.BackColor = System.Drawing.SystemColors.Menu;
            this.txtPayments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPayments.CausesValidation = false;
            this.txtPayments.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtPayments.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayments.ForeColor = System.Drawing.Color.Black;
            this.txtPayments.Location = new System.Drawing.Point(121, 36);
            this.txtPayments.Name = "txtPayments";
            this.txtPayments.ReadOnly = true;
            this.txtPayments.Size = new System.Drawing.Size(113, 19);
            this.txtPayments.TabIndex = 13;
            this.txtPayments.TabStop = false;
            this.txtPayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPayable
            // 
            this.txtPayable.BackColor = System.Drawing.SystemColors.Menu;
            this.txtPayable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPayable.CausesValidation = false;
            this.txtPayable.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtPayable.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayable.ForeColor = System.Drawing.Color.Black;
            this.txtPayable.Location = new System.Drawing.Point(121, 11);
            this.txtPayable.Name = "txtPayable";
            this.txtPayable.ReadOnly = true;
            this.txtPayable.Size = new System.Drawing.Size(113, 19);
            this.txtPayable.TabIndex = 12;
            this.txtPayable.TabStop = false;
            this.txtPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBalance1
            // 
            this.txtBalance1.AutoSize = true;
            this.txtBalance1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance1.Location = new System.Drawing.Point(8, 60);
            this.txtBalance1.Name = "txtBalance1";
            this.txtBalance1.Size = new System.Drawing.Size(116, 18);
            this.txtBalance1.TabIndex = 0;
            this.txtBalance1.Text = "Account Balance :";
            // 
            // txtPayable1
            // 
            this.txtPayable1.AutoSize = true;
            this.txtPayable1.Font = new System.Drawing.Font("Calibri", 11F);
            this.txtPayable1.Location = new System.Drawing.Point(9, 11);
            this.txtPayable1.Name = "txtPayable1";
            this.txtPayable1.Size = new System.Drawing.Size(115, 18);
            this.txtPayable1.TabIndex = 6;
            this.txtPayable1.Text = "Total Payable       :";
            // 
            // txtPayments1
            // 
            this.txtPayments1.AutoSize = true;
            this.txtPayments1.Font = new System.Drawing.Font("Calibri", 11F);
            this.txtPayments1.Location = new System.Drawing.Point(9, 35);
            this.txtPayments1.Name = "txtPayments1";
            this.txtPayments1.Size = new System.Drawing.Size(115, 18);
            this.txtPayments1.TabIndex = 5;
            this.txtPayments1.Text = "Total Payments   :";
            // 
            // chkEmail
            // 
            this.chkEmail.AutoSize = true;
            this.chkEmail.Location = new System.Drawing.Point(290, 59);
            this.chkEmail.Name = "chkEmail";
            this.chkEmail.Size = new System.Drawing.Size(55, 19);
            this.chkEmail.TabIndex = 4;
            this.chkEmail.Text = "Email";
            this.chkEmail.UseVisualStyleBackColor = true;
            this.chkEmail.Click += new System.EventHandler(this.chkEmail_Click);
            // 
            // chkSMS
            // 
            this.chkSMS.AutoSize = true;
            this.chkSMS.Location = new System.Drawing.Point(240, 59);
            this.chkSMS.Name = "chkSMS";
            this.chkSMS.Size = new System.Drawing.Size(49, 19);
            this.chkSMS.TabIndex = 3;
            this.chkSMS.Text = "SMS";
            this.chkSMS.UseVisualStyleBackColor = true;
            this.chkSMS.Click += new System.EventHandler(this.chkSMS_Click);
            // 
            // chkProfessional
            // 
            this.chkProfessional.AutoSize = true;
            this.chkProfessional.Location = new System.Drawing.Point(240, 35);
            this.chkProfessional.Name = "chkProfessional";
            this.chkProfessional.Size = new System.Drawing.Size(119, 19);
            this.chkProfessional.TabIndex = 2;
            this.chkProfessional.Text = "Professional/Firm";
            this.chkProfessional.UseVisualStyleBackColor = true;
            this.chkProfessional.Click += new System.EventHandler(this.chkProfessional_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(29, 416);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 48);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quick Actions Menu";
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(228, 17);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(77, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Validate";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(311, 17);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(77, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Add Memo";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(117, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Update Profle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(6, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Payment History";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelOrder.Location = new System.Drawing.Point(810, 55);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(92, 23);
            this.btnCancelOrder.TabIndex = 5;
            this.btnCancelOrder.Text = "Cancel Order";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(690, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "New Order";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewMemos
            // 
            this.dataGridViewMemos.AllowUserToAddRows = false;
            this.dataGridViewMemos.AllowUserToDeleteRows = false;
            this.dataGridViewMemos.AllowUserToResizeColumns = false;
            this.dataGridViewMemos.AllowUserToResizeRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            this.dataGridViewMemos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewMemos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMemos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewMemos.ColumnHeadersHeight = 18;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMemos.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewMemos.GridColor = System.Drawing.Color.LightGray;
            this.dataGridViewMemos.Location = new System.Drawing.Point(29, 466);
            this.dataGridViewMemos.Name = "dataGridViewMemos";
            this.dataGridViewMemos.ReadOnly = true;
            this.dataGridViewMemos.RowHeadersVisible = false;
            this.dataGridViewMemos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewMemos.Size = new System.Drawing.Size(397, 174);
            this.dataGridViewMemos.TabIndex = 14;
            this.dataGridViewMemos.TabStop = false;
            this.dataGridViewMemos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewMemos.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridViewMemos.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridViewMemos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridViewMemos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridViewMemos.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewMemos.ThemeStyle.GridColor = System.Drawing.Color.LightGray;
            this.dataGridViewMemos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewMemos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewMemos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewMemos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewMemos.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewMemos.ThemeStyle.HeaderStyle.Height = 18;
            this.dataGridViewMemos.ThemeStyle.ReadOnly = true;
            this.dataGridViewMemos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewMemos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewMemos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dataGridViewMemos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewMemos.ThemeStyle.RowsStyle.Height = 22;
            this.dataGridViewMemos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.SystemColors.Info;
            this.dataGridViewMemos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewMemos.SelectionChanged += new System.EventHandler(this.dataGridViewMemos_SelectionChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Outfit Thin Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(445, 440);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Interaction Notes";
            // 
            // txtMemo
            // 
            this.txtMemo.BackColor = System.Drawing.SystemColors.Menu;
            this.txtMemo.CausesValidation = false;
            this.txtMemo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtMemo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMemo.ForeColor = System.Drawing.Color.Black;
            this.txtMemo.Location = new System.Drawing.Point(449, 466);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.ReadOnly = true;
            this.txtMemo.Size = new System.Drawing.Size(453, 174);
            this.txtMemo.TabIndex = 12;
            this.txtMemo.TabStop = false;
            // 
            // salesData
            // 
            this.salesData.AllowUserToAddRows = false;
            this.salesData.AllowUserToDeleteRows = false;
            this.salesData.AllowUserToResizeColumns = false;
            this.salesData.AllowUserToResizeRows = false;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.White;
            this.salesData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            this.salesData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.salesData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.salesData.ColumnHeadersHeight = 18;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.salesData.DefaultCellStyle = dataGridViewCellStyle24;
            this.salesData.GridColor = System.Drawing.Color.LightGray;
            this.salesData.Location = new System.Drawing.Point(449, 82);
            this.salesData.Name = "salesData";
            this.salesData.ReadOnly = true;
            this.salesData.RowHeadersVisible = false;
            this.salesData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.salesData.Size = new System.Drawing.Size(453, 127);
            this.salesData.TabIndex = 18;
            this.salesData.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.salesData.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.salesData.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.salesData.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.salesData.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.salesData.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.salesData.ThemeStyle.GridColor = System.Drawing.Color.LightGray;
            this.salesData.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.salesData.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.salesData.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesData.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.salesData.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.salesData.ThemeStyle.HeaderStyle.Height = 18;
            this.salesData.ThemeStyle.ReadOnly = true;
            this.salesData.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.salesData.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.salesData.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.salesData.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.salesData.ThemeStyle.RowsStyle.Height = 22;
            this.salesData.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.SystemColors.Info;
            this.salesData.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.salesData.SelectionChanged += new System.EventHandler(this.salesData_SelectionChanged);
            // 
            // saleItemsGrid
            // 
            this.saleItemsGrid.AllowUserToAddRows = false;
            this.saleItemsGrid.AllowUserToDeleteRows = false;
            this.saleItemsGrid.AllowUserToResizeColumns = false;
            this.saleItemsGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.White;
            this.saleItemsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.saleItemsGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.saleItemsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.saleItemsGrid.ColumnHeadersHeight = 18;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.saleItemsGrid.DefaultCellStyle = dataGridViewCellStyle27;
            this.saleItemsGrid.GridColor = System.Drawing.Color.LightGray;
            this.saleItemsGrid.Location = new System.Drawing.Point(449, 208);
            this.saleItemsGrid.Name = "saleItemsGrid";
            this.saleItemsGrid.ReadOnly = true;
            this.saleItemsGrid.RowHeadersVisible = false;
            this.saleItemsGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.saleItemsGrid.Size = new System.Drawing.Size(453, 183);
            this.saleItemsGrid.TabIndex = 19;
            this.saleItemsGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.saleItemsGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.saleItemsGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.saleItemsGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.saleItemsGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.saleItemsGrid.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.saleItemsGrid.ThemeStyle.GridColor = System.Drawing.Color.LightGray;
            this.saleItemsGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.saleItemsGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.saleItemsGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleItemsGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.saleItemsGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.saleItemsGrid.ThemeStyle.HeaderStyle.Height = 18;
            this.saleItemsGrid.ThemeStyle.ReadOnly = true;
            this.saleItemsGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.saleItemsGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.saleItemsGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.saleItemsGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.saleItemsGrid.ThemeStyle.RowsStyle.Height = 22;
            this.saleItemsGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.SystemColors.Info;
            this.saleItemsGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Outfit Thin Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(445, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Order History";
            // 
            // VAT
            // 
            this.VAT.BackColor = System.Drawing.SystemColors.Menu;
            this.VAT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VAT.CausesValidation = false;
            this.VAT.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.VAT.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VAT.ForeColor = System.Drawing.Color.Black;
            this.VAT.Location = new System.Drawing.Point(783, 433);
            this.VAT.Name = "VAT";
            this.VAT.ReadOnly = true;
            this.VAT.Size = new System.Drawing.Size(113, 16);
            this.VAT.TabIndex = 22;
            this.VAT.TabStop = false;
            this.VAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // vatableAmount
            // 
            this.vatableAmount.BackColor = System.Drawing.SystemColors.Menu;
            this.vatableAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vatableAmount.CausesValidation = false;
            this.vatableAmount.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.vatableAmount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vatableAmount.ForeColor = System.Drawing.Color.Black;
            this.vatableAmount.Location = new System.Drawing.Point(783, 414);
            this.vatableAmount.Name = "vatableAmount";
            this.vatableAmount.ReadOnly = true;
            this.vatableAmount.Size = new System.Drawing.Size(113, 16);
            this.vatableAmount.TabIndex = 21;
            this.vatableAmount.TabStop = false;
            this.vatableAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grossAmount
            // 
            this.grossAmount.BackColor = System.Drawing.SystemColors.Menu;
            this.grossAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grossAmount.CausesValidation = false;
            this.grossAmount.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.grossAmount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grossAmount.ForeColor = System.Drawing.Color.Black;
            this.grossAmount.Location = new System.Drawing.Point(783, 394);
            this.grossAmount.Name = "grossAmount";
            this.grossAmount.ReadOnly = true;
            this.grossAmount.Size = new System.Drawing.Size(113, 16);
            this.grossAmount.TabIndex = 20;
            this.grossAmount.TabStop = false;
            this.grossAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(660, 433);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "VAT Amount               :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(660, 394);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 15);
            this.label10.TabIndex = 19;
            this.label10.Text = "Gross Amount          :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(661, 415);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "Vatable Amount       :";
            // 
            // btnReload
            // 
            this.btnReload.BorderRadius = 5;
            this.btnReload.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReload.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReload.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReload.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReload.FillColor = System.Drawing.Color.Silver;
            this.btnReload.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.Location = new System.Drawing.Point(449, 24);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(129, 26);
            this.btnReload.TabIndex = 23;
            this.btnReload.Text = "Reload Data";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(926, 667);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.VAT);
            this.Controls.Add(this.btnCancelOrder);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.vatableAmount);
            this.Controls.Add(this.grossAmount);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.saleItemsGrid);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.salesData);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.dataGridViewMemos);
            this.Controls.Add(this.guna2GroupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOrder";
            this.Text = "FormOrder";
            this.Load += new System.EventHandler(this.FormOrder_Load);
            this.Copy.ResumeLayout(false);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMemos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleItemsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridViewMemos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ContextMenuStrip Copy;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label txtBalance1;
        private System.Windows.Forms.CheckBox chkSMS;
        private System.Windows.Forms.CheckBox chkProfessional;
        private System.Windows.Forms.CheckBox chkEmail;
        private System.Windows.Forms.Label txtPayable1;
        private System.Windows.Forms.Label txtPayments1;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.TextBox txtPayments;
        private System.Windows.Forms.TextBox txtPayable;
        private System.Windows.Forms.TextBox txtMemo;
        private Guna.UI2.WinForms.Guna2DataGridView salesData;
        private Guna.UI2.WinForms.Guna2DataGridView saleItemsGrid;
        private System.Windows.Forms.CheckBox chkPhone;
        private System.Windows.Forms.CheckBox chkPastDue;
        private Guna.UI.WinForms.GunaButton gunaButton1;
        private Guna.UI.WinForms.GunaButton gunaButton2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox VAT;
        private System.Windows.Forms.TextBox vatableAmount;
        private System.Windows.Forms.TextBox grossAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button6;
        private Guna.UI2.WinForms.Guna2Button btnReload;
    }
}