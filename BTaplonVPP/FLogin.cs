using BTaplonVPP.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTaplonVPP
{
    public partial class FLogin : Form
    {
        bool flagEye = true;
        ketnoi kncsdl = new ketnoi();
        NhanSu ns  = new NhanSu();
        public string mans;
        public FLogin()
        {
      
            InitializeComponent();
            pictureBox2.Image = Properties.Resources.visible;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            if (flagEye == true)
            {
                txt_mk.UseSystemPasswordChar = false;
                pictureBox2.Image = Properties.Resources.hide;
                flagEye = false;
            }
            else {
                txt_mk.UseSystemPasswordChar = true;
                pictureBox2.Image = Properties.Resources.visible;
                flagEye = true;
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Có thật không?","Muốn thoát?",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mans = ns.GetMans(txt_tentk.Text, txt_mk.Text);
            if (ns.Login(txt_tentk.Text, txt_mk.Text))
            {
                FManager fm = new FManager(mans);
                this.Hide();
                fm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai mk hoặc tài khoản");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {   
            FSignUp fc = new FSignUp();
            this.Hide();
            fc.ShowDialog();
            this.Show();
        }
    }
}
