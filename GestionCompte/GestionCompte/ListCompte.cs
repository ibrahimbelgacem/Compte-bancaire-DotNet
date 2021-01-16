using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCompte
{
    class ListCompte
    {

       // public List<Compte> lCompte=new List<Compte>();
        public static List<Compte> lCompte1=new List<Compte>();
        public ListCompte()
        {
           
        }
        public void ajouter(Compte c)
        {
            
            lCompte1.Add(c);

            
            
        }
        public Compte rechercher(int numC)
        {
            
       
            
            int i = 0;
       
            while (i < lCompte1.Count) 
            {
                if (lCompte1.ElementAt(i).numcompte == numC) { 
                 
                    
                    return lCompte1[i];
                }
                else
                    i++;
            }
          
            return null;
        }
        public void supprimer(Compte c)
        {
            if(lCompte1.Contains(c))
            lCompte1.Remove(c);                       
        }
        
     
    }
}
