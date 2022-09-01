using AppBlackJack_DPFacade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlackJack_DPFacade.Interface
{
    public interface IFabriqueJoueur
    {
        IEnumerable<Joueur> GetJoueurs();
        int NbreJoueur { get; set; }
        bool isNbrJoueurGreaterThanZero();

    }
}
