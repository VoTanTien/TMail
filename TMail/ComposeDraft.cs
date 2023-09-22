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
using System.Globalization;
using System.IO;
namespace TMail
{
    public partial class ComposeDraft : Form
    {
        int id;
        string username;
        string anh = "";
        string file = "";
        public ComposeDraft(Draft draft, string name)
        {
            InitializeComponent();
            username = name;
            id = draft.Madraft;
            guna2TextBox_Title.Text = draft.Title;
            guna2TextBox_Mail.Text = draft.Detail;
            if(draft.Anh != "")
            {
                anh = draft.Anh;
                pictureBox_Anh.BackgroundImage = new Bitmap(draft.Anh);
            }    
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

        private void guna2Button_Send_Click(object sender, EventArgs e)
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

        private void pictureBox_EXIT_Click(object sender, EventArgs e)
        {
            
            if (DraftDAO.Instance.UpdateDraft(id, guna2TextBox_Title.Text.ToString(), guna2TextBox_Mail.Text.ToString(), anh))
            {
                MessageBox.Show("Lưu vào thư nháp");
            }
            else
            {
                MessageBox.Show("Gửi thất bại");
            }
            this.Hide();
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
    }
}
