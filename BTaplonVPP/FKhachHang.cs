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
    public partial class FKhachHang : Form
    {
        public FKhachHang()
        {
            InitializeComponent();
        }
        ketnoi kncsdl = new ketnoi();
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_makh.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập mã!");
                txt_makh.Focus();
                return;
            }
            if (txt_tenkh.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập họ tên!");
                txt_tenkh.Focus();
                return;
            }
            if (txt_sdt.Text == "")
            {
                MessageBox.Show("Chưa nhập giới tính!");
                txt_sdt.Focus();
                return;
            }
            if (kncsdl.TonTaiKH(txt_makh.Text.Trim()))
            {
                MessageBox.Show("Mã khách hàng đã tồn tại");
                txt_makh.Focus();
                return;
            }
            kncsdl.ThemKH(txt_makh.Text.Trim(), txt_tenkh.Text,  txt_sdt.Text);
            DuaDLVaoBang();
            ClearTexts();
            MessageBox.Show("Thêm thành công!");
        }
        void ClearTexts()
        {
            txt_makh.Clear();
            txt_tenkh.Clear();
            txt_sdt.Clear();
        }
        void DuaDLVaoBang()
        {
            grv_dskh.DataSource = kncsdl.getAllKH();
            //dataGridView1.DataSource = kn.getAllKhachHang();
            //dataGridView1.DataSource = khDB.getAllKH();
        }

        private void grv_dskh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grv_dskh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;//Chỉ số của hàng đang chọn
            if (i >= 0)
            {
                DataGridViewRow r = new DataGridViewRow();
                r = grv_dskh.Rows[i];
                txt_makh.Text = r.Cells[0].Value.ToString();
                txt_tenkh.Text = r.Cells[1].Value.ToString();
                txt_sdt.Text = r.Cells[2].Value.ToString();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (grv_dskh.SelectedRows == null) return;
            if (grv_dskh.SelectedRows[0].Cells[0].Value == null) return;
            if (MessageBox.Show("Chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow r in grv_dskh.SelectedRows)
                {
                    string ma = r.Cells[0].Value.ToString();
                    kncsdl.XoaKH(ma);
                }
                DuaDLVaoBang();
                ClearTexts();
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FKhachHang_Load(object sender, EventArgs e)
        {
            DuaDLVaoBang();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

            if (kncsdl.TonTaiKH(txt_makh.Text.Trim()))
            {
                kncsdl.SuaKH(txt_makh.Text, txt_tenkh.Text, txt_sdt.Text);
                DuaDLVaoBang();
                ClearTexts();
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                if (MessageBox.Show("Không tồn tại khách hàng nào có mã như vậy, có muốn thêm không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                {
                    btn_add_Click(sender, e);

                }
            }
        }
    }
}
