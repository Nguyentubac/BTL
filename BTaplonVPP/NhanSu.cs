using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BTaplonVPP
{
    internal class NhanSu
    {
        ketnoi kn;
        public NhanSu()
        {
            kn = new ketnoi();
        }
        bool check(string mans, string tentk, string mk, string quyen)
        {
            if (mans == "")
            {
                MessageBox.Show("Chưa nhập mã!");
                return false;
            }
            if (tentk == "")
            {
                MessageBox.Show("Chưa nhập mã!");
                return false;
            }
            if (mk == "")
            {
                MessageBox.Show("Chưa nhập mã!");
                return false;
            }
            if (quyen == "")
            {
                MessageBox.Show("Chưa nhập quyen!");
                return false;
            }
            return true;
        }
        public DataTable GetAllNS()
        {
            string sql = "select * from tbNhanSu";
            return kn.ReadData(sql);
        }

        public DataTable GetSomeNS(string mans)
        {
            string sql = "select * from tbNhanSu where MaNs=@ma";
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@ma",mans)
            };
            return kn.ReadData(sql, sp);
        }
        public bool Isvalid_NS(string mans)
        {
            string sql = "select * from tbNhanSu where MaNs=@ma";
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@ma",mans)
            };
            if (kn.ReadData(sql, sp).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool Login(string tk, string mk )
        {
            string sql = "select * from tbNhanSu where TenTaiKhoan= @tk and MatKhau = @mk ";
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@tk",tk),
            new SqlParameter("@mk",mk)
            };
            if(kn.ReadData(sql, sp).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public  void CreateNS(string mans, string tentk, string mk, string quyen)
        {
            if (check(mans, tentk, mk, quyen))
            {
                string sql = "INSERT INTO tbNhanSu(MaNS,TenTaiKhoan, MatKhau, Quyen) VALUES(@mans, @tentk, @mk, @quyen)";
                SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("mans", mans),
                new SqlParameter("tentk", tentk),
                new SqlParameter("mk", mk),
                new SqlParameter("quyen", quyen)
            };
                kn.CreateUpdateDelete(sql, sp);
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Thêm ko thành công!");
            }
        }
        public void DeleteNS(string mans)
        {
            string sql = "delete tbNhanSu where MaNS = @mans";
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@mans",mans)
            };
            kn.CreateUpdateDelete(sql, sp);
        }
        public void UpdateNS(string ma, string ten, string namsinh, string sdt, string diachi)
        {   
            string tuoi = (2025 - int.Parse(namsinh)).ToString();
            string sql = "UPDATE tbNhanSu SET Ten = @ten, SDT = @sdt,DiaChi = @diachi, NamSinh = @namsinh " +
            " WHERE MaNs = @mans;";
            SqlParameter[] sp = new SqlParameter[] {
                    new SqlParameter("@mans", ma),
                    new SqlParameter("@ten", ten),
                    new SqlParameter("@sdt", sdt),
                    new SqlParameter("@diachi", diachi),
                    new SqlParameter("@namsinh",namsinh)
                };
            kn.CreateUpdateDelete(sql, sp);
        }
        public string GetMans(string tk, string mk)
        {
            DataTable dataTable = new DataTable();
            string mans = string.Empty; // Khởi tạo biến mans là chuỗi rỗng
            string sql = "SELECT MaNs FROM tbNhanSu WHERE TenTaiKhoan = @tk AND MatKhau = @mk";

            SqlParameter[] parameters = new SqlParameter[] {
        new SqlParameter("@tk", tk),
        new SqlParameter("@mk", mk),
    };

            // Giả định rằng kn là một đối tượng kết nối database với phương thức ReadData
            dataTable = kn.ReadData(sql, parameters);

            // Kiểm tra xem có kết quả trả về hay không
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                mans = row["MaNs"].ToString(); // Lấy giá trị từ cột MaNs
            }

            return mans; // Trả về mã nhân sự hoặc chuỗi rỗng nếu không tìm thấy
        }
    }
}
