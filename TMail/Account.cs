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
    public partial class Account : Form
    {
        string query;
        string avatar;
        public Account(string username)
        {
            InitializeComponent();
            query = "SELECT *FROM NGUOIDUNG WHERE MAND = '" + username +"'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            label_Head.Text = username;
            foreach (DataRow row in data.Rows)
            {
                guna2TextBox_Ten.Text = row[2].ToString();
                guna2TextBox_SDT.Text = row[3].ToString();
                guna2TextBox_MK.Text = row[1].ToString();
                guna2PictureBox_Avatar.Image = new Bitmap(row[4].ToString());
                avatar = row[4].ToString();
            }
                

        }
        public void GetImage()
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {

                avatar = open.FileName;
                guna2PictureBox_Avatar.BackgroundImage = new Bitmap(open.FileName);
            }
        }

        private void pictureBox_EXIT_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void guna2Button_Save_Click(object sender, EventArgs e)
        {
            if(AccountDAO.Instance.Save(label_Head.Text, guna2TextBox_MK.Text, guna2TextBox_Ten.Text, guna2TextBox_SDT.Text, avatar))
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
                MessageBox.Show("Cập nhật không thành công");
        }

        private void guna2PictureBox_Avatar_Click(object sender, EventArgs e)
        {
            GetImage();
            guna2PictureBox_Avatar.Image = new Bitmap(avatar);
        }
    }
}
