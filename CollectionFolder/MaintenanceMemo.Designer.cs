namespace Dashboard.Forms
{
    partial class MaintenanceMemo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmployee = new System.Windows.Forms.TextBox();
            this.txtTimeStamp = new System.Windows.Forms.TextBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtUserText = new System.Windows.Forms.TextBox();
            this.txtreason = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSystemText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Maintenance Memo ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Timestamp            :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Employee Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Reason                    :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "User Text      :";
            // 
            // txtEmployee
            // 
            this.txtEmployee.BackColor = System.Drawing.SystemColors.Menu;
            this.txtEmployee.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmployee.CausesValidation = false;
            this.txtEmployee.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtEmployee.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployee.ForeColor = System.Drawing.Color.Black;
            this.txtEmployee.Location = new System.Drawing.Point(125, 58);
            this.txtEmployee.Name = "txtEmployee";
            this.txtEmployee.ReadOnly = true;
            this.txtEmployee.Size = new System.Drawing.Size(304, 19);
            this.txtEmployee.TabIndex = 13;
            this.txtEmployee.TabStop = false;
            // 
            // txtTimeStamp
            // 
            this.txtTimeStamp.BackColor = System.Drawing.SystemColors.Menu;
            this.txtTimeStamp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTimeStamp.CausesValidation = false;
            this.txtTimeStamp.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtTimeStamp.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeStamp.ForeColor = System.Drawing.Color.Black;
            this.txtTimeStamp.Location = new System.Drawing.Point(125, 34);
            this.txtTimeStamp.Name = "txtTimeStamp";
            this.txtTimeStamp.ReadOnly = true;
            this.txtTimeStamp.Size = new System.Drawing.Size(304, 19);
            this.txtTimeStamp.TabIndex = 14;
            this.txtTimeStamp.TabStop = false;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BackColor = System.Drawing.SystemColors.Menu;
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustomerID.CausesValidation = false;
            this.txtCustomerID.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtCustomerID.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.ForeColor = System.Drawing.Color.Black;
            this.txtCustomerID.Location = new System.Drawing.Point(125, 10);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.Size = new System.Drawing.Size(304, 19);
            this.txtCustomerID.TabIndex = 15;
            this.txtCustomerID.TabStop = false;
            // 
            // txtUserText
            // 
            this.txtUserText.BackColor = System.Drawing.Color.White;
            this.txtUserText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserText.CausesValidation = false;
            this.txtUserText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtUserText.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserText.ForeColor = System.Drawing.Color.Black;
            this.txtUserText.Location = new System.Drawing.Point(98, 196);
            this.txtUserText.Multiline = true;
            this.txtUserText.Name = "txtUserText";
            this.txtUserText.Size = new System.Drawing.Size(331, 128);
            this.txtUserText.TabIndex = 17;
            this.txtUserText.TabStop = false;
            // 
            // txtreason
            // 
            this.txtreason.DropDownHeight = 104;
            this.txtreason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtreason.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtreason.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreason.FormattingEnabled = true;
            this.txtreason.IntegralHeight = false;
            this.txtreason.Items.AddRange(new object[] {
            "New Employee Profile",
            "Employee Resignation",
            "Promotion or Job Transfer",
            "Other Employee Reasons",
            "New Supplier Profile",
            "Supplier Performance Evaluation",
            "Contract Renewals",
            "Supplier Audits",
            "Quality Issues and Resolutions",
            "Price Changes",
            "New Product or Service Requests",
            "Supplier Visits or Site Inspections",
            "Compliance and Certification",
            "Supplier Termination",
            "Other Supplier Reasons"});
            this.txtreason.Location = new System.Drawing.Point(125, 81);
            this.txtreason.Name = "txtreason";
            this.txtreason.Size = new System.Drawing.Size(304, 23);
            this.txtreason.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(331, 330);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Add Memo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(262, 330);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtSystemText
            // 
            this.txtSystemText.BackColor = System.Drawing.SystemColors.Control;
            this.txtSystemText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSystemText.CausesValidation = false;
            this.txtSystemText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtSystemText.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSystemText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSystemText.Location = new System.Drawing.Point(99, 110);
            this.txtSystemText.Multiline = true;
            this.txtSystemText.Name = "txtSystemText";
            this.txtSystemText.ReadOnly = true;
            this.txtSystemText.Size = new System.Drawing.Size(331, 80);
            this.txtSystemText.TabIndex = 21;
            this.txtSystemText.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 18);
            this.label6.TabIndex = 22;
            this.label6.Text = "System Text :";
            // 
            // MaintenanceMemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(443, 362);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSystemText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtreason);
            this.Controls.Add(this.txtUserText);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.txtTimeStamp);
            this.Controls.Add(this.txtEmployee);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MaintenanceMemo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Memo";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmployee;
        private System.Windows.Forms.TextBox txtTimeStamp;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtUserText;
        private System.Windows.Forms.ComboBox txtreason;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtSystemText;
        private System.Windows.Forms.Label label6;
    }
}