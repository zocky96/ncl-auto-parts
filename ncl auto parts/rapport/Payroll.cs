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

namespace ncl_auto_parts.rapport
{
    public partial class Payroll : Form
    {
        public Payroll()
        {
            InitializeComponent();
        }

        private void Payroll_Load(object sender, EventArgs e)
        {

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
                int ifCodeEmployerExiste = await UserC.ifCodeEmployerExiste(ID.Text);
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
                                    }
                                }
                            }
                        }
                    }
                }
                MessageBox.Show(ifCodeEmployerExiste.ToString());
            }
        }
    }
}
