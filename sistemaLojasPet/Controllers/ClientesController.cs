using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using sistemaLojasPet.Entidades;
using sistemaLojasPet.DAO;
using servicosPet.DAO;
using sistemaLojasPet.Models;
using WebMatrix.WebData;
using System.Web.Security;

namespace sistemaLojasPet.Controllers
{
    public class ClientesController : Controller
    {
        private LojaContext context = new LojaContext();
        
        // GET: Clientes
        public ActionResult Index()
        {
            ClientesDAO dao = new ClientesDAO(context);
            IEnumerable<Cliente> clientes = dao.Lista();
            return View(clientes);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            ClientesDAO dao = new ClientesDAO(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente =dao.BuscaPorId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteModel model)
        {
            ClientesDAO dao = new ClientesDAO(context);
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(model.Nome, model.Senha,
                        new { Email = model.Email });
                    return RedirectToAction("Index");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("cliente.Invalido", e.Message);
                    return View("Create", model);
                }
            }
            else
            {
                return View("Create", model);
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            ClientesDAO dao = new ClientesDAO(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = dao.BuscaPorId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email")] Cliente cliente)
        {
            ClientesDAO dao = new ClientesDAO(context);
            if (ModelState.IsValid)
            {
                dao.Update(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            ClientesDAO dao = new ClientesDAO(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = dao.BuscaPorId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientesDAO dao = new ClientesDAO(context);
            Cliente cliente = dao.BuscaPorId(id);
            dao.Remove(cliente);
           
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
