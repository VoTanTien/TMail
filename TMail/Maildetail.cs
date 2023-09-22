using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMail.DTO;
using TMail.DAO;
using Guna.UI2.WinForms;

namespace TMail
{
    public partial class Maildetail : Form
    {
        int id;
        string anh;
        string file;
        int reply;
        Mail mail2;
        string name;
        public Maildetail(Mail mail, string username)
        {
            InitializeComponent();
            name = username;
            id = mail.ID;
            reply = mail.Reply;
            mail2 = mail;
            MailDAO.Instance.UpdateMailread(id, "READ");
            if (mail.Nguoigui == username)
            {
                label_Head.Text = "ĐỌC THƯ ĐÃ GỬI ";
                Label_ND.Text = "Từ tôi Đến : " + mail.Nguoinhan;
            }
            else
            {
                label_Head.Text = "ĐỌC THƯ ĐÃ NHẬN ";
                Label_ND.Text = "Người gửi: " + mail.Nguoigui + " Đến tôi";
            }
            Label_Title.Text = mail.Title;
            Label_Detail.Text = mail.Detail;
            if (mail.Filee != "")
            {
                file = mail.Filee.ToString();
                Panel pn = new Panel();
                pn.Dock = DockStyle.Left;
                pn.Width = 200;
                guna2Panel_dinhkem.Controls.Add(pn);

                Guna2Button btnfile = new Guna2Button();
                btnfile.FillColor = Color.FromArgb(144, 129, 228);
                btnfile.BackColor = Color.Transparent;
                btnfile.BorderRadius = 23;
                btnfile.Width = 150;
                btnfile.Height = 50;
                btnfile.Location = new Point(0, 13);
                btnfile.Text = mail.Filee.ToString();
                btnfile.Click += File_Click;
                pn.Controls.Add(btnfile);

            }
            if (mail.Anh != "")
            {
                anh = mail.Anh;
                PictureBox pb = new PictureBox();
                pb.Dock = DockStyle.Left;
                pb.BackgroundImage = new Bitmap(mail.Anh);
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                pb.BackColor = Color.White;
                pb.Click += pictureBox_Image_Click;
                guna2Panel_dinhkem.Controls.Add(pb);


            }
            string query = "SELECT * FROM MAIL WHERE Reply = " + mail.ID.ToString() + " ORDER BY Thgian ASC";
            guna2Panel_Reply.Controls.Clear();
            List<Mail> listmail = MailDAO.Instance.LoadMail(query);
            foreach (Mail item in listmail)
            {
                Guna2Panel panel = new Guna2Panel();
                panel.Dock = DockStyle.Top;
                panel.BackColor = Color.Transparent;
                panel.Height = 55;
                panel.BorderThickness = 1;
                panel.BorderColor = Color.Black;
                guna2Panel_Reply.Controls.Add(panel);

                Label lbtg = new Label();
                lbtg.Dock = DockStyle.Right;
                lbtg.Width = 100;
                lbtg.BackColor = Color.Transparent;
                lbtg.Text = item.Thgian.ToString();
                lbtg.Font = new Font("Segoe UI", 10);
                lbtg.TextAlign = ContentAlignment.MiddleCenter;
                panel.Controls.Add(lbtg);

                Guna2Button btntex = new Guna2Button();
                btntex.FillColor = Color.Transparent;
                btntex.Text = "Từ " + item.Nguoigui + " đến " + item.Nguoinhan + Environment.NewLine +  item.Title;
                btntex.Font = new Font("Segoe UI", 12);
                btntex.ForeColor = Color.DeepPink;
                btntex.TextAlign = HorizontalAlignment.Left;
                btntex.Dock = DockStyle.Fill;
                btntex.Cursor = Cursors.Hand;
                btntex.Click += new EventHandler((sender, e) => Mail_Click(sender, e, item));
                panel.Controls.Add(btntex);

            }
        }

        private void pictureBox_EXIT_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void guna2Button_Delete_Click(object sender, EventArgs e)
        {
            MailDAO.Instance.DeleteMail(id);
            this.Hide();
        }

        private void pictureBox_Image_Click(object sender, EventArgs e)
        {
            Pictureshow image = new Pictureshow(anh);
            image.Show();
        }
        private void File_Click(object sender, EventArgs e)
        {
            string fileName = @"D:\hacker3.2\C#\đồ án\TMail\TMail\File\" + file;
            var process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo() { UseShellExecute = true, FileName = fileName };
            process.Start();

        }

        private void guna2Button_Reply_Click(object sender, EventArgs e)
        {
            Compose reply = new Compose(mail2);
            reply.Show();
        }
        private void Mail_Click(object sender, EventArgs e, Mail mail)
        {
            Maildetail maildetail = new Maildetail(mail, name);
            maildetail.Show();
        }
    }
}
