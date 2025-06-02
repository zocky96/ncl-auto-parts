using ncl_auto_parts.controller;
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
    public partial class OtherVente : Form
    {
        string id = null;
        string noRecu = null, idT, nomProduitT, quantiteT, deviseT, p_clientName = null, p_receiptNumber = null, p_date = null;

        private async void cart_Click(object sender, EventArgs e)
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
                        CartC.addToCart(name.Text, int.Parse(qte.Text), clientName.Text, table);
                        main.closeConn();
                        // CartC.showPanier(tableCart);
                        name.Text = "";
                        qte.Text = "";

                    }
                }
            }
        }

        public OtherVente(string id)
        {
            InitializeComponent();
            this.id = id;
            
        }

        private void OtherVente_Load(object sender, EventArgs e)
        {

        }
        private void clearField()
        {
            name.Text = "";
            qte.Text = "";
            clientName.Text = "";
        }
        private async void vendre_Click(object sender, EventArgs e)
        {
            main.closeConn();
            bool isAnumber;
            Random random = new Random();
            int randomNumber = random.Next(9999999);

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
                                main.closeConn();
                                receiptNumber = "NCL" + randomNumber.ToString() + maxId.ToString();

                                bool receiptExist = await VenteC.ifReceiptIdExist(receiptNumber);
                                while (receiptExist)
                                {
                                    int ii = 0;
                                    randomNumber = random.Next(9999999);
                                    receiptNumber = "NCL" + randomNumber.ToString() + VenteC.getMaxId().ToString();
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

                            string date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
                            float total = int.Parse(qte.Text);
                            //VenteM vente = new VenteM(name.Text,date,"zock",receiptNumber,clientName.Text,5,566,2,1,5);
                            int rep = await VenteC.vendre(name.Text, int.Parse(qte.Text), table, receiptNumber, clientName.Text, devise.Text);
                            main.closeConn();
                            if (rep == 0)
                            {
                                p_receiptNumber = receiptNumber;
                                p_date = date;

                                main.closeConn();
                                VenteC.showVente(table);
                                main.closeConn();
                                clearField();
                                MessageBox.Show("Vente effectué avec succes");

                                main.showLogin(new oneVente(receiptNumber));
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
    }
}
