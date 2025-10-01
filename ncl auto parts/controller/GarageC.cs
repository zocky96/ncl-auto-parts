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
        public async static Task<float> getDette()
        {
            float dette = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select old_dette  from fgarage");
            while (result.Read())
            {
                dette = float.Parse(result["old_dette"].ToString());
            }
            return dette;
        }
        public static async Task<Boolean> ifReceiptExist()
        {
            int nbr = 0;
            Boolean exist = false;
            MySqlDataReader result = await dbConfig.getResultCommand("select count(*) as nbr from fgarage where no_recu!=''");
            while (result.Read())
            {
                nbr = int.Parse(result["nbr"].ToString());
            }
            if (nbr > 0)
            {
                exist = true;
            }
            return exist;
        }
        public static async Task<bool> isFactureEmptyMain()
        {
            bool rep = true;
            MySqlDataReader result = await dbConfig.getResultCommand("select count(*) as nbr from fgarage");
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
        public async static Task<string> getDevise()
        {
            string sumPrice = null;
            MySqlDataReader result = await dbConfig.getResultCommand("select devise as amount from fgarage");
            while (result.Read())
            {
                sumPrice = result["amount"].ToString();
            }
            return sumPrice;
        }
        public static async Task<MySqlDataReader> getFactureSimple()
        {
            MySqlDataReader result = await dbConfig.getResultCommand("select * from fgarage where no_recu IS NULL");
            return result;
        }
        public static async Task<float> getOLdTotal()
        {
            float total = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select old_total as nbr from fgarage where no_recu!=''");
            while (result.Read())
            {
                total = float.Parse(result["nbr"].ToString());

            }
            return total;
        }
        public static async Task<string> getNo_recu()
        {
            bool rep = true;
            string no_recu = null;
            MySqlDataReader result = await dbConfig.getResultCommand("select no_recu as nbr from fgarage where no_recu!=''");
            while (result.Read())
            {
                no_recu = result["nbr"].ToString();

            }
            return no_recu;
        }
        public static async Task<bool> isFactureEmpty()
        {
            bool rep = true;
            MySqlDataReader result = await dbConfig.getResultCommand("select count(*) as nbr from fgarage where no_recu IS NOT NULL");
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
        public static async Task<int> cleanFactureSimple()
        {
            return await dbConfig.execute_command("delete from fgarage "); ;
        }
        public static async Task<int> saveFactureSimple(AutoPartM facture, float discount, float avance, string statut, string payment, string comment, string id_auto, float pay, string no_recu, float old_total, float old_avance, float old_dette)
        {
            int rep = await dbConfig.execute_command("insert into fgarage(clientName,service,devise,montant,car_name,plaque,description,quantite,total,discount,avance,statut,payment,comment,id_auto,pay,no_recu,old_total,old_avance,old_dette,phone) values('" + facture.ClientName + "','" + facture.Service + "','" + facture.Devise + "'," + facture.Prix + ",'" + facture.CarName + "','" + facture.Plaque + "','" + facture.Description + "'," + facture.Quantite + "," + facture.Total + "," + discount + "," + avance + ",'" + statut + "','" + payment + "','" + comment + "','" + id_auto + "'," + pay + ",'" + no_recu + "'," + old_total + "," + old_avance + "," + old_dette + ",'"+facture.Phone+"')");

            return rep;
        }
        public async static void searchFacture(String word, BunifuDataGridView table)
        {
            table.Rows.Clear();

            MySqlDataReader result = await dbConfig.getResultCommand("select * from fgarage order by id desc  where id='" + word + "' or clientName='" + word + "'");
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
        public async static Task<float> getSumPrice()
        {
            float sumPrice = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select montant,quantite from fgarage");
            while (result.Read())
            {
                sumPrice += float.Parse(result["montant"].ToString()) * int.Parse(result["quantite"].ToString());
            }
            return sumPrice;
        }
        public async static Task<float> getPay()
        {
            float sumPrice = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select pay as amount from fgarage");
            while (result.Read())
            {
                sumPrice = float.Parse(result["amount"].ToString());
           
            }
            return sumPrice;
        }
        public async static Task<float> getDiscount()
        {
            float sumPrice = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select discount as amount from fgarage");
            while (result.Read())
            {
                sumPrice = float.Parse(result["amount"].ToString());
                
            }
            return sumPrice;
        }
        public async static Task<float> getAvance()
        {
            float sumPrice = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select avance as amount from fgarage");
            while (result.Read())
            {
                sumPrice = float.Parse(result["amount"].ToString());
                break;
            }
            return sumPrice;
        }
        public static async Task<int> saveFacture(AutoPartM facture, BunifuDataGridView table,float discount,float avance,string statut,string payment,string comment,string id_auto,float pay, string no, float old_total, float oldDette)
        {
            int rep = await dbConfig.execute_command("insert into fgarage(clientName,service,devise,montant,car_name,plaque,description,quantite,total,discount,avance,statut,payment,comment,id_auto,pay,phone,no_recu,old_total,old_dette) values('" + facture.ClientName + "','" + facture.Service + "','" + facture.Devise + "'," + facture.Prix + ",'"+facture.CarName+"','"+facture.Plaque+"','"+facture.Description+"',"+facture.Quantite+","+facture.Total+","+discount+","+avance+",'"+statut+"','"+payment+"','"+comment+"','"+id_auto+"',"+pay+",'"+facture.Phone+"','"+no+"',"+old_total+","+oldDette+")");
            showFacture(table);
            return rep;
        }
        public static async Task<int> modifyFacture(AutoPartM facture, BunifuDataGridView table, float discount, float avance, string statut, string payment, string comment, string id_auto, float pay,int id)
        {
            int rep = await dbConfig.execute_command("update fgarage set clientName='"+facture.ClientName+"',service='"+facture.Service+"',devise='"+facture.Devise+"',montant="+facture.Prix+",car_name='"+facture.ClientName+"',plaque='"+facture.Plaque+"',description='"+facture.Description+"',quantite="+facture.Quantite+",total="+facture.Total+",discount="+discount+",avance="+avance+",statut='"+statut+"',payment='"+payment+"',comment='"+comment+"',id_auto='"+id_auto+"',pay="+pay+",phone='"+facture.Phone+"' where id="+id+"");
            showFacture(table);
            return rep;
        }
        public async static void showGoodFacture(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand(" select *,(select sum(total) from facture_garage) as ok from facture_garage group by no_recu order by id desc");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["clientName"], result["service"], result["montant"], result["quantite"], result["dette"],result["discount"], result["avance"], result["comment"], result["total"], result["statut"], result["payment"], result["id_auto"], result["pay"], result["devise"], result["no_recu"], result["date"], result["user"]);

                }
            }
            catch
            {

            }
        }
        public async static void filterGoodFacture(BunifuDataGridView table,string word)         
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from facture_garage where statut='"+word+"'");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["clientName"], result["service"], result["montant"], result["quantite"], result["dette"], result["discount"], result["avance"], result["comment"], result["total"], result["statut"], result["payment"], result["id_auto"], result["pay"], result["devise"], result["no_recu"], result["date"], result["user"]);

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

                        table.Rows.Add(result["id"], result["clientName"], result["service"], result["montant"], result["quantite"],result["dette"],result["discount"], result["avance"], result["comment"], result["total"], result["statut"], result["payment"], result["id_auto"], result["pay"], result["devise"], result["no_recu"], result["date"], result["user"]);

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

                        table.Rows.Add(result["id"], result["clientName"], result["service"], result["montant"], result["discount"], result["avance"], result["comment"], result["total"], result["statut"], result["payment"], result["id_auto"], result["pay"], result["devise"], result["no_recu"], result["date"], result["user"]);

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
        public static async Task<bool> ifReceiptIdExist(string id)
        {
            bool rep = false;
            MySqlDataReader result = await dbConfig.getResultCommand("select count(*) as nbr from facture_garage where no_recu='" + id + "'");
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
            MySqlDataReader result = await dbConfig.getResultCommand("select max(id) as maxid from facture_garage");
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
        public static async Task<int> saveGoodFacture(AutoPartM facture, string receiptId, BunifuDataGridView table,float discount,float avance,string comment,string statut,string payment,string id_auto,float pay)
        {
            string date;

            date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            int rep = await dbConfig.execute_command("insert into facture_garage(clientName,service,devise,montant,no_recu,date,user,car_name,plaque,phone,description,quantite,total,discount,avance,comment,statut,payment,id_auto,pay) values('" + facture.ClientName + "','" + facture.Service + "','" + facture.Devise + "'," + facture.Prix + ",'" + receiptId + "','" + date + "','" + main.userName + "','" + facture.CarName + "','" + facture.Plaque + "','" + facture.Phone + "','" + facture.Description + "'," + facture.Quantite + "," + facture.Total + ","+discount+","+avance+",'"+comment+"','"+statut+"','"+payment+"','"+id_auto+"',"+pay+")");
            showFacture(table);
            return rep;
        }

        public static async Task<int> modifyFacture(AutoPartM facture, BunifuDataGridView table, String id)
        {

            int rep = await dbConfig.execute_command("update fgarage set clientName='" + facture.ClientName + "',service='" + facture.Service + "',devise='" + facture.Devise + "',montant=" + facture.Prix + " where id='" + id + "'");
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
            MySqlDataReader result = await dbConfig.getResultCommand("select *from fgarage order by id desc");
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
