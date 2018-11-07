using ECommerce.DataAccess;
using ECommerce.Model;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    [RoutePrefix("client")]
    public class ClientController : Controller
    {
        private readonly DataContext db = new DataContext();

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

        [Route("detalhes-{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Client client = db.Clients.FirstOrDefault(x=>x.ID == id);
            if (client == null)            
                return HttpNotFound();
            
            return View(client);
        }

        [Route("editar-{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Client client = db.Clients.FirstOrDefault(x => x.ID == id);
            if (client == null)            
                return HttpNotFound();
            
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar-{id}")]
        public ActionResult Edit([Bind(Include = "ID,Name")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Client client = db.Clients.FirstOrDefault(x => x.ID == id);
            if (client == null)            
                return HttpNotFound();
            
            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.FirstOrDefault(x => x.ID == id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}