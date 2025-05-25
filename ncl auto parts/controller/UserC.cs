using Bunifu.UI.WinForms;
using MySql.Data.MySqlClient;
using ncl_auto_parts.db;
using ncl_auto_parts.model;
using ncl_auto_parts.screens;
using ncl_auto_parts.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ncl_auto_parts.controller
{
    internal class UserC
    {
        public async static void searchUser(String word, BunifuDataGridView table)
        {
            table.Rows.Clear();

            MySqlDataReader result = await dbConfig.getResultCommand("select * from utilisateur where id='" + word + "' or username= '" + word + "'");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["nom"], result["prenom"], result["username"], result["password"]);

                }
            }
            catch
            {

            }
        }
        public static async Task<int> fixLogin(string user)
        {
            int rep = await ifUserEmployerExiste(user);
            await dbConfig.execute_command("update utilisateur set isConected=0 where username='" + user + "'");
            return rep;
        }
        public static async Task<int> CheckIfUserConnected(String username)
        {
            int rep = 0;
            MySqlDataReader result;
            result = await dbConfig.getResultCommand("select isConected from utilisateur where username='" + username + "' ");
            while (result.Read())
            {
                rep = int.Parse(result["isConected"].ToString());
            }
            return rep;
        }
        public static async Task<AutoCompleteStringCollection> GetAllUsers_()

        {
            AutoCompleteStringCollection ProductsName = new AutoCompleteStringCollection();
            MySqlDataReader result = await dbConfig.getResultCommand("select nom from utilisateur");
            while (result.Read())
            {
                ProductsName.Add(result["nom"].ToString());

            }

            result = await dbConfig.getResultCommand("select prenom from utilisateur");
            while (result.Read())
            {
                ProductsName.Add(result["prenom"].ToString());

            }
            result = await dbConfig.getResultCommand("select username from utilisateur");
            while (result.Read())
            {
                ProductsName.Add(result["username"].ToString());

            }
            return ProductsName;
        }
        public static async Task<AutoCompleteStringCollection> GetAllUsers()

        {
            AutoCompleteStringCollection ProductsName = new AutoCompleteStringCollection();
            ProductsName = await GetAllUsers_();
            return ProductsName;
        }
        public static async Task<int> ifUserExiste_(String username)
        {
            int rep = 0;
            MySqlDataReader result;
            result = await dbConfig.getResultCommand("select count(*) as reponse from utilisateur where username='" + username + "'");
            while (result.Read())
            {
                rep = int.Parse(result["reponse"].ToString());
            }
            return rep;
        }
        public static async Task<int> CheckIfUserConnected_(String username)
        {
            int rep = 0;
            MySqlDataReader result;
            result = await dbConfig.getResultCommand("select isConected from utilisateur where username='" + username + "' ");
            while (result.Read())
            {
                rep = int.Parse(result["isConected"].ToString());
            }

            return rep;
        }
        public static async Task<int> ifPasswordIsGood_(String username, String password)
        {
            int rep = 0;
            MySqlDataReader result;
            result = await dbConfig.getResultCommand("select count(*) as reponse from utilisateur where username='" + username + "' and password='" + password + "'");
            while (result.Read())
            {
                rep = int.Parse(result["reponse"].ToString());
            }
            return rep;
        }
        public static async Task<MySqlDataReader> login_(String username, String password)
        {
            MySqlDataReader result;

            result = await dbConfig.getResultCommand("select count(*) as reponse,concat(nom,' ',prenom) as nom_complet,nom,prenom from utilisateur where username='" + username + "' and password='" + password + "' and isConected=0");
            return result;
        }
        public static async Task<MySqlDataReader> getPoste(String nom, String prenom)
        {
            MySqlDataReader result = await dbConfig.getResultCommand("select poste from employer where nom='" + nom + "' and prenom='" + prenom + "'");
            return result;
        }
        public static async Task<int> login(String username, String password)
        {
            int response = 1;
            int message = await ifUserExiste_(username);
            main.closeConn();
            int checkUser = await CheckIfUserConnected_(username);
            main.closeConn();
            String nom_complet = null, nom = null, prenom = null, poste = null;

            if (checkUser != 0)
            {

                MessageBox.Show("Quelqu'un est deja connecte sur votre compte");
            }
            if (message == 0)
            {
                MessageBox.Show("Ce nom d'utilisateur n'existe pas");
            }
            else
            {
                
                message = await ifPasswordIsGood_(username, hashMe.HASH_SHA1(password));
                if (message == 0)
                {
                    MessageBox.Show("Le mot de passe est incorrect");

                }
                else
                {
                    MySqlDataReader result = await login_(username, hashMe.HASH_SHA1(password));
                    int rep = -100;
                    
                    while (result.Read())
                    {

                        rep = int.Parse(result["reponse"].ToString());
                        nom_complet = result["nom_complet"].ToString();
                        nom = result["nom"].ToString();
                        prenom = result["prenom"].ToString();

                    }
                    if (rep > 0)
                    {
                        int chechConnected = await CheckIfUserConnected_(username);
                        if (chechConnected == 0)
                        {
                            
                            result = await getPoste(nom, prenom);
                            while (result.Read())
                            {
                                poste = result["poste"].ToString();
                            }
                            main.poste = poste;
                            Connected(username);
                            main.log_out.Visible = true;
                            Dashboard.label.Text = username;
                            if (poste == "caissier")
                            {
                                main.vente_.Enabled = true;
                                //DashBoard.sale.Enabled = true;
                                main.user_.Enabled = true;
                                ////DashBoard.user.Enabled = true;
                                main.cart_.Enabled = true;
                                //main.rapport.Enabled = true;
                                main.log_in.Visible = false;
                                main.userName = username;
                                main.poste = "caissier";



                            }
                            if (poste == "gestionnaire de stock")
                            {
                                main.reparation_.Enabled = true;
                                main.article_.Enabled = true;
                                main.client_.Enabled= true;
                                main.userName = username;
                                main.log_in.Visible = false;
                                main.poste = "gestionnaire de stock";
                                
                            }
                            if (poste == "secretaire")
                            {
                                main.article_.Enabled = true;
                                main.vente_.Enabled = true;
                                main.fournisseur_.Enabled = true;
                                main.cart_.Enabled = true;
                                main.employe_.Enabled = true;
                                main.user_.Enabled = true;
                                main.payroll_.Enabled = true;
                                main.autoPart_.Enabled = true;
                                main.payroll_.Enabled = true;
                                main.truePayroll_.Enabled = true;
                                //main.facturation_.Enabled = true;
                                main.client_.Enabled = true;
                                main.reparation_.Enabled = true;
                                main.garage_.Enabled = true;
                                //main.settings_.Enabled = true;
                                main.log_in.Visible = false;
                                main.userName = username;
                                main.poste = "secretaire";
                            }
                            
                            if (poste == "manager")
                            {
                                main.article_.Enabled = true;
                                main.vente_.Enabled = true;
                                main.fournisseur_.Enabled = true;
                                main.cart_.Enabled = true;
                                main.employe_.Enabled = true;
                                main.user_.Enabled = true;
                                main.payroll_.Enabled = true;
                                main.autoPart_.Enabled = true;
                                //main.facturation_.Enabled = true;
                                main.client_.Enabled = true;
                                main.reparation_.Enabled = true;
                                main.garage_.Enabled = true;
                                main.settings_.Enabled = true;
                                main.log_in.Visible = false;
                                main.payroll_.Enabled = true;
                                main.truePayroll_.Enabled = true;
                                main.userName = username;
                                main.poste = "manager";
                            }
                            if (poste == "PDG")
                            {
                                main.article_.Enabled = true;
                                main.truePayroll_.Enabled = true;
                                main.vente_.Enabled = true;
                                main.fournisseur_.Enabled = true;
                                main.cart_.Enabled = true;
                                main.employe_.Enabled = true;
                                main.user_.Enabled = true;
                                main.payroll_.Enabled = true;
                                main.payroll_.Enabled = true;
                                main.autoPart_.Enabled = true;
                                //main.facturation_.Enabled = true;
                                main.client_.Enabled = true;
                                main.reparation_.Enabled = true;
                                main.garage_.Enabled = true;
                                main.settings_.Enabled = true;
                                main.log_in.Visible = false;
                                main.userName = username;
                                main.poste = "PDG";
                            }


                            //main.the_name.Text = nom_complet.ToString();
                            response = 0;
                            
                        }
                        else
                        {
                            MessageBox.Show("Quelqu'un est deja connecte sur votre compte");
                        }
                    }
                    else
                    {
                        response = 1;
                    }
                }

            }
            return response;
        }
        public static async void Connected(string username)
        {
            int rep = await dbConfig.execute_command("update utilisateur set isConected=1 where username='" + username + "'");
        }
        public static async void Disconnected(string username)
        {
            int rep = await dbConfig.execute_command("update utilisateur set isConected=0 where username='" + username + "'");
        }
        public static async Task<int> saveUser(string nom, String prenom, String username, String password, String code_employer, BunifuDataGridView table)
        {
            UserM user = new UserM(nom, prenom, username, password, code_employer);
            int rep = await dbConfig.execute_command("insert into utilisateur(nom,prenom,username,password,code_employer,isConected) values('" + user.Nom + "','" + user.Prenom + "','" + user.Username + "','" + user.Password + "','" + user.Code_employer + "',0)");
            showUser(table);
            return rep;
        }
        public static async Task<int> modifyUser(String username, String password, BunifuDataGridView table, String id)
        {
            UserM user = new UserM("", "", username, password, "");
            int rep = await dbConfig.execute_command("update utilisateur set username='" + user.Username + "',password='" + user.Password + "' where id='" + id + "'");
            showUser(table);
            return rep;
        }
        public static async Task<int> ifCodeEmployerExiste_(String code)
        {
            int rep = -110;
            MySqlDataReader result = await dbConfig.getResultCommand("select count(*) as reponse from utilisateur where code_employer='" + code + "'");
            while (result.Read())
            {
                rep = int.Parse(result["reponse"].ToString());
            }
            return rep;
        }
        public static async Task<int> ifCodeEmployerExisteTrue(String code)
        {
            int rep = -110;
            MySqlDataReader result = await dbConfig.getResultCommand("select count(*) as reponse from employer where emp_id='" + code + "'");
            while (result.Read())
            {
                rep = int.Parse(result["reponse"].ToString());
            }
            return rep;
        }
        public static async Task<int> ifCodeEmployerExiste(String code)
        {
            int rep = -110;
            rep = await ifCodeEmployerExiste_(code);
            return rep;
        }
        public static async Task<int> ifUserEmployerExiste_(String user)
        {
            int rep = -110;
            MySqlDataReader result = await dbConfig.getResultCommand("select count(*) as reponse from utilisateur where username='" + user + "'");
            while (result.Read())
            {
                rep = int.Parse(result["reponse"].ToString());
            }
            return rep;
        }
        public static async Task<int> ifUserEmployerExiste(String user)
        {
            int rep = -110;
            rep = await ifUserEmployerExiste_(user);
            return rep;
        }
        public static async Task<int> deleteUser(BunifuDataGridView table, String id)
        {
            int rep = await dbConfig.execute_command("delete from utilisateur where code_employer='" + id + "'");
            showUser(table);
            return rep;
        }
        public async static void showUser(BunifuDataGridView table)
        {
            table.Rows.Clear();
            if (main.poste.Equals("manager"))
            {
                MySqlDataReader result = await dbConfig.getResultCommand("select *from utilisateur");
                try
                {
                    while (result.Read())
                    {

                        table.Rows.Add(result["code_employer"], result["nom"], result["prenom"], result["username"], result["password"]);

                    }
                }
                catch
                {

                }
            }
            else
            {
                table.Rows.Clear();
                MySqlDataReader result = await dbConfig.getResultCommand("select *from utilisateur where username='" + main.userName + "'");
                try
                {
                    while (result.Read())
                    {

                        table.Rows.Add(result["id"], result["nom"]+" "+result["prenom"], result["username"], result["password"]);

                    }
                }
                catch
                {

                }
            }
        }
    }
}
