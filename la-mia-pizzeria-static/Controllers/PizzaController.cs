using Microsoft.AspNetCore.Mvc;
//L’elenco delle pizze ora va passato come model dal controller, e la view deve utilizzarlo per mostrare l’html corretto.
//Gestiamo anche la possibilità che non ci siano pizze nell’elenco: in quel caso dobbiamo mostrare un messaggio che indichi all’utente che non ci sono pizze presenti nella nostra applicazione.

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            return View(Pizza.pizzas);
        }


        //Read
        [HttpGet] //se non inserisco [Http...] ci sarà di deafault [HttpGet]
        public IActionResult Details(int id)
        {
            var pizza = Pizza.pizzas.FirstOrDefault(p => p.Id == id);
            
            return View(pizza);
        }


        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza data)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", data);
            }

            Pizza pizzaCreate = new Pizza();
            pizzaCreate.Name = data.Name;
            pizzaCreate.Description = data.Description;
            pizzaCreate.Image = data.Image;
            pizzaCreate.Price = data.Price;
            pizzaCreate.Category = data.Category;

            Pizza.pizzas.Add(data);

            //context.Pizzas.SaveChanges();
            //context.SaveChanges();

            return RedirectToAction("Index");
        }






        ////Update
        //[HttpGet]
        //public IActionResult Edit()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View("Create", data);
        //    }

        //    Pizza pizzaCreate = new Pizza();
        //    pizzaCreate.Name = data.Name;
        //    pizzaCreate.Description = data.Description;
        //    pizzaCreate.Image = data.Image;
        //    pizzaCreate.Price = data.Price;
        //    pizzaCreate.Category = data.Category;

        //    Pizza.pizzas.Add(pizzaCreate);

        //    //context.Pizzas.SaveChanges();
        //    //context.SaveChanges();

        //    return RedirectToAction("Index");
        //}
    }
}
