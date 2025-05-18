using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncl_auto_parts.model
{
    internal class factureM
    {
        string description;
        int quantite;
        float prix, total;

        public factureM(string description, int quantite, float prix, float total)
        {
            this.Description = description;
            this.Quantite = quantite;
            this.Prix = prix;
            this.Total = total;
        }

        public string Description { get => description; set => description = value; }
        public int Quantite { get => quantite; set => quantite = value; }
        public float Prix { get => prix; set => prix = value; }
        public float Total { get => total; set => total = value; }
    }
}
