using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using backend.Models;

namespace backend.Controllers
{

    public class AccountController : Controller
    {
        private readonly MagasinDB2Entities _context = new MagasinDB2Entities();
        public ActionResult Index()
        {
            return View(_context.adminn.ToList());
        }
    }
}