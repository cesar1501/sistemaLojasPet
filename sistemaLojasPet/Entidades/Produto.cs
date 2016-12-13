using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaLojasPet.Entidades
{
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string  Descricao { get; set; }

        public Categoria Categoria { get; set; }
        public int? CategoriaID { get; set; }
       
        public virtual ICollection<LojaProduto> LojaProduto { get; set; }
        //public int ProdutoID { get; set; }
    }
}