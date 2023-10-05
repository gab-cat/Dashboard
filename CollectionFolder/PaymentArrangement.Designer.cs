namespace Dashboard.CollectionFolder
{
    partial class PaymentArrangement
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
            this.lblPAID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.Label();
            this.dtpickerDueDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPaymentDue = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnMakePA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payment Arrangement ID :";
            // 
            // lblPAID
            // 
            this.lblPAID.BackColor = System.Drawing.Color.Silver;
            this.lblPAID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPAID.Location = new System.Drawing.Point(209, 18);
            this.lblPAID.Name = "lblPAID";
            this.lblPAID.Size = new System.Drawing.Size(124, 25);
            this.lblPAID.TabIndex = 1;
            this.lblPAID.Text = "PA6000";
            this.lblPAID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Customer ID                        :";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BackColor = System.Drawing.Color.Silver;
            this.txtCustomerID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.Location = new System.Drawing.Point(209, 48);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(124, 25);
            this.txtCustomerID.TabIndex = 3;
            this.txtCustomerID.Text = "3000";
            this.txtCustomerID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpickerDueDate
            // 
            this.dtpickerDueDate.CustomFormat = "yyyy-MM-dd";
            this.dtpickerDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpickerDueDate.Location = new System.Drawing.Point(209, 79);
            this.dtpickerDueDate.Name = "dtpickerDueDate";
            this.dtpickerDueDate.Size = new System.Drawing.Size(123, 23);
            this.dtpickerDueDate.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Promise to Pay Date          :";
            // 
            // txtPaymentDue
            // 
            this.txtPaymentDue.BackColor = System.Drawing.Color.Silver;
            this.txtPaymentDue.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentDue.Location = new System.Drawing.Point(209, 108);
            this.txtPaymentDue.Name = "txtPaymentDue";
            this.txtPaymentDue.Size = new System.Drawing.Size(124, 25);
            this.txtPaymentDue.TabIndex = 7;
            this.txtPaymentDue.Text = "3000";
            this.txtPaymentDue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Payment Due                      :";
            // 
            // btnMakePA
            // 
            this.btnMakePA.Location = new System.Drawing.Point(158, 149);
            this.btnMakePA.Name = "btnMakePA";
            this.btnMakePA.Size = new System.Drawing.Size(175, 27);
            this.btnMakePA.TabIndex = 8;
            this.btnMakePA.Text = "Create Payment Arrangement";
            this.btnMakePA.UseVisualStyleBackColor = true;
            // 
            // PaymentArrangement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 185);
            this.Controls.Add(this.btnMakePA);
            this.Controls.Add(this.txtPaymentDue);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpickerDueDate);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPAID);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "PaymentArrangement";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Make Payment Arrangement";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPAID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtCustomerID;
        private System.Windows.Forms.DateTimePicker dtpickerDueDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtPaymentDue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnMakePA;
    }
}