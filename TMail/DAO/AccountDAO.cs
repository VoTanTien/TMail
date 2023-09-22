using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TMail.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { AccountDAO.instance = value; }
        }
        private AccountDAO() { }
        public bool Signin(string username,string password)
        {
            string query = "SELECT* FROM NGUOIDUNG WHERE MaND = " + "'" + username + "'" + " AND " +"Matkhau = " + "'" + password + "'";
            DataTable result = DataProvider.Instance.ExcuteQuery(query);
            return result.Rows.Count >0;
        }
        public bool SignUp(string username, string password)
        {
            string query = string.Format("INSERT INTO NGUOIDUNG(MaND, Matkhau) VALUES ('{0}','{1}')", username, password);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool Save(string username, string password, string ten, string sdt, string anh )
        {
            string query = string.Format("UPDATE NGUOIDUNG SET Matkhau = '{1}' , Ten = N'{2}', SDT = '{3}', AVATAR = N'{4}' WHERE MAND = '{0}' ", username, password, ten, sdt, anh);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;

        }
    }
}
