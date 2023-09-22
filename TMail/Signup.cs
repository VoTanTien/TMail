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
    public partial class Signup : UserControl
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void guna2Button_Signup_Click(object sender, EventArgs e)
        {
            if(guna2TextBox_MKSU.Text != guna2TextBox_MK2SU.Text)
            {
                MessageBox.Show("lặp lại mật khẩu không trùng với mật khẩu");
            }
            else
            {
                if (AccountDAO.Instance.SignUp(guna2TextBox_TKSU.Text,guna2TextBox_MKSU.Text))
                {
                    MessageBox.Show("Tạo tài khoản thành công");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại");
                }
            }    
            
        }
    }
}
