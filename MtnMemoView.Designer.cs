namespace Dashboard
{
    partial class MtnMemoView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MemoGrid = new System.Windows.Forms.DataGridView();
            this.txtMemo = new System.Windows.Forms.RichTextBox();
            this.btnAddInvMemo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MemoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MemoGrid
            // 
            this.MemoGrid.AllowUserToAddRows = false;
            this.MemoGrid.AllowUserToDeleteRows = false;
            this.MemoGrid.AllowUserToResizeColumns = false;
            this.MemoGrid.AllowUserToResizeRows = false;
            this.MemoGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MemoGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.MemoGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MemoGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MemoGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MemoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MemoGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.MemoGrid.EnableHeadersVisualStyles = false;
            this.MemoGrid.Location = new System.Drawing.Point(12, 12);
            this.MemoGrid.Name = "MemoGrid";
            this.MemoGrid.ReadOnly = true;
            this.MemoGrid.RowHeadersVisible = false;
            this.MemoGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MemoGrid.ShowCellErrors = false;
            this.MemoGrid.ShowCellToolTips = false;
            this.MemoGrid.ShowEditingIcon = false;
            this.MemoGrid.Size = new System.Drawing.Size(382, 245);
            this.MemoGrid.TabIndex = 76;
            this.MemoGrid.SelectionChanged += new System.EventHandler(this.MemoGrid_SelectionChanged);
            // 
            // txtMemo
            // 
            this.txtMemo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMemo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMemo.Location = new System.Drawing.Point(400, 47);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.ReadOnly = true;
            this.txtMemo.Size = new System.Drawing.Size(265, 210);
            this.txtMemo.TabIndex = 77;
            this.txtMemo.Text = "";
            // 
            // btnAddInvMemo
            // 
            this.btnAddInvMemo.Font = new System.Drawing.Font("Outfit Thin Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInvMemo.ForeColor = System.Drawing.Color.Black;
            this.btnAddInvMemo.Location = new System.Drawing.Point(400, 12);
            this.btnAddInvMemo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddInvMemo.Name = "btnAddInvMemo";
            this.btnAddInvMemo.Size = new System.Drawing.Size(264, 29);
            this.btnAddInvMemo.TabIndex = 78;
            this.btnAddInvMemo.Text = "Add Memo";
            this.btnAddInvMemo.UseVisualStyleBackColor = true;
            this.btnAddInvMemo.Click += new System.EventHandler(this.btnAddInvMemo_Click);
            // 
            // MtnMemoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(677, 269);
            this.Controls.Add(this.btnAddInvMemo);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.MemoGrid);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MtnMemoView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maintenance Memo";
            this.Load += new System.EventHandler(this.MtnMemoView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MemoGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView MemoGrid;
        private System.Windows.Forms.RichTextBox txtMemo;
        private System.Windows.Forms.Button btnAddInvMemo;
    }
}