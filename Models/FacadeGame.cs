using AppBlackJack_DPFacade.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlackJack_DPFacade.Models
{
    public class FacadeGame
    {
        private Joueur joueur;
        private IRegle _regle;
        private Cartes carte;
        private IFabriqueCartes _fabriqueCartes;
        private IFabriqueJoueur _fabriqueJoueur;
        private SauvegardePartie sauvegardePartie;
        private List<Joueur> joueurs;
        private List<Cartes> cartes;
        private HashSet<Cartes> cartesMelange;
        private IConsole _console;

        public FacadeGame(IConsole console,IFabriqueCartes fabriqueCartes,IFabriqueJoueur fabriqueJoueur,IRegle regle)
        {
            _fabriqueCartes = fabriqueCartes;
            _fabriqueJoueur = fabriqueJoueur;
            _regle = regle;
            _console = console;

            sauvegardePartie =new SauvegardePartie();
            joueurs = new List<Joueur>();
            cartes = new List<Cartes>();
           

        }



        public async Task MiseEnPlaceDelaTableAsync() 
        {
            _console.ecrireLigne("\t Creation et mise en place de la Table");
            _fabriqueJoueur.NbreJoueur = 20;
            if (_fabriqueJoueur.isNbrJoueurGreaterThanZero())
            {
                joueurs = _fabriqueJoueur.GetJoueurs().ToList();
                _console.ecrireLigne("\t Liste des joueurs effectuée" + "\n\t Nombre de Joueurs : " + joueurs.Count());

                _console.sautDeligne();

                _console.ecrireLigne("\t Creation du jeu de Cartes");
                cartes = _fabriqueCartes.listeDeCartes().ToList();

                _console.sautDeligne();
                AffichageDeJoueurs();
                await TraitementMelangeCarteAsync();
            }
            else
            {

                if (_fabriqueJoueur.NbreJoueur < 1) { _console.ecrireLigne("\t Nombre de Joueurs insuffisant pour lancer une partie"); }
                if (_fabriqueJoueur.NbreJoueur > 15) { _console.ecrireLigne("\t Nombre de joueurs trop important autour de la Table"); }
                    


            }
           
        }
        

        private void  MelangeCarte()
        {

            cartesMelange = _regle.melangeCartes(cartes).ToHashSet();

            _console.ecrireLigne("\t Les cartes ont été melangées..Traitement Terminé....." + "Nb Cartes : " + cartesMelange.Count());
        }

        private async Task TraitementMelangeCarteAsync()
        {
            _console.ecrireLigne("\t Melange des cartes en cours.....");
            await Task.Run(() => MelangeCarte());
        }

        public void SauvegardeDeLaPartie(Joueur joueur)
        {
           
            sauvegardePartie.SaveDataJoueur(joueur);
        }


        private void AffichageDeJoueurs()
        {
            sauvegardePartie.DeleteFileJoueur();
            _console.ecrireLigne("\t Liste des joueurs ");
            _console.sautDeligne();
            joueurs.ToList().ForEach(j => _console.ecrireLigne($"\t id : {j.id} Name : {j.Name} Age : {j.Age} Mise : {j.Mise}€ Argent : {j.Argent}€ Donneur : {j.isDonneur}  {j.PointObtenu} point(s) "));
            
            foreach (var joueur in joueurs)
            {
                SauvegardeDeLaPartie(joueur);
            }
            
            _console.sautDeligne();
        }

        public void VisualisationDuJeuDeCarte()
        {
            _console.ecrireLigne("\t Liste des cartes ");
            _console.sautDeligne();
            cartes.ToList().ForEach(c => _console.ecrireLigne($"\t  {c.id} {c.Name} {c.ValeurCarte}{c.CarteType}"));
            _console.sautDeligne();
        }
    }
}
