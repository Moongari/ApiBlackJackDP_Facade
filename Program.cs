// See https://aka.ms/new-console-template for more information

using AppBlackJack_DPFacade.Models;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;

Log.Information("LANCEMENT APPLICATION");
FacadeGame game = new FacadeGame(new ConsoleDeSortie(),new FabriqueCartes(),new FabriqueJoueur(),new Regle());


await game.MiseEnPlaceDelaTableAsync();

    if (game.Rejouer)
    {
        await game.MiseEnPlaceDelaTableAsync();
    }
    else
    {
        game.FinDePartie();
    }



Console.ReadKey();
