using MySql.Data.MySqlClient;
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
            }
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
                garage.Font = new Font("Century Gothic", 10);
                lEnployer.Font = new Font("Century Gothic", 10);
                lComtabilite.Text = "Compta...";
                lComtabilite.Font = new Font("Century Gothic", 10);
            }
            else
            {
                sidebar.Width = 229;
                auto.Font = new Font("Century Gothic", 14);
                garage.Font = new Font("Century Gothic", 14);
                lEnployer.Font = new Font("Century Gothic", 14);
                
                lComtabilite.Text = "Comptabilité";
                lComtabilite.Font = new Font("Century Gothic", 12);


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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
