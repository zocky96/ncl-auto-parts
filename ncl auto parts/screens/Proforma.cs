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
    public partial class Proforma : Form
    {
        string id;
        float sum = 0;
        string somme = null;
        ProformaM proforma_ = null;
        public List<(string name, int quantite, float price, float total)> donnees;
        public Proforma()
        {
            InitializeComponent();
            //ProformaC.clearProforma(table);
            ProformaC.showProforma(table);
            
            try
            {
                getSum();
                autoCompletion();
            }
            catch
            {

            }
            main.closeConn();
        }
        private async void getSum()
        {
            total.Text ="$"+ await ProformaC.getArticleSum();
        }
        private async Task<string> getSum_()
        {
            return "$" + await ProformaC.getArticleSum();
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

        private async void add_Click(object sender, EventArgs e)
        {
            main.closeConn();
            bool isAnumber;
            int i;
           
            delete.Visible = false;
           
            if (clientName.Text == "")
            {
                MessageBox.Show("Le nom du client ne doit pas etre vide");
            }
            else
            {
                if (name.Text == "")
                {
                    MessageBox.Show("Le nom de l'article ne doit pas etre vide");
                }
                else
                {
                    isAnumber = int.TryParse(qte.Text, out i);

                    if (isAnumber)
                    {
                        float j = 0;
                        isAnumber = float.TryParse(price.Text, out j);
                        if(isAnumber)
                        {
                            if(devise.Text == "US" || devise.Text == "HTG")
                            {
                                sum += float.Parse(price.Text) * int.Parse(qte.Text);
                                string date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
                                ProformaM proforma = new ProformaM(clientName.Text, carName.Text, plaque_.Text, phone.Text, date, name.Text, float.Parse(price.Text), float.Parse(price.Text) * int.Parse(qte.Text), int.Parse(qte.Text));
                                int rep = await ProformaC.saveProforma(proforma, table,devise.Text);
                                if (rep == 0)
                                {
                                    getSum();
                                    clearField();
                                }
                                else
                                {
                                    MessageBox.Show("Une erreur s'est produit lors de l'enregistrement");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Choisir une devise");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Le champ prix dois contenir que des chiffres");
                        }
                        
                        
                       

                    }
                    else
                    {
                        MessageBox.Show("Le champ quantité dois contenir que des chiffres");
                    }
                }
            }
        }

        private void Proforma_Load(object sender, EventArgs e)
        {

        }

        private async void clean_Click(object sender, EventArgs e)
        {
            main.closeConn();
            if (!await ProformaC.ifTableEmpty())
            {
                delete.Visible = false;
                ProformaC.clearProforma(table);
                getSum();
            }
            
        }

        private void delete_Click(object sender, EventArgs e)
        {
            main.closeConn();
            ProformaC.deleteProforma(table, id);
            getSum();
            delete.Visible = false;
            
        }
        private void clearField()
        {
            name.Text = "";
            qte.Text = "";
            price.Text = "";
        }
        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = table.CurrentRow.Cells["id_"].Value.ToString();
            delete.Visible = true;
            print.Visible = true;
        }

        private async void print_Click(object sender, EventArgs e)
        {
            main.closeConn();
            delete.Visible = false;
            main.showLogin(new ProformaViewer());
            
        }

        private async void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            

            Bitmap bmp = new Bitmap(logo.Width, logo.Height);
            logo.DrawToBitmap(bmp, new Rectangle(0, 0, logo.Width, logo.Height));
            e.Graphics.DrawImage(bmp, new Point(60, 60));
            e.Graphics.DrawString("NC.L AUTO SERVICE", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(300, 60));
            e.Graphics.DrawString("Quartier Morin NORD,Haiti", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(335, 90));
            e.Graphics.DrawString("Tél:(509)36449128\\33650089", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(335, 110));
            e.Graphics.DrawString("info.nclautoservices@gmail.com", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(325, 130));
            //-
            e.Graphics.DrawString("Nom du client : "+proforma_.ClientName, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 210));
            e.Graphics.DrawString("Nom du véhicule : "+proforma_.CarName, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 230));
            e.Graphics.DrawString("Plaque : "+proforma_.Plaque, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 250));
            e.Graphics.DrawString("Téléphone : "+proforma_.Phone, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 270));
            string date;
           
            date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            e.Graphics.DrawString("Date : "+proforma_.Date, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 290));
            //-

            e.Graphics.DrawString("Service :", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 360));
            e.Graphics.DrawString("Proforma", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(150, 410));
            //-
            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Black;
            Pen pen = Pens.Black;

            int startX = 85;
            int startY = 460;
            int rowHeight = 25;
            int[] colWidths = { 340, 90, 90, 90, 220, 220 }; // name, quantite, quantity, price, tax, total

            string[] headers = { "Description", "Quantité", "Prix unitaire", "Total" };

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
            foreach (var (Description, quantiteM, price, total) in donnees)
            {
                x = startX;

                string[] valeurs = {
            Description,
            quantiteM.ToString(),
            price.ToString(),
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
            e.Graphics.DrawString("TOTAL", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(85, y+50));
           
            e.Graphics.DrawString(somme, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(605, y + 50));

            //-
            e.Graphics.DrawString("PS:\"Ce proforma est valide pour une durée de 8 jours\" :", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(85, 1020));
            e.Graphics.DrawString("Merci d'avoir choisi NC.L Autoservices!!!", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(485, 1070));
        }

        private void qte_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
