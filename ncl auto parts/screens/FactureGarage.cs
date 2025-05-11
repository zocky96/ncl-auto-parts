using MySql.Data.MySqlClient;
using ncl_auto_parts.controller;
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
    public partial class FactureGarage : Form
    {
        string id="";
        public FactureGarage()
        {
            InitializeComponent();
            GarageC.showGoodFacture(table);
            main.closeConn();
        }

        private void searchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (searchBar.Text == "")
                {

                }
                else
                {
                    GarageC.searchGoodFacture(table, searchBar.Text);
                }

            }
        }

        private async void facture_Click(object sender, EventArgs e)
        {
            main.closeConn();
            float sum = 0;
            String devise = null;
            if (id == "")
            {
                MessageBox.Show("Selectionne la facture a annulée");
            }
            else
            {
                MySqlDataReader result = await AutoPartC.getGoodFacture(id);
                MessageBox.Show(id);
                while (result.Read())
                {
                    devise = result["devise"].ToString();
                    sum += float.Parse(result["montant"].ToString());
                }
                if (devise == "US")
                {
                    id = "";
                    VenteC.RemoveUsMoney(sum);
                    AutoPartC.deleteGoodFacture(table, id);
                    MessageBox.Show("Facture annulée avec succès");
                }
                else
                {
                    id = "";
                    VenteC.RemoveHtgMoney(sum);
                    AutoPartC.deleteGoodFacture(table, id);
                    MessageBox.Show("Facture annulée avec succès");
                }
            }
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = table.CurrentRow.Cells["no"].Value.ToString();
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
