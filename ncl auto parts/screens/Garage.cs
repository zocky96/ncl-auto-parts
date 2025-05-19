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
    public partial class Garage : Form
    {
        string id = "";
        float sum = 0;
        float realTotal = 0;
        string somme = null;
        AutoPartM autoPart = null;
        string receiptNumber = null;
        public List<(string service, float montant)> donnees;
        public Garage()
        {
            InitializeComponent();
            GarageC.showFacture(table);
            main.closeConn();
        }
        private void clearField()
        {
            montant.Text = "";
            service.Text = "";
        }
        private async void facture_Click(object sender, EventArgs e)
        {
            main.closeConn();
            float i = 0;
            
            bool isAnumber = float.TryParse(montant.Text, out i);
            if (service.Text == "")
            {
                MessageBox.Show("Le champ service ne dois pas etre vide");
            }
            else
            {
                if (clientName.Text == "")
                {
                    MessageBox.Show("Le champ 'Nom du client' ne dois pas etre vide");
                }
                else
                {
                    if (devise.Text == "US" || devise.Text == "HTG")
                    {
                            if (isAnumber)
                            {
                                if (plaque.Text == "")
                                {
                                    MessageBox.Show("Le champ 'Plaque' ne dois pas etre vide");
                                }
                                else
                                {
                                    if (phone.Text == "")
                                    {
                                        MessageBox.Show("Le champ 'Telephone' ne dois pas etre vide");
                                    }
                                    else
                                    {
                                        if (description.Text == "") 
                                        {
                                            MessageBox.Show("Le champ 'Description' ne dois pas etre vide");
                                        }
                                        else 
                                        {
                                            isAnumber = float.TryParse(quantite.Text, out i);
                                            if (isAnumber)
                                            {
                                                if (vehicule.Text == "")
                                                {
                                                    MessageBox.Show("Le champ 'Nom du véhicule' ne dois pas etre vide");
                                                }
                                                else
                                                {
                                                    AutoPartM facture = new AutoPartM(clientName.Text, service.Text, devise.Text, plaque.Text, vehicule.Text, phone.Text, description.Text, int.Parse(quantite.Text), float.Parse(montant.Text), int.Parse(quantite.Text) * float.Parse(montant.Text));
                                                    int rep = await GarageC.saveFacture(facture, table);
                                                    if (rep == 0)
                                                    {
                                                        clearField();
                                                        //MessageBox.Show("Factué avec succè");
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Erreur lors de la facturation");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Le champ 'Quantite' dois avoir que des chiffres");
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("le champ montant dois contenir que des chiffres");
                            }
                        
                        


                    }
                    else
                    {
                        MessageBox.Show("Choisi une devise");
                    }
                }
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            main.closeConn();
            GarageC.cleanFacture(table);
        }

        private async void delete_Click(object sender, EventArgs e)
        {
            main.closeConn();
            delete.Visible = false;
            int rep = await GarageC.deleteFacture(table, id);
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = table.CurrentRow.Cells["id_"].Value.ToString();
            delete.Visible = true;
        }

        private async void bunifuButton1_Click(object sender, EventArgs e)
        {
            
            Random random = new Random();
            donnees = new List<(string, float)>();
            int randomNumber = random.Next(9999999);
            try
            {
                int maxId = await VenteC.getMaxId();
                receiptNumber = "IOE" + randomNumber.ToString() + maxId.ToString();

                bool receiptExist = await VenteC.ifReceiptIdExist(receiptNumber);
                while (receiptExist)
                {
                    int ii = 0;
                    randomNumber = random.Next(9999999);
                    receiptNumber = "IOE" + randomNumber.ToString() + VenteC.getMaxId().ToString();
                    receiptExist = await VenteC.ifReceiptIdExist(receiptNumber);
                    ii += 1;
                    if (ii >= 20)
                    {
                        receiptNumber = "IOk" + randomNumber.ToString() + VenteC.getMaxId().ToString();
                        receiptExist = await VenteC.ifReceiptIdExist(receiptNumber);
                    }
                }
            }
            catch
            {

            }

            MySqlDataReader result = await GarageC.getFacture();
            int rep = -1;
            while (result.Read())
            {

                if (result["devise"].ToString() == "US")
                {
                    autoPart = new AutoPartM(result["clientName"].ToString(), result["service"].ToString(), result["devise"].ToString(), result["plaque"].ToString(), result["car_name"].ToString(), result["phone"].ToString(), result["description"].ToString(), int.Parse(result["quantite"].ToString()),float.Parse(result["montant"].ToString()),float.Parse(result["total"].ToString()));
                    rep = await GarageC.saveGoodFacture(autoPart, receiptNumber, table);
                    VenteC.AddUsMoneyGarage(float.Parse(result["montant"].ToString()));

                }
                else
                {
                    autoPart = new AutoPartM(result["clientName"].ToString(), result["service"].ToString(), result["devise"].ToString(), result["plaque"].ToString(), result["car_name"].ToString(), result["phone"].ToString(), result["description"].ToString(), int.Parse(result["quantite"].ToString()), float.Parse(result["montant"].ToString()), float.Parse(result["total"].ToString()));
                    rep = await GarageC.saveGoodFacture(autoPart, receiptNumber, table);
                    VenteC.AddHTGMoneyGarage(float.Parse(result["montant"].ToString()));
                }

            }
            if (rep == 0)
            {
                
                GarageC.cleanFacture(table);
                MessageBox.Show("Facture effectuée avec succès");
                //MessageBox.Show(receiptNumber);
                main.showLogin(new oneFacture(receiptNumber,"garage"));

            }
            else
            {
                MessageBox.Show("Erreur lors de la facturation");
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            main.showLogin(new FactureGarage());
        }

        private void Garage_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            realTotal = 0;
            Bitmap bmp = new Bitmap(logo.Width, logo.Height);
            logo.DrawToBitmap(bmp, new Rectangle(0, 0, logo.Width, logo.Height));
            e.Graphics.DrawImage(bmp, new Point(60, 60));
            e.Graphics.DrawString("NC.L AUTO SERVICE", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(300, 60));
            e.Graphics.DrawString("Quartier Morin NORD,Haiti", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(335, 90));
            e.Graphics.DrawString("Tél:(509)36449128\\33650089", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(335, 110));
            e.Graphics.DrawString("info.nclautoservices@gmail.com", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(325, 130));
            //-
            e.Graphics.DrawString("Nom du client : " + autoPart.ClientName, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 210));
            e.Graphics.DrawString("No recu : " + receiptNumber, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 230));

            string date;
            receiptNumber = "";
            date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            e.Graphics.DrawString("Date : " + date, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 250));
            //-
            e.Graphics.DrawString("Garage ", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 270));
            e.Graphics.DrawString("Facture ", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 360));

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

        private void table_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            id = table.CurrentRow.Cells["id_"].Value.ToString();
            delete.Visible = true;
        }
    }
}
