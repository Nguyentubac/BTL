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
    internal class SanPham
    {
        ketnoi kn;
        public SanPham() { 
            kn = new ketnoi();
        }
        bool check(string masp, string tensp, string sluong, float dgia, string loaisp)
        {
            if (masp == "")
            {
                MessageBox.Show("Chưa nhập mã!");
                
                return false;
            }
            if (tensp == "")
            {
                MessageBox.Show("Chưa nhập tên!");
                
                return false;
            }
            if (sluong== "")
            {
                MessageBox.Show("Chưa nhập số lượng!");
                
                return false;
            }
            if (dgia < 0)
            {
                MessageBox.Show("Giá chưa hợp lệ !");
                
                return false;
            }
            if (loaisp == "")
            {
                MessageBox.Show("Chưa nhập loại sản phẩm!");
                return false;
            }
            return true;
        }
        public DataTable GetAllSP()
        {
            string sql = "select * from tbSanPham";
            return kn.ReadData(sql);
        }
        public DataTable GetSomeSP(string masp)
        {
            string sql = "select * from tbSanPham where  MaSp = @masp";
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@masp",masp)
            };
            return kn.ReadData(sql, sp);
        }
        public void CreateSP(string masp, string tensp, string sluong, float dgia, string loaisp)
        {
            if (check(masp, tensp, sluong, dgia, loaisp))
            {
                string sql = "INSERT INTO tbSanPham (MaSp, TenSp, SoLuong, DonGia, LoaiSanPham) VALUES (@ma, @ten, @sl, @dg, @loai)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ma", masp),
                    new SqlParameter("@ten", tensp),
                    new SqlParameter("@sl", sluong),
                    new SqlParameter("@dg", dgia),
                    new SqlParameter("@loai", loaisp)
                };
                kn.CreateUpdateDelete(sql, parameters);
                
            }
            else
            {
                MessageBox.Show("Thêm ko thành công!");
            }
               
            
        }
        public void UpdateSP(string masp, string tensp, string sluong, float dgia, string loaisp)
        {
            if (check(masp, tensp, sluong, dgia, loaisp))
            {
                string sql = "UPDATE tbSanPham SET TenSP = @ten, SoLuong = @sl, DonGia = @dg, LoaiSanPham = @loai WHERE MaSp = @ma";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ma", masp),
                    new SqlParameter("@ten", tensp),
                    new SqlParameter("@sl", sluong),
                    new SqlParameter("@dg", dgia),
                    new SqlParameter("@loai", loaisp)
                };
                kn.CreateUpdateDelete(sql, parameters);
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Sửa ko thành công!");
            }
        }
        public void DeleteSP(string masp)
        {
            string sql = "delete tbSanPham where MaSp =@ma";
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@ma",masp)
            };
            kn.CreateUpdateDelete(sql, sp);
        }
        public bool Isvalid_SP(string masp)
        {
            string sql = "select * from tbSanPham where MaSp=@ma";
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@ma",masp)
            };
            if (kn.ReadData(sql, sp) != null)
            {
                return true;
            }
            return false;
        }
        public DataTable GetHD(string masp)
        {
            string sql = "select Ma from tbSanPham";
            return kn.ReadData(sql);
        }
        public DataTable GetTimKiem(string tentk)
        {
            string sql = "select * from tbSanPham where LoaiSanPham = @lsp";
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@lsp",tentk)
            };
            return kn.ReadData(sql, sp);
        }
        public void UpdateSPM(string masp, int sluong)
        {
            
                string sql = "UPDATE tbSanPham SET SoLuong = Soluong - @sl WHERE MaSp = @ma";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ma", masp),
                    new SqlParameter("@sl", sluong)
                };
                kn.CreateUpdateDelete(sql, parameters);
                MessageBox.Show("Sửa thành công!");
         }
            
        }
}
