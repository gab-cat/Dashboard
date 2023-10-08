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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle78 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle79 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle80 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle81 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle82 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle83 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle84 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle85 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle86 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle87 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle88 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.cboxFilter = new System.Windows.Forms.ComboBox();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.cboxProductCategory = new System.Windows.Forms.ComboBox();
            this.PriceHistoryGrid = new Guna.UI.WinForms.GunaDataGridView();
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
            this.SuppliersGrid = new Guna.UI.WinForms.GunaDataGridView();
            this.InventoryNotesGrid = new Guna.UI.WinForms.GunaDataGridView();
            this.btnAddInvMemo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ProductGrid = new System.Windows.Forms.DataGridView();
            this.btnNewProduct = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PriceHistoryGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SuppliersGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryNotesGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductGrid)).BeginInit();
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
            // PriceHistoryGrid
            // 
            this.PriceHistoryGrid.AllowUserToAddRows = false;
            this.PriceHistoryGrid.AllowUserToDeleteRows = false;
            this.PriceHistoryGrid.AllowUserToResizeColumns = false;
            this.PriceHistoryGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle78.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle78.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle78.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle78.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle78.SelectionForeColor = System.Drawing.Color.Black;
            this.PriceHistoryGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle78;
            this.PriceHistoryGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PriceHistoryGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.PriceHistoryGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PriceHistoryGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.PriceHistoryGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle79.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle79.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle79.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle79.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle79.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle79.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PriceHistoryGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle79;
            this.PriceHistoryGrid.ColumnHeadersHeight = 25;
            dataGridViewCellStyle80.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle80.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle80.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle80.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle80.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle80.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle80.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PriceHistoryGrid.DefaultCellStyle = dataGridViewCellStyle80;
            this.PriceHistoryGrid.EnableHeadersVisualStyles = false;
            this.PriceHistoryGrid.GridColor = System.Drawing.Color.Silver;
            this.PriceHistoryGrid.Location = new System.Drawing.Point(12, 518);
            this.PriceHistoryGrid.Name = "PriceHistoryGrid";
            this.PriceHistoryGrid.ReadOnly = true;
            this.PriceHistoryGrid.RowHeadersVisible = false;
            this.PriceHistoryGrid.RowTemplate.Height = 20;
            this.PriceHistoryGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PriceHistoryGrid.Size = new System.Drawing.Size(516, 130);
            this.PriceHistoryGrid.TabIndex = 64;
            this.PriceHistoryGrid.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.PriceHistoryGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.PriceHistoryGrid.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceHistoryGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.PriceHistoryGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.SystemColors.Info;
            this.PriceHistoryGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.PriceHistoryGrid.ThemeStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.PriceHistoryGrid.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.PriceHistoryGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.PriceHistoryGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.PriceHistoryGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceHistoryGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.PriceHistoryGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.PriceHistoryGrid.ThemeStyle.HeaderStyle.Height = 25;
            this.PriceHistoryGrid.ThemeStyle.ReadOnly = true;
            this.PriceHistoryGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.PriceHistoryGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.PriceHistoryGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceHistoryGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.PriceHistoryGrid.ThemeStyle.RowsStyle.Height = 20;
            this.PriceHistoryGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.SystemColors.Info;
            this.PriceHistoryGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Outfit Thin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 495);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 65;
            this.label1.Text = "Price History :";
            // 
            // groupBox1
            // 
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
            this.groupBox1.Controls.Add(this.SuppliersGrid);
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
            this.txtSellingPrice.Location = new System.Drawing.Point(129, 346);
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
            this.txtCostPrice.Location = new System.Drawing.Point(129, 321);
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
            this.txtProductName.Location = new System.Drawing.Point(130, 294);
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
            this.txtCategory.Location = new System.Drawing.Point(130, 267);
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
            this.txtDescription.Location = new System.Drawing.Point(129, 400);
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
            this.txtQuantityInStock.Location = new System.Drawing.Point(129, 373);
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
            this.label10.Location = new System.Drawing.Point(6, 319);
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
            this.label9.Location = new System.Drawing.Point(6, 346);
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
            this.label8.Location = new System.Drawing.Point(6, 373);
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
            this.label5.Location = new System.Drawing.Point(6, 265);
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
            this.label4.Location = new System.Drawing.Point(6, 400);
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
            this.label3.Location = new System.Drawing.Point(6, 292);
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
            this.txtAddQuantity.Location = new System.Drawing.Point(225, 199);
            this.txtAddQuantity.Name = "txtAddQuantity";
            this.txtAddQuantity.Size = new System.Drawing.Size(148, 26);
            this.txtAddQuantity.TabIndex = 67;
            this.txtAddQuantity.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Outfit Thin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(145, 201);
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
            this.cboxSupplierProduct.Size = new System.Drawing.Size(136, 26);
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
            this.btnAddStock.Location = new System.Drawing.Point(281, 232);
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
            // SuppliersGrid
            // 
            this.SuppliersGrid.AllowUserToAddRows = false;
            this.SuppliersGrid.AllowUserToDeleteRows = false;
            this.SuppliersGrid.AllowUserToResizeColumns = false;
            this.SuppliersGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle81.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle81.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle81.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle81.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle81.SelectionForeColor = System.Drawing.Color.Black;
            this.SuppliersGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle81;
            this.SuppliersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SuppliersGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.SuppliersGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SuppliersGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.SuppliersGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle82.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle82.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle82.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle82.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle82.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle82.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle82.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SuppliersGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle82;
            this.SuppliersGrid.ColumnHeadersHeight = 25;
            dataGridViewCellStyle83.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle83.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle83.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle83.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle83.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle83.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle83.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SuppliersGrid.DefaultCellStyle = dataGridViewCellStyle83;
            this.SuppliersGrid.EnableHeadersVisualStyles = false;
            this.SuppliersGrid.GridColor = System.Drawing.Color.Silver;
            this.SuppliersGrid.Location = new System.Drawing.Point(6, 19);
            this.SuppliersGrid.Name = "SuppliersGrid";
            this.SuppliersGrid.ReadOnly = true;
            this.SuppliersGrid.RowHeadersVisible = false;
            this.SuppliersGrid.RowTemplate.Height = 20;
            this.SuppliersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SuppliersGrid.Size = new System.Drawing.Size(368, 121);
            this.SuppliersGrid.TabIndex = 67;
            this.SuppliersGrid.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.SuppliersGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.SuppliersGrid.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuppliersGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.SuppliersGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.SystemColors.Info;
            this.SuppliersGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.SuppliersGrid.ThemeStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.SuppliersGrid.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.SuppliersGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.SuppliersGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.SuppliersGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuppliersGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.SuppliersGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.SuppliersGrid.ThemeStyle.HeaderStyle.Height = 25;
            this.SuppliersGrid.ThemeStyle.ReadOnly = true;
            this.SuppliersGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.SuppliersGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.SuppliersGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuppliersGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.SuppliersGrid.ThemeStyle.RowsStyle.Height = 20;
            this.SuppliersGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.SystemColors.Info;
            this.SuppliersGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // InventoryNotesGrid
            // 
            this.InventoryNotesGrid.AllowUserToAddRows = false;
            this.InventoryNotesGrid.AllowUserToDeleteRows = false;
            this.InventoryNotesGrid.AllowUserToResizeColumns = false;
            this.InventoryNotesGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle84.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle84.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle84.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle84.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle84.SelectionForeColor = System.Drawing.Color.Black;
            this.InventoryNotesGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle84;
            this.InventoryNotesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.InventoryNotesGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.InventoryNotesGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InventoryNotesGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.InventoryNotesGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle85.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle85.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle85.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle85.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle85.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle85.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InventoryNotesGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle85;
            this.InventoryNotesGrid.ColumnHeadersHeight = 25;
            dataGridViewCellStyle86.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle86.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle86.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle86.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle86.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle86.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle86.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InventoryNotesGrid.DefaultCellStyle = dataGridViewCellStyle86;
            this.InventoryNotesGrid.EnableHeadersVisualStyles = false;
            this.InventoryNotesGrid.GridColor = System.Drawing.Color.Silver;
            this.InventoryNotesGrid.Location = new System.Drawing.Point(10, 19);
            this.InventoryNotesGrid.Name = "InventoryNotesGrid";
            this.InventoryNotesGrid.ReadOnly = true;
            this.InventoryNotesGrid.RowHeadersVisible = false;
            this.InventoryNotesGrid.RowTemplate.Height = 20;
            this.InventoryNotesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InventoryNotesGrid.Size = new System.Drawing.Size(364, 144);
            this.InventoryNotesGrid.TabIndex = 72;
            this.InventoryNotesGrid.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.InventoryNotesGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.InventoryNotesGrid.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryNotesGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.InventoryNotesGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.SystemColors.Info;
            this.InventoryNotesGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.InventoryNotesGrid.ThemeStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.InventoryNotesGrid.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.InventoryNotesGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.InventoryNotesGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.InventoryNotesGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryNotesGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.InventoryNotesGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.InventoryNotesGrid.ThemeStyle.HeaderStyle.Height = 25;
            this.InventoryNotesGrid.ThemeStyle.ReadOnly = true;
            this.InventoryNotesGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.InventoryNotesGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.InventoryNotesGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryNotesGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.InventoryNotesGrid.ThemeStyle.RowsStyle.Height = 20;
            this.InventoryNotesGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.SystemColors.Info;
            this.InventoryNotesGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // btnAddInvMemo
            // 
            this.btnAddInvMemo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddInvMemo.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInvMemo.ForeColor = System.Drawing.Color.Black;
            this.btnAddInvMemo.Location = new System.Drawing.Point(292, 169);
            this.btnAddInvMemo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddInvMemo.Name = "btnAddInvMemo";
            this.btnAddInvMemo.Size = new System.Drawing.Size(81, 27);
            this.btnAddInvMemo.TabIndex = 72;
            this.btnAddInvMemo.Text = "Add Memo";
            this.btnAddInvMemo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddInvMemo);
            this.groupBox2.Controls.Add(this.InventoryNotesGrid);
            this.groupBox2.Location = new System.Drawing.Point(534, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 202);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inventory/Stock Notes";
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
            dataGridViewCellStyle87.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle87.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle87.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle87.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle87.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle87.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle87.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle87;
            this.ProductGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle88.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle88.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle88.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle88.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle88.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle88.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle88.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductGrid.DefaultCellStyle = dataGridViewCellStyle88;
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
            this.ProductGrid.Size = new System.Drawing.Size(516, 392);
            this.ProductGrid.TabIndex = 74;
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
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Outfit Thin Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(176, 67);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 26);
            this.button1.TabIndex = 75;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(926, 667);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ProductGrid);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PriceHistoryGrid);
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
            ((System.ComponentModel.ISupportInitialize)(this.PriceHistoryGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SuppliersGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryNotesGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductGrid)).EndInit();
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
        private Guna.UI.WinForms.GunaDataGridView PriceHistoryGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAddQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxSupplierProduct;
        private System.Windows.Forms.Button btnNewSupplier;
        private System.Windows.Forms.Button btnUpdateSupplier;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.Button btnDeleteSupplier;
        private Guna.UI.WinForms.GunaDataGridView SuppliersGrid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaDataGridView InventoryNotesGrid;
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
        private System.Windows.Forms.Button button1;
    }
}