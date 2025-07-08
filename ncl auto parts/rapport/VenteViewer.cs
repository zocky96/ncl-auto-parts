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
    public partial class VenteViewer : Form
    {
        string de, a;
        public VenteViewer(string de,string a)
        {
            InitializeComponent();
            this.de = de;
            this.a = a;
        }

        private async void VenteViewer_Load(object sender, EventArgs e)
        {
            List<MyDate> tot = new List<MyDate>();
            tot.Add(new MyDate
            {
                theDate = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString()
            });

            FactureData vente = new FactureData();
            MySqlConnection connection = await dbConfig.connection();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(" select *,(select sum(total) from vente where date>='"+de+"' and date<='"+a+ "' and devise='US') as total_us,(select sum(total) from vente where date>='" + de + "' and date<='" + a + "' and devise='HTG') as total_htg,(select init_value from article where nom_du_produit=vente.nom_du_produit) as init_value,(select quantite from article where nom_du_produit=vente.nom_du_produit) as dispo,(select init_value - quantite from article where nom_du_produit=vente.nom_du_produit) as quantite_vendu from vente where date >='" + de+"' and date<='"+a+ "' group by nom_du_produit", connection);
            dataAdapter.Fill(vente, vente.Tables[0].TableName);
            ReportDataSource rds = new ReportDataSource("Vente", vente.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Date", tot));
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            connection.Close();
            
        }
    }
}
