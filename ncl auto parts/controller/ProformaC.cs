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
    internal class ProformaC
    {
        public static async void clearProforma(BunifuDataGridView table)
        {
            dbConfig db = new dbConfig();
            int rep = await dbConfig.execute_command("delete from proforma");
            showProforma(table);
        }
        public static async void deleteProforma(BunifuDataGridView table,string id)
        {
            dbConfig db = new dbConfig();
            int rep = await dbConfig.execute_command("delete from proforma where id ='"+id+"'");
            showProforma(table);
        }
        public static async Task<int> saveProforma(ProformaM proforma, BunifuDataGridView table)
        {
             
            int rep = await dbConfig.execute_command("insert into proforma(clientName,carName,plaque,phone,date,description,quantite,price,total) values('" + proforma.ClientName+"','"+proforma.CarName+"','"+proforma.Plaque+"','"+proforma.Phone+"','"+proforma.Date+"','"+proforma.Description+"',"+proforma.Quantite+","+proforma.Price+","+proforma.Total+")");
            showProforma(table);
            return rep;
        }
        public static async void showProforma(BunifuDataGridView table)
        {

            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from proforma");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["clientName"], result["description"], result["quantite"], result["price"], result["total"]);

                }
            }
            catch
            {

            }

        }
    }
}
