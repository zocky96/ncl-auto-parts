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
    public partial class VoitureViewer : Form
    {
        string id = null,idReparation = null;
        public VoitureViewer(string id,string idReparation)
        {
            InitializeComponent();
            this.id = id;
            this.idReparation = idReparation;
        }

        private async void VoitureViewer_Load(object sender, EventArgs e)
        {
            FactureData vente = new FactureData();
            MySqlConnection connection = await dbConfig.connection();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("select *from reparation,client where client.id ="+id+" and reparation.id="+idReparation+ " and reparation.clientId="+id, connection);
            dataAdapter.Fill(vente, vente.Tables[0].TableName);
            ReportDataSource rds = new ReportDataSource("Voiture", vente.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            connection.Close();
            this.reportViewer1.RefreshReport();
        }
    }
}
