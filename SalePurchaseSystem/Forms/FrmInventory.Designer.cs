namespace SalePurchaseSystem.Forms
{
    partial class FrmInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventory));
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grdViewInventory = new System.Windows.Forms.DataGridView();
            this.InventoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitialPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtInitialPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbInventoryType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtInventoryName = new System.Windows.Forms.TextBox();
            this.lblInvId = new System.Windows.Forms.Label();
            this.pnlAddNew = new System.Windows.Forms.Panel();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlNumberCount = new System.Windows.Forms.Panel();
            this.txtNumberCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStockAdd = new System.Windows.Forms.Label();
            this.chkAddToStock = new System.Windows.Forms.CheckBox();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnLoadAll = new System.Windows.Forms.Button();
            this.pnlSaveAll = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewInventory)).BeginInit();
            this.pnlAddNew.SuspendLayout();
            this.pnlNumberCount.SuspendLayout();
            this.pnlSaveAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(285, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 24);
            this.label7.TabIndex = 26;
            this.label7.Text = "Inventory";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(46, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(156, 61);
            this.txtDescription.MaxLength = 8000;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(455, 20);
            this.txtDescription.TabIndex = 4;
            
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(340, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Initial Price:";
            // 
            // grdViewInventory
            // 
            this.grdViewInventory.AllowUserToAddRows = false;
            this.grdViewInventory.AllowUserToDeleteRows = false;
            this.grdViewInventory.AllowUserToResizeColumns = false;
            this.grdViewInventory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.grdViewInventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdViewInventory.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdViewInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdViewInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdViewInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdViewInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InventoryId,
            this.InventoryName,
            this.InventoryNumber,
            this.InventoryTypeName,
            this.InitialPrice,
            this.btnEdit,
            this.btnDelete});
            this.grdViewInventory.Location = new System.Drawing.Point(0, 183);
            this.grdViewInventory.Name = "grdViewInventory";
            this.grdViewInventory.ReadOnly = true;
            this.grdViewInventory.RowHeadersWidth = 20;
            this.grdViewInventory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdViewInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdViewInventory.Size = new System.Drawing.Size(688, 356);
            this.grdViewInventory.TabIndex = 21;
            this.grdViewInventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdViewInventory_CellClick);
            // 
            // InventoryId
            // 
            this.InventoryId.DataPropertyName = "InventoryId";
            this.InventoryId.HeaderText = "Id";
            this.InventoryId.Name = "InventoryId";
            this.InventoryId.ReadOnly = true;
            this.InventoryId.Visible = false;
            // 
            // InventoryName
            // 
            this.InventoryName.DataPropertyName = "InventoryName";
            this.InventoryName.HeaderText = "Name";
            this.InventoryName.Name = "InventoryName";
            this.InventoryName.ReadOnly = true;
            this.InventoryName.ToolTipText = "Inventory Name";
            this.InventoryName.Width = 150;
            // 
            // InventoryNumber
            // 
            this.InventoryNumber.DataPropertyName = "InventoryNumber";
            this.InventoryNumber.HeaderText = "Number";
            this.InventoryNumber.Name = "InventoryNumber";
            this.InventoryNumber.ReadOnly = true;
            this.InventoryNumber.ToolTipText = "Inventory Number";
            // 
            // InventoryTypeName
            // 
            this.InventoryTypeName.DataPropertyName = "InventoryTypeName";
            this.InventoryTypeName.HeaderText = "Inventory Type";
            this.InventoryTypeName.Name = "InventoryTypeName";
            this.InventoryTypeName.ReadOnly = true;
            this.InventoryTypeName.ToolTipText = "Inventory Type";
            this.InventoryTypeName.Width = 150;
            // 
            // InitialPrice
            // 
            this.InitialPrice.DataPropertyName = "InitialPrice";
            this.InitialPrice.HeaderText = "Initial Price";
            this.InitialPrice.Name = "InitialPrice";
            this.InitialPrice.ReadOnly = true;
            this.InitialPrice.ToolTipText = "Initial Price";
            this.InitialPrice.Width = 150;
            // 
            // btnEdit
            // 
            this.btnEdit.HeaderText = "Edit";
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ReadOnly = true;
            this.btnEdit.Text = "Edit";
            this.btnEdit.ToolTipText = "Edit";
            this.btnEdit.UseColumnTextForButtonValue = true;
            this.btnEdit.Width = 50;
            // 
            // btnDelete
            // 
            this.btnDelete.HeaderText = "Delete";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ReadOnly = true;
            this.btnDelete.Text = "Delete";
            this.btnDelete.ToolTipText = "Delete";
            this.btnDelete.UseColumnTextForButtonValue = true;
            this.btnDelete.Width = 50;
            // 
            // txtInitialPrice
            // 
            this.txtInitialPrice.Location = new System.Drawing.Point(470, 34);
            this.txtInitialPrice.MaxLength = 10;
            this.txtInitialPrice.Name = "txtInitialPrice";
            this.txtInitialPrice.Size = new System.Drawing.Size(141, 20);
            this.txtInitialPrice.TabIndex = 3;
            
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(340, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Inventory Type:";
            // 
            // cmbInventoryType
            // 
            this.cmbInventoryType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbInventoryType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbInventoryType.DisplayMember = "Text";
            this.cmbInventoryType.FormattingEnabled = true;
            this.cmbInventoryType.Location = new System.Drawing.Point(470, 7);
            this.cmbInventoryType.Name = "cmbInventoryType";
            this.cmbInventoryType.Size = new System.Drawing.Size(141, 21);
            this.cmbInventoryType.TabIndex = 1;
            this.cmbInventoryType.ValueMember = "Value";
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name:";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(156, 114);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtInventoryName
            // 
            this.txtInventoryName.Location = new System.Drawing.Point(156, 7);
            this.txtInventoryName.MaxLength = 250;
            this.txtInventoryName.Name = "txtInventoryName";
            this.txtInventoryName.Size = new System.Drawing.Size(141, 20);
            this.txtInventoryName.TabIndex = 0;
            
            // 
            // lblInvId
            // 
            this.lblInvId.AutoSize = true;
            this.lblInvId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvId.Location = new System.Drawing.Point(428, 9);
            this.lblInvId.Name = "lblInvId";
            this.lblInvId.Size = new System.Drawing.Size(0, 17);
            this.lblInvId.TabIndex = 23;
            this.lblInvId.Visible = false;
            // 
            // pnlAddNew
            // 
            this.pnlAddNew.Controls.Add(this.txtNumber);
            this.pnlAddNew.Controls.Add(this.label3);
            this.pnlAddNew.Controls.Add(this.pnlNumberCount);
            this.pnlAddNew.Controls.Add(this.lblStockAdd);
            this.pnlAddNew.Controls.Add(this.chkAddToStock);
            this.pnlAddNew.Controls.Add(this.txtInitialPrice);
            this.pnlAddNew.Controls.Add(this.label8);
            this.pnlAddNew.Controls.Add(this.txtDescription);
            this.pnlAddNew.Controls.Add(this.label5);
            this.pnlAddNew.Controls.Add(this.label2);
            this.pnlAddNew.Controls.Add(this.cmbInventoryType);
            this.pnlAddNew.Controls.Add(this.label1);
            this.pnlAddNew.Controls.Add(this.btnAdd);
            this.pnlAddNew.Controls.Add(this.txtInventoryName);
            this.pnlAddNew.Location = new System.Drawing.Point(3, 36);
            this.pnlAddNew.Name = "pnlAddNew";
            this.pnlAddNew.Size = new System.Drawing.Size(658, 142);
            this.pnlAddNew.TabIndex = 28;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(156, 35);
            this.txtNumber.MaxLength = 50;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(141, 20);
            this.txtNumber.TabIndex = 2;
            
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Number:";
            // 
            // pnlNumberCount
            // 
            this.pnlNumberCount.Controls.Add(this.txtNumberCount);
            this.pnlNumberCount.Controls.Add(this.label4);
            this.pnlNumberCount.Location = new System.Drawing.Point(285, 87);
            this.pnlNumberCount.Name = "pnlNumberCount";
            this.pnlNumberCount.Size = new System.Drawing.Size(326, 35);
            this.pnlNumberCount.TabIndex = 22;
            this.pnlNumberCount.Visible = false;
            // 
            // txtNumberCount
            // 
            this.txtNumberCount.Location = new System.Drawing.Point(142, 5);
            this.txtNumberCount.MaxLength = 10;
            this.txtNumberCount.Name = "txtNumberCount";
            this.txtNumberCount.Size = new System.Drawing.Size(141, 20);
            this.txtNumberCount.TabIndex = 20;
            this.txtNumberCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPay_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Number Count:";
            // 
            // lblStockAdd
            // 
            this.lblStockAdd.AutoSize = true;
            this.lblStockAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockAdd.Location = new System.Drawing.Point(46, 88);
            this.lblStockAdd.Name = "lblStockAdd";
            this.lblStockAdd.Size = new System.Drawing.Size(110, 17);
            this.lblStockAdd.TabIndex = 19;
            this.lblStockAdd.Text = "Add To Stock:";
            // 
            // chkAddToStock
            // 
            this.chkAddToStock.AutoSize = true;
            this.chkAddToStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAddToStock.Location = new System.Drawing.Point(157, 91);
            this.chkAddToStock.Name = "chkAddToStock";
            this.chkAddToStock.Size = new System.Drawing.Size(104, 17);
            this.chkAddToStock.TabIndex = 5;
            this.chkAddToStock.Text = "Add To Stock";
            this.chkAddToStock.UseVisualStyleBackColor = true;
            this.chkAddToStock.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAll.Location = new System.Drawing.Point(17, 5);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAll.TabIndex = 7;
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
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(91, 3);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 27;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnLoadAll
            // 
            this.btnLoadAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadAll.Location = new System.Drawing.Point(10, 3);
            this.btnLoadAll.Name = "btnLoadAll";
            this.btnLoadAll.Size = new System.Drawing.Size(75, 23);
            this.btnLoadAll.TabIndex = 22;
            this.btnLoadAll.Text = "Load All";
            this.btnLoadAll.UseVisualStyleBackColor = true;
            this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
            // 
            // pnlSaveAll
            // 
            this.pnlSaveAll.Controls.Add(this.btnSaveAll);
            this.pnlSaveAll.Controls.Add(this.btnCancel);
            this.pnlSaveAll.Location = new System.Drawing.Point(228, 542);
            this.pnlSaveAll.Name = "pnlSaveAll";
            this.pnlSaveAll.Size = new System.Drawing.Size(200, 31);
            this.pnlSaveAll.TabIndex = 24;
            this.pnlSaveAll.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(172, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 29;
            this.btnPrint.Text = "Print All";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FrmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 571);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grdViewInventory);
            this.Controls.Add(this.lblInvId);
            this.Controls.Add(this.pnlAddNew);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnLoadAll);
            this.Controls.Add(this.pnlSaveAll);
            this.Controls.Add(this.btnPrint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.FrmInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdViewInventory)).EndInit();
            this.pnlAddNew.ResumeLayout(false);
            this.pnlAddNew.PerformLayout();
            this.pnlNumberCount.ResumeLayout(false);
            this.pnlNumberCount.PerformLayout();
            this.pnlSaveAll.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView grdViewInventory;
        private System.Windows.Forms.TextBox txtInitialPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbInventoryType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtInventoryName;
        private System.Windows.Forms.Label lblInvId;
        private System.Windows.Forms.Panel pnlAddNew;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnLoadAll;
        private System.Windows.Forms.Panel pnlSaveAll;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox chkAddToStock;
        private System.Windows.Forms.Label lblStockAdd;
        private System.Windows.Forms.TextBox txtNumberCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlNumberCount;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitialPrice;
        private System.Windows.Forms.DataGridViewButtonColumn btnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn btnDelete;
    }
}