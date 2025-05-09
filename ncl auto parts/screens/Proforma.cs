using ncl_auto_parts.controller;
using ncl_auto_parts.model;
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
    public partial class Proforma : Form
    {
        string id;
        public Proforma()
        {
            InitializeComponent();
            ProformaC.clearProforma(table);
            autoCompletion();
        }
        private async void autoCompletion()
        {

            //------------------------

            name.AutoCompleteCustomSource = await ArticleC.GetAllProductName();
            name.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            name.AutoCompleteSource = AutoCompleteSource.CustomSource;
            name.PlaceholderText = "Enter text";
            //main.CurrentSuggestion.PlaceholderText = "Recherche          date :  2024-12-25";
        }

        private async void add_Click(object sender, EventArgs e)
        {
            bool isAnumber;
            int i;
           
            delete.Visible = false;
            print.Visible = false;
            if (clientName.Text == "")
            {
                MessageBox.Show("Le nom du client ne doit pas etre vide");
            }
            else
            {
                if (name.Text == "")
                {
                    MessageBox.Show("Le nom de l'article ne doit pas etre vide");
                }
                else
                {
                    isAnumber = int.TryParse(qte.Text, out i);
                    if (isAnumber)
                    {
                       
                       string date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
                        ProformaM proforma = new ProformaM(clientName.Text, carName.Text, plaque_.Text, phone.Text, date, name.Text, 0, 100, int.Parse(qte.Text));
                        int rep = await ProformaC.saveProforma(proforma, table);
                        if (rep == 0)
                        {
                            clearField();
                        }
                        else
                        {
                            MessageBox.Show("Une erreur s'est produit lors de l'enregistrement");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Le champ quantité dois contenir que des chiffres");
                    }
                }
            }
        }

        private void Proforma_Load(object sender, EventArgs e)
        {

        }

        private void clean_Click(object sender, EventArgs e)
        {
            delete.Visible = false;
            print.Visible = false;
            ProformaC.clearProforma(table);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            ProformaC.deleteProforma(table, id);
            delete.Visible = false;
            print.Visible = false;
        }
        private void clearField()
        {
            name.Text = "";
            qte.Text = "";
        }
        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = table.CurrentRow.Cells["id_"].Value.ToString();
            delete.Visible = true;
            print.Visible = true;
        }

        private void print_Click(object sender, EventArgs e)
        {
            delete.Visible = false;
            print.Visible = false;
        }
    }
}
