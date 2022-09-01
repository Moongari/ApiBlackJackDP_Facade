using AppBlackJack_DPFacade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlackJack_DPFacade.Models
{
    public class FabriqueCartes : IFabriqueCartes
    {

        private int cptId = 1;

        /// <summary>
        /// Renvoie et crée une liste de 52 cartes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cartes> listeDeCartes()
        {

            foreach (var itemCarte in Enum.GetNames(typeof(Carte)))
            {
                foreach (var itemType in Enum.GetNames(typeof(TypeDeCarte)))
                {
                    yield return new Cartes() { id= cptId,  Name = itemCarte, CarteType = itemType, ValeurCarte = ValeurCarte(itemCarte) };
                    cptId++;
                }


            }
        }

        /// <summary>
        /// Affecte des valeurs aux cartes
        /// </summary>
        /// <param name="carte"></param>
        /// <returns></returns>
        public int ValeurCarte(string carte)
        {
            int valeurCarte = carte switch
            {
                "Ace" => 1,
                "Two" => 2,
                "Three" => 3,
                "Four" => 4,
                "Five" => 5,
                "Six" => 6,
                "Seven" => 7,
                "Eight" => 8,
                "Nine" => 9,
                "Ten" => 10,
                "Jack"=>10,
                "Queen" => 10,
                "King" => 10,

                _ => -1

            };

            return valeurCarte;
        }
    }
}
