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
    public partial class oneFacture : Form
    {
        string id = null, page = null;
        public oneFacture(string id, string page)
        {
            InitializeComponent();
            this.id = id;
            this.page = page;
        }

        private async void oneFacture_Load(object sender, EventArgs e)
        {
            if (page == "auto")
            {
                FactureData vente = new FactureData();
                MySqlConnection connection = await dbConfig.connection();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select *,montant * quantite as goodTotal from facture_auto where no_recu='" + id + "'", connection);
                dataAdapter.Fill(vente, vente.Tables[0].TableName);
                ReportDataSource rds = new ReportDataSource("oneFacture", vente.Tables[0]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);

                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
                connection.Close();
            }
            else
            {
                FactureData vente = new FactureData();
                MySqlConnection connection = await dbConfig.connection();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select *,montant * quantite as goodTotal from facture_garage where no_recu='" + id + "';", connection);
                dataAdapter.Fill(vente, vente.Tables[0].TableName);
                ReportDataSource rds = new ReportDataSource("oneFacture", vente.Tables[0]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);

                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
                connection.Close();
            }
            
            
   
        }
    }
}
