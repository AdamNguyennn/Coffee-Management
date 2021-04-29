using CF2.DAO;
using CF2.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CF2
{
    public partial class fTableLogin : Form
    {
        public fTableLogin()
        {
            InitializeComponent();
        }

        private void bttnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtbUser.Text;
            string passWord = txtbPass.Text;
            if (Login(userName,passWord))
            {

                Account loginAccount = AccountDAO.Instance.GetAccountByUsername(userName); 
                fTablbeManager f = new fTablbeManager(loginAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {

                MessageBox.Show("Sai ten tai khoan hoac mat khau");
            }
        }

        bool Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName,passWord); 
        }

        private void bttnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
