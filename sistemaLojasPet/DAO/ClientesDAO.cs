using servicosPet.DAO;
using sistemaLojasPet.Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace sistemaLojasPet.DAO
{

    public class ClientesDAO
    {
        private LojaContext context;

        public ClientesDAO(LojaContext context)
        {
            this.context = context;
        }
        public ClientesDAO()
        {

        }
       
        public IList<Cliente> Lista()
        {
           return context.Clientes.ToList();
        }

        public Cliente BuscaPorId(int? id)
        {
            return context.Clientes.Find(id);
        }

        public void Adiciona(Cliente cliente)
        {
            context.Clientes.Add(cliente);
            context.SaveChanges();
        }

        public void Update(Cliente cliente)
        {
            context.Entry(cliente).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(Cliente cliente)
        {
            context.Clientes.Remove(cliente);
            context.SaveChanges();
        }

    }
}