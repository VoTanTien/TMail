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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        bool Signin(string username, string password)
        {

            return AccountDAO.Instance.Signin(username,password) ;
        }
        private void label_Signup_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            guna2Panel1.Controls.Add(signup);
        }

        private void pictureBox_EXIT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void guna2Button_Signin_Click(object sender, EventArgs e)
        {
            string username = guna2TextBox_TK.Text;
            string password = guna2TextBox_MK.Text;
            if (Signin(username,password))
            {
                this.Hide();
                Main main = new Main(username);
                main.Show();
            }
            else
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu");
        }

    }
}
