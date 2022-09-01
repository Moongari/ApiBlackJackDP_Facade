// See https://aka.ms/new-console-template for more information

using AppBlackJack_DPFacade.Models;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;

FacadeGame game = new FacadeGame(new ConsoleDeSortie(),new FabriqueCartes(),new FabriqueJoueur(),new Regle());
await game.MiseEnPlaceDelaTableAsync();





Console.ReadKey();
