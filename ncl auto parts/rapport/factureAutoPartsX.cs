using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using ncl_auto_parts.db;
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
    public partial class factureAutoPartsX : Form
    {
        string de, a;
        public factureAutoPartsX(string de,string a)
        {
            InitializeComponent();
            this.de = de;
            this.a = a;
        }

        private async void factureAutoPartsX_Load(object sender, EventArgs e)
        {
            FactureData vente = new FactureData();
            MySqlConnection connection = await dbConfig.connection();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select *,(SELECT SUM(total) as r FROM (SELECT no_recu, MIN(total) AS total FROM facture_auto where date>='"+de+"' and date<='"+a+ "' and devise='US' GROUP BY no_recu) AS une_vente_par_recu) as total_us,(SELECT SUM(total) as r FROM (SELECT no_recu, MIN(total) AS total FROM facture_auto where date>='"+de+"' and date<='"+a+"' and devise='HTG' GROUP BY no_recu) AS une_vente_par_recu) as total_htg from facture_auto where date >='" + de + "' and date<='" + a + "'", connection);
            dataAdapter.Fill(vente, vente.Tables[0].TableName);
            ReportDataSource rds = new ReportDataSource("oneFacture", vente.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            connection.Close();
            this.reportViewer1.RefreshReport();
        }
    }
}
