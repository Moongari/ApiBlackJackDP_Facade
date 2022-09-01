using AppBlackJack_DPFacade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlackJack_DPFacade.Interface
{
    public interface IFabriqueCartes
    {
        IEnumerable<Cartes> listeDeCartes();
        int ValeurCarte(string carte);
    }
}
