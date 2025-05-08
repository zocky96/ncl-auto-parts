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
    

    public partial class Cart : Form
    {
        String id_Cart = null, p_receiptNumber = null, p_date=null, p_clientName=null;
        public List<(string name, int quantite, float price, float tax, float total)> donnees;
        public Cart()
        {
            InitializeComponent();
            main.currentPage = "cart";
            CartC.showPanier(tableCart);
            main.closeConn();
        }

        private void deleteCart_Click(object sender, EventArgs e)
        {
            deleteCart.Visible = false;
            videCart.Visible = false;
            CartC.deleteToCart(id_Cart, tableCart);
        }

        private void videCart_Click(object sender, EventArgs e)
        {
            deleteCart.Visible = false;
            videCart.Visible = false;
            CartC.CleanCart(tableCart);
        }

        private void tableCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            deleteCart.Visible = true;
            videCart.Visible = true;
            id_Cart = tableCart.CurrentRow.Cells["IDCart"].Value.ToString();
        }

        private void Cart_Load(object sender, EventArgs e)
        {

        }

        private async void vendre_Click(object sender, EventArgs e)
        {
            id_Cart = "";
            String name, quantite, prix, type, clientName=null;
            bool isCartEmpty = await CartC.isCartEmpty();
            if (isCartEmpty)
            {
                MessageBox.Show("Le panier est vide", "Info");
            }
            else
            {
                int rep = 1;
                Random random = new Random();
                int randomNumber = random.Next(9999);
                int ID = await VenteC.getMaxId() + 1;
                String receiptNumber = "IOE" + randomNumber.ToString() + ID.ToString();
                //-----------------

                bool receiptExist = await VenteC.ifReceiptIdExist(receiptNumber);
                while (receiptExist)
                {
                    int i = 0;
                    receiptNumber = "IOE" + randomNumber.ToString() + VenteC.getMaxId().ToString();
                    receiptExist = await VenteC.ifReceiptIdExist(receiptNumber);
                    i += 1;
                    if (i >= 20)
                    {
                        receiptNumber = "IOk" + randomNumber.ToString() + VenteC.getMaxId().ToString();
                        receiptExist = await VenteC.ifReceiptIdExist(receiptNumber);
                    }
                }
                //-------------------
                MySqlDataReader result = await CartC.getVenteInCart();
                ;
                float sum = 0;
                string nomDuClient = null;

                while (result.Read())
                {
                    name = result["nom_du_produit"].ToString();
                    quantite = result["quantite"].ToString();
                    //prix = result["prix"].ToString();
                    clientName = result["clientName"].ToString();
                    rep = await VenteC.vendre(name, int.Parse(quantite), tableCart, receiptNumber, clientName,devise.Text);

                }

                if (rep == 0)
                {
                    string year, month, day, date;
                    year = DateTime.Now.Year.ToString();
                    month = DateTime.Now.Month.ToString();
                    day = DateTime.Now.Day.ToString();
                    date = year + "/" + month + "/" + day;

                    CartC.CleanCart(tableCart);
                    result = await dbConfig.getResultCommand("select * from vente where receiptNumber='" + receiptNumber + "'");
                    //public List<(string name, int quantite, float price, float tax, float total)> donnees;
                    donnees = new List<(string, int, float, float, float)>();
                    p_clientName = clientName;
                    p_receiptNumber = receiptNumber;
                    p_date = date;
                    while (result.Read())
                    {
                        donnees.Add((result["nom_du_produit"].ToString(), int.Parse(result["quantite"].ToString()), float.Parse(result["prix"].ToString()), 0, float.Parse(result["total"].ToString())));
                    }
                    printDocument1.Print();
                    main.closeConn();
                    MessageBox.Show("Vente effectue avec succes");
                }
                else
                {
                    main.closeConn();
                    MessageBox.Show("Erreur lors de la vente", "error");
                }



            }
            main.closeConn();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("INVOICE", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(80, 90));
            e.Graphics.DrawString("NC.L AUTO PARTS", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(80, 120));
            e.Graphics.DrawString("Quartier Morin, route nationale no 6", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(80, 140));
            e.Graphics.DrawString("Cap-Haitien", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(80, 170));
            e.Graphics.DrawString("Phone                34951243", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(80, 190));
            e.Graphics.DrawString("Email                info.nclautoservices@gmail.com", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(80, 210));
            Bitmap bmp = new Bitmap(logo.Width, logo.Height);
            logo.DrawToBitmap(bmp, new Rectangle(0, 0, logo.Width, logo.Height));
            e.Graphics.DrawImage(bmp, new Point(480, 60));
            e.Graphics.DrawString("__________________________________________________________________________________________________", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(40, 240));
            e.Graphics.DrawString("Bill to : " + p_clientName, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(80, 270));
            e.Graphics.DrawString("Invoice No :" + main.spaceInBill("Invoice No :", 35) + p_receiptNumber, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(500, 270));
            e.Graphics.DrawString("le kiki", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(80, 290));
            e.Graphics.DrawString("Date :" + main.spaceInBill("Date :", 35) + p_date, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(500, 290));
            e.Graphics.DrawString("Due date :" + main.spaceInBill("Due date :", 35) + p_date, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(500, 310));
            e.Graphics.DrawString("Payment status :" + main.spaceInBill("Payment status :", 35) + "Paid", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(500, 330));
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
        }
    }
}
