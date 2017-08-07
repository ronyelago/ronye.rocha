﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControleEstoque.Web.Models;

namespace ControleEstoque.Web.Controllers
{
    public class CategoriaProdutoesController : Controller
    {
        private StockEntities db = new StockEntities();

        // GET: CategoriaProdutoes
        public ActionResult Index()
        {
            return View(db.CategoriaProduto.ToList());
        }

        // GET: CategoriaProdutoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProduto categoriaProduto = db.CategoriaProduto.Find(id);
            if (categoriaProduto == null)
            {
                return HttpNotFound();
            }
            return View(categoriaProduto);
        }

        // GET: CategoriaProdutoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProdutoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Estado")] CategoriaProduto categoriaProduto)
        {
            if (ModelState.IsValid)
            {
                db.CategoriaProduto.Add(categoriaProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaProduto);
        }

        // GET: CategoriaProdutoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProduto categoriaProduto = db.CategoriaProduto.Find(id);
            if (categoriaProduto == null)
            {
                return HttpNotFound();
            }
            return View(categoriaProduto);
        }

        // POST: CategoriaProdutoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Estado")] CategoriaProduto categoriaProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriaProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaProduto);
        }

        // GET: CategoriaProdutoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaProduto categoriaProduto = db.CategoriaProduto.Find(id);
            if (categoriaProduto == null)
            {
                return HttpNotFound();
            }
            return View(categoriaProduto);
        }

        // POST: CategoriaProdutoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaProduto categoriaProduto = db.CategoriaProduto.Find(id);
            db.CategoriaProduto.Remove(categoriaProduto);
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
