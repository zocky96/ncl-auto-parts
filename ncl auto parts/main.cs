using Bunifu.Framework.UI;
using Bunifu.UI.WinForms.BunifuButton;
using MySql.Data.MySqlClient;
using ncl_auto_parts.controller;
using ncl_auto_parts.db;
using ncl_auto_parts.screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ncl_auto_parts
{
    public partial class main : Form
    {
        public static List<MySqlConnection> listConn = new List<MySqlConnection>();
        public static string userName = null;
        public static string poste = "";
        public static string the_name = "";
        //-----------------------
        public static String currentPage="home";
        public static string ex = "";
        public static Control exButton;
        private BunifuFlatButton boutonActif = null;
        private BunifuButton boutonActif2 = null;
        public static BunifuCustomLabel log_in,log_out;
        public static BunifuButton article_,vente_,fournisseur_,cart_,employe_,user_,payroll_,autoPart_,facturation_,client_,reparation_,garage_,settings_;
        public  main()
        {
            int rep = 000;
            dbConfig.createDataBase();
            dbConfig.createTables() ;


            //MessageBox.Show(spaceInBill("Bon",10));
            if (rep == 9)
            {
                Dispose();
            }
            else
            {
                InitializeComponent();
                //showScreen(new Dashboard());
                //showScreen(new Reparation());
                //showLogin(new ReparationC());

                article_ = article;
                vente_ = vente;
                fournisseur_ = fournisseur;
                cart_ = cart;
                employe_ = employe;
                user_ = user;
                payroll_ = payroll;
                autoPart_ = autoPart;
                //facturation_ = facturation;
                client_ = client;
                reparation_ = reparation;
                garage_ = garage;
                settings_ = settings;
                log_in = login;
                log_out = logout;
                disableButton();
                //moveSelectedItem2(payroll);
                //showScreen(new Payroll());

            }
        }
        private void disableButton()
        {
            article.Enabled = false;
            vente.Enabled = false;
            fournisseur.Enabled = false;
            cart.Enabled = false;
            employe.Enabled = false;
            user.Enabled = false;
            payroll.Enabled = false;
            autoPart.Enabled = false;
            //facturation.Enabled = false;
            client.Enabled = false;
            reparation.Enabled = false;
            garage.Enabled = false;
            settings.Enabled = false;

        }
       
        private void moveSelectedItem2(BunifuButton nouveauBouton)
        {
            if (boutonActif2 != null && boutonActif2 != nouveauBouton)
            {
                boutonActif2.Enabled = true;
                //boutonActif2.selected = false;
                //boutonActif.BackColor = Color.FromArgb(30, 30, 30); // Couleur normale
            }

            // Désactiver le bouton actuel et le marquer actif
            boutonActif2 = nouveauBouton;
            boutonActif2.Enabled = false;
            //boutonActif2.selected = true;
        }
       

        private void showScreen(object Form)
        {


            if (this.body.Controls.Count > 0)
            {
                this.body.Controls.RemoveAt(0);
                this.body.Controls.Clear();

            }
            //Panel container2 = new Panel();
            //listPanel.Add(container2);
            //container2.Dock = DockStyle.Fill;
            //---------------------------
            Form form = Form as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.body.Controls.Add(form);
            //container2.Controls.Add(form);
            //instance.Controls.Add(container2);
            //exform = form;
            form.Show();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }
        public static void closeConn()
        {
            for (int i = 0; i < listConn.Count - 1; i++)
            {
                try
                {
                    listConn[i].Close();
                }
                catch
                {

                }
            }
        }
        public static void showLogin(object Form)
        {

            Form form = Form as Form;
            form.TopMost = true;

            //form.Dock = DockStyle.Fill;
            //this.container.Controls.Add(form);
            form.ShowDialog();

        }
        private void body_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if(sidebar.Width == 229)
            {
                sidebar.Width = 84;
                auto.Font = new Font("Century Gothic",10);
                //garage.Font = new Font("Century Gothic", 10);
                //lEnployer.Font = new Font("Century Gothic", 10);
                //lComtabilite.Text = "Compta...";
                //Ladmin.Text = "Admins...";
                //Ladmin.Font = new Font("Century Gothic", 10);
                //lComtabilite.Font = new Font("Century Gothic", 10);
            }
            else
            {
                sidebar.Width = 229;
                auto.Font = new Font("Century Gothic", 14);
                //garage.Font = new Font("Century Gothic", 14);
                //lEnployer.Font = new Font("Century Gothic", 14);
                //Ladmin.Font = new Font("Century Gothic", 14);
                //lComtabilite.Text = "Comptabilité";
                //Ladmin.Text = "Adminstration";
                //lComtabilite.Font = new Font("Century Gothic", 12);


            }
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void home_Click(object sender, EventArgs e)
        {
         
            showScreen(new Article());
        }

        private void btn_vente_Click(object sender, EventArgs e)
        {
            
            showScreen(new vente());
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            showScreen(new Reparation());
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            showScreen(new Client());
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            showScreen(new Employer());
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            showScreen(new User());
        }
        public static string spaceInBill(string product, int nbrSpace)
        {
            if (product.Length >= nbrSpace)
            {
                return null;
            }
            int len = nbrSpace - product.Length;
            string spance = null;
            for (int i = 0; i <= (len - 1); i++)
            {
                spance += " ";
            }
            return spance;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            showScreen(new Employer());
        }

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            showScreen(new User());
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
          
            showScreen(new Fournisseur());
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            
            showScreen(new Cart());
        }

        private void bunifuFlatButton4_Click_1(object sender, EventArgs e)
        {
           
            showScreen(new Client());
        }

        private void bunifuFlatButton6_Click_1(object sender, EventArgs e)
        {
            
            showScreen(new Reparation());
        }

        private void bunifuFlatButton7_Click_1(object sender, EventArgs e)
        {
            showScreen(new Facturation());
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {
            showLogin(new Login());
        }

        private void garage_Click(object sender, EventArgs e)
        {

        }

        private void b_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            showScreen(new Payroll());
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            showScreen(new AutoPart());
        }

        private void logout_Click(object sender, EventArgs e)
        {
            UserC.Disconnected(userName);
            logout.Visible = false;
            login.Visible = true;
            showScreen(new Dashboard());
            disableButton();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
               UserC.Disconnected(userName);
                logout.Visible = false;
                login.Visible = true;
                disableButton();
           
        }
        
        private void main_Load(object sender, EventArgs e)
        {
           
        }

        private void garage_Click_1(object sender, EventArgs e)
        {
            moveSelectedItem2(garage);
            showScreen(new Garage());
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            moveSelectedItem2(article);
            showScreen(new Article());
        }

        private void bunifuButton12_Click(object sender, EventArgs e)
        {
            moveSelectedItem2(settings);
            showScreen(new Settings());
        }

        private void vente_Click(object sender, EventArgs e)
        {
            moveSelectedItem2(vente);
            showScreen(new vente());
        }

        private void cart_Click(object sender, EventArgs e)
        {
            moveSelectedItem2(cart);
            showScreen(new Cart());
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            moveSelectedItem2(fournisseur);
            showScreen(new Fournisseur());
        }

        private void client_Click(object sender, EventArgs e)
        {
            moveSelectedItem2(client);
            showScreen(new Client());
        }

        private void reparation_Click(object sender, EventArgs e)
        {
            moveSelectedItem2(reparation);
            showScreen(new Reparation());
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {

        }

        private void employe_Click(object sender, EventArgs e)
        {
            moveSelectedItem2(employe);
            showScreen(new Employer());
        }

        private void user_Click(object sender, EventArgs e)
        {
            moveSelectedItem2(user);
            showScreen(new User());
        }

        private void autoPart_Click(object sender, EventArgs e)
        {
            moveSelectedItem2(autoPart);
            showScreen(new AutoPart());
        }

        private void payroll_Click(object sender, EventArgs e)
        {
            moveSelectedItem2(payroll);
            showScreen(new Payroll());
        }
    }
}
