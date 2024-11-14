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
using System.Runtime.InteropServices; // Để sử dụng COM Interop // Đặt tên không gian cho thư viện Excel
using Excel = Microsoft.Office.Interop.Excel;
namespace BTaplonVPP
{
    
    public partial class FManager : Form
    {
        DataTable dataTable = new DataTable();
        SanPham sp = new SanPham();
        ketnoi kn = new ketnoi();
        HoaDonBan hdb = new HoaDonBan();
        public float Tong { get; set; } = 0; // Tổng tiền
        public string MNS { get; set; } 
        public int SL { get; set; } // Số lượng
        public float DG { get; set; } // Đơn giá
        public string MKH { get; set; } // Mã khách hàng
        public string MSP { get; set; } // Mã sản phẩm
        public float TongTien { get; set; } // Tổng tiền
        public string TSP { get; set; } // Tên sản phẩm
        public float GG { get; set; }
        public FManager(string mans)
        {
            InitializeComponent();
            UpdateTotal();
            MNS = mans;
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
            txt_mns.Text = MNS;
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
            
            Tong = float.Parse(total.ToString());
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
                    
                    string MKH = "KH001";
                    MSP = row.Cells["MaSP"].Value.ToString(); 
                    TSP = row.Cells["TenSP"].Value.ToString(); 
                    SL = int.Parse(row.Cells["SoLuong"].Value.ToString()); 
                    DG =float.Parse(row.Cells["DonGia"].Value.ToString());
                    GG = float.Parse(numericUpDown2.Value.ToString());
                    float tongtien = Tong;

                    hdb.AddInvoice(tongtien,MNS,MKH, MSP,TSP, SL, DG, GG);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Excel.Application xcelApp = new Excel.Application();

            try
            {
                xcelApp.Visible = true;
                // Thêm một workbook mới
                Excel.Workbook workbook = xcelApp.Workbooks.Add();
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
                // Gộp các ô từ A1 đến I12
                for (int i = 1; i <= 11; i++)
                {
                    Excel.Range range = worksheet.Range[$"A{i}:H{i}"];
                    range.Merge();
                    if (i == 7 || i == 5)
                    {
                        range.Font.Name = "Arial";
                        range.Font.Size = 18;
                        range.Font.Bold = true;
                    }
                }
                worksheet.Cells[4, 1] = "Địa chỉ: 123 Đường ABC, Thành phố XYZ";
                // Ghi dấu "=================" vào dòng 5
                worksheet.Cells[5, 1] = "'=======================================================";
                worksheet.Cells[5, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                worksheet.Cells[7, 1] = "HOÁ ĐƠN BÁN HÀNG";
                worksheet.Cells[7, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                // Ghi "Khách Hàng :" vào dòng 8
                worksheet.Cells[8, 1] = "Khách Hàng : " + MKH;
                worksheet.Cells[9, 1] = "Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy");
                worksheet.Cells[10, 1] = "Ngân hàng Thương mại cổ phần Quân đội (MB Bank) STK 0836075402 / CTK : Nguyễn Tự Bắc";
                worksheet.Cells[11, 1] = "Hình thức thanh toán";

                worksheet.Cells[12, 1] = "STT";
                worksheet.Cells[12, 2] = "Mã Sản Phẩm";
                worksheet.Cells[12, 3] = "Tên Sản Phẩm";
                worksheet.Cells[12, 4] = "Số Lượng";
                worksheet.Cells[12, 5] = "Đơn Giá";
                worksheet.Cells[12, 6] = "Thành Tiền";
                int so_dong = dataTable.Rows.Count;

                int index = 0;
                foreach (DataRow existingRow in dataTable.Rows)
                {   worksheet.Cells[13 + index, 1] = index + 1;
                    worksheet.Cells[13 + index, 2] = existingRow[0].ToString();
                    worksheet.Cells[13 + index, 3] = existingRow[1].ToString();
                    worksheet.Cells[13 + index, 4] = existingRow[2].ToString();
                    worksheet.Cells[13 + index, 5] = existingRow[3].ToString();
                    worksheet.Cells[13 + index, 6] = (int.Parse(existingRow[2].ToString()) * int.Parse(existingRow[3].ToString())).ToString();

                    for (int i = 1; i <= 7; i++) {
                        Excel.Range cell = worksheet.Cells[13 + index, i];
                        cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    }
                    index++;
                }
                worksheet.Cells[13 + index, 1] = "Tổng tiền : ";
                worksheet.Cells[13 + index, 6].Formula = string.Format("=SUM(F13:F{0})", 13 + index - 1);

                worksheet.Cells[14 + index, 1] = "Giảm giá / Chiết Khấu : ";
                worksheet.Cells[14 + index, 6] = GG + "%";

                worksheet.Cells[15 + index, 1] = "Số tiền cần thanh toán : ";
                worksheet.Cells[15 + index, 6] = Tong.ToString("#,0") + "VNĐ";
                Excel.Range r = worksheet.Range[$"A{13+index}:G{15+index}"];
                r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                // tô màu 
                //worksheet.Cells[13 + index, 6].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue);

                worksheet.Columns[1].AutoFit();
                worksheet.Columns[2].AutoFit();
                worksheet.Columns[3].AutoFit();
                worksheet.Columns[4].AutoFit();
                worksheet.Columns[5].AutoFit();
                worksheet.Columns[6].AutoFit();
                worksheet.Columns[7].AutoFit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                xcelApp.Quit();
                Marshal.ReleaseComObject(xcelApp);
                Console.WriteLine("Ứng dụng Excel đã đóng.");
            }
            // Giải phóng bộ nhớ
            GC.Collect();
            GC.WaitForPendingFinalizers();
        
        
        }
    }
}
