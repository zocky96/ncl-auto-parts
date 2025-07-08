using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using ncl_auto_parts.db;
using ncl_auto_parts.model;
using ncl_auto_parts.viewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ncl_auto_parts.rapport
{
    public partial class rapportGarage : Form
    {
        string de, a;
        public rapportGarage(string de,string a)
        {
            InitializeComponent();
            this.de = de;
            this.a = a;

        }
        private async Task<List<Money>> getTotal()
        {
            var tot = new List<Money>();
            float total_gds_ = 0, total_dollar_ = 0, total_dette_gds_ = 0, total_dette_dollar_ = 0;
            MySqlDataReader result = await dbConfig.getResultCommand("select *,(SELECT SUM(total) as r FROM (SELECT no_recu, MIN(total) AS total FROM facture_garage where date>='" + de + "' and date<='" + a + "' and devise='US' GROUP BY no_recu) AS une_vente_par_recu) as total_us,(SELECT SUM(total) as r FROM (SELECT no_recu, MIN(total) AS total FROM facture_garage where date>='" + de + "' and date<='" + a + "' and devise='HTG' GROUP BY no_recu) AS une_vente_par_recu) as total_htg from facture_garage where date >='" + de + "' and date<='" + a + "' group by no_recu");
            try
            {
                while (result.Read())
                {
                    if(result["statut"].ToString() == "paye")
                    {
                        if(result["devise"].ToString() == "US")
                        {
                            total_dollar_ += float.Parse(result["total"].ToString());
                        }

                        if (result["devise"].ToString() == "HTG")
                        {
                            total_gds_ += float.Parse(result["total"].ToString());
                        }
                    }

                    else if (result["statut"].ToString() == "avance")
                    {
                        if (result["devise"].ToString() == "US")
                        {
                            total_dollar_ += float.Parse(result["avance"].ToString());
                            total_dette_dollar_ += float.Parse(result["dette"].ToString());
                        }


                        if (result["devise"].ToString() == "HTG")
                        {
                            total_gds_ += float.Parse(result["avance"].ToString());
                            //MessageBox.Show(total_gds_.ToString());
                            total_dette_gds_ += float.Parse(result["dette"].ToString());
                        }
                    }

                    else if (result["statut"].ToString() == "non paye")
                    {
                        if (result["devise"].ToString() == "US")
                        {
                            total_dette_dollar_ += float.Parse(result["dette"].ToString());
                        }
                        if (result["devise"].ToString() == "HTG")
                        {
                            total_dette_gds_ += float.Parse(result["dette"].ToString());
                        }
                    }

                }
                tot.Add(new Money
                {
                    D_dollar = total_dette_dollar_,
                    D_gds = total_dette_gds_,
                    All_dollar = total_dollar_,
                    All_gds = total_gds_
                }) ;
            }
            catch
            {

            }
            return tot;
        }
        private async void rapportGarage_Load(object sender, EventArgs e)
        {
            List<MyDate> tot = new List<MyDate>();
            tot.Add(new MyDate
            {
                theDate = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString()
            });
            FactureData vente = new FactureData();
            var totaux = await getTotal();
            MySqlConnection connection = await dbConfig.connection();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select *,(SELECT SUM(total) as r FROM (SELECT no_recu, MIN(total) AS total FROM facture_garage where date>='"+de+"' and date<='"+a+ "' and devise='US' GROUP BY no_recu) AS une_vente_par_recu) as total_us,(SELECT SUM(total) as r FROM (SELECT no_recu, MIN(total) AS total FROM facture_garage where date>='"+de+"' and date<='"+a+"' and devise='HTG' GROUP BY no_recu) AS une_vente_par_recu) as total_htg from facture_garage where date >='" + de + "' and date<='"+a+"'", connection);
            dataAdapter.Fill(vente, vente.Tables[0].TableName);
            ReportDataSource rds = new ReportDataSource("oneFacture", vente.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("total",totaux));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Date", tot));
            //reportViewer1.LocalReport.SetParameters(new ReportParameter("goodDate", DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString()));
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            connection.Close();
            this.reportViewer1.RefreshReport();
            
        }
    }
}
