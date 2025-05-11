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
    
    public partial class Article : Form
    {
        String id = null;
        public Article()
        {
            InitializeComponent();
            main.currentPage = "article";
            ArticleC.showArticle(table);
            main.closeConn();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Article_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void clearField()
        {
            name.Text = "";
            price.Text = "";
            qte.Text = "";
            idFournisseur.Text = "";
            element.Text = "";
            refArticle.Text = "";
            numero.Text = "";
        }

        private async void save_Click(object sender, EventArgs e)
        {
            main.closeConn();
            modify.Visible = false;
            delete.Visible = false;
            int i = 0;
            double j = 0;
            bool isAnumber ;
            //MessageBox.Show();
            if (name.Text == "")
            {
                MessageBox.Show("Le champ 'Nom de l'article' ne doit pas etre vide");
            }
            else
            {
                isAnumber = int.TryParse(qte.Text, out i);
                if (!isAnumber)
                {
                    MessageBox.Show("Le champ 'Quantité' doit contenir que des chiffres");
                }
                else
                {
                    isAnumber = double.TryParse(price.Text, out j);
                    if (!isAnumber)
                    {
                        MessageBox.Show("Le champ 'Prix unitaire' doit contenir que des chiffres");
                    }
                    else
                    {
                        isAnumber = int.TryParse(idFournisseur.Text, out i);
                        if (!isAnumber)
                        {
                            MessageBox.Show("Le champ 'L'identifiant du fournisseur' doit  contenir que des chiffres");
                        }
                        else
                        {
                            if(element.Text == "")
                            {
                                MessageBox.Show("Le champ 'Element' ne doit pas etre vide");
                            }
                            else
                            {
                                if (refArticle.Text == "")
                                {
                                    MessageBox.Show("Le champ 'Ref' ne doit pas etre vide");
                                }
                                else
                                {
                                    isAnumber = int.TryParse(numero.Text, out i);
                                    if (!isAnumber)
                                    {
                                        MessageBox.Show("Le champ 'Numero' doit contenir que des chiffres");
                                    }
                                    else
                                    {
                                        //put that fucking function here
                                        string year, month, day, date;
                                        year = DateTime.Now.Year.ToString();
                                        month = DateTime.Now.Month.ToString();
                                        day = DateTime.Now.Day.ToString();
                                        date = year + "/" + month + "/" + day;
                                        //dateSortie.Value.Date.ToShortDateString();
                                        //date = DateTime.Now.ToString("yyyy-MM-dd");
                                        
                                        ArticleM article = new ArticleM(name.Text, refArticle.Text, element.Text, float.Parse(price.Text), int.Parse(qte.Text), int.Parse(idFournisseur.Text), int.Parse(numero.Text));
                                        int rep = await ArticleC.saveArticle(article, table, date);
                                        main.closeConn();
                                        if (rep == 0)
                                        {
                                            clearField();
                                            MessageBox.Show("Article enregistrer avec succes");
                                        }
                                        else
                                        {
                                            MessageBox.Show("erreur lors de l'enregistrement");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            modify.Visible = true;
            delete.Visible = true;
            id = table.CurrentRow.Cells["id_"].Value.ToString();
            name.Text = table.CurrentRow.Cells["name_"].Value.ToString();
            price.Text = table.CurrentRow.Cells["price_"].Value.ToString();
            qte.Text = table.CurrentRow.Cells["qte_"].Value.ToString();
            idFournisseur.Text = table.CurrentRow.Cells["idf_"].Value.ToString();
            element.Text = table.CurrentRow.Cells["element_"].Value.ToString();
            refArticle.Text = table.CurrentRow.Cells["ref_"].Value.ToString();
            numero.Text = table.CurrentRow.Cells["numero_"].Value.ToString();
        }

        private async void modify_Click(object sender, EventArgs e)
        {
            main.closeConn();
            modify.Visible = false;
            delete.Visible = false;
            int i = 0;
            double j = 0;
            bool isAnumber;

            if (name.Text == "")
            {
                MessageBox.Show("Le champ 'Nom de l'article' ne doit pas etre vide");
            }
            else
            {
                isAnumber = int.TryParse(qte.Text, out i);
                if (!isAnumber)
                {
                    MessageBox.Show("Le champ 'Quantité' doit contenir que des chiffres");
                }
                else
                {
                    isAnumber = double.TryParse(price.Text, out j);
                    if (!isAnumber)
                    {
                        MessageBox.Show("Le champ 'Prix unitaire' doit contenir que des chiffres");
                    }
                    else
                    {
                        isAnumber = int.TryParse(idFournisseur.Text, out i);
                        if (!isAnumber)
                        {
                            MessageBox.Show("Le champ 'L'identifiant du fournisseur' doit  contenir que des chiffres");
                        }
                        else
                        {
                            if (element.Text == "")
                            {
                                MessageBox.Show("Le champ 'Element' ne doit pas etre vide");
                            }
                            else
                            {
                                if (refArticle.Text == "")
                                {
                                    MessageBox.Show("Le champ 'Ref' ne doit pas etre vide");
                                }
                                else
                                {
                                    isAnumber = int.TryParse(numero.Text, out i);
                                    if (!isAnumber)
                                    {
                                        MessageBox.Show("Le champ 'Numero' doit contenir que des chiffres");
                                    }
                                    else
                                    {
                                        //put that fucking function here
                                        string year, month, day, date;
                                        year = DateTime.Now.Year.ToString();
                                        month = DateTime.Now.Month.ToString();
                                        day = DateTime.Now.Day.ToString();
                                        date = year + "/" + month + "/" + day;

                                        ArticleM article = new ArticleM(name.Text, refArticle.Text, element.Text, float.Parse(price.Text), int.Parse(qte.Text), int.Parse(idFournisseur.Text), int.Parse(numero.Text));
                                        int rep = await ArticleC.modifyArticle(article,table,id);
                                        main.closeConn();
                                        if (rep == 0)
                                        {
                                            clearField();
                                            MessageBox.Show("Article enregistrer avec succes");
                                        }
                                        else
                                        {
                                            MessageBox.Show("erreur lors de l'enregistrement");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private async void delete_Click(object sender, EventArgs e)
        {
            main.closeConn();
            modify.Visible = false;
            delete.Visible = false;
            int rep = -9;
            try
            {
                rep = await ArticleC.deleteArticle(id, table);
            }
            catch
            {

            }
            if (rep == 0)
            {
                clearField();
                MessageBox.Show("Article suprimer avec succes");
            }
            else
            {
                MessageBox.Show("erreur lors de supression");
            }
            main.closeConn();
        }

        private void print_Click(object sender, EventArgs e)
        {
            main.closeConn();
            modify.Visible = false;
            delete.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(filter.Text== "Article en rupture de stock")
            {
                ArticleC.filtredByFinnishStock(table);
            }else if (filter.Text == "Filtre")
            {
                ArticleC.showArticle(table);
            }
            
        }

        private void searchBar_Enter(object sender, EventArgs e)
        {
            
        }

        private void searchBar_KeyDown(object sender, KeyEventArgs e)
        {
            main.closeConn();
            if (e.KeyCode == Keys.Enter)
            {
                if (searchBar.Text == "")
                {
                    
                }
                else
                {
                    ArticleC.searchArticle(searchBar.Text, table);
                }
                
            }
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchBar_KeyUp(object sender, KeyEventArgs e)
        {
            if (searchBar.Text == "")
            {
                ArticleC.showArticle(table);
            }
        }
    }
}
