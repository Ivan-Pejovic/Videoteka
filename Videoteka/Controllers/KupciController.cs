using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videoteka.Models;

namespace Videoteka.Controllers
{
    public class KupciController : Controller
    {
        public ApplicationDbContext _context;

        public KupciController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}