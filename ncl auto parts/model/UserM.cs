using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncl_auto_parts.model
{
    internal class UserM
    {
        string nom, prenom, username, password, code_employer;

        public UserM(string nom, string prenom, string username, string password, string code_employer)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Username = username;
            this.Password = password;
            this.Code_employer = code_employer;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Code_employer { get => code_employer; set => code_employer = value; }
    }
}
