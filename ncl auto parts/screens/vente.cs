using MySql.Data.MySqlClient;
using ncl_auto_parts.controller;
using ncl_auto_parts.db;
using ncl_auto_parts.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ncl_auto_parts.screens
{
    public partial class vente : Form
    {
        string noRecu = null,idT, nomProduitT,quantiteT,deviseT,p_clientName=null,p_receiptNumber=null,p_date=null;
        public List<(string name, int quantite, float price, float tax, float total)> donnees;
        public vente()
        {
            InitializeComponent();
            main.currentPage = "vente";
            autoCompletion();
            VenteC.showVente(table);
            //CartC.showPanier(tableCart);
            main.closeConn();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void clearField()
        {
            name.Text = "";
            qte.Text = "";
            clientName.Text = "";
        }

        private void vente_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            
        }

        private async void bunifuButton5_Click(object sender, EventArgs e)
        {
            bool isAnumber;            
            int i = 0;
            if (name.Text == "")
            {
                MessageBox.Show("Le champs 'Nom de l'article' ne doit pas etre vide");
            }
            else
            {
                isAnumber = int.TryParse(qte.Text, out i);
                if (!isAnumber)
                {
                    MessageBox.Show("Le champs 'Quantité' doit contenir que des chiffres");
                }
                else
                {
                    if (clientName.Text == "")
                    {
                        MessageBox.Show("Le champs 'Nom de l'article' ne doit pas etre vide");
                    }
                    else
                    {
                        CartC.addToCart(name.Text, int.Parse(qte.Text), clientName.Text,table);
                       // CartC.showPanier(tableCart);
                        name.Text = "";
                        qte.Text = "";
                       
                    }
                }
            }
        }

        private async void bunifuButton1_Click(object sender, EventArgs e)
        {
            main.closeConn();
            bool isAnumber;
            Random random = new Random();
            int randomNumber = random.Next(9999);

            String receiptNumber = null;
            int i = 0;
            if(name.Text == "")
            {
                MessageBox.Show("Le champs 'Nom de l'article' ne doit pas etre vide");
            }
            else
            {
                isAnumber = int.TryParse(qte.Text, out i);
                if (!isAnumber)
                {
                    MessageBox.Show("Le champs 'Quantité' doit contenir que des chiffres");
                }
                else
                {
                    if(clientName.Text == "")
                    {
                        MessageBox.Show("Le champs 'Nom de l'article' ne doit pas etre vide");
                    }
                    else
                    {
                        if(devise.Text=="US" || devise.Text == "HTG")
                        {
                            
                                try
                                {
                                    int maxId = await VenteC.getMaxId();
                                    receiptNumber = "IOE" + randomNumber.ToString() + maxId.ToString();

                                    bool receiptExist = await VenteC.ifReceiptIdExist(receiptNumber);
                                    while (receiptExist)
                                    {
                                        int ii = 0;
                                        randomNumber = random.Next(9999);
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

                                string year, month, day, date;
                                year = DateTime.Now.Year.ToString();
                                month = DateTime.Now.Month.ToString();
                                day = DateTime.Now.Day.ToString();
                                date = year + "/" + month + "/" + day;
                                float total = int.Parse(qte.Text);
                                //VenteM vente = new VenteM(name.Text,date,"zock",receiptNumber,clientName.Text,5,566,2,1,5);
                                int rep = await VenteC.vendre(name.Text, int.Parse(qte.Text), table, receiptNumber, clientName.Text, devise.Text);
                                if (rep == 0)
                                {
                                    MySqlDataReader result = await dbConfig.getResultCommand("select * from vente where receiptNumber='"+receiptNumber+"'");
                                    //public List<(string name, int quantite, float price, float tax, float total)> donnees;
                                    donnees = new List<(string, int, float, float, float)>();
                                    p_clientName = clientName.Text;
                                    p_receiptNumber = receiptNumber;
                                    p_date = date;
                                    while (result.Read())
                                    {
                                        donnees.Add((result["nom_du_produit"].ToString(), int.Parse(result["quantite"].ToString()), float.Parse(result["prix"].ToString()), 0, float.Parse(result["total"].ToString())));
                                    }
                                    printDocument1.Print();
                                    VenteC.showVente(table);
                                    clearField();
                                    MessageBox.Show("Vente effectué avec succes");
                                }
                                else
                                {
                                    MessageBox.Show("Erreur lors de la vente");
                                }
                                
                            
                        }
                        else
                        {
                            MessageBox.Show("Choisir une devise");
                        }
                    }
                }
            }
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            
        }
        private int TotalWidth(int[] widths)
        {
            int total = 0;
            foreach (int w in widths)
                total += w;
            return total;
        }
        private async void loadData()
        {
            
            
        }
        private async void okok(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawString("INVOICE", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(80, 90));
            e.Graphics.DrawString("NC.L AUTO PARTS", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(80, 120));
            e.Graphics.DrawString("Quartier Morin NORD,Haiti", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(80, 140));
            e.Graphics.DrawString("Cap-Haitien", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(80, 170));
            e.Graphics.DrawString("Tél:(509)36449128\\33650089", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(80, 190));
            e.Graphics.DrawString("Email:info.nclautoservices@gmail.com", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(80, 210));
            //---
            
            //--

            Bitmap bmp = new Bitmap(logo.Width,logo.Height);
            logo.DrawToBitmap(bmp, new Rectangle(0, 0, logo.Width, logo.Height));
            e.Graphics.DrawImage(bmp, new Point(480, 60));
            e.Graphics.DrawString("__________________________________________________________________________________________________", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(40, 240));
            e.Graphics.DrawString("Bill to : "+p_clientName, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(80, 270));
            e.Graphics.DrawString("Invoice No :"+ p_receiptNumber, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(500, 270));
            //e.Graphics.DrawString("le kiki", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(80, 290));
            e.Graphics.DrawString("Date :"+p_date, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(500, 290));
            e.Graphics.DrawString("Due date :"+ p_date, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(500, 310));
            e.Graphics.DrawString("Payment status :" + "Paid", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(500, 330));
            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Black;
            Pen pen = Pens.Black;

            int startX = 100;
            int startY = 390;
            int rowHeight = 25;
            int[] colWidths = { 220, 90, 90, 90, 90, 90 }; // name, quantite, quantity, price, tax, total

            string[] headers = { "Name", "Quantity", "Price", "Tax", "Total" };

            // Dessiner l'en-tête avec bordures
            int x = startX;
            for (int i = 0; i < headers.Length; i++)
            {
                Rectangle rect = new Rectangle(x, startY, colWidths[i], rowHeight);
                e.Graphics.DrawRectangle(pen, rect);
                e.Graphics.DrawString(headers[i], new Font("Arial", 10, FontStyle.Bold), brush, rect);
                x += colWidths[i];
            }

            // Dessiner les données avec bordures
            int y = startY + rowHeight;
            foreach (var (name, quantity, price, tax, total) in donnees)
            {
                x = startX;

                string[] valeurs = {
            name,
            quantity.ToString(),
            price.ToString(),
            tax.ToString(),
            total.ToString()
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

            e.Graphics.DrawString("$" +0, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(605, y + 50));

            //-
            //e.Graphics.DrawString("PS:\"Ce proforma est valide pour une durée de 8 jours\" :", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(85, 1020));
            e.Graphics.DrawString("Merci d'avoir choisi NC.L Autoservices!!!", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(485, 1070));
        }

        private void bunifuTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (searchBar.Text == "")
                {

                }
                else
                {
                    VenteC.searchVente(searchBar.Text, table);
                }

            }
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchBar_KeyUp(object sender, KeyEventArgs e)
        {
            if (searchBar.Text == "")
            {
                VenteC.showVente(table);
            }
        }

        private async void bunifuButton1_Click_1(object sender, EventArgs e)
        {

            
           
            //}
        }

        private async void vendre_Click(object sender, EventArgs e)
        {
            main.closeConn();
            bool isAnumber;
            Random random = new Random();
            int randomNumber = random.Next(9999);

            String receiptNumber = null;
            int i = 0;
            if (name.Text == "")
            {
                MessageBox.Show("Le champs 'Nom de l'article' ne doit pas etre vide");
            }
            else
            {
                isAnumber = int.TryParse(qte.Text, out i);
                if (!isAnumber)
                {
                    MessageBox.Show("Le champs 'Quantité' doit contenir que des chiffres");
                }
                else
                {
                    if (clientName.Text == "")
                    {
                        MessageBox.Show("Le champs 'Nom de l'article' ne doit pas etre vide");
                    }
                    else
                    {
                        if (devise.Text == "US" || devise.Text == "HTG")
                        {

                            try
                            {
                                int maxId = await VenteC.getMaxId();
                                receiptNumber = "IOE" + randomNumber.ToString() + maxId.ToString();

                                bool receiptExist = await VenteC.ifReceiptIdExist(receiptNumber);
                                while (receiptExist)
                                {
                                    int ii = 0;
                                    randomNumber = random.Next(9999);
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

                            string year, month, day, date;
                            year = DateTime.Now.Year.ToString();
                            month = DateTime.Now.Month.ToString();
                            day = DateTime.Now.Day.ToString();
                            date = year + "/" + month + "/" + day;
                            float total = int.Parse(qte.Text);
                            //VenteM vente = new VenteM(name.Text,date,"zock",receiptNumber,clientName.Text,5,566,2,1,5);
                            int rep = await VenteC.vendre(name.Text, int.Parse(qte.Text), table, receiptNumber, clientName.Text, devise.Text);
                            if (rep == 0)
                            {
                                MySqlDataReader result = await dbConfig.getResultCommand("select * from vente where receiptNumber='" + receiptNumber + "'");
                                //public List<(string name, int quantite, float price, float tax, float total)> donnees;
                                donnees = new List<(string, int, float, float, float)>();
                                p_clientName = clientName.Text;
                                p_receiptNumber = receiptNumber;
                                p_date = date;
                                while (result.Read())
                                {
                                    donnees.Add((result["nom_du_produit"].ToString(), int.Parse(result["quantite"].ToString()), float.Parse(result["prix"].ToString()), 0, float.Parse(result["total"].ToString())));
                                }
                                PrintDialog printDialog1 = new PrintDialog();
                                printDialog1.Document = printDocument1;
                                DialogResult resulta = printDialog1.ShowDialog();
                                if (resulta == DialogResult.OK)
                                {
                                    printDocument1.Print();
                                }
                                VenteC.showVente(table);
                                clearField();
                                MessageBox.Show("Vente effectué avec succes");
                            }
                            else
                            {
                                MessageBox.Show("Erreur lors de la vente");
                            }


                        }
                        else
                        {
                            MessageBox.Show("Choisir une devise");
                        }
                    }
                }
            }
        }

        private void cart_Click(object sender, EventArgs e)
        {
            main.closeConn();
            bool isAnumber;
            int i = 0;
            if (name.Text == "")
            {
                MessageBox.Show("Le champs 'Nom de l'article' ne doit pas etre vide");
            }
            else
            {
                isAnumber = int.TryParse(qte.Text, out i);
                if (!isAnumber)
                {
                    MessageBox.Show("Le champs 'Quantité' doit contenir que des chiffres");
                }
                else
                {
                    if (clientName.Text == "")
                    {
                        MessageBox.Show("Le champs 'Nom de l'article' ne doit pas etre vide");
                    }
                    else
                    {
                        CartC.addToCart(name.Text, int.Parse(qte.Text), clientName.Text, table);
                        // CartC.showPanier(tableCart);
                        name.Text = "";
                        qte.Text = "";

                    }
                }
            }
        }

        private void table_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            cancelCart.Visible = true;
            print.Visible = true;
            noRecu = table.CurrentRow.Cells["receipt"].Value.ToString();
            idT = table.CurrentRow.Cells["id"].Value.ToString();
            nomProduitT = table.CurrentRow.Cells["productName"].Value.ToString();
            quantiteT = table.CurrentRow.Cells["quantite_"].Value.ToString();
            deviseT = table.CurrentRow.Cells["devise_"].Value.ToString();
            //----
            p_clientName = table.CurrentRow.Cells["_nomClien"].Value.ToString();
            p_receiptNumber = table.CurrentRow.Cells["receipt"].Value.ToString();
            p_date = table.CurrentRow.Cells["dd"].Value.ToString();
        }

        private async void print_Click(object sender, EventArgs e)
        {
            main.closeConn();
            cancelCart.Visible = false;
            print.Visible = false;
            MySqlDataReader result = await dbConfig.getResultCommand("select * from vente where receiptNumber='" + p_receiptNumber + "'");
            //public List<(string name, int quantite, float price, float tax, float total)> donnees;
            donnees = new List<(string, int, float, float, float)>();

            while (result.Read())
            {
                donnees.Add((result["nom_du_produit"].ToString(), int.Parse(result["quantite"].ToString()), float.Parse(result["prix"].ToString()), 0, float.Parse(result["total"].ToString())));
            }
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = printDocument1;
            DialogResult resulta = printDialog1.ShowDialog();
            if (resulta == DialogResult.OK)
            {
                printDocument1.Print();
            }
            clearField();
            MessageBox.Show("Vente effectué avec succes");
        }

        private void cancelCart_Click(object sender, EventArgs e)
        {
            main.closeConn();
            cancelCart.Visible = false;
            print.Visible = false;
            VenteC.cancelVente(idT, nomProduitT, table, int.Parse(quantiteT), noRecu, deviseT);
        }

        private void proforma_Click(object sender, EventArgs e)
        {
            main.closeConn();
            main.showLogin(new Proforma());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton1_Click_2(object sender, EventArgs e)
        {
            main.showLogin(new Rapport());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void logo_Click(object sender, EventArgs e)
        {

        }

        private async void autoCompletion()
        {
            
            //------------------------

            name.AutoCompleteCustomSource = await ArticleC.GetAllProductName();
            name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            name.AutoCompleteSource = AutoCompleteSource.CustomSource;
            name.PlaceholderText = "Enter text";
            //main.CurrentSuggestion.PlaceholderText = "Recherche          date :  2024-12-25";
        }

        private void tableCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private async void bunifuButton4_Click(object sender, EventArgs e)
        {
            
        }

        private async void bunifuButton2_Click(object sender, EventArgs e)
        {
            cancelCart.Visible = false;
            print.Visible = false;
            MySqlDataReader result = await dbConfig.getResultCommand("select * from vente where receiptNumber='" + p_receiptNumber + "'");
            //public List<(string name, int quantite, float price, float tax, float total)> donnees;
            donnees = new List<(string, int, float, float, float)>();
            
            while (result.Read())
            {
                donnees.Add((result["nom_du_produit"].ToString(), int.Parse(result["quantite"].ToString()), float.Parse(result["prix"].ToString()), 0, float.Parse(result["total"].ToString())));
            }
            printDocument1.Print();
            clearField();
            MessageBox.Show("Vente effectué avec succes");
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cancelCart.Visible = true;
            print.Visible = true;
            noRecu = table.CurrentRow.Cells["receipt"].Value.ToString();
            idT = table.CurrentRow.Cells["id"].Value.ToString();
            nomProduitT = table.CurrentRow.Cells["productName"].Value.ToString();
            quantiteT =   table.CurrentRow.Cells["quantite_"].Value.ToString();
            deviseT = table.CurrentRow.Cells["devise_"].Value.ToString();
            //----
            p_clientName = table.CurrentRow.Cells["_nomClien"].Value.ToString();
            p_receiptNumber = table.CurrentRow.Cells["receipt"].Value.ToString();
            p_date = table.CurrentRow.Cells["dd"].Value.ToString();
        }
    }
}
