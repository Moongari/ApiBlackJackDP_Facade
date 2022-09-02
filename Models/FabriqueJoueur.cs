using AppBlackJack_DPFacade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlackJack_DPFacade.Models
{
    public class FabriqueJoueur : IFabriqueJoueur
    {
      
        public int NbreJoueur { get ; set ; }

        private Random rndMise;
        private Random rndArgent;
        private Random rndAge;
        private Random rndIsDonneur;
        private bool _isDonneur = false;
        private int _maxJoueurs = 20;
        private int _minJoueurs = 2;
     

        public FabriqueJoueur()
        {
            rndMise = new Random();
            rndArgent = new Random();
            rndAge = new Random();
            rndIsDonneur = new Random();
           
        }

        public IEnumerable<Joueur> GetJoueurs()
        {
            if (isNbrJoueurGreaterThanZero())
            {

         
            int donneur = rndIsDonneur.Next(1, NbreJoueur);

            for (int i = 0; i < NbreJoueur; i++)
            {
                int mise = rndMise.Next(30, 100);
                int argent = rndArgent.Next(10, 200);
                int age = rndAge.Next(10, 70);
               

                if (donneur == i) { _isDonneur = true; } else { _isDonneur = false; }
                yield return new Joueur() { id = i, Name = "Joueur_"+i, Age = age, Mise = mise, Argent = argent, isDonneur = _isDonneur, PointObtenu = 0 };

            }

                //yield return new Joueur() { id = 2, Name = "Robert", Age =34, Mise = 23, Argent = 100, isDonneur = false, PointObtenu = 0 };
                //yield return new Joueur() { id = 3, Name = "Jacky", Age = 45, Mise = 26, Argent = 200, isDonneur = false, PointObtenu = 0 };
                //yield return new Joueur() { id = 4, Name = "Mouloud", Age = 26, Mise = 39, Argent = 200, isDonneur = false, PointObtenu = 0 };
                //yield return new Joueur() { id = 5, Name = "Imane", Age = 17, Mise = 23, Argent = 40, isDonneur = false, PointObtenu = 0 };
                //yield return new Joueur() { id = 6, Name = "Soulaymane", Age = 17, Mise = 20, Argent = 100, isDonneur = false, PointObtenu = 0 };
                //yield return new Joueur() { id = 7, Name = "Francois", Age = 38, Mise = 78, Argent = 400, isDonneur = false, PointObtenu = 0 };
                //yield return new Joueur() { id = 8, Name = "Carry", Age = 67, Mise = 30, Argent = 1000, isDonneur = false, PointObtenu = 0 };
            }
           
        }

        public bool isNbrJoueurGreaterThanZero()
        {
            return NbreJoueur > _minJoueurs && NbreJoueur <= _maxJoueurs;
        }
    }
}
