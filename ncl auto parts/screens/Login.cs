using ncl_auto_parts.controller;
using ncl_auto_parts.db;
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
            //userName.Focus();
            repaireTable();
            
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
            main.closeConn();
            int rep = await UserC.login(userName.Text, password.Text);
            main.closeConn();
            if (rep == 0)
            {
                Dashboard.label.Text = userName.Text;
                Dispose();
            }
        }

        private void userName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private async void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int rep = await UserC.login(userName.Text, password.Text);
                if (rep == 0)
                {
                    Dispose();
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                userName.Focus();
            }

        }

        private void userName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                password.Focus();
            }
           
        }
        private async void repaireTable()
        {
            List<string> list = new List<string>
            {
                "account_htg",
                "account_htg_garage",
                "account_us",
                "account_us_garage",
                "ajout",
                "ajout_garage",
                "article" ,
                "cancel_facture_garage" ,
                "canceled_facture_auto" ,
                "canceledvente" ,
                "client" ,
                "depenses" ,
                "depenses_garage" ,
                "employer" ,
                "employer_suprimer", 
                "facture_auto" ,
                "facture_garage" ,
                "fauto_part" ,
                "fgarage" ,
                "fournisseur",
                "log" ,
                "new_payroll" ,
                "paiement",
                "panier",
                "proforma",
                "reparation",
                "services",
                "utilisateur",
                "vente",
            };
            for(int i = 0;i < list.Count; i++)
            {
                int rep = await dbConfig.execute_command("repair table "+list[i]);
                main.closeConn();
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            userName.Select();
            //this.ActiveControl = userName;
           // userName.Focus();
        }
    }
}
