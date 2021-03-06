﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SUD.Models;
using SUD.ViewModels;

namespace SUD.Controllers
{
    [Authorize(Roles = "Jefe de bodega, Administrador")]

    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Measure);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.Products.Find(id);
            var Barra = new BarCode
            {
                ProductId = product.ProductId
            };

            NewProductView np = new NewProductView();
            np.Product = product;
            np.BarCode = Barra;

            
            if (np == null)
            {
                return HttpNotFound();
            }

            return View(np);
        }

        // GET: Products/BarCodes
        public ActionResult BarCodeDetails(int? id)
        {
            var view = new NewProductView
            {
                BarCodes = db.BarCodes.Where(bc => bc.ProductId == id).ToList()
            };

            return PartialView("BarCodeDetails", view);
        }

        [HttpPost]
        public JsonResult AddBarCodes(NewProductView view)
        {

            if (ModelState.IsValid)
            {
                var barCode = new BarCode
                {
                    ProductId = view.BarCode.ProductId,
                    Bar = view.BarCode.Bar
                };

                db.BarCodes.Add(barCode);
                db.SaveChanges();
           
            }

            
            return Json(view, JsonRequestBehavior.AllowGet);
        }

        // Metodo para Elminar Codigos de Barras a los productos
        public ActionResult DeleteBarCode(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var barCode = db.BarCodes.Where(bc => bc.BarCodeId == id).FirstOrDefault();
            if (barCode == null)
            {
                return HttpNotFound();
            }

            db.BarCodes.Remove(barCode);
            db.SaveChanges();

            return RedirectToAction("Details", new { id = barCode.ProductId });
        }


        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(p => p.Description), "CategoryId", "Description");
            ViewBag.MeasureId = new SelectList(db.Measures.OrderBy(m => m.Description), "MeasureId", "Description");
            return View();
        }

        // POST: Products/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,CategoryId,MeasureId,Description,Price,Note,Image,Medida,FotografiaFile")] Product product)
        {


            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();

                if (product.FotografiaFile != null)
                {
                    var folder = "~/Uploads/Products";
                    var response = FilesHelper.UploadPhoto(product.FotografiaFile, folder, string.Format("{0}.jpg", product.ProductId));
                    if (response)
                    {
                        var pic = string.Format("{0}/{1}.jpg", folder, product.ProductId);
                        product.Image = pic;

                        db.Entry(product).State = EntityState.Modified;
                        db.SaveChanges();


                    }
                }
                return RedirectToAction("Index");



            }

            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(p => p.Description), "CategoryId", "Description");
            ViewBag.MeasureId = new SelectList(db.Measures.OrderBy(m => m.Description), "MeasureId", "Description");
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(p => p.Description), "CategoryId", "Description");
            ViewBag.MeasureId = new SelectList(db.Measures.OrderBy(m => m.Description), "MeasureId", "Description");
            return View(product);
        }

        // POST: Products/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,CategoryId,MeasureId,Description,Price,Note,Image,Medida,FotografiaFile")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();

                if (product.FotografiaFile != null)
                {
                    var folder = "~/Uploads/Products";
                    var response = FilesHelper.UploadPhoto(product.FotografiaFile, folder, string.Format("{0}.jpg", product.ProductId));
                    if (response)
                    {
                        var pic = string.Format("{0}/{1}.jpg", folder, product.ProductId);
                        product.Image = pic;

                        db.Entry(product).State = EntityState.Modified;
                        db.SaveChanges();


                    }
                }

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description", product.CategoryId);
            ViewBag.MeasureId = new SelectList(db.Measures, "MeasureId", "Description", product.MeasureId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
