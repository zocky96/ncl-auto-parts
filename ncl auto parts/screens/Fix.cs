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
    public partial class Fix : Form
    {
        public Fix()
        {
            InitializeComponent();
        }

        private async void bunifuButton1_Click(object sender, EventArgs e)
        {
            main.closeConn();
            if (userName.Text == "")
            {
                MessageBox.Show("Le champ username est vide");
            }
            else
            {
                int rep = await UserC.fixLogin(userName.Text);

                if (rep == 1)
                {
                    MessageBox.Show("Login fixed");
                }
                else
                {
                    MessageBox.Show("Ce nom d'utilisateur n'existe pas !");
                }


            }
        }

        private void Fix_Load(object sender, EventArgs e)
        {
            userName.Select();
        }

        private async void userName_KeyDown(object sender, KeyEventArgs e)
        {
            //la
            if (e.KeyCode == Keys.Enter)
            {
                main.closeConn();
                if (userName.Text == "")
                {
                    MessageBox.Show("Le champ username est vide");
                }
                else
                {
                    int rep = await UserC.fixLogin(userName.Text);

                    if (rep == 1)
                    {
                        MessageBox.Show("Login fixed");
                    }
                    else
                    {
                        MessageBox.Show("Ce nom d'utilisateur n'existe pas !");
                    }


                }
            }
            
        }
    }
}
