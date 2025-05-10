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
    public partial class FactureAuto : Form
    {
        string id = "";
        public FactureAuto()
        {
            InitializeComponent();
            AutoPartC.showGoodFacture(table);
        }

        private void FactureAuto_Load(object sender, EventArgs e)
        {

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
                    AutoPartC.searchGoodFacture(table, searchBar.Text);
                }

            }
        }

        private async void facture_Click(object sender, EventArgs e)
        {
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
    }
}
