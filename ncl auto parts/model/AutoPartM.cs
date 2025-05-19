using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncl_auto_parts.model
{
    internal class AutoPartM
    {
        string clientName, service, devise, plaque, carName, phone, description;
        int quantite;
        float prix, total;

        public AutoPartM(string clientName, string service, string devise, string plaque, string carName, string phone, string description, int quantite, float prix, float total)
        {
            this.ClientName = clientName;
            this.Service = service;
            this.Devise = devise;
            this.Plaque = plaque;
            this.CarName = carName;
            this.Phone = phone;
            this.Description = description;
            this.Quantite = quantite;
            this.Prix = prix;
            this.Total = total;
        }

        public string ClientName { get => clientName; set => clientName = value; }
        public string Service { get => service; set => service = value; }
        public string Devise { get => devise; set => devise = value; }
        public string Plaque { get => plaque; set => plaque = value; }
        public string CarName { get => carName; set => carName = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Description { get => description; set => description = value; }
        public int Quantite { get => quantite; set => quantite = value; }
        public float Prix { get => prix; set => prix = value; }
        public float Total { get => total; set => total = value; }
    }
}
