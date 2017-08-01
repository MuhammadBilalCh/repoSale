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
    public partial class FrmMain : BaseForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                base.OnFormClosing(e);
                if (PreClosingConfirmation() == System.Windows.Forms.DialogResult.Yes)
                {
                    Dispose(true);
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmEmployeeType"];
                if (f != null)
                    f.BringToFront();
                else
                {
                    //FrmEmployeeType employeeType = new FrmEmployeeType();
                    //employeeType.MdiParent = this;
                    //employeeType.Show();
                }
            }
        }

        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmEmployee"];
                if (f != null)
                    f.BringToFront();
                else
                {
                    //FrmEmployee employee = new FrmEmployee();
                    //employee.MdiParent = this;
                    //employee.Show();
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmInventoryType"];
                if (f != null)
                    f.BringToFront();
                else
                {
                    //FrmInventoryType inv = new FrmInventoryType();
                    //inv.MdiParent = this;
                    //inv.Show();
                }
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmInventory"];
                if (f != null)
                    f.BringToFront();
                else
                {
                    FrmInventory inv = new FrmInventory();
                    inv.MdiParent = this;
                    inv.Show();
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmStock"];
                if (f != null)
                    f.Close();

                FrmStock stk = new FrmStock(true);
                stk.MdiParent = this;
                stk.Show();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmStock"];
                if (f != null)
                    f.Close();

                FrmStock stk = new FrmStock(false);
                stk.MdiParent = this;
                stk.Show();
            }
        }

        private void expenseTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmExpenseType"];
                if (f != null)
                    f.BringToFront();
                else
                {
                    //FrmExpenseType frmExpTyp = new FrmExpenseType();
                    //frmExpTyp.MdiParent = this;
                    //frmExpTyp.Show();
                }
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmTransport"];
                if (f != null)
                    f.BringToFront();
                else
                {
                    //FrmTransport frmTrans = new FrmTransport();
                    //frmTrans.MdiParent = this;
                    //frmTrans.Show();
                }
            }
        }

        private void viewTransportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmLoadTransport"];
                if (f != null)
                    f.BringToFront();
                else
                {
                    //FrmLoadTransport frmLdTrans = new FrmLoadTransport();
                    //frmLdTrans.MdiParent = this;
                    //frmLdTrans.Show();
                }
            }
        }

        private void loadInStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmLoadStock"];
                if (f != null)
                    f.Close();

                FrmLoadStock frmLdTrans = new FrmLoadStock(true);
                frmLdTrans.MdiParent = this;
                frmLdTrans.Show();
            }
        }

        private void loadOutStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmLoadStock"];
                if (f != null)
                    f.Close();

                FrmLoadStock frmLdTrans = new FrmLoadStock(false);
                frmLdTrans.MdiParent = this;
                frmLdTrans.Show();
            }
        }

        private void transportDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmLoadTransportById"];
                if (f != null)
                    f.BringToFront();
                else
                {
                    //FrmLoadTransportById frmLdTrans = new FrmLoadTransportById();
                    //frmLdTrans.MdiParent = this;
                    //frmLdTrans.Show();
                }
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmDBBackup"];
                if (f != null)
                    f.BringToFront();
                else
                {
                    FrmDBBackup frmLdTrans = new FrmDBBackup();
                    frmLdTrans.MdiParent = this;
                    frmLdTrans.Show();
                }
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                try
                {
                    Form f = Application.OpenForms["frmRptEmployee"];
                    if (f != null)
                        f.Close();

                    //frmRptEmployee rept = new frmRptEmployee();
                    //rept.MdiParent = this;

                    //var cnBuilder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SaleEntities"].ConnectionString);
                    //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(cnBuilder.ProviderConnectionString);
                    //string genusSqlServerName = sqlConnectionStringBuilder.DataSource;
                    //string genusDatabaseName = sqlConnectionStringBuilder.InitialCatalog;
                    //string genusUserName = sqlConnectionStringBuilder.UserID;
                    //string genusPassword = sqlConnectionStringBuilder.Password;
                    //rept.RptEmployee1.DataSourceConnections[0].IntegratedSecurity = false;
                    //rept.RptEmployee1.DataSourceConnections[0].SetConnection(genusSqlServerName, genusDatabaseName, genusUserName, genusPassword);
                    //rept.RptEmployee1.Refresh();
                    //rept.MdiParent = this;
                    //rept.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void inventoryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                try
                {
                    Form f = Application.OpenForms["frmRptInventory"];
                    if (f != null)
                        f.Close();

                    //frmRptInventory rept = new frmRptInventory();
                    //rept.MdiParent = this;

                    //var cnBuilder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SaleEntities"].ConnectionString);
                    //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(cnBuilder.ProviderConnectionString);
                    //string genusSqlServerName = sqlConnectionStringBuilder.DataSource;
                    //string genusDatabaseName = sqlConnectionStringBuilder.InitialCatalog;
                    //string genusUserName = sqlConnectionStringBuilder.UserID;
                    //string genusPassword = sqlConnectionStringBuilder.Password;
                    //rept.RptInventory1.DataSourceConnections[0].IntegratedSecurity = false;
                    //rept.RptInventory1.DataSourceConnections[0].SetConnection(genusSqlServerName, genusDatabaseName, genusUserName, genusPassword);
                    //rept.RptInventory1.Refresh();
                    //rept.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void loadInStockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmLoadStock"];
                if (f != null)
                    f.Close();

                FrmLoadStock frmLdTrans = new FrmLoadStock(true);
                frmLdTrans.MdiParent = this;
                frmLdTrans.Show();
            }
        }

        private void loadOutStockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmLoadStock"];
                if (f != null)
                    f.Close();

                FrmLoadStock frmLdTrans = new FrmLoadStock(false);
                frmLdTrans.MdiParent = this;
                frmLdTrans.Show();
            }
        }

        private void viewRecevieAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmReceivableByDateId"];
                if (f != null)
                    f.BringToFront();
                else
                {
                    //FrmReceivableByDateId frmLdTrans = new FrmReceivableByDateId();
                    //frmLdTrans.MdiParent = this;
                    //frmLdTrans.Show();
                }
            }
        }

        private void viewTransportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmLoadTransport"];
                if (f != null)
                    f.BringToFront();
                else
                {
                    //FrmLoadTransport frmLdTrans = new FrmLoadTransport();
                    //frmLdTrans.MdiParent = this;
                    //frmLdTrans.Show();
                }
            }
        }

        private void transportDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmLoadTransportById"];
                if (f != null)
                    f.BringToFront();
                else
                {
                    //FrmLoadTransportById frmLdTrans = new FrmLoadTransportById();
                    //frmLdTrans.MdiParent = this;
                    //frmLdTrans.Show();
                }
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmReceiveAmount"];
                if (f != null)
                    f.Close();

                //FrmReceiveAmount frmLdTrans = new FrmReceiveAmount();
                //frmLdTrans.MdiParent = this;
                //frmLdTrans.Show();
            }
        }

        private void viewRecevieAmountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmReceivableByDateId"];
                if (f != null)
                    f.BringToFront();
                else
                {
                    //FrmReceivableByDateId frmLdTrans = new FrmReceivableByDateId();
                    //frmLdTrans.MdiParent = this;
                    //frmLdTrans.Show();
                }
            }
        }
    }
}
