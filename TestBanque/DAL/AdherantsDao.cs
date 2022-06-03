using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBanque.Model;
using MySql.Data.MySqlClient;

namespace TestBanque.DAL
{
    class AdherantsDao
    {
        private ConnectionSql maConnexionSql;

        private MySqlCommand Ocom;


        public List<Adherent> getAdherents()
        {
            List<Adherent> ladh = new List<Adherent>(); 
            try
            {
                maConnexionSql = ConnectionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);
                maConnexionSql.openConnection();

                Ocom = maConnexionSql.reqExec("Select person.id idP, person.nom nomP, person.prenom PrenomP  from students INNER JOIN person On students.id = person.id");

                 MySqlDataReader reader = Ocom.ExecuteReader();

                while (reader.Read())
                {
                    
                    int idP = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);

                    Adherent a = new Adherent(idP, nom, prenom);

                    ladh.Add(a);
                }
                reader.Close();
                maConnexionSql.closeConnection();
            }
            catch(Exception e)
            {
                throw (new Exception("" + e));   
            }
            return ladh;
        }
    }
}
