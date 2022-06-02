using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBanque.Model
{
    class Instrument
    {
        private int idinstru;
        private string nomInstru;
   
        public Instrument(int idinstru, string nomInstru)
        {
            this.idinstru= idinstru;
            this.nomInstru = nomInstru;
        }
        public String NomInstru { get => nomInstru; }
        public int id { get => idinstru;}
    }
}
