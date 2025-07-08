using ATDDotNetTrainingBatch2.WinFormsApp1.Database.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATDDotNetTrainingBatch2.WinFormsApp1
{
    public partial class frmLogin : Form
    {
        private readonly AppDbContext _db;

        public frmLogin()
        {
            InitializeComponent();
            _db = new AppDbContext();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string staffCode = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            var item = _db.TblStaffs.FirstOrDefault(x => x.StaffCode == staffCode && x.Password == password);
            if (item is null)
            {
                MessageBox.Show("Invalid user name and password! ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Hide();
            frmMenu frm = new frmMenu();
            frm.ShowDialog();
            if (!frm.isExit)
            {
                this.Show();
                return;
            }
            Application.Exit();
            

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        
    }
}
