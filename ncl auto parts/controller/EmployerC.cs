using Bunifu.UI.WinForms;
using MySql.Data.MySqlClient;
using ncl_auto_parts.db;
using ncl_auto_parts.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ncl_auto_parts.controller
{
    internal class EmployerC
    {
        public static async void getAllCaissier(ComboBox caissier)
        {
            MySqlDataReader result = await dbConfig.getResultCommand("select concat(nom,' ',prenom) as nom_complet from employer");
            while (result.Read())
            {
                caissier.Items.Add(result["nom_complet"].ToString());
            }
        }
        public static async Task<int> countEmployer()
        {
            int nbr = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select count(*) as nbr from employer");
            while (result.Read())
            {
                nbr = int.Parse(result["nbr"].ToString());
            }
            return nbr;
        }
        public static async Task<float> sumEmployer()
        {
            float nbr = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select sum(salaire) as somme from employer");
            while (result.Read())
            {
                nbr = float.Parse(result["somme"].ToString());
            }
            return nbr;
        }
        public static async Task<int> deleteEmployer(String id,string lot, BunifuDataGridView table)
        {
           int rep = await dbConfig.execute_command("delete from employer where emp_id='" + id + "' or emp_id='" + lot+"'");
            showEmployer(table);
            return rep;
        }
        public static async Task<int> ifCodeEmployerExiste_(String code)
        {
            int rep = -110;
            MySqlDataReader result = await dbConfig.getResultCommand("select count(*) as reponse from employer where id='" + code + "'");
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
        public static async Task<List<String>> getNameAndFirstnameById_(String id)
        {
            List<String> liste = new List<string>();
            liste.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select nom,prenom from employer where emp_id='" + id+"'");
            while (result.Read())
            {
                String nom = result["nom"].ToString();
                String prenom = result["prenom"].ToString();
                liste.Add(nom);
                liste.Add(prenom);
            }
            return liste;
        }
        public static async Task<List<String>> getInfoById_(String id)
        {
            List<String> liste = new List<string>();
            liste.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select concat(nom,' ',prenom) as fullname,poste,salaire from employer where emp_id='"+id+"'");
            while (result.Read())
            {
                String fullName = result["fullname"].ToString();
                String poste = result["poste"].ToString();
                string salaire = result["salaire"].ToString();
                liste.Add(fullName);
                liste.Add(poste);
                liste.Add(salaire);
            }
            return liste;
        }
        public static async Task<List<String>> getNameAndFirstnameById(String id)
        {
            List<String> liste = new List<string>();
            liste = await getNameAndFirstnameById_(id);

            return liste;
        }
        public static async Task<int> restaureEmployer(String nom, String prenom, String nif, String sexe, String adresse, String date_de_naissance, String poste, BunifuDataGridView table, String id,string mail)
        {
            EmployerM emplo = new EmployerM(nom, prenom, nif, mail, adresse, date_de_naissance, poste, "");
            int rep = await restaureEmployer(id, emplo, table);
            return rep;
        }
        public static async Task<int> restaureEmployer(String id, EmployerM empl, BunifuDataGridView table)
        {
            int rep = await dbConfig.execute_command("insert into employer(nom,prenom,nif,mail,poste,adresse,date_de_naissance) values('" + empl.Nom + "','" + empl.Prenom + "','" + empl.Nif + "','" + empl.Mail + "','" + empl.Poste + "','" + empl.Adresse + "')");
            rep = await dbConfig.execute_command("delete from employer_suprimer where id=" + id + "");
            showDeletedEmployer(table);
            return rep;
        }
        public static async Task<int> saveEmployer(String nom, String prenom, String nif, String mail, String adresse, String date_de_naissance, String poste, BunifuDataGridView table, string phone,float salaire,string empID)
        {
            EmployerM emplo = new EmployerM(nom, prenom, nif, mail, adresse, date_de_naissance, poste, phone);
            int rep = await dbConfig.execute_command("insert into employer(nom,prenom,nif,mail,poste,adresse,phone,salaire,emp_id) values('" + emplo.Nom + "','" + emplo.Prenom + "','" + emplo.Nif+ "','" + emplo.Mail + "','" + emplo.Poste + "','" + emplo.Adresse + "'," + "'" + emplo.Phone + "',"+salaire+",'"+empID+"')");

            showEmployer(table);
            return rep;
        }
        public static async Task<int> deletedEmployer(String nom, String prenom, String nif, String sexe, String adresse, String date_de_naissance, String poste, BunifuDataGridView table,string mail)
        {
            EmployerM emplo = new EmployerM(nom, prenom, nif, mail, adresse, date_de_naissance, poste, "");
            return await dbConfig.execute_command("insert into employer_suprimer(nom,prenom,nif,mail,poste,adresse,date_de_naissance) values('" + emplo.Nom + "','" + emplo.Prenom+ "','" + emplo.Nif + "','" + emplo.Mail + "','" + emplo.Poste + "','" + emplo.Adresse+ "')" );

            //showEmployer(table);

        }
        public async static void searchEmployer(String word, BunifuDataGridView table)
        {
            table.Rows.Clear();
            
            MySqlDataReader result = await dbConfig.getResultCommand("select * from employer where id='" + word + "' or nom='" + word + "' or  prenom='" + word + "' or nif='" + word + "' or phone='"+word+"' or mail='"+word+"'");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["nom"], result["prenom"], result["mail"], result["nif"], result["adresse"], result["poste"], result["phone"],result["salaire"],"HTG");

                }
            }
            catch
            {

            }

        }
        public static async Task<int> modifyEmployer(EmployerM emplo, BunifuDataGridView table, String id,string salaire)
        {
            int rep = await dbConfig.execute_command("update employer set nom='" + emplo.Nom + "',prenom='" + emplo.Prenom + "',nif='"+emplo.Nif+ "',adresse='"+emplo.Adresse+ "',poste='"+emplo.Poste+ "',phone='"+emplo.Phone+ "',mail='"+emplo.Mail+ "',salaire="+salaire+" where id =" + id);
            showEmployer(table);
            return rep;
        }
        public static async Task<bool> ifIdExistEmploye(string id)
        {
            bool rep = false;
            MySqlDataReader result = await dbConfig.getResultCommand("select count(*) as nbr from employer where emp_id='" + id + "'");
            while (result.Read())
            {
                int nbr = int.Parse(result["nbr"].ToString());
                if (nbr == 0)
                {
                    rep = false;
                }
                else
                {
                    rep = true;
                }
            }
            return rep;
        }
        public static async Task<int> getMaxId()
        {
            int id = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select max(id) as maxid from employer");
            if (result == null)
            {
                id = 0;
            }
            else
            {
                while (result.Read())
                {
                    try
                    {
                        id = int.Parse(result["maxid"].ToString());
                        // MessageBox.Show("ok zizi" + id.ToString());
                    }
                    catch
                    {
                        id = 0;
                    }
                }
            }



            return id;
        }
        public async static void showEmployer(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from employer order by id desc");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["emp_id"], result["nom"], result["prenom"], result["mail"], result["nif"], result["adresse"], result["poste"], result["phone"],result["salaire"],"HTG");

                }
            }
            catch
            {

            }
        }
        public async static void showDeletedEmployer(BunifuDataGridView table)
        {

            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select * from employer_suprimer order by id desc");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["nom"], result["prenom"], result["mail"], result["nif"], result["adresse"], result["poste"]);

                }
            }
            catch
            {

            }
        }
    }
}
