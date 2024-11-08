using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTaplonVPP
{
    internal class KhachHang
    {
        ketnoi kn;
        public KhachHang() { 
            kn = new ketnoi();
        }
        bool check(string makh, string tenkh, string sdt)
        {
            if (makh == "")
            {
                MessageBox.Show("Chưa nhập mã!");
                return false ;
            }
            if (tenkh == "")
            {
                MessageBox.Show("Chưa nhập họ tên!");
                return false ;
            }
            if (sdt == "")
            {
                MessageBox.Show("Chưa nhập số điện thoại!");
                return false ;
            }
            return true;
        }
        public DataTable GetAllKH()
        {
            string sql = "select * from tbKhachHang";
            return kn.ReadData(sql);
        }
        public DataTable GetSomeKH(string makh)
        {
            string sql = "select * from tbKhachHang MaKH = @makh";
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@makh",makh)
            };
            return kn.ReadData(sql, sp);
        }

        public void CreateKH(string makh, string tenkh, string sdt)
        {
            if(check(makh, tenkh, sdt)){
                string sql = "INSERT INTO tbKhachHang values(@makh,@tenkh,@sdt)";
                SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@makh", makh),
                new SqlParameter("@tenkh", tenkh),
                new SqlParameter("@sdt", sdt)
                };
                kn.CreateUpdateDelete(sql, sp);
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Thêm ko thành công!");
            }
            
        }
        public void DeleteKH(string makh)
        {
            string sql = "DELETE FROM tbKhachHang WHERE MaKH =@makh";
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@mk",makh)
            };
            kn.CreateUpdateDelete(sql, sp);
        }
        public void UpdateKH(string makh, string tenkh, string sdt)
        {
            if (check(makh, tenkh, sdt))
            {
                string sql = "UPDATE tbKhachHang SET TenKH = @tenkh, SDT = @sdt WHERE MaKH = @makh";
                SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@makh", makh),
            new SqlParameter("@tenkh", tenkh),
            new SqlParameter("@sdt", sdt)
            };
                kn.CreateUpdateDelete(sql, sp);
            }
            else
            {
                MessageBox.Show("Sửa ko thành công!");
            }
        }
        public bool Isvalid_KH(string makh)
        {
            string sql = "select * from tbKhachHang where MaKH=@ma";
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@ma",makh)
            };
            if (kn.ReadData(sql, sp) != null)
            {
                return true;
            }
            return false;
        }
    }
}
