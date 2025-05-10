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
    internal class ProformaC
    {
        public static async void clearProforma(BunifuDataGridView table)
        {
            dbConfig db = new dbConfig();
            int rep = await dbConfig.execute_command("delete from proforma");
            Label l = new Label();
            showProforma(table);
        }
       
        public static async Task<ProformaM> getPersonalInfo()
        {
            int i = 0;
           ProformaM proforma = null;
            MySqlDataReader result = await dbConfig.getResultCommand("select clientName,carName,plaque,phone,date from proforma");
            while (result.Read())
            {
                if (i == 0)
                {
                    proforma=new ProformaM(result["clientName"].ToString(), result["carName"].ToString(), result["plaque"].ToString(), result["phone"].ToString(), result["date"].ToString(),"",0,0,0);
                }
                i += 1;
            }
            return proforma;
        }
        public static async Task<bool> ifTableEmpty()
        {
            bool empty = true;
            MySqlDataReader result = await dbConfig.getResultCommand("select count(*) as nbr from proforma");
            while (result.Read())
            {
                int nbr = int.Parse(result["nbr"].ToString());
                if(nbr == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return empty;
        }
        public static async Task<string> getArticleSum()
        {
            float sum = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select price,quantite from proforma");
            while (result.Read())
            {
                sum +=float.Parse(result["price"].ToString())*float.Parse(result["quantite"].ToString());
            }
            return sum.ToString();
        }
        public static async void deleteProforma(BunifuDataGridView table,string id)
        {
            dbConfig db = new dbConfig();
            int rep = await dbConfig.execute_command("delete from proforma where id ='"+id+"'");
            Label l = new Label();
            showProforma(table);
        }
        public static async Task<int> saveProforma(ProformaM proforma, BunifuDataGridView table)
        {
             
            int rep = await dbConfig.execute_command("insert into proforma(clientName,carName,plaque,phone,date,description,quantite,price,total) values('" + proforma.ClientName+"','"+proforma.CarName+"','"+proforma.Plaque+"','"+proforma.Phone+"','"+proforma.Date+"','"+proforma.Description+"',"+proforma.Quantite+","+proforma.Price+","+proforma.Total+")");
            Label l=new Label();
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
