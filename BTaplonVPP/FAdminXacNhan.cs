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
    public partial class FAdminXacNhan : Form
    {
        public FAdminXacNhan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Có thật không?", "Muốn thoát?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Close() ;
            }
        }
    }
}
