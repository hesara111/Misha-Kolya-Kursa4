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

namespace KursEntityModulMVC.Controllers
{
    public class AuthorController : Controller
    {
        CoursesDbContext context = new CoursesDbContext();

        private readonly IManager<Author,int> _repo;

        public AuthorController()
        {

        }

        public AuthorController(IManager<Author,int> repo)
        {
            _repo = repo;
        }

        
        public ActionResult Index()
        {
            return View(_repo.GetAll());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var mod = _repo.Get(id);
            return View(mod);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Author model)
        {
            _repo.Create(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_repo.Get(id));
        }
        [HttpPost]
        public ActionResult Delete(int id,object o)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_repo.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Author model, int id)
        {
            _repo.Edit(model,id);
            return RedirectToAction("Index");
        }
    }
}
