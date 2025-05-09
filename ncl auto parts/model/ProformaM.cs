using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncl_auto_parts.model
{
    internal class ProformaM
    {
        string clientName, carName, plaque, phone, date, description ;
        int quantite;
        float price, total;

        public ProformaM(string clientName, string carName, string plaque, string phone, string date, string description, float price, float total, int quantite)
        {
            this.ClientName = clientName;
            this.CarName = carName;
            this.Plaque = plaque;
            this.Phone = phone;
            this.Date = date;
            this.Description = description;
            this.Price = price;
            this.Total = total;
            this.Quantite = quantite;
        }

        public string ClientName { get => clientName; set => clientName = value; }
        public string CarName { get => carName; set => carName = value; }
        public string Plaque { get => plaque; set => plaque = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Date { get => date; set => date = value; }
        public string Description { get => description; set => description = value; }
        public float Price { get => price; set => price = value; }
        public float Total { get => total; set => total = value; }
        public int Quantite { get => quantite; set => quantite = value; }
    }
}
