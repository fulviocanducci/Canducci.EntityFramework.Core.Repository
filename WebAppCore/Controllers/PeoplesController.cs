using Canducci.EntityFramework.Repository.EFCore.Mvc.Extensions;
using Microsoft.AspNetCore.Mvc;
using WebAppCore.Models;
using System.Linq;
using Canducci.EntityFramework.Repository.Core;
using System;

namespace WebAppCore.Controllers
{
    public class PeoplesController : Controller
    {
        private IRepositoryPeople Repository { get; }

        public PeoplesController(IRepositoryPeople repository)
        {
            Repository = repository;
        }
        
        public ActionResult Index()
        {
            var lista = Repository
                .Query(s => new { s.Id, s.Name }, o => o.Name, o => o.Id)                   
                .ToSelectList("Id", "Name");

            ViewData["lista"] = lista;

            return View(Repository.Get(x => x.Name));
        }
        
        public ActionResult Details(int id)
        {
            
            return View(Repository.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(People people)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repository.Add(people);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
                
        public ActionResult Edit(int id)
        {
            return View(Repository.Find(id));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, People people)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repository.Edit(people);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
                
        public ActionResult Delete(int id)
        {
            return View(Repository.Find(id));
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, People people)
        {
            try
            {
                if (id > 0)
                {
                    Repository.Delete(id);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}