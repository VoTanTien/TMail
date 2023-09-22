using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMail
{
    public partial class Pictureshow : Form
    {
        public Pictureshow(string anh)
        {
            InitializeComponent();
            pictureBox1.BackgroundImage = new Bitmap(anh);
        }

        private void pictureBox_EXIT_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
