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
                float total = await AutoPartC.getSumPrice() + await AutoPartC.getPay() - (await AutoPartC.getDiscount());
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
                                                    
                                                        if (statut.Text == "paye" || statut.Text == "non paye" || statut.Text == "avance")
                                                        {
                                                                isAnumber = float.TryParse(mainPay.Text, out i);
                                                                if (isAnumber)
                                                                {
                                                            int k = 0;
                                                                isAnumber = int.TryParse(quantite.Text, out k);
                                                                if (isAnumber)
                                                                {
                                                                    bool isFactureEmpty = await AutoPartC.isFactureEmptyMain();
                                                                    if(isFactureEmpty){
                                                                        //MessageBox.Show("ok");
                                                                        AutoPartM facture = new AutoPartM(clientName.Text, service.Text, devise.Text, plaque.Text, vehicule.Text, phone.Text, description.Text, int.Parse(quantite.Text), float.Parse(montant.Text), 1);
                                                                        int rep = await AutoPartC.saveFacture(facture, table, float.Parse(discount.Text), float.Parse(Avance.Text), statut.Text, payment.Text, comment.Text, idAuto.Text, float.Parse(mainPay.Text));
                                                                        main.closeConn();
                                                                        float total = await AutoPartC.getSumPrice() + await AutoPartC.getPay() - (await AutoPartC.getDiscount());
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
                                                                        string good_devise = await AutoPartC.getDevise();
                                                                        if (good_devise != devise.Text) 
                                                                        {
                                                                            MessageBox.Show("La devise selectionnée est differente");
                                                                        }
                                                                        else
                                                                        {
                                                                            AutoPartM facture = new AutoPartM(clientName.Text, service.Text, devise.Text, plaque.Text, vehicule.Text, phone.Text, description.Text, int.Parse(quantite.Text), float.Parse(montant.Text), 1);
                                                                            int rep = await AutoPartC.saveFacture(facture, table, float.Parse(discount.Text), float.Parse(Avance.Text), statut.Text, payment.Text, comment.Text, idAuto.Text, float.Parse(mainPay.Text));
                                                                            main.closeConn();
                                                                            float total = await AutoPartC.getSumPrice() + await AutoPartC.getPay() - (await AutoPartC.getDiscount());
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
            init_values();
            AutoPartC.showFacture(table);
        }

        private async void delete_Click(object sender, EventArgs e)
        {
            delete.Visible = false;
            int rep = await AutoPartC.deleteFacture(table, id);
            init_values();
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
            
            AutoPartC.cleanFacture(table);
            init_values();
            main.closeConn();
        }

        private async void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuButton1.Enabled = false;
            realTotal = 0;
            Random random = new Random();
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
            string myDevise = null,realStatut = null;
            float total = (await AutoPartC.getSumPrice() + await AutoPartC.getPay()) - ( await AutoPartC.getDiscount());
           
            int rep = -1;
            float good_avance = 0;
            while (result.Read())
            {
                myDevise = result["devise"].ToString();
                realStatut = result["statut"].ToString();
                good_avance = float.Parse(result["avance"].ToString());
                autoPart = new AutoPartM(result["clientName"].ToString(), result["service"].ToString(), result["devise"].ToString(), result["plaque"].ToString(), result["car_name"].ToString(), result["phone"].ToString(), result["description"].ToString(), int.Parse(result["quantite"].ToString()), float.Parse(result["montant"].ToString()), total);
                rep = await AutoPartC.saveGoodFacture(autoPart, receiptNumber, table, float.Parse(result["discount"].ToString()), float.Parse(result["avance"].ToString()), result["comment"].ToString(), result["statut"].ToString(), result["payment"].ToString(), result["id_auto"].ToString(), float.Parse(result["pay"].ToString()));
            }
            
            //---------------
            if (realStatut == "paye")
            {
                await dbConfig.execute_command("update facture_auto set total=" + total + ",dette=0 where no_recu='" + receiptNumber + "'");
                if (myDevise == "US")
                {
                    VenteC.AddUsMoney(total);
                }
                else
                {
                    VenteC.AddHtgMoney(total);
                }
            }
            
            else if (realStatut == "avance" && good_avance > 0)
            {
                float aux = total - good_avance;
                if(good_avance == total)
                {
                    await dbConfig.execute_command("update facture_auto set total=" + total + ",dette=0,statut='paye' where no_recu='" + receiptNumber + "'");
                }
                else
                {
                    await dbConfig.execute_command("update facture_auto set total=" + total + ",dette =" + aux + " where no_recu='" + receiptNumber + "'");
                }
                
                if (myDevise == "US")
                {
                    VenteC.AddUsMoney(good_avance);
                }
                else
                {
                    VenteC.AddHtgMoney(good_avance);
                }
            }
            
            if (realStatut == "non paye" )
            {
                await dbConfig.execute_command("update facture_auto set total=" + total + " ,dette=" + total + " where no_recu='" + receiptNumber + "'");
            }
            //-----------------------------
           
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
            bunifuButton1.Enabled = true;
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

        private async void table_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            id = table.CurrentRow.Cells["id_"].Value.ToString();
            clientName.Text = table.CurrentRow.Cells["name_"].Value.ToString();
            service.Text = table.CurrentRow.Cells["sevice_"].Value.ToString();
            devise.Text = table.CurrentRow.Cells["devise_"].Value.ToString();
            payment.Text = table.CurrentRow.Cells["methode_"].Value.ToString();
            statut.Text = table.CurrentRow.Cells["statut_"].Value.ToString();
            discount.Text = table.CurrentRow.Cells["discount_"].Value.ToString();
            Avance.Text = table.CurrentRow.Cells["avance_"].Value.ToString();
            mainPay.Text = table.CurrentRow.Cells["pay_"].Value.ToString();
            MySqlDataReader result = await AutoPartC.getFacture();
            while (result.Read())
            {
                vehicule.Text = result["car_name"].ToString();
                plaque.Text = result["plaque"].ToString();

                phone.Text = result["phone"].ToString();
                comment.Text = result["comment"].ToString();
                idAuto.Text = result["id_auto"].ToString();
            }
            delete.Visible = true;
        }

        private async void modify_Click(object sender, EventArgs e)
        {
            modify.Enabled = false;
            bool isCartEmpty = await AutoPartC.isFactureEmpty();
            if (isCartEmpty)
            {
                modify.Enabled = true;
                MessageBox.Show("Selectionne d'abord une facture", "Info");
            }
            else
            {
                String no_recu = await AutoPartC.getNo_recu();
                float old_total = await AutoPartC.getOLdTotal();
                //--------------------------------------------------------------------------
                MySqlDataReader result = await AutoPartC.getFactureSimple();
                string myDevise = null, realStatut = null;
                float total = (await AutoPartC.getSumPrice() + await AutoPartC.getPay()) - (await AutoPartC.getDiscount());
                float newTotal = total - old_total;
                int rep = -1;
                while (result.Read())
                {
                    myDevise = result["devise"].ToString();
                    realStatut = result["statut"].ToString();
                    autoPart = new AutoPartM(result["clientName"].ToString(), result["service"].ToString(), result["devise"].ToString(), result["plaque"].ToString(), result["car_name"].ToString(), result["phone"].ToString(), result["description"].ToString(), int.Parse(result["quantite"].ToString()), float.Parse(result["montant"].ToString()), total);
                    rep = await AutoPartC.saveGoodFacture(autoPart, no_recu, table, float.Parse(result["discount"].ToString()), float.Parse(result["avance"].ToString()), result["comment"].ToString(), result["statut"].ToString(), result["payment"].ToString(), result["id_auto"].ToString(), float.Parse(result["pay"].ToString()));
                }
                //---------------
                if (realStatut == "paye")
                {
                    await dbConfig.execute_command("update facture_auto set total=" + total + ",dette=0,statut='paye' where no_recu='" + no_recu + "'");
                    if (myDevise == "US")
                    {
                        VenteC.AddUsMoney(newTotal);
                    }
                    else
                    {
                        VenteC.AddHtgMoney(newTotal);
                    }
                }
                else if (realStatut == "avance")
                {
                    await dbConfig.execute_command("update facture_auto set total=" + total + ",dette =" + total + "-avance ,statut='avance' where no_recu='" + no_recu + "'");
                }
                if (realStatut == "non paye")
                {
                    await dbConfig.execute_command("update facture_auto set total=" + total + " ,dette=" + total + " where no_recu='" + no_recu + "'");
                }
                //-----------------------------

                main.closeConn();

                if (rep == 0)
                {


                    AutoPartC.cleanFacture(table);
                    theSum.Text = "$0";
                    MessageBox.Show("Facture effectuée avec succès");
                    modify.Enabled = true;
                    main.showLogin(new oneFacture(no_recu, "auto"));
                    main.closeConn();

                }
                else
                {
                    MessageBox.Show("Erreur lors de la facturation");
                }
                //-------------------------------------------------------------==
            }
        }
    }
}
