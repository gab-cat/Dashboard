namespace Dashboard.Forms
{
    partial class FormInventory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInventory));
            this.btnSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.cboxFilter = new System.Windows.Forms.ComboBox();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.cboxProductCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSellingPrice = new System.Windows.Forms.TextBox();
            this.txtCostPrice = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtQuantityInStock = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxSupplierProduct = new System.Windows.Forms.ComboBox();
            this.btnNewSupplier = new System.Windows.Forms.Button();
            this.btnUpdateSupplier = new System.Windows.Forms.Button();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.btnDeleteSupplier = new System.Windows.Forms.Button();
            this.btnAddInvMemo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ProductGrid = new System.Windows.Forms.DataGridView();
            this.btnNewProduct = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.gunaDataGridView1 = new Guna.UI.WinForms.GunaDataGridView();
            this.txtMemo = new System.Windows.Forms.RichTextBox();
            this.dgvPriceHistory = new System.Windows.Forms.DataGridView();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.button1 = new Guna.UI.WinForms.GunaCircleButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(448, 20);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 27);
            this.btnSearch.TabIndex = 59;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Outfit Thin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(188, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 58;
            this.label7.Text = "Search Term :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Outfit Thin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(13, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 57;
            this.label6.Text = "Filter by :";
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.BackColor = System.Drawing.Color.White;
            this.txtSearchTerm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchTerm.CausesValidation = false;
            this.txtSearchTerm.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSearchTerm.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchTerm.ForeColor = System.Drawing.Color.Black;
            this.txtSearchTerm.Location = new System.Drawing.Point(295, 20);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(148, 26);
            this.txtSearchTerm.TabIndex = 56;
            this.txtSearchTerm.TabStop = false;
            this.txtSearchTerm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchTerm_KeyDown);
            // 
            // cboxFilter
            // 
            this.cboxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxFilter.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboxFilter.FormattingEnabled = true;
            this.cboxFilter.Items.AddRange(new object[] {
            "Product ID",
            "Category",
            "Item Name",
            "Supplier ID"});
            this.cboxFilter.Location = new System.Drawing.Point(84, 20);
            this.cboxFilter.Name = "cboxFilter";
            this.cboxFilter.Size = new System.Drawing.Size(102, 26);
            this.cboxFilter.TabIndex = 55;
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteProduct.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteProduct.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteProduct.Location = new System.Drawing.Point(447, 67);
            this.btnDeleteProduct.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(81, 27);
            this.btnDeleteProduct.TabIndex = 60;
            this.btnDeleteProduct.Text = "Delete";
            this.btnDeleteProduct.UseVisualStyleBackColor = true;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateProduct.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateProduct.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateProduct.Location = new System.Drawing.Point(341, 67);
            this.btnUpdateProduct.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(102, 27);
            this.btnUpdateProduct.TabIndex = 61;
            this.btnUpdateProduct.Text = "Update Item";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // cboxProductCategory
            // 
            this.cboxProductCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxProductCategory.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboxProductCategory.FormattingEnabled = true;
            this.cboxProductCategory.Items.AddRange(new object[] {
            "First Name",
            "Last Name",
            "Customer ID",
            "Phone Number",
            "Email Address",
            "Address"});
            this.cboxProductCategory.Location = new System.Drawing.Point(12, 67);
            this.cboxProductCategory.Name = "cboxProductCategory";
            this.cboxProductCategory.Size = new System.Drawing.Size(161, 26);
            this.cboxProductCategory.TabIndex = 63;
            this.cboxProductCategory.SelectedIndexChanged += new System.EventHandler(this.cboxProductCategory_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Outfit Thin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 489);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 65;
            this.label1.Text = "Inventory Notes ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.txtSellingPrice);
            this.groupBox1.Controls.Add(this.txtCostPrice);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.txtCategory);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.txtQuantityInStock);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAddQuantity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboxSupplierProduct);
            this.groupBox1.Controls.Add(this.btnNewSupplier);
            this.groupBox1.Controls.Add(this.btnUpdateSupplier);
            this.groupBox1.Controls.Add(this.btnAddStock);
            this.groupBox1.Controls.Add(this.btnDeleteSupplier);
            this.groupBox1.Location = new System.Drawing.Point(534, 228);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 427);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supplier / Stock Management";
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSellingPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSellingPrice.CausesValidation = false;
            this.txtSellingPrice.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSellingPrice.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellingPrice.ForeColor = System.Drawing.Color.Black;
            this.txtSellingPrice.Location = new System.Drawing.Point(129, 311);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.ReadOnly = true;
            this.txtSellingPrice.Size = new System.Drawing.Size(244, 19);
            this.txtSellingPrice.TabIndex = 81;
            this.txtSellingPrice.TabStop = false;
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.BackColor = System.Drawing.SystemColors.Menu;
            this.txtCostPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCostPrice.CausesValidation = false;
            this.txtCostPrice.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtCostPrice.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostPrice.ForeColor = System.Drawing.Color.Black;
            this.txtCostPrice.Location = new System.Drawing.Point(129, 286);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.ReadOnly = true;
            this.txtCostPrice.Size = new System.Drawing.Size(244, 19);
            this.txtCostPrice.TabIndex = 80;
            this.txtCostPrice.TabStop = false;
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.SystemColors.Menu;
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductName.CausesValidation = false;
            this.txtProductName.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtProductName.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.ForeColor = System.Drawing.Color.Black;
            this.txtProductName.Location = new System.Drawing.Point(130, 259);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(244, 19);
            this.txtProductName.TabIndex = 79;
            this.txtProductName.TabStop = false;
            // 
            // txtCategory
            // 
            this.txtCategory.BackColor = System.Drawing.SystemColors.Menu;
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCategory.CausesValidation = false;
            this.txtCategory.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtCategory.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.ForeColor = System.Drawing.Color.Black;
            this.txtCategory.Location = new System.Drawing.Point(130, 232);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(244, 19);
            this.txtCategory.TabIndex = 78;
            this.txtCategory.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.Menu;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.CausesValidation = false;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDescription.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.Location = new System.Drawing.Point(129, 365);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(244, 19);
            this.txtDescription.TabIndex = 77;
            this.txtDescription.TabStop = false;
            // 
            // txtQuantityInStock
            // 
            this.txtQuantityInStock.BackColor = System.Drawing.SystemColors.Menu;
            this.txtQuantityInStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantityInStock.CausesValidation = false;
            this.txtQuantityInStock.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtQuantityInStock.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantityInStock.ForeColor = System.Drawing.Color.Black;
            this.txtQuantityInStock.Location = new System.Drawing.Point(129, 338);
            this.txtQuantityInStock.Name = "txtQuantityInStock";
            this.txtQuantityInStock.ReadOnly = true;
            this.txtQuantityInStock.Size = new System.Drawing.Size(244, 19);
            this.txtQuantityInStock.TabIndex = 76;
            this.txtQuantityInStock.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(6, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 19);
            this.label10.TabIndex = 75;
            this.label10.Text = "Cost Price                :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(6, 311);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 19);
            this.label9.TabIndex = 74;
            this.label9.Text = "Selling Price            :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(6, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 19);
            this.label8.TabIndex = 73;
            this.label8.Text = "Quantity in Stock :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 19);
            this.label5.TabIndex = 72;
            this.label5.Text = "Category                 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 19);
            this.label4.TabIndex = 71;
            this.label4.Text = "Description             :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 19);
            this.label3.TabIndex = 67;
            this.label3.Text = "Product Name      :";
            // 
            // txtAddQuantity
            // 
            this.txtAddQuantity.BackColor = System.Drawing.Color.White;
            this.txtAddQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddQuantity.CausesValidation = false;
            this.txtAddQuantity.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtAddQuantity.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddQuantity.ForeColor = System.Drawing.Color.Black;
            this.txtAddQuantity.Location = new System.Drawing.Point(213, 199);
            this.txtAddQuantity.Name = "txtAddQuantity";
            this.txtAddQuantity.Size = new System.Drawing.Size(160, 26);
            this.txtAddQuantity.TabIndex = 67;
            this.txtAddQuantity.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Outfit Thin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(137, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 67;
            this.label2.Text = "Quantity :";
            // 
            // cboxSupplierProduct
            // 
            this.cboxSupplierProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSupplierProduct.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboxSupplierProduct.FormattingEnabled = true;
            this.cboxSupplierProduct.Items.AddRange(new object[] {
            "First Name",
            "Last Name",
            "Customer ID",
            "Phone Number",
            "Email Address",
            "Address"});
            this.cboxSupplierProduct.Location = new System.Drawing.Point(6, 199);
            this.cboxSupplierProduct.Name = "cboxSupplierProduct";
            this.cboxSupplierProduct.Size = new System.Drawing.Size(127, 26);
            this.cboxSupplierProduct.TabIndex = 67;
            // 
            // btnNewSupplier
            // 
            this.btnNewSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewSupplier.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewSupplier.ForeColor = System.Drawing.Color.Black;
            this.btnNewSupplier.Location = new System.Drawing.Point(115, 146);
            this.btnNewSupplier.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNewSupplier.Name = "btnNewSupplier";
            this.btnNewSupplier.Size = new System.Drawing.Size(81, 27);
            this.btnNewSupplier.TabIndex = 70;
            this.btnNewSupplier.Text = "New";
            this.btnNewSupplier.UseVisualStyleBackColor = true;
            // 
            // btnUpdateSupplier
            // 
            this.btnUpdateSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSupplier.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateSupplier.ForeColor = System.Drawing.Color.Black;
            this.btnUpdateSupplier.Location = new System.Drawing.Point(204, 146);
            this.btnUpdateSupplier.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUpdateSupplier.Name = "btnUpdateSupplier";
            this.btnUpdateSupplier.Size = new System.Drawing.Size(81, 27);
            this.btnUpdateSupplier.TabIndex = 69;
            this.btnUpdateSupplier.Text = "Update";
            this.btnUpdateSupplier.UseVisualStyleBackColor = true;
            // 
            // btnAddStock
            // 
            this.btnAddStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStock.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStock.ForeColor = System.Drawing.Color.Black;
            this.btnAddStock.Location = new System.Drawing.Point(281, 390);
            this.btnAddStock.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(92, 27);
            this.btnAddStock.TabIndex = 68;
            this.btnAddStock.Text = "Add Stock";
            this.btnAddStock.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSupplier
            // 
            this.btnDeleteSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSupplier.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSupplier.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteSupplier.Location = new System.Drawing.Point(293, 146);
            this.btnDeleteSupplier.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDeleteSupplier.Name = "btnDeleteSupplier";
            this.btnDeleteSupplier.Size = new System.Drawing.Size(81, 27);
            this.btnDeleteSupplier.TabIndex = 67;
            this.btnDeleteSupplier.Text = "Delete";
            this.btnDeleteSupplier.UseVisualStyleBackColor = true;
            // 
            // btnAddInvMemo
            // 
            this.btnAddInvMemo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddInvMemo.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInvMemo.ForeColor = System.Drawing.Color.Black;
            this.btnAddInvMemo.Location = new System.Drawing.Point(343, 485);
            this.btnAddInvMemo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddInvMemo.Name = "btnAddInvMemo";
            this.btnAddInvMemo.Size = new System.Drawing.Size(184, 27);
            this.btnAddInvMemo.TabIndex = 72;
            this.btnAddInvMemo.Text = "Add Memo";
            this.btnAddInvMemo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblLastUpdate);
            this.groupBox2.Controls.Add(this.lblProductName);
            this.groupBox2.Controls.Add(this.txtMemo);
            this.groupBox2.Location = new System.Drawing.Point(534, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 202);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Price History";
            // 
            // ProductGrid
            // 
            this.ProductGrid.AllowUserToAddRows = false;
            this.ProductGrid.AllowUserToDeleteRows = false;
            this.ProductGrid.AllowUserToResizeColumns = false;
            this.ProductGrid.AllowUserToResizeRows = false;
            this.ProductGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.ProductGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProductGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ProductGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.ProductGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.ProductGrid.EnableHeadersVisualStyles = false;
            this.ProductGrid.Location = new System.Drawing.Point(12, 100);
            this.ProductGrid.Name = "ProductGrid";
            this.ProductGrid.ReadOnly = true;
            this.ProductGrid.RowHeadersVisible = false;
            this.ProductGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductGrid.ShowCellErrors = false;
            this.ProductGrid.ShowCellToolTips = false;
            this.ProductGrid.ShowEditingIcon = false;
            this.ProductGrid.Size = new System.Drawing.Size(516, 379);
            this.ProductGrid.TabIndex = 74;
            this.ProductGrid.SelectionChanged += new System.EventHandler(this.ProductGrid_SelectionChanged);
            // 
            // btnNewProduct
            // 
            this.btnNewProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewProduct.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewProduct.ForeColor = System.Drawing.Color.Black;
            this.btnNewProduct.Location = new System.Drawing.Point(235, 67);
            this.btnNewProduct.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNewProduct.Name = "btnNewProduct";
            this.btnNewProduct.Size = new System.Drawing.Size(102, 27);
            this.btnNewProduct.TabIndex = 62;
            this.btnNewProduct.Text = "New Item";
            this.btnNewProduct.UseVisualStyleBackColor = true;
            this.btnNewProduct.Click += new System.EventHandler(this.btnNewProduct_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(10, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(363, 121);
            this.dataGridView1.TabIndex = 76;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(343, 518);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(186, 130);
            this.richTextBox1.TabIndex = 76;
            this.richTextBox1.Text = "";
            // 
            // gunaDataGridView1
            // 
            this.gunaDataGridView1.AllowUserToAddRows = false;
            this.gunaDataGridView1.AllowUserToDeleteRows = false;
            this.gunaDataGridView1.AllowUserToResizeColumns = false;
            this.gunaDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.gunaDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gunaDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gunaDataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.gunaDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gunaDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gunaDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gunaDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gunaDataGridView1.ColumnHeadersHeight = 25;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gunaDataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.gunaDataGridView1.EnableHeadersVisualStyles = false;
            this.gunaDataGridView1.GridColor = System.Drawing.Color.Silver;
            this.gunaDataGridView1.Location = new System.Drawing.Point(12, 518);
            this.gunaDataGridView1.Name = "gunaDataGridView1";
            this.gunaDataGridView1.ReadOnly = true;
            this.gunaDataGridView1.RowHeadersVisible = false;
            this.gunaDataGridView1.RowTemplate.Height = 20;
            this.gunaDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gunaDataGridView1.Size = new System.Drawing.Size(331, 130);
            this.gunaDataGridView1.TabIndex = 73;
            this.gunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.gunaDataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gunaDataGridView1.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaDataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gunaDataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.SystemColors.Info;
            this.gunaDataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gunaDataGridView1.ThemeStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.gunaDataGridView1.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.Height = 25;
            this.gunaDataGridView1.ThemeStyle.ReadOnly = true;
            this.gunaDataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gunaDataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gunaDataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaDataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gunaDataGridView1.ThemeStyle.RowsStyle.Height = 20;
            this.gunaDataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.SystemColors.Info;
            this.gunaDataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // txtMemo
            // 
            this.txtMemo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMemo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMemo.Location = new System.Drawing.Point(202, 47);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.ReadOnly = true;
            this.txtMemo.Size = new System.Drawing.Size(171, 148);
            this.txtMemo.TabIndex = 77;
            this.txtMemo.Text = "";
            // 
            // dgvPriceHistory
            // 
            this.dgvPriceHistory.AllowUserToAddRows = false;
            this.dgvPriceHistory.AllowUserToDeleteRows = false;
            this.dgvPriceHistory.AllowUserToResizeColumns = false;
            this.dgvPriceHistory.AllowUserToResizeRows = false;
            this.dgvPriceHistory.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvPriceHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPriceHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPriceHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPriceHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPriceHistory.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPriceHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvPriceHistory.EnableHeadersVisualStyles = false;
            this.dgvPriceHistory.Location = new System.Drawing.Point(544, 67);
            this.dgvPriceHistory.Name = "dgvPriceHistory";
            this.dgvPriceHistory.ReadOnly = true;
            this.dgvPriceHistory.RowHeadersVisible = false;
            this.dgvPriceHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPriceHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPriceHistory.ShowCellErrors = false;
            this.dgvPriceHistory.ShowCellToolTips = false;
            this.dgvPriceHistory.ShowEditingIcon = false;
            this.dgvPriceHistory.Size = new System.Drawing.Size(191, 148);
            this.dgvPriceHistory.TabIndex = 77;
            this.dgvPriceHistory.SelectionChanged += new System.EventHandler(this.dgvPriceHistory_SelectionChanged);
            // 
            // lblProductName
            // 
            this.lblProductName.BackColor = System.Drawing.Color.Transparent;
            this.lblProductName.Font = new System.Drawing.Font("Outfit Thin", 12F);
            this.lblProductName.Location = new System.Drawing.Point(6, 21);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(190, 23);
            this.lblProductName.TabIndex = 78;
            this.lblProductName.Text = "lblProductName";
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.BackColor = System.Drawing.Color.Transparent;
            this.lblLastUpdate.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUpdate.Location = new System.Drawing.Point(198, 21);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(175, 23);
            this.lblLastUpdate.TabIndex = 79;
            this.lblLastUpdate.Text = "lblLastUpdate";
            this.lblLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.AnimationHoverSpeed = 0.07F;
            this.button1.AnimationSpeed = 0.03F;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BaseColor = System.Drawing.Color.White;
            this.button1.BorderColor = System.Drawing.Color.Black;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.button1.FocusedColor = System.Drawing.Color.Empty;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageSize = new System.Drawing.Size(25, 25);
            this.button1.Location = new System.Drawing.Point(174, 67);
            this.button1.Name = "button1";
            this.button1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.button1.OnHoverBorderColor = System.Drawing.Color.Transparent;
            this.button1.OnHoverForeColor = System.Drawing.Color.White;
            this.button1.OnHoverImage = ((System.Drawing.Image)(resources.GetObject("button1.OnHoverImage")));
            this.button1.OnPressedColor = System.Drawing.Color.Black;
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 78;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(926, 667);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvPriceHistory);
            this.Controls.Add(this.gunaDataGridView1);
            this.Controls.Add(this.btnAddInvMemo);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ProductGrid);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxProductCategory);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboxFilter);
            this.Controls.Add(this.btnNewProduct);
            this.Controls.Add(this.btnUpdateProduct);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSearchTerm);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInventory";
            this.Text = "FormOrder";
            this.Load += new System.EventHandler(this.FormOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gunaDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.ComboBox cboxFilter;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.ComboBox cboxProductCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAddQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxSupplierProduct;
        private System.Windows.Forms.Button btnNewSupplier;
        private System.Windows.Forms.Button btnUpdateSupplier;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.Button btnDeleteSupplier;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddInvMemo;
        private System.Windows.Forms.TextBox txtSellingPrice;
        private System.Windows.Forms.TextBox txtCostPrice;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtQuantityInStock;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView ProductGrid;
        private System.Windows.Forms.Button btnNewProduct;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private Guna.UI.WinForms.GunaDataGridView gunaDataGridView1;
        private System.Windows.Forms.RichTextBox txtMemo;
        private System.Windows.Forms.DataGridView dgvPriceHistory;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.Label lblProductName;
        private Guna.UI.WinForms.GunaCircleButton button1;
    }
}