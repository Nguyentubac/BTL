using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTaplonVPP
{    
    internal class HoaDonNhap
    {
        ketnoi kn = new ketnoi();
    

        public DataTable GetAllHDN()
        {
            string sql = "select * from tbHoaDonNhap";
            return kn.ReadData(sql);
        }
        public DataTable GetCTHD(string ma)
        {
            string sql = "select MaNCC, MaNS, MaSP,TenSP,SoLuong,DonGia from tbChiTietHoaDonNhap Where MaHDN = @ma";
            SqlParameter[] hdn = new SqlParameter[] {
            new SqlParameter("@ma",ma)
            };
            return kn.ReadData(sql, hdn);
        }



    }
}
