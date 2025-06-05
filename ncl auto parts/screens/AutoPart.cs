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
    public partial class AutoPart : Form
    {
        string id = null;
        float sum = 0;
        float realTotal = 0;
        string somme = null;
        AutoPartM autoPart = null;
        string receiptNumber = null;
        public List<(string service, float montant)> donnees;
        public AutoPart()
        {
            InitializeComponent();
            AutoPartC.showFacture(table);
            init_values();
            main.closeConn();
        }
        private async void init_values()
        {
            try
            {
                float total = await AutoPartC.getSumPrice() + await AutoPartC.getPay() - (await AutoPartC.getAvance() + await AutoPartC.getDiscount());
                theSum.Text = "$" + total.ToString();
            }
            catch
            {

            }

        }
        private async void facture_Click(object sender, EventArgs e)
        {
            main.closeConn();
            float i=0;
            int j = 0;
            bool isAnumber = float.TryParse(montant.Text, out i);
            if (description.Text == "")
            {
                MessageBox.Show("Le champ Description ne dois pas etre vide");
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
                                if (vehicule.Text == "")
                                {
                                    MessageBox.Show("Le champ 'Nom du véhicule' ne dois pas etre vide");
                                }
                                else
                                {
                                    if(plaque.Text == "")
                                    {
                                        MessageBox.Show("Le champ 'Plaque' ne dois pas etre vide");
                                    }
                                    else
                                    {
                                        
                                            if (service.Text == "")
                                            {
                                                MessageBox.Show("Le champ 'Service' ne dois pas etre vide");
                                            }
                                            else
                                            {

                                            isAnumber = float.TryParse(discount.Text, out i);
                                            if (isAnumber)
                                            {
                                                isAnumber = float.TryParse(Avance.Text, out i);
                                                if (isAnumber)
                                                {
                                                    if (payment.Text == "Cash" || payment.Text == "Virement" || payment.Text == "Cheque" || payment.Text == "Mon Cash" || payment.Text == "Nat Cash")
                                                    {
                                                        if (statut.Text == "paye" || statut.Text == "non paye" || statut.Text == "avance")
                                                        {
                                                                isAnumber = float.TryParse(mainPay.Text, out i);
                                                                if (isAnumber)
                                                                {
                                                            int k = 0;
                                                                isAnumber = int.TryParse(quantite.Text, out k);
                                                                if (isAnumber)
                                                                {
                                                                    AutoPartM facture = new AutoPartM(clientName.Text, service.Text, devise.Text, plaque.Text, vehicule.Text, phone.Text, description.Text, int.Parse(quantite.Text), float.Parse(montant.Text), 1);
                                                                    int rep = await AutoPartC.saveFacture(facture, table, float.Parse(discount.Text), float.Parse(Avance.Text), statut.Text, payment.Text, comment.Text, idAuto.Text, float.Parse(mainPay.Text));
                                                                    main.closeConn();
                                                                    float total = await AutoPartC.getSumPrice() + await AutoPartC.getPay() - (await AutoPartC.getAvance() + await AutoPartC.getDiscount());
                                                                    theSum.Text = "$" + total.ToString();
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
                                                                else
                                                                {
                                                                MessageBox.Show("Le champ quantité doit contenir que des chiffres");
                                                                }
                                                               

                                                        }
                                                            else
                                                            {
                                                                MessageBox.Show("Le champ Main d'oeuvre doit contenir que des chiffres");
                                                            }

                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Veuillez Choisir le statut du paiement");
                                                        }

                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Veuillez choisir une methode de paiement");
                                                    }

                                                }
                                                else
                                                {
                                                    MessageBox.Show("Le champ Avance doit contenir que des chiffres");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Le champ Discount doit contenir que des chiffres");
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

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            main.showLogin(new FactureAuto());
        }

        private async void delete_Click(object sender, EventArgs e)
        {
            init_values();
            delete.Visible = false;
            int rep = await AutoPartC.deleteFacture(table, id);
            main.closeConn();

        }
        private void clearField()
        {
            montant.Text = "";
            description.Text = "";
            
            quantite.Text = "";
        }
        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = table.CurrentRow.Cells["id_"].Value.ToString();
            delete.Visible = true;
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            init_values();
            AutoPartC.cleanFacture(table);
            main.closeConn();
        }

        private async void bunifuButton1_Click(object sender, EventArgs e)
        {
            realTotal = 0;
            Random random = new Random();
            donnees = new List<(string, float)>();
            int randomNumber = random.Next(9999999);
            try
            {
                int maxId = await AutoPartC.getMaxId();
                receiptNumber = "NCL" + randomNumber.ToString() + maxId.ToString();

                bool receiptExist = await AutoPartC.ifReceiptIdExist(receiptNumber);
                while (receiptExist)
                {
                    int ii = 0;
                    randomNumber = random.Next(9999999);
                    receiptNumber = "NCL" + randomNumber.ToString() + VenteC.getMaxId().ToString();
                    receiptExist = await AutoPartC.ifReceiptIdExist(receiptNumber);
                    ii += 1;
                    if (ii >= 20)
                    {
                        receiptNumber = "IOk" + randomNumber.ToString() + VenteC.getMaxId().ToString();
                        receiptExist = await AutoPartC.ifReceiptIdExist(receiptNumber);
                    }
                }
            }
            catch
            {

            }

            MySqlDataReader result = await AutoPartC.getFacture();
            string myDevise = null;
            float total = await AutoPartC.getSumPrice() + await AutoPartC.getPay() - (await AutoPartC.getAvance() + await AutoPartC.getDiscount());
            int rep = -1;
            while (result.Read())
            {
                myDevise = result["devise"].ToString();
                autoPart = new AutoPartM(result["clientName"].ToString(), result["service"].ToString(), result["devise"].ToString(), result["plaque"].ToString(), result["car_name"].ToString(), result["phone"].ToString(), result["description"].ToString(), int.Parse(result["quantite"].ToString()), float.Parse(result["montant"].ToString()), total);
                rep = await AutoPartC.saveGoodFacture(autoPart, receiptNumber, table, float.Parse(result["discount"].ToString()), float.Parse(result["avance"].ToString()), result["comment"].ToString(), result["statut"].ToString(), result["payment"].ToString(), result["id_auto"].ToString(), float.Parse(result["pay"].ToString()));


            }
            //-----------------------------
            rep = await dbConfig.execute_command("update facture_auto set total=" + total + " where no_recu='" + receiptNumber + "'");
            main.closeConn();
            if (myDevise == "US")
            {
                VenteC.AddUsMoney(total);
            }
            else
            {
                VenteC.AddHtgMoney(total);
            }
            main.closeConn();

            if (rep == 0)
            {
              
                
                AutoPartC.cleanFacture(table);
                theSum.Text = "$0";
                MessageBox.Show("Facture effectuée avec succès");
                main.showLogin(new oneFacture(receiptNumber,"auto"));
                main.closeConn();

            }
            else
            {
                MessageBox.Show("Erreur lors de la facturation");
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
            e.Graphics.DrawString("Nom du client : " + autoPart.ClientName, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 210));
            e.Graphics.DrawString("No recu : " + receiptNumber, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 230));
            
            string date;
            receiptNumber = "";
            date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            e.Graphics.DrawString("Date : " + date, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 250));
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

            e.Graphics.DrawString("$"+realTotal.ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(605, y + 50));

            //-
            //e.Graphics.DrawString("PS:\"Ce proforma est valide pour une durée de 8 jours\" :", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(85, 1020));
            e.Graphics.DrawString("Merci d'avoir choisi NC.L Autoservices!!!", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(485, 1070));
        }

        private void AutoPart_Load(object sender, EventArgs e)
        {

        }

        private void table_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            id = table.CurrentRow.Cells["id_"].Value.ToString();
            delete.Visible = true;
        }

        private void table_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            id = table.CurrentRow.Cells["id_"].Value.ToString();
            delete.Visible = true;
        }
    }
}
