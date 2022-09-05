using AppBlackJack_DPFacade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlackJack_DPFacade.Interface
{
    public interface IRegle
    {
        public void aGagne(List<Joueur> joueurs);
        public void egaliteJoueur(List<Joueur> joueurs);
        public bool isValidAge(List<Joueur> joueurs);

        public IEnumerable<Tuple<string, string, int, Joueur>> distributionDesCartes(HashSet<Cartes> cartes,Joueur joueur);

        public IEnumerable<Cartes>melangeCartes(IEnumerable<Cartes> cartes);

        public bool isIdValid(Cartes idCartes);

        public bool isAsAndTenCard();


    }
}
