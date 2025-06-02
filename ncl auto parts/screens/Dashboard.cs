using MySql.Data.MySqlClient;
using ncl_auto_parts.controller;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace ncl_auto_parts.screens
{
    public partial class Dashboard : Form
    {
        public static Label label;
        public Dashboard()
        {
            InitializeComponent();
            label = hello;
            if (main.userName != null)
            {
                if (main.poste != "gestionnaire de stock")
                {
                    init_screen();
                }
                
            }
            //init_screen();
            main.closeConn();
        }
        public  async void init_screen()
        {
            nbrClient.Text = await ClientC.getNbrClient();
            nbrArticle.Text = await ArticleC.getNbrArticle();
            totalVente.Text = "$"+ await VenteC.getTotalVente();
            totalByMonth.Text = "$"+ await VenteC.getTotalVenteBymonth();
            VenteC.showLast10Vente(tableTransaction);
            ClientC.showLast10Client(tableClient);
            ArticleC.filtredByFinnishStock10Last(tableStock);
            byMonth.Series.Clear();
            var series = new Series("revenu du mois")
            {
                ChartType = SeriesChartType.Spline
            };
            MySqlDataReader result = await dbConfig.getResultCommand("select * from article");
            try
            {
                while (result.Read())
                {
                    string nom = result.GetString("nom_du_produit");
                    
                    int total_vendu = result.GetInt32("quantite_vendu");
                    series.Points.AddXY(nom,total_vendu);
                    //table.Rows.Add(result["id"], result["nom"], result["prenom"], result["telephone"], result["adresse"], result["nom_du_produit"]);

                }
                byMonth.Series.Add(series);
            }
            catch
            {

            }

            //---------------------------------------------------------------------------
            series = new Series("Populaire")
            {
                ChartType = SeriesChartType.Column
            };
            result = await dbConfig.getResultCommand("select * from vente");
            try
            {
                while (result.Read())
                {
                    string nom = result.GetString("nom_du_produit");

                    int total_vendu = result.GetInt32("quantite");
                    series.Points.AddXY(nom, total_vendu);
                    //table.Rows.Add(result["id"], result["nom"], result["prenom"], result["telephone"], result["adresse"], result["nom_du_produit"]);

                }
                top.Series.Add(series);
            }
            catch
            {

            }
        }
        private async void Dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.showLogin(new RapportVenteViewer());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            //main.moveSelectedItem2(main.article_);
            //main.showScreen(new Article());
        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {
            //moveSelectedItem2(article);
            //showScreen(new Article());
        }

        private void panel28_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            main.showLogin(new Rapport());
        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
