using CF2.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF2.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if( instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login @userName , @passWord ";

            DataTable result = DataProvider.Instace.ExcuteQuery(query, new object[]{userName, passWord});

            return result.Rows.Count > 0;
        }

        public bool UpdateAccount(string userName, string displayName, string pass, string newPass )
        {
            int result = DataProvider.Instace.ExcuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @passWord , @newPassWord ", new object[] { userName, displayName, pass, newPass });

            return result > 0;
        }
        public Account GetAccountByUsername(string userName)
        {
            DataTable data = DataProvider.Instace.ExcuteQuery("Select * from account Where UserName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public Account GetAccountByType(string userName)
        {
            DataTable data = DataProvider.Instace.ExcuteQuery("Select type from account Where userName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public List<Account> LoadAccountList()
        {
            List<Account> accountList = new List<Account>();

            DataTable data = DataProvider.Instace.ExcuteQuery(" USP_AccountList");

            foreach (DataRow item in data.Rows)
            {
                Account account = new Account(item);
                accountList.Add(account);
            }

            return accountList;
        }
    }
}
