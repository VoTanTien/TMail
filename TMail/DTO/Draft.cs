using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMail.DTO
{
    public class Draft
    {
        public Draft(int madraft,string maND,string title,string detail,string anh)
        {
            this.Madraft = madraft;
            this.MaND = maND;
            this.Title = title;
            this.Detail = detail;
            this.Anh = anh;
        }
        public Draft(DataRow row)
        {
            this.Madraft = (int)row["MaDraft"];
            this.MaND = row["MaND"].ToString();
            this.Title = row["Title"].ToString();
            this.Detail = row["Detail"].ToString();
            this.Anh = row["Anh"].ToString();
        }
        private int madraft;
        private string maND;
        private string title;
        private string detail;
        private string anh;

        public int Madraft { get => madraft; set => madraft = value; }
        public string MaND { get => maND; set => maND = value; }
        public string Title { get => title; set => title = value; }
        public string Detail { get => detail; set => detail = value; }
        public string Anh { get => anh; set => anh = value; }
    }
}
