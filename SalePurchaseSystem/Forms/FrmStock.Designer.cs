namespace SalePurchaseSystem.Forms
{
    partial class FrmStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStock));
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStkId = new System.Windows.Forms.Label();
            this.pnlSaveAll = new System.Windows.Forms.Panel();
            this.grdViewStock = new System.Windows.Forms.DataGridView();
            this.StockId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.InventoryTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpProcessDate = new System.Windows.Forms.DateTimePicker();
            this.cmbInventoryType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbInventory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtNumberCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNoInStock = new System.Windows.Forms.Label();
            this.btnAddInventory = new System.Windows.Forms.Button();
            this.btnReSet = new System.Windows.Forms.Button();
            this.txtInventoryNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlSaveAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewStock)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNew
            // 
            this.btnAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(5, 3);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 36;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAll.Location = new System.Drawing.Point(17, 6);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAll.TabIndex = 11;
            this.btnSaveAll.Text = "Save All";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(98, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStkId
            // 
            this.lblStkId.AutoSize = true;
            this.lblStkId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStkId.Location = new System.Drawing.Point(405, 9);
            this.lblStkId.Name = "lblStkId";
            this.lblStkId.Size = new System.Drawing.Size(0, 17);
            this.lblStkId.TabIndex = 32;
            this.lblStkId.Visible = false;
            // 
            // pnlSaveAll
            // 
            this.pnlSaveAll.Controls.Add(this.btnSaveAll);
            this.pnlSaveAll.Controls.Add(this.btnCancel);
            this.pnlSaveAll.Location = new System.Drawing.Point(272, 463);
            this.pnlSaveAll.Name = "pnlSaveAll";
            this.pnlSaveAll.Size = new System.Drawing.Size(200, 31);
            this.pnlSaveAll.TabIndex = 33;
            this.pnlSaveAll.Visible = false;
            // 
            // grdViewStock
            // 
            this.grdViewStock.AllowUserToAddRows = false;
            this.grdViewStock.AllowUserToDeleteRows = false;
            this.grdViewStock.AllowUserToResizeColumns = false;
            this.grdViewStock.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.grdViewStock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdViewStock.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdViewStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdViewStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdViewStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdViewStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockId,
            this.InventoryTypeName,
            this.InventoryName,
            this.InventoryNumber,
            this.NumberCount,
            this.Price,
            this.btnEdit,
            this.btnDelete,
            this.InventoryTypeId,
            this.InventoryId});
            this.grdViewStock.Location = new System.Drawing.Point(1, 120);
            this.grdViewStock.Name = "grdViewStock";
            this.grdViewStock.ReadOnly = true;
            this.grdViewStock.RowHeadersWidth = 20;
            this.grdViewStock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdViewStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdViewStock.Size = new System.Drawing.Size(793, 346);
            this.grdViewStock.TabIndex = 30;
            this.grdViewStock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdViewStock_CellClick);
            // 
            // StockId
            // 
            this.StockId.DataPropertyName = "StockId";
            this.StockId.HeaderText = "Id";
            this.StockId.Name = "StockId";
            this.StockId.ReadOnly = true;
            this.StockId.Visible = false;
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
            this.InventoryNumber.Width = 120;
            // 
            // NumberCount
            // 
            this.NumberCount.DataPropertyName = "NumberCount";
            this.NumberCount.HeaderText = "Count";
            this.NumberCount.Name = "NumberCount";
            this.NumberCount.ReadOnly = true;
            this.NumberCount.ToolTipText = "Number Count";
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.ToolTipText = "Price";
            this.Price.Width = 150;
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
            // InventoryTypeId
            // 
            this.InventoryTypeId.DataPropertyName = "InventoryTypeId";
            this.InventoryTypeId.HeaderText = "InventoryTypeId";
            this.InventoryTypeId.Name = "InventoryTypeId";
            this.InventoryTypeId.ReadOnly = true;
            this.InventoryTypeId.Visible = false;
            // 
            // InventoryId
            // 
            this.InventoryId.DataPropertyName = "InventoryId";
            this.InventoryId.HeaderText = "InventoryId";
            this.InventoryId.Name = "InventoryId";
            this.InventoryId.ReadOnly = true;
            this.InventoryId.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(369, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(84, 24);
            this.lblTitle.TabIndex = 35;
            this.lblTitle.Text = "Stock In";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(167, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 64;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 17);
            this.label9.TabIndex = 78;
            this.label9.Text = "Inventory Type:";
            // 
            // dtpProcessDate
            // 
            this.dtpProcessDate.CustomFormat = "dd-MMM-yyyy hh:mm:ss tt";
            this.dtpProcessDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpProcessDate.Location = new System.Drawing.Point(376, 67);
            this.dtpProcessDate.Name = "dtpProcessDate";
            this.dtpProcessDate.Size = new System.Drawing.Size(170, 20);
            this.dtpProcessDate.TabIndex = 3;
            this.dtpProcessDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // cmbInventoryType
            // 
            this.cmbInventoryType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbInventoryType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbInventoryType.DisplayMember = "Text";
            this.cmbInventoryType.FormattingEnabled = true;
            this.cmbInventoryType.Location = new System.Drawing.Point(130, 39);
            this.cmbInventoryType.Name = "cmbInventoryType";
            this.cmbInventoryType.Size = new System.Drawing.Size(141, 21);
            this.cmbInventoryType.TabIndex = 0;
            this.cmbInventoryType.ValueMember = "Value";
            this.cmbInventoryType.SelectedIndexChanged += new System.EventHandler(this.cmbInventoryType_SelectedIndexChanged);
            this.cmbInventoryType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.myCombo_KeyPress);
            this.cmbInventoryType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(323, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 77;
            this.label3.Text = "Date:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(130, 67);
            this.txtPrice.MaxLength = 10;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(141, 20);
            this.txtPrice.TabIndex = 2;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPay_KeyPress);
            this.txtPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(33, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 17);
            this.label8.TabIndex = 76;
            this.label8.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(130, 93);
            this.txtDescription.MaxLength = 8000;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(416, 20);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(76, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 75;
            this.label5.Text = "Price:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(291, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 73;
            this.label2.Text = "Inventory:";
            // 
            // cmbInventory
            // 
            this.cmbInventory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbInventory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbInventory.DisplayMember = "Text";
            this.cmbInventory.FormattingEnabled = true;
            this.cmbInventory.Location = new System.Drawing.Point(375, 39);
            this.cmbInventory.Name = "cmbInventory";
            this.cmbInventory.Size = new System.Drawing.Size(171, 21);
            this.cmbInventory.TabIndex = 1;
            this.cmbInventory.ValueMember = "Value";
            this.cmbInventory.SelectedIndexChanged += new System.EventHandler(this.cmbInventory_SelectedIndexChanged);
            this.cmbInventory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.myCombo_KeyPress);
            this.cmbInventory.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(579, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 71;
            this.label1.Text = "Count:";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(583, 91);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtNumberCount
            // 
            this.txtNumberCount.Location = new System.Drawing.Point(640, 67);
            this.txtNumberCount.MaxLength = 10;
            this.txtNumberCount.Name = "txtNumberCount";
            this.txtNumberCount.Size = new System.Drawing.Size(71, 20);
            this.txtNumberCount.TabIndex = 4;
            this.txtNumberCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPay_KeyPress);
            this.txtNumberCount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(578, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 79;
            this.label4.Text = "No In Stock:";
            // 
            // lblNoInStock
            // 
            this.lblNoInStock.AutoSize = true;
            this.lblNoInStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoInStock.Location = new System.Drawing.Point(691, 11);
            this.lblNoInStock.Name = "lblNoInStock";
            this.lblNoInStock.Size = new System.Drawing.Size(0, 17);
            this.lblNoInStock.TabIndex = 80;
            // 
            // btnAddInventory
            // 
            this.btnAddInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInventory.Location = new System.Drawing.Point(375, 39);
            this.btnAddInventory.Name = "btnAddInventory";
            this.btnAddInventory.Size = new System.Drawing.Size(171, 23);
            this.btnAddInventory.TabIndex = 81;
            this.btnAddInventory.Text = "Add Inventory";
            this.btnAddInventory.UseVisualStyleBackColor = true;
            this.btnAddInventory.Visible = false;
            this.btnAddInventory.Click += new System.EventHandler(this.btnAddInventory_Click);
            // 
            // btnReSet
            // 
            this.btnReSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReSet.Location = new System.Drawing.Point(86, 4);
            this.btnReSet.Name = "btnReSet";
            this.btnReSet.Size = new System.Drawing.Size(75, 23);
            this.btnReSet.TabIndex = 82;
            this.btnReSet.Text = "Reset";
            this.btnReSet.UseVisualStyleBackColor = true;
            // 
            // txtInventoryNumber
            // 
            this.txtInventoryNumber.Location = new System.Drawing.Point(640, 40);
            this.txtInventoryNumber.MaxLength = 250;
            this.txtInventoryNumber.Name = "txtInventoryNumber";
            this.txtInventoryNumber.ReadOnly = true;
            this.txtInventoryNumber.Size = new System.Drawing.Size(136, 20);
            this.txtInventoryNumber.TabIndex = 83;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(579, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 17);
            this.label6.TabIndex = 84;
            this.label6.Text = "No:";
            // 
            // FrmStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 496);
            this.Controls.Add(this.txtInventoryNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnReSet);
            this.Controls.Add(this.btnAddInventory);
            this.Controls.Add(this.lblNoInStock);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpProcessDate);
            this.Controls.Add(this.cmbInventoryType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbInventory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtNumberCount);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.lblStkId);
            this.Controls.Add(this.pnlSaveAll);
            this.Controls.Add(this.grdViewStock);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock In";
            this.Load += new System.EventHandler(this.FrmStock_Load);
            this.pnlSaveAll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdViewStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStkId;
        private System.Windows.Forms.Panel pnlSaveAll;
        private System.Windows.Forms.DataGridView grdViewStock;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpProcessDate;
        private System.Windows.Forms.ComboBox cmbInventoryType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbInventory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtNumberCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNoInStock;
        private System.Windows.Forms.Button btnAddInventory;
        private System.Windows.Forms.Button btnReSet;
        private System.Windows.Forms.TextBox txtInventoryNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewButtonColumn btnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryId;
    }
}