using DataAccess.Common;
using DataAccess.CustomRepositories;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalePurchaseSystem.Forms
{
    public partial class FrmStock : Form
    {
        private StockRepo _repository;
        private Stock tempStk;
        private bool _isPurchase = true;
        private DateTime _startDate;
        private DateTime _endDate;

        public FrmStock()
        {
            InitializeComponent();
            _repository = new StockRepo();
            tempStk = new Stock();
        }

        public FrmStock(bool isPurchase)
        {
            InitializeComponent();
            _repository = new StockRepo();
            tempStk = new Stock();
            _isPurchase = isPurchase;
            grdViewStock.AutoGenerateColumns = false;
            BindingList<Stock> newlist = new BindingList<Stock>();
            grdViewStock.DataSource = newlist;
            if (isPurchase == true)
            {
                lblTitle.Text = "Stock In";
            }
            else
            {
                lblTitle.Text = "Stock Out";
            }
        }


        public FrmStock(DateTime startDate, DateTime endDate, bool isPurchase)
        {
            try
            {
                InitializeComponent();
                grdViewStock.AutoGenerateColumns = false;
                _repository = new StockRepo();
                _startDate = startDate;
                _endDate = endDate;
                var listStk = _repository.GetAllStocksByDate(startDate, endDate, isPurchase);
                BindingList<Stock> newlist = new BindingList<Stock>(listStk);
                grdViewStock.DataSource = newlist;
                _isPurchase = isPurchase;
                if (isPurchase == true)
                {
                    lblTitle.Text = "Stock In";
                }
                else
                {
                    lblTitle.Text = "Stock Out";
                }
                btnPrint.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmStock_Load(object sender, EventArgs e)
        {
            try
            {
                var list = _repository.GetLookUpList("InventoryType");
                cmbInventoryType.DataSource = list;
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Convert.ToInt32(txtNumberCount.Text) <= 0) || (txtPrice.Text.Trim() == ""))
                {
                    MessageBox.Show("Please add number and price", "Add all...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //if (_isPurchase == false)
                //{
                if (Convert.ToInt32(txtNumberCount.Text) > Convert.ToInt32(lblNoInStock.Text))
                {
                    MessageBox.Show("Out of Stock", "Wrong Add...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int totalSale = 0;

                if (grdViewStock.Rows.Count > 0)
                {
                    int i = 0;

                    totalSale = Convert.ToInt32(txtNumberCount.Text);
                    foreach (DataGridViewRow row in grdViewStock.Rows)
                    {
                        if (Convert.ToInt32(row.Cells[9].Value) == Convert.ToInt32(cmbInventory.SelectedValue))
                        {
                            totalSale = totalSale + Convert.ToInt32(row.Cells[4].Value);
                            i++;
                        }
                    }
                    if (i > 0)
                    {
                        if (totalSale > Convert.ToInt32(lblNoInStock.Text))
                        {
                            MessageBox.Show("Out of Stock", "Wrong Add...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                //}

                Stock stk = new Stock()
                {
                    StockId = 0,
                    InventoryTypeId = Convert.ToInt32(cmbInventoryType.SelectedValue),
                    InventoryId = Convert.ToInt32(cmbInventory.SelectedValue),
                    Price = Convert.ToDecimal(txtPrice.Text),
                    Description = txtDescription.Text,
                    IsPurchase = _isPurchase,
                    ProcessDate = dtpProcessDate.Value,
                    InventoryTypeName = (cmbInventoryType.SelectedItem as LookupDO).Text,
                    InventoryName = (cmbInventory.SelectedItem as LookupDO).Text,
                    InventoryNumber = txtInventoryNumber.Text,
                    NumberCount = Convert.ToInt32(txtNumberCount.Text)
                };

                if (btnAdd.Text == "Update")
                {
                    if (lblStkId.Text != "0")
                    {
                        stk.StockId = Convert.ToInt32(lblStkId.Text);
                        _repository.SaveStock(stk);
                        MessageBox.Show("Stock Updated Successfully", "Updated...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblNoInStock.Text = Convert.ToString(_repository.GetNumberInStock(Convert.ToInt32(cmbInventory.SelectedValue)));
                    }
                    else
                    {
                        var dataSource = grdViewStock.DataSource;

                        foreach (DataGridViewRow row in grdViewStock.Rows)
                        {
                            var thsStk = row.DataBoundItem as Stock;
                            if (tempStk == thsStk)
                            {
                                (row.DataBoundItem as Stock).InventoryTypeId = stk.InventoryTypeId;
                                (row.DataBoundItem as Stock).InventoryId = stk.InventoryId;
                                (row.DataBoundItem as Stock).Price = stk.Price;
                                (row.DataBoundItem as Stock).Description = stk.Description;
                                (row.DataBoundItem as Stock).IsPurchase = stk.IsPurchase;
                                (row.DataBoundItem as Stock).ProcessDate = stk.ProcessDate;
                                (row.DataBoundItem as Stock).InventoryTypeName = stk.InventoryTypeName;
                                (row.DataBoundItem as Stock).InventoryName = stk.InventoryName;
                                (row.DataBoundItem as Stock).InventoryNumber = stk.InventoryNumber;
                                (row.DataBoundItem as Stock).NumberCount = stk.NumberCount;
                                break;
                            }
                        }
                        grdViewStock.Refresh();
                    }
                    btnAdd.Text = "Add";
                }
                else
                {
                    var dataSource = grdViewStock.DataSource;
                    (dataSource as BindingList<Stock>).Add(stk);
                    grdViewStock.DataSource = dataSource;
                    grdViewStock.Refresh();
                    pnlSaveAll.Visible = true;
                }

                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            try
            {
                List<Stock> stks = new List<Stock>();
                foreach (DataGridViewRow row in grdViewStock.Rows)
                {
                    Stock stk = row.DataBoundItem as Stock;
                    stk.CurrentDate = DateTime.Now;
                    stks.Add(stk);
                }
                _repository.SaveAllStocks(stks);
                MessageBox.Show("All Stock Add Successfully", "Add...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll();
                BindingList<Stock> newlist = new BindingList<Stock>();
                grdViewStock.DataSource = newlist;
                lblNoInStock.Text = Convert.ToString(_repository.GetNumberInStock(Convert.ToInt32(cmbInventory.SelectedValue)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (PreCancelConfirmation() == System.Windows.Forms.DialogResult.Yes)
            {
                ClearAll();
            }
        }

        private void grdViewStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (((e.ColumnIndex == 6) || (e.ColumnIndex == 7)) && (e.RowIndex != -1))
                {
                    int rowIndex = e.RowIndex;
                    DataGridViewRow row = grdViewStock.Rows[rowIndex];

                    if (e.ColumnIndex == 6)
                    {
                        lblStkId.Text = Convert.ToString(row.Cells[0].Value);

                        if (lblStkId.Text != "0")
                        {
                            var InvObj = _repository.GetAllStocksById(Convert.ToInt32(row.Cells[0].Value));
                            txtDescription.Text = InvObj.Description;
                            txtNumberCount.Text = Convert.ToString(InvObj.NumberCount);
                            cmbInventoryType.SelectedValue = InvObj.InventoryTypeId;
                            cmbInventory.SelectedValue = InvObj.InventoryId;
                            dtpProcessDate.Value = InvObj.ProcessDate;
                            txtPrice.Text = string.Format("{0:#,##0}", double.Parse(Convert.ToString(InvObj.Price)));
                            txtDescription.Text = InvObj.Description;
                            lblNoInStock.Text = Convert.ToString(_repository.GetNumberInStock(Convert.ToInt32(cmbInventory.SelectedValue)));
                        }
                        else
                        {
                            tempStk = row.DataBoundItem as Stock;
                            txtDescription.Text = tempStk.Description;
                            txtNumberCount.Text = Convert.ToString(tempStk.NumberCount);
                            cmbInventoryType.SelectedValue = tempStk.InventoryTypeId;
                            cmbInventory.SelectedValue = tempStk.InventoryId;
                            dtpProcessDate.Value = tempStk.ProcessDate;
                            txtPrice.Text = string.Format("{0:#,##0}", double.Parse(Convert.ToString(tempStk.Price)));
                        }
                        btnAdd.Text = "Update";
                    }

                    if (e.ColumnIndex == 7)
                    {
                        if (PreDeleteConfirmation() == System.Windows.Forms.DialogResult.Yes)
                        {
                            var StockId = Convert.ToInt32(row.Cells[0].Value);

                            foreach (DataGridViewRow rr in grdViewStock.Rows)
                            {
                                if (rr == row)
                                {
                                    grdViewStock.Rows.RemoveAt(rr.Index);
                                    break;
                                }
                            }
                            grdViewStock.Refresh();

                            if (StockId != 0)
                            {
                                _repository.DeleteStock(StockId);
                                MessageBox.Show("Stock Deleted Successfully", "Deleted...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearAll();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DialogResult PreDeleteConfirmation()
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Delete?          ", "Delete...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res;
        }

        private DialogResult PreCancelConfirmation()
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Cancel?          ", "Cancel...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res;
        }

        private void ClearAll()
        {
            lblStkId.Text = "";
            txtDescription.Text = "";
            txtNumberCount.Text = "";
            txtPrice.Text = "";
            cmbInventoryType.Focus();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            cmbInventoryType.Focus();
            BindingList<Stock> newlist = new BindingList<Stock>();
            grdViewStock.DataSource = newlist;
            btnAdd.Text = "Add";
        }

        private void myCombo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = Application.OpenForms["frmRptStockByDate"];
                if (f != null)
                    f.Close();

                //frmRptStockByDate rept = new frmRptStockByDate();
                //rept.MdiParent = this.MdiParent;

                //var cnBuilder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SaleEntities"].ConnectionString);
                //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(cnBuilder.ProviderConnectionString);
                //string genusSqlServerName = sqlConnectionStringBuilder.DataSource;
                //string genusDatabaseName = sqlConnectionStringBuilder.InitialCatalog;
                //string genusUserName = sqlConnectionStringBuilder.UserID;
                //string genusPassword = sqlConnectionStringBuilder.Password;
                //rept.RptStockByDate1.DataSourceConnections[0].IntegratedSecurity = false;
                //rept.RptStockByDate1.DataSourceConnections[0].SetConnection(genusSqlServerName, genusDatabaseName, genusUserName, genusPassword);
                //rept.crystalReportViewer1.SelectionFormula =
                //    "{Stock.ProcessDate}>=#" + _startDate.ToString() + "# and {Stock.ProcessDate}<= #" + _endDate.ToString() + "# and {Stock.IsPurchase}= " + _isPurchase.ToString();
                //rept.RptStockByDate1.Refresh();
                //rept.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Control_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void txtPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmbInventoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var val = Convert.ToInt32(((ComboBox)sender).SelectedValue);
                var list = new InventoryRepo().GetInventoryByType(val);
                cmbInventory.DataSource = list;
                if (list.Count == 0)
                {
                    cmbInventory.Text = "";
                    btnAddInventory.Visible = true;
                }
                else
                {
                    btnAddInventory.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblNoInStock.Text = Convert.ToString(_repository.GetNumberInStock(Convert.ToInt32((sender as ComboBox).SelectedValue)));
                txtInventoryNumber.Text = (new InventoryRepo()).GetInventoryById(Convert.ToInt32((sender as ComboBox).SelectedValue)).InventoryNumber;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddInventory_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = Application.OpenForms["FrmInventory"];
                if (f != null)
                    f.BringToFront();
                else
                {
                    FrmInventory inv = new FrmInventory();
                    inv.MdiParent = this.MdiParent;
                    inv.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
