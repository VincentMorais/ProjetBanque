using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBanque.Model;
using MySql.Data.MySqlClient;



namespace TestBanque.DAL
{
    class InscriptionDao
    {
        private ConnectionSql maConnectionSql;
        private MySqlCommand Ocom;
        public List<Inscription> getInscritptions(Adherent adherant_Select)
        {
            List<Inscription> L_inscr = new List<Inscription>();
            List<Cours> L_cours = new List<Cours>();
            try
            {
                maConnectionSql = ConnectionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);
                maConnectionSql.openConnection();

                Ocom = maConnectionSql.reqExec("Select idCours, instrument.id,  instrument.nom, cours.jourDate, inscription.paye from inscription INNER JOIN cours On cours.id = inscription.idCours INNER JOIN instrument On instrument.id = cours.idInstrument WHERE idStudent ="+adherant_Select.Numero+" ;");


                MySqlDataReader reader = Ocom.ExecuteReader();

                while (reader.Read())
                {

                    int idCours = (int)reader.GetValue(0);
                    int idInstru = (int)reader.GetValue(1);
                    string nomC = (string)reader.GetValue(2);
                    string Date = (string)reader.GetValue(3);
                    int paye = (int)reader.GetValue(4);

                    Instrument instru_Cours = new Instrument(idInstru, nomC);
                    Cours cours = new Cours(idCours, instru_Cours, paye);
                    Inscription adh_insc = new Inscription(adherant_Select, cours, paye);

                    L_inscr.Add(adh_insc);

                }
                reader.Close();
                maConnectionSql.closeConnection();
            }
            catch (Exception e)
            {
                throw (new Exception("" + e));
            }
            return L_inscr;
        }
        public void valideinscription(int idStudent, int idCours)
        {
            maConnectionSql = ConnectionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);
            maConnectionSql.openConnection();
             
            Ocom = maConnectionSql.reqExec("UPDATE inscription SET paye ='0' WHERE inscription.idCours = "+idCours+" and inscription.idStudent = "+idStudent+"; ");
            Ocom.ExecuteNonQuery();

            maConnectionSql.closeConnection();
        }
        public void devalideinscription(int idStudent, int idCours)
        {
            maConnectionSql = ConnectionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);
            maConnectionSql.openConnection();

            Ocom = maConnectionSql.reqExec("UPDATE inscription SET paye ='1' WHERE inscription.idCours = " + idCours + " and inscription.idStudent = " + idStudent + "; ");
            Ocom.ExecuteNonQuery();

            maConnectionSql.closeConnection();
        }
        public void supprinscri(int idStudent, int idCours)
        {
            maConnectionSql = ConnectionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);
            maConnectionSql.openConnection();

            Ocom = maConnectionSql.reqExec("Delete FROM inscription WHERE inscription.idCours = " + idCours + " and inscription.idStudent = " + idStudent + "; ");
           
            Ocom.ExecuteNonQuery();
            maConnectionSql.closeConnection();
        }
        public void supprstudent(int idStudent)
        {
            maConnectionSql = ConnectionSql.getInstance(Fabrique.ProviderMysql, Fabrique.DataBaseMysql, Fabrique.UidMysql, Fabrique.MdpMysql);
            maConnectionSql.openConnection();
            Ocom = maConnectionSql.reqExec("Delete FROM students WHERE students.id = " + idStudent +"; ");
            Ocom.ExecuteNonQuery();
            Ocom = maConnectionSql.reqExec("Delete FROM person WHERE person.id = " + idStudent + "; ");
            Ocom.ExecuteNonQuery();
            maConnectionSql.closeConnection();
        }
    }

}