﻿using System;
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
    public partial class FSignUp : Form
    {   
        NhanSu ns = new NhanSu();
        public FSignUp()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Có thật không?", "Muốn thoát?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Close();
            }
           
        }

        
        private void button2_Click(object sender, EventArgs e)
        {   
            if (ns.Isvalid_NS(txtMaNs.Text))
                    {
                        MessageBox.Show("Đã Tồn Tại mã Nhân sự");
                    }else if(ns.Isvalid_TKMK(txt_tentk.Text, txt_mk.Text))
                        {
                            MessageBox.Show("Tài khoản đã tồn tại", "Thông báo");
                        }
                    else if (MessageBox.Show("Bạn phải xác nhận quyền admin", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (txt_mk.Text == txt_nlmk.Text)
                        {
                            FAdminXacNhan fa = new FAdminXacNhan(txtMaNs.Text,txttns.Text,txtsdt.Text,txtdc.Text,dateTimePicker1.Value, txt_tentk.Text, txt_mk.Text, comboBox1.Text);
                            fa.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("mật khẩu không khớp");
                        }
                    }
                }
                
            
                
            
        }


    }

