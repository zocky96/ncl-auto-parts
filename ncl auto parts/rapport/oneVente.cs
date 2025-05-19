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
    public partial class oneVente : Form
    {
        string id;
        public oneVente(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private async void oneVente_Load(object sender, EventArgs e)
        {
            FactureData vente = new FactureData();
            MySqlConnection connection = await dbConfig.connection();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select *,(select sum(total) from vente where receiptNumber='"+id+"') as real_total from vente where receiptNumber='"+id+"';", connection);
            dataAdapter.Fill(vente, vente.Tables[0].TableName);
            ReportDataSource rds = new ReportDataSource("oneVente", vente.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
           
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            connection.Close();
          
        }
    }
}
