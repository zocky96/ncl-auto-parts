using Bunifu.UI.WinForms;
using MySql.Data.MySqlClient;
using ncl_auto_parts.db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ncl_auto_parts.screens
{
    public partial class CancelFactureGarage : Form
    {
        public CancelFactureGarage()
        {
            InitializeComponent();
            showGoodFacture(table);
            main.closeConn();   
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public async static void showGoodFacture(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select *from cancel_facture_garage");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["clientName"], result["service"], result["montant"], result["devise"], result["no_recu"], result["date"], result["user"]);

                }
                main.closeConn();

            }
            catch
            {

            }
        }
        private void CancelFactureGarage_Load(object sender, EventArgs e)
        {

        }
    }
}
