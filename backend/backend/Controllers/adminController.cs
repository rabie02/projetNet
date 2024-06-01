using backend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace backend.Controllers
{
    public class adminController : Controller
    {
        private readonly MagasinDB2Entities _context = new MagasinDB2Entities();

        public ActionResult index()
        {

            var functionalities = new List<FunctionalityInfo>
            {
                new FunctionalityInfo { Name = "Accueil", Url = Url.Action("Index", "admin") },
                new FunctionalityInfo { Name = "Produits", Url = Url.Action("Indexproduct", "admin") },
                new FunctionalityInfo { Name = "Admins", Url = Url.Action("Indexadmin", "admin") },
                new FunctionalityInfo { Name = "Clients", Url = Url.Action("Indexclient", "admin") },
                new FunctionalityInfo { Name = "Commandes", Url = Url.Action("Indexcommande", "admin") },
                new FunctionalityInfo { Name = "Contacts", Url = Url.Action("Indexcontact", "admin") }
            };
            // Passer la liste à la vue
            return View(functionalities);
        }
                                                     //////////Product//////////////////
        public ActionResult Indexproduct()
        {
            return View(_context.product.ToList());
        }
        public ActionResult CreateProduct()
        {
            return View();
        }

        // POST: admin/CreateProduct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(product Product)
        {
            if (ModelState.IsValid)
            {
                _context.product.Add(Product);
                _context.SaveChanges();
                return RedirectToAction("IndexProduct");
            }

            return View(Product);
        }

        // GET: admin/EditProduct/5
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            product Product = _context.product.Find(id);

            if (Product == null)
            {
                return HttpNotFound();
            }

            return View(Product);
        }
        public ActionResult DetailsProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            product Product = _context.product.Find(id);

            if (Product == null)
            {
                return HttpNotFound();
            }

            return View(Product);
        }

        public ActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            product Product = _context.product.Find(id);

            if (Product == null)
            {
                return HttpNotFound();
            }

            return View(Product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDeleteProduct(int id)
        {
            product Product = _context.product.Find(id);

            if (Product == null)
            {
                return HttpNotFound();
            }

            _context.product.Remove(Product);
            _context.SaveChanges();

            return RedirectToAction("IndexProduct");
        }
        //////////Product//////////////////
        //////////Admin//////////////////
        public ActionResult Indexadmin()
        {
            return View(_context.adminn.ToList());
        }

        public ActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAdmin(adminn Admin)
        {
            if (ModelState.IsValid)
            {
                _context.adminn.Add(Admin);
                _context.SaveChanges();
                return RedirectToAction("Indexadmin");
            }

            return View(Admin);
        }

        public ActionResult EditAdmin(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            adminn Admin = _context.adminn.Find(id);

            if (Admin == null)
            {
                return HttpNotFound();
            }

            return View(Admin);
        }

        public ActionResult DetailsAdmin(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            adminn Admin = _context.adminn.Find(id);

            if (Admin == null)
            {
                return HttpNotFound();
            }

            return View(Admin);
        }

        public ActionResult DeleteAdmin(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            adminn Admin = _context.adminn.Find(id);

            if (Admin == null)
            {
                return HttpNotFound();
            }

            return View(Admin);
        }

        [HttpPost, ActionName("DeleteAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDeleteAdmin(int id)
        {
            adminn Admin = _context.adminn.Find(id);

            if (Admin == null)
            {
                return HttpNotFound();
            }

            _context.adminn.Remove(Admin);
            _context.SaveChanges();

            return RedirectToAction("Indexadmin");
        }
        //////////Admin//////////////////
        //////////Client//////////////////
        public ActionResult Indexclient()
        {
            return View(_context.client.ToList());
        }
        public ActionResult CreateClient()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClient(client Client)
        {
            if (ModelState.IsValid)
            {
                _context.client.Add(Client);
                _context.SaveChanges();
                return RedirectToAction("Indexclient");
            }

            return View(Client);
        }

        public ActionResult EditClient(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            client Client = _context.client.Find(id);

            if (Client == null)
            {
                return HttpNotFound();
            }

            return View(Client);
        }

        public ActionResult DetailsClient(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            client Client = _context.client.Find(id);

            if (Client == null)
            {
                return HttpNotFound();
            }

            return View(Client);
        }

        public ActionResult DeleteClient(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            client Client = _context.client.Find(id);

            if (Client == null)
            {
                return HttpNotFound();
            }

            return View(Client);
        }

        [HttpPost, ActionName("DeleteClient")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDeleteClient(int id)
        {
            client Client = _context.client.Find(id);

            if (Client == null)
            {
                return HttpNotFound();
            }

            _context.client.Remove(Client);
            _context.SaveChanges();

            return RedirectToAction("Indexclient");
        }
        //////////Client//////////////////
        //////////Commandes//////////////////
        public ActionResult Indexcommande()
        {
            return View(_context.commande.ToList());
        }
        public ActionResult CreateCommande()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCommande(commande Commande)
        {
            if (ModelState.IsValid)
            {
                _context.commande.Add(Commande);
                _context.SaveChanges();
                return RedirectToAction("Indexcommande");
            }

            return View(Commande);
        }

        public ActionResult EditCommande(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            commande Commande = _context.commande.Find(id);

            if (Commande == null)
            {
                return HttpNotFound();
            }

            return View(Commande);
        }

        public ActionResult DetailsCommande(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            commande Commande = _context.commande.Find(id);

            if (Commande == null)
            {
                return HttpNotFound();
            }

            return View(Commande);
        }

        public ActionResult DeleteCommande(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            commande Commande = _context.commande.Find(id);

            if (Commande == null)
            {
                return HttpNotFound();
            }

            return View(Commande);
        }

        [HttpPost, ActionName("DeleteCommande")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDeleteCommande(int id)
        {
            commande Commande = _context.commande.Find(id);

            if (Commande == null)
            {
                return HttpNotFound();
            }

            _context.commande.Remove(Commande);
            _context.SaveChanges();

            return RedirectToAction("Indexcommande");
        }
        //////////Commandes//////////////////
        public ActionResult Indexcontact()
        {
            return View(_context.contact.ToList());
        }
     

    }
}