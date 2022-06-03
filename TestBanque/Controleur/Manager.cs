using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBanque.DAL;
using TestBanque.Model;

namespace TestBanque.Controleur
{
    class Manager
    {
        private AdherantsDao Adao = new AdherantsDao();
        private InscriptionDao Idao = new InscriptionDao();
        private Adherent Adherent = new Adherent(1, null, null);
        public List<Adherent> getAdherents()
        {
            return Adao.getAdherents();

        }

        public List<Inscription> chargementDbInsc(Adherent adherent)
        {
            return Idao.getInscritptions(adherent);

        }
        public bool ChargementDbPaye(Inscription inscritption)
        {
            return inscritption.insciPayee();
        }
        public void valideinscription(int idStudent, int idCours)
        {
            Idao.valideinscription(idStudent,idCours);
        }
        public void devalideinscription(int idStudent, int idCours)
        {
            Idao.devalideinscription(idStudent, idCours);
        }
        public void supprinscri(int idStudent, int idCours)
        {
            Idao.supprinscri(idStudent,idCours);
        }
        public void supprstudent(int idStudent)
        {
            Idao.supprstudent(idStudent);
        }
    }
}
