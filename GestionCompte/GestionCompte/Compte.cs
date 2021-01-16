using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompte
{
   public class Compte
    {

        public List<Mouvements> lMouv { get; set; }
        public int numcompte { get; set; }
        public double solde { get; set; }
        public string titulaire { get; set; }

        public Compte( int numcompte, double solde, string titulaire)
        {
          
            this.numcompte = numcompte;
            this.solde = solde;
            this.titulaire = titulaire;
        }
        public Compte()
        {

        }
        public int nbMouv()
        {
            return lMouv.Count;
        }
        public void nouveauMouv(Mouvements mouv)
        {
            lMouv.Add(mouv);

        }
        public void retirer(double val)
        {
            solde -= val;
        }
        public void verser(double val)
        {
            solde += val;
        }
    }
}
