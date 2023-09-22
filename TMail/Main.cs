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

namespace TMail
{
    public partial class Main : Form
    {
        string username;
        public Main(string name)
        {
            InitializeComponent();
            username = name;
            LoadAccount();
            LoadDaTaHome();
        }
        public void LoadAccount()
        {
            string query = "SELECT *FROM NGUOIDUNG WHERE MAND = '" + username + "'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            label_Username.Text = username;
            foreach (DataRow row in data.Rows)
            {
                pictureBox_Account.BackgroundImage = new Bitmap(row[4].ToString());
            }

        }
        public void LoadDaTaHome()
        {
            string query = "SELECT *FROM MAIL Where NgNhan =" + "'" + username + "' AND Reply = 0 "  + "ORDER BY Thgian ASC";
            label_Head.Text = "HỘP THƯ ĐẾN";
            guna2Button_Recevie.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\mailbox1.png");
            guna2Button_Read.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\read.png");
            guna2Button_Send.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\send.png");
            guna2Button_Star.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\star.png");
            guna2Button_Draft.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\draft.png");
            SettingPick(guna2Panel_Recevie);
            SettingUnpick(guna2Panel_Read);
            SettingUnpick(guna2Panel_Send);
            SettingUnpick(guna2Panel_Star);
            SettingUnpick(guna2Panel_Draft);
            fMail mail = new fMail(query,username);
            Addcontrol(mail);
        }

        public void SettingPick(Guna2Panel c)
        {
            c.BorderColor = Color.White;
            c.BorderRadius = 15;
            c.BorderThickness = 2;
            c.FillColor = Color.FromArgb(226, 230, 255);
        }
        public void SettingUnpick(Guna2Panel c)
        {
            c.BorderThickness = 0;
            c.BorderRadius = 0;
            c.FillColor = Color.Transparent;
        }
        public void Addcontrol(Control c)
        {
            c.Dock = DockStyle.Fill;
            guna2Panel_UserControl.Controls.Clear();
            guna2Panel_UserControl.Controls.Add(c);
        }
        private void pictureBox_EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void guna2Button_Recevie_Click(object sender, EventArgs e)
        {
            LoadDaTaHome();
        }

        private void guna2Button_Send_Click(object sender, EventArgs e)
        {
            string query = "SELECT *FROM MAIL Where NgGui =" + "'" + username + "' AND Reply = 0 " + "ORDER BY Thgian ASC";
            label_Head.Text = "THƯ ĐÃ GỬI";
            guna2Button_Recevie.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\mailbox.png");
            guna2Button_Read.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\read.png");
            guna2Button_Send.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\send1.png");
            guna2Button_Star.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\star.png");
            guna2Button_Draft.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\draft.png");
            SettingPick(guna2Panel_Send);
            SettingUnpick(guna2Panel_Read);
            SettingUnpick(guna2Panel_Recevie);
            SettingUnpick(guna2Panel_Star);
            SettingUnpick(guna2Panel_Draft);
            fMail mail = new fMail(query,username);
            Addcontrol(mail);
        }


        private void guna2Button_Star_Click(object sender, EventArgs e)
        {
            string query = "SELECT *FROM MAIL Where Star = 'STAR' " + "ORDER BY Thgian ASC";
            label_Head.Text = "THƯ ĐÃ ĐÁNH DẤU";
            guna2Button_Recevie.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\mailbox.png");
            guna2Button_Read.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\read.png");
            guna2Button_Send.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\send.png");
            guna2Button_Star.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\star1.png");
            guna2Button_Draft.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\draft.png");
            SettingPick(guna2Panel_Star);
            SettingUnpick(guna2Panel_Read);
            SettingUnpick(guna2Panel_Recevie);
            SettingUnpick(guna2Panel_Draft);
            SettingUnpick(guna2Panel_Send);
            fMail mail = new fMail(query,username);
            Addcontrol(mail);
        }

        private void guna2Button_Draft_Click(object sender, EventArgs e)
        {
            string query = "SELECT *FROM Draft WHERE MaND = " + "'" + username + "' ";
            label_Head.Text = "THƯ NHÁP";
            guna2Button_Recevie.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\mailbox.png");
            guna2Button_Read.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\read.png");
            guna2Button_Send.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\send.png");
            guna2Button_Star.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\star.png");
            guna2Button_Draft.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\draft1.png");
            SettingPick(guna2Panel_Draft);
            SettingUnpick(guna2Panel_Read);
            SettingUnpick(guna2Panel_Recevie);
            SettingUnpick(guna2Panel_Star);
            SettingUnpick(guna2Panel_Send);
            fMail mail = new fMail(query,username);
            Addcontrol(mail);
        }
        private void guna2Button_Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void guna2Button_Compose_Click(object sender, EventArgs e)
        {
            Compose compose = new Compose(username);
            compose.Show();
        }

        private void guna2Button_Read_Click(object sender, EventArgs e)
        {
            string query = "SELECT *FROM MAIL Where READED = 'READ' AND NgNhan ="  +"'" + username + "' AND Reply = 0 " + "ORDER BY Thgian ASC";
            label_Head.Text = "THƯ ĐÃ ĐỌC";
            guna2Button_Read.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\read1.png");
            guna2Button_Recevie.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\mailbox.png");
            guna2Button_Send.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\send.png");
            guna2Button_Star.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\star.png");
            guna2Button_Draft.Image = new Bitmap(@"D:\hacker3.2\C#\đồ án\TMail\TMail\Resources\draft.png");
            SettingPick(guna2Panel_Read);
            SettingUnpick(guna2Panel_Send);
            SettingUnpick(guna2Panel_Recevie);
            SettingUnpick(guna2Panel_Star);
            SettingUnpick(guna2Panel_Draft);
            fMail mail = new fMail(query, username);
            Addcontrol(mail);
        }

        private void pictureBox_Account_Click(object sender, EventArgs e)
        {
            Account acc = new Account(username);
            acc.Show();
        }

        private void guna2Panel_Head_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
