using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncl_auto_parts.model
{
    internal class PayrollM
    {
        string id_emp, fullname, poste, comment;
        float breuvage, nourriture, avance, dette, sol, init_amount, final_amount;

        public PayrollM(string id_emp, string fullname, string poste, string comment, float breuvage, float nourriture, float avance, float dette, float sol, float init_amount, float final_amount)
        {
            this.Id_emp = id_emp;
            this.Fullname = fullname;
            this.Poste = poste;
            this.Comment = comment;
            this.Breuvage = breuvage;
            this.Nourriture = nourriture;
            this.Avance = avance;
            this.Dette = dette;
            this.Sol = sol;
            this.Init_amount = init_amount;
            this.Final_amount = final_amount;
        }

        public string Id_emp { get => id_emp; set => id_emp = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Poste { get => poste; set => poste = value; }
        public string Comment { get => comment; set => comment = value; }
        public float Breuvage { get => breuvage; set => breuvage = value; }
        public float Nourriture { get => nourriture; set => nourriture = value; }
        public float Avance { get => avance; set => avance = value; }
        public float Dette { get => dette; set => dette = value; }
        public float Sol { get => sol; set => sol = value; }
        public float Init_amount { get => init_amount; set => init_amount = value; }
        public float Final_amount { get => final_amount; set => final_amount = value; }
    }
}
