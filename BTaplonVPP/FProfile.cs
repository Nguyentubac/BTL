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
    public partial class FProfile : Form
    {
        public FProfile()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FAdminXacNhan fAdminXacNhan = new FAdminXacNhan();
            fAdminXacNhan.Show();
        }
    }
}
