using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncl_auto_parts.model
{
    internal class ReparationM
    {
        string clientId, Marque, modele, annee, plaque, couleur, service, dateEntree, dateSortie;

        public ReparationM(string clientId, string marque, string modele, string annee, string plaque, string couleur, string service, string dateEntree, string dateSortie)
        {
            this.ClientId = clientId;
            Marque1 = marque;
            this.Modele = modele;
            this.Annee = annee;
            this.Plaque = plaque;
            this.Couleur = couleur;
            this.Service = service;
            this.DateEntree = dateEntree;
            this.DateSortie = dateSortie;
        }

        public string ClientId { get => clientId; set => clientId = value; }
        public string Marque1 { get => Marque; set => Marque = value; }
        public string Modele { get => modele; set => modele = value; }
        public string Annee { get => annee; set => annee = value; }
        public string Plaque { get => plaque; set => plaque = value; }
        public string Couleur { get => couleur; set => couleur = value; }
        public string Service { get => service; set => service = value; }
        public string DateEntree { get => dateEntree; set => dateEntree = value; }
        public string DateSortie { get => dateSortie; set => dateSortie = value; }
    }
}
