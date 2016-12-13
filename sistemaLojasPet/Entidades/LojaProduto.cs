using sistemaLojasPet.Entidades;

namespace sistemaLojasPet.Entidades
{
    public class LojaProduto
    {
        public int ID { get; set; }
        public int LojaID { get; set; }
        public int ProdutoID { get; set; }

        public decimal Preco { get; set; }

        public virtual Loja Loja { get; set; }
        public virtual Produto Produto { get; set; }
    }
}