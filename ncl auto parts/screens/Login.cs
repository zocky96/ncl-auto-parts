using ncl_auto_parts.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ncl_auto_parts.screens
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            userName.Focus();
            
        }

        private async void signin_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            main.showLogin(new Fix());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void signin_Click_1(object sender, EventArgs e)
        {
            int rep = await UserC.login(userName.Text, password.Text);
            if (rep == 0)
            {
                Dispose();
            }
        }

        private void userName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
