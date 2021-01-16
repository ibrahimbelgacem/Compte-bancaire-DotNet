using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompte
{

    public class Mouvements
    {
        public DateTime dateop { get; set; }
        public double montant { get; set; }
        public string typeop { get; set; }
        public int numC { get; set; }

        public static List<Mouvements> listMouvements = new List<Mouvements>();
        public Mouvements() { }
        public Mouvements(DateTime dateop, double montant, string typeop,int numC)
        {
            this.numC = numC;
            this.dateop = dateop;
            this.montant = montant;
            this.typeop = typeop;
        }
        public void ajoutMouv(Mouvements mv)
        {
            listMouvements.Add(mv);
        }
        public Mouvements rechercheMouv(DateTime dateMv)
        {
            {



                int i = 0;

                while (i < listMouvements.Count)
                {
                    if (listMouvements.ElementAt(i).dateop == dateMv)
                    {


                        return listMouvements[i];
                    }
                    else
                        i++;
                }

                return null;
            }
        }
    }
}
