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
    public partial class PayrollViewer : Form
    {
        string id=null,lot=null;
        public PayrollViewer(string id,string  lot)
        {
            InitializeComponent();
            this.id = id;
            this.lot = lot;
        }

        private async void PayrollViewer_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(lot);
            FactureData vente = new FactureData();
            MySqlConnection connection = await dbConfig.connection();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select * from new_payroll where id='" + id + "' and id_emp='" + lot + "'", connection);
            dataAdapter.Fill(vente, vente.Tables[0].TableName);
            ReportDataSource rds = new ReportDataSource("Payroll", vente.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            connection.Close();
            this.reportViewer1.RefreshReport();
        }
    }
}
