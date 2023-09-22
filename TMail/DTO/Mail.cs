using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMail.DTO
{
    public class Mail
    {
        public Mail(int id,string nguoinhan,string nguoigui,int reply, DateTime? thgian, string title,string detail,string star, string anh,string filee, string readed)
        {
            this.ID = id;
            this.Nguoinhan = nguoinhan;
            this.Nguoigui = nguoigui;
            this.Reply = reply;
            this.Thgian = thgian;
            this.Title = title;
            this.Detail = detail;
            this.Star = star;
            this.Anh = anh;
            this.Filee = filee;
            this.Readed = readed;
        }
        public Mail(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Nguoinhan = row["NgNhan"].ToString();
            this.Nguoigui = row["NgGui"].ToString();
            this.Reply = (int)row["Reply"];
            this.Thgian = (DateTime?)row["Thgian"];
            this.Title = row["Title"].ToString();
            this.Detail = row["Detail"].ToString();
            this.Star = row["Star"].ToString();
            this.Anh = row["Anh"].ToString();
            this.Filee = row["filee"].ToString();
            this.Readed = row["Readed"].ToString();
        }
        private int iD;
        private string nguoinhan;
        private string nguoigui;
        private int reply;
        private DateTime? thgian; 
        private string title;
        private string detail;
        private string star;
        private string anh;
        private string filee;
        private string readed;

        public string Nguoinhan { get => nguoinhan; set => nguoinhan = value; }
        public string Nguoigui { get => nguoigui; set => nguoigui = value; }
        public string Title { get => title; set => title = value; }
        public string Detail { get => detail; set => detail = value; }
        public string Star { get => star; set => star = value; }
        public string Anh { get => anh; set => anh = value; }
        public int ID { get => iD; set => iD = value; }
        public DateTime? Thgian { get => thgian; set => thgian = value; }
        public int Reply { get => reply; set => reply = value; }
        public string Filee { get => filee; set => filee = value; }
        public string Readed { get => readed; set => readed = value; }
    }
}
