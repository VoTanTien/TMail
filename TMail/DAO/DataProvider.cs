using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMail.DAO
{

    class DataProvider
    {
        private string connectionSTR = @"Data Source=LAPTOP-L8MAAO7V\SQLEXPRESS;Initial Catalog=TMAIL;Integrated Security=True";
        private static DataProvider instance;

        public static DataProvider Instance
        {
          get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
          private set { DataProvider.instance = value;} 
        }
        private DataProvider() { }
        public DataTable ExcuteQuery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand comand = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(comand);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        public int ExcuteNonQuery(string query)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand comand = new SqlCommand(query, connection);
                data = comand.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

    } 
}
