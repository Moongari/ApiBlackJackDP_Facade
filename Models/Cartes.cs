using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlackJack_DPFacade.Models
{
    public class Cartes
    {

        public int id { get; init; }
        public string? Name { get; set; }
        public int ValeurCarte { get; set; }
        public string CarteType { get; set; }


    }




    public enum Carte
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public enum TypeDeCarte
    {
        Clover,
        Spade,
        Diamonds,
        Heart,
    }
}
