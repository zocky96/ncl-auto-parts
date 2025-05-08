using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncl_auto_parts.model
{
    internal class CartM
    {
        string nom_du_produit, date, clientName, username;
        float prix;
        int Quantite;

        public CartM(string nom_du_produit, string date, string clientName, string username, float prix, int quantite)
        {
            this.Nom_du_produit = nom_du_produit;
            this.Date = date;
            this.ClientName = clientName;
            this.Username = username;
            this.Prix = prix;
            Quantite1 = quantite;
        }

        public string Nom_du_produit { get => nom_du_produit; set => nom_du_produit = value; }
        public string Date { get => date; set => date = value; }
        public string ClientName { get => clientName; set => clientName = value; }
        public string Username { get => username; set => username = value; }
        public float Prix { get => prix; set => prix = value; }
        public int Quantite1 { get => Quantite; set => Quantite = value; }
    }
}
