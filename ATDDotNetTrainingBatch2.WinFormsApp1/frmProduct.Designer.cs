﻿namespace ATDDotNetTrainingBatch2.WinFormsApp1
{
    partial class frmProduct
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
            label1 = new Label();
            txtProductCode = new TextBox();
            txtProductName = new TextBox();
            label2 = new Label();
            txtProductPrice = new TextBox();
            label3 = new Label();
            btnSaveClick = new Button();
            dgvProductList = new DataGridView();
            chkDelete = new CheckBox();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            colPID = new DataGridViewTextBoxColumn();
            colPCode = new DataGridViewTextBoxColumn();
            colPName = new DataGridViewTextBoxColumn();
            colPPrice = new DataGridViewTextBoxColumn();
            isDelete = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvProductList).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 30);
            label1.Name = "label1";
            label1.Size = new Size(121, 25);
            label1.TabIndex = 0;
            label1.Text = "Product Code";
            // 
            // txtProductCode
            // 
            txtProductCode.Location = new Point(15, 70);
            txtProductCode.Name = "txtProductCode";
            txtProductCode.Size = new Size(255, 31);
            txtProductCode.TabIndex = 1;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(15, 163);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(255, 31);
            txtProductName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 120);
            label2.Name = "label2";
            label2.Size = new Size(126, 25);
            label2.TabIndex = 2;
            label2.Text = "Product Name";
            // 
            // txtProductPrice
            // 
            txtProductPrice.Location = new Point(12, 250);
            txtProductPrice.Name = "txtProductPrice";
            txtProductPrice.Size = new Size(255, 31);
            txtProductPrice.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 212);
            label3.Name = "label3";
            label3.Size = new Size(49, 25);
            label3.TabIndex = 4;
            label3.Text = "Price";
            // 
            // btnSaveClick
            // 
            btnSaveClick.Location = new Point(158, 352);
            btnSaveClick.Name = "btnSaveClick";
            btnSaveClick.Size = new Size(112, 34);
            btnSaveClick.TabIndex = 6;
            btnSaveClick.Text = "Save";
            btnSaveClick.UseVisualStyleBackColor = true;
            btnSaveClick.Click += btnSavelClick;
            // 
            // dgvProductList
            // 
            dgvProductList.AllowUserToAddRows = false;
            dgvProductList.AllowUserToDeleteRows = false;
            dgvProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductList.Columns.AddRange(new DataGridViewColumn[] { colEdit, colDelete, colPID, colPCode, colPName, colPPrice, isDelete });
            dgvProductList.Location = new Point(307, 40);
            dgvProductList.Name = "dgvProductList";
            dgvProductList.ReadOnly = true;
            dgvProductList.RowHeadersWidth = 62;
            dgvProductList.Size = new Size(472, 346);
            dgvProductList.TabIndex = 7;
            dgvProductList.CellContentClick += dgvProductList_CellContentClick;
            // 
            // chkDelete
            // 
            chkDelete.AutoSize = true;
            chkDelete.Location = new Point(15, 304);
            chkDelete.Name = "chkDelete";
            chkDelete.Size = new Size(101, 29);
            chkDelete.TabIndex = 8;
            chkDelete.Text = "IsDelete";
            chkDelete.UseVisualStyleBackColor = true;
            chkDelete.CheckedChanged += chkDelete_CheckedChanged;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "Edit";
            colEdit.MinimumWidth = 8;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Width = 150;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "Delete";
            colDelete.MinimumWidth = 8;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Width = 150;
            // 
            // colPID
            // 
            colPID.DataPropertyName = "ProductId";
            colPID.HeaderText = "ProductID";
            colPID.MinimumWidth = 8;
            colPID.Name = "colPID";
            colPID.ReadOnly = true;
            colPID.Visible = false;
            colPID.Width = 150;
            // 
            // colPCode
            // 
            colPCode.DataPropertyName = "ProductCode";
            colPCode.HeaderText = "Product Code";
            colPCode.MinimumWidth = 8;
            colPCode.Name = "colPCode";
            colPCode.ReadOnly = true;
            colPCode.Width = 150;
            // 
            // colPName
            // 
            colPName.DataPropertyName = "ProductItem";
            colPName.HeaderText = "Product Name";
            colPName.MinimumWidth = 8;
            colPName.Name = "colPName";
            colPName.ReadOnly = true;
            colPName.Width = 150;
            // 
            // colPPrice
            // 
            colPPrice.DataPropertyName = "Price";
            colPPrice.HeaderText = "Price";
            colPPrice.MinimumWidth = 8;
            colPPrice.Name = "colPPrice";
            colPPrice.ReadOnly = true;
            colPPrice.Width = 150;
            // 
            // isDelete
            // 
            isDelete.DataPropertyName = "IsDelete";
            isDelete.HeaderText = "IsDelete";
            isDelete.MinimumWidth = 8;
            isDelete.Name = "isDelete";
            isDelete.ReadOnly = true;
            isDelete.Width = 150;
            // 
            // frmProduct
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chkDelete);
            Controls.Add(dgvProductList);
            Controls.Add(btnSaveClick);
            Controls.Add(txtProductPrice);
            Controls.Add(label3);
            Controls.Add(txtProductName);
            Controls.Add(label2);
            Controls.Add(txtProductCode);
            Controls.Add(label1);
            Name = "frmProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Product";
            Load += frmProduct_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtProductCode;
        private TextBox txtProductName;
        private Label label2;
        private TextBox txtProductPrice;
        private Label label3;
        private Button btnSaveClick;
        private DataGridView dgvProductList;
        private CheckBox chkDelete;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private DataGridViewTextBoxColumn colPID;
        private DataGridViewTextBoxColumn colPCode;
        private DataGridViewTextBoxColumn colPName;
        private DataGridViewTextBoxColumn colPPrice;
        private DataGridViewCheckBoxColumn isDelete;
    }
}