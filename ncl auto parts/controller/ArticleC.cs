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
    internal class ArticleC
    {
        public static async void filtredByFinnishStock(BunifuDataGridView table)
        {
            MySqlDataReader result;
            table.Rows.Clear();
            result = await dbConfig.getResultCommand("select *from article where quantite <= 3");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["nom_du_produit"], result["prix"], result["quantite"], result["idfournisseur"], result["element"], result["ref"], result["numero"], result["dateAjout"],result["init_value"]);

                }
            }
            catch
            {

            }

        }
        public static async void filtreArticleByType(BunifuDataGridView table, String typeX)
        {
            MySqlDataReader result = null;
            table.Rows.Clear();
            if (typeX == "Comprime")
            {
                result = await dbConfig.getResultCommand("select *from article where type='Comprime'");
            }
            else if (typeX == "Sirop")
            {
                result = await dbConfig.getResultCommand("select *from article where type='Sirop'");
            }
            else if (typeX == "Creme")
            {
                result = await dbConfig.getResultCommand("select *from article where type='Creme'");
            }
            else if (typeX == "Goutte")
            {
                result = await dbConfig.getResultCommand("select *from article where type='Goutte'");
            }
            else if (typeX == "piqure")
            {
                result = await dbConfig.getResultCommand("select *from article where type='piqure'");
            }
            else if (typeX == "Bandage")
            {
                result = await dbConfig.getResultCommand("select *from article where type='Bandage'");
            }
            else if (typeX == "Lait")
            {
                result = await dbConfig.getResultCommand("select *from article where type='Lait'");
            }
            else if (typeX == "Eau")
            {
                result = await dbConfig.getResultCommand("select *from article where type='Eau'");
            }
            else
            {

            }

            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["nom_du_produit"], result["prix"], result["quantite"], result["type"], result["fournisseur"], result["dateAjout"], result["dateExpiration"]);

                }
            }
            catch
            {

            }

        }
        public static async Task<int> saveArticle(ArticleM arti, BunifuDataGridView table, String DateAjout)
        {
            int rep = -1, nbr = -1;
            float Exquantite = 0;

            MySqlDataReader result = await dbConfig.getResultCommand("select count(*) as nbr from article where nom_du_produit='" + arti.Nom + "'");
            while (result.Read())
            {

                nbr = int.Parse(result["nbr"].ToString());
                // MessageBox.Show(" kk " + result["nbr"].ToString());
            }

            if (nbr == 0)
            {
                rep = await dbConfig.execute_command("insert into article(nom_du_produit,prix,quantite,idfournisseur,element,ref,numero,dateAjout,init_value) values('" + arti.Nom + "','" + arti.Prix + "','" + arti.Quantite + "','" + arti.IdFournisseur1 + "','"+arti.Element+"','"+arti.Reference+"','"+arti.Numero+"','" + DateAjout + "',"+arti.Quantite+")");

            }
            else if (nbr > 0)
            {
                if (MessageBox.Show("Ce produit existe deja! \n Voulez vous modifier la quantite de ce produit?", "Enregistrement de Produit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    result = await dbConfig.getResultCommand("select quantite from article where nom_du_produit='" + arti.Nom + "' ");
                    while (result.Read())
                    {
                        Exquantite = float.Parse(result["quantite"].ToString());
                    }

                    Exquantite += arti.Quantite;
                    rep = await dbConfig.execute_command("update article set quantite=" + Exquantite.ToString() + "  where nom_du_produit='" + arti.Nom + "'");

                }
            }
            else
            {

            }
            showArticle(table);
            return rep;
        }
        public static async Task<int> getArticleQuantite(String id)
        {
            int quantite = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select quantite from article where id=" + id);

            while (result.Read())
            {


                quantite = int.Parse(result["quantite"].ToString());

            }
            return quantite;
        }
        public static async Task<MySqlDataReader> getArticleSum()
        {
            MySqlDataReader result = await dbConfig.getResultCommand("select prix,quantite from article");
            return result;
        }
        public static async Task<string> GetIdByName(string productName)
        {
            string id = null;
            MySqlDataReader result = await dbConfig.getResultCommand("select prix from article where nom_du_produit='" + productName + "'");
            while (result.Read())
            {
                id = result["prix"].ToString();
            }
            return id;
        }
        public static async Task<AutoCompleteStringCollection> GetAllProductName()

        {
            AutoCompleteStringCollection ProductsName = new AutoCompleteStringCollection();
            MySqlDataReader result = await dbConfig.getResultCommand("select nom_du_produit from article");
            while (result.Read())
            {
                ProductsName.Add(result["nom_du_produit"].ToString());

            }
            result = await dbConfig.getResultCommand("select receiptNumber from vente");
            while (result.Read())
            {
                ProductsName.Add(result["receiptNumber"].ToString());

            }
            result = await dbConfig.getResultCommand("select clientName from vente");
            while (result.Read())
            {
                ProductsName.Add(result["clientName"].ToString());

            }
            //
            result = await dbConfig.getResultCommand("select service from services");
            while (result.Read())
            {
                ProductsName.Add(result["service"].ToString());

            }
            return ProductsName;
        }

        public static async Task<int> modifyArticle(ArticleM article, BunifuDataGridView table, String id)
        {
            string year, month, day, date_x;
            year = DateTime.Now.Year.ToString();
            month = DateTime.Now.Month.ToString();
            day = DateTime.Now.Day.ToString();
            date_x = year + "/" + month + "/" + day;
            int rep = await dbConfig.execute_command("update article set nom_du_produit='" + article.Nom + "',prix='" + article.Prix + "',quantite='" + article.Quantite + "',idfournisseur='" + article.IdFournisseur1 + "',dateAjout='" + date_x + "',ref='"+article.Reference+"',element='"+article.Element+"',numero="+article.Numero+ ",init_value="+article.Quantite+" where id=" + id);
            showArticle(table);
            return rep;
        }
        public static async Task<int> updateQuantite(string productName, int quantite)
        {
            return await dbConfig.execute_command("update article set quantite=" + quantite.ToString() + " where nom_du_produit='" + productName + "'");
        }
        public static async Task<int> deleteArticle(String id, BunifuDataGridView table)
        {
            int rep = await dbConfig.execute_command("delete from article where id=" + id + "");
            showArticle(table);
            return rep;
        }
        public static async void setArticleQuantite(float quantite, String nom_du_produit, string id, BunifuDataGridView table, string type)
        {
            MySqlDataReader result = await dbConfig.getResultCommand("select count('nom_du_produit') as nbr from article where nom_du_produit='" + nom_du_produit + "' and type='" + type + "'");
            try
            {
                while (result.Read())
                {

                    int i = int.Parse(result["nbr"].ToString());
                    if (i == 0)
                    {
                        MessageBox.Show("Ce produit a ete suprimer! \nImposible d'annule la vente");
                    }
                    else
                    {
                        int rep = await dbConfig.execute_command("update article set quantite=" + quantite + " where nom_du_produit='" + nom_du_produit + "' and type='" + type + "'");
                        deleteArticle(id, table);
                    }

                }
            }
            catch
            {

            }

        }
        public static async void searchArticle(String word, BunifuDataGridView table)
        {
            table.Rows.Clear();

            MySqlDataReader result = await dbConfig.getResultCommand("select * from article where id='" + word + "' or nom_du_produit= '" + word + "' or numero='"+word+"'");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["nom_du_produit"], result["prix"], result["quantite"], result["idfournisseur"], result["element"], result["ref"], result["numero"], result["dateAjout"],result["init_value"]);

                }
            }
            catch
            {

            }
        }
        public static async void ExpiredArticle(BunifuDataGridView table)
        {
            MySqlDataReader result;
            table.Rows.Clear();
            string year, month, day, date_x;
            year = DateTime.Now.Year.ToString();
            month = DateTime.Now.Month.ToString();
            day = DateTime.Now.Day.ToString();
            date_x = year + "/" + month + "/" + day;
            result = await dbConfig.getResultCommand("select * from article where dateExpiration <'" + date_x + "'");
            while (result.Read())
            {

                table.Rows.Add(result["id"], result["nom_du_produit"], result["prix"], result["quantite"], result["type"], result["fournisseur"], result["dateAjout"], result["dateExpiration"],result["init_value"]);

            }
        }
        public static async Task<MySqlDataReader> getAllProducts()
        {
            MySqlDataReader result;


            return result = await dbConfig.getResultCommand("select *from article");
        }
        public static async void showArticle(BunifuDataGridView table)
        {
            MySqlDataReader result;
            table.Rows.Clear();

            result = await dbConfig.getResultCommand("select *from article");

            try
            {
                while (result.Read())
                {
                    //MessageBox.Show(result["dateAjout"].ToString());
                    table.Rows.Add(result["id"], result["nom_du_produit"], result["prix"], result["quantite"], result["idfournisseur"], result["element"], result["ref"], result["numero"], result["dateAjout"],result["init_value"]);

                }
            }
            catch
            {

            }

        }
    }
}
