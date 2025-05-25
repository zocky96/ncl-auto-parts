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
    public partial class Employer : Form
    {
        string id = null,lot1 = null;
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
            salaire.Text = "";
        }
        private async void save_Click(object sender, EventArgs e)
        {
            main.closeConn();
            Random random = new Random();
            int randomNumber = random.Next(99);
            string receiptNumber = null;
            //-------------------
            try
            {
                int maxId = await EmployerC.getMaxId();
                main.closeConn();
                receiptNumber = "NCL" + randomNumber.ToString() + maxId.ToString();

                bool receiptExist = await EmployerC.ifIdExistEmploye(receiptNumber);
                main.closeConn();
                while (receiptExist)
                {
                    int ii = 0;
                    randomNumber = random.Next(99);
                    receiptNumber = "NCL" + randomNumber.ToString() + EmployerC.getMaxId().ToString();
                    receiptExist = await EmployerC.ifIdExistEmploye(receiptNumber);
                    main.closeConn();
                    ii += 1;
                    if (ii >= 20)
                    {
                        receiptNumber = "IOk" + randomNumber.ToString() + EmployerC.getMaxId().ToString();
                        receiptExist = await EmployerC.ifIdExistEmploye(receiptNumber);
                        main.closeConn();
                    }
                }
            }
            catch
            {

            }
            //----------------------------
            modify.Visible = false;
            delete.Visible = false;
            bool isAnumber = false;
            float j = 0;
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
                                    if(poste.Text == "caissier" || poste.Text == "PDG" || poste.Text == "gestionnaire de stock" || poste.Text == "manager" || poste.Text == "secretaire" || poste.Text == "directeur" || poste.Text == "mecanicien")
                                    {
                                        //ok
                                        isAnumber = float.TryParse(salaire.Text, out j);
                                        if (isAnumber)
                                        {
                                            EmployerC.saveEmployer(nom.Text, prenom.Text, nif.Text, mail.Text, adresse.Text, "", poste.Text, table, phone.Text,float.Parse(salaire.Text),receiptNumber);
                                            clearField();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Le champ salaire doit contenir que des chiffres");
                                        }
                                            
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
            lot1 = table.CurrentRow.Cells["lot"].Value.ToString();
            //MessageBox.Show(id);
            nom.Text = table.CurrentRow.Cells["nom_"].Value.ToString();
            prenom.Text = table.CurrentRow.Cells["prenom_"].Value.ToString();
            adresse.Text = table.CurrentRow.Cells["adresse_"].Value.ToString();
            phone.Text = table.CurrentRow.Cells["phone_"].Value.ToString();
            mail.Text = table.CurrentRow.Cells["mail_"].Value.ToString();
            nif.Text = table.CurrentRow.Cells["nif_"].Value.ToString();
            poste.Text = table.CurrentRow.Cells["poste_"].Value.ToString();
            salaire.Text = table.CurrentRow.Cells["sal"].Value.ToString();
            modify.Visible = true;
            delete.Visible = true;
        }

        private async void modify_Click(object sender, EventArgs e)
        {
            main.closeConn();
            bool isAnumber = false;
            float j = 0;
            //MessageBox.Show(id);
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
                                    if (poste.Text == "caissier" || poste.Text == "PDG" || poste.Text == "gestionnaire de stock" || poste.Text == "manager" || poste.Text == "secretaire" || poste.Text == "directeur" || poste.Text== "mecanicien")
                                    {
                                        //ok
                                        isAnumber = float.TryParse(salaire.Text, out j);
                                        if (isAnumber)
                                        {
                                            modify.Visible = false;
                                            delete.Visible = false;
                                            EmployerM emplo = new EmployerM(nom.Text, prenom.Text, nif.Text, mail.Text, adresse.Text, "", poste.Text, phone.Text);
                                            int rep = await EmployerC.modifyEmployer(emplo, table, id,salaire.Text);
                                            main.closeConn();
                                            clearField();
                                            if (rep == 0)
                                            {
                                                MessageBox.Show("Employé modifier avec succes");
                                            }
                                            else
                                            {
                                                MessageBox.Show("Erreur lors de la modification");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Le champ salaire doit contenir que des chiffres");
                                        }
                                           
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
            main.closeConn();
            modify.Visible = false;
            delete.Visible = false;
            EmployerC.deleteEmployer(id,lot1,table);
            main.closeConn();
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
                    main.closeConn();
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
