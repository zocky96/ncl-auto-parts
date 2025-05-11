using MySql.Data.MySqlClient;
using ncl_auto_parts.controller;
using ncl_auto_parts.model;
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
                        if (devise.Text == "US")
                        {
                            if (isAnumber)
                            {
                                AutoPartM facture = new AutoPartM(clientName.Text, service.Text, devise.Text, float.Parse(montant.Text));
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
                            else
                            {
                                MessageBox.Show("le champ montant dois contenir que des chiffres");
                            }
                        }
                        else
                        {
                            if (isAnumber)
                            {
                                AutoPartM facture = new AutoPartM(clientName.Text, service.Text, devise.Text, float.Parse(montant.Text));
                                int rep = await GarageC.saveFacture(facture, table);
                                if (rep == 0)
                                {
                                    clearField();
                                    //MessageBox.Show("Facturé avec succès");
                                }
                                else
                                {
                                    MessageBox.Show("Erreur lors de la facturation");
                                }
                            }
                            else
                            {
                                MessageBox.Show("le champ montant dois contenir que des chiffres");
                            }
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
            string receiptNumber = null;
            Random random = new Random();
            int randomNumber = random.Next(9999);
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

            MySqlDataReader result = await GarageC.getFacture();
            int rep = -1;
            while (result.Read())
            {

                if (result["devise"].ToString() == "US")
                {
                    AutoPartM facture = new AutoPartM(result["clientName"].ToString(), result["service"].ToString(), result["devise"].ToString(), float.Parse(result["montant"].ToString()));
                    rep = await GarageC.saveGoodFacture(facture, receiptNumber, table);
                    if (rep == 0)
                    {
                        VenteC.AddUsMoney(float.Parse(result["montant"].ToString()));
                        GarageC.cleanFacture(table);
                        MessageBox.Show("Facture effectuée avec succès");
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la facturation");
                    }
                }
                else
                {
                    AutoPartM facture = new AutoPartM(result["clientName"].ToString(), result["service"].ToString(), result["devise"].ToString(), float.Parse(result["montant"].ToString()));
                    rep = await GarageC.saveGoodFacture(facture, receiptNumber, table);
                    if (rep == 0)
                    {
                        VenteC.AddHtgMoney(float.Parse(result["montant"].ToString()));
                        GarageC.cleanFacture(table);
                        MessageBox.Show("Facture effectuée avec succès");
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la facturation");
                    }
                }

            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            main.showLogin(new FactureGarage());
        }

        private void Garage_Load(object sender, EventArgs e)
        {

        }
    }
}
