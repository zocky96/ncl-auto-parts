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
    public partial class PayDette : Form
    {
        string table = null;
        public PayDette(string id_,string table_)
        {
            InitializeComponent();
            ID.Text = id_;
            this.table = table_;
            ID.Enabled = false;
        }

        private void PayDette_Load(object sender, EventArgs e)
        {

        }

        private async void facture_Click(object sender, EventArgs e)
        {
            main.closeConn();
            float i = 0;

            bool isAnumber = float.TryParse(montant.Text, out i);
            if (isAnumber) 
            {
                if (payment.Text == "Cash" || payment.Text == "Virement" || payment.Text == "Cheque" || payment.Text == "Mon Cash" || payment.Text == "Nat Cash")
                {
                    if (table == "auto")
                    {
                        float dette = 0, real_montant = 0, avance_ = 0;
                        string myDevise = null;

                        MySqlDataReader result = await dbConfig.getResultCommand("select * from facture_auto where no_recu='" + ID.Text + "'");
                        while (result.Read())
                        {
                            try
                            {
                                dette = float.Parse(result["dette"].ToString());
                            }
                            catch
                            {
                                dette = 0;
                            }

                            //real_montant = float.Parse(result["total"].ToString());
                            myDevise = result["devise"].ToString();
                            avance_ = float.Parse(result["avance"].ToString());
                        }

                        real_montant = dette - float.Parse(montant.Text);
                        avance_ += float.Parse(montant.Text);
                        if (float.Parse(montant.Text) > dette)
                        {
                            MessageBox.Show("La valeur entrer est superieur a la dette");
                        }
                        else if (float.Parse(montant.Text) < 0)
                        {
                            MessageBox.Show("La valeur saisi est negatif");
                        }
                        else
                        {
                            if (real_montant == 0)
                            {
                                int rep = await dbConfig.execute_command("update facture_auto set dette=" + real_montant + ",statut='paye',payment='"+payment.Text+"',avance=0 where no_recu='" + ID.Text + "'");
                                if (myDevise == "US")
                                {
                                    VenteC.AddUsMoney(float.Parse(montant.Text));
                                }
                                else
                                {
                                    VenteC.AddHtgMoney(float.Parse(montant.Text));
                                }
                                MessageBox.Show("Dette acquitté avec succes");
                            }
                            if (real_montant > 0)
                            {
                                int rep = await dbConfig.execute_command("update facture_auto set dette=" + real_montant + ",statut='avance',payment='"+payment.Text+"',avance="+avance_+" where no_recu='" + ID.Text + "'");
                                if (myDevise == "US")
                                {
                                    VenteC.AddUsMoney(float.Parse(montant.Text));
                                }
                                else
                                {
                                    VenteC.AddHtgMoney(float.Parse(montant.Text));
                                }
                                MessageBox.Show("Ajout effectué avec succes");
                            }
                        }

                    }
                    else
                    {
                        //garage
                        float dette = 0, real_montant = 0, avance_ = 0;
                        string myDevise = null;
                        MySqlDataReader result = await dbConfig.getResultCommand("select * from facture_garage where no_recu='" + ID.Text + "'");
                        while (result.Read())
                        {
                            try
                            {
                                dette = float.Parse(result["dette"].ToString());
                            }
                            catch
                            {
                                dette = 0;
                            }
                            //real_montant = float.Parse(result["total"].ToString());
                            myDevise = result["devise"].ToString();
                        }

                        real_montant = dette - float.Parse(montant.Text);
                        avance_ += float.Parse(montant.Text);
                        if (float.Parse(montant.Text) > dette)
                        {
                            MessageBox.Show("La valeur entrer est superieur a la dette");
                        }
                        else if (float.Parse(montant.Text) < 0)
                        {
                            MessageBox.Show("La valeur saisi est negatif");
                        }
                        else
                        {
                            if (real_montant == 0)
                            {
                                int rep = await dbConfig.execute_command("update facture_garage set dette=" + real_montant + ",statut='paye',payment='"+payment.Text+"',avance=0 where no_recu='" + ID.Text + "'");
                                if (myDevise == "US")
                                {
                                    VenteC.AddUsMoneyGarage(float.Parse(montant.Text));
                                }
                                else
                                {
                                    VenteC.AddHTGMoneyGarage(float.Parse(montant.Text));
                                }
                                MessageBox.Show("Dette acquitté avec succes");
                            }
                            if (real_montant > 0)
                            {
                                int rep = await dbConfig.execute_command("update facture_garage set dette=" + real_montant + ",statut='avance',payment='"+payment.Text+"',avance="+avance_+" where no_recu='" + ID.Text + "'");
                                if (myDevise == "US")
                                {
                                    VenteC.AddUsMoneyGarage(float.Parse(montant.Text));
                                }
                                else
                                {
                                    VenteC.AddHTGMoneyGarage(float.Parse(montant.Text));
                                }
                                MessageBox.Show("Ajout effectué avec succes");
                            }
                        }



                        //garage
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez Choisir une methode de paiement");
                }

                    
   
            }
            else
            {
                MessageBox.Show("Le champ montant doit contenir que des chiffres");
            }
            main.closeConn();
            
        }
    }
}
