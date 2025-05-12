using MySql.Data.MySqlClient;
using ncl_auto_parts.controller;
using ncl_auto_parts.db;
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
    public partial class Payroll : Form
    {
        public Payroll()
        {
            InitializeComponent();
            DepenseC.showDepense(tableDepense);
            
            initWin();
            
        }
        public static async Task<string> getAutoUs()
        {
            string quantite = null;
            MySqlDataReader result = await dbConfig.getResultCommand("select amount from account_us");

            while (result.Read())
            {


                quantite = result["amount"].ToString();

            }
            return quantite;
        }
        public static async Task<string> getAutoHtg()
        {
            string quantite = null;
            MySqlDataReader result = await dbConfig.getResultCommand("select amount from account_htg");

            while (result.Read())
            {


                quantite = result["amount"].ToString();

            }
            return quantite;
        }
        //-
        public static async Task<string> getGarageHtg()
        {
            string quantite = null;
            MySqlDataReader result = await dbConfig.getResultCommand("select amount from account_htg_garage");

            while (result.Read())
            {


                quantite = result["amount"].ToString();

            }
            return quantite;
        }
        //-
        public static async Task<string> getGarageUs()
        {
            string quantite = null;
            MySqlDataReader result = await dbConfig.getResultCommand("select amount from account_us_garage");

            while (result.Read())
            {


                quantite = result["amount"].ToString();

            }
            return quantite;
        }

        private async void initWin()
        {
            int nbr = await EmployerC.countEmployer();
            float somme = await EmployerC.sumEmployer();
            nbrEmploye.Text = nbr.ToString();
            moneyEmploye.Text = "$"+somme.ToString();
            autoUs.Text = "$" + await getAutoUs();
            autoHtg.Text = "$" + await getAutoHtg();
            garageHtg.Text = "$"+ await getGarageHtg();
            garageUs.Text = "$" + await getGarageUs();
            main.closeConn();
        }
        private void bunifuShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private async void retirer_Click(object sender, EventArgs e)
        {
            main.closeConn();
            float i;
            bool isAnumber = float.TryParse(montant.Text, out i);
            if (isAnumber)
            {
                if (explication.Text == "")
                {
                    MessageBox.Show("Le champ 'Explication' ne dois pas etre vide");
                }
                else
                {
                    if(devise.Text=="US" || devise.Text == "HTG")
                    {
                        string date;
                        
                        date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
                        if (devise.Text == "US")
                        {
                            int rep = await VenteC.RemoveUsMoney(float.Parse(montant.Text));
                            if (rep == 0)
                            {
                                DepenseM depense = new DepenseM(motif.Text, explication.Text, main.userName, date, devise.Text, float.Parse(montant.Text));
                                rep = await DepenseC.saveDepense(depense, tableDepense);
                                if (rep == 0)
                                {
                                    main.closeConn();
                                    clearField();
                                    initWin();
                                    MessageBox.Show("Montant retirer avec succes");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Une erreur s'est produire lors de la soustraction de l'argent");
                            }
                        }
                        else
                        {
                            int rep = await VenteC.RemoveHtgMoney(float.Parse(montant.Text));
                            if (rep == 0)
                            {
                                DepenseM depense = new DepenseM(motif.Text, explication.Text, main.userName, date, devise.Text, float.Parse(montant.Text));
                                rep = await DepenseC.saveDepense(depense, tableDepense);
                                if (rep == 0)
                                {
                                    clearField();
                                    MessageBox.Show("Montant retirer avec succes");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Une erreur s'est produire lors de la soustraction de l'argent");
                            }
                            
                           
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Choisir une devise");
                    }
                }
            }
            else
            {
                MessageBox.Show("Le champ 'Montant' dois contenir que des chiffres");
            }
        }
        private void clearField()
        {
            motif.Text = "";
            explication.Text = "";
            motif.Text = "";
            devise.Text = "Devise";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void bunifuButton1_Click(object sender, EventArgs e)
        {
            main.closeConn();
            float i;
            bool isAnumber = float.TryParse(montant.Text, out i);
            if (isAnumber)
            {
                if (explication.Text == "")
                {
                    MessageBox.Show("Le champ 'Explication' ne dois pas etre vide");
                }
                else
                {
                    if (devise.Text == "US" || devise.Text == "HTG")
                    {
                        string date;

                        date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
                        if (devise.Text == "US")
                        {
                            int rep = await VenteC.AddUsMoney(float.Parse(montant.Text));
                            if (rep == 0)
                            {
                                DepenseM depense = new DepenseM(motif.Text, explication.Text, main.userName, date, devise.Text, float.Parse(montant.Text));
                                rep = await DepenseC.saveDepense(depense, tableDepense);
                                if (rep == 0)
                                {
                                    clearField();
                                    MessageBox.Show("Montant ajouter avec succes");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Une erreur s'est produire lors de l'addition de l'argent");
                            }
                        }
                        else
                        {
                            int rep = await VenteC.AddHtgMoney(float.Parse(montant.Text));
                            if (rep == 0)
                            {
                                DepenseM depense = new DepenseM(motif.Text, explication.Text, main.userName, date, devise.Text, float.Parse(montant.Text));
                                rep = await DepenseC.saveDepense(depense, tableDepense);
                                if (rep == 0)
                                {
                                    clearField();
                                    MessageBox.Show("Montant ajouter avec succes");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Une erreur s'est produire lors de l'addition de l'argent");
                            }



                        }
                    }
                    else
                    {
                        MessageBox.Show("Choisir une devise");
                    }
                }
            }
            else
            {
                MessageBox.Show("Le champ 'Montant' dois contenir que des chiffres");
            }
        }

        private void tableDepense_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
