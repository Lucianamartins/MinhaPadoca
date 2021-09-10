using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaPadoca.Models;
using MinhaPadoca.Services.Padaria;
using System;

namespace MinhaPadoca.Controllers
{
    public class BakeriesController : Controller
    {
        private readonly IBakeryService _bakeryService;

        public BakeriesController(IBakeryService bakeryService)
        {
            _bakeryService = bakeryService;
        }
        // GET: BakeriesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BakeriesController/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                Bakery bakery = _bakeryService.GetById(id);
                if (bakery == null)
                {
                    return NotFound();
                }
                return View(bakery);
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        // GET: BakeriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BakeriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection form)
        {
            try
            {
               _bakeryService.Create(form);

                return RedirectToAction("Index", "Home");
                
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: BakeriesController/Edit/5
        public ActionResult Edit(int? id)
        {
            var bakery = _bakeryService.GetById(id);
            return View(bakery);
        }

        // POST: BakeriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, IFormCollection collection)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var bakery = _bakeryService.GetById(id);

                if (bakery == null)
                {
                    return NotFound();
                }



                bakery = _bakeryService.Update(bakery.Id, collection);

                return RedirectToAction("Edit", new { id = bakery.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: BakeriesController/Delete/5
        public ActionResult Delete(int id)
        {
            var bakery = _bakeryService.GetById(id);
            if (bakery == null)
            {
                return NotFound();
            }
            return View(bakery);
        }

        // POST: BakeriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var bakery = _bakeryService.GetById(id);
                if (bakery == null)
                {
                    return NotFound();
                }

                _bakeryService.Delete(bakery);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public string GetByName(string name)
        {
            var bakery = _bakeryService.GetByName(name);
            var dados = string.Empty;
            if (bakery != null)
            {
                return   "Nome de padaria já existe, favor escolher outro nome!";
            }

            return null;

        }
    }
}
