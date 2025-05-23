using ncl_auto_parts.controller;
using ncl_auto_parts.rapport;
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
    public partial class Reparation : Form
    {
        string id=null, ClientName = "", realDate = "",reparationID=null;
        public List<(string service, float montant)> donnees;
        float realTotal = 0;

        public Reparation()
        {
            InitializeComponent();
            main.currentPage = "reparation";
            ReparationC.showReparation(table);
            main.closeConn();
        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Reparation_Load(object sender, EventArgs e)
        {

        }
        private void clearField()
        {
            idClient.Text = "";
            marque.Text = "";
            modeleb.Text = "";
            annee.Text = "";
            plaque.Text = "";
            couleur.Text = "";
            service.Text = "";
            dateEntre.Refresh();
            dateSortie.Refresh();
        }

        private async void save_Click(object sender, EventArgs e)
        {
            main.closeConn();
            print.Visible = false;
            bool isAnumber;
            int i ;
            
            
            isAnumber = int.TryParse(idClient.Text, out i);
            if (isAnumber)
            {
                int ifCodeClientExiste = await ClientC.ifCodeClientExiste(idClient.Text);
                main.closeConn();
                if (ifCodeClientExiste != 0)
                {
                    if (marque.Text == "")
                    {
                        MessageBox.Show("Le champ 'Marque' ne doit pas etre vide");
                    }
                    else
                    {
                        if (modeleb.Text == "")
                        {
                            MessageBox.Show("Le champ 'Modele' ne doit pas etre vide");
                        }
                        else
                        {
                            if (annee.Text == "")
                            {
                                MessageBox.Show("Le champ 'Année' ne doit pas etre vide");
                            }
                            else
                            {
                                if (plaque.Text == "")
                                {
                                    MessageBox.Show("Le champ 'Plaque' ne doit pas etre vide");
                                }
                                else
                                {
                                    if (couleur.Text == "")
                                    {
                                        MessageBox.Show("Le champ 'Couleur' ne doit pas etre vide");
                                    }
                                    else
                                    {
                                        if (service.Text == "")
                                        {
                                            MessageBox.Show("Le champ 'Service' ne doit pas etre vide");
                                        }
                                        else
                                        {
                                            int rep = await ReparationC.saveReparation(idClient.Text, marque.Text, modeleb.Text, annee.Text, plaque.Text, couleur.Text, service.Text, dateEntre.Value.Year.ToString() + "/" + dateEntre.Value.Month + "/" + dateEntre.Value.Day, dateSortie.Value.Year.ToString()+"/"+dateSortie.Value.Month+"/"+dateSortie.Value.Day, table);
                                            main.closeConn();
                                            if (rep == 0)
                                            {
                                                clearField();
                                                main.closeConn();
                                                MessageBox.Show("Enregistrer avec succes");
                                            }
                                            else
                                            {
                                                MessageBox.Show("Erreur lors de lénregistrement");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Le code du client n'existe pas");
                }
            }
            else
            {
                MessageBox.Show("Le champ 'identifiant du client' ne doit contenir que des chiffres");
            }
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            modify.Visible = true;
            delete.Visible = true;
            print.Visible = true;
            reparationID = table.CurrentRow.Cells["id_du_client"].Value.ToString();
            id = table.CurrentRow.Cells["id_"].Value.ToString();
            idClient.Text = table.CurrentRow.Cells["id_du_client"].Value.ToString(); 
            marque.Text = table.CurrentRow.Cells["marque_"].Value.ToString();
            modeleb.Text = table.CurrentRow.Cells["modele_"].Value.ToString();
            annee.Text = table.CurrentRow.Cells["annee_"].Value.ToString();
            plaque.Text = table.CurrentRow.Cells["plaque_"].Value.ToString();
            couleur.Text = table.CurrentRow.Cells["couleur_"].Value.ToString();
            service.Text = table.CurrentRow.Cells["service_"].Value.ToString();
            dateEntre.Text = table.CurrentRow.Cells["dateE"].Value.ToString(); 
            dateSortie.Text = table.CurrentRow.Cells["dateS"].Value.ToString();
        }

        private async void bunifuButton4_Click(object sender, EventArgs e)
        {
            main.closeConn();
            modify.Visible = false;
            delete.Visible = false;
            print.Visible = false;
            bool isAnumber;
            int i;
            isAnumber = int.TryParse(idClient.Text, out i);
            if (isAnumber)
            {
                int ifCodeClientExiste = await ClientC.ifCodeClientExiste(idClient.Text);
                main.closeConn();
                if (ifCodeClientExiste != 0)
                {
                    if (marque.Text == "")
                    {
                        MessageBox.Show("Le champ 'Marque' ne doit pas etre vide");
                    }
                    else
                    {
                        if (modeleb.Text == "")
                        {
                            MessageBox.Show("Le champ 'Modele' ne doit pas etre vide");
                        }
                        else
                        {
                            if (annee.Text == "")
                            {
                                MessageBox.Show("Le champ 'Année' ne doit pas etre vide");
                            }
                            else
                            {
                                if (plaque.Text == "")
                                {
                                    MessageBox.Show("Le champ 'Plaque' ne doit pas etre vide");
                                }
                                else
                                {
                                    if (couleur.Text == "")
                                    {
                                        MessageBox.Show("Le champ 'Couleur' ne doit pas etre vide");
                                    }
                                    else
                                    {
                                        if (service.Text == "")
                                        {
                                            MessageBox.Show("Le champ 'Service' ne doit pas etre vide");
                                        }
                                        else
                                        {
                                            int rep = await ReparationC.modifyreparation( marque.Text, modeleb.Text, annee.Text, plaque.Text, couleur.Text, service.Text, dateEntre.Value.Year.ToString() + "/" + dateEntre.Value.Month + "/" + dateEntre.Value.Day, dateSortie.Value.Year.ToString()+"/"+dateSortie.Value.Month+"/"+dateSortie.Value.Day, table,id,idClient.Text);
                                            main.closeConn();
                                            if (rep == 0)
                                            {
                                                clearField();
                                                main.closeConn();
                                                MessageBox.Show("Enregistrer avec succes");
                                            }
                                            else
                                            {
                                                MessageBox.Show("Erreur lors de lénregistrement");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Le code du client n'existe pas");
                }
            }
            else
            {
                MessageBox.Show("Le champ 'identifiant du client' ne doit contenir que des chiffres");
            }
        }

        private async void delete_Click(object sender, EventArgs e)
        {
            main.closeConn();
            modify.Visible = false;
            delete.Visible = false;
            print.Visible = false;
            int rep = await ReparationC.deleteReparation(table, id);
            main.closeConn();
            if (rep == 0)
            {
                clearField();
                MessageBox.Show("Suprimer avec succes");
            }
            else
            {
                MessageBox.Show("Erreur lors de la supression");
            }
        }

        private void print_Click(object sender, EventArgs e)
        {
            main.closeConn();
            modify.Visible = false;
            delete.Visible = false;
            print.Visible = false;
            //print.Visible = false;
            main.showLogin(new VoitureViewer(id,reparationID));
            
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
                    ReparationC.searchReparation(searchBar.Text, table);
                }

            }
        }

        private void searchBar_KeyUp(object sender, KeyEventArgs e)
        {
            if (searchBar.Text == "")
            {
                ReparationC.showReparation(table);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(logo.Width, logo.Height);
            logo.DrawToBitmap(bmp, new Rectangle(0, 0, logo.Width, logo.Height));
            e.Graphics.DrawImage(bmp, new Point(60, 60));
            e.Graphics.DrawString("NC.L AUTO SERVICE", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(300, 60));
            e.Graphics.DrawString("Quartier Morin NORD,Haiti", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(335, 90));
            e.Graphics.DrawString("Tél:(509)36449128\\33650089", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(335, 110));
            e.Graphics.DrawString("info.nclautoservices@gmail.com", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(325, 130));
            //-
            e.Graphics.DrawString("Nom du client : " + ClientName, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 210));
            e.Graphics.DrawString("No recu : " + id, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 230));

            string date;
            id = "";
            date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            e.Graphics.DrawString("Date : " + realDate, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 250));
            //-

            e.Graphics.DrawString("Facture", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(85, 360));

            //-
            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Black;
            Pen pen = Pens.Black;

            int startX = 85;
            int startY = 460;
            int rowHeight = 25;
            int[] colWidths = { 340, 290 }; // name, quantite, quantity, price, tax, total

            string[] headers = { "Service", "Montant" };

            // Dessiner l'en-tête avec bordures
            int x = startX;
            for (int i = 0; i < headers.Length; i++)
            {
                Rectangle rect = new Rectangle(x, startY, colWidths[i], rowHeight);
                e.Graphics.DrawRectangle(pen, rect);
                e.Graphics.DrawString(headers[i], new Font("Arial", 12, FontStyle.Bold), brush, rect);
                x += colWidths[i];
            }

            // Dessiner les données avec bordures
            int y = startY + rowHeight;
            foreach (var (service, montant) in donnees)
            {
                x = startX;

                string[] valeurs = {
            service,
            montant.ToString(),

        };

                for (int i = 0; i < valeurs.Length; i++)
                {
                    Rectangle rect = new Rectangle(x, y, colWidths[i], rowHeight);
                    e.Graphics.DrawRectangle(pen, rect);
                    e.Graphics.DrawString(valeurs[i], font, brush, rect);
                    x += colWidths[i];
                }

                y += rowHeight;
            }
            e.Graphics.DrawString("TOTAL", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(85, y + 50));

            e.Graphics.DrawString("$" + realTotal.ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(605, y + 50));

            //-
            //e.Graphics.DrawString("PS:\"Ce proforma est valide pour une durée de 8 jours\" :", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(85, 1020));
            e.Graphics.DrawString("Merci d'avoir choisi NC.L Autoservices!!!", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(485, 1070));
        }
    }
}
