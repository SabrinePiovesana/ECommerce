using ECommerce.DataAccess;
using ECommerce.Model;
using System.Linq;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ClientController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Client
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }
    }
}