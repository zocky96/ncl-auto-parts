using MySql.Data.MySqlClient;
using ncl_auto_parts.db;
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
    public partial class Rapport : Form
    {
        string id = "", ClientName = "", realDate = "";
        public List<(string clientName, string service, string devise, float montant, string no_recu, string date, string user)> donnees_facture_garage;
        public List<(string clientName, string service, string devise, float montant, string no_recu, string date, string user)> donnees_facture_auto;
        public List<(string nom_du_produit, float prix, int quantite, string date, string signature_autorise, string receiptNumber, string devise)> donneesVente;
        float realTotal = 0;
        public Rapport()
        {
            InitializeComponent();
        }

        private async void article_Click(object sender, EventArgs e)
        {
            realTotal = 0;
            if(sur.Text == "Vente" || sur.Text == "Facture Auto parts" || sur.Text == "Facture Garage")
            {
                if (sur.Text == "Vente")
                {
                    main.showLogin(new VenteViewer(de.Text,a.Text));
                    //donneesVente = new List<(string, float, int, string, string, string, string)>();
                    //MySqlDataReader resultax = await dbConfig.getResultCommand("select * from vente where date>='" + de.Text + "' and date<='" + a.Text + "'");
                    //while (resultax.Read())
                    //{
                    //    realTotal += float.Parse(resultax["prix"].ToString()) * int.Parse(resultax["quantite"].ToString());
                    //    donneesVente.Add((resultax["nom_du_produit"].ToString(), float.Parse(resultax["prix"].ToString()), int.Parse(resultax["quantite"].ToString()), resultax["date"].ToString(), resultax["signature_autorise"].ToString(), resultax["receiptNumber"].ToString(), resultax["devise"].ToString()));
                    //}
                }
                if (sur.Text == "Facture Auto parts")
                {
                    //List<(string clientName, string service, string devise, float montant, string no_recu, string date, string user)> donnees_facture_auto;
                    donnees_facture_auto = new List<(string, string, string, float, string, string, string)>();
                    MySqlDataReader resultax = await dbConfig.getResultCommand("select * from facture_auto where date>='" + de.Text + "' and date<='" + a.Text + "'");
                    while (resultax.Read())
                    {
                        realTotal += float.Parse(resultax["montant"].ToString());
                        donnees_facture_auto.Add((resultax["clientName"].ToString(), resultax["service"].ToString(), resultax["devise"].ToString(), float.Parse(resultax["montant"].ToString()), resultax["no_recu"].ToString(), resultax["date"].ToString(), resultax["user"].ToString()));
                    }
                }
                if (sur.Text == "Facture Garage")
                {
                    //List<(string clientName, string service, string devise, float montant, string no_recu, string date, string user)> donnees_facture_auto;
                    donnees_facture_garage = new List<(string, string, string, float, string, string, string)>();
                    MySqlDataReader resultax = await dbConfig.getResultCommand("select * from facture_garage where date>='" + de.Text + "' and date<='" + a.Text + "'");
                    while (resultax.Read())
                    {
                        realTotal += float.Parse(resultax["montant"].ToString());
                        donnees_facture_garage.Add((resultax["clientName"].ToString(), resultax["service"].ToString(), resultax["devise"].ToString(), float.Parse(resultax["montant"].ToString()), resultax["no_recu"].ToString(), resultax["date"].ToString(), resultax["user"].ToString()));
                    }
                }
                PrintDialog printDialog1 = new PrintDialog();
                printDialog1.Document = printDocument1;
                DialogResult resulta = printDialog1.ShowDialog();
                if (resulta == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
            else
            {
                MessageBox.Show("choisissez sur quel departement vous souhaitez lancer le raport");
            }

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
          
            //-
            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Black;
            Pen pen = Pens.Black;

            

            //----------------------------------------------------
            if (sur.Text == "Facture Auto parts")
            {
                int startX = 20;
                int startY = 300;
                int rowHeight = 25;

                int x = startX;
                int y = startY + rowHeight;
                string date_;
                int[] colWidths = { 150, 170, 60, 90, 80, 160, 80 };
                date_ = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
                e.Graphics.DrawString("Date : " + date_, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(80, 220));
                e.Graphics.DrawString("Rapport des Factures de l'auto parts", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(275, 250));
                string[] headers = { "Nom du client", "Service", "Devise", "Montant", "No recu", "Date", "Utilisateur" };
                // Dessiner l'en-tête avec bordures

                for (int i = 0; i < headers.Length; i++)
                {
                    Rectangle rect = new Rectangle(x, startY, colWidths[i], rowHeight);
                    e.Graphics.DrawRectangle(pen, rect);
                    e.Graphics.DrawString(headers[i], new Font("Arial", 10, FontStyle.Bold), brush, rect);
                    x += colWidths[i];
                }

                // Dessiner les données avec bordures

                foreach (var (clientName, service, devise, montant, no_recu, date, user) in donnees_facture_auto)
                {
                    x = startX;

                    string[] valeurs = {
            clientName,
            service,
            devise,
            montant.ToString(),
            no_recu,
            date,
            user
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
                e.Graphics.DrawString("TOTAL", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(20, y + 50));

                e.Graphics.DrawString("$" + realTotal.ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(635, y + 50));
            }
            //-----------------------------------------------------------------------
            if (sur.Text == "Facture Garage")
            {
                int startX = 20;
                int startY = 300;
                int rowHeight = 25;

                int x = startX;
                int y = startY + rowHeight;
                string date_;
                int[] colWidths = { 150, 170, 60, 90, 80, 160, 80 };
                date_ = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
                e.Graphics.DrawString("Date : " + date_, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(80, 220));
                e.Graphics.DrawString("Rapport des Factures du garage", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(275, 250));
                string[] headers = { "Nom du client", "Service", "Devise", "Montant", "No recu", "Date", "Utilisateur" };
                // Dessiner l'en-tête avec bordures

                for (int i = 0; i < headers.Length; i++)
                {
                    Rectangle rect = new Rectangle(x, startY, colWidths[i], rowHeight);
                    e.Graphics.DrawRectangle(pen, rect);
                    e.Graphics.DrawString(headers[i], new Font("Arial", 10, FontStyle.Bold), brush, rect);
                    x += colWidths[i];
                }

                // Dessiner les données avec bordures

                foreach (var (clientName, service, devise, montant, no_recu, date, user) in donnees_facture_garage)
                {
                    x = startX;

                    string[] valeurs = {
            clientName,
            service,
            devise,
            montant.ToString(),
            no_recu,
            date,
            user
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
                e.Graphics.DrawString("TOTAL", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(20, y + 50));

                e.Graphics.DrawString("$" + realTotal.ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(635, y + 50));
            }







        }

        private void Rapport_Load(object sender, EventArgs e)
        {

        }
    }
}
