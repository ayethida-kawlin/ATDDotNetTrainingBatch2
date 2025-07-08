namespace ATDDotNetTrainingBatch2.WinFormsApp1
{
    partial class FrmStaff
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btlSave = new Button();
            label1 = new Label();
            txtCode = new TextBox();
            txtName = new TextBox();
            label2 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            txtPassword = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtMobile = new TextBox();
            label6 = new Label();
            cboPosition = new ComboBox();
            dgvData = new DataGridView();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            colId = new DataGridViewTextBoxColumn();
            colCode = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colPosition = new DataGridViewTextBoxColumn();
            colMobile = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // btlSave
            // 
            btlSave.Location = new Point(94, 447);
            btlSave.Name = "btlSave";
            btlSave.Size = new Size(112, 34);
            btlSave.TabIndex = 0;
            btlSave.Text = "Save";
            btlSave.UseVisualStyleBackColor = true;
            btlSave.Click += btlSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 9);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 1;
            label1.Text = "Staff Code:";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(20, 37);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(277, 31);
            txtCode.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Location = new Point(20, 110);
            txtName.Name = "txtName";
            txtName.Size = new Size(277, 31);
            txtName.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 82);
            label2.Name = "label2";
            label2.Size = new Size(104, 25);
            label2.TabIndex = 3;
            label2.Text = "Staff Name:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(20, 182);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(277, 31);
            txtEmail.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 154);
            label3.Name = "label3";
            label3.Size = new Size(58, 25);
            label3.TabIndex = 5;
            label3.Text = "Email:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(20, 255);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(277, 31);
            txtPassword.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 227);
            label4.Name = "label4";
            label4.Size = new Size(91, 25);
            label4.TabIndex = 7;
            label4.Text = "Password:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 295);
            label5.Name = "label5";
            label5.Size = new Size(79, 25);
            label5.TabIndex = 9;
            label5.Text = "Position:";
            // 
            // txtMobile
            // 
            txtMobile.Location = new Point(20, 394);
            txtMobile.Name = "txtMobile";
            txtMobile.Size = new Size(277, 31);
            txtMobile.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 366);
            label6.Name = "label6";
            label6.Size = new Size(100, 25);
            label6.TabIndex = 11;
            label6.Text = "Mobile No:";
            // 
            // cboPosition
            // 
            cboPosition.FormattingEnabled = true;
            cboPosition.Items.AddRange(new object[] { "--Select One--", "Admin", "Cashier", "Manager" });
            cboPosition.Location = new Point(24, 328);
            cboPosition.Name = "cboPosition";
            cboPosition.Size = new Size(273, 33);
            cboPosition.TabIndex = 13;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { colEdit, colDelete, colId, colCode, colName, colEmail, colPosition, colMobile });
            dgvData.Location = new Point(349, 12);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersWidth = 62;
            dgvData.Size = new Size(444, 469);
            dgvData.TabIndex = 14;
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "Edit";
            colEdit.MinimumWidth = 8;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Text = "Edit";
            colEdit.UseColumnTextForButtonValue = true;
            colEdit.Width = 150;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "Delete";
            colDelete.MinimumWidth = 8;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Text = "Delete";
            colDelete.UseColumnTextForButtonValue = true;
            colDelete.Width = 150;
            // 
            // colId
            // 
            colId.DataPropertyName = "StaffId";
            colId.HeaderText = "Id";
            colId.MinimumWidth = 8;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 150;
            // 
            // colCode
            // 
            colCode.DataPropertyName = "StaffCode";
            colCode.HeaderText = "Staff Code";
            colCode.MinimumWidth = 8;
            colCode.Name = "colCode";
            colCode.ReadOnly = true;
            colCode.Width = 150;
            // 
            // colName
            // 
            colName.DataPropertyName = "StaffName";
            colName.HeaderText = "Staff Name";
            colName.MinimumWidth = 8;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 150;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "emailAddress";
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 8;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            colEmail.Width = 150;
            // 
            // colPosition
            // 
            colPosition.DataPropertyName = "Position";
            colPosition.HeaderText = "Position";
            colPosition.MinimumWidth = 8;
            colPosition.Name = "colPosition";
            colPosition.ReadOnly = true;
            colPosition.Width = 150;
            // 
            // colMobile
            // 
            colMobile.DataPropertyName = "MobileNo";
            colMobile.HeaderText = "Mobile No:";
            colMobile.MinimumWidth = 8;
            colMobile.Name = "colMobile";
            colMobile.ReadOnly = true;
            colMobile.Width = 150;
            // 
            // FrmStaff
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 519);
            Controls.Add(dgvData);
            Controls.Add(cboPosition);
            Controls.Add(txtMobile);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtPassword);
            Controls.Add(label4);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(txtCode);
            Controls.Add(label1);
            Controls.Add(btlSave);
            Name = "FrmStaff";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Staff";
            Load += FrmStaff_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btlSave;
        private Label label1;
        private TextBox txtCode;
        private TextBox txtName;
        private Label label2;
        private TextBox txtEmail;
        private Label label3;
        private TextBox txtPassword;
        private Label label4;
        private Label label5;
        private TextBox txtMobile;
        private Label label6;
        private ComboBox cboPosition;
        private DataGridView dgvData;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colCode;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colPosition;
        private DataGridViewTextBoxColumn colMobile;
    }
}
