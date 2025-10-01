using MySql.Data.MySqlClient;
using ncl_auto_parts.controller;
using ncl_auto_parts.db;
using ncl_auto_parts.model;
using ncl_auto_parts.rapport;
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
    public partial class FactureGarage : Form
    {
        string id = "", ClientName = "", realDate = "";
        public List<(string service, float montant)> donnees;
        float realTotal = 0;
        public FactureGarage()
        {
            InitializeComponent();
            GarageC.showGoodFacture(table);
            main.closeConn();
        }

        private void searchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (searchBar.Text == "")
                {

                }
                else
                {
                    GarageC.searchGoodFacture(table, searchBar.Text);
                }

            }
        }

        private async void facture_Click(object sender, EventArgs e)
        {
            realTotal = 0;
            pay.Visible = false;
            modify.Visible = false;
            main.closeConn();
            float my_sum = 0, avance = 0;
            String devise = null, status = null;
            
            if (id == "")
            {
                MessageBox.Show("Selectionne la facture a annulée");
            }
            else
            {
                MySqlDataReader result = await GarageC.getGoodFacture(id);

                string date;
                while (result.Read())
                {
                    date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
                    int rep = await dbConfig.execute_command("insert into cancel_facture_garage(clientName,service,devise,montant,no_recu,date,user,car_name,plaque,phone,description,quantite,total) values('" + result["clientName"].ToString() + "','" + result["service"].ToString() + "','" + result["devise"].ToString() + "'," + result["montant"].ToString() + ",'" + id + "','" + date + "','" + main.userName + "','" + result["car_name"].ToString() + "','" + result["plaque"].ToString() + "','" + result["phone"].ToString() + "','" + result["description"].ToString() + "'," + result["quantite"].ToString() + "," + result["total"].ToString() + ")");
                    devise = result["devise"].ToString();
                    //sum = float.Parse(result["total"].ToString());
                    my_sum = float.Parse(result["total"].ToString());
                    status = result["statut"].ToString();
                    avance = float.Parse(result["avance"].ToString());
                }
                if (status == "paye")
                {
                    if (devise == "US")
                    {
                        VenteC.RemoveUsMoneyGarage(my_sum);
                        main.closeConn();
                        GarageC.deleteGoodFacture(table, id);
                        main.closeConn();
                        GarageC.showGoodFacture(table);
                        main.closeConn();
                    }
                    else
                    {
                        VenteC.RemoveHtgMoneyGarage(my_sum);
                        main.closeConn();
                        GarageC.deleteGoodFacture(table, id);
                        main.closeConn();
                        GarageC.showGoodFacture(table);
                        main.closeConn();

                    }
                }
                else if (status == "avance")
                {
                    if (devise == "US")
                    {
                        VenteC.RemoveUsMoneyGarage(avance);
                        main.closeConn();
                        GarageC.deleteGoodFacture(table, id);
                        main.closeConn();
                        GarageC.showGoodFacture(table);
                        main.closeConn();
                    }
                    else
                    {
                        VenteC.RemoveHtgMoneyGarage(avance);
                        main.closeConn();
                        GarageC.deleteGoodFacture(table, id);
                        main.closeConn();
                        GarageC.showGoodFacture(table);
                        main.closeConn();

                    }
                }
                else
                {

                }
            }
        }

        private async void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            modify.Visible = true;
            id = table.CurrentRow.Cells["no"].Value.ToString();
            ClientName = table.CurrentRow.Cells["client"].Value.ToString();
            string statut = null, dette = null;
            try
            {
                MySqlDataReader result = await dbConfig.getResultCommand("select statut,dette from facture_garage where no_recu='"+id+"'");
                while (result.Read())
                {
                    statut = result["statut"].ToString();
                    if (result.IsDBNull(1))
                    {
                        dette = "nullos123";
                    }
                }
                if (dette == "nullos123")
                {
                    statut_.Visible = true;
                    change.Visible = true;
                }
                if (dette != "nullos123")
                {
                    statut_.Visible = false;
                    change.Visible = false;
                }
                if (statut == "avance" || statut == "non paye")
                {
                    pay.Visible = true;
                }
                else
                {
                    pay.Visible = false;
                }
            }
            catch
            {

            }
            print.Visible = true;
           
        }

        private async void print_Click(object sender, EventArgs e)
        {
            main.closeConn();
            print.Visible = false;
            modify.Visible = false;
            pay.Visible = false;
            
            main.showLogin(new oneFacture(id, "garage"));
        }

        private void FactureGarage_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter.Text != "Filtre")
            {
                GarageC.filterGoodFacture(table,filter.Text);
            }
            else if (filter.Text == "Filtre")
            {
                GarageC.showGoodFacture(table);
            }
            main.closeConn();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            print.Visible = false;
            modify.Visible = false;
            pay.Visible = false;

            main.showLogin(new PayDette(id,"garage"));
            GarageC.showGoodFacture(table);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void change_Click(object sender, EventArgs e)
        {
            if (statut_.Text == "paye" || statut_.Text == "non paye" || statut_.Text == "avance")
            {
                int rep = await dbConfig.execute_command("update facture_garage set statut='" + statut_.Text + "',dette=0 where no_recu='" + id + "'");
                GarageC.showGoodFacture(table);
                main.closeConn();
                modify.Visible = false;
                change.Visible = false;
                statut_.Visible = false;
            }
            else
            {
                MessageBox.Show("Veuillez Choisir le statut du paiement");
            }
        }

        private async void modify_Click(object sender, EventArgs e)
        {
            modify.Visible = false;
            MySqlDataReader result = await GarageC.getGoodFacture(id);
            GarageC.cleanFactureSimple();
            while (result.Read())
            {

                AutoPartM facture = new AutoPartM(result["clientName"].ToString(), result["service"].ToString(), result["devise"].ToString(), result["plaque"].ToString(), result["car_name"].ToString(), result["phone"].ToString(), result["description"].ToString(), int.Parse(result["quantite"].ToString()), float.Parse(result["montant"].ToString()), 1);
               
                int rep = await GarageC.saveFactureSimple(facture, float.Parse(result["discount"].ToString()), float.Parse(result["avance"].ToString()), result["statut"].ToString(), result["payment"].ToString(), result["comment"].ToString(), result["id_auto"].ToString(), float.Parse(result["pay"].ToString()), result["no_recu"].ToString(), float.Parse(result["total"].ToString()), float.Parse(result["avance"].ToString()), float.Parse(result["dette"].ToString()));
            }
            main.closeConn();
            Dispose();
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(logo.Width, logo.Height);
            logo.DrawToBitmap(bmp, new Rectangle(0, 0, logo.Width, logo.Height));
            e.Graphics.DrawImage(bmp, new Point(60, 60));
            e.Graphics.DrawString("NC.L AUTO SERVICE", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(300, 60));
            e.Graphics.DrawString("Quartier Morin NORD,Haiti", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(335, 90));
            e.Graphics.DrawString("Tél:(509)36449128\\33650089", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(335, 110));
            e.Graphics.DrawString("info.nclautoservices@gmail.com", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(325, 130));
            //-
            e.Graphics.DrawString("Nom du client : " + ClientName, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 210));
            e.Graphics.DrawString("No recu : " + id, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 230));

            string date;
            id = "";
            date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            e.Graphics.DrawString("Date : " + realDate, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 250));
            //-

            e.Graphics.DrawString("Facture", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 360));

            //-
            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Black;
            Pen pen = Pens.Black;

            int startX = 85;
            int startY = 460;
            int rowHeight = 25;
            int[] colWidths = { 340, 290 }; // name, quantite, quantity, price, tax, total

            string[] headers = { "Service", "Montant" };

            // Dessiner l'en-tête avec bordures
            int x = startX;
            for (int i = 0; i < headers.Length; i++)
            {
                Rectangle rect = new Rectangle(x, startY, colWidths[i], rowHeight);
                e.Graphics.DrawRectangle(pen, rect);
                e.Graphics.DrawString(headers[i], new Font("Arial", 12, FontStyle.Bold), brush, rect);
                x += colWidths[i];
            }

            // Dessiner les données avec bordures
            int y = startY + rowHeight;
            foreach (var (service, montant) in donnees)
            {
                x = startX;

                string[] valeurs = {
            service,
            montant.ToString(),

        };

                for (int i = 0; i < valeurs.Length; i++)
                {
                    Rectangle rect = new Rectangle(x, y, colWidths[i], rowHeight);
                    e.Graphics.DrawRectangle(pen, rect);
                    e.Graphics.DrawString(valeurs[i], font, brush, rect);
                    x += colWidths[i];
                }

                y += rowHeight;
            }
            e.Graphics.DrawString("TOTAL", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(85, y + 50));

            e.Graphics.DrawString("$" + realTotal.ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(605, y + 50));

            //-
            //e.Graphics.DrawString("PS:\"Ce proforma est valide pour une durée de 8 jours\" :", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(85, 1020));
            e.Graphics.DrawString("Merci d'avoir choisi NC.L Autoservices!!!", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(485, 1070));
        }
    }
}
