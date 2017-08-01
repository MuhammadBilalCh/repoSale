using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalePurchaseSystem.Forms
{
    public class BaseForm : Form
    {
        #region WaitCursor
        public static IDisposable BeginWaitCursorBlock()
        {
            return ((!_waitCursorIsActive) ? (IDisposable)new waitCursor() : null);
        }
        private static bool _waitCursorIsActive;
        private class waitCursor : IDisposable
        {
            private Cursor oldCur;
            public waitCursor()
            {
                _waitCursorIsActive = true;
                oldCur = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
            }
            public void Dispose()
            {
                Cursor.Current = oldCur;
                _waitCursorIsActive = false;
            }
        }
        #endregion

        #region KeyBoardEvents
        protected virtual void Control_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        protected virtual void myCombo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        protected virtual void txtPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        #endregion

        #region Dialogs
        public DialogResult PreClosingConfirmation()
        {
            DialogResult res = MessageBox.Show(" Do you want to close application?          ", "Close Application...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res;
        }

        public DialogResult PreDeleteConfirmation()
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Delete?          ", "Delete...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res;
        }

        public DialogResult PreCancelConfirmation()
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Cancel?          ", "Cancel...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res;
        }

        #endregion

        #region Reporting
        public void SetConnectionAndShowReport(ReportClass rpt)
        {
            var cnBuilder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SaleEntities"].ConnectionString);
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(cnBuilder.ProviderConnectionString);
            string genusSqlServerName = sqlConnectionStringBuilder.DataSource;
            string genusDatabaseName = sqlConnectionStringBuilder.InitialCatalog;
            string genusUserName = sqlConnectionStringBuilder.UserID;
            string genusPassword = sqlConnectionStringBuilder.Password;
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            rpt.DataSourceConnections[0].SetConnection(genusSqlServerName, genusDatabaseName, genusUserName, genusPassword);
            rpt.Refresh();
        }
        #endregion
    }
}
