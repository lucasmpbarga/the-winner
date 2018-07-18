using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationTheWinner.Models;

namespace WebApplication1.Controllers
{
    public class QuadroController : Controller
    {

        private Context  db = new Context();

        // GET: quadro
        public ActionResult Index()
        {
            return View(db.Times.ToList());
        }

        public ActionResult FaseTwo(int? id)
        {
            var faseTwo = db.Times.ToList().FindAll(f => f.Fase == 2);

            if (faseTwo.Count < 2)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Time time = db.Times.Find(id);
                if (time == null)
                {
                    return HttpNotFound();
                }

                time.Fase = 2;

                if (ModelState.IsValid)
                {
                    db.Entry(time).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            
            Response.Write("<script> alert('Apenas 2 times na final!'); </script>");
            return View("Index", db.Times);
        }

        public ActionResult Winner(int? id)
        {
            var faseOne = db.Times.ToList().FindAll(f => f.Fase == 1);

            if (faseOne.Count < 1)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Time time = db.Times.Find(id);
                if (time == null)
                {
                    return HttpNotFound();
                }

                time.Fase = 1;

                if (ModelState.IsValid)
                {
                    db.Entry(time).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            Response.Write("<script> alert('Apenas 1 time Campeão!'); </script>");
            return View("Index", db.Times);
        }

        public ActionResult Reset()
        {
            var todos = db.Times.ToList();

            foreach( var time in todos)
            {
                time.Fase = 3;

                if (ModelState.IsValid)
                {
                    db.Entry(time).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    
    }
}