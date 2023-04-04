using Microsoft.AspNetCore.Mvc;
using NimapInfotechMVC.Models;
using NimapInfotechMVC.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace NimapInfotechMVC.Controllers
{
    public class ProductController : Controller
    {
        ProductRepo productRepo = new ProductRepo();
        public ActionResult Index(string Search,int? i)
        {
            var data = productRepo.GetProducts().ToPagedList(i??1,3);
            return View(data);
        }
        
        public ActionResult Details(int id)
        {
            Product p = new Product();
            p.ProductId = id;
            var data = productRepo.GetProductbyId(id);
            return View(data);
        }

        public ActionResult Create()
        {
            CategoryRepo categoryRepo = new CategoryRepo();

            ViewBag.Categories = new SelectList(categoryRepo.GetCategories(), "CId", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    productRepo.InsertProduct(product);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

            //var data = productRepo.InsertProduct(product);
            //return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            CategoryRepo categoryRepo = new CategoryRepo();

            ViewBag.Categories = new SelectList(categoryRepo.GetCategories(), "CId", "CategoryName");
            var data = productRepo.GetProductbyId(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    productRepo.UpdateProduct(product);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Product p = new Product();
            p.ProductId = id;
            var data = productRepo.GetProductbyId(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            var data = productRepo.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}