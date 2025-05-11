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
    public partial class Reparation : Form
    {
        string id=null;
        public Reparation()
        {
            InitializeComponent();
            main.currentPage = "reparation";
            ReparationC.showReparation(table);
            main.closeConn();
        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Reparation_Load(object sender, EventArgs e)
        {

        }
        private void clearField()
        {
            idClient.Text = "";
            marque.Text = "";
            modeleb.Text = "";
            annee.Text = "";
            plaque.Text = "";
            couleur.Text = "";
            service.Text = "";
            dateEntre.Refresh();
            dateSortie.Refresh();
        }

        private async void save_Click(object sender, EventArgs e)
        {
            main.closeConn();
            bool isAnumber;
            int i ;
            isAnumber = int.TryParse(idClient.Text, out i);
            if (isAnumber)
            {
                int ifCodeClientExiste = await ClientC.ifCodeClientExiste(idClient.Text);
                if (ifCodeClientExiste != 0)
                {
                    if (marque.Text == "")
                    {
                        MessageBox.Show("Le champ 'Marque' ne doit pas etre vide");
                    }
                    else
                    {
                        if (modeleb.Text == "")
                        {
                            MessageBox.Show("Le champ 'Modele' ne doit pas etre vide");
                        }
                        else
                        {
                            if (annee.Text == "")
                            {
                                MessageBox.Show("Le champ 'Année' ne doit pas etre vide");
                            }
                            else
                            {
                                if (plaque.Text == "")
                                {
                                    MessageBox.Show("Le champ 'Plaque' ne doit pas etre vide");
                                }
                                else
                                {
                                    if (couleur.Text == "")
                                    {
                                        MessageBox.Show("Le champ 'Couleur' ne doit pas etre vide");
                                    }
                                    else
                                    {
                                        if (service.Text == "")
                                        {
                                            MessageBox.Show("Le champ 'Service' ne doit pas etre vide");
                                        }
                                        else
                                        {
                                            int rep = await ReparationC.saveReparation(idClient.Text, marque.Text, modeleb.Text, annee.Text, plaque.Text, couleur.Text, service.Text, dateEntre.Value.Date.ToShortDateString(), dateSortie.Value.Date.ToShortDateString(), table);
                                            if (rep == 0)
                                            {
                                                clearField();
                                                main.closeConn();
                                                MessageBox.Show("Enregistrer avec succes");
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
                else
                {
                    MessageBox.Show("Le code du client n'existe pas");
                }
            }
            else
            {
                MessageBox.Show("Le champ 'identifiant du client' ne doit contenir que des chiffres");
            }
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            modify.Visible = true;
            delete.Visible = true;
            print.Visible = true;
            id = table.CurrentRow.Cells["id_"].Value.ToString();
            idClient.Text = table.CurrentRow.Cells["id_du_client"].Value.ToString(); 
            marque.Text = table.CurrentRow.Cells["marque_"].Value.ToString();
            modeleb.Text = table.CurrentRow.Cells["modele_"].Value.ToString();
            annee.Text = table.CurrentRow.Cells["annee_"].Value.ToString();
            plaque.Text = table.CurrentRow.Cells["plaque_"].Value.ToString();
            couleur.Text = table.CurrentRow.Cells["couleur_"].Value.ToString();
            service.Text = table.CurrentRow.Cells["service_"].Value.ToString();
            dateEntre.Text = table.CurrentRow.Cells["dateE"].Value.ToString(); 
            dateSortie.Text = table.CurrentRow.Cells["dateS"].Value.ToString();
        }

        private async void bunifuButton4_Click(object sender, EventArgs e)
        {
            main.closeConn();
            modify.Visible = false;
            delete.Visible = false;
            print.Visible = false;
            bool isAnumber;
            int i;
            isAnumber = int.TryParse(idClient.Text, out i);
            if (isAnumber)
            {
                int ifCodeClientExiste = await ClientC.ifCodeClientExiste(idClient.Text);
                if (ifCodeClientExiste != 0)
                {
                    if (marque.Text == "")
                    {
                        MessageBox.Show("Le champ 'Marque' ne doit pas etre vide");
                    }
                    else
                    {
                        if (modeleb.Text == "")
                        {
                            MessageBox.Show("Le champ 'Modele' ne doit pas etre vide");
                        }
                        else
                        {
                            if (annee.Text == "")
                            {
                                MessageBox.Show("Le champ 'Année' ne doit pas etre vide");
                            }
                            else
                            {
                                if (plaque.Text == "")
                                {
                                    MessageBox.Show("Le champ 'Plaque' ne doit pas etre vide");
                                }
                                else
                                {
                                    if (couleur.Text == "")
                                    {
                                        MessageBox.Show("Le champ 'Couleur' ne doit pas etre vide");
                                    }
                                    else
                                    {
                                        if (service.Text == "")
                                        {
                                            MessageBox.Show("Le champ 'Service' ne doit pas etre vide");
                                        }
                                        else
                                        {
                                            int rep = await ReparationC.modifyreparation( marque.Text, modeleb.Text, annee.Text, plaque.Text, couleur.Text, service.Text, dateEntre.Value.Date.ToShortDateString(), dateSortie.Value.Date.ToShortDateString(), table,id,idClient.Text);
                                            if (rep == 0)
                                            {
                                                clearField();
                                                main.closeConn();
                                                MessageBox.Show("Enregistrer avec succes");
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
                else
                {
                    MessageBox.Show("Le code du client n'existe pas");
                }
            }
            else
            {
                MessageBox.Show("Le champ 'identifiant du client' ne doit contenir que des chiffres");
            }
        }

        private async void delete_Click(object sender, EventArgs e)
        {
            main.closeConn();
            modify.Visible = false;
            delete.Visible = false;
            print.Visible = false;
            int rep = await ReparationC.deleteReparation(table, id);
            if (rep == 0)
            {
                clearField();
                MessageBox.Show("Suprimer avec succes");
            }
            else
            {
                MessageBox.Show("Erreur lors de la supression");
            }
        }

        private void print_Click(object sender, EventArgs e)
        {
            main.closeConn();
            modify.Visible = false;
            delete.Visible = false;
            print.Visible = false;
        }

        private void searchBar_KeyDown(object sender, KeyEventArgs e)
        {
            main.closeConn();
            if (e.KeyCode == Keys.Enter)
            {
                if (searchBar.Text == "")
                {

                }
                else
                {
                    ReparationC.searchReparation(searchBar.Text, table);
                }

            }
        }

        private void searchBar_KeyUp(object sender, KeyEventArgs e)
        {
            if (searchBar.Text == "")
            {
                ReparationC.showReparation(table);
            }
        }
    }
}
