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
    internal class AutoPartC
    {
        public async static Task<float> getSumPrice()
        {
            float sumPrice = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select montant,quantite  from fauto_part");
            while (result.Read())
            {
                sumPrice += float.Parse(result["montant"].ToString()) * int.Parse(result["quantite"].ToString());
            }
            return sumPrice;
        }
        public async static Task<float> getPay()
        {
            float sumPrice = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select pay as amount from fauto_part");
            while (result.Read())
            {
                sumPrice = float.Parse(result["amount"].ToString());
                break;
            }
            return sumPrice;
        }
        public async static Task<float> getDiscount()
        {
            float sumPrice = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select discount as amount from fauto_part");
            while (result.Read())
            {
                sumPrice = float.Parse(result["amount"].ToString());
                break;
            }
            return sumPrice;
        }
        public async static Task<float> getAvance()
        {
            float sumPrice = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select avance as amount from fauto_part");
            while (result.Read())
            {
                sumPrice = float.Parse(result["amount"].ToString());
                break;
            }
            return sumPrice;
        }
        public async static void searchFacture(String word, BunifuDataGridView table)
        {
            table.Rows.Clear();

            MySqlDataReader result = await dbConfig.getResultCommand("select * from fauto_part where id='" + word + "' or clientName='" + word + "'");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["clientName"], result["service"], result["montant"], result["devise"]);

                }
            }
            catch
            {

            }
        }
        public static async Task<int> saveFacture(AutoPartM facture, BunifuDataGridView table, float discount, float avance, string statut, string payment, string comment, string id_auto, float pay)
        {
            int rep = await dbConfig.execute_command("insert into fauto_part(clientName,service,devise,montant,car_name,plaque,description,quantite,total,discount,avance,statut,payment,comment,id_auto,pay) values('" + facture.ClientName + "','" + facture.Service + "','" + facture.Devise + "'," + facture.Prix + ",'" + facture.CarName + "','" + facture.Plaque + "','" + facture.Description + "'," + facture.Quantite + "," + facture.Total + "," + discount + "," + avance + ",'" + statut + "','" + payment + "','" + comment + "','" + id_auto + "'," + pay + ")");
            showFacture(table);
            return rep;
        }
        public async static void filterGoodFacture(BunifuDataGridView table,string word)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from facture_auto where statut='"+word+"'");
            try
            {
                while (result.Read())
                {
                    table.Rows.Add(result["id"], result["clientName"], result["service"], result["montant"], result["quantite"], result["discount"], result["avance"], result["comment"], result["total"], result["statut"], result["payment"], result["id_auto"], result["pay"], result["devise"], result["no_recu"], result["date"], result["user"]);

                }
            }
            catch
            {

            }
        }
        public async static void showGoodFacture(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from facture_auto order by id desc");
            try
            {
                while (result.Read())
                {
                    table.Rows.Add(result["id"], result["clientName"], result["service"], result["montant"], result["quantite"],result["discount"], result["avance"], result["comment"], result["total"], result["statut"], result["payment"], result["id_auto"], result["pay"], result["devise"], result["no_recu"], result["date"], result["user"]);

                }
            }
            catch
            {

            }
        }
        public async static void searchGoodFacture(BunifuDataGridView table,string id)
        {
            table.Rows.Clear();
            if (id == "")
            {
                MySqlDataReader result = await dbConfig.getResultCommand("select *from facture_auto");
                try
                {
                    while (result.Read())
                    {
                        table.Rows.Add(result["id"], result["clientName"], result["service"], result["montant"], result["quantite"],result["discount"], result["avance"], result["comment"], result["total"], result["statut"], result["payment"], result["id_auto"], result["pay"], result["devise"], result["no_recu"], result["date"], result["user"]);

                    }
                }
                catch
                {

                }
            }
            else
            {
                MySqlDataReader result = await dbConfig.getResultCommand("select *from facture_auto where no_recu='" + id + "'");
                try
                {
                    while (result.Read())
                    {

                        table.Rows.Add(result["id"], result["clientName"], result["service"], result["montant"], result["devise"], result["no_recu"], result["date"]);

                    }
                }
                catch
                {

                }
            }
            
        }
        public static async Task<int> deleteGoodFacture(BunifuDataGridView table, String id)
        {
            int rep = await dbConfig.execute_command("delete from facture_auto where no_recu='" + id + "'");
            showFacture(table);
            return rep;
        }
        public static async Task<int> saveGoodFacture(AutoPartM facture, string receiptId, BunifuDataGridView table, float discount, float avance, string comment, string statut, string payment, string id_auto, float pay)
        {
            string date;

            date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            int rep = await dbConfig.execute_command("insert into facture_auto(clientName,service,devise,montant,no_recu,date,user,car_name,plaque,phone,description,quantite,total,discount,avance,comment,statut,payment,id_auto,pay) values('" + facture.ClientName + "','" + facture.Service + "','" + facture.Devise + "'," + facture.Prix + ",'" + receiptId + "','" + date + "','" + main.userName + "','" + facture.CarName + "','" + facture.Plaque + "','" + facture.Phone + "','" + facture.Description + "'," + facture.Quantite + "," + facture.Total + "," + discount + "," + avance + ",'" + comment + "','" + statut + "','" + payment + "','" + id_auto + "'," + pay + ")");
            showFacture(table);
            return rep;
        }
        public static async Task<bool> ifReceiptIdExist(string id)
        {
            bool rep = false;
            MySqlDataReader result = await dbConfig.getResultCommand("select count(*) as nbr from facture_auto where no_recu='" + id + "'");
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
            MySqlDataReader result = await dbConfig.getResultCommand("select max(id) as maxid from facture_auto");
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
            main.closeConn();



            return id;
        }
        public static async Task<int> modifyFacture(AutoPartM facture, BunifuDataGridView table, String id)
        {
            
            int rep = await dbConfig.execute_command("update fauto_part set clientName='" + facture.ClientName + "',service='" + facture.Service + "',devise='" + facture.Devise + "',montant=" + facture.Prix + " where id='" + id + "'");
            showFacture(table);
            return rep;
        }

        public static async Task<int> deleteFacture(BunifuDataGridView table, String id)
        {
            int rep = await dbConfig.execute_command("delete from fauto_part where id='" + id + "'");
            showFacture(table);
            return rep;
        }
        public static async Task<int> cleanFacture(BunifuDataGridView table)
        {
            int rep = await dbConfig.execute_command("delete from fauto_part ");
            showFacture(table);
            return rep;
        }
        public static async Task<MySqlDataReader> getFacture()
        {
            MySqlDataReader result = await dbConfig.getResultCommand("select * from fauto_part");
            return result;
        }
        public static async Task<MySqlDataReader> getGoodFacture(string id)
        {
            MySqlDataReader result = await dbConfig.getResultCommand("select * from facture_auto where no_recu='"+id+"'");
            return result;
        }
        public async static void showFacture(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from fauto_part order by id desc");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["clientName"], result["service"], result["description"], result["montant"], result["quantite"],result["discount"], result["avance"], result["pay"], result["statut"], result["payment"], result["devise"]);

                }
            }
            catch
            {

            }
        }
    }
}
