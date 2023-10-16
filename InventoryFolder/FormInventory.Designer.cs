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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInventory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnRemoveStocks = new System.Windows.Forms.Button();
            this.StockGrid = new System.Windows.Forms.DataGridView();
            this.txtSellingPrice = new System.Windows.Forms.TextBox();
            this.txtCostPrice = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtQuantityInStock = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleteStockItem = new System.Windows.Forms.Button();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddInvMemo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtMemoPH = new System.Windows.Forms.RichTextBox();
            this.dgvPriceHistory = new System.Windows.Forms.DataGridView();
            this.ProductGrid = new System.Windows.Forms.DataGridView();
            this.btnNewProduct = new System.Windows.Forms.Button();
            this.txtMemo = new System.Windows.Forms.RichTextBox();
            this.button1 = new Guna.UI.WinForms.GunaCircleButton();
            this.dataGridViewMemos = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.cboxColumn = new System.Windows.Forms.ComboBox();
            this.cboxUnique = new System.Windows.Forms.ComboBox();
            this.chkRestock = new Guna.UI.WinForms.GunaCheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StockGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMemos)).BeginInit();
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
            this.txtSearchTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchTerm_KeyPress);
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
            this.cboxFilter.SelectedIndexChanged += new System.EventHandler(this.cboxFilter_SelectedIndexChanged);
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
            this.label1.Location = new System.Drawing.Point(12, 473);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 65;
            this.label1.Text = "Inventory Notes ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRestock);
            this.groupBox1.Controls.Add(this.btnRemoveStocks);
            this.groupBox1.Controls.Add(this.StockGrid);
            this.groupBox1.Controls.Add(this.txtSellingPrice);
            this.groupBox1.Controls.Add(this.txtCostPrice);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.txtCategory);
            this.groupBox1.Controls.Add(this.txtProductID);
            this.groupBox1.Controls.Add(this.txtQuantityInStock);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtQuantity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnDeleteStockItem);
            this.groupBox1.Controls.Add(this.btnAddStock);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Location = new System.Drawing.Point(536, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 427);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supplier / Stock Management";
            // 
            // btnRemoveStocks
            // 
            this.btnRemoveStocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveStocks.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveStocks.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveStocks.Location = new System.Drawing.Point(268, 391);
            this.btnRemoveStocks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRemoveStocks.Name = "btnRemoveStocks";
            this.btnRemoveStocks.Size = new System.Drawing.Size(105, 27);
            this.btnRemoveStocks.TabIndex = 82;
            this.btnRemoveStocks.Text = "Decrease";
            this.btnRemoveStocks.UseVisualStyleBackColor = true;
            this.btnRemoveStocks.Click += new System.EventHandler(this.btnRemoveStocks_Click);
            // 
            // StockGrid
            // 
            this.StockGrid.AllowUserToAddRows = false;
            this.StockGrid.AllowUserToDeleteRows = false;
            this.StockGrid.AllowUserToResizeColumns = false;
            this.StockGrid.AllowUserToResizeRows = false;
            this.StockGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.StockGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StockGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StockGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.StockGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.StockGrid.DefaultCellStyle = dataGridViewCellStyle18;
            this.StockGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.StockGrid.EnableHeadersVisualStyles = false;
            this.StockGrid.Location = new System.Drawing.Point(10, 19);
            this.StockGrid.Name = "StockGrid";
            this.StockGrid.ReadOnly = true;
            this.StockGrid.RowHeadersVisible = false;
            this.StockGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StockGrid.ShowCellErrors = false;
            this.StockGrid.ShowCellToolTips = false;
            this.StockGrid.ShowEditingIcon = false;
            this.StockGrid.Size = new System.Drawing.Size(363, 136);
            this.StockGrid.TabIndex = 76;
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSellingPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSellingPrice.CausesValidation = false;
            this.txtSellingPrice.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSellingPrice.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellingPrice.ForeColor = System.Drawing.Color.Black;
            this.txtSellingPrice.Location = new System.Drawing.Point(130, 366);
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
            this.txtCostPrice.Location = new System.Drawing.Point(130, 339);
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
            this.txtProductName.Location = new System.Drawing.Point(130, 258);
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
            this.txtCategory.Location = new System.Drawing.Point(130, 312);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(244, 19);
            this.txtCategory.TabIndex = 78;
            this.txtCategory.TabStop = false;
            // 
            // txtProductID
            // 
            this.txtProductID.BackColor = System.Drawing.SystemColors.Menu;
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductID.CausesValidation = false;
            this.txtProductID.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtProductID.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductID.ForeColor = System.Drawing.Color.Black;
            this.txtProductID.Location = new System.Drawing.Point(130, 285);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.ReadOnly = true;
            this.txtProductID.Size = new System.Drawing.Size(244, 19);
            this.txtProductID.TabIndex = 77;
            this.txtProductID.TabStop = false;
            // 
            // txtQuantityInStock
            // 
            this.txtQuantityInStock.BackColor = System.Drawing.SystemColors.Menu;
            this.txtQuantityInStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantityInStock.CausesValidation = false;
            this.txtQuantityInStock.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtQuantityInStock.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantityInStock.ForeColor = System.Drawing.Color.Black;
            this.txtQuantityInStock.Location = new System.Drawing.Point(130, 232);
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
            this.label10.Location = new System.Drawing.Point(6, 337);
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
            this.label9.Location = new System.Drawing.Point(6, 364);
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
            this.label8.Location = new System.Drawing.Point(6, 229);
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
            this.label5.Location = new System.Drawing.Point(5, 310);
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
            this.label4.Location = new System.Drawing.Point(5, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 19);
            this.label4.TabIndex = 71;
            this.label4.Text = "Product ID               :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Outfit Thin Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 19);
            this.label3.TabIndex = 67;
            this.label3.Text = "Product Name      :";
            // 
            // txtQuantity
            // 
            this.txtQuantity.BackColor = System.Drawing.Color.White;
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.CausesValidation = false;
            this.txtQuantity.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtQuantity.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.ForeColor = System.Drawing.Color.Black;
            this.txtQuantity.Location = new System.Drawing.Point(213, 199);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(160, 26);
            this.txtQuantity.TabIndex = 67;
            this.txtQuantity.TabStop = false;
            this.txtQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyDown);
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Outfit Thin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(129, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 67;
            this.label2.Text = "Quantity    :";
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(127, 161);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 27);
            this.btnSave.TabIndex = 70;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeleteStockItem
            // 
            this.btnDeleteStockItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteStockItem.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteStockItem.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteStockItem.Location = new System.Drawing.Point(210, 161);
            this.btnDeleteStockItem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDeleteStockItem.Name = "btnDeleteStockItem";
            this.btnDeleteStockItem.Size = new System.Drawing.Size(81, 27);
            this.btnDeleteStockItem.TabIndex = 69;
            this.btnDeleteStockItem.Text = "Delete";
            this.btnDeleteStockItem.UseVisualStyleBackColor = true;
            this.btnDeleteStockItem.Click += new System.EventHandler(this.btnDeleteStockItem_Click);
            // 
            // btnAddStock
            // 
            this.btnAddStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddStock.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStock.ForeColor = System.Drawing.Color.Black;
            this.btnAddStock.Location = new System.Drawing.Point(130, 391);
            this.btnAddStock.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(136, 27);
            this.btnAddStock.TabIndex = 68;
            this.btnAddStock.Text = "Increase";
            this.btnAddStock.UseVisualStyleBackColor = true;
            this.btnAddStock.Click += new System.EventHandler(this.btnAddStock_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(293, 161);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(81, 27);
            this.btnClear.TabIndex = 67;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAddInvMemo
            // 
            this.btnAddInvMemo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddInvMemo.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInvMemo.ForeColor = System.Drawing.Color.Black;
            this.btnAddInvMemo.Location = new System.Drawing.Point(447, 471);
            this.btnAddInvMemo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddInvMemo.Name = "btnAddInvMemo";
            this.btnAddInvMemo.Size = new System.Drawing.Size(81, 26);
            this.btnAddInvMemo.TabIndex = 72;
            this.btnAddInvMemo.Text = "Add Memo";
            this.btnAddInvMemo.UseVisualStyleBackColor = true;
            this.btnAddInvMemo.Click += new System.EventHandler(this.btnAddInvMemo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblLastUpdate);
            this.groupBox2.Controls.Add(this.lblProductName);
            this.groupBox2.Controls.Add(this.txtMemoPH);
            this.groupBox2.Controls.Add(this.dgvPriceHistory);
            this.groupBox2.Location = new System.Drawing.Point(536, 455);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 202);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Price History";
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
            // txtMemoPH
            // 
            this.txtMemoPH.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMemoPH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMemoPH.Location = new System.Drawing.Point(202, 47);
            this.txtMemoPH.Name = "txtMemoPH";
            this.txtMemoPH.ReadOnly = true;
            this.txtMemoPH.Size = new System.Drawing.Size(171, 148);
            this.txtMemoPH.TabIndex = 77;
            this.txtMemoPH.Text = "";
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
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPriceHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvPriceHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPriceHistory.DefaultCellStyle = dataGridViewCellStyle20;
            this.dgvPriceHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvPriceHistory.EnableHeadersVisualStyles = false;
            this.dgvPriceHistory.Location = new System.Drawing.Point(13, 47);
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
            // ProductGrid
            // 
            this.ProductGrid.AllowUserToAddRows = false;
            this.ProductGrid.AllowUserToDeleteRows = false;
            this.ProductGrid.AllowUserToResizeColumns = false;
            this.ProductGrid.AllowUserToResizeRows = false;
            this.ProductGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.ProductGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProductGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.ProductGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductGrid.DefaultCellStyle = dataGridViewCellStyle22;
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
            this.ProductGrid.Size = new System.Drawing.Size(516, 367);
            this.ProductGrid.TabIndex = 74;
            this.ProductGrid.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.ProductGrid_RowPrePaint);
            this.ProductGrid.SelectionChanged += new System.EventHandler(this.ProductGrid_SelectionChanged);
            this.ProductGrid.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.ProductGrid_SortCompare);
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
            // txtMemo
            // 
            this.txtMemo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMemo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMemo.Location = new System.Drawing.Point(343, 502);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.ReadOnly = true;
            this.txtMemo.Size = new System.Drawing.Size(185, 153);
            this.txtMemo.TabIndex = 76;
            this.txtMemo.Text = "";
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
            // dataGridViewMemos
            // 
            this.dataGridViewMemos.AllowUserToAddRows = false;
            this.dataGridViewMemos.AllowUserToDeleteRows = false;
            this.dataGridViewMemos.AllowUserToResizeColumns = false;
            this.dataGridViewMemos.AllowUserToResizeRows = false;
            this.dataGridViewMemos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMemos.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewMemos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewMemos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMemos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewMemos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMemos.DefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewMemos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridViewMemos.EnableHeadersVisualStyles = false;
            this.dataGridViewMemos.Location = new System.Drawing.Point(12, 502);
            this.dataGridViewMemos.Name = "dataGridViewMemos";
            this.dataGridViewMemos.ReadOnly = true;
            this.dataGridViewMemos.RowHeadersVisible = false;
            this.dataGridViewMemos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewMemos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMemos.ShowCellErrors = false;
            this.dataGridViewMemos.ShowCellToolTips = false;
            this.dataGridViewMemos.ShowEditingIcon = false;
            this.dataGridViewMemos.Size = new System.Drawing.Size(330, 153);
            this.dataGridViewMemos.TabIndex = 79;
            this.dataGridViewMemos.SelectionChanged += new System.EventHandler(this.dataGridViewMemos_SelectionChanged);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(381, 471);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 26);
            this.button2.TabIndex = 80;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cboxColumn
            // 
            this.cboxColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxColumn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboxColumn.FormattingEnabled = true;
            this.cboxColumn.Items.AddRange(new object[] {
            "Date",
            "Reason",
            "Employee Name"});
            this.cboxColumn.Location = new System.Drawing.Point(134, 471);
            this.cboxColumn.Name = "cboxColumn";
            this.cboxColumn.Size = new System.Drawing.Size(109, 26);
            this.cboxColumn.TabIndex = 81;
            this.cboxColumn.SelectedIndexChanged += new System.EventHandler(this.cboxColumn_SelectedIndexChanged);
            // 
            // cboxUnique
            // 
            this.cboxUnique.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxUnique.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.cboxUnique.FormattingEnabled = true;
            this.cboxUnique.Location = new System.Drawing.Point(249, 471);
            this.cboxUnique.Name = "cboxUnique";
            this.cboxUnique.Size = new System.Drawing.Size(128, 26);
            this.cboxUnique.TabIndex = 82;
            this.cboxUnique.SelectedIndexChanged += new System.EventHandler(this.cboxUnique_SelectedIndexChanged);
            // 
            // chkRestock
            // 
            this.chkRestock.BaseColor = System.Drawing.Color.White;
            this.chkRestock.CheckedOffColor = System.Drawing.Color.Gray;
            this.chkRestock.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.chkRestock.FillColor = System.Drawing.Color.White;
            this.chkRestock.Font = new System.Drawing.Font("Outfit Thin", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRestock.ForeColor = System.Drawing.Color.Black;
            this.chkRestock.Location = new System.Drawing.Point(4, 402);
            this.chkRestock.Name = "chkRestock";
            this.chkRestock.Size = new System.Drawing.Size(105, 21);
            this.chkRestock.TabIndex = 83;
            this.chkRestock.Text = "Restock only";
            this.chkRestock.CheckedChanged += new System.EventHandler(this.chkRestock_CheckedChanged);
            // 
            // FormInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(926, 667);
            this.Controls.Add(this.cboxUnique);
            this.Controls.Add(this.cboxColumn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridViewMemos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddInvMemo);
            this.Controls.Add(this.txtMemo);
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
            ((System.ComponentModel.ISupportInitialize)(this.StockGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMemos)).EndInit();
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
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDeleteStockItem;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.Button btnClear;
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
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.TextBox txtQuantityInStock;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView ProductGrid;
        private System.Windows.Forms.Button btnNewProduct;
        private System.Windows.Forms.DataGridView StockGrid;
        private System.Windows.Forms.RichTextBox txtMemo;
        private System.Windows.Forms.RichTextBox txtMemoPH;
        private System.Windows.Forms.DataGridView dgvPriceHistory;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.Label lblProductName;
        private Guna.UI.WinForms.GunaCircleButton button1;
        private System.Windows.Forms.DataGridView dataGridViewMemos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cboxColumn;
        private System.Windows.Forms.ComboBox cboxUnique;
        private System.Windows.Forms.Button btnRemoveStocks;
        private Guna.UI.WinForms.GunaCheckBox chkRestock;
    }
}