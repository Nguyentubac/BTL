using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTaplonVPP
{///
    internal class ketnoi
    {
        SqlConnection conn;

        public void mokn()
        {
            string sql = @"Data Source=DESKTOP-M6B6C7R\SQL;Initial Catalog=VPP;Integrated Security=True";
            conn = new SqlConnection(sql);
            //aaa
            conn.Open();
        }
        public void dongkn()
        {
            conn.Close();
        }

        //Khach hang
        public DataTable getAllKH()
        {
            DataTable table = new DataTable();
            mokn();
            string sql = "select * from tbKhachHang";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            table.Load(sdr);
            dongkn();
            return table;
        }
        public bool TonTaiKH(string ma)
        {
            bool kt = false;
            mokn();
            string sql = "select * from tbKhachHang where MaKH=@makh";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("makh", ma);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows) kt = true;
            dongkn();
            return kt;
        }
        public void ThemKH(string ma, string ten, string sdt)
        {
            mokn();
            string sql = "insert into tbKhachHang values(@makh,@tenkh,@sdt)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("makh", ma);
            cmd.Parameters.AddWithValue("tenkh", ten);
            cmd.Parameters.AddWithValue("sdt", sdt);
            cmd.ExecuteNonQuery();
            dongkn();
        }
        public void XoaKH(string ma)
        {

            mokn();
            string sql = "delete tbKhachHang where MaKH =@makh";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("makh", ma);
            cmd.ExecuteNonQuery();
            dongkn();
        }
        public void SuaKH(string ma, string ten, string sdt)
        {
            mokn(); // Mở kết nối
            string sql = "UPDATE tbKhachHang SET TenKH = @tenkh, SDT = @sdt WHERE MaKH = @makh";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@makh", ma);
            cmd.Parameters.AddWithValue("@tenkh", ten);
            cmd.Parameters.AddWithValue("@sdt", sdt);

            // Thực thi câu lệnh
            cmd.ExecuteNonQuery();

            dongkn(); // Đóng kết nối
        }

        //Nha cung cap
        public DataTable getAllNCC()
        {
            DataTable table = new DataTable();
            mokn();
            string sql = "select * from tbNhaCungCap";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            table.Load(sdr);
            dongkn();
            return table;
        }
        public bool TonTaiNCC(string ma)
        {
            bool kt = false;
            mokn();
            string sql = "select * from tbNhaCungCap where MaNCC=@mancc";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("mancc", ma);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows) kt = true;
            dongkn();
            return kt;
        }
        public void ThemNCC(string ma, string ten, string sdt, string dc, string maspcc)
        {
            mokn();
            string sql = "insert into tbNhaCungCap values(@mancc,@tenncc,@sdt,@diachi,@maspcc)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("mancc", ma);
            cmd.Parameters.AddWithValue("tenncc", ten);
            cmd.Parameters.AddWithValue("sdt", sdt);
            cmd.Parameters.AddWithValue("diachi", dc);
            cmd.Parameters.AddWithValue("maspcc", maspcc);
            cmd.ExecuteNonQuery();
            dongkn();
        }
        public void XoaNCC(string ma)
        {

            mokn();
            string sql = "delete tbNhaCungCap where MaNCC =@mancc";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("mancc", ma);
            cmd.ExecuteNonQuery();
            dongkn();
        }
        public void SuaNCC(string ma, string ten, string sdt, string dc, string maspcc)
        {
            mokn(); // Mở kết nối
            string sql = "UPDATE tbNhaCungCap SET TenNCC = @ten, SDT = @sdt, DiaChi = @dc, MaSpCC = @maspcc WHERE MaNCC = @ma";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@makh", ma);
            cmd.Parameters.AddWithValue("@tenkh", ten);
            cmd.Parameters.AddWithValue("@sdt", sdt);
            cmd.Parameters.AddWithValue("@dc", dc);
            cmd.Parameters.AddWithValue("@maspcc", maspcc);
            // Thực thi câu lệnh
            cmd.ExecuteNonQuery();

            dongkn(); // Đóng kết nối
        }

        //San pham
        public DataTable getAllSP()
        {
            DataTable table = new DataTable();
            mokn();
            string sql = "select * from tbSanPham";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            table.Load(sdr);
            dongkn();
            return table;
        }
        public bool TonTaiSP(string ma)
        {
            bool kt = false;
            mokn();
            string sql = "select * from tbSanPham where MaSp=@ma";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("ma", ma);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows) kt = true;
            dongkn();
            return kt;
        }
        public void ThemSP(string ma, string ten, string loaisp,float dg, string sl )
        {
            mokn();
            string sql = "insert into tbSanPham values(@ma,@ten,@sl,@dg,@loai)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("ma", ma);
            cmd.Parameters.AddWithValue("ten", ten);
            cmd.Parameters.AddWithValue("loai", loaisp);
            cmd.Parameters.AddWithValue("dg", dg);
            cmd.Parameters.AddWithValue("sl", sl);
            cmd.ExecuteNonQuery();
            dongkn();
        }
        public void XoaSP(string ma)
        {

            mokn();
            string sql = "delete tbSanPham where MaSp =@ma";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("ma", ma);
            cmd.ExecuteNonQuery();
            dongkn();
        }
        public void SuaSP(string ma, string ten, string loaisp, string dg, string sl)
        {
            mokn(); // Mở kết nối
            string sql = "UPDATE tbSanPham SET TenSP = @ten, SoLuong = @sl, DonGia = @dg, Loai = @loai WHERE MaSp = @ma";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ma", ma);
            cmd.Parameters.AddWithValue("@ten", ten);
            cmd.Parameters.AddWithValue("@sl", sl);
            cmd.Parameters.AddWithValue("@dg", dg);
            cmd.Parameters.AddWithValue("@loai", loaisp);
            // Thực thi câu lệnh
            cmd.ExecuteNonQuery();

            dongkn(); // Đóng kết nối
        }
    }
}
 
