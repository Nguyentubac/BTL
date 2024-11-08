using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTaplonVPP
{
    internal class NhaCungCap
    {
        ketnoi kn;
        public NhaCungCap() { 
            kn = new ketnoi();
        }
        bool check(string mancc, string tenncc, string sdt, string diachi,string maspcc)
        {
            if (mancc == "")
            {
                MessageBox.Show("Chưa nhập mã!");
                return false;
            }
            if (tenncc == "")
            {
                MessageBox.Show("Chưa nhập họ tên!");
                return false;
            }
            if (sdt == "")
            {
                MessageBox.Show("Chưa nhập số điện thoại!");
                return false;
            }
            if (diachi == "")
            {
                MessageBox.Show("Chưa nhập dia chi!");
                return false;
            }
            if (maspcc == "")
            {
                MessageBox.Show("Chưa nhập ma sp cung cấp!");
                return false;
            }
            return true;
        }
        private void CreateNCC(string mancc, string tenncc, string sdt, string diachi, string maspcc)
        {
            if (check(mancc,tenncc,sdt,diachi,maspcc))
            {
                string sql = "\"insert into tbNhaCungCap values(@mancc,@tenncc,@sdt,@diachi,@maspcc)";
                SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@mancc", mancc),
                new SqlParameter("@tenncc", tenncc),
                new SqlParameter("@sdt", sdt),
                new SqlParameter("@diachi", diachi),
                new SqlParameter("@maspcc", maspcc)
                };
                kn.CreateUpdateDelete(sql, sp);
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Thêm ko thành công!");
            }

        }
        public void DeleteNCC(string mancc)
        {
            string sql = "delete tbNhaCungCap where MaNCC = @mancc";
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@mancc",mancc)
            };
            kn.CreateUpdateDelete(sql, sp);
        }
        public void UpdateNCC(string mancc, string tenncc, string sdt, string diachi, string maspcc)
        {
            if (check(mancc, tenncc, sdt, diachi, maspcc))
            {
                string sql = "UPDATE tbNhaCungCap SET TenNCC = @ten, SDT = @sdt, DiaChi = @dc, MaSpCC = @maspcc WHERE MaNCC = @ma";
                SqlParameter[] sp = new SqlParameter[] {
                    new SqlParameter("@ma", mancc),
                    new SqlParameter("@ten", tenncc),
                    new SqlParameter("@sdt", sdt),
                    new SqlParameter("@dc", diachi),
                    new SqlParameter("@maspcc",maspcc)
            };
                kn.CreateUpdateDelete(sql, sp);
            }
            else
            {
                MessageBox.Show("Sửa ko thành công!");
            }
        }
    }
}
