using servicosPet.DAO;
using sistemaLojasPet.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace sistemaLojasPet.DAO
{
    public class ProdutoDAO
    {
        private LojaContext context;

        public ProdutoDAO(LojaContext context)
        {
            this.context = context;
        }
        public ProdutoDAO()
        {

        }

        public IList<Produto> Lista()
        {
            return context.Produtos.ToList();
        }

        public Produto BuscaPorId(int? id)
        {
            return context.Produtos.Find(id);
        }

        public void Adiciona(Produto produto,LojaProduto lojaProduto)
        {
            context.Produtos.Add(produto);
            context.LojaProduto.Add(lojaProduto);

            context.SaveChanges();

           
          
        }

        public void Update(Produto produto)
        {
            context.Entry(produto).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(Produto produto)
        {
            context.Produtos.Remove(produto);
            context.SaveChanges();
        }
    }
}