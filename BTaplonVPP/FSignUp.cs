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
    public partial class FSignUp : Form
    {
        public FSignUp()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Có thật không?", "Muốn thoát?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Close();
            }
           
        }


        private void button2_Click(object sender, EventArgs e)
        {       
                if (MessageBox.Show("Bạn phải xác nhận quyền admin", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    FAdminXacNhan fa = new FAdminXacNhan();
                    fa.ShowDialog();
                    
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo");
                }
                
            
        }
    }
}
