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
    public class LojasController : Controller
    {
        
        private LojaContext context = new LojaContext();

        // GET: Lojas
        public ActionResult Index()
        {
            LojaDAO dao = new LojaDAO(context);
            IEnumerable<Loja> lojas = dao.Lista();
            return View(lojas);
        }

        // GET: Lojas/Details/5
        public ActionResult Details(int? id)
        {
            LojaDAO dao = new LojaDAO(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = dao.BuscaPorId(id);
            if (loja == null)
            {
                return HttpNotFound();
            }
            return View(loja);
        }

        // GET: Lojas/Create
        public ActionResult Create()
        {
            ViewBag.LojaID = new SelectList(context.Lojas, "ID", "RazaoSocial");
            return View();
        }

        // POST: Lojas/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Logradouro,Cep,Bairro,Cidade,Loja_ID")] Endereco endereco,[Bind(Include = "ID,RazaoSocial,Email,Telefone,HorarioFuncionamento,EnderecoID")] Loja loja )

        {
            if (ModelState.IsValid)
            {
                LojaDAO dao = new LojaDAO(context);
                dao.Adiciona(endereco,loja);
               
                return RedirectToAction("Index");
            }

            return View(loja);
        }

        // GET: Lojas/Edit/5
        public ActionResult Edit(int? id)
        {
            LojaDAO dao = new LojaDAO(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = dao.BuscaPorId(id);
            if (loja == null)
            {
                return HttpNotFound();
            }
            return View(loja);
        }

        // POST: Lojas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RazaoSocial,Email,Telefone,HorarioFuncionamento,EnderecoID")] Loja loja)
        {
            LojaDAO dao = new LojaDAO(context);
            if (ModelState.IsValid)
            {
                dao.Update(loja);
           
                return RedirectToAction("Index");
            }
            return View(loja);
        }

        // GET: Lojas/Delete/5
        public ActionResult Delete(int? id)
        {
             LojaDAO dao = new LojaDAO(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = dao.BuscaPorId(id);
            if (loja == null)
            {
                return HttpNotFound();
            }
            return View(loja);
        }

        // POST: Lojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LojaDAO dao = new LojaDAO(context);

            Loja loja = dao.BuscaPorId(id);
            dao.Remove(loja);
            
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
