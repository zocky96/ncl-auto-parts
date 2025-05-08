using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncl_auto_parts.model
{
    internal class FournisseurM
    {
        String nom, prenom, telephone, adresse, nom_du_produit;

        public FournisseurM(string nom, string prenom, string telephone, string adresse, string nom_du_produit)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Telephone = telephone;
            this.Adresse = adresse;
            this.Nom_du_produit = nom_du_produit;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Nom_du_produit { get => nom_du_produit; set => nom_du_produit = value; }
    }
}
