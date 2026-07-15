using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionProductos.Models;
using GestionProductos.DAL;

namespace GestionProductos.Controllers
{
    public class ProductoController : Controller
    {
        private GestorProducto db = new GestorProducto();
        // GET: Producto
        public ActionResult Index()
        {
            return View(db.Productos.ToList());
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Precio")] Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Productos.Add(producto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(producto);
            }
            catch
            {
                return View(producto);
            }
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Precio")] Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(producto).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(producto);
            }
            catch
            {
                return View(producto);
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Producto producto = db.Productos.Find(id);
                db.Productos.Remove(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
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