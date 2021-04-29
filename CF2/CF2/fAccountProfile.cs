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
    public partial class fAccountProfile : Form
    {

        private Account loginAccount;
        public Account LoginAccount
        {
            get => loginAccount;
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        public fAccountProfile(Account acc)
        {
            InitializeComponent();

            LoginAccount = acc;
        }
        
        void ChangeAccount(Account acc)
        {
            txtUserName.Text = LoginAccount.Username;
            txtbDisplayName.Text = LoginAccount.Displayname;
        }

        void UpdateAccountInfo()
        {
            string displayName = txtbDisplayName.Text;
            string passWord = txtbPassWord.Text;
            string newPass = txtbNewPassWord.Text;
            string reenterPass = txtbReplayPassWord.Text;
            string userName = txtUserName.Text;

            if(!newPass.Equals(reenterPass))
            {
                MessageBox.Show("Vui long nhap lai mk moi");
            }
            else
            {
                if(AccountDAO.Instance.UpdateAccount(userName,displayName,passWord,newPass))
                {
                    MessageBox.Show("Cap Nhat OK","thong bao");
                }
                else
                {
                    MessageBox.Show("Vui long nhap lai mk moi");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }
    }
}
