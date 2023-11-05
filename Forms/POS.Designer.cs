namespace Dashboard.Forms
{
    partial class POS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POS));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TimeDate = new System.Windows.Forms.Label();
            this.txt_Role = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.BacktoForm = new System.Windows.Forms.Button();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnNewTransaction = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtTransactionID = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtVAT = new System.Windows.Forms.Label();
            this.txtVatable = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.Label();
            this.txttotal = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.orderGrid = new System.Windows.Forms.DataGridView();
            this.btnXColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(52)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblTotalAmount);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(999, 58);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.label4.Location = new System.Drawing.Point(720, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 56);
            this.label4.TabIndex = 5;
            this.label4.Text = "₱";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Consolas", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.lblTotalAmount.Location = new System.Drawing.Point(721, 2);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(278, 56);
            this.lblTotalAmount.TabIndex = 4;
            this.lblTotalAmount.Text = "0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(306, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "●     POINT OF SALE     ●";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Outfit Thin SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(74, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "New Bernales Hardware Store";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Controls.Add(this.TimeDate);
            this.panel4.Controls.Add(this.txt_Role);
            this.panel4.Controls.Add(this.txt_Name);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 603);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(999, 25);
            this.panel4.TabIndex = 4;
            // 
            // TimeDate
            // 
            this.TimeDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TimeDate.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F);
            this.TimeDate.ForeColor = System.Drawing.Color.White;
            this.TimeDate.Location = new System.Drawing.Point(709, 2);
            this.TimeDate.Name = "TimeDate";
            this.TimeDate.Size = new System.Drawing.Size(287, 23);
            this.TimeDate.TabIndex = 37;
            this.TimeDate.Text = "label21";
            this.TimeDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_Role
            // 
            this.txt_Role.AutoSize = true;
            this.txt_Role.Font = new System.Drawing.Font("Outfit Thin SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.txt_Role.ForeColor = System.Drawing.Color.White;
            this.txt_Role.Location = new System.Drawing.Point(399, 3);
            this.txt_Role.Name = "txt_Role";
            this.txt_Role.Size = new System.Drawing.Size(40, 19);
            this.txt_Role.TabIndex = 36;
            this.txt_Role.Text = "Role";
            // 
            // txt_Name
            // 
            this.txt_Name.AutoSize = true;
            this.txt_Name.Font = new System.Drawing.Font("Outfit Thin SemiBold", 11.25F, System.Drawing.FontStyle.Bold);
            this.txt_Name.ForeColor = System.Drawing.Color.White;
            this.txt_Name.Location = new System.Drawing.Point(48, 3);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(50, 19);
            this.txt_Name.TabIndex = 35;
            this.txt_Name.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(318, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "Designation :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(3, 5);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 16);
            this.label17.TabIndex = 33;
            this.label17.Text = "Name :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel2.Controls.Add(this.btnCreateOrder);
            this.panel2.Controls.Add(this.BacktoForm);
            this.panel2.Controls.Add(this.btnDiscount);
            this.panel2.Controls.Add(this.btnAddItem);
            this.panel2.Controls.Add(this.btnNewTransaction);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.txtVAT);
            this.panel2.Controls.Add(this.txtVatable);
            this.panel2.Controls.Add(this.txtDiscount);
            this.panel2.Controls.Add(this.txttotal);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(730, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 545);
            this.panel2.TabIndex = 5;
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(165)))), ((int)(((byte)(217)))));
            this.btnCreateOrder.Enabled = false;
            this.btnCreateOrder.FlatAppearance.BorderSize = 0;
            this.btnCreateOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateOrder.Font = new System.Drawing.Font("Outfit Thin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateOrder.ForeColor = System.Drawing.Color.White;
            this.btnCreateOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateOrder.Image")));
            this.btnCreateOrder.Location = new System.Drawing.Point(10, 406);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnCreateOrder.Size = new System.Drawing.Size(251, 57);
            this.btnCreateOrder.TabIndex = 13;
            this.btnCreateOrder.Text = "     [F4]  Create Order";
            this.btnCreateOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateOrder.UseVisualStyleBackColor = false;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // BacktoForm
            // 
            this.BacktoForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(165)))), ((int)(((byte)(217)))));
            this.BacktoForm.FlatAppearance.BorderSize = 0;
            this.BacktoForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BacktoForm.Font = new System.Drawing.Font("Outfit Thin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BacktoForm.ForeColor = System.Drawing.Color.White;
            this.BacktoForm.Image = ((System.Drawing.Image)(resources.GetObject("BacktoForm.Image")));
            this.BacktoForm.Location = new System.Drawing.Point(10, 469);
            this.BacktoForm.Name = "BacktoForm";
            this.BacktoForm.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.BacktoForm.Size = new System.Drawing.Size(251, 57);
            this.BacktoForm.TabIndex = 12;
            this.BacktoForm.Text = "     [F5]  Back to Dashboard";
            this.BacktoForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BacktoForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BacktoForm.UseVisualStyleBackColor = false;
            this.BacktoForm.Click += new System.EventHandler(this.BacktoForm_Click);
            // 
            // btnDiscount
            // 
            this.btnDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(165)))), ((int)(((byte)(217)))));
            this.btnDiscount.Enabled = false;
            this.btnDiscount.FlatAppearance.BorderSize = 0;
            this.btnDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscount.Font = new System.Drawing.Font("Outfit Thin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscount.ForeColor = System.Drawing.Color.White;
            this.btnDiscount.Image = ((System.Drawing.Image)(resources.GetObject("btnDiscount.Image")));
            this.btnDiscount.Location = new System.Drawing.Point(10, 343);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnDiscount.Size = new System.Drawing.Size(251, 57);
            this.btnDiscount.TabIndex = 11;
            this.btnDiscount.Text = "     [F3]  Add Discount";
            this.btnDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiscount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDiscount.UseVisualStyleBackColor = false;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(165)))), ((int)(((byte)(217)))));
            this.btnAddItem.FlatAppearance.BorderSize = 0;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Outfit Thin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            this.btnAddItem.Location = new System.Drawing.Point(10, 280);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(251, 57);
            this.btnAddItem.TabIndex = 10;
            this.btnAddItem.Text = "    [F2]  Add Items";
            this.btnAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnNewTransaction
            // 
            this.btnNewTransaction.BackColor = System.Drawing.Color.Orange;
            this.btnNewTransaction.FlatAppearance.BorderSize = 0;
            this.btnNewTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewTransaction.Font = new System.Drawing.Font("Outfit Thin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewTransaction.ForeColor = System.Drawing.Color.White;
            this.btnNewTransaction.Image = ((System.Drawing.Image)(resources.GetObject("btnNewTransaction.Image")));
            this.btnNewTransaction.Location = new System.Drawing.Point(10, 217);
            this.btnNewTransaction.Name = "btnNewTransaction";
            this.btnNewTransaction.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNewTransaction.Size = new System.Drawing.Size(251, 57);
            this.btnNewTransaction.TabIndex = 9;
            this.btnNewTransaction.Text = "    [F1]  New Transaction";
            this.btnNewTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewTransaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNewTransaction.UseVisualStyleBackColor = false;
            this.btnNewTransaction.Click += new System.EventHandler(this.btnNewTransaction_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(165)))), ((int)(((byte)(217)))));
            this.panel5.Controls.Add(this.txtTransactionID);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Font = new System.Drawing.Font("Outfit Thin SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(10, 123);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(251, 88);
            this.panel5.TabIndex = 8;
            // 
            // txtTransactionID
            // 
            this.txtTransactionID.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransactionID.ForeColor = System.Drawing.Color.White;
            this.txtTransactionID.Location = new System.Drawing.Point(0, 40);
            this.txtTransactionID.Name = "txtTransactionID";
            this.txtTransactionID.Size = new System.Drawing.Size(251, 19);
            this.txtTransactionID.TabIndex = 1;
            this.txtTransactionID.Text = "No Transaction.";
            this.txtTransactionID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(11, 6);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(103, 15);
            this.label18.TabIndex = 0;
            this.label18.Text = "TRANSACTION ID :";
            // 
            // txtVAT
            // 
            this.txtVAT.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVAT.ForeColor = System.Drawing.Color.White;
            this.txtVAT.Location = new System.Drawing.Point(146, 90);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(111, 20);
            this.txtVAT.TabIndex = 7;
            this.txtVAT.Text = "0.00";
            this.txtVAT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVatable
            // 
            this.txtVatable.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVatable.ForeColor = System.Drawing.Color.White;
            this.txtVatable.Location = new System.Drawing.Point(146, 70);
            this.txtVatable.Name = "txtVatable";
            this.txtVatable.Size = new System.Drawing.Size(111, 20);
            this.txtVatable.TabIndex = 6;
            this.txtVatable.Text = "0.00";
            this.txtVatable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.ForeColor = System.Drawing.Color.White;
            this.txtDiscount.Location = new System.Drawing.Point(146, 50);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(111, 20);
            this.txtDiscount.TabIndex = 5;
            this.txtDiscount.Text = "0.00";
            this.txtDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txttotal
            // 
            this.txttotal.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotal.ForeColor = System.Drawing.Color.White;
            this.txttotal.Location = new System.Drawing.Point(146, 20);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(111, 20);
            this.txttotal.TabIndex = 4;
            this.txttotal.Text = "0.00";
            this.txttotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Outfit Thin", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(16, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 16);
            this.label13.TabIndex = 3;
            this.label13.Text = "VAT";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Outfit Thin", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(16, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "Vatable Amount";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Outfit Thin", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(16, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "Discount";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Outfit Thin SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(15, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "TOTAL";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.Controls.Add(this.txtSubtotal);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtUnitPrice);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtQuantity);
            this.panel3.Controls.Add(this.txtDescription);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtProductId);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("Cascadia Code", 9.75F, System.Drawing.FontStyle.Bold);
            this.panel3.Location = new System.Drawing.Point(0, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(730, 81);
            this.panel3.TabIndex = 6;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubtotal.Location = new System.Drawing.Point(608, 45);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(100, 23);
            this.txtSubtotal.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cascadia Code SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(498, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "SUBTOTAL   :";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnitPrice.Location = new System.Drawing.Point(608, 16);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.ReadOnly = true;
            this.txtUnitPrice.Size = new System.Drawing.Size(100, 23);
            this.txtUnitPrice.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cascadia Code SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(498, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "UNIT PRICE :";
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Location = new System.Drawing.Point(378, 16);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(100, 23);
            this.txtQuantity.TabIndex = 5;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(151, 45);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(327, 23);
            this.txtDescription.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cascadia Code SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(292, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "QUANTITY:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cascadia Code SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "DESCRIPTION  :";
            // 
            // txtProductId
            // 
            this.txtProductId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductId.Location = new System.Drawing.Point(151, 16);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.ReadOnly = true;
            this.txtProductId.Size = new System.Drawing.Size(112, 23);
            this.txtProductId.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Code SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "PRODUCT CODE :";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "X";
            this.dataGridViewImageColumn1.Image = global::Dashboard.Properties.Resources.bin;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 35;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.DimGray;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(602, 139);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(128, 25);
            this.label20.TabIndex = 29;
            this.label20.Text = "Subtotal";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DimGray;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(469, 139);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(68, 25);
            this.label21.TabIndex = 28;
            this.label21.Text = "Price";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.DimGray;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(224, 139);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(250, 25);
            this.label22.TabIndex = 27;
            this.label22.Text = "Description";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.DimGray;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(94, 139);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(130, 25);
            this.label23.TabIndex = 26;
            this.label23.Text = "Item";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.DimGray;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(24, 139);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(70, 25);
            this.label24.TabIndex = 25;
            this.label24.Text = "Product ID";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.DimGray;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(0, 139);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(30, 25);
            this.label25.TabIndex = 24;
            this.label25.Text = "#";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.DimGray;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(532, 139);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(70, 25);
            this.label26.TabIndex = 30;
            this.label26.Text = "Quantity";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // orderGrid
            // 
            this.orderGrid.AllowUserToAddRows = false;
            this.orderGrid.AllowUserToDeleteRows = false;
            this.orderGrid.AllowUserToResizeColumns = false;
            this.orderGrid.AllowUserToResizeRows = false;
            this.orderGrid.BackgroundColor = System.Drawing.Color.White;
            this.orderGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.orderGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.orderGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.orderGrid.ColumnHeadersHeight = 25;
            this.orderGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.orderGrid.ColumnHeadersVisible = false;
            this.orderGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnXColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.orderGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.orderGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.orderGrid.Location = new System.Drawing.Point(0, 163);
            this.orderGrid.Name = "orderGrid";
            this.orderGrid.RowHeadersVisible = false;
            this.orderGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.orderGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.orderGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.orderGrid.ShowCellErrors = false;
            this.orderGrid.ShowCellToolTips = false;
            this.orderGrid.ShowEditingIcon = false;
            this.orderGrid.ShowRowErrors = false;
            this.orderGrid.Size = new System.Drawing.Size(730, 436);
            this.orderGrid.TabIndex = 31;
            this.orderGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderGrid_CellContentClick);
            this.orderGrid.SelectionChanged += new System.EventHandler(this.orderGrid_SelectionChanged);
            // 
            // btnXColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.btnXColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnXColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXColumn.HeaderText = " ";
            this.btnXColumn.Name = "btnXColumn";
            this.btnXColumn.Text = "X";
            this.btnXColumn.UseColumnTextForButtonValue = true;
            this.btnXColumn.Width = 55;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // POS
            // 
            this.AcceptButton = this.btnNewTransaction;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(999, 628);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.orderGrid);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "POS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.POS_FormClosed);
            this.Load += new System.EventHandler(this.POS_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.POS_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label txtVAT;
        private System.Windows.Forms.Label txtVatable;
        private System.Windows.Forms.Label txtDiscount;
        private System.Windows.Forms.Label txttotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label txtTransactionID;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnNewTransaction;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button BacktoForm;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DataGridView orderGrid;
        private System.Windows.Forms.DataGridViewButtonColumn btnXColumn;
        private System.Windows.Forms.Label TimeDate;
        private System.Windows.Forms.Label txt_Role;
        private System.Windows.Forms.Label txt_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label17;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}