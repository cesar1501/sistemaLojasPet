using servicosPet.DAO;
using sistemaLojasPet.Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace sistemaLojasPet.DAO
{
    public class EnderecoDAO
    {
        private LojaContext context;

        public EnderecoDAO(LojaContext context)
        {
            this.context = context;
        }


        public IList<Endereco> Lista()
        {
            return context.Enderecos.ToList();
        }

        public Endereco BuscaPorId(int? id)
        {
            return context.Enderecos.Find(id);
        }

        public void Adiciona(Endereco endereco)
        {
            context.Enderecos.Add(endereco);
            
            context.SaveChanges();
           
        }

        public void Update(Endereco endereco)
        {
            context.Entry(endereco).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(Endereco endereco)
        {
            context.Enderecos.Remove(endereco);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
