using AppBlackJack_DPFacade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlackJack_DPFacade.Models
{
    public class ConsoleDeSortie : IConsole
    {
        public void ecrireLigne(string message)
        {
            Console.WriteLine(message);
        }

        public void sautDeligne()
        {
            Console.WriteLine("");
        }
    }
}
