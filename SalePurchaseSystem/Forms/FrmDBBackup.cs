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
    public partial class FrmDBBackup : BaseForm
    {
        public FrmDBBackup()
        {
            InitializeComponent();
        }

        private void FrmDBBackup_Load(object sender, EventArgs e)
        {

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                try
                {
                    var cnBuilder = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SaleEntities"].ConnectionString);
                    SqlConnectionStringBuilder sqlConStrBuilder = new SqlConnectionStringBuilder(cnBuilder.ProviderConnectionString);

                    var backupFolder = ConfigurationManager.AppSettings["BackupFolder"];
                    var backupFileName = String.Format("{0}{1}-{2}.bak", backupFolder, sqlConStrBuilder.InitialCatalog, DateTime.Now.ToString("dd-MMM-yyyy"));

                    using (var connection = new SqlConnection(sqlConStrBuilder.ConnectionString))
                    {
                        var query = String.Format("BACKUP DATABASE {0} TO DISK='{1}'", sqlConStrBuilder.InitialCatalog, backupFileName);
                        using (var command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Backup Created Successfully", "DATABASE Backup...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
