using DataAccess.Common;
using DataAccess.CustomRepositories;
using DataAccess.EntityFramework;
using SalePurchaseSystem.Reports;
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
    public partial class FrmInventory : Form
    {
        private InventoryRepo _repository;
        private Inventory tempInv;

        public FrmInventory()
        {
            InitializeComponent();
            _repository = new InventoryRepo();
            tempInv = new Inventory();
        }

        private void FrmInventory_Load(object sender, EventArgs e)
        {
            try
            {
                grdViewInventory.AutoGenerateColumns = false;
                cmbInventoryType.DataSource = _repository.GetLookUpList("InventoryType");
                ReSetAll();
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
                if ((txtInventoryName.Text.Trim() == "") || (txtNumber.Text.Trim() == "") || (txtInitialPrice.Text == "") || cmbInventoryType.SelectedValue == null)
                {
                    MessageBox.Show("Please enter all data", "Add...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInventoryName.Focus();
                    return;
                }

                Inventory Inv = new Inventory()
                {
                    InventoryName = txtInventoryName.Text,
                    InventoryNumber = txtNumber.Text,
                    InventoryTypeId = Convert.ToInt32(cmbInventoryType.SelectedValue),
                    InitialPrice = Convert.ToDecimal(txtInitialPrice.Text),
                    Description = txtDescription.Text,
                    InventoryTypeName = (cmbInventoryType.SelectedItem as LookupDO).Text,
                    IsAddedToStock = chkAddToStock.Checked,
                };

                if (btnAdd.Text == "Update")
                {
                    if (lblInvId.Text != "0")
                    {
                        Inv.InventoryId = Convert.ToInt32(lblInvId.Text);
                        _repository.SaveInventory(Inv);
                        MessageBox.Show("Inventory Updated Successfully", "Updated...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAll();                      
                    }
                    else
                    {
                        var dataSource = grdViewInventory.DataSource;

                        foreach (DataGridViewRow row in grdViewInventory.Rows)
                        {
                            var thsInv = row.DataBoundItem as Inventory;
                            if (tempInv == thsInv)
                            {
                                (row.DataBoundItem as Inventory).InventoryName = Inv.InventoryName;
                                (row.DataBoundItem as Inventory).InventoryTypeId = Inv.InventoryTypeId;
                                (row.DataBoundItem as Inventory).InventoryTypeName = Inv.InventoryTypeName;
                                (row.DataBoundItem as Inventory).IsAddedToStock = Inv.IsAddedToStock;
                                (row.DataBoundItem as Inventory).InitialPrice = Inv.InitialPrice;
                                (row.DataBoundItem as Inventory).Description = Inv.Description;
                                (row.DataBoundItem as Inventory).InventoryId = Inv.InventoryId;
                                (row.DataBoundItem as Inventory).NumberCount = Inv.NumberCount;
                                (row.DataBoundItem as Inventory).InventoryNumber = Inv.InventoryNumber;
                                break;
                            }
                        }
                        grdViewInventory.Refresh();
                    }
                    ClearAll();
                    //pnlSaveAll.Visible = true;
                }
                else
                {
                    if (_repository.CheckExistingInventory(txtNumber.Text, txtInventoryName.Text, Convert.ToInt32(cmbInventoryType.SelectedValue)))
                    {
                        Inv.NumberCount = txtNumberCount.Text.Trim().Length == 0 ? 1 : Convert.ToInt32(txtNumberCount.Text);
                        var dataSource = grdViewInventory.DataSource;
                        (dataSource as BindingList<Inventory>).Add(Inv);
                        grdViewInventory.DataSource = dataSource;
                        grdViewInventory.Refresh();
                        ClearAll();
                        pnlSaveAll.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Inventory Already Exists", "Already Exists...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
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
                List<Inventory> Invs = new List<Inventory>();
                foreach (DataGridViewRow row in grdViewInventory.Rows)
                {
                    Inventory Inv = row.DataBoundItem as Inventory;
                    Inv.CurrentDate = DateTime.Now;

                    if (Inv.IsAddedToStock == true)
                    {
                        var stkItem = new Stock()
                        {
                            CurrentDate = DateTime.Now,
                            IsPurchase = true,
                            Price = Inv.InitialPrice,
                            NumberCount = Inv.NumberCount,
                            ProcessDate = DateTime.Now
                        };
                        Inv.Stocks.Add(stkItem);
                    }

                    Invs.Add(Inv);
                }
                _repository.SaveAllInventorys(Invs);
                MessageBox.Show("All Inventory Add Successfully", "Add...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReSetAll();
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
                ReSetAll();
            }
        }

        private void grdViewInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (((e.ColumnIndex == 5) || (e.ColumnIndex == 6)) && (e.RowIndex != -1))
                {
                    int rowIndex = e.RowIndex;
                    DataGridViewRow row = grdViewInventory.Rows[rowIndex];

                    if (e.ColumnIndex == 5)
                    {
                        lblInvId.Text = Convert.ToString(row.Cells[0].Value);

                        if (tempInv.IsAddedToStock == true)
                        {
                            pnlNumberCount.Visible = true;
                            chkAddToStock.Checked = true;
                            lblStockAdd.Visible = true;
                            chkAddToStock.Visible = true;
                        }
                        else
                        {
                            lblStockAdd.Visible = false;
                            chkAddToStock.Visible = false;
                        }

                        if (lblInvId.Text != "0")
                        {
                            var InvObj = _repository.Find(Convert.ToInt32(row.Cells[0].Value));
                            txtInventoryName.Text = InvObj.InventoryName;
                            txtNumber.Text = InvObj.InventoryNumber;
                            txtInitialPrice.Text = string.Format("{0:#,##0}", double.Parse(Convert.ToString(InvObj.InitialPrice)));
                            txtDescription.Text = InvObj.Description;
                            cmbInventoryType.SelectedValue = InvObj.InventoryTypeId;
                        }
                        else
                        {
                            tempInv = row.DataBoundItem as Inventory;
                            txtInventoryName.Text = tempInv.InventoryName;
                            txtNumber.Text = tempInv.InventoryNumber;
                            txtInitialPrice.Text = string.Format("{0:#,##0}", double.Parse(Convert.ToString(tempInv.InitialPrice)));
                            txtDescription.Text = tempInv.Description;
                            cmbInventoryType.SelectedValue = tempInv.InventoryTypeId;
                            txtNumberCount.Text = Convert.ToString(tempInv.NumberCount);
                        }

                        btnAdd.Text = "Update";
                        pnlAddNew.Visible = true;
                    }

                    if (e.ColumnIndex == 6)
                    {
                        if (PreDeleteConfirmation() == System.Windows.Forms.DialogResult.Yes)
                        {
                            var InventoryId = Convert.ToInt32(row.Cells[0].Value);
                            if (InventoryId == 0)
                            {
                                foreach (DataGridViewRow rr in grdViewInventory.Rows)
                                {
                                    if (rr == row)
                                    {
                                        grdViewInventory.Rows.RemoveAt(rr.Index);
                                        break;
                                    }
                                }
                                grdViewInventory.Refresh();
                            }
                            else
                            {
                                _repository.DeleteInventory(InventoryId);
                                MessageBox.Show("Inventory Deleted Successfully", "Updated...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReSetAll();
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
            //pnlSaveAll.Visible = false;
            pnlNumberCount.Visible = false;
            tempInv = new Inventory();
            lblInvId.Text = "";
            txtInventoryName.Text = "";
            txtInitialPrice.Text = "";
            txtDescription.Text = "";
            txtNumber.Text = "";
            txtNumberCount.Text = "1";
            btnAdd.Text = "Add";
            chkAddToStock.Visible = true;
            chkAddToStock.Checked = false;
            lblStockAdd.Visible = true;
            txtInventoryName.Focus();
        }
        private void ReSetAll()
        {
            ClearAll();
            LoadAll();
        }

        private void LoadAll()
        {
            try
            {
                var listInv = _repository.GetAllInventorys();
                BindingList<Inventory> inv = new BindingList<Inventory>(listInv);
                grdViewInventory.DataSource = listInv;
                pnlAddNew.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            LoadAll();
            pnlAddNew.Visible = false;
            pnlSaveAll.Visible = false;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearAll();
            pnlAddNew.Visible = true;
            txtInventoryName.Focus();
            BindingList<Inventory> newlist = new BindingList<Inventory>();
            grdViewInventory.DataSource = newlist;
        }

        private void myCombo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = Application.OpenForms["frmRptInventory"];
                if (f != null)
                    f.Close();

                frmRptInventory rept = new frmRptInventory();
                rept.MdiParent = this.MdiParent;

                var cnBuilder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SaleEntities"].ConnectionString);
                SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(cnBuilder.ProviderConnectionString);
                string genusSqlServerName = sqlConnectionStringBuilder.DataSource;
                string genusDatabaseName = sqlConnectionStringBuilder.InitialCatalog;
                string genusUserName = sqlConnectionStringBuilder.UserID;
                string genusPassword = sqlConnectionStringBuilder.Password;
                rept.RptInventory1.DataSourceConnections[0].IntegratedSecurity = false;
                rept.RptInventory1.DataSourceConnections[0].SetConnection(genusSqlServerName, genusDatabaseName, genusUserName, genusPassword);
                rept.RptInventory1.Refresh();
                rept.Show();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAddToStock.Checked == true)
            {
                pnlNumberCount.Visible = true;
                txtNumberCount.Text = "1";
            }
            else
            {
                pnlNumberCount.Visible = false;
                txtNumberCount.Text = "";
            }
        }
    }
}
