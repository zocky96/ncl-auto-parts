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
    public partial class CancelVente : Form
    {
        public CancelVente()
        {
            InitializeComponent();
            showVente(table);
            main.closeConn();
        }
        public async static void showVente(BunifuDataGridView table)
        {
            table.Rows.Clear();
            MySqlDataReader result = await dbConfig.getResultCommand("select * from canceledvente");
            try
            {
                while (result.Read())
                {

                    table.Rows.Add(result["id"], result["nom_du_produit"], result["prix"], result["quantite"], result["total"], result["date"], result["signature_autorise"], result["receiptNumber"], result["clientName"], result["devise"]);

                }
            }
            catch
            {

            }
        }
        private void CancelVente_Load(object sender, EventArgs e)
        {

        }
    }
}
