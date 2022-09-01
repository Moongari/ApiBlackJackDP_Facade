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
        public bool aGagne(string name);
        public void egaliteJoueur(List<Joueur> joueurs);
        public bool isValidAge(List<Joueur> joueurs);

        public IEnumerable<List<Tuple<string, string, int , Joueur>>> distributionDesCartes();

        public IEnumerable<Cartes>melangeCartes(IEnumerable<Cartes> cartes);

        public bool isIdValid(Cartes idCartes);


    }
}
