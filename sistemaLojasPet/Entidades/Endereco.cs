using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaLojasPet.Entidades
{
    public class Endereco
    {
        public int ID { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        public Loja Loja { get; set; }
    }
}