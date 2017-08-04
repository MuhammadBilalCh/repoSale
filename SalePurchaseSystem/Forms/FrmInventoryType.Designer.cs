namespace SalePurchaseSystem.Forms
{
    partial class FrmInventoryType
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventoryType));
            this.pnlAddNew = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtInventoryType = new System.Windows.Forms.TextBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnLoadAll = new System.Windows.Forms.Button();
            this.pnlSaveAll = new System.Windows.Forms.Panel();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblInvId = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.grdViewInventoryType = new System.Windows.Forms.DataGridView();
            this.InventoryTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlAddNew.SuspendLayout();
            this.pnlSaveAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewInventoryType)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAddNew
            // 
            this.pnlAddNew.Controls.Add(this.label1);
            this.pnlAddNew.Controls.Add(this.btnAdd);
            this.pnlAddNew.Controls.Add(this.txtInventoryType);
            this.pnlAddNew.Location = new System.Drawing.Point(66, 37);
            this.pnlAddNew.Name = "pnlAddNew";
            this.pnlAddNew.Size = new System.Drawing.Size(496, 38);
            this.pnlAddNew.TabIndex = 19;
            this.pnlAddNew.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Inventory Type:";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(304, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtInventoryType
            // 
            this.txtInventoryType.Location = new System.Drawing.Point(140, 8);
            this.txtInventoryType.MaxLength = 250;
            this.txtInventoryType.Name = "txtInventoryType";
            this.txtInventoryType.Size = new System.Drawing.Size(141, 20);
            this.txtInventoryType.TabIndex = 0;
            this.txtInventoryType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInventoryType_KeyUp);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(83, 3);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 18;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnLoadAll
            // 
            this.btnLoadAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadAll.Location = new System.Drawing.Point(2, 3);
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.Size = new System.Drawing.Size(75, 23);
            this.btnLoadAll.TabIndex = 15;
            this.btnLoadAll.Text = "Load All";
            this.btnLoadAll.UseVisualStyleBackColor = true;
            this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
            // 
            // pnlSaveAll
            // 
            this.pnlSaveAll.Controls.Add(this.btnSaveAll);
            this.pnlSaveAll.Controls.Add(this.btnCancel);
            this.pnlSaveAll.Location = new System.Drawing.Point(197, 326);
            this.pnlSaveAll.Name = "pnlSaveAll";
            this.pnlSaveAll.Size = new System.Drawing.Size(200, 31);
            this.pnlSaveAll.TabIndex = 17;
            this.pnlSaveAll.Visible = false;
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAll.Location = new System.Drawing.Point(17, 5);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAll.TabIndex = 2;
            this.btnSaveAll.Text = "Save All";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(98, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblInvId
            // 
            this.lblInvId.AutoSize = true;
            this.lblInvId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvId.Location = new System.Drawing.Point(370, 6);
            this.lblInvId.Name = "lblInvId";
            this.lblInvId.Size = new System.Drawing.Size(0, 17);
            this.lblInvId.TabIndex = 16;
            this.lblInvId.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(164, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 20;
            this.btnPrint.Text = "Print All";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // grdViewInventoryType
            // 
            this.grdViewInventoryType.AllowUserToAddRows = false;
            this.grdViewInventoryType.AllowUserToDeleteRows = false;
            this.grdViewInventoryType.AllowUserToResizeColumns = false;
            this.grdViewInventoryType.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.grdViewInventoryType.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdViewInventoryType.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdViewInventoryType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdViewInventoryType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdViewInventoryType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdViewInventoryType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InventoryTypeId,
            this.InventoryTypeName,
            this.btnEdit,
            this.btnDelete});
            this.grdViewInventoryType.Location = new System.Drawing.Point(0, 93);
            this.grdViewInventoryType.Name = "grdViewInventoryType";
            this.grdViewInventoryType.ReadOnly = true;
            this.grdViewInventoryType.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdViewInventoryType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdViewInventoryType.Size = new System.Drawing.Size(584, 232);
            this.grdViewInventoryType.TabIndex = 14;
            this.grdViewInventoryType.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdViewInventoryType_CellClick);
            // 
            // InventoryTypeId
            // 
            this.InventoryTypeId.DataPropertyName = "InventoryTypeId";
            this.InventoryTypeId.HeaderText = "Id";
            this.InventoryTypeId.Name = "InventoryTypeId";
            this.InventoryTypeId.ReadOnly = true;
            this.InventoryTypeId.Visible = false;
            // 
            // InventoryTypeName
            // 
            this.InventoryTypeName.DataPropertyName = "InventoryTypeName";
            this.InventoryTypeName.HeaderText = "Inventory Type";
            this.InventoryTypeName.Name = "InventoryTypeName";
            this.InventoryTypeName.ReadOnly = true;
            this.InventoryTypeName.Width = 200;
            // 
            // btnEdit
            // 
            this.btnEdit.HeaderText = "Edit";
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ReadOnly = true;
            this.btnEdit.Text = "Edit";
            this.btnEdit.ToolTipText = "Edit";
            this.btnEdit.UseColumnTextForButtonValue = true;
            // 
            // btnDelete
            // 
            this.btnDelete.HeaderText = "Delete";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ReadOnly = true;
            this.btnDelete.Text = "Delete";
            this.btnDelete.ToolTipText = "Delete";
            this.btnDelete.UseColumnTextForButtonValue = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(297, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 24);
            this.label7.TabIndex = 22;
            this.label7.Text = "Inventory Type";
            // 
            // FrmInventoryType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pnlAddNew);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnLoadAll);
            this.Controls.Add(this.pnlSaveAll);
            this.Controls.Add(this.lblInvId);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.grdViewInventoryType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInventoryType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Type";
            this.Load += new System.EventHandler(this.FrmInventoryType_Load);
            this.pnlAddNew.ResumeLayout(false);
            this.pnlAddNew.PerformLayout();
            this.pnlSaveAll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdViewInventoryType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlAddNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtInventoryType;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnLoadAll;
        private System.Windows.Forms.Panel pnlSaveAll;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblInvId;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView grdViewInventoryType;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryTypeName;
        private System.Windows.Forms.DataGridViewButtonColumn btnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn btnDelete;
        private System.Windows.Forms.Label label7;
    }
}