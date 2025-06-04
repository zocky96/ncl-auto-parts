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
    internal class ReparationC
    {
        public static async Task<int> saveReparation(String clientId, String Marque, String modele, String annee, String plaque,string couleur,string service,string dateEntree,string dateSortie, BunifuDataGridView table,string payment,string statut)
        {
            ReparationM reparation = new ReparationM(clientId, Marque, modele, annee, plaque, couleur, service, dateEntree, dateSortie);
            int rep = await dbConfig.execute_command("insert into reparation(clientId, Marque, modele, annee, plaque, couleur, service, dateEntree, dateSortie,statut,payment) values('" + clientId + "','"+ Marque + "','"+ modele + "','"+ annee + "','"+ plaque + "','"+ couleur + "','"+ service + "','"+ dateEntree + "','"+ dateSortie + "','"+statut+"','"+payment+"')");
            showReparation(table);
            return rep;
        }
        public static async Task<int> modifyreparation( String Marque, String modele, String annee, String plaque, string couleur, string service, string dateEntree, string dateSortie, BunifuDataGridView table, String id,string ClientID, string payment, string statut)
        {
            //FournisseurM fournisseur = new FournisseurM(nom, prenom, telephone, adresse, nom_du_produit);
            int rep = await dbConfig.execute_command("update reparation set Marque='"+Marque+"', modele='"+modele+"', annee='"+annee+"', plaque='"+plaque+"', couleur='"+couleur+"', service='"+service+"', dateEntree='"+dateEntree+"', dateSortie='"+dateSortie+ "',statut='"+statut+ "',payment='"+payment+"' where id='" + id + "' and clientId='"+ClientID+"'");
            showReparation(table);
            return rep;
        }
        public static async Task<int> deleteReparation(BunifuDataGridView table, String id)
        {
            int rep = await dbConfig.execute_command("delete from reparation where id='" + id + "'");
            showReparation(table);
            return rep;
        }
        public async static void searchReparation(string word,BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from reparation where dateSortie='" + word+ "' or dateEntree='"+word+ "' or service='"+word+ "' or plaque='"+word+ "' or annee='"+word+ "' or modele='"+word+ "' or Marque='"+word+ "' or clientId='"+word+"'");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["clientId"], result["Marque"], result["modele"], result["annee"], result["plaque"], result["couleur"], result["service"], result["dateEntree"], result["dateSortie"], result["statut"], result["payment"]);

                }
            }
            catch
            {

            }
        }
        public async static void filtreReparation(string word, BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from reparation where statut='"+word+"'");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["clientId"], result["Marque"], result["modele"], result["annee"], result["plaque"], result["couleur"], result["service"], result["dateEntree"], result["dateSortie"], result["statut"], result["payment"]);

                }
            }
            catch
            {

            }
        }
        public async static void showReparation(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from reparation order by id desc");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["clientId"], result["Marque"], result["modele"], result["annee"], result["plaque"], result["couleur"], result["service"], result["dateEntree"], result["dateSortie"],result["statut"],result["payment"]);

                }
            }
            catch
            {

            }
        }
    }
}
