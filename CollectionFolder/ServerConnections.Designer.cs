namespace Dashboard.CollectionFolder
{
    partial class ServerConnections
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
            this.ConnectionsGrid = new System.Windows.Forms.DataGridView();
            this.btnKill = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnKillAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectionsGrid
            // 
            this.ConnectionsGrid.AllowUserToAddRows = false;
            this.ConnectionsGrid.AllowUserToDeleteRows = false;
            this.ConnectionsGrid.AllowUserToResizeColumns = false;
            this.ConnectionsGrid.AllowUserToResizeRows = false;
            this.ConnectionsGrid.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.ConnectionsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ConnectionsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ConnectionsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConnectionsGrid.Location = new System.Drawing.Point(12, 12);
            this.ConnectionsGrid.Name = "ConnectionsGrid";
            this.ConnectionsGrid.ReadOnly = true;
            this.ConnectionsGrid.RowHeadersVisible = false;
            this.ConnectionsGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ConnectionsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ConnectionsGrid.ShowCellErrors = false;
            this.ConnectionsGrid.ShowCellToolTips = false;
            this.ConnectionsGrid.ShowEditingIcon = false;
            this.ConnectionsGrid.ShowRowErrors = false;
            this.ConnectionsGrid.Size = new System.Drawing.Size(427, 219);
            this.ConnectionsGrid.TabIndex = 8;
            this.ConnectionsGrid.TabStop = false;
            // 
            // btnKill
            // 
            this.btnKill.Location = new System.Drawing.Point(246, 237);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(99, 23);
            this.btnKill.TabIndex = 7;
            this.btnKill.Text = "Kill Process";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnKillAll
            // 
            this.btnKillAll.Location = new System.Drawing.Point(141, 237);
            this.btnKillAll.Name = "btnKillAll";
            this.btnKillAll.Size = new System.Drawing.Size(99, 23);
            this.btnKillAll.TabIndex = 9;
            this.btnKillAll.Text = "Kill All";
            this.btnKillAll.UseVisualStyleBackColor = true;
            this.btnKillAll.Click += new System.EventHandler(this.btnKillAll_Click);
            // 
            // ServerConnections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 272);
            this.Controls.Add(this.btnKillAll);
            this.Controls.Add(this.ConnectionsGrid);
            this.Controls.Add(this.btnKill);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ServerConnections";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server Connections";
            ((System.ComponentModel.ISupportInitialize)(this.ConnectionsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ConnectionsGrid;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnKillAll;
    }
}