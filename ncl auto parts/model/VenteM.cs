using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncl_auto_parts.model
{
    internal class VenteM
    {
        String nomDuProduit, date, signature, receiptNumber, clientName, devise;
        float prix, total;
        int quantite, IdFournisseur, numero;

        public VenteM(string nomDuProduit, string date, string signature, string receiptNumber, string clientName, string devise, float prix, float total, int quantite, int idFournisseur, int numero)
        {
            this.NomDuProduit = nomDuProduit;
            this.Date = date;
            this.Signature = signature;
            this.ReceiptNumber = receiptNumber;
            this.ClientName = clientName;
            this.Devise = devise;
            this.Prix = prix;
            this.Total = total;
            this.Quantite = quantite;
            IdFournisseur1 = idFournisseur;
            this.Numero = numero;
        }

        public string NomDuProduit { get => nomDuProduit; set => nomDuProduit = value; }
        public string Date { get => date; set => date = value; }
        public string Signature { get => signature; set => signature = value; }
        public string ReceiptNumber { get => receiptNumber; set => receiptNumber = value; }
        public string ClientName { get => clientName; set => clientName = value; }
        public string Devise { get => devise; set => devise = value; }
        public float Prix { get => prix; set => prix = value; }
        public float Total { get => total; set => total = value; }
        public int Quantite { get => quantite; set => quantite = value; }
        public int IdFournisseur1 { get => IdFournisseur; set => IdFournisseur = value; }
        public int Numero { get => numero; set => numero = value; }
    }
}
