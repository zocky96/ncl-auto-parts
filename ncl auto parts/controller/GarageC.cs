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
    internal class GarageC
    {
        public async static void searchFacture(String word, BunifuDataGridView table)
        {
            table.Rows.Clear();

            MySqlDataReader result = await dbConfig.getResultCommand("select * from fgarage where id='" + word + "' or clientName='" + word + "'");
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
        public static async Task<int> saveFacture(AutoPartM facture, BunifuDataGridView table)
        {
            int rep = await dbConfig.execute_command("insert into fgarage(clientName,service,devise,montant) values('" + facture.ClientName + "','" + facture.Service + "','" + facture.Devise + "'," + facture.Montant + ")");
            showFacture(table);
            return rep;
        }
        public async static void showGoodFacture(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from facture_garage");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["clientName"], result["service"], result["montant"], result["devise"], result["no_recu"], result["date"], result["user"]);

                }
            }
            catch
            {

            }
        }
        public async static void searchGoodFacture(BunifuDataGridView table, string id)
        {
            table.Rows.Clear();
            if (id == "")
            {
                MySqlDataReader result = await dbConfig.getResultCommand("select *from facture_garage");
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
            else
            {
                MySqlDataReader result = await dbConfig.getResultCommand("select *from facture_garage where no_recu='" + id + "'");
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
            int rep = await dbConfig.execute_command("delete from facture_garage where no_recu='" + id + "'");
            //showFacture(table);
            return rep;
        }
        public static async Task<int> saveGoodFacture(AutoPartM facture, string receiptId, BunifuDataGridView table)
        {
            string date;

            date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            int rep = await dbConfig.execute_command("insert into facture_garage(clientName,service,devise,montant,no_recu,date,user) values('" + facture.ClientName + "','" + facture.Service + "','" + facture.Devise + "'," + facture.Montant + ",'" + receiptId + "','" + date + "','"+main.userName+"')");
            showFacture(table);
            return rep;
        }

        public static async Task<int> modifyFacture(AutoPartM facture, BunifuDataGridView table, String id)
        {

            int rep = await dbConfig.execute_command("update fgarage set clientName='" + facture.ClientName + "',service='" + facture.Service + "',devise='" + facture.Devise + "',montant=" + facture.Montant + " where id='" + id + "'");
            showFacture(table);
            return rep;
        }

        public static async Task<int> deleteFacture(BunifuDataGridView table, String id)
        {
            int rep = await dbConfig.execute_command("delete from fgarage where id='" + id + "'");
            showFacture(table);
            return rep;
        }
        public static async Task<int> cleanFacture(BunifuDataGridView table)
        {
            int rep = await dbConfig.execute_command("delete from fgarage ");
            showFacture(table);
            return rep;
        }
        public static async Task<MySqlDataReader> getFacture()
        {
            MySqlDataReader result = await dbConfig.getResultCommand("select * from fgarage");
            return result;
        }
        public static async Task<MySqlDataReader> getGoodFacture(string id)
        {
            MySqlDataReader result = await dbConfig.getResultCommand("select * from facture_garage where no_recu='" + id + "'");
            return result;
        }
        public async static void showFacture(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from fgarage");
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
    }
}
