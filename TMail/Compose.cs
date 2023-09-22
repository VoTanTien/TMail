using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using TMail.DAO;
using TMail.DTO;
using System.Globalization;
namespace TMail
{
    public partial class Compose : Form
    {
        string username;
        string anh = "";
        string file = "";
        int reply = 0;
        public Compose(string name)
        {
            InitializeComponent();
            username = name;
        }
        public Compose(Mail mail)
        {
            InitializeComponent();
            username = mail.Nguoinhan;
            if (mail.Reply == 0)
            {
                reply = mail.ID;
            }
            else
                reply = mail.Reply;
            guna2TextBox_NgNhan.Text = mail.Nguoigui.ToString();
            guna2TextBox_Title.Text = "Reply for " + mail.Nguoigui ;
        }
        public void GetImage()
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                anh = open.FileName;
                pictureBox_Anh.BackgroundImage = new Bitmap(open.FileName);
                pictureBox_Anh.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void pictureBox_EXIT_Click(object sender, EventArgs e)
        {
            if (DraftDAO.Instance.InsertDraft(username, guna2TextBox_Title.Text.ToString(), guna2TextBox_Mail.Text.ToString(), anh))
            {
                MessageBox.Show("Lưu vào thư nháp");
            }
            else
            {
                MessageBox.Show("Gửi thất bại");
            }
            this.Hide();
        }

        private void guna2Button_Send_Click(object sender, EventArgs e)
        {
            if (reply == 0)
            {
                if (guna2TextBox_NgNhan.Text != "")
                {
                    if (MailDAO.Instance.SendMail(guna2TextBox_NgNhan.Text.ToString(), username, guna2TextBox_Title.Text.ToString(), guna2TextBox_Mail.Text.ToString(), anh, file))
                    {
                        MessageBox.Show("Gửi thành công");
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Gửi thất bại");
                    }
                }
                else
                    MessageBox.Show("Chưa điền thông tin người nhận");
            }
            else
            {
                if (MailDAO.Instance.SendMailReply(guna2TextBox_NgNhan.Text.ToString(), username, guna2TextBox_Title.Text.ToString(), guna2TextBox_Mail.Text.ToString(), anh, file, reply))
                {
                    MessageBox.Show("Trả lời thành công");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Gửi thất bại");
                }
            }    
           
        }

        private void guna2Button_Addimage_Click(object sender, EventArgs e)
        {
            GetImage();
            
        }

        private void guna2Button_attach_Click(object sender, EventArgs e)
        {
            string sourcepath;
            string despath;
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                sourcepath = open.FileName;
                file = Path.GetFileName(open.FileName);
                despath = @"D:\hacker3.2\C#\đồ án\TMail\TMail\File\" + file;
                despath = Path.Combine(sourcepath, despath);
                File.Copy(sourcepath, despath, true);
                guna2Button_Filename.Visible = true;
                guna2Button_Filename.Text = file;
            }
        }

        private void guna2Button_Font_Click(object sender, EventArgs e)
        {
            
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                guna2TextBox_Mail.Font = fd.Font;
            }
        }

    }
}
