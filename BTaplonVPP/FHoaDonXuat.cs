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
    public partial class FHoaDonXuat : Form
    {
        public FHoaDonXuat()
        {
            InitializeComponent();
        }
        HoaDonBan HDB = new HoaDonBan();
        private void grv_dssp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Close();
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
                    dataGridView2.DataSource = HDB.GetCTHD(ma);
                }
                else
                {
                    dataGridView2.DataSource = HDB.GetCTHD(ma);
                }

            }
        }

        private void FHoaDonXuat_Load(object sender, EventArgs e)
        {
            grv_dssp.DataSource = HDB.GetAllHDB();
        }
    }
}
