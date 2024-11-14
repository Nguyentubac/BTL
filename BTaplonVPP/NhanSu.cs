using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTaplonVPP
{
    internal class NhanSu
    {
        ketnoi kn;
        public NhanSu()
        {
            kn = new ketnoi();
        }
        bool check(string mans, string tenns, string dc, string sdt, string namsinh,string tentk, string mk, string quyen)
        {
            if (mans == "")
            {
                MessageBox.Show("Chưa nhập mã!");
                return false;
            }
            
            if (tenns == "")
            {
                MessageBox.Show("Chưa nhập tên!");
                return false;
            }
            if (dc == "")
            {
                MessageBox.Show("Chưa nhập địa chỉ!");
                return false;
            }
            if (sdt == "")
            {
                MessageBox.Show("Chưa nhập số điện thoại!");
                return false;
            }
            if (namsinh == "")
            {
                MessageBox.Show("Chưa nhập năm sinh!");
                return false;
            }
            if (tentk == "")
            {
                MessageBox.Show("Chưa nhập tên tài khoản!");
                return false;
            }
            if (mk == "")
            {
                MessageBox.Show("Chưa nhập mật khẩu!");
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
        public bool Isvalid_TKMK(string tk, string mk)
        {
            string sql = "select * from tbNhanSu where TenTaiKhoan=@ttk and MatKhau =@mk";
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@ttk",tk),
            new SqlParameter("@mk",mk)
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
        public  void CreateNS(string mans, string tenns, string dc, string sdt, string namsinh,string tentk, string mk, string quyen)
        {
            if (check(mans,tenns,dc,sdt,namsinh, tentk, mk, quyen))
            {
                string sql = "INSERT INTO tbNhanSu(MaNS,Ten,SDT,DiaChi,NamSinh,TenTaiKhoan, MatKhau, Quyen) VALUES(@mans,@ten,@sdt,@dc,@ns, @tentk, @mk, @quyen)";
                SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("mans", mans),
                new SqlParameter("ten", tenns),
                new SqlParameter("sdt", sdt),
                new SqlParameter("dc", dc),
                new SqlParameter("ns", namsinh),
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
        public string GetQuyen(string tk, string mk)
        {
            DataTable dataTable = new DataTable();
            string quyen = string.Empty;
            string sql = "SELECT Quyen FROM tbNhanSu WHERE TenTaiKhoan = @tk AND MatKhau = @mk";

            SqlParameter[] parameters = new SqlParameter[] {
            new SqlParameter("@tk", tk),
            new SqlParameter("@mk", mk),
            };

    
            dataTable = kn.ReadData(sql, parameters);

        
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                quyen = row["Quyen"].ToString(); 
            }

            return quyen; 
        }
        public DataTable GetProfile(string mans)
        {
            string sql = "select TenTaiKhoan, Ten, DiaChi, SDT, NamSinh from tbNhanSu where MaNs=@ma";
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@ma",mans)
            };
            return kn.ReadData(sql, sp);
        }
    }
}
