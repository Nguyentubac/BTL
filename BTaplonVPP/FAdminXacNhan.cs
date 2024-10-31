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
    public partial class FAdminXacNhan : Form
    {
        ketnoi kncsdl = new ketnoi();
        FSignUp fSignUp = new FSignUp();
        string a;
        string b;
        string c;
        string d;
        public FAdminXacNhan(string a, string b, string c , string d)
        {
            InitializeComponent();
            this.a = a;
            this.b = b;
            this.c = c; 
            this.d = d; 
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (kncsdl.TonTaiAdmin(txt_tentk.Text, txt_mk.Text))
            {
                kncsdl.ThemAdmin(a, b, c, d);
                this.Close();
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Sai mk hoặc tài khoản");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {   
            if (MessageBox.Show("Bạn có chắc muốn thoát không ?", "Muốn thoát?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Close() ;
            }
        }


    }
}
