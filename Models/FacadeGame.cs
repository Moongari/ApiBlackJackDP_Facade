using AppBlackJack_DPFacade.Interface;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace AppBlackJack_DPFacade.Models
{
    public class FacadeGame
    {
 
        private IRegle _regle;
        private IFabriqueCartes _fabriqueCartes;
        private IFabriqueJoueur _fabriqueJoueur;
        private SauvegardePartie sauvegardePartie;
        private List<Joueur> joueurs;
        private List<Cartes> cartes;
        private HashSet<Cartes> cartesMelange;
        private IConsole _console;
        private Jeu jeu;
   
        
        public bool Rejouer { get; set; }
       

        public FacadeGame(IConsole console, IFabriqueCartes fabriqueCartes, IFabriqueJoueur fabriqueJoueur, IRegle regle)
        {
            _fabriqueCartes = fabriqueCartes;
            _fabriqueJoueur = fabriqueJoueur;
            _regle = regle;
            _console = console;

            sauvegardePartie = new SauvegardePartie();
            joueurs = new List<Joueur>();
            cartes = new List<Cartes>();
            jeu = new Jeu(new ConsoleDeSortie());
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .CreateLogger();

         
            

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task MiseEnPlaceDelaTableAsync() 
        {
            Log.Information("DEMARRAGE DU JEU ");
            
          
            jeu.Demarrage();
           

            _fabriqueJoueur.NbreJoueur = jeu.NbreDejoueurInJeu;
            if (_fabriqueJoueur.isNbrJoueurGreaterThanZero())
            {
                joueurs = _fabriqueJoueur.GetJoueurs().ToList();
                _console.ecrireLigne("\t Liste des joueurs effectuée" + "\n\t Nombre de Joueurs : " + joueurs.Count());

                _console.sautDeligne();

                //_console.ecrireLigne("\t Creation du jeu de Cartes");
                Log.Write(Serilog.Events.LogEventLevel.Information, "Creation du jeu de Cartes");
                cartes = _fabriqueCartes.listeDeCartes().ToList();

                _console.sautDeligne();
                AffichageDeJoueurs();
                await TraitementMelangeCarteAsync();






                _console.sautDeligne();

                foreach (var joueur in joueurs)
                {
                   var distribution = _regle.distributionDesCartes(cartesMelange, joueur);


                   


                    distribution.ToList().ForEach(d => _console.ecrireLigne($"\t Carte : {d.Item1} Type :{d.Item2}- {d.Item3} Points / Joueur = {d.Item4.Name} "));
                    SauvegardeDeLaPartie(joueur);
                }

                _console.sautDeligne();

                _regle.aGagne(joueurs);

                _console.sautDeligne();

                _regle.egaliteJoueur(joueurs);

            }
            else
            {

                if (_fabriqueJoueur.NbreJoueur < 1) { _console.ecrireLigne("\t Nombre de Joueurs insuffisant pour lancer une partie"); }
                if (_fabriqueJoueur.NbreJoueur > 15) { _console.ecrireLigne("\t Nombre de joueurs trop important autour de la Table"); }

                jeu.Rejouer();

                Rejouer = jeu.isReplay;

            }
           
        }
        
        /// <summary>
        ///  Appel de la methode pour melanger les cartes
        /// </summary>
        private void  MelangeCarte()
        {

            cartesMelange = _regle.melangeCartes(cartes).ToHashSet();

            _console.ecrireLigne("\t Les cartes ont été melangées..Traitement Terminé....." + "Nb Cartes : " + cartesMelange.Count());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private async Task TraitementMelangeCarteAsync()
        {
            _console.ecrireLigne("\t Melange des cartes en cours.....");
            await Task.Run(() => MelangeCarte());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="joueur"></param>
        public void SauvegardeDeLaPartie(Joueur joueur)
        {
           
            sauvegardePartie.SaveDataJoueur(joueur);
        }

        /// <summary>
        /// 
        /// </summary>
        private void AffichageDeJoueurs()
        {
            sauvegardePartie.DeleteFileJoueur();
            _console.ecrireLigne("\t Liste des joueurs ");
            _console.sautDeligne();
            joueurs.ToList().ForEach(j => _console.ecrireLigne($"\t id : {j.id} Name : {j.Name} Age : {j.Age} Mise : {j.Mise}€ Argent : {j.Argent}€ Donneur : {j.isDonneur}  {j.PointObtenu} point(s) "));
            
            //foreach (var joueur in joueurs)
            //{
            //    SauvegardeDeLaPartie(joueur);
            //}
            
            _console.sautDeligne();
        }

        /// <summary>
        /// 
        /// </summary>
        public void VisualisationDuJeuDeCarte()
        {
            _console.ecrireLigne("\t Liste des cartes ");
            _console.sautDeligne();
            cartes.ToList().ForEach(c => _console.ecrireLigne($"\t  {c.id} {c.Name} {c.ValeurCarte}{c.CarteType}"));
            _console.sautDeligne();
        }


        public void FinDePartie()
        {
           
            _console.ecrireLigne("\t ############# FIN DE LA PARTIE #####################");
        }
    }
}
