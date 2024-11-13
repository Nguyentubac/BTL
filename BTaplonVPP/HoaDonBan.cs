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
            string sql = "select  MaNS,MaKH, MaSP,TenSP,SoLuong,DonGia,GiamGia from tbChiTietHoaDonBan Where MaHDN = @ma";
            SqlParameter[] hdb = new SqlParameter[] {
            new SqlParameter("@ma",ma)
            };
            return kn.ReadData(sql, hdb);
        }
        public void CreateHDB(string mahd, float tt)
        {
                string sql = "INSERT INTO tbHoaDonBan (MaHDB, TongTien, NgayBan) VALUES (@ma, @tt, @nb)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ma", masp),
                    new SqlParameter("@tt", tt),
                    new SqlParameter("@nb", DateTime.Now.ToString("dd-MM-yyyy"))
                };
                kn.CreateUpdateDelete(sql, parameters);
                MessageBox.Show("Thêm thành công!");
        }
        public void CreateCTHDB(string mahd, string mans, string makh, string masp, string tensp, int soluong, float dongia, float giamgia, string nb)
        {
            string sql = "INSERT INTO tbChiTietHoaDonBan (MaHDB, MaNS,MaKH, MaSp, TenSp, SoLuong, DonGia, GiamGia) VALUES (@mahd, @mans, @makh,@masp, @tensp, @sl,@dg,@gg)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@mahd", masp),
                    new SqlParameter("@mans", mans),
                    new SqlParameter("@makh", makh),
                    new SqlParameter("@masp", masp),
                    new SqlParameter("@tensp", tensp),
                    new SqlParameter("@sl", soluong),
                    new SqlParameter("@dg", dongia),
                    new SqlParameter("@gg", giamgia)
            };
            kn.CreateUpdateDelete(sql, parameters);
            MessageBox.Show("Thêm thành công!");
        }
    }
}
