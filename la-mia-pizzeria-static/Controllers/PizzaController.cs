using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.ConstrainedExecution;
//L’elenco delle pizze ora va passato come model dal controller, e la view deve utilizzarlo per mostrare l’html corretto.
//Gestiamo anche la possibilità che non ci siano pizze nell’elenco: in quel caso dobbiamo mostrare un messaggio che indichi all’utente che non ci sono pizze presenti nella nostra applicazione.

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzeriaContext context = new PizzeriaContext())
            {
                var pizzas = context.Pizzas.ToList();

                return View(pizzas);
            }
        }

        // CRUD

        //Create
        [HttpGet]
        public IActionResult Create()
        {
            using (PizzeriaContext context = new PizzeriaContext())
            {
                List<Category> categories = context.Categories.ToList();

                //creazione model da passare alla pagina get
                PizzaFormModel model = new PizzaFormModel();
                model.Pizza = new Pizza();
                model.Categories = categories;

                return View("Create", model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaFormModel data)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", data);
            }
            using (PizzeriaContext context = new PizzeriaContext())
            {
                Pizza pizzaCreate = new Pizza();
                pizzaCreate.Name = data.Pizza.Name;
                pizzaCreate.Description = data.Pizza.Description;
                pizzaCreate.Image = data.Pizza.Image;
                pizzaCreate.Price = data.Pizza.Price;
                pizzaCreate.CategoryId = data.Pizza.CategoryId;

                context.Pizzas.Add(pizzaCreate);

                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }


        //Read
        [HttpGet] //se non inserisco [Http...] ci sarà di deafault [HttpGet]
        public IActionResult View(int id)
        {
            using (PizzeriaContext context = new PizzeriaContext())
            {
                var pizza = context.Pizzas.Where(p => p.Id == id).Include(p => p.Category).FirstOrDefault(); //metodo Include() per recuperare Category assieme alla Pizza

                return View(pizza);
            }

        }


        //Update
        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (PizzeriaContext context = new PizzeriaContext())
            {
                //passo i dati per avere i valori degli attributi nella pagina Edit
                Pizza pizzaEdit = context.Pizzas.FirstOrDefault(p => p.Id == id);

                    List<Category> categories = context.Categories.ToList();

                    PizzaFormModel model = new PizzaFormModel();
                    model.Pizza = pizzaEdit;
                    model.Categories = categories;


                return View("Edit", model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PizzaFormModel data)
        {
            using (PizzeriaContext context = new PizzeriaContext())
            {
                var pizzaEdit = context.Pizzas.Where(p => p.Id == id).FirstOrDefault(); //FirstOrDefaut prendel'id corrispondente e se non lo trova darà null

                if (pizzaEdit != null)
                {
                    pizzaEdit.Name = data.Pizza.Name;
                    pizzaEdit.Description = data.Pizza.Description;
                    pizzaEdit.Image = data.Pizza.Image;
                    pizzaEdit.Price = data.Pizza.Price;
                    pizzaEdit.CategoryId = data.Pizza.CategoryId;
                    
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound(); //restituisce errore 404
                }
            }
        }


        //Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using (PizzeriaContext context = new PizzeriaContext())
            {
                var pizzaDelete = context.Pizzas.Where(p => p.Id == id).FirstOrDefault();

                if (pizzaDelete != null)
                {
                    context.Pizzas.Remove(pizzaDelete);
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }








        //public class PizzaController : Controller
        //{
        //    public IActionResult Index()
        //    {
        //        return View(Pizza.pizzas);
        //    }

        //    // CRUD

        //    //Create
        //    [HttpGet]
        //    public IActionResult Create()
        //    {
        //        return View();
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public IActionResult Create(Pizza data)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return View("Create", data);
        //        }

        //        Pizza pizzaCreate = new Pizza();
        //        pizzaCreate.Name = data.Name;
        //        pizzaCreate.Description = data.Description;
        //        pizzaCreate.Image = data.Image;
        //        pizzaCreate.Price = data.Price;
        //        pizzaCreate.Category = data.Category;

        //        Pizza.pizzas.Add(data);

        //        return RedirectToAction("Index");
        //    }


        //    //Read
        //    [HttpGet] //se non inserisco [Http...] ci sarà di deafault [HttpGet]
        //    public IActionResult View(int id)
        //    {
        //        var pizza = Pizza.pizzas.FirstOrDefault(p => p.Id == id);

        //        return View(pizza);
        //    }


        //    //Update
        //    [HttpGet]
        //    public IActionResult Edit(int id)
        //    {
        //        //passo i dati per avere i valori degli attributi nella pagina Edit
        //        var pizza = Pizza.pizzas.FirstOrDefault(p => p.Id == id);

        //        return View(pizza);
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public IActionResult Edit(int id, Pizza data)
        //    {
        //        var pizzaEdit = Pizza.pizzas.Where(p => p.Id == id).FirstOrDefault(); //FirstOrDefaut prendel'id corrispondente e se non lo trova darà null

        //        if (pizzaEdit != null)
        //        {
        //            pizzaEdit.Name = data.Name;
        //            pizzaEdit.Description = data.Description;
        //            pizzaEdit.Image = data.Image;
        //            pizzaEdit.Price = data.Price;
        //            pizzaEdit.Category = data.Category;

        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            return NotFound(); //restituisce errore 404
        //        }
        //    }


        //    //Delete
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public IActionResult Delete(int id)
        //    {
        //        var pizzaDelete = Pizza.pizzas.Where(p => p.Id == id).FirstOrDefault();

        //        if (pizzaDelete != null)
        //        {
        //            Pizza.pizzas.Remove(pizzaDelete);

        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
    }
}
