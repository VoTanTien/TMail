using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMail.DTO;

namespace TMail.DAO
{
    class DraftDAO
    {
        private static DraftDAO instance;
        public static DraftDAO Instance
        {
            get { if (instance == null) instance = new DraftDAO(); return DraftDAO.instance; }
            private set { DraftDAO.instance = value; }
        }
        private DraftDAO() { }
        public List<Draft> LoadDraft(string query)
        {
            List<Draft> listdraft = new List<Draft>();
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Draft mail = new Draft(item);
                listdraft.Add(mail);
            }
            return listdraft;
        }
        public bool InsertDraft(string nguoidung, string title, string detail, string anh)
        {
            string query = string.Format("INSERT INTO Draft(MaND, Title, Detail, Anh) VALUES('{0}', N'{1}', N'{2}',N'{3}')", nguoidung, title, detail, anh);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateDraft(int id, string title, string detail, string anh)
        {
            string query = string.Format("UPDATE DRAFT SET Title = '{0}' , Detail = '{1}' , Anh = N'{3}'  WHERE MaDraft = {2} ", title, detail, id, anh);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteDraft(int id)
        {
            string query = "DELETE FROM DRAFT WHERE MaDraft = '" + id + "'";
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
