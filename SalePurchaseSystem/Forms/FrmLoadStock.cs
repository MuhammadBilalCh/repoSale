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
    public partial class FrmLoadStock : Form
    {
        private bool _isPurchase = true;
        public FrmLoadStock()
        {
            InitializeComponent();
        }

        public FrmLoadStock(bool isPurchase)
        {
            InitializeComponent();
            _isPurchase = isPurchase;
            if (isPurchase == true)
            {
                lblTitle.Text = "Load In Stock";
            }
            else
            {
                lblTitle.Text = "Load Out Stock";
            }
        }

        private void FrmStockLoad_Load(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if ((dtpDateStart.Value > DateTime.Now) || (dtpDateEnd.Value > DateTime.Now))
                {
                    MessageBox.Show("Please Select dates less then current date", "Wrong Date...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dtpDateEnd.Value < dtpDateStart.Value)
                {
                    MessageBox.Show("From Date cannot be less then To Date", "Wrong Date...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Form f = Application.OpenForms["FrmStock"];
                    if (f != null)
                        f.Close();

                    FrmStock frmstk = new FrmStock(dtpDateStart.Value, dtpDateEnd.Value, _isPurchase);
                    frmstk.MdiParent = this.MdiParent;
                    frmstk.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ReSetAll();
        }

        private void ReSetAll()
        {
            dtpDateEnd.Value = DateTime.Now;
            dtpDateStart.Value = DateTime.Now;
        }
        private void Control_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}
