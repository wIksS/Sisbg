using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sisbg.Data;
using Sisbg.Models;
using System.IO;
namespace Sisbg.Controllers
{
    public class ProductsController : BaseController
    {
        public ProductsController(ISisbgData data)
            : base(data)
        {

        }
        // GET: Products
        public ActionResult Index()
        {
            return View(data.Products.All().ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = data.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,BriefDescription,Description,JobDescription")] Product product,
            [Bind(Include = "Code,Weight,Pallet,Length")] Length[] lengths,IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                data.Products.Add(product);
                data.Products.SaveChanges();

                for (int i = 0; i < lengths.Length; i++)
                {
                    lengths[i].Product = product;
                    product.Lengths.Add(lengths[i]);
                    data.Lengths.Add(lengths[i]);
                }

                if (Request.Files.Count > 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var file = Request.Files[i];

                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var virtualPath = "~/Images/" + product.Name;
                            var path = Path.Combine(Server.MapPath(virtualPath), fileName);
                            bool exists = System.IO.Directory.Exists(virtualPath);

                            if (!exists)
                            {
                                System.IO.Directory.CreateDirectory(Server.MapPath(virtualPath));
                            }

                            file.SaveAs(path);
                            Sisbg.Models.File newFile = new Sisbg.Models.File();
                            newFile.Path = path;
                            newFile.Product = product;
                            newFile.ProductId = product.Id;
                            data.Files.Add(newFile);

                            product.Images.Add(newFile);
                        }
                    }
                }

                data.Files.SaveChanges();
                data.Products.SaveChanges();
                data.Lengths.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = data.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,BriefDescription,Description,JobDescription")] Product product)
        {
            if (ModelState.IsValid)
            {
                data.Products.Update(product);
                data.Products.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = data.Products.Find(id);
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
            Product product = data.Products.Find(id);
            data.Products.Delete(product);
            data.Products.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
