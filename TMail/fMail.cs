using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMail.DAO;
using TMail.DTO;

namespace TMail
{
    public partial class fMail : UserControl
    {
        string name;
        string query1;
        public fMail(string query, string username)
        {
            InitializeComponent();
            guna2Panel_Mailmain.Dock = DockStyle.Fill;
            name = username;
            query1 = query;
            if (query == "SELECT *FROM Draft WHERE MaND = " + "'" + username + "' ")
                LoadDraft(query);
            else
            LoadMail(query);
           

        }
        public void LoadMail(string query)
        {
            guna2Panel_Mail.Controls.Clear();
            List<Mail> listmail = MailDAO.Instance.LoadMail(query);
            foreach (Mail item in listmail)
            {
                Guna2Panel panel = new Guna2Panel();
                panel.Dock = DockStyle.Top;
                panel.BackColor = Color.Transparent;
                panel.Height = 55;
                guna2Panel_Mail.Controls.Add(panel);

                Guna2Button btntex = new Guna2Button();
                btntex.FillColor = Color.Transparent;
                btntex.Text = item.Title;
                btntex.Font = new Font("Segoe UI", 14);
                btntex.ForeColor = Color.Black;
                btntex.TextAlign = HorizontalAlignment.Left;
                btntex.Dock = DockStyle.Fill;
                btntex.Cursor = Cursors.Hand;
                btntex.Click += new EventHandler((sender, e) => Mail_Click(sender, e, item));
                panel.Controls.Add(btntex);

                Guna2Button btnmark = new Guna2Button();
                btnmark.Dock = DockStyle.Left;
                btnmark.FillColor = Color.White;
                btnmark.BackColor = Color.Transparent;
                btnmark.Width = 43;
                if(item.Star == "STAR") 
                btnmark.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\mark1.png");
                else
                btnmark.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\mark.png");
                btnmark.Cursor = Cursors.Hand;
                btnmark.Click += new EventHandler((sender, e) => Mark_Click(sender, e, item));
                panel.Controls.Add(btnmark);

                if(CountReply(item.ID) != 0)
                {
                    Guna2Button btnre = new Guna2Button();
                    btnre.Dock = DockStyle.Right;
                    btnre.FillColor = Color.White;
                    btnre.BackColor = Color.Transparent;
                    btnre.Width = 60;
                    btnre.ImageAlign = HorizontalAlignment.Left;
                    btnre.Cursor = Cursors.Hand;
                    btnre.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\reply1.png");
                    btnre.Text = "(" + CountReply(item.ID).ToString() + ")";
                    btnre.ForeColor = Color.Black;
                    btnre.TextAlign = HorizontalAlignment.Right;
                    panel.Controls.Add(btnre);
                }    

                if(item.Nguoinhan == name)
                {
                    Guna2Button btnreaded = new Guna2Button();
                    btnreaded.Dock = DockStyle.Right;
                    btnreaded.FillColor = Color.White;
                    btnreaded.BackColor = Color.Transparent;
                    btnreaded.Width = 40;
                    btnreaded.Cursor = Cursors.Hand;
                    if (item.Readed == "READ")
                        btnreaded.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\readed.png");
                    else
                        btnreaded.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\unread.png");
                    btnreaded.Click += new EventHandler((sender, e) => Read_Click(sender, e, item));
                    panel.Controls.Add(btnreaded);
                }    
                


                Guna2Button btndelete = new Guna2Button();
                btndelete.Dock = DockStyle.Right;
                btndelete.FillColor = Color.White;
                btndelete.BackColor = Color.Transparent;
                btndelete.Width = 40;
                btndelete.Cursor = Cursors.Hand;
                btndelete.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\bin1.png");
                btndelete.Click += new EventHandler((sender, e) => Deletemail_Click(sender, e, item));
                panel.Controls.Add(btndelete);

                Label lbtg = new Label();
                lbtg.Dock = DockStyle.Right;
                lbtg.Width = 100;
                lbtg.BackColor = Color.Transparent;
                lbtg.Text = item.Thgian.ToString();
                lbtg.Font = new Font("Segoe UI", 10);
                lbtg.TextAlign = ContentAlignment.MiddleCenter;
                panel.Controls.Add(lbtg);


            }    
        }
        public void LoadDraft(string query)
        {
            guna2Panel_Mail.Controls.Clear();
            List<Draft> listmail = DraftDAO.Instance.LoadDraft(query);
            foreach (Draft item in listmail)
            {
                Guna2Panel panel = new Guna2Panel();
                panel.Dock = DockStyle.Top;
                panel.BackColor = Color.Transparent;
                panel.Height = 55;

                Guna2Button btntex = new Guna2Button();
                btntex.FillColor = Color.Transparent;
                if (item.Title != "")
                    btntex.Text = "THƯ NHÁP:     " + item.Title + " - " + item.Detail;
                else
                    btntex.Text = "THƯ NHÁP:     " + item.Detail;
                btntex.Font = new Font("Segoe UI", 14);
                btntex.ForeColor = Color.Black;
                btntex.TextAlign = HorizontalAlignment.Left;
                btntex.Dock = DockStyle.Fill;
                btntex.Click += new EventHandler((sender, e) => Draft_Click(sender, e, item));

                Guna2Button btndelete = new Guna2Button();
                btndelete.Dock = DockStyle.Right;
                btndelete.FillColor = Color.White;
                btndelete.BackColor = Color.Transparent;
                btndelete.Width = 43;
                btndelete.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\bin1.png");
                btndelete.Click += new EventHandler((sender, e) => Deletedraft_Click(sender, e, item));

                //Label lbtg = new Label();
                //lbtg.Dock = DockStyle.Right;
                //lbtg.Width = 100;
                //lbtg.BackColor = Color.Transparent;
                //lbtg.Text = item.Thgian.ToString();
                //lbtg.Font = new Font("Segoe UI", 10);
                //lbtg.TextAlign = ContentAlignment.MiddleCenter;

                panel.Controls.Add(btntex);
                panel.Controls.Add(btndelete);
                //panel.Controls.Add(lbtg);
                guna2Panel_Mail.Controls.Add(panel);

            }
        }
        private void Mail_Click(object sender, EventArgs e, Mail mail)
        {
            Maildetail maildetail = new Maildetail(mail, name);
            maildetail.Show();
        }
        private void Draft_Click(object sender, EventArgs e, Draft mail)
        {
            ComposeDraft compose = new ComposeDraft(mail, name);
            compose.Show();
        }
        private void Mark_Click(object sender, EventArgs e, Mail mail)
        {

            if (mail.Star == "NULL")
            {
                MailDAO.Instance.UpdateMail(mail.ID, "STAR");
            LoadMail(query1);
            }
            else
            {
                MailDAO.Instance.UpdateMail(mail.ID, "NULL");
            LoadMail(query1);
            }

        }
        private void Read_Click(object sender, EventArgs e, Mail mail)
        {

            if (mail.Readed == "")
            {
                MailDAO.Instance.UpdateMailread(mail.ID, "READ");
                LoadMail(query1);
            }
            else
            {
                MailDAO.Instance.UpdateMailread(mail.ID, "");
                LoadMail(query1);
            }

        }
        private void Deletedraft_Click(object sender, EventArgs e, Draft mail)
        {

            DraftDAO.Instance.DeleteDraft(mail.Madraft);
            LoadDraft(query1);

        }
        private void Deletemail_Click(object sender, EventArgs e, Mail mail)
        {

            MailDAO.Instance.DeleteMail(mail.ID);
            LoadMail(query1);

        }

        private void guna2Button_Search_Click(object sender, EventArgs e)
        {
            string query;
            if (guna2ComboBox_Choice.SelectedItem.ToString() == "Người dùng")
            {
                query = "SELECT * FROM MAIL WHERE NgGui LIKE '%" + guna2TextBox_Search.Text + "%' AND  NgNhan = '" + name + "'";
            }    
            else
                query = "SELECT * FROM MAIL WHERE (Title LIKE '%" + guna2TextBox_Search.Text + "%' OR Detail LIKE '%" + guna2TextBox_Search.Text + "%') AND  NgNhan = '" + name + "'";
            LoadMail(query);
        }

        private void guna2TextBox_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string query;
                if (guna2ComboBox_Choice.SelectedItem.ToString() == "Người dùng")
                {
                    query = "SELECT * FROM MAIL WHERE NgGui LIKE '%" + guna2TextBox_Search.Text + "%' AND  NgNhan = '" + name + "'" + "AND Reply = 0";
                }
                else 
                    query = "SELECT * FROM MAIL WHERE (Title LIKE '%" + guna2TextBox_Search.Text + "%' OR Detail LIKE '%" + guna2TextBox_Search.Text + "%') AND  NgNhan = '" + name + "'";
                LoadMail(query);
            }

        }

        private void guna2Button_Refresh_Click(object sender, EventArgs e)
        {
            LoadMail(query1);
        }

        private void guna2Button_Allread_Click(object sender, EventArgs e)
        {
            MailDAO.Instance.UpdateMailallread(name);
            LoadMail(query1);
        }
        private int CountReply(int a)
        {
            int b = 0;
            string query = "SELECT COUNT(Reply) From MAIL WHERE Reply = " + a.ToString();
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                b =  (int)row[0];

            }
            return b;
        }

    }
}
