using Bunifu.UI.WinForms;
using MySql.Data.MySqlClient;
using ncl_auto_parts.db;
using ncl_auto_parts.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncl_auto_parts.controller
{
    internal class ClientC
    {
        public static async Task<int> saveClient(String nom, String prenom, String adresse, String phone, String mail, BunifuDataGridView table)
        {
            ClientM client = new ClientM(nom, prenom, adresse, phone, mail);
            int rep = await dbConfig.execute_command("insert into client(nom,prenom,adresse,phone,mail) values('" + client.Nom + "','" + client.Prenom + "','" + client.Adresse + "','" + client.Phone + "','" + client.Mail + "')");
            showClient(table);
            return rep;
        }
        public static async Task<int> ifCodeClientExiste(String code)
        {
            int rep = -110;
            MySqlDataReader result = await dbConfig.getResultCommand("select count(*) as reponse from client where id='" + code + "'");
            while (result.Read())
            {
                rep = int.Parse(result["reponse"].ToString());
            }
            return rep;
        }
        public static async Task<int> modifyClient(String nom, String prenom, String adresse, String phone, String mail, BunifuDataGridView table,string id)
        {
            ClientM client = new ClientM(nom, prenom, adresse, phone, mail);
            int rep = await dbConfig.execute_command("update client set nom='"+client.Nom+"',prenom='"+client.Prenom+"',adresse='"+client.Adresse+"',phone='"+client.Phone+"',mail='"+client.Mail+"' where id='"+id+"'");
            showClient(table);
            return rep;
        }
        public static async Task<int> deleteClient(BunifuDataGridView table, String id)
        {
            int rep = await dbConfig.execute_command("delete from client where id='" + id + "'");
            showClient(table);
            return rep;
        }
        public async static void searchClient(string word,BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from client where nom='"+word+"' or prenom='"+word+"' or phone='"+word+"' or mail='"+word+"'");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["nom"], result["prenom"], result["adresse"], result["phone"], result["mail"]);

                }
            }
            catch
            {

            }
        }
        public async static void showClient(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from client");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["nom"], result["prenom"], result["adresse"], result["phone"], result["mail"]);

                }
            }
            catch
            {

            }
        }
    }
}
