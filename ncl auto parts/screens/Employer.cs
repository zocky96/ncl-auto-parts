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
    public partial class Employer : Form
    {
        string id = null;
        public Employer()
        {
            InitializeComponent();
            main.currentPage = "employer";
            EmployerC.showEmployer(table);

            main.closeConn();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Employer_Load(object sender, EventArgs e)
        {

        }
        private void clearField()
        {
            nom.Text = "";
            prenom.Text = "";
            adresse.Text = "";
            phone.Text = "";
            mail.Text = "";
            nif.Text = "";
            poste.Text = "Poste";
        }
        private void save_Click(object sender, EventArgs e)
        {
            modify.Visible = false;
            delete.Visible = false;
        
            if(nom.Text == "")
            {
                MessageBox.Show("Le champ 'Nom' ne doit pas etre vide");
            }
            else
            {
                if(prenom.Text == "")
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
                        if(phone.Text == "")
                        {
                            MessageBox.Show("Le champ 'Téléphone' ne doit pas etre vide");
                        }
                        else
                        {
                            if(mail.Text == "")
                            {
                                MessageBox.Show("Le champ 'mail' ne doit pas etre vide");
                            }
                            else
                            {
                                if (nif.Text == "")
                                {
                                    MessageBox.Show("Le champ 'Nif' ne doit pas etre vide");
                                }
                                else
                                {
                                    if(poste.Text == "caissier" || poste.Text == "PDG" || poste.Text == "gestionnaire de stock" || poste.Text == "manager" || poste.Text == "secretaire" || poste.Text == "directeur")
                                    {
                                        //ok
                                        EmployerC.saveEmployer(nom.Text, prenom.Text, nif.Text, mail.Text, adresse.Text, "", poste.Text, table, phone.Text);
                                        clearField();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Le poste que vous avez choisi n'est pas valable");
                                    }

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
            nom.Text = table.CurrentRow.Cells["nom_"].Value.ToString();
            prenom.Text = table.CurrentRow.Cells["prenom_"].Value.ToString();
            adresse.Text = table.CurrentRow.Cells["adresse_"].Value.ToString();
            phone.Text = table.CurrentRow.Cells["phone_"].Value.ToString();
            mail.Text = table.CurrentRow.Cells["mail_"].Value.ToString();
            nif.Text = table.CurrentRow.Cells["nif_"].Value.ToString();
            poste.Text = table.CurrentRow.Cells["poste_"].Value.ToString();
            modify.Visible = true;
            delete.Visible = true;
        }

        private void modify_Click(object sender, EventArgs e)
        {
           
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
                        if (phone.Text == "")
                        {
                            MessageBox.Show("Le champ 'Téléphone' ne doit pas etre vide");
                        }
                        else
                        {
                            if (mail.Text == "")
                            {
                                MessageBox.Show("Le champ 'mail' ne doit pas etre vide");
                            }
                            else
                            {
                                if (nif.Text == "")
                                {
                                    MessageBox.Show("Le champ 'Nif' ne doit pas etre vide");
                                }
                                else
                                {
                                    if (poste.Text == "caissier" || poste.Text == "PDG" || poste.Text == "gestionnaire de stock" || poste.Text == "manager" || poste.Text == "secretaire" || poste.Text == "directeur")
                                    {
                                        //ok
                                        modify.Visible = false;
                                        delete.Visible = false;
                                        EmployerC.modifyEmployer(nom.Text, prenom.Text, nif.Text, adresse.Text, "", poste.Text, table,id, phone.Text,mail.Text);
                                        clearField();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Le poste que vous avez choisi n'est pas valable");
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            modify.Visible = false;
            delete.Visible = false;
            EmployerC.deleteEmployer(id, table);
            clearField();
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
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

                    EmployerC.searchEmployer(searchBar.Text, table);

                }

            }
        }

        private void searchBar_KeyUp(object sender, KeyEventArgs e)
        {
            if (searchBar.Text == "")
            {
                EmployerC.showEmployer(table);
            }
        }
    }
}
