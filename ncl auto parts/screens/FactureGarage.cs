using MySql.Data.MySqlClient;
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
            main.closeConn();
            float sum = 0;
            String devise = null;
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
                    dbConfig.execute_command("insert into cancel_facture_garage(clientName,service,devise,montant,no_recu,date,user) values('" + result["clientName"].ToString() + "','" + result["service"].ToString() + "','" + result["devise"].ToString() + "'," + result["montant"].ToString() + ",'" + id + "','" + date + "','" + main.userName + "')");
                    devise = result["devise"].ToString();
                    sum += float.Parse(result["montant"].ToString());
                }
                if (devise == "US")
                {
                    
                    VenteC.RemoveUsMoneyGarage(sum);
                    GarageC.deleteGoodFacture(table, id);
                    id = "";
                    GarageC.showGoodFacture(table);
                    MessageBox.Show("Facture annulée avec succès");
                }
                else
                {
                    
                    VenteC.RemoveHtgMoneyGarage(sum);
                    GarageC.deleteGoodFacture(table, id);
                    id = "";
                    GarageC.showGoodFacture(table);
                    MessageBox.Show("Facture annulée avec succès");
                }
            }
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = table.CurrentRow.Cells["no"].Value.ToString();
            ClientName = table.CurrentRow.Cells["client"].Value.ToString();
            print.Visible = true;
        }

        private async void print_Click(object sender, EventArgs e)
        {
            main.closeConn();
            print.Visible = false;
            donnees = new List<(string, float)>();
            MySqlDataReader resulta = await dbConfig.getResultCommand("select service,montant,date from facture_garage where no_recu='" + id + "'");
            while (resulta.Read())
            {
                realTotal += float.Parse(resulta["montant"].ToString());
                realDate = resulta["date"].ToString();
                //MessageBox.Show(resulta["service"].ToString());
                donnees.Add((resulta["service"].ToString(), float.Parse(resulta["montant"].ToString())));
            }

            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = printDocument1;
            DialogResult resultx = printDialog1.ShowDialog();
            if (resultx == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void FactureGarage_Load(object sender, EventArgs e)
        {

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
