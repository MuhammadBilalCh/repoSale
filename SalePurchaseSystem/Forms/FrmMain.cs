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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                Form f = Application.OpenForms["FrmInventoryType"];
                if (f != null)
                    f.BringToFront();
                else
                {
                    FrmInventoryType inv = new FrmInventoryType();
                    inv.MdiParent = this;
                    inv.Show();
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
        
    }
}
