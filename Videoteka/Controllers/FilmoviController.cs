using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Videoteka.Models;
using Videoteka.ViewModels;

namespace Videoteka.Controllers
{
    public class FilmoviController : Controller
    {
        private ApplicationDbContext _context;

        public FilmoviController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Novi()
        {
            var zanrovi = _context.Zanrovi.ToList();
            var viewModel = new FilmViewModel
            {
                Film = new Film(),
                Zanrovi = zanrovi
            };

            return View("FilmForma", viewModel);
        }

        public ActionResult Izmijeni(int id)
        {
            var film = _context.Filmovi.SingleOrDefault(f => f.Id == id);

            if (film == null)
                return HttpNotFound();

            var viewModel = new FilmViewModel
            {
                Film = film,
                Zanrovi = _context.Zanrovi.ToList()
            };

            return View("FilmForma", viewModel);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Save(Film film)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new FilmViewModel
                {
                    Film = film,
                    Zanrovi = _context.Zanrovi.ToList()
                };

                return View("FilmForma", viewModel);
            }

            film.DatumUnosa = DateTime.Now;

            if(film.Id == 0)
            {
                _context.Filmovi.Add(film);
            }
            else
            {
                var filmInDb = _context.Filmovi.Single(f => f.Id == film.Id);

                filmInDb.Naziv = film.Naziv;
                filmInDb.ZanrId = film.ZanrId;
                filmInDb.DatumIzdanja = film.DatumIzdanja;
                filmInDb.BrojNaStanju = film.BrojNaStanju;
                filmInDb.BrojDostupnih = film.BrojDostupnih;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Filmovi");
        }

        public void Delete(int id)
        {
            var filmInDb = _context.Filmovi.SingleOrDefault(f => f.Id == id);

            if (filmInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Filmovi.Remove(filmInDb);
            _context.SaveChanges();
        }
    }
}