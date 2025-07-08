using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncl_auto_parts.model
{
    internal class Money
    {
        float somme_gds, somme_dollar, somme_dette_gds, somme_dette_dollar;

        public float All_gds { get => somme_gds; set => somme_gds = value; }
        public float All_dollar { get => somme_dollar; set => somme_dollar = value; }
        public float D_gds { get => somme_dette_gds; set => somme_dette_gds = value; }
        public float D_dollar { get => somme_dette_dollar; set => somme_dette_dollar = value; }
    }
}
