using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TMail.DTO;

namespace TMail.DAO
{
    class MailDAO
    {
        private static MailDAO instance;

        public static MailDAO Instance
        {
            get { if (instance == null) instance = new MailDAO(); return MailDAO.instance; }
            private set { MailDAO.instance = value; }
        }
        private MailDAO() { }
        public List<Mail> LoadMail(string query)
        {
            List<Mail> listmail = new List<Mail>();
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows )
            {
                Mail mail = new Mail(item);
                listmail.Add(mail);
            }    
            return listmail;
        }
        public bool SendMail(string nguoinhan,string nguoigui, string title,string detail, string anh, string file)
        {
            string query = string.Format("INSERT INTO MAIL(NgNhan, NgGui, Thgian, Title, Detail, Star, Anh, filee) VALUES('{0}','{1}', GETDATE(),N'{2}',N'{3}','NULL',N'{4}', N'{5}')", nguoinhan, nguoigui, title, detail, anh, file);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result>0;
        }
        public bool SendMailReply(string nguoinhan, string nguoigui, string title, string detail, string anh, string file, int reply)
        {
            string query = string.Format("INSERT INTO MAIL(NgNhan, NgGui, Reply , Thgian, Title, Detail, Star, Anh, filee) VALUES('{0}','{1}', {6} , GETDATE(),N'{2}',N'{3}','NULL',N'{4}', N'{5}')", nguoinhan, nguoigui, title, detail, anh, file, reply);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMail(int id, string star)
        {
            string query = string.Format("UPDATE MAIL SET Star = '{0}' WHERE ID = {1} ", star, id);
            int result = DataProvider.Instance.ExcuteNonQuery(query); 
            return result > 0;
        }
        public bool UpdateMailread(int id, string read)
        {
            string query = string.Format("UPDATE MAIL SET Readed = '{0}' WHERE ID = {1} ", read, id);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateMailallread(string nguoinhan)
        {
            string query = string.Format("UPDATE MAIL SET Readed = 'READ' WHERE NgNhan = '{0}' ", nguoinhan);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteMail(int id)
        {
            string query = "DELETE FROM MAIL WHERE ID = '" + id + "'";
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
