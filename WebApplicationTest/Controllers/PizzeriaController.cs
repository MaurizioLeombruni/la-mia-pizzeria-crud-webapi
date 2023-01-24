using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApplicationTest.Areas.Identity.Data;
using WebApplicationTest.Database;
using WebApplicationTest.Models;

namespace WebApplicationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzeriaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? search)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Pizza> pizzas = new List<Pizza>();


                if (search is null || search == "")
                {
                    pizzas = db.Pizzas.ToList<Pizza>();
                }
                else
                {
                    search = search.ToLower();

                    pizzas = db.Pizzas.Where(pizza => pizza.Name.ToLower().Contains(search)).ToList<Pizza>();
                }

                return Ok(pizzas);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizza = db.Pizzas.Where(articolo => articolo.Id == id).FirstOrDefault();

                if (pizza is null)
                {
                    return NotFound("L'articolo con questo id non è stato trovato!");
                }

                return Ok(pizza);
            }
        }
    }
}
