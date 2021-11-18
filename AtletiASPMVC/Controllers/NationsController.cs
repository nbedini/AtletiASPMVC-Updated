using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AtletiASPMVC.Models;
using AtletiASPMVC.ViewModels;

namespace AtletiASPMVC.Controllers
{
    public class NationsController : Controller
    {
        // GET: Nations
        public ActionResult Random()
        {
            //Interrogazione del model
            using (OlympicsEntities model = new OlympicsEntities())
            {
                System.Random randomGenerator = new Random();
                int randomValue = randomGenerator.Next(model.Nationalities.Count() - 1);

                Nationality nation = model.Nationalities.OrderBy(o => o.Id).Skip(randomValue).FirstOrDefault();
                if( nation==null ) return HttpNotFound();


                //ViewResult
                //return View("Details",nation);
                return View("Details", new NationsDetailViewModel
                {
                    Title="Random",
                    Nation = nation
                });

                //ContentResult
                //return Content(nation.Code);

                //return RedirectToAction()
                //return File()

                //return new EmptyResult();
            }
        }

        public ActionResult Details(int id)
        {
            using (OlympicsEntities model = new OlympicsEntities())
            {
                Nationality nation = model.Nationalities.FirstOrDefault(q=>q.Id == id);
                if (nation == null) return HttpNotFound();

                return View(new NationsDetailViewModel
                {
                    Title = "Details",
                    Nation = nation
                });
            }
        }

        [Route("Nations/ByCode/{code}")]
        public ActionResult GetByCode(string code)
        {
            using (OlympicsEntities model = new OlympicsEntities())
            {
                Nationality nation = model.Nationalities.FirstOrDefault(q => q.Code == code);
                if (nation == null) return HttpNotFound();

                return View("Details", new NationsDetailViewModel
                {
                    Title = "GetByCode",
                    Nation = nation
                });
            }
        }

        public ActionResult Index(int id = 1)
        {
            const int pageSize = 10;

            using (OlympicsEntities model = new OlympicsEntities())
            {
                List<Nationality> nations = model.Nationalities.OrderBy(ob => ob.Code)
                    .Skip( (id-1)*pageSize )
                    .Take(pageSize).ToList();
                if (nations.Count() == 0) return HttpNotFound();

                int pages = model.Nationalities.Count() / pageSize;
                if (model.Nationalities.Count() % pageSize != 0) pages++;

                return View(new NationsListViewModel
                {
                    page = id,
                    pages = pages,
                    nations = nations
                });
            }
        }

        public ActionResult Edit(int id)
        {
            using (OlympicsEntities model = new OlympicsEntities())
            {
                Nationality nation = model.Nationalities.FirstOrDefault(q => q.Id == id);
                if (nation == null) return HttpNotFound();

                return View(nation);
            }
        }

        [HttpPost]
        public ActionResult Edit(Nationality n)
        {
            if (n == null) return HttpNotFound();

            using(OlympicsEntities model = new OlympicsEntities())
            {
                Nationality candidate = model.Nationalities.FirstOrDefault(q => q.Id == n.Id);
                if (candidate == null) return HttpNotFound();

                candidate.Code = n.Code;
                candidate.Name = n.Name;
                model.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Nationality n)
        {
            if (n == null) return HttpNotFound();

            using(OlympicsEntities model = new OlympicsEntities())
            {
                model.Nationalities.Add(n);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}