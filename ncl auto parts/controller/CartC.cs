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
    internal class CartC
    {
        public static async Task<String> getArticleSum()
        {
            float prix, somme = 0;
            int quantite;
            MySqlDataReader result = await dbConfig.getResultCommand("select prix,quantite from panier where username='" + main.userName + "'"); 
           // MySqlDataReader result = await PanierV.getArticleSum();
            while (result.Read())
            {

                prix = float.Parse(result["prix"].ToString());
                quantite = int.Parse(result["quantite"].ToString());
                somme += (prix * quantite);

            }

           //main.theSum_.Text = somme.ToString() + " $";

            return somme.ToString();
        }
        public static async Task<bool> isCartEmpty()
        {
            bool rep = true;
            MySqlDataReader result = await dbConfig.getResultCommand("select count(*) as nbr from panier where username='" + main.userName + "'");
            while (result.Read())
            {
                int nbr = int.Parse(result["nbr"].ToString());
                if (nbr == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return rep;
        }
        public static async void getVenteInCart(BunifuDataGridView table, String receiptNumber)
        {
            MySqlDataReader result = await dbConfig.getResultCommand("select * from panier where username='" + main.userName + "'");

            while (result.Read())
            {

                //(result["id"], result["nom_du_produit"], result["prix"], result["quantite"]);
                //VenteC.vendre(result["nom_du_produit"].ToString(),int.Parse(result["quantite"].ToString()), table,receiptNumber,"");

            }
            CleanCart(table);
            showPanier(table);


        }
        public async static void deleteToCart(String id, BunifuDataGridView table)
        {
            int rep = await dbConfig.execute_command("delete from panier where id=" + id);
            showPanier(table);
        }
        public async static void showPanier(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select * from panier where username='" + main.userName + "'");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["nom_du_produit"], result["prix"], result["quantite"], result["clientName"]);

                }
            }
            catch
            {

            }
        }
        public static async Task<MySqlDataReader> getVenteInCart()
        {
            MySqlDataReader result = await dbConfig.getResultCommand("select * from panier where username='" + main.userName + "'");
            return result;
        }
        public static void CleanCart(BunifuDataGridView table)
        {
            dbConfig.execute_command("delete from panier where username='" + main.userName + "'");
            showPanier(table);
        }
        public static async void addToCart(String nom_du_produit, int quantite, string clientName, BunifuDataGridView table)
        {
            VenteM vente = await VenteC.getPriceAndQuantite(nom_du_produit);
            float total, prix_db = float.Parse(vente.Prix.ToString());
            int quantite_db = int.Parse(vente.Quantite.ToString());

            if (quantite > quantite_db)
            {
                MessageBox.Show("Nous n'avons pas cette quantite de " + nom_du_produit + " en stock");
            }
            else
            {
                string year, month, day, date;
                year = DateTime.Now.Year.ToString();
                month = DateTime.Now.Month.ToString();
                day = DateTime.Now.Day.ToString();
                date = year + "/" + month + "/" + day;
                CartM panier = new CartM(nom_du_produit,date,clientName,main.userName,prix_db,quantite);
                AddToCart(panier);
                
                MessageBox.Show(nom_du_produit + " a ete ajouter au panier");
            }

        }
        public static async Task<int> AddToCart(CartM panier)
        {
            int rep = await dbConfig.execute_command("insert into panier(nom_du_produit,prix,quantite,clientName,username) values('" + panier.Nom_du_produit + "'," + panier.Prix + "," + panier.Quantite1 + ",'" + panier.ClientName + "'" + ",'" + main.userName + "')");
            return rep;
        }

    }
}
