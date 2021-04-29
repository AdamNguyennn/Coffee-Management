using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF2.DTO
{
    public class Account
    {
        public Account(string userName, string displayName, int type, string password = null)
        {
            this.Displayname = displayName;
            this.Password = password;
            this.Type = type;
            this.Username = userName;
        }

        public Account(DataRow row)
        {
            this.Displayname = row["displayName"].ToString();
            this.Password = row["passWord"].ToString(); 
            this.Type = (int)row["type"];
            this.Username = row["userName"].ToString(); 
        }
        private string displayname;
        private string password;
        private int type;
        private string username;


        public string Username { get => username; set => username = value; }
        public int Type { get => type; set => type = value; }
        public string Password { get => password; set => password = value; }
        public string Displayname { get => displayname; set => displayname = value; }
    }
}
