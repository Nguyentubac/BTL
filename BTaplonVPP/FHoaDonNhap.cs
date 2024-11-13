using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTaplonVPP
{
    public partial class FHoaDonNhap : Form
    {
        HoaDonNhap HDN = new HoaDonNhap();
        public FHoaDonNhap()
        {
            InitializeComponent();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        
        private void FHoaDonNhap_Load(object sender, EventArgs e)
        {
            grv_dssp.DataSource = HDN.GetAllHDN();
        }

        private void grv_dssp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                string ma;
                DataGridViewRow r = new DataGridViewRow();
                r = grv_dssp.Rows[i];
                ma = r.Cells[0].Value.ToString().Trim();
                if (dataGridView2.DataSource != null)
                {
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = HDN.GetCTHD(ma);
                }
                else
                {
                    dataGridView2.DataSource = HDN.GetCTHD(ma);
                }
                
            }

        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
