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
    public partial class FProfile : Form
    {
        NhanSu ns =new NhanSu();
        string mans = "";
        public FProfile(string getmns)
        {
            InitializeComponent();
            mans = getmns;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //FAdminXacNhan fAdminXacNhan = new FAdminXacNhan();
            //fAdminXacNhan.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FProfile_Load(object sender, EventArgs e)
        {
            DataTable dt = ns.GetProfile(mans); // Gọi hàm GetTable

            // Kiểm tra xem DataTable có dữ liệu không
            if (dt.Rows.Count > 0)
            {
                // Lấy dữ liệu từ hàng đầu tiên
                DataRow row = dt.Rows[0];
                txt_tentk.Text = row["TenTaiKhoan"].ToString(); // Gán mã nhân viên vào TextBox
                txtht.Text = row["Ten"].ToString(); // Gán tên nhân viên vào TextBox
                txtsdt.Text = row["SDT"].ToString(); // Gán tuổi vào TextBox
                txtdc.Text = row["DiaChi"].ToString();
                dateTimePicker2.Value = DateTime.Parse(row["NamSinh"].ToString());
            }
            else
            {
                MessageBox.Show("Không có dữ liệu nhân viên.");
            }
        }
    }
}
