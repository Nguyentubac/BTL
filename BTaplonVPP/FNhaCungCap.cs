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
    public partial class FNhaCungCap : Form
    {
        NhaCungCap ncc = new NhaCungCap();
        public FNhaCungCap()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void grv_dsnv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                DataGridViewRow r = new DataGridViewRow();
                r = grv_dsnv.Rows[i];
                txt_mancc.Text = r.Cells[0].Value.ToString().Trim();
                txt_tncc.Text = r.Cells[1].Value.ToString().Trim();
                txt_sdt.Text = r.Cells[2].Value.ToString().Trim();
                txt_diachi.Text = r.Cells[3].Value.ToString().Trim();
                richTextBox1.AppendText(r.Cells[4].Value.ToString().Trim());
            }
        }

        private void FNhaCungCap_Load(object sender, EventArgs e)
        {
            DuaDLVaoBang();
        }


        private void ClearText()
        {
            txt_diachi.Text = "";
            txt_mancc.Text = "";
            txt_sdt.Text = "";
            txt_tncc.Text = "";
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_mancc.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập mã!");
                txt_mancc.Focus();
                return;
            }
            if (txt_tncc.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập tên!");
                txt_tncc.Focus();
                return;
            }
            if (txt_sdt.Text == "")
            {
                MessageBox.Show("Chưa nhập số điện thoại!");
                txt_sdt.Focus();
                return;
            }
            if (txt_diachi.Text == "")
            {
                MessageBox.Show("Chưa nhập địa chỉ!");
                txt_diachi.Focus();
                return;
            }
            if (!ncc.Isvalid_NS(txt_mancc.Text))
            {
                MessageBox.Show("Nhà cung cấp này đã tồn tại","Thông báo");
            }
            else
            {
                ncc.CreateNCC(txt_mancc.Text, txt_tncc.Text, txt_sdt.Text, txt_diachi.Text, richTextBox1.Text);
                ClearText();
                DuaDLVaoBang();
                MessageBox.Show("Thêm thành công!");
            }
            
        }
        public void DuaDLVaoBang()
        {
            grv_dsnv.DataSource = ncc.GetAllNCC();
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (ncc.Isvalid_NS(txt_mancc.Text.Trim()))
            {

                ncc.UpdateNCC(txt_mancc.Text, txt_tncc.Text, txt_sdt.Text, txt_diachi.Text, richTextBox1.Text);
                DuaDLVaoBang();
                ClearText();
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                if (MessageBox.Show("Không tồn nhà cung cấp nào có mã như vậy, có muốn thêm không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                {
                    btn_add_Click(sender, e);

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
                    ncc.DeleteNCC(ma);
                }
                DuaDLVaoBang();
                ClearText();
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
