using Bunifu.UI.WinForms;
using MySql.Data.MySqlClient;
using ncl_auto_parts.db;
using ncl_auto_parts.model;
using ncl_auto_parts.screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ncl_auto_parts.controller
{
    internal class VenteC
    {
        public async static void searchVente(String word, BunifuDataGridView table)
        {
            table.Rows.Clear();

            MySqlDataReader result = await dbConfig.getResultCommand("select * from vente where id='" + word + "' or nom_du_produit= '" + word + "' or date='" + word + "' or signature_autorise='" + word + "'or receiptNumber='" + word + "' or clientName='"+word+"'");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["nom_du_produit"], result["prix"], result["quantite"], result["total"], result["date"], result["signature_autorise"], result["receiptNumber"], result["clientName"], result["devise"]);

                }
            }
            catch
            {

            }
        }
        public static async Task<float> getAllVenteOnReportViewer(string de, string a, BunifuDataGridView table)
        {
            float total = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select * from vente where date >= '" + de + "' and date <='" + a + "'");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["clientName"], result["nom_du_produit"], result["prix"], result["quantite"], result["total"], result["date"], result["signature_autorise"], result["type"], result["receiptNumber"]);
                    total += float.Parse(result["prix"].ToString()) * float.Parse(result["quantite"].ToString());
                }
            }
            catch
            {

            }
            return total;
        }
        public async static Task<int> deleteVente(string receiptNumber, BunifuDataGridView table)
        {
            int rep = await dbConfig.execute_command("delete from vente where receiptNumber='" + receiptNumber + "'");

             showVente(table);
            return rep;
        }
       
        public static async Task<MySqlDataReader> getSaleByReceiptNumber(string receipt)
        {
            MySqlDataReader result = await dbConfig.getResultCommand("select * from vente where receiptNumber='" + receipt + "'");
            return result;
        }
        public async static void showVente(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select * from vente");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["nom_du_produit"], result["prix"], result["quantite"], result["total"], result["date"], result["signature_autorise"], result["receiptNumber"], result["clientName"], result["devise"]);

                }
            }
            catch
            {

            }
        }
        public static async Task<bool> ifReceiptIdExist(string id)
        {
            bool rep = false;
            MySqlDataReader result = await dbConfig.getResultCommand("select count(*) as nbr from vente where receiptNumber='" + id + "'");
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
        public static async Task<AutoCompleteStringCollection> GetAllVente_()

        {
            AutoCompleteStringCollection ProductsName = new AutoCompleteStringCollection();
            MySqlDataReader result = await dbConfig.getResultCommand("select nom_du_produit from vente");
            while (result.Read())
            {
                ProductsName.Add(result["nom_du_produit"].ToString());

            }
            return ProductsName;
        }
        public static async Task<MySqlDataReader> getAllVente(string datee)
        {
            MySqlDataReader result = await dbConfig.getResultCommand("select * from vente where date='" + datee + "'");
            // MessageBox.Show("select * from vente where date='" + datee + "'");
            return result;
        }


        public static async Task<MySqlDataReader> getAllVenteV(string de, string a)
        {
            MySqlDataReader result = await dbConfig.getResultCommand("select * from vente where date >='" + de + "' and date <='" + a + "' and type!='service'");
            // MessageBox.Show("select * from vente where date='" + datee + "'");
            return result;
        }
        public static async Task<int> IfProductExist(string productName)
        {
            int quantite = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select count(*) as nbr from article where nom_du_produit='" + productName + "'");
            while (result.Read())
            {
                quantite = int.Parse(result["nbr"].ToString());
            }
            return quantite;
        }
        public static async Task<VenteM> getPriceAndQuantite(String nom_du_produit)
        {
            int rep, quantite = -100;
            float prix = -100;
            string devise = null;
            MySqlDataReader result = await dbConfig.getResultCommand("select prix,quantite from article where nom_du_produit='" + nom_du_produit + "'");
            while (result.Read())
            {
                prix = float.Parse(result["prix"].ToString());
                quantite = int.Parse(result["quantite"].ToString());
               
            }
           
            VenteM vente = new VenteM(nom_du_produit, "0", main.userName, "0", "0", devise, prix, 0, quantite, 0, 0);
            //showArticle(table);
            return vente;
        }
        public static async void cancelVente(String id, String nomProduit, BunifuDataGridView table, int quantite, string receipt,string devise)
        {
            
            int rep = await IfProductExist(nomProduit);
            if (rep == 0)
            {
                MessageBox.Show("Impossible d'annuler la vente!\nCe produit a ete efface");
            }
            else
            {
                float total = 0;
                VenteM vente = null;
                MySqlDataReader result = await dbConfig.getResultCommand("select *from vente where receiptNumber='"+receipt+"'");
                int response=-1;
                try
                {
                    string date;
                   
                    date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
                    while (result.Read())
                    {
                        dbConfig.execute_command("insert into canceledvente(nom_du_produit,prix,quantite,total,signature_autorise,date,receiptNumber,clientName,devise) values('" + result["nom_du_produit"].ToString() +"',"+float.Parse(result["prix"].ToString()) +","+int.Parse(result["quantite"].ToString()) +","+float.Parse(result["total"].ToString()) +",'"+main.userName+"','"+ date + "','"+receipt+"','"+ result["clientName"].ToString() + "','"+ result["devise"].ToString() + "')");
                        vente = await getPriceAndQuantite(result["nom_du_produit"].ToString());
                        int newQuantite = int.Parse(vente.Quantite.ToString()) + quantite;
                        response = await updateQuantite(vente.NomDuProduit, newQuantite);
                    }
                    if (response == 0)
                    {
                      
                        if (devise == "HTG")
                        {
                            float money = vente.Prix * quantite;
                            
                            RemoveHtgMoney(money);
                        }
                        else
                        {
                            float money = vente.Prix * quantite;
                            RemoveUsMoney(money);
                        }
                        deleteVente(receipt, table);
                        getArticleSum();
                        MessageBox.Show("Vente annulée avec succes");
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la suppression");
                    }
                }
                catch
                {

                }
                //------------------------------------
                
                // MessageBox.Show(newQuantite.ToString());
            }

        }
        public static async Task<int> getMaxId()
        {
            int id = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select max(id) as maxid from vente");
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
        public static async void getArticleSum()
        {
            //float prix, somme = 0;
            //int quantite;

            //MySqlDataReader result = await VenteV.getArticleSum();
            //while (result.Read())
            //{

            //    prix = float.Parse(result["prix"].ToString());
            //    quantite = int.Parse(result["quantite"].ToString());
            //    somme += (prix * quantite);

            //}

            //main.theSum_.Text = somme.ToString() + " $";

        }
        public static async Task<int> updateQuantite(string productName, int quantite)
        {
            return await dbConfig.execute_command("update article set quantite=" + quantite.ToString() + " where nom_du_produit='" + productName + "'");
        }
        public static async Task<int> AddUsMoney(float money)
        {
            float amount = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select amount from account_us");
            while (result.Read())
            {
                try
                {
                    amount = float.Parse(result["amount"].ToString());  
                }
                catch
                {
                    
                }
            }
            amount += money;
            int rep = await dbConfig.execute_command("update account_us set amount ="+amount+" where id=1");
            return rep;         
        }
        public static async Task<int> AddHtgMoney(float money)
        {
            float amount = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select amount from account_htg");
            while (result.Read())
            {
                try
                {
                    amount = float.Parse(result["amount"].ToString());
                }
                catch
                {

                }
            }
            
            amount += money;
            
            int rep = await dbConfig.execute_command("update account_htg set amount =" + amount + " where id=1");
            return rep;
        }
        //--------------
        public static async Task<int> RemoveUsMoney(float money)
        {
            float amount = 0;
            int rep = -1;
            
            MySqlDataReader result = await dbConfig.getResultCommand("select amount from account_us");
            while (result.Read())
            {
                try
                {
                    amount = float.Parse(result["amount"].ToString());
                }
                catch
                {

                }
            }
            if (amount > money)
            {
             
                amount -= money;
                
                rep = await dbConfig.execute_command("update account_us set amount =" + amount + " where id=1");
            }
            else
            {
                MessageBox.Show("Nous n'avons pas assez de credit");
            }
            
            return rep;
        }
        public static async Task<int> RemoveHtgMoney(float money)
        {
            float amount = 0;
            int rep = 1;
            MySqlDataReader result = await dbConfig.getResultCommand("select amount from account_htg");
            while (result.Read())
            {
                try
                {
                    amount = float.Parse(result["amount"].ToString());
                }
                catch
                {

                }
            }
            if (amount > money)
            {
                amount -= money;
                rep = await dbConfig.execute_command("update account_htg set amount =" + amount + " where id=1");
            }
            else
            {
                MessageBox.Show("Nous n'avons pas assez de credit");
            }
            return rep;
        }
        public static async Task<int> vendre(String nom_du_produit, int quantite, BunifuDataGridView table, String receiptNumber, string clientName,string devise)
        {
            int rep = await IfProductExist(nom_du_produit);
            if (rep == 0)
            {
                MessageBox.Show("Nous avons pas ce produit en stock");
            }
            else
            {
                VenteM vente = await getPriceAndQuantite(nom_du_produit);
                
                if (vente.Quantite < quantite)
                {
                    MessageBox.Show("Nous avons pas cette quantite de produit");
                }
                else
                {
                    int quantiteRestante = vente.Quantite - quantite;
                    
                    int response = await updateQuantite(nom_du_produit, quantiteRestante);

                   
                    if (response == 0)
                    {
                        float total = 0, prix_db = float.Parse(vente.Prix.ToString());
                        total = quantite * vente.Prix;
             
                        string year, month, day, date;
                        year = DateTime.Now.Year.ToString();
                        month = DateTime.Now.Month.ToString();
                        day = DateTime.Now.Day.ToString();
                        date = year + "/" + month + "/" + day;

                        //vente.setQuantite(quantite);
                        rep = await dbConfig.execute_command("insert into vente(nom_du_produit,prix,quantite,total,date,signature_autorise,receiptNumber,clientName,devise) values('" + vente.NomDuProduit+"',"+vente.Prix+","+quantite+","+total+",'"+date+"','"+main.userName+"','"+receiptNumber+"','"+clientName+"','"+devise+"')");
                        if (devise == "HTG")
                        {
                            AddHtgMoney(total);
                        }
                        else
                        {
                            AddUsMoney(total);
                        }
                        //MessageBox.Show("Vente effectue avec succes");
                        //main.closeConn();
                        //showVente(table);

                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'enregistrement");
                    }




                }
            }



            return rep;



        }
        //---------------------------------------------------------------------------
        public static async Task<int> RemoveHtgMoneyGarage(float money)
        {
            float amount = 0;
            int rep = 1;
            MySqlDataReader result = await dbConfig.getResultCommand("select amount from account_htg_garage");
            while (result.Read())
            {
                try
                {
                    amount = float.Parse(result["amount"].ToString());
                }
                catch
                {

                }
            }
            if (amount > money)
            {
                amount -= money;
                rep = await dbConfig.execute_command("update account_htg_garage set amount =" + amount + " where id=1");
            }
            else
            {
                MessageBox.Show("Nous n'avons pas assez de credit");
            }
            return rep;
        }
        public static async Task<int> RemoveUsMoneyGarage(float money)
        {
            float amount = 0;
            int rep = 1;
            MySqlDataReader result = await dbConfig.getResultCommand("select amount from account_us_garage");
            while (result.Read())
            {
                try
                {
                    amount = float.Parse(result["amount"].ToString());
                }
                catch
                {

                }
            }
            if (amount > money)
            {
                amount -= money;
                rep = await dbConfig.execute_command("update account_us_garage set amount =" + amount + " where id=1");
            }
            else
            {
                MessageBox.Show("Nous n'avons pas assez de credit");
            }
            return rep;
        }
        public static async Task<int> AddUsMoneyGarage(float money)
        {
            float amount = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select amount from account_us_garage");
            while (result.Read())
            {
                try
                {
                    amount = float.Parse(result["amount"].ToString());
                }
                catch
                {

                }
            }
            amount += money;
            int rep = await dbConfig.execute_command("update account_us_garage set amount =" + amount + " where id=1");
            return rep;
        }
        public static async Task<int> AddHTGMoneyGarage(float money)
        {
            float amount = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select amount from account_htg_garage");
            while (result.Read())
            {
                try
                {
                    amount = float.Parse(result["amount"].ToString());
                }
                catch
                {

                }
            }
            amount += money;
            int rep = await dbConfig.execute_command("update account_htg_garage set amount =" + amount + " where id=1");
            return rep;
        }
    }
}
