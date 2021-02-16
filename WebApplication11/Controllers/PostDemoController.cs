using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class PostDemoController : Controller
    {
        private string _connectionString =
            @"Data Source=.\sqlexpress;Initial Catalog=FurnitureStore;Integrated Security=true;";

        public ActionResult AddFurniture()
        {
            FurnitureDb db = new FurnitureDb(_connectionString);
            AddFurnitureViewModel vm = new AddFurnitureViewModel
            {
                Count = db.GetTotalCount()
            };
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddFurniture(string name, string color, decimal price, int quantityInStock)
        {
            FurnitureDb db = new FurnitureDb(_connectionString);
            db.Add(new Furniture
            {
                Name = name,
                Color = color,
                Price = price,
                QuantityInStock = quantityInStock
            });

            return Redirect("/postdemo/AddFurniture");
        }

        public ActionResult SimpleForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HiddenTest(string foo)
        {
            PostHiddenViewModel vm = new PostHiddenViewModel
            {
                Foo = foo
            };
            return View(vm);
        }
    }
}

//Create a page that displays a list of People (or whatever interests you).
//On top of the page, have a link that says "Add Person". When this link
//is clicked, the user should be taken to a page that has a form that 
//has textboxes for firstname/lastname/age (or whatever thing you're doing).
//Beneath that, there should be a submit button. When the button is clicked,
//the person should get added to the database, and the user should be redirected
//back to the list of all the people.

//Second exercise:

//Add a column to your table called "Delete". In each row of the table, there
//should be a delete button, that when clicked, will delete that person from the
//database, and redirect the user back to the page that shows a list of all people.
//The way to achieve this is to embed each Delete button in a form that posts
//to an Action on your controller that will delete that person. Inside that form,
//also have a hidden input with the id of that person. Then, in your controller,
//take that id in as a parameter, delete that person, and then redirect back to
//the list page.

//<input type="hidden" name="id" value="some id" />