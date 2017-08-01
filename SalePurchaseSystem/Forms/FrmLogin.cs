using DataAccess.CustomRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalePurchaseSystem.Forms
{
    public partial class FrmLogin : BaseForm
    {
        private LoginUserRepo _repository;
        public FrmLogin()
        {
            _repository = new LoginUserRepo();
            InitializeComponent();
            txtUserName.KeyUp += base.Control_KeyUp;
            txtUserPassword.KeyUp += base.Control_KeyUp;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (BeginWaitCursorBlock())
            {
                try
                {
                    var userStatus = _repository.ValidateUser(txtUserName.Text, txtUserPassword.Text);

                    if (userStatus == true)
                    {
                        //if (DateTime.Now.Month == 8)
                        //{
                        //    Cursor.Current = Cursors.Default;
                        //    MessageBox.Show("Your Tiral has expired. Please contact System provider.", "Trial has Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return;
                        //}
                        this.Hide();
                        var frmMain = new FrmMain();
                        frmMain.Show();
                    }
                    else
                    {
                        MessageBox.Show("In Valid User Name or Password", "Valid User...", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
