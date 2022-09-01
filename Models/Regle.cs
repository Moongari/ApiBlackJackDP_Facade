using AppBlackJack_DPFacade.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlackJack_DPFacade.Models
{
    public class Regle : IRegle
    {
        private List<Cartes> ids;

        public Regle()
        {
            ids = new List<Cartes>();
        }
        public bool aGagne(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<List<Tuple<string, string, int, Joueur>>> distributionDesCartes()
        {
            throw new NotImplementedException();
        }



        public void egaliteJoueur(List<Joueur> joueurs)
        {
            throw new NotImplementedException();
        }

        public bool isIdValid(Cartes idCartes)
        {
            if (!ids.Contains(idCartes))
            {
                ids.Add(idCartes);
                return true;
            }
            return false;

        }

        public bool isValidAge(List<Joueur> joueurs)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cartes> melangeCartes(IEnumerable<Cartes> cartes)
        {
            Random rndCartes = new Random();
            int valMax = cartes.Count();
            while (ids.Count < valMax)
            {
                for (int i = cartes.Count() - 1; i >= 0; i--)
                {
                    int k = rndCartes.Next(1, cartes.Count()+1);
                    var carteId = cartes.Where(c => c.id == k).First();
                    if (carteId != null)
                    {
                        if (isIdValid(carteId))
                        {
                           
                            yield return new Cartes() { id = carteId.id, Name = carteId.Name, CarteType = carteId.CarteType, ValeurCarte = carteId.ValeurCarte };

                        }

                    }
                }

   
                var cardNotFirstList = cartes.Except(ids).ToList();
                //foreach (var item in cardNotFirstList)
                //{
                //    Console.WriteLine($" {item.id}");
                //}
            }
        }
    }
}
