using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBanque.Model
{
    class Cours
    {
        private int idCours;
        private string nomInstru;
        private int payee;
        public Cours(int IdCours, Instrument instrument, int payee)
        {
            this.idCours = IdCours;
            this.nomInstru = instrument.NomInstru;
            this.payee = payee;
        }
        public String NomInstru { get => nomInstru; }
        public int Idcours { get => idCours; }
    }
    

}
