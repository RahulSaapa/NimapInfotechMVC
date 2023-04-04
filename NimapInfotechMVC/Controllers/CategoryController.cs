using NimapInfotechMVC.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using NimapInfotechMVC.Models;

namespace NimapInfotechMVC.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepo categoryRepo = new CategoryRepo();
        public ActionResult Index(string Search, int? i)
        {
            var data = categoryRepo.GetCategories().ToPagedList(i ?? 1, 2);
            return View(data);
        }

        public ActionResult Details(int id)
        {
            Category category = new Category();
            category.CId = id;
            var data = categoryRepo.GetCategorybyId(id);
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            var data = categoryRepo.InsertCategory(category);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var data = categoryRepo.GetCategorybyId(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(int id, Category category)
        {
            var data = categoryRepo.UpdateCategory(category);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Product p = new Product();
            p.ProductId = id;
            var data = categoryRepo.GetCategorybyId(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(int id, Category category)
        {
            var data = categoryRepo.DeleteCategory(id);
            return RedirectToAction("Index");
        }

    }
}