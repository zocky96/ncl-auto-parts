using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncl_auto_parts.model
{
    internal class ClientM
    {
        string nom, prenom, adresse, phone, mail;

        public ClientM(string nom, string prenom, string adresse, string phone, string mail)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Adresse = adresse;
            this.Phone = phone;
            this.Mail = mail;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Mail { get => mail; set => mail = value; }
    }
}
