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
    public partial class FProductManager : Form
    {   SanPham sp = new SanPham();
        public FProductManager()
        {
            InitializeComponent();
        }
        ketnoi kncsdl = new ketnoi();
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_masp.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập mã!");
                txt_masp.Focus();
                return;
            }
            if (txt_tensp.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập tên!");
                txt_tensp.Focus();
                return;
            }
            if (txt_sluong.Text == "")
            {
                MessageBox.Show("Chưa nhập số lượng!");
                txt_sluong.Focus();
                return;
            }
            if (txt_dgia.Text == "")
            {
                MessageBox.Show("Chưa nhập đơn giá!");
                txt_dgia.Focus();
                return;
            }
            if (txt_loaisp.Text == "")
            {
                MessageBox.Show("Chưa nhập loại sản phẩm!");
                txt_loaisp.Focus();
                return;
            }
            if (sp.Isvalid_SP(txt_masp.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại");
                txt_masp.Focus();
                return;
            }
            sp.CreateSP(txt_masp.Text.Trim(), txt_tensp.Text, txt_loaisp.Text, float.Parse(txt_dgia.Text), txt_sluong.Text);
            ClearTexts();
            MessageBox.Show("Thêm thành công!");
        }
        void ClearTexts()
        {
            txt_masp.Clear();
            txt_tensp.Clear();
            txt_dgia.Clear();
            txt_loaisp.Clear();
            txt_sluong.Clear();
        }
        void DuaDLVaoBang()
        {
            grv_dssp.DataSource = sp.GetAllSP();
           
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (grv_dssp.SelectedRows == null) return;
            if (grv_dssp.SelectedRows[0].Cells[0].Value == null) return;
            if (MessageBox.Show("Chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow r in grv_dssp.SelectedRows)
                {
                    string ma = r.Cells[0].Value.ToString();
                   sp.DeleteSP(ma);
                }
                DuaDLVaoBang();
                ClearTexts();
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (sp.Isvalid_SP(txt_masp.Text.Trim()))
            {

                sp.UpdateSP(txt_masp.Text, txt_tensp.Text, txt_loaisp.Text, float.Parse(txt_dgia.Text), txt_sluong.Text);
                DuaDLVaoBang();
                ClearTexts();
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                if (MessageBox.Show("Không tồn tại sản phẩm nào có mã như vậy, có muốn thêm không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                {
                    btn_add_Click(sender, e);

                }
            }
        }

        private void FProductManager_Load(object sender, EventArgs e)
        {
            DuaDLVaoBang();
        }

        private void grv_dssp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;//Chỉ số của hàng đang chọn
            if (i >= 0)
            {
                DataGridViewRow r = new DataGridViewRow();
                r = grv_dssp.Rows[i];
                txt_masp.Text = r.Cells[0].Value.ToString();
                txt_tensp.Text = r.Cells[1].Value.ToString();
                txt_loaisp.Text = r.Cells[2].Value.ToString();
                txt_sluong.Text = r.Cells[3].Value.ToString();
                txt_dgia.Text = r.Cells[4].Value.ToString();
            }
        }
    }
}
