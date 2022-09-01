using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlackJack_DPFacade.Models
{
    public class Joueur
    {
        public int id { get;init; }
        public string? Name { get; set; }
        public int Age  { get; set; }
        public double Mise {get; set; }
        public double Argent { get; set; }

        public bool isDonneur { get; set; }

        public int PointObtenu { get; set; }

    }
}
