using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTaplonVPP
{
    
    public partial class FManager : Form
    {
        DataTable dataTable = new DataTable();
        SanPham sp = new SanPham();
        ketnoi kn = new ketnoi();
        HoaDonBan hdb = new HoaDonBan();
        float tong = 0;
        public FManager()
        {
            InitializeComponent();
            UpdateTotal();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void chiTiếtThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void khoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FManager_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sp.GetAllSP();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                dataTable.Columns.Add(column.Name, column.ValueType);
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FProfile fProfile = new FProfile();
            fProfile.ShowDialog();
        }

        private void thôngTinNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FNhaCungCap fNhaCungCap = new FNhaCungCap();
            fNhaCungCap.ShowDialog();
        }

        private void thôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FKhachHang fKhachHang = new FKhachHang();
            fKhachHang.ShowDialog();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void quảnLýNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FStaffManager fStaffManager = new FStaffManager();
            fStaffManager.ShowDialog();
        }

        private void hóaĐơnNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FHoaDonNhap fHoaDonNhap = new FHoaDonNhap();
            fHoaDonNhap.ShowDialog();
        }

        private void hóaĐơnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FHoaDonXuat fHoaDonXuat = new FHoaDonXuat();
            fHoaDonXuat.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                string ma;
                DataGridViewRow r = new DataGridViewRow();
                r = dataGridView1.Rows[i];
                ma = r.Cells[0].Value.ToString().Trim();
                

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Duyệt qua tất cả các hàng được chọn để xóa
                foreach (DataGridViewRow selectedRow in dataGridView2.SelectedRows)
                {
                    // Đảm bảo không xóa hàng mới thêm (nếu có)
                    if (!selectedRow.IsNewRow)
                    {
                        dataGridView2.Rows.Remove(selectedRow);
                    }
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn một hàng để xóa.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {



            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                {
                    // Tạo một DataRow mới
                    DataRow row = dataTable.NewRow();

                    // Sao chép dữ liệu từ hàng được chọn vào DataRow
                    for (int i = 0; i < selectedRow.Cells.Count; i++)
                    {
                        row[i] = selectedRow.Cells[i].Value; // Gán giá trị từ ô vào DataRow
                    }

                    // Đặt giá trị của cột "SoLuong" thành 0
                    row["SoLuong"] = 1;

                    // Kiểm tra xem hàng đã tồn tại trong DataTable chưa
                    bool exists = false;
                    foreach (DataRow existingRow in dataTable.Rows)
                    {
                        // Giả sử bạn kiểm tra sự tồn tại dựa trên cột "ID"
                        if (existingRow["MaSp"].Equals(row["MaSp"])) // Thay "ID" bằng cột bạn muốn kiểm tra
                        {
                            exists = true;
                            MessageBox.Show("Sản phẩm đã tồn tại","Thông báo");
                            break; // Thoát khỏi vòng lặp nếu đã tìm thấy
                        }
                    }

                    // Nếu hàng chưa tồn tại, thêm vào DataTable
                    if (!exists)
                    {
                        dataTable.Rows.Add(row); // Thêm DataRow vào DataTable
                    }
                }

                // Cập nhật DataGridView2 với DataTable mới
                dataGridView2.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Hãy chọn 1 sản phẩm");
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Lấy hàng đầu tiên được chọn
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                // Cập nhật giá trị của cột cụ thể (ví dụ cột "SoLuong")
                selectedRow.Cells["SoLuong"].Value = nsl.Value; // Thay "SoLuong" bằng tên cột thực tế
            }
            else
            {
                MessageBox.Show("Hãy chọn một hàng để thay đổi giá trị.");
            }

        }

        private void cbb_loai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tentk = cbb_loai.SelectedItem.ToString();
            dataGridView1.DataSource = sp.GetTimKiem(tentk);
            if(cbb_loai.SelectedItem.ToString() == "Tất Cả")
            {
                dataGridView1.DataSource = sp.GetAllSP();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        private void UpdateTotal()
        {
            decimal total = 0;
            int sl = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                // Giả sử cột thứ hai chứa giá trị số tiền
                if (row.Cells[3].Value != null && decimal.TryParse(row.Cells[3].Value.ToString(), out decimal value))
                {
                    sl = int.Parse(row.Cells[2].Value.ToString());
                    total += value*sl;
                }
            }
            total -= numericUpDown2.Value/100 * total;
            
            tong = float.Parse(total.ToString());
            // Cập nhật giá trị vào TextBox
            textBox1.Text = total.ToString("#,0") + "VNĐ"; // Định dạng tiền tệ
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTotal();
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateTotal();
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateTotal();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            float.TryParse(numericUpDown2.Value.ToString(), out float km);
            
            if (numericUpDown2.Value < 0 )
            {
                MessageBox.Show("Khuyến mãi không thể âm", "Thông báo");
                numericUpDown2.Value = 0;   
            }else if(km > 15 )
            {
                MessageBox.Show("Khuyến mãi không thể lớn hơn 15%", "Thông báo");
                numericUpDown2.Value = 0;
            }
            else
            UpdateTotal();
        }

        private void buttontt_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (!row.IsNewRow)
                {
                    string MNS ="" ;
                    MessageBox.Show(MNS);
                    string MKH = "";
                    string MSP = row.Cells["MaSP"].Value.ToString(); 
                    string TSP = row.Cells["TenSP"].Value.ToString(); 
                    int SL = int.Parse(row.Cells["SoLuong"].Value.ToString()); 
                    float DG =float.Parse(row.Cells["DonGia"].Value.ToString());
                    float GG = float.Parse(numericUpDown2.Value.ToString());
                    float tongtien = tong;

                    
                    hdb.AddInvoice(tongtien,MNS,MKH, MSP,TSP, SL, DG, GG);
                }
            }
        }
    }
}
