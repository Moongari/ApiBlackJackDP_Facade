﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlackJack_DPFacade.Interface
{
    public interface IConsole
    {
        public void ecrireLigne(string message);
        public void sautDeligne();
    }
}
