using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;
using WebApplicationTest.Database;
using WebApplicationTest.Models;
using WebApplicationTest.Utilities;

namespace WebApplicationTest.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Pizza> listaPizze = db.Pizzas.ToList();
                return View("Index", listaPizze);
            }
        }

        public IActionResult Details(int id)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizzaDaCercare = db.Pizzas
                    .Where(pizza => pizza.Id == id)
                    .Include(pizza => pizza.Category)
                    .FirstOrDefault();

                if (pizzaDaCercare != null)
                {
                    return View(pizzaDaCercare);
                }

                return NotFound("Something went wrong tralalala");
            }

        }

        [HttpGet]
        public IActionResult GenerateForm()
        {    
            using(PizzeriaContext db = new PizzeriaContext())
            {
                List<Category> categories = db.Categories.ToList();

                PizzaCategoryView modelView = new PizzaCategoryView();
                modelView.Pizza = new();

                modelView.Categories = categories;

                return View("GenerateForm", modelView);
            }

            //return View("GenerateForm"); OLD
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GenerateForm(PizzaCategoryView formData)
        {
            if(!ModelState.IsValid)
            {
                using(PizzeriaContext db = new PizzeriaContext())
                {
                    List<Category> categories = db.Categories.ToList();

                    formData.Categories = categories;
                }

                return View("GenerateForm", formData);
            }

            using(PizzeriaContext db = new PizzeriaContext())
            {
                db.Pizzas.Add(formData.Pizza);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using(PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizzaToUpdate = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaToUpdate != null)
                {
                    List<Category> categories = db.Categories.ToList();
                    PizzaCategoryView modelView = new();
                    modelView.Pizza = pizzaToUpdate;
                    modelView.Categories = categories;

                    return View("Update", modelView);
                }

                return NotFound("Something went wrong when trying to update this pizza");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaCategoryView formData)
        {
            if (!ModelState.IsValid)
            {
                using(PizzeriaContext db = new PizzeriaContext())
                {
                    List<Category> categories = db.Categories.ToList();

                    formData.Categories = categories;
                }

                return View("Update", formData);
            }

            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizzaToUpdate = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaToUpdate != null)
                {
                    pizzaToUpdate.Name = formData.Pizza.Name;
                    pizzaToUpdate.Description = formData.Pizza.Description;
                    pizzaToUpdate.Image = formData.Pizza.Image;
                    pizzaToUpdate.Price = formData.Pizza.Price;
                    pizzaToUpdate.CategoryId = formData.Pizza.CategoryId;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("haha pizza goes brrr");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using(PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizzaToDelete = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaToDelete != null)
                {
                    db.Pizzas.Remove(pizzaToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("why are we here, just to suffer");
                }
            }
        }
    }
}
