using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using servicosPet.DAO;
using sistemaLojasPet.Entidades;
using sistemaLojasPet.DAO;

namespace sistemaLojasPet.Controllers
{
    public class CategoriasController : Controller
    {
        private LojaContext context = new LojaContext();

        // GET: Categorias
        public ActionResult Index()
        {
            CategoriaDAO dao = new CategoriaDAO(context);
            return View(dao.Lista());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            CategoriaDAO dao = new CategoriaDAO(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = dao.BuscaPorId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Descricao")] Categoria categoria)
        {
            CategoriaDAO dao = new CategoriaDAO(context);
            if (ModelState.IsValid)
            {
               dao.Adiciona(categoria);
              
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            CategoriaDAO dao = new CategoriaDAO(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = dao.BuscaPorId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Descricao")] Categoria categoria)
        {
            CategoriaDAO dao = new CategoriaDAO(context);
            if (ModelState.IsValid)
            {
                dao.Update(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            CategoriaDAO dao = new CategoriaDAO(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = dao.BuscaPorId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaDAO dao = new CategoriaDAO(context);
            Categoria categoria = dao.BuscaPorId(id);
            dao.Remove(categoria);
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            CategoriaDAO dao = new CategoriaDAO(context);
            if (disposing)
            {
                dao.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
