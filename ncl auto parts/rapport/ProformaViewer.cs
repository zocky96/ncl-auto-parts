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
    public partial class ProformaViewer : Form
    {
        public ProformaViewer()
        {
            InitializeComponent();
        }

        private async void ProformaViewer_Load(object sender, EventArgs e)
        {

            FactureData vente = new FactureData();
            MySqlConnection connection = await dbConfig.connection();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select *,(select sum(total) from proforma) as real_total from proforma ", connection);
            dataAdapter.Fill(vente, vente.Tables[0].TableName);
            ReportDataSource rds = new ReportDataSource("Proforma", vente.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            connection.Close();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
