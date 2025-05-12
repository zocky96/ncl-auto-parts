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
    internal class DepenseC
    {
        public async static void searchFournisseur(String word, BunifuDataGridView table)
        {
            table.Rows.Clear();

            MySqlDataReader result = await dbConfig.getResultCommand("select * from fournisseur where id='" + word + "' or nom='" + word + "' or  prenom='" + word + "' or telephone='" + word + "' or nom_du_produit='" + word + "'");
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
        public static async Task<int> saveDepense(DepenseM depense, BunifuDataGridView table)
        {
            int rep = await dbConfig.execute_command("insert into depenses(motifDepense,montantDepense,date,explication,signature,devise) values('" + depense.MotifDepense + "',"+depense.MontantDepense+",'"+depense.Date+"','"+depense.Explication+"','"+depense.Signature+"','"+depense.Devise+"')");
            showDepense(table);
            return rep;
        }
        public static async Task<int> saveAjout(DepenseM depense, BunifuDataGridView table)
        {
            int rep = await dbConfig.execute_command("insert into ajout(montantDepense,date,explication,signature,devise) values( " + depense.MontantDepense + ",'" + depense.Date + "','" + depense.Explication + "','" + depense.Signature + "','" + depense.Devise + "')");
            showAjout(table);
            return rep;
        }
        public static async Task<int> saveAjoutGarage(DepenseM depense, BunifuDataGridView table)
        {
            int rep = await dbConfig.execute_command("insert into ajout_garage(montantDepense,date,explication,signature,devise) values( " + depense.MontantDepense + ",'" + depense.Date + "','" + depense.Explication + "','" + depense.Signature + "','" + depense.Devise + "')");
            showAjoutGarage(table);
            return rep;
        }
        public static async Task<int> saveDepenseGarage(DepenseM depense, BunifuDataGridView table)
        {
            int rep = await dbConfig.execute_command("insert into depenses_garage(motifDepense,montantDepense,date,explication,signature,devise) values('" + depense.MotifDepense + "'," + depense.MontantDepense + ",'" + depense.Date + "','" + depense.Explication + "','" + depense.Signature + "','" + depense.Devise + "')");
            //showDepenseGarage(table);
            return rep;
        }
        public static async Task<int> modifyDepense(String nom, String prenom, String telephone, String adresse, String nom_du_produit, BunifuDataGridView table, String id)
        {
            FournisseurM fournisseur = new FournisseurM(nom, prenom, telephone, adresse, nom_du_produit);
            int rep = await dbConfig.execute_command("update fournisseur set nom='" + fournisseur.Nom + "',prenom='" + fournisseur.Prenom + "',telephone='" + fournisseur.Telephone + "',adresse='" + fournisseur.Adresse + "',nom_du_produit='" + fournisseur.Nom_du_produit + "' where id='" + id + "'");
            showDepense(table);
            return rep;
        }
        public static async Task<int> deleteFournisseur(BunifuDataGridView table, String id)
        {
            int rep = await dbConfig.execute_command("delete from fournisseur where id='" + id + "'");
            showDepense(table);
            return rep;
        }
        public async static void showDepense(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from depenses");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["motifDepense"], result["montantDepense"], result["explication"], result["signature"], result["date"], result["devise"]);

                }
            }
            catch
            {

            }
        }
        public async static void showAjout(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from ajout");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["montantDepense"], result["explication"], result["signature"], result["date"], result["devise"]);

                }
            }
            catch
            {

            }
        }
        public async static void showAjoutGarage(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from ajout_garage");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["montantDepense"], result["explication"], result["signature"], result["date"], result["devise"]);

                }
            }
            catch
            {

            }
        }
        public async static void showDepenseGarage(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from depenses_garage");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["motifDepense"], result["montantDepense"], result["explication"], result["signature"], result["date"], result["devise"]);

                }
            }
            catch
            {

            }
        }

    }
}
