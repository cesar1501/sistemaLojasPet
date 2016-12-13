using System.Web.Mvc;
using WebMatrix.WebData;

namespace sistemaLojasPet.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Autentica(string login, string senha)
        {
            if (WebSecurity.Login(login, senha))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index");
            }
        }
    }
}