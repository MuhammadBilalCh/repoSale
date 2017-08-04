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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalePurchaseSystem.Forms
{
    public partial class FrmInventoryType : BaseForm
    {
        private InventoryTypeRepo _repository;
        private InventoryType tempInvType;

        public FrmInventoryType()
        {
            InitializeComponent();
            _repository = new InventoryTypeRepo();
            tempInvType = new InventoryType();

        }

        private void FrmInventoryType_Load(object sender, EventArgs e)
        {
            grdViewInventoryType.AutoGenerateColumns = false;
            ReSetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInventoryType.Text.Trim() == "")
                {
                    MessageBox.Show("Please add Inventory Type Text", "Add...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_repository.CheckExistingInventoryType(txtInventoryType.Text))
                {
                    InventoryType InvType = new InventoryType()
                    {
                        InventoryTypeId = 0,
                        InventoryTypeName = txtInventoryType.Text
                    };

                    if (btnAdd.Text == "Update")
                    {
                        if (lblInvId.Text != "0")
                        {
                            InvType.InventoryTypeId = Convert.ToInt32(lblInvId.Text);
                            _repository.SaveInventoryType(InvType);
                            MessageBox.Show("Inventory Type Updated Successfully", "Updated...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReSetAll();
                        }
                        else
                        {
                            //var dataSource = grdViewInventoryType.DataSource;

                            foreach (DataGridViewRow row in grdViewInventoryType.Rows)
                            {
                                var thsInv = row.DataBoundItem as InventoryType;
                                if (tempInvType == thsInv)
                                {
                                    (row.DataBoundItem as InventoryType).InventoryTypeName = InvType.InventoryTypeName;
                                    (row.DataBoundItem as InventoryType).InventoryTypeId = InvType.InventoryTypeId;
                                    break;
                                }
                            }
                            grdViewInventoryType.Refresh();
                        }
                        btnAdd.Text = "Add";
                    }
                    else
                    {
                        var dataSource = grdViewInventoryType.DataSource;
                        (dataSource as BindingList<InventoryType>).Add(InvType);
                        grdViewInventoryType.DataSource = dataSource;
                        grdViewInventoryType.Refresh();
                        pnlSaveAll.Visible = true;
                    }

                    txtInventoryType.Text = "";
                }
                else
                {
                    MessageBox.Show("Inventory Type Already Exists", "Already Exists...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                List<InventoryType> InvTyps = new List<InventoryType>();

                foreach (DataGridViewRow row in grdViewInventoryType.Rows)
                {
                    InventoryType InvTyp = row.DataBoundItem as InventoryType;
                    InvTyps.Add(InvTyp);
                }
                _repository.SaveAllInventoryTypes(InvTyps);
                MessageBox.Show("All Inventory Type Add Successfully", "Add...", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void grdViewInventoryType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (((e.ColumnIndex == 2) || (e.ColumnIndex == 3)) && (e.RowIndex != -1))
                {
                    int rowIndex = e.RowIndex;
                    DataGridViewRow row = grdViewInventoryType.Rows[rowIndex];

                    if (e.ColumnIndex == 2)
                    {
                        lblInvId.Text = Convert.ToString(row.Cells[0].Value);

                        if (lblInvId.Text != "0")
                        {
                            var InvObj = _repository.Find(Convert.ToInt32(row.Cells[0].Value));
                            txtInventoryType.Text = InvObj.InventoryTypeName;
                        }
                        else
                        {
                            tempInvType = row.DataBoundItem as InventoryType;
                            txtInventoryType.Text = tempInvType.InventoryTypeName;
                        }

                        btnAdd.Text = "Update";
                        pnlAddNew.Visible = true;
                    }

                    if (e.ColumnIndex == 3)
                    {
                        if (PreDeleteConfirmation() == System.Windows.Forms.DialogResult.Yes)
                        {
                            var InventoryId = Convert.ToInt32(row.Cells[0].Value);
                            if (InventoryId == 0)
                            {
                                foreach (DataGridViewRow rr in grdViewInventoryType.Rows)
                                {
                                    if (rr == row)
                                    {
                                        grdViewInventoryType.Rows.RemoveAt(rr.Index);
                                        break;
                                    }
                                }
                                grdViewInventoryType.Refresh();
                            }
                            else
                            {
                                _repository.DeleteInventoryType(InventoryId);
                                MessageBox.Show("Inventory Type Deleted Successfully", "Updated...", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ReSetAll()
        {
            try
            {
                lblInvId.Text = "";
                txtInventoryType.Text = "";
                var listInv = _repository.GetAllInventoryTypes();
                grdViewInventoryType.DataSource = listInv;
                pnlSaveAll.Visible = false;
                pnlAddNew.Visible = false;
                tempInvType = new InventoryType();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            try
            {
                var listInv = _repository.GetAllInventoryTypes();
                grdViewInventoryType.DataSource = listInv;
                pnlAddNew.Visible = false;
                pnlSaveAll.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            pnlAddNew.Visible = true;
            txtInventoryType.Focus();
            BindingList<InventoryType> newlist = new BindingList<InventoryType>();
            grdViewInventoryType.DataSource = newlist;
            txtInventoryType.Text = "";
            btnAdd.Text = "Add";
        }

        private void txtInventoryType_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Form f = Application.OpenForms["frmRptInventoryType"];
                if (f != null)
                    f.Close();

                //frmRptInventoryType rept = new frmRptInventoryType();
                //rept.MdiParent = this.MdiParent;

                //var cnBuilder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SaleEntities"].ConnectionString);
                //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(cnBuilder.ProviderConnectionString);
                //string genusSqlServerName = sqlConnectionStringBuilder.DataSource;
                //string genusDatabaseName = sqlConnectionStringBuilder.InitialCatalog;
                //string genusUserName = sqlConnectionStringBuilder.UserID;
                //string genusPassword = sqlConnectionStringBuilder.Password;
                //rept.RptInventoryType1.DataSourceConnections[0].IntegratedSecurity = false;
                //rept.RptInventoryType1.DataSourceConnections[0].SetConnection(genusSqlServerName, genusDatabaseName, genusUserName, genusPassword);
                //rept.RptInventoryType1.Refresh();
                //rept.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
