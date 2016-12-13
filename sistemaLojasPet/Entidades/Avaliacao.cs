
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaLojasPet.Entidades
{
    public class Avaliacao
    {
        public int ID { get; set; }
        public int ClienteID { get; set; }
        public int LojaID { get; set; }

        public string Avalicao { get; set; }
        public virtual Cliente  Cliente { get; set; }
       
        public virtual Loja Loja { get; set; }

    }
}