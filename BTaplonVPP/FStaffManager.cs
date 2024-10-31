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
    public partial class FStaffManager : Form
    {
        public FStaffManager()
        {
            InitializeComponent();
        }

        ketnoi kncsdl = new ketnoi();
        void ClearTexts()
        {
            txt_manv.Clear();
            txt_tennv.Clear();
            txt_sdt.Clear();
            dtp_nansinh.Text = null;
            txt_diachi.Clear();
        }
        void DuaDLVaoBang()
        {
            grv_dsnv.DataSource = kncsdl.getAllNS();
        }


        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public bool checkNS()
        {
            if (txt_manv.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập mã!");
                txt_manv.Focus();
                return false;
            }
            if (txt_tennv.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập họ tên!");
                txt_tennv.Focus();
                return false;
            }
            if (txt_sdt.Text == "")
            {
                MessageBox.Show("Chưa nhập số điện thoại!");
                txt_sdt.Focus();
                return false;
            }
            if (txt_diachi.Text == "")
            {
                MessageBox.Show("Chưa nhập địa chỉ!");
                txt_diachi.Focus();
                return false;
            }
            if (dtp_nansinh == null)
            {
                MessageBox.Show("Chưa nhập ngày sinh!");
                dtp_nansinh.Focus();
                return false;
            }
            if (kncsdl.TonTaiNS(txt_manv.Text.Trim()))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại");
                txt_manv.Focus();
                return false;
            }
            return true;
        }

        private void grv_dsnv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;//Chỉ số của hàng đang chọn
            if (i >= 0)
            {
                DataGridViewRow r = new DataGridViewRow();
                r = grv_dsnv.Rows[i];
                txt_manv.Text = r.Cells[0].Value.ToString();
                txt_tennv.Text = r.Cells[1].Value.ToString();
                txt_sdt.Text = r.Cells[2].Value.ToString();
                txt_diachi.Text = r.Cells[3].Value.ToString();
                dtp_nansinh.Text = r.Cells[4].Value.ToString();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (checkNS())
            {
                if (kncsdl.TonTaiNS(txt_manv.Text.Trim()))
                {
                    kncsdl.SuaNS(txt_manv.Text, txt_tennv.Text, txt_sdt.Text, txt_diachi.Text, dtp_nansinh.Text);
                    DuaDLVaoBang();
                    ClearTexts();
                    MessageBox.Show("Sửa thành công!");
                }
                else
                {
                    if (MessageBox.Show("Không tồn tại nhân sự nào có mã như vậy, có muốn thêm không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                    {
                        FSignUp fSignUp = new FSignUp();
                        fSignUp.ShowDialog();
                        this.Close();
                    }
                }
            }
            
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (grv_dsnv.SelectedRows == null) return;
            if (grv_dsnv.SelectedRows[0].Cells[0].Value == null) return;
            if (MessageBox.Show("Chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow r in grv_dsnv.SelectedRows)
                {
                    string ma = r.Cells[0].Value.ToString();
                    kncsdl.XoaNS(ma);
                }
                DuaDLVaoBang();
                ClearTexts();
            }
        }

        private void FStaffManager_Load_1(object sender, EventArgs e)
        {
            DuaDLVaoBang();
        }
    }
}
