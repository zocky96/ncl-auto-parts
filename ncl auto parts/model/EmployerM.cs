using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncl_auto_parts.model
{
    internal class EmployerM
    {
        String nom, prenom, nif, mail, adresse, date_de_naissance, poste, phone;

        public EmployerM(string nom, string prenom, string nif, string mail, string adresse, string date_de_naissance, string poste, string phone)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Nif = nif;
            this.Mail = mail;
            this.Adresse = adresse;
            this.Date_de_naissance = date_de_naissance;
            this.Poste = poste;
            this.Phone = phone;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Nif { get => nif; set => nif = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Date_de_naissance { get => date_de_naissance; set => date_de_naissance = value; }
        public string Poste { get => poste; set => poste = value; }
        public string Phone { get => phone; set => phone = value; }
    }
}
