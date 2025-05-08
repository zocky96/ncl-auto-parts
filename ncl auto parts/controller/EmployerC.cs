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
        public static async Task<int> deleteEmployer(String id, BunifuDataGridView table)
        {
           int rep = await dbConfig.execute_command("delete from employer where id=" + id + "");
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
            MySqlDataReader result = await dbConfig.getResultCommand("select nom,prenom from employer where id=" + id);
            while (result.Read())
            {
                String nom = result["nom"].ToString();
                String prenom = result["prenom"].ToString();
                liste.Add(nom);
                liste.Add(prenom);
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
        public static async Task<int> saveEmployer(String nom, String prenom, String nif, String mail, String adresse, String date_de_naissance, String poste, BunifuDataGridView table, string phone)
        {
            EmployerM emplo = new EmployerM(nom, prenom, nif, mail, adresse, date_de_naissance, poste, phone);
            int rep = await dbConfig.execute_command("insert into employer(nom,prenom,nif,mail,poste,adresse,phone) values('" + emplo.Nom + "','" + emplo.Prenom + "','" + emplo.Nif+ "','" + emplo.Mail + "','" + emplo.Poste + "','" + emplo.Adresse + "'," + "'" + emplo.Phone + "')");

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

                    table.Rows.Add(result["id"], result["nom"], result["prenom"], result["mail"], result["nif"], result["adresse"], result["poste"], result["phone"]);

                }
            }
            catch
            {

            }

        }
        public static async Task<int> modifyEmployer(String nom, String prenom, String nif, String adresse, String date_de_naissance, String poste, BunifuDataGridView table, String id, string phone,string mail)
        {
            EmployerM emplo = new EmployerM(nom, prenom, nif, mail, adresse, date_de_naissance, poste, phone);
            int rep = await dbConfig.execute_command("update employer set nom='" + emplo.Nom + "',prenom='" + emplo.Prenom + "',nif='" + emplo.Nif + "'," + "adresse='" + emplo.Adresse + "',poste='" + emplo.Poste + "'" + ",phone='" + emplo.Phone + "' where id =" + id);
            showEmployer(table);
            return rep;
        }
        public async static void showEmployer(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from employer");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["nom"], result["prenom"], result["mail"], result["nif"], result["adresse"], result["poste"], result["phone"]);

                }
            }
            catch
            {

            }
        }
        public async static void showDeletedEmployer(BunifuDataGridView table)
        {

            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select * from employer_suprimer");
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
