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
    public partial class FManager : Form
    {
        public FManager()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void chiTiếtThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void khoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FManager_Load(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FProfile fProfile = new FProfile();
            fProfile.ShowDialog();
        }

        private void thôngTinNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FNhaCungCap fNhaCungCap = new FNhaCungCap();
            fNhaCungCap.ShowDialog();
        }

        private void thôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FKhachHang fKhachHang = new FKhachHang();
            fKhachHang.ShowDialog();
        }
    }
}
