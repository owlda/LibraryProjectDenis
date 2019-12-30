using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject.Models;
using LibraryProject.Models.LivresViewModel;

namespace LibraryProject.Views.Home
{
    public class LivreController : Controller
    {

        ApplicationDbContext _dbContextLivre;
        private List<Livre> _list = new List<Livre>();
        public LivreController() {

            _dbContextLivre = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContextLivre.Dispose();
        }

        // GET: Livre
        [HttpGet]
        [AllowAnonymous]
        [Route("livre/show")]
        public ActionResult Show()
        {
            var _list = new List<Livre>();
            var book1 = new Livre();
            var book6 = new Livre();
            var book2 = new Livre();
            var book3 = new Livre();
            var book4 = new Livre();
            var book5 = new Livre();
            book1.Id = 1;
            book1.Name = "Design d'expérience utilisateur : principes et méthodes UX";
            book1.Description = "Conception participative (Conception de systèmes) Interfaces utilisateurs (Informatique)";
            book1.Category = "14+ (Jeunes)";
            book1.Author = "Daumal, Sylvie";
            book1.NumberAvalible = "Disponible";
            book2.Id = 2;
            book2.Name = "Design d'expérience utilisateur : principes et méthodes UX";
            book2.Description = "Conception participative (Conception de systèmes) Interfaces utilisateurs (Informatique)";
            book2.Category = "14+ (Jeunes)";
            book2.Author = "Daumal, Sylvie";
            book2.NumberAvalible = "Disponible";
            book3.Id = 3;
            book3.Name = "Design d'expérience utilisateur : principes et méthodes UX";
            book3.Description = "Conception participative (Conception de systèmes) Interfaces utilisateurs (Informatique)";
            book3.Category = "14+ (Jeunes)";
            book3.Author = "Daumal, Sylvie";
            book3.NumberAvalible = "Disponible";
            book4.Id = 4;
            book4.Name = "Design d'expérience utilisateur : principes et méthodes UX";
            book4.Description = "Conception participative (Conception de systèmes) Interfaces utilisateurs (Informatique)";
            book4.Category = "14+ (Jeunes)";
            book4.Author = "Daumal, Sylvie";
            book4.NumberAvalible = "Disponible";
            book5.Id = 5;
            book5.Name = "Design d'expérience utilisateur : principes et méthodes UX";
            book5.Description = "Conception participative (Conception de systèmes) Interfaces utilisateurs (Informatique)";
            book5.Category = "14+ (Jeunes)";
            book5.Author = "Daumal, Sylvie";
            book5.NumberAvalible = "Disponible";
            book6.Id = 6;
            book6.Name = "Design d'expérience utilisateur : principes et méthodes UX";
            book6.Description = "Conception participative (Conception de systèmes) Interfaces utilisateurs (Informatique)";
            book6.Category = "14+ (Jeunes)";
            book6.Author = "Daumal, Sylvie";
            book6.NumberAvalible = "Disponible";
            _list.Add(book1); _list.Add(book2); _list.Add(book3); _list.Add(book4); _list.Add(book5); _list.Add(book6);
            return View("ShowForUser", _list);
                    
        }
        // GET: Livre/Create
        [HttpGet]
        [Authorize]
        [Route("livre/create")]
        public ActionResult Create() {
            ViewBag.Total = _dbContextLivre.Reservations.Count(c => c.IDUser == this.User.Identity.Name);
            var _modelCreateLivre = new Livre(){};
            return View(_modelCreateLivre);
        }
        // POST: Livre/Create
        [HttpPost]
        [Authorize]
        [Route("livre/create")]
        public ActionResult Create(Livre livre)
        {
            ViewBag.Total = _dbContextLivre.Reservations.Count(c => c.IDUser == this.User.Identity.Name);
            _dbContextLivre.Livres.Add(livre);
            _dbContextLivre.SaveChanges();
            return RedirectToAction("index", "home");

        }
        // GET: Livre/Edit/5        
        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.Total = _dbContextLivre.Reservations.Count(c => c.IDUser == this.User.Identity.Name);
            var _livre = _dbContextLivre.Livres.SingleOrDefault(c => c.Id == id);
            if (_livre == null)
            {
                return HttpNotFound();
            }
            else
            {
                var modelEdit = _livre;                
                return View(modelEdit);

            }
        }
        // POST: Livre/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(Livre livre)
        {

            var livreInDB = _dbContextLivre.Livres.Single(c => c.Id == livre.Id);
            ViewBag.Total = _dbContextLivre.Reservations.Count(c => c.IDUser == this.User.Identity.Name);
            livreInDB.Name = livre.Name;
            livreInDB.Description = livre.Description;
            livreInDB.Author = livre.Author;
            livreInDB.Category = livre.Category;
            livreInDB.NumberAvalible = livre.NumberAvalible;

            _dbContextLivre.SaveChanges();
            return RedirectToAction("show", "livre");

        }
        // GET: Livre/DELETE/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            ViewBag.Total = _dbContextLivre.Reservations.Count(c => c.IDUser == this.User.Identity.Name);
            var _livre = _dbContextLivre.Livres.SingleOrDefault(c => c.Id == id);
            if (_livre == null)
            {
                return HttpNotFound();
            }
            else
            {
                var modelDelete = new Livre(){};
                return View(modelDelete);
            }
        }
        // POST: Livre/DELETE/5
        [HttpPost]
        [Authorize]
        public ActionResult Delete(Livre livre)
        {
            ViewBag.Total = _dbContextLivre.Reservations.Count(c => c.IDUser == this.User.Identity.Name);
            var livreInDB = _dbContextLivre.Livres.Single(c => c.Id == livre.Id);
            _dbContextLivre.Livres.Remove(livreInDB);
            _dbContextLivre.SaveChanges();
            return RedirectToAction("Show", "livre");

        }

        [HttpGet]
        [AllowAnonymous]
        [Route("livre/details/{id:regex(\\d+)}")]
        public ActionResult ShowByID(int id)
        {
            var details = _list.Single(c => c.Id == id);
            if (details == null)
            {
                return HttpNotFound();
            }
            else
            {
               
                var viewModel = details;
                return View(viewModel);
            }

        }

        // GET: Reserver
        [HttpGet]
        [Authorize]
        [Route("livre/reserver/{id:regex(\\d+)}")]
        public ActionResult Reserver(int id)
        {           
                var _rent = _dbContextLivre.Livres.Single(c => c.Id == id);
                if (_rent == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    ViewBag.Total = _dbContextLivre.Reservations.Count(c => c.IDUser == this.User.Identity.Name);
                    var viewModel = _rent;
                    return View(viewModel);
                }        

        }       

        // POST: Livre/RESERVERPOST/5
        [HttpPost]
        [Authorize]
        public ActionResult ReserverPost(int id)
        {
            ViewBag.Total = _dbContextLivre.Reservations.Count(c => c.IDUser == this.User.Identity.Name);
            
            if (_dbContextLivre.Reservations.Count(c => c.IDUser == this.User.Identity.Name) >= 3)
            {
                ViewBag.Total = _dbContextLivre.Reservations.Count(c => c.IDUser == this.User.Identity.Name);
                return View("Error");

            }
            else
            {
                var _reservationDB = _dbContextLivre.Reservations;
                var _livresDB = _dbContextLivre.Livres;

                var livreInDB = _dbContextLivre.Livres.Single(c => c.Id == id);

                if (livreInDB == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    livreInDB.NumberAvalible = "Non disponible";

                    var reservation = new Reservation()
                    {
                        DateTimeReservation = DateTime.Now,
                        DateTimeRetour = DateTime.Now.AddDays(3),
                        Author = livreInDB.Author,
                        Category = livreInDB.Category,
                        Description = livreInDB.Description,
                        IDUser = this.User.Identity.Name,
                        Name = livreInDB.Name,
                        NumberAvalible = "Non disponible",
                        NumberInCatalog = livreInDB.Id
                    };
                    _reservationDB.Add(reservation);
                    _dbContextLivre.SaveChanges();
                    return RedirectToAction("Show", "livre");
                }

            }          

        }

    }    
}