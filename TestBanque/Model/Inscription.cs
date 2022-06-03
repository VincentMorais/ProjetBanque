using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBanque.Model
{
    class Inscription
    {
        private Adherent unAdherent;
        private Cours unCours;

        private int payee;
        private int solde;


        public Inscription(Adherent unAdherent, Cours unCours, int payee, int solde)
        {
            this.unAdherent = unAdherent;
            this.unCours = unCours;
            this.payee = payee;
            this.solde = solde;
            
        }
        public void crediter(int montant)
        {
            solde = montant + solde;
            
        }

        public bool insciPayee()
        {
            if (this.payee == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public int Payee { get => Payee; } 
        public Adherent UnAdherent { get => unAdherent; }
        public Cours UnCours { get => unCours; }
        public int Solde { get => solde; }
     

        public override string ToString()
        {
            return ("Cours :"+ unCours.NomInstru+" ; payee : "+this.payee+" ; Solde"+this.solde+";");
        }
    }  
}
