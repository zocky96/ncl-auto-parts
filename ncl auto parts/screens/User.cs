using ncl_auto_parts.controller;
using ncl_auto_parts.tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ncl_auto_parts.screens
{
    public partial class User : Form
    {
        string id = null;
        public User()
        {
            InitializeComponent();
            main.currentPage = "user";
            UserC.showUser(table);
            main.closeConn();
            if(main.poste== "PDG" || main.poste== "manager")
            {
                save.Enabled = true;
                delete.Enabled = true;
            }
        }
        private void clearFields()
        {
            idEmployer.Text = "";
            userName.Text = "";
            password.Text = "";
            confPassword.Text = "";
        }
        private async void bunifuButton1_Click(object sender, EventArgs e)
        {
            main.closeConn();
            string nom, prenom, username, passwd, passwd_conf, code_employer;
            if (idEmployer.Text == "")
            {
                MessageBox.Show("Le champ 'identifiant de l'employer' ne doit pas etre vide");
            }
            else
            {
                if (userName.Text == "")
                {
                    MessageBox.Show("Le champ 'Nom d'utilisateur' ne doit pas etre vide");
                }
                else
                {
                    if(password.Text == "")
                    {
                        MessageBox.Show("Le champ 'Mot de passe' ne doit pas etre vide");
                    }
                    else
                    {
                        if (confPassword.Text == "")
                        {
                            MessageBox.Show("Le champ 'Confirmé le mot de passe' ne doit pas etre vide");
                        }
                        else
                        {
                            if (password.Text.Equals(confPassword.Text))
                            {
                                int ifCodeEmployerExiste = await UserC.ifCodeEmployerExiste(idEmployer.Text);
                                int ifUserNameExist = await UserC.ifUserEmployerExiste(userName.Text);
                                if (ifCodeEmployerExiste == 0)
                                {
                                    if (ifUserNameExist == 0)
                                    {
                                        try
                                        {
                                            List<string> l1 = new List<string>();
                                            List<string> l2 = new List<string>();
                                            l1 = await EmployerC.getNameAndFirstnameById(idEmployer.Text);
                                            nom = l1[0].ToString();
                                            l2 = await EmployerC.getNameAndFirstnameById(idEmployer.Text);
                                            prenom = l2[1].ToString();
                                            //username = username_u.Text;
                                            passwd = hashMe.HASH_SHA1(password.Text);
                                            passwd_conf = hashMe.HASH_SHA1(confPassword.Text);
                                            if (passwd.Equals(passwd_conf))
                                            {
                                                int rep = await UserC.saveUser(nom, prenom, userName.Text, passwd, idEmployer.Text, table);
                                                if (rep == 0)
                                                {
                                                    UserC.showUser(table);
                                                    clearFields();
                                                    delete.Visible = false;
                                                    modify.Visible = false;
                                                    main.closeConn();
                                                    MessageBox.Show("Utilisateur enregistrer avec succes");
                                                }
                                                else
                                                {
                                                    main.closeConn();
                                                    MessageBox.Show("Erreur lors de l'enregistrement");
                                                }
                                            }
                                            else
                                            {
                                                main.closeConn();
                                                MessageBox.Show("Entrer le meme mot de passe dans les deux champs");
                                            }
                                        }
                                        catch
                                        {
                                            main.closeConn();
                                            MessageBox.Show("Cet employer n'existe pas");
                                        }
                                    }
                                    else
                                    {
                                        main.closeConn();
                                        MessageBox.Show("Le nom d'utilisateur est deja pris");

                                    }
                                }
                                else
                                {
                                    main.closeConn();
                                    MessageBox.Show("Cet utilisateur existe deja dans la base se donnee");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Vous devez mettre le meme mot de passe dans les deux champs");
                            }
                        }
                    }
                }
            }
        }

        private void User_Load(object sender, EventArgs e)
        {

        }

        private async void modify_Click(object sender, EventArgs e)
        {
            main.closeConn();
            string nom, prenom, username, passwd, passwd_conf, code_employer;
            
            passwd = hashMe.HASH_SHA1(password.Text);
            passwd_conf = hashMe.HASH_SHA1(confPassword.Text);
            if (idEmployer.Text == "")
            {
                MessageBox.Show("Le champ 'Code de l'employer' est vide");
            }
            else
            {
                if (userName.Text == "")
                {
                    MessageBox.Show("Le champ 'Nom d'utilisateur' est vide");
                }
                else
                {
                    if (password.Text == "")
                    {
                        MessageBox.Show("Le champ 'Mot de passe' est vide");
                    }
                    else
                    {
                        if (confPassword.Text == "")
                        {
                            MessageBox.Show("Le champ 'Confirmation de mot de passe' est vide");
                        }
                        else
                        {



                            try
                            {
                                List<string> l1 = new List<string>();
                                List<string> l2 = new List<string>();
                                l1 = await EmployerC.getNameAndFirstnameById(idEmployer.Text);
                                nom = l1[0].ToString();
                                l2 = await EmployerC.getNameAndFirstnameById(idEmployer.Text);
                                prenom = l2[1].ToString();

                                //username = username_u.Text;
                                passwd = hashMe.HASH_SHA1(password.Text);
                                passwd_conf = hashMe.HASH_SHA1(confPassword.Text);
                                if (passwd.Equals(passwd_conf))
                                {
                                    int rep = await UserC.modifyUser(userName.Text, passwd, table, id);
                                    if (rep == 0)
                                    {
                                        MessageBox.Show("Utilisateur modifier avec succes");
                                        //main.userName = username;
                                        UserC.showUser(table);
                                        clearFields();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Erreur lors de la modification");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Entrer le meme mot de passe dans les deux champs");
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Cet employer n'existe pas");
                            }


                        }
                    }
                }
            }
        }

        private async void delete_Click(object sender, EventArgs e)
        {
            main.closeConn();
            int rep = await UserC.deleteUser(table, id);
            //MessageBox.Show(id_.ToString());
            if (rep == 0)
            {
                delete.Visible = false;
                modify.Visible = false;
                main.closeConn();
                MessageBox.Show("Utilisateur suprimer avec succes");
                clearFields();
            }
            else
            {
                main.closeConn();
                MessageBox.Show("Erreur lors de la supression");
            }
            main.closeConn();
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            delete.Visible = true;
            id = table.CurrentRow.Cells["id_"].Value.ToString();
            idEmployer.Text = table.CurrentRow.Cells["id_"].Value.ToString();
            userName.Text = table.CurrentRow.Cells["user_"].Value.ToString();

        }
    }
}
