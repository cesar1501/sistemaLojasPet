
using servicosPet.DAO;
using sistemaLojasPet.Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace sistemaLojasPet.DAO
{
    public class CategoriaDAO
    {
         private LojaContext context;

        public CategoriaDAO(LojaContext context)
        {
            this.context = context;
        }
 
       
        public IList<Categoria> Lista()
        {
            return context.Categorias.ToList();
        }

        public Categoria BuscaPorId(int? id)
        {
            return context.Categorias.Find(id);
        }

        public void Adiciona(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            context.SaveChanges();
        }

        public void Update(Categoria categoria)
        {
            context.Entry(categoria).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(Categoria categoria)
        {
            context.Categorias.Remove(categoria);
            context.SaveChanges();
        }
        public void Dispose() 
        {
            context.Dispose();
        }

    }
}