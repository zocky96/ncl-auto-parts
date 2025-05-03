using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncl_auto_parts.model
{
    internal class ArticleM
    {
        String nom, reference, element;
        float prix;
        int quantite, IdFournisseur,numero;

        public ArticleM(string nom, string reference, string element, float prix, int quantite, int idFournisseur, int numero)
        {
            this.Nom = nom;
            this.Reference = reference;
            this.Element = element;
            this.Prix = prix;
            this.Quantite = quantite;
            IdFournisseur1 = idFournisseur;
            this.Numero = numero;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Reference { get => reference; set => reference = value; }
        public string Element { get => element; set => element = value; }
        public float Prix { get => prix; set => prix = value; }
        public int Quantite { get => quantite; set => quantite = value; }
        public int IdFournisseur1 { get => IdFournisseur; set => IdFournisseur = value; }
        public int Numero { get => numero; set => numero = value; }
    }
}
