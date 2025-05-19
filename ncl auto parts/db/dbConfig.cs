using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ncl_auto_parts.db
{
    internal class dbConfig
    {
        static byte[] key = Encoding.UTF8.GetBytes("ungrandpouvoirPk");

        public dbConfig()
        {

        }
        public static List<string> showConfig()
        {
            string user, passwd, host, port;
            List<string> list = new List<string>();

            SQLiteDataReader result = getResultCommandSQLite("select *from db_config");
            try
            {
                while (result.Read())
                {

                    user = result["username"].ToString();
                    passwd = result["password"].ToString();
                    host = result["host"].ToString();
                    port = result["port"].ToString();
                    list.Add(Decrypt(user, dbConfig.key));
                    list.Add(Decrypt(passwd, dbConfig.key));
                    list.Add(Decrypt(host, dbConfig.key));
                    list.Add(Decrypt(port, dbConfig.key));

                }
            }
            catch
            {

            }
            return list;
        }
        public static String Decrypt(String plaintBytes, byte[] keys)
        {
            byte[] textToDecode = Convert.FromBase64String(plaintBytes);
            byte[] decryptedBytes = null;
            using (Aes aes = Aes.Create())
            {
                aes.Key = keys;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;
                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                {
                    decryptedBytes = decryptor.TransformFinalBlock(textToDecode, 0, textToDecode.Length);

                }
            }

            return Encoding.UTF8.GetString(decryptedBytes);
        }
        public static SQLiteConnection connectionSQLite()
        {
            string cs = @"URI=file:" + Application.StartupPath + "\\config.db";
            SQLiteConnection conn = new SQLiteConnection(cs);
            try
            {
                conn.Open();
            }
            catch
            {
                MessageBox.Show("file not found");
                conn = null;
            }

            return conn;
        }
        public static void executeCommandSQLite(String cmd)
        {

            try
            {
                SQLiteConnection conn = connectionSQLite();
                SQLiteCommand command = conn.CreateCommand();
                command.CommandText = (cmd);
                command.ExecuteNonQuery();
                conn.Close();

            }
            catch
            {


            }
        }
        public static SQLiteDataReader getResultCommandSQLite(String cmd)
        {
            SQLiteDataReader reader = null;
            SQLiteConnection conn = connectionSQLite();
            try
            {
                SQLiteCommand command = conn.CreateCommand();
                command.CommandText = cmd;
                reader = command.ExecuteReader();
                return reader;
            }
            catch
            {
            }
            return reader;

        }

        public async static Task<MySqlConnection> connectionConfig()
        {
            List<string> list = new List<string>();
            list = showConfig();
            
            string link = "Server=" + list[2] + ";port=" + list[3] + ";User=" + list[0] + ";Password=" + list[1];
            MySqlConnection conn = new MySqlConnection(link);
            try
            {
                await conn.OpenAsync();
            }
            catch
            {


            }

            return conn;
        }
        public static async Task<MySqlConnection> connection()
        {
            List<string> list = new List<string>();
            list = showConfig();
            MySqlConnection conn2 = null;
            string link = "Server=" + list[2] + ";port=" + list[3] + ";User=" + list[0] + ";Password=" + list[1] + ";Database=ncl;Connection Timeout=10";
            MySqlConnection conn = new MySqlConnection(link);
            CancellationTokenSource source = new CancellationTokenSource();
            try
            {
                //Task<MySqlConnection> task = Task.Run(() => conn.Open(),source.Token);
                await conn.OpenAsync();
                return conn;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message.ToString());
                MessageBox.Show("\nServeur injoiniable, verfifier l'adresse du serveur ou\n autoriser l'access au serveur mysql");
                conn.Close();
                conn = new MySqlConnection(link);
                await conn.OpenAsync();
                return conn;
            }

            return conn;
        }

        public static async Task<MySqlDataReader> getResultCommand(String cmd)
        {

            MySqlDataReader reader = null;
            MySqlConnection conn = await connection();
            try
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = cmd;

                reader = await Task<MySqlDataReader>.Run(() => {
                    return command.ExecuteReader();
                });
                main.listConn.Add(conn);
                return reader;
            }
            catch
            {
            }
            main.listConn.Add(conn);
            return reader;

        }

        public static async void executeCommand(String cmd)
        {

            try
            {
                MySqlConnection conn = await connectionConfig();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = (cmd);
                command.ExecuteNonQuery();
                conn.Close();

            }
            catch
            {


            }
        }
        public static async Task<int> execute_command(String cmd)
        {
            int retu = 0;
            MySqlConnection conn = await connection();
            if (conn == null)
            {

                return 9;
            }
            else
            {
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = (cmd);

                try
                {
                    command.ExecuteNonQuery();
                    conn.Close();
                    return 0;
                }
                catch
                {
                    return 1;
                }
            }
            conn.Close();
            return retu;

        }
        public static void createDataBase()
        {
            executeCommand("create database Ncl");
        }

        public static async Task<int> createTables()
        {
            int rep = await execute_command("create table employer(id int primary key auto_increment,nom varchar(255),prenom varchar(255),nif varchar(70),adresse varchar(255),date_de_naissance date,poste enum('caissier','PDG','gestionnaire de stock','manager','secretaire','directeur','mecanicien'),phone varchar(30),mail varchar(50),salaire double)");

            if (rep == 0)
            {
                await execute_command("insert into employer(nom,prenom,nif,poste,adresse,date_de_naissance,phone,salaire) values('Desir','Renaldo','007-100-199484','manager','56,Fort St Michel','1996/12/25','50934951243',0)");
            }
            rep = await execute_command("create table employer_suprimer(id int primary key auto_increment,nom varchar(255),prenom varchar(255),nif varchar(70),sexe varchar(70),adresse varchar(255),date_de_naissance date,poste enum('caissier','technicien','docteur','sysadmin','manager'))");
           
            rep = await execute_command("create table utilisateur(id int primary key auto_increment,nom varchar(70),prenom varchar(70),username varchar(100),code_employer varchar(70),password varchar(100),isConected int,constraint fk_id_employer foreign key(id) references employer(id))");
            if (rep == 0)
            {
                await execute_command("insert into utilisateur(nom,prenom,username,password,code_employer,isConected) values('Desir','Renaldo','zock','7110eda4d09e062aa5e4a390b0a572ac0d2c0220','1',0)");
            }
           
            rep = await execute_command("create table article (id int primary key auto_increment,nom_du_produit varchar(100),prix float,quantite int,fournisseur varchar(80),dateAjout date,dateExpiration date,element varchar(255),ref varchar(255),numero varchar(255),idfournisseur int)");
           
            rep = await execute_command("create table fournisseur (id int primary key auto_increment,nom varchar(255),prenom varchar(100),adresse varchar(100),nom_du_produit varchar(100),telephone varchar(100))");
           
            rep = await execute_command("create table vente (id int primary key auto_increment,nom_du_produit varchar(100),prix float,quantite int,total float,date date,signature_autorise varchar(150),receiptNumber varchar(255),type varchar(255),clientName varchar(255),devise enum('HTG','US'))");
            // rep = execute_command("create table vente (id int primary key auto_increment,nom_du_produit varchar(100))");
           
            //----
            rep = await execute_command("create table canceledvente (id int primary key auto_increment,nom_du_produit varchar(100),prix float,quantite int,total float,date date,signature_autorise varchar(150),receiptNumber varchar(255),type varchar(255),clientName varchar(255),devise enum('HTG','US'))");
            // rep = execute_command("create table vente (id int primary key auto_increment,nom_du_produit varchar(100))");
            
            //---
            rep = await execute_command("create table panier (id int primary key auto_increment,nom_du_produit varchar(100),prix float,quantite int,date date,clientName varchar(255),username varchar(50))");
           
            rep = await execute_command("create table paiement (id int primary key,caissier float,secretaire float,comptable float,manager float,gestionnaire float)");
           
           
            rep = await execute_command("create table log (id int,nom varchar(100),prenom varchar(100),username varchar(50),date date,heure varchar(10))");
           
            rep = await execute_command("create table payroll (id int,employer varchar(100),salaire varchar(100),short int,surplus int)");

            
            rep = await execute_command("create table services(id int primary key auto_increment,service varchar(255),prix double(12,4))");
           
            rep = await execute_command("create table depenses(id int primary key auto_increment,motifDepense varchar(255),montantDepense double(12,4),explication varchar(255),signature varchar(100),date date,devise enum('HTG','US'))");
            if (rep == 9)
            {
                return 52;
            }
            //---
            rep = await execute_command("create table depenses_garage(id int primary key auto_increment,motifDepense varchar(255),montantDepense double(12,4),explication varchar(255),signature varchar(100),date date,devise enum('HTG','US'))");
           
            //---
            rep = await execute_command("create table ajout(id int primary key auto_increment,montantDepense double(12,4),explication varchar(255),signature varchar(100),date date,devise enum('HTG','US'))");
            
            //--
            rep = await execute_command("create table ajout_garage(id int primary key auto_increment,montantDepense double(12,4),explication varchar(255),signature varchar(100),date date,devise enum('HTG','US'))");
           
            //--
            rep = await execute_command("create table client(id int primary key auto_increment,nom varchar(255),prenom varchar(255),adresse varchar(255),phone varchar(100),mail varchar(100))");
           
            rep = await execute_command("create table reparation(id int primary key auto_increment,clientId varchar(255),Marque varchar(255),modele varchar(255),annee varchar(100),plaque varchar(100),couleur varchar(100),service varchar(100),dateEntree date,dateSortie date)");
           
            //--
            rep = await execute_command("create table proforma(id int primary key auto_increment,clientName varchar(255),carName varchar(255),plaque varchar(100),phone varchar(50),date date,description varchar(200),quantite int,price double,total double)");
            rep = await execute_command("ALTER TABLE proforma ADD devise enum('HTG','US')");
            //--
            rep = await execute_command("create table fauto_part(id int primary key auto_increment,clientName varchar(255),service varchar(255),devise enum('HTG','US'),montant double)");
            rep = await execute_command("ALTER TABLE fauto_part ADD car_name VARCHAR(100)");
            rep = await execute_command("ALTER TABLE fauto_part ADD plaque VARCHAR(100)");
            rep = await execute_command("ALTER TABLE fauto_part ADD phone VARCHAR(20)");
            rep = await execute_command("ALTER TABLE fauto_part ADD description VARCHAR(150)");
            rep = await execute_command("ALTER TABLE fauto_part ADD quantite INT");
            rep = await execute_command("ALTER TABLE fauto_part ADD total DOUBLE");
            //--
            rep = await execute_command("create table fgarage(id int primary key auto_increment,clientName varchar(255),service varchar(255),devise enum('HTG','US'),montant double)");
            rep = await execute_command("ALTER TABLE fgarage ADD car_name VARCHAR(100)");
            rep = await execute_command("ALTER TABLE fgarage ADD plaque VARCHAR(100)");
            rep = await execute_command("ALTER TABLE fgarage ADD phone VARCHAR(20)");
            rep = await execute_command("ALTER TABLE fgarage ADD description VARCHAR(150)");
            rep = await execute_command("ALTER TABLE fgarage ADD quantite INT");
            rep = await execute_command("ALTER TABLE fgarage ADD total DOUBLE");
            //--
            rep = await execute_command("create table facture_auto(id int primary key auto_increment,clientName varchar(255),service varchar(255),devise enum('HTG','US'),montant double,no_recu varchar(255),date date ,user varchar(150))");
            //MessageBox.Show("ok");
            rep = await execute_command("ALTER TABLE facture_auto ADD car_name VARCHAR(100)");
            rep = await execute_command("ALTER TABLE facture_auto ADD plaque VARCHAR(100)");
            rep = await execute_command("ALTER TABLE facture_auto ADD phone VARCHAR(20)");
            rep = await execute_command("ALTER TABLE facture_auto ADD description VARCHAR(150)");
            rep = await execute_command("ALTER TABLE facture_auto ADD quantite INT");
            rep = await execute_command("ALTER TABLE facture_auto ADD total DOUBLE");
            //,,,,,");
            //--
            rep = await execute_command("create table canceled_facture_auto(id int primary key auto_increment,clientName varchar(255),service varchar(255),devise enum('HTG','US'),montant double,no_recu varchar(255),date date ,user varchar(150))");
            rep = await execute_command("ALTER TABLE canceled_facture_auto ADD car_name VARCHAR(100)");
            rep = await execute_command("ALTER TABLE canceled_facture_auto ADD plaque VARCHAR(100)");
            rep = await execute_command("ALTER TABLE canceled_facture_auto ADD phone VARCHAR(20)");
            rep = await execute_command("ALTER TABLE canceled_facture_auto ADD description VARCHAR(150)");
            rep = await execute_command("ALTER TABLE canceled_facture_auto ADD quantite INT");
            rep = await execute_command("ALTER TABLE canceled_facture_auto ADD total DOUBLE");
            //--
            rep = await execute_command("create table facture_garage(id int primary key auto_increment,clientName varchar(255),service varchar(255),devise enum('HTG','US'),montant double,no_recu varchar(255),date date ,user varchar(150))");
            rep = await execute_command("ALTER TABLE facture_garage ADD car_name VARCHAR(100)");
            rep = await execute_command("ALTER TABLE facture_garage ADD plaque VARCHAR(100)");
            rep = await execute_command("ALTER TABLE facture_garage ADD phone VARCHAR(20)");
            rep = await execute_command("ALTER TABLE facture_garage ADD description VARCHAR(150)");
            rep = await execute_command("ALTER TABLE facture_garage ADD quantite INT");
            rep = await execute_command("ALTER TABLE facture_garage ADD total DOUBLE");
            //-----
            rep = await execute_command("create table cancel_facture_garage(id int primary key auto_increment,clientName varchar(255),service varchar(255),devise enum('HTG','US'),montant double,no_recu varchar(255),date date,user varchar(150) )");
            rep = await execute_command("ALTER TABLE cancel_facture_garage ADD car_name VARCHAR(100)");
            rep = await execute_command("ALTER TABLE cancel_facture_garage ADD plaque VARCHAR(100)");
            rep = await execute_command("ALTER TABLE cancel_facture_garage ADD phone VARCHAR(20)");
            rep = await execute_command("ALTER TABLE cancel_facture_garage ADD description VARCHAR(150)");
            rep = await execute_command("ALTER TABLE cancel_facture_garage ADD quantite INT");
            rep = await execute_command("ALTER TABLE cancel_facture_garage ADD total DOUBLE");
            //-----
            //--------------------------------
            rep = await execute_command("create table account_HTG_garage(id int primary key auto_increment,amount float)");
            if (rep == 0)
            {
                await execute_command("insert into account_HTG_garage(amount) values(0)");
            }
            //------------------------------------
            rep = await execute_command("create table account_us_garage(id int primary key auto_increment,amount float)");
            if (rep == 0)
            {
                await execute_command("insert into account_us_garage(amount) values(0)");
            }
            //------------------------------------
            rep = await execute_command("create table account_HTG(id int primary key auto_increment,amount float)");
            if (rep == 0)
            {
                await execute_command("insert into account_HTG(amount) values(0)");
            }
            if (rep == 9)
            {
                return 52;
            }
            rep = await execute_command("create table account_US(id int primary key auto_increment,amount float)");
            if (rep == 0)
            {
                await execute_command("insert into account_US(amount) values(0)");
            }
            
            return rep;
        }
    }
}
