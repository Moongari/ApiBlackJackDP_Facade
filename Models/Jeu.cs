using AppBlackJack_DPFacade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlackJack_DPFacade.Models
{
    public  class Jeu
    {
        public Joueur Joueur { get; set; }
        public Cartes Cartes { get; set; }
        public Regle Regle { get; set; }
        public IFabriqueJoueur _fabriqueJoueur;
        public int NbreDejoueurInJeu { get; set; }
        public bool isReplay { get; set; }
        private int iNbrejoueur = 0;
        private IConsole _console;





        public Jeu (IConsole console)
        {
            _console = console;
            
            _console.ecrireLigne("\t\t ## BIENVENUE AU JEU DU BLACK JACK #### ");
        }



        public void Demarrage()

        {
            
            while (true)
            {
                _console.ecrireLigneSansRetourLigne("\t\t ## Veuillez indiquer le nombre de Joueur :  ");
                string? nbreJoueur = Console.ReadLine();

                if (nbreJoueur != null)
                {
                    if (isNbrJoueurValid(nbreJoueur))
                    {
                        NbreDejoueurInJeu = iNbrejoueur;
                        _console.ecrireLigne($"\t ## Nombre de personnes autour de la Table : {iNbrejoueur}  #### ");
                        
                        break;
                    }
                    else
                    {
                        _console.ecrireLigne("\t Valeur saisie incorrect !");
                    }
                }
              
            }
           


        }



        private bool isNbrJoueurValid(string nbjoueur)
        {
                
            return int.TryParse(nbjoueur, out iNbrejoueur);
        }

        public void Rejouer()
        {
            while (true)
            {
                _console.ecrireLigne("\t Desirez vous rejouer une partie ? ");
                _console.ecrireLigne("\t Si Oui Tapez O / Tapez N ");
                string response = Console.ReadLine();
                if (response[0] == 'O')
                {
                    isReplay = true;
                    break;
                }
                else
                {
                    isReplay = false;
                    break;
                }
            }
        }
    }
}
