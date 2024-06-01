using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace backend.Controllers
{
    public class clientsController : Controller
    {
        // GET: clients
        private readonly MagasinDB2Entities _context = new MagasinDB2Entities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Indexcommande2()
        {
            return View(_context.commande.ToList());
        }
    }
}