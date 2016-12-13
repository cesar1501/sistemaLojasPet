using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using servicosPet.DAO;
using sistemaLojasPet.Entidades;
using sistemaLojasPet.DAO;

namespace sistemaLojasPet.Controllers
{
    public class EnderecosController : Controller
    {
        
        private LojaContext context = new LojaContext();

        // GET: Enderecoes
        public ActionResult Index()
        {
            EnderecoDAO dao = new EnderecoDAO(context);
            return View(dao.Lista());
        }

        // GET: Enderecoes/Details/5
        public ActionResult Details(int? id)
        {
            EnderecoDAO dao = new EnderecoDAO(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = dao.BuscaPorId(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: Enderecoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enderecoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Logradouro,Cep,Bairro,Cidade")] Endereco endereco)
        {
            EnderecoDAO dao = new EnderecoDAO(context);
            if (ModelState.IsValid)
            {
                dao.Adiciona(endereco);
                
                return RedirectToAction("Index");
            }

            return View(endereco);
        }

        // GET: Enderecoes/Edit/5
        public ActionResult Edit(int? id)
        {
            EnderecoDAO dao = new EnderecoDAO(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco =dao.BuscaPorId(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Enderecoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Logradouro,Cep,Bairro,Cidade")] Endereco endereco)
        {
            EnderecoDAO dao = new EnderecoDAO(context);
            if (ModelState.IsValid)
            {
                dao.Update(endereco);
                return RedirectToAction("Index");
            }
            return View(endereco);
        }

        // GET: Enderecoes/Delete/5
        public ActionResult Delete(int? id)
        {
            EnderecoDAO dao = new EnderecoDAO(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = dao.BuscaPorId(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Enderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnderecoDAO dao = new EnderecoDAO(context);
            Endereco endereco = dao.BuscaPorId(id);
            dao.Remove(endereco);
           
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            EnderecoDAO dao = new EnderecoDAO(context);
            if (disposing)
            {
                dao.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
