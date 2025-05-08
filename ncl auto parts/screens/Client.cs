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
    public partial class Client : Form
    {
        string id = null;
        public Client()
        {
            InitializeComponent();
            main.currentPage = "client";
            ClientC.showClient(table);
            main.closeConn();
        }
        private void clearField()
        {
            nom.Text = "";
            prenom.Text = "";
            adresse.Text = "";
            phone.Text = "";
            mail.Text = "";

        }
        private async void save_Click(object sender, EventArgs e)
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
                            MessageBox.Show("Le champ 'phone' ne doit pas etre vide");
                        }
                        else
                        {
                            if (mail.Text == "")
                            {
                                MessageBox.Show("Le champ 'Mail' ne doit pas etre vide");
                            }
                            else
                            {
                                int rep = await ClientC.saveClient(nom.Text, prenom.Text, adresse.Text, phone.Text, mail.Text, table);
                                if (rep == 0)
                                {
                                    clearField();
                                    modify.Visible = false;
                                    delete.Visible = false;
                                    MessageBox.Show("Client enregistré avec succes");
                                }
                                else
                                {
                                    MessageBox.Show("Erreur lors de la l'enregistrement");
                                }
                                clearField();
                                main.closeConn();
                            }
                        }
                    }
                }
            }
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            modify.Visible = true;
            delete.Visible = true;
            id = table.CurrentRow.Cells["id_"].Value.ToString();
            nom.Text = table.CurrentRow.Cells["nom_"].Value.ToString();
            prenom.Text = table.CurrentRow.Cells["prenom_"].Value.ToString();
            adresse.Text = table.CurrentRow.Cells["adresse_"].Value.ToString();
            phone.Text = table.CurrentRow.Cells["phone_"].Value.ToString();
            mail.Text = table.CurrentRow.Cells["mail_"].Value.ToString();
        }

        private async void modify_Click(object sender, EventArgs e)
        {
            modify.Visible = false;
            delete.Visible = false;
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
                            MessageBox.Show("Le champ 'phone' ne doit pas etre vide");
                        }
                        else
                        {
                            if (mail.Text == "")
                            {
                                MessageBox.Show("Le champ 'Mail' ne doit pas etre vide");
                            }
                            else
                            {
                                int rep = await ClientC.modifyClient(nom.Text, prenom.Text, adresse.Text, phone.Text, mail.Text, table,id);
                                if (rep == 0)
                                {
                                    clearField();
                                    modify.Visible = false;
                                    delete.Visible = false;
                                    MessageBox.Show("Client enregistré avec succes");
                                }
                                else
                                {
                                    MessageBox.Show("Erreur lors de la l'enregistrement");
                                }
                                clearField();
                                main.closeConn();
                            }
                        }
                    }
                }
            }
        }

        private async void delete_Click(object sender, EventArgs e)
        {
            modify.Visible = false;
            delete.Visible = false;
            int rep = await ClientC.deleteClient(table, id);
            if (rep == 0)
            {
                clearField();
                MessageBox.Show("Client suprimé avec succes");
            }
            else
            {
                MessageBox.Show("Erreur lors de la supression");
            }
        }

        private void Client_Load(object sender, EventArgs e)
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

                    ClientC.searchClient(searchBar.Text, table);
                    
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
                ClientC.showClient(table);
            }
        }
    }
}
