using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KirsEntityModulMVC.Core.Interaces;
using KursEntityModulMVC.SQLDataAcces;
using KursEntityModulMVC.SQLDataAcces.Entities;
using KursEntityModulMVC.SQLDataAcces.Repositories;

namespace KursEntityModulMVC.Controllers
{
    public class BookController : Controller
    {
        CoursesDbContext context = new CoursesDbContext();

        Repository<Book,Guid> rep = new Repository<Book,Guid>();


        private readonly IManager<Book,Guid> _repo;

        public BookController()
        {

        }

        public BookController(IManager<Book,Guid> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult Index()
        {
            SelectList Authors = new SelectList(context.Authors, "Id", "Name");
            ViewBag.Author = Authors;
            return View(_repo.GetAll());
        }
       

        // GET: CustomStudents/Details/5
        public ActionResult Details(Guid id)
        {
            
            var mod = _repo.Get(id);
            return View(mod);
        }
        [HttpGet]
        public ActionResult Create()
        {
            Book bk = new Book();
            bk.Authors = context.Authors.ToList();
            SelectList Genres = new SelectList(context.Genres, "Id", "Title");
            ViewBag.Genre = Genres;
            SelectList Statuses = new SelectList(context.Statuses, "Id", "Title");
            ViewBag.Status = Statuses;
            SelectList Authors = new SelectList(context.Authors, "Id", "Name");
            ViewBag.Author = Authors;

            return View();  
        }
        [HttpPost]
        public ActionResult Create(Book model)
        {
                _repo.Create(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            return View(_repo.Get(id));
        }
        [HttpPost]
        public ActionResult Delete(Guid id, object o)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            SelectList Genres = new SelectList(context.Genres, "Id", "Title");
            ViewBag.Genre = Genres;
            return View(_repo.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Book model, Guid id)
        {
            _repo.Edit(model, id);
            return RedirectToAction("Index");
        }
    }
}
