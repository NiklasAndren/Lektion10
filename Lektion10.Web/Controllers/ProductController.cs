using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lektion10.Model.Entities;
using Lektion10.Web;
using Lektion10.Model.Abstract;

namespace Lektion10.Web.Controllers
{ 
    public class ProductController : Controller
    {
        private IProductRepository _repo;
        public ProductController(IProductRepository repo) { _repo = repo; }

        //
        // GET: /Product/

        public ViewResult Index()
        {
            return View(_repo.Products);
        }

        //
        // GET: /Product/Details/5

        public ViewResult Details(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repo.Save(product);
                return RedirectToAction("Index");  
            }

            return View(product);
        }
        
        //
        // GET: /Product/Edit/5
 
        public ActionResult Edit(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repo.Save(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /Product/Delete/5
 
        public ActionResult Delete(int id)
        {
            Product product = _repo.Get(id);
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(_repo.Get(id));
            return RedirectToAction("Index");
        }
    }
}