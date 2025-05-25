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

namespace ncl_auto_parts.rapport
{
    public partial class OkPayroll : Form
    {
        string id = null, lotG = null;
        public OkPayroll()
        {
            InitializeComponent();
            PayrollC.showPayroll(table);
            main.closeConn();
        }

        private void Payroll_Load(object sender, EventArgs e)
        {

        }
        private void clearField()
        {
            ID.Text = "";
            food.Text = "";
            drink.Text = "";
            sol.Text = "";
            dette.Text = "";
            avance.Text = "";
            comment.Text = "";
        }
        private async void save_Click(object sender, EventArgs e)
        {
            float i=0;
            bool isAnumber = false ;
            if (ID.Text == "")
            {
                MessageBox.Show("Le champ ID ne dois pas etre vide");
            }
            else
            {
                int ifCodeEmployerExiste = await UserC.ifCodeEmployerExisteTrue(ID.Text);
                main.closeConn();
                if (ifCodeEmployerExiste == 0)
                {
                    MessageBox.Show("Le code saisi est incorrect");
                }
                else
                {
                    isAnumber = float.TryParse(drink.Text, out i);
                    if (!isAnumber)
                    {
                        MessageBox.Show("Le champ Breuvage dois contenir que des chiffres");
                    }
                    else
                    {
                        isAnumber = float.TryParse(sol.Text, out i);
                        if (!isAnumber)
                        {
                            MessageBox.Show("Le champ Sol dois contenir que des chiffres");
                        }
                        else
                        {
                            isAnumber = float.TryParse(food.Text, out i);
                            if (!isAnumber)
                            {
                                MessageBox.Show("Le champ Nourriture dois contenir que des chiffres");
                            }
                            else
                            {
                                isAnumber = float.TryParse(avance.Text, out i);
                                if (!isAnumber)
                                {
                                    MessageBox.Show("Le champ Avance dois contenir que des chiffres");
                                }
                                else
                                {
                                    isAnumber = float.TryParse(dette.Text, out i);
                                    if (!isAnumber)
                                    {
                                        MessageBox.Show("Le champ Dette dois contenir que des chiffres");
                                    }
                                    else
                                    {
                                        //here
                                       
                                        List<string> list = await EmployerC.getInfoById_(ID.Text);
                                        main.closeConn();
                                        String fullName = list[0];
                                        String poste = list[1];
                                        string salaire = list[2];
                                        float sum = float.Parse(drink.Text) + float.Parse(food.Text) + float.Parse(sol.Text) + float.Parse(avance.Text) + float.Parse(dette.Text);
                                        if(sum > float.Parse(salaire))
                                        {
                                            MessageBox.Show("les dettes sont superieur au salaire");
                                        }
                                        else
                                        {
                                            float final_salaire = float.Parse(salaire) - sum;
                                            PayrollM pay = new PayrollM(ID.Text, fullName, poste, comment.Text, float.Parse(drink.Text), float.Parse(food.Text), float.Parse(avance.Text), float.Parse(dette.Text), float.Parse(sol.Text), float.Parse(salaire), final_salaire);
                                            int rep = await PayrollC.savePayroll(pay, table);
                                            main.closeConn();
                                            if (rep == 0)
                                            {
                                                clearField();
                                                MessageBox.Show("Paiement effectué avec succès");
                                            }
                                            else
                                            {
                                                MessageBox.Show("Erreur lors du paiement");
                                            }
                                            main.closeConn();
                                        }
                                        
                                    }
                                }
                            }
                        }
                    }
                }
                
            }
        }

        private void searchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                PayrollC.searchPayment(searchBar.Text,table);
            }
        }

        private void searchBar_KeyUp(object sender, KeyEventArgs e)
        {
            if (searchBar.Text == "")
            {
                PayrollC.showPayroll(table);
            }
        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            print.Visible = true;
            lotG = table.CurrentRow.Cells["lot"].Value.ToString();
            id = table.CurrentRow.Cells["id_"].Value.ToString();
            ID.Text = table.CurrentRow.Cells["lot"].Value.ToString();
            drink.Text = table.CurrentRow.Cells["drink_"].Value.ToString();
            food.Text = table.CurrentRow.Cells["food_"].Value.ToString();
            sol.Text = table.CurrentRow.Cells["sol_"].Value.ToString();
            avance.Text = table.CurrentRow.Cells["avance_"].Value.ToString();
            dette.Text = table.CurrentRow.Cells["dette_"].Value.ToString();
            comment.Text = table.CurrentRow.Cells["comment_"].Value.ToString();
        }

        private void print_Click(object sender, EventArgs e)
        {
            print.Visible = false;
            //MessageBox.Show(lotG);
            main.showLogin(new PayrollViewer(id,lotG));
        }
    }
}
