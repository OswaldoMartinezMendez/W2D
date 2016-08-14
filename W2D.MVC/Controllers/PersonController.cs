using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using W2D.Domain.Entities;
using W2D.MVC.Models;
using W2D.Service.Contracts;

namespace W2D.MVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }

        //
        // GET: /Person/

        public ActionResult Index()
        {
            var list = _service.GetAll();
            var newlist = Mapper.Map<IEnumerable<Person>, IEnumerable<PersonModel>>(list);
            return View(newlist);
        }

        //
        // GET: /Person/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Person/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Person/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var person = new Person()
                {
                    DocumentNumber = collection["DocumentNumber"],
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    Phone = collection["Phone"],
                };
                _service.Add(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Person/Edit/5

        public ActionResult Edit(int id)
        {
            var person = _service.GetById(id);
            var personModel = Mapper.Map<Person, PersonModel>(person);
            return View(personModel);
        }

        //
        // POST: /Person/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var updatePerson = new Person()
                {
                    Id = id,
                    DocumentNumber = collection["DocumentNumber"],
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    Phone = collection["Phone"]
                };

                _service.Update(updatePerson);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Person/Delete/5

        public ActionResult Delete(int id)
        {
            var person = _service.GetById(id);
            var personModel = Mapper.Map<Person, PersonModel>(person);
            return View(personModel);
        }

        //
        // POST: /Person/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var deletePerson = new Person()
                {
                    Id = id,
                    DocumentNumber = collection["DocumentNumber"],
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    Phone = collection["Phone"]
                };

                _service.Delete(deletePerson);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
