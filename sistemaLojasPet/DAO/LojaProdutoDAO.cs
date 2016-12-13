using servicosPet.DAO;
using sistemaLojasPet.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace sistemaLojasPet.DAO
{
    public class LojaProdutoDAO
    {
        private LojaContext context;

        public LojaProdutoDAO(LojaContext context)
        {
            this.context = context;
        }

        public IList<LojaProduto> Lista()
        {
            return context.LojaProduto.ToList();
        }

        public Endereco BuscaPorId(int? id)
        {
            return context.Enderecos.Find(id);
        }

        public void Adiciona(LojaProduto lojaProduto)
        {
            context.LojaProduto.Add(lojaProduto);

            context.SaveChanges();
          
        }

        public void Update(LojaProduto lojaProduto)
        {
            context.Entry(lojaProduto).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(LojaProduto lojaProduto)
        {
            context.LojaProduto.Remove(lojaProduto);
            context.SaveChanges();
        }


    }
}