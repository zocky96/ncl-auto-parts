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
    internal class FournisseurC
    {
        public async static void searchFournisseur(String word, BunifuDataGridView table)
        {
            table.Rows.Clear();

            MySqlDataReader result = await dbConfig.getResultCommand("select * from fournisseur order by id desc where id='" + word + "' or nom='" + word + "' or  prenom='" + word + "' or telephone='" + word + "' or nom_du_produit='" + word + "'");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["nom"], result["prenom"], result["telephone"], result["adresse"], result["nom_du_produit"]);

                }
            }
            catch
            {

            }
        }
        public static async Task<int> saveFournisseur(String nom, String prenom, String telephone, String adresse, String nom_du_produit, BunifuDataGridView table)
        {
            FournisseurM fournisseur = new FournisseurM(nom, prenom, telephone, adresse, nom_du_produit);
            int rep = await dbConfig.execute_command("insert into fournisseur(nom,prenom,adresse,telephone,nom_du_produit) values('" + fournisseur.Nom + "','" + fournisseur.Prenom + "','" + fournisseur.Adresse + "','" + fournisseur.Telephone + "','" + fournisseur.Nom_du_produit + "')");
            showFournisseur(table);
            return rep;
        }
        public static async Task<int> modifyFournisseur(String nom, String prenom, String telephone, String adresse, String nom_du_produit, BunifuDataGridView table, String id)
        {
            FournisseurM fournisseur = new FournisseurM(nom, prenom, telephone, adresse, nom_du_produit);
            int rep = await dbConfig.execute_command("update fournisseur set nom='" + fournisseur.Nom + "',prenom='" + fournisseur.Prenom + "',telephone='" + fournisseur.Telephone + "',adresse='" + fournisseur.Adresse + "',nom_du_produit='" + fournisseur.Nom_du_produit + "' where id='" + id + "'");
            showFournisseur(table);
            return rep;
        }
        public static async Task<int> deleteFournisseur(BunifuDataGridView table, String id)
        {
            int rep = await dbConfig.execute_command("delete from fournisseur where id='" + id + "'");
            showFournisseur(table);
            return rep;
        }
        public async static void showFournisseur(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from fournisseur order by id desc");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["nom"], result["prenom"], result["telephone"], result["adresse"], result["nom_du_produit"]);

                }
            }
            catch
            {

            }
        }
    }
}
