using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncl_auto_parts.model
{
    internal class AutoPartM
    {
        string clientName, service, devise;
        float montant;

        public AutoPartM(string clientName, string service, string devise, float montant)
        {
            this.ClientName = clientName;
            this.Service = service;
            this.Devise = devise;
            this.Montant = montant;
        }

        public string ClientName { get => clientName; set => clientName = value; }
        public string Service { get => service; set => service = value; }
        public string Devise { get => devise; set => devise = value; }
        public float Montant { get => montant; set => montant = value; }
    }
}
