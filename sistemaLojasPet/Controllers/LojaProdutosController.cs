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

namespace sistemaLojasPet.Controllers
{
    public class LojaProdutosController : Controller
    {
        private LojaContext db = new LojaContext();
        private LojaContext context = new LojaContext();
        // GET: LojaProdutos
        public ActionResult Index()
        {

            var lojaProduto = db.LojaProduto.Include(l => l.Loja).Include(l => l.Produto);
            return View(lojaProduto.ToList());
        }

        // GET: LojaProdutos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LojaProduto lojaProduto = db.LojaProduto.Find(id);
            if (lojaProduto == null)
            {
                return HttpNotFound();
            }
            return View(lojaProduto);
        }

        // GET: LojaProdutos/Create
        public ActionResult Create()
        {
            ViewBag.LojaID = new SelectList(db.Lojas, "ID", "RazaoSocial");
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ID", "Nome");
            return View();
        }

        // POST: LojaProdutos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LojaID,ProdutoID,Preco")] LojaProduto lojaProduto)
        {
            if (ModelState.IsValid)
            {
                db.LojaProduto.Add(lojaProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LojaID = new SelectList(db.Lojas, "ID", "RazaoSocial", lojaProduto.LojaID);
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ID", "Nome", lojaProduto.ProdutoID);
            return View(lojaProduto);
        }

        // GET: LojaProdutos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LojaProduto lojaProduto = db.LojaProduto.Find(id);
            if (lojaProduto == null)
            {
                return HttpNotFound();
            }
            ViewBag.LojaID = new SelectList(db.Lojas, "ID", "RazaoSocial", lojaProduto.LojaID);
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ID", "Nome", lojaProduto.ProdutoID);
            return View(lojaProduto);
        }

        // POST: LojaProdutos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LojaID,ProdutoID,Preco")] LojaProduto lojaProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lojaProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LojaID = new SelectList(db.Lojas, "ID", "RazaoSocial", lojaProduto.LojaID);
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ID", "Nome", lojaProduto.ProdutoID);
            return View(lojaProduto);
        }

        // GET: LojaProdutos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LojaProduto lojaProduto = db.LojaProduto.Find(id);
            if (lojaProduto == null)
            {
                return HttpNotFound();
            }
            return View(lojaProduto);
        }

        // POST: LojaProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LojaProduto lojaProduto = db.LojaProduto.Find(id);
            db.LojaProduto.Remove(lojaProduto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
