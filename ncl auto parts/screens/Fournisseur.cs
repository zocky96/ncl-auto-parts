using ncl_auto_parts.controller;
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
    public partial class Fournisseur : Form
    {
        string id,nom_, prenom_, telephone_, adresse_, nom_du_produit_;
        public Fournisseur()
        {
            InitializeComponent();
            main.currentPage = "fournisseur";
            FournisseurC.showFournisseur(table);
            main.closeConn();
        }

        private void Fournisseur_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void nom_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void searchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (searchBar.Text == "")
                {
                    
                }
                else
                {
                    FournisseurC.searchFournisseur(searchBar.Text, table);
                }

            }
        }

        private void searchBar_KeyUp(object sender, KeyEventArgs e)
        {
            if (searchBar.Text == "")
            {
                FournisseurC.showFournisseur(table);
            }
        }

        private void print_Click(object sender, EventArgs e)
        {

        }

        private void clearField()
        {
            nom.Text = "";
            prenom.Text = "";
            adresse.Text = "";
            productName.Text = "";
            phone.Text = "";
        }

        private async void save_Click(object sender, EventArgs e)
        {
            main.closeConn();
            modify.Visible = false;
            delete.Visible = false;
            main.closeConn();
            if (nom.Text == "")
            {
                MessageBox.Show("Le champ 'Nom' ne doit pas etre vide");
            }
            else
            {
                if (prenom.Text == "")
                {
                    MessageBox.Show("Le champ 'Prenom' ne doit pas etre vide");
                }
                else
                {
                    if(adresse.Text == "")
                    {
                        MessageBox.Show("Le champ 'Adresse' ne doit pas etre vide");
                    }
                    else
                    {
                        if(productName.Text == "")
                        {
                            MessageBox.Show("Le champ 'Nom du produit' ne doit pas etre vide");
                        }
                        else
                        {
                            if(phone.Text == "")
                            {
                                MessageBox.Show("Le champ 'Téléphone' ne doit pas etre vide");
                            }
                            else
                            {
                                //put that fucking fuction here
                                int rep = await FournisseurC.saveFournisseur(nom.Text, prenom.Text, phone.Text, adresse.Text, productName.Text, table);
                                if(rep == 0)
                                {
                                    clearField();
                                    MessageBox.Show("Fournisseur enregistrer avec succes");
                                }
                                else
                                {
                                    MessageBox.Show("Erreur lors de lénregistrement");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = table.CurrentRow.Cells["id_"].Value.ToString();
            modify.Visible = true;
            delete.Visible = true;
            nom.Text = table.CurrentRow.Cells["nomT"].Value.ToString();
            prenom.Text = table.CurrentRow.Cells["prenomT"].Value.ToString();
            phone.Text = table.CurrentRow.Cells["phoneT"].Value.ToString();
            adresse.Text = table.CurrentRow.Cells["adresseT"].Value.ToString();
            productName.Text = table.CurrentRow.Cells["produit"].Value.ToString();
        }

        private async void delete_Click(object sender, EventArgs e)
        {
            main.closeConn();
            int rep = await FournisseurC.deleteFournisseur(table, id);
            if (rep == 0)
            {
                modify.Visible = false;
                delete.Visible = false;
                clearField();
                MessageBox.Show("Fournisseur suprimer avec succes");
            }
            else
            {
                MessageBox.Show("Erreur lors de supression");
            }
        }

        private async void modify_Click(object sender, EventArgs e)
        {
            main.closeConn();
            modify.Visible = false;
            delete.Visible = false;
            main.closeConn();
            if (nom.Text == "")
            {
                MessageBox.Show("Le champ 'Nom' ne doit pas etre vide");
            }
            else
            {
                if (prenom.Text == "")
                {
                    MessageBox.Show("Le champ 'Prenom' ne doit pas etre vide");
                }
                else
                {
                    if (adresse.Text == "")
                    {
                        MessageBox.Show("Le champ 'Adresse' ne doit pas etre vide");
                    }
                    else
                    {
                        if (productName.Text == "")
                        {
                            MessageBox.Show("Le champ 'Nom du produit' ne doit pas etre vide");
                        }
                        else
                        {
                            if (phone.Text == "")
                            {
                                MessageBox.Show("Le champ 'Téléphone' ne doit pas etre vide");
                            }
                            else
                            {
                                //put that fucking fuction here
                                int rep = await FournisseurC.modifyFournisseur(nom.Text, prenom.Text, phone.Text, adresse.Text, productName.Text, table,id);
                                if (rep == 0)
                                {
                                    clearField();
                                    MessageBox.Show("Fournisseur enregistrer avec succes");
                                }
                                else
                                {
                                    MessageBox.Show("Erreur lors de lénregistrement");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
