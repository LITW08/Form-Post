using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class PeopleController : Controller
    {
        private string _connectionString =
            @"Data Source=.\sqlexpress;Initial Catalog=OneToManyDemo;Integrated Security=true;";
        
        public ActionResult Index()
        {
            PeopleDb db = new PeopleDb(_connectionString);
            PeopleViewModel vm = new PeopleViewModel
            {
                People = db.GetAll()
            };
            return View(vm);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Person person)
        {
            PeopleDb db = new PeopleDb(_connectionString);
            db.Add(person);
            return Redirect("/people/index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            PeopleDb db = new PeopleDb(_connectionString);
            db.Delete(id);
            return Redirect("/people/index");
        }
    }
}