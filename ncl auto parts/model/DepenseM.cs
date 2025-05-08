using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncl_auto_parts.model
{
    internal class DepenseM
    {
        string motifDepense, explication, signature, date, devise;
        float montantDepense;

        public DepenseM(string motifDepense, string explication, string signature, string date, string devise, float montantDepense)
        {
            this.MotifDepense = motifDepense;
            this.Explication = explication;
            this.Signature = signature;
            this.Date = date;
            this.Devise = devise;
            this.MontantDepense = montantDepense;
        }

        public string MotifDepense { get => motifDepense; set => motifDepense = value; }
        public string Explication { get => explication; set => explication = value; }
        public string Signature { get => signature; set => signature = value; }
        public string Date { get => date; set => date = value; }
        public string Devise { get => devise; set => devise = value; }
        public float MontantDepense { get => montantDepense; set => montantDepense = value; }
    }
}
