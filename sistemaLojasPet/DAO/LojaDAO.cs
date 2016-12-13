using servicosPet.DAO;
using sistemaLojasPet.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace sistemaLojasPet.DAO
{
    public class LojaDAO
    {
        private LojaContext context;

        public LojaDAO(LojaContext context)
        {
            this.context = context;
        }
        public LojaDAO()
        {

        }

        public IList<Loja> Lista()
        {
            return context.Lojas.ToList();
        }

        public Loja BuscaPorId(int? id)
        {
            return context.Lojas.Find(id);
        }

        public void Adiciona(Endereco endereco,Loja loja)
        {
            var transaction =context.Database.BeginTransaction();
            try
            {
                loja.Endereco = new List<Endereco>();
                context.Enderecos.Add(endereco);
                context.SaveChanges();

                loja.EnderecoID = endereco.ID;

                context.Lojas.Add(loja);
                context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception e)
            {

                transaction.Rollback();
                Console.WriteLine("Transaction Roll backed due to some exception - " + e );
            }
          

        }

        public void Update(Loja loja)
        {
            context.Entry(loja).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(Loja loja)
        {
            context.Lojas.Remove(loja);
            context.SaveChanges();
        }

    }
}