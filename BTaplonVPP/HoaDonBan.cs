using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTaplonVPP
{
    internal class HoaDonBan
    {
        ketnoi kn = new ketnoi();
        public DataTable GetAllHDB()
        {
            string sql = "select * from tbHoaDonBan";
            return kn.ReadData(sql);
        }
        public DataTable GetCTHD(string ma)
        {
            string sql = "select MaNs, MaKH, MaSp,TenSp,SoLuong,DonGia,GiamGia from tbChiTietHoaDonBan Where MaHDB = @ma";
            SqlParameter[] hdn = new SqlParameter[] {
            new SqlParameter("@ma",ma)
            };
            return kn.ReadData(sql, hdn);
        }
        public string CreateHDB(float tt)
        {
            // Tạo mã hóa đơn duy nhất
            string mahd = "HDB" + DateTime.Now.ToString("yyyyMMddHHmmssfff"); // Thêm milliseconds để tăng tính duy nhất

            string sql = "INSERT INTO tbHoaDonBan (MaHDB, TongTien, NgayBan) VALUES (@ma, @tt, @nb)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma", mahd),
                new SqlParameter("@tt", tt),
                new SqlParameter("@nb", DateTime.Now.ToString("dd-MM-yyyy").ToString())
            };

            try
            {
                kn.CreateUpdateDelete(sql, parameters);
                //MessageBox.Show("Thêm hóa đơn thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message);
            }

            return mahd; // Trả về mã hóa đơn vừa tạo
        }

        public void CreateCTHDB(string mahd, string mans, string makh, string masp, string tensp, int soluong, float dongia, float giamgia)
        {
            // Câu lệnh SQL để chèn thông tin chi tiết hóa đơn
            string sql = "INSERT INTO tbChiTietHoaDonBan (MaHDB, MaNS, MaKH, MaSp, TenSp, SoLuong, DonGia, GiamGia) VALUES (@mahd, @mans, @makh, @masp, @tensp, @sl, @dg, @gg)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@mahd", mahd),
                new SqlParameter("@mans", mans),
                new SqlParameter("@makh", makh),
                new SqlParameter("@masp", masp),
                new SqlParameter("@tensp", tensp),
                new SqlParameter("@sl", soluong),
                new SqlParameter("@dg", dongia),
                new SqlParameter("@gg", giamgia)
            };

            try
            {
                kn.CreateUpdateDelete(sql, parameters);
                //MessageBox.Show("Thêm chi tiết hóa đơn thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
                MessageBox.Show("ngoại lệ ");
            }
        }

        public void AddInvoice(float tt, string mans, string makh, string masp, string tensp, int soluong, float dongia, float giamgia)
        {   

            string mahd = CreateHDB(tt); // Tạo hóa đơn và lấy mã
            CreateCTHDB(mahd, mans, makh, masp, tensp, soluong, dongia, giamgia); // Tạo chi tiết hóa đơn
        }
    }
}
