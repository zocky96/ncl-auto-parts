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
    internal class PayrollC
    {
        public async static void searchPayment(String word, BunifuDataGridView table)
        {
            table.Rows.Clear();

            MySqlDataReader result = await dbConfig.getResultCommand("select * from new_payroll order by id desc where id_emp='" + word + "' or poste='" + word + "' or  date='" + word + "'");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["id_emp"], result["fullname"], result["poste"], result["breuvage"], result["nourriture"], result["avance"], result["dette"], result["sol"], result["init_amount"], result["final_amount"], result["comment"],result["date"]);

                }
            }
            catch
            {

            }
        }
        public static async Task<int> savePayroll( PayrollM pay, BunifuDataGridView table)
        {
            string date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            int rep = await dbConfig.execute_command("insert into new_payroll(id_emp,fullname,poste,breuvage,nourriture,avance,dette,sol,init_amount,final_amount,comment,date) values('" + pay.Id_emp+"','"+pay.Fullname+"','"+pay.Poste+"',"+pay.Breuvage+","+pay.Nourriture+","+pay.Avance+","+pay.Dette+","+pay.Sol+","+pay.Init_amount+","+pay.Final_amount+",'"+pay.Comment+"','"+date+"')");
            showPayroll(table);
            return rep;
        }
        public static async Task<int> modifyFournisseur(String nom, String prenom, String telephone, String adresse, String nom_du_produit, BunifuDataGridView table, String id)
        {
            FournisseurM fournisseur = new FournisseurM(nom, prenom, telephone, adresse, nom_du_produit);
            int rep = await dbConfig.execute_command("update fournisseur set nom='" + fournisseur.Nom + "',prenom='" + fournisseur.Prenom + "',telephone='" + fournisseur.Telephone + "',adresse='" + fournisseur.Adresse + "',nom_du_produit='" + fournisseur.Nom_du_produit + "' where id='" + id + "'");
            //showFournisseur(table);
            return rep;
        }
        public static async Task<int> deleteFournisseur(BunifuDataGridView table, String id)
        {
            int rep = await dbConfig.execute_command("delete from fournisseur where id='" + id + "'");
            //showFournisseur(table);
            return rep;
        }
        public async static void showPayroll(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from new_payroll order by id desc");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["id_emp"], result["fullname"], result["poste"], result["breuvage"], result["nourriture"], result["avance"], result["dette"], result["sol"], result["init_amount"], result["final_amount"], result["comment"],result["date"]);

                }
            }
            catch
            {

            }
        }
    }
}
