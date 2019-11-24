using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeForPets.Models;
using HomeForPets.Infrastructure;
using System.IO;

namespace HomeForPets.Controllers
{
    public class FormController : Controller
    {
        PetsDbContext db = new PetsDbContext();

        [HttpGet]
        public ActionResult Create()
        {
            SelectList categories = new SelectList(db.Categories, "CategoryID", "CategoryName");
            SelectList species = new SelectList(db.Species, "SpecieID", "SpecieName");
            ViewBag.Categories = categories;
            ViewBag.Species = species;

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Form form, HttpPostedFileBase[] files)
        {
            List<Image> images = new List<Image>();
            
            if(ModelState.IsValid)
            {
                form.CreateDate = DateTime.Now;
                //Временная заглушка
                form.ProfileID = 1;
                
                foreach (var file in files)
                {
                    if(file != null)
                    {
                        if (file.ContentLength > 0 && IsImage(file))
                        {
                            var imageName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/App_Data/Images"), imageName);
                            file.SaveAs(path);

                            Image savedImage = db.Images.Add(new Image { Path = path });
                            images.Add(savedImage);
                        }
                    }
                }

                foreach (var img in images)
                {
                    form.Images.Add(img);
                }

                db.Forms.Add(form);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return Create();
        }

        private bool IsImage(HttpPostedFileBase img)
        {
            switch(img.ContentType)
            {
                case "image/jpeg":
                    {
                        return true;
                    }
                case "image/png":
                    {
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }
    }
}