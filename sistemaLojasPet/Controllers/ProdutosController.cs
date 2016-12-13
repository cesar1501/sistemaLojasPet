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
    public class ProdutosController : Controller
    {
       
        private LojaContext context = new LojaContext();
        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = context.Produtos.Include(p => p.Categoria);
            return View(produtos.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            ProdutoDAO dao = new ProdutoDAO(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = dao.BuscaPorId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.LojaID = new SelectList(context.Lojas, "ID", "RazaoSocial");
           
            ViewBag.CategoriaID = new SelectList(context.Categorias, "ID", "Nome");
           // ViewBag.ProdutoID = new SelectList(context.Produtos, "ID", "Nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Descricao,CategoriaID")] Produto produto, [Bind(Include = "ID,LojaID,ProdutoID,Preco")] LojaProduto lojaProduto)
        {
            ProdutoDAO dao = new ProdutoDAO(context);
           
            if (ModelState.IsValid)
            {
                dao.Adiciona(produto, lojaProduto);
               // lojaProduto.ProdutoID = dao.Adiciona(produto);

                //lojaProdDAO.Adiciona(lojaProduto);
             
               
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(context.Categorias, "ID", "Nome", produto.CategoriaID);

            return View(produto);

           
           
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            ProdutoDAO dao = new ProdutoDAO(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = dao.BuscaPorId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(context.Categorias, "ID", "Nome", produto.CategoriaID);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Descricao,CategoriaID")] Produto produto)
        {
            ProdutoDAO dao = new ProdutoDAO(context);
            if (ModelState.IsValid)
            {
                dao.Update(produto);
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(context.Categorias, "ID", "Nome", produto.CategoriaID);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            ProdutoDAO dao = new ProdutoDAO(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = dao.BuscaPorId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdutoDAO dao = new ProdutoDAO(context);

            Produto produto = dao.BuscaPorId(id);
            dao.Remove(produto);
           
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
