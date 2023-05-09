//using Microsoft.AspNetCore.Mvc;
////L’elenco delle pizze ora va passato come model dal controller, e la view deve utilizzarlo per mostrare l’html corretto.
////Gestiamo anche la possibilità che non ci siano pizze nell’elenco: in quel caso dobbiamo mostrare un messaggio che indichi all’utente che non ci sono pizze presenti nella nostra applicazione.

//namespace la_mia_pizzeria_static.Controllers
//{
//    public class PizzaController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View(Pizza.pizzas);
//        }

//        // CRUD

//        //Create
//        [HttpGet]
//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create(Pizza data)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View("Create", data);
//            }

//            Pizza pizzaCreate = new Pizza();
//            pizzaCreate.Name = data.Name;
//            pizzaCreate.Description = data.Description;
//            pizzaCreate.Image = data.Image;
//            pizzaCreate.Price = data.Price;
//            pizzaCreate.Category = data.Category;

//            Pizza.pizzas.Add(data);

//            //context.Pizzas.SaveChanges();
//            //context.SaveChanges();

//            return RedirectToAction("Index");
//        }


//        //Read
//        [HttpGet] //se non inserisco [Http...] ci sarà di deafault [HttpGet]
//        public IActionResult View(int id)
//        {
//            var pizza = Pizza.pizzas.FirstOrDefault(p => p.Id == id);

//            return View(pizza);
//        }


//        //Update
//        [HttpGet]
//        public IActionResult Edit(int id)
//        {
//            //passo i dati per avere i valori degli attributi nella pagina Edit
//            var pizza = Pizza.pizzas.FirstOrDefault(p => p.Id == id);

//            return View(pizza);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(int id, Pizza data)
//        {
//            var pizzaEdit = Pizza.pizzas.Where(p => p.Id == id).FirstOrDefault(); //FirstOrDefaut prendel'id corrispondente e se non lo trova darà null

//            if (pizzaEdit != null)
//            {
//                pizzaEdit.Name = data.Name;
//                pizzaEdit.Description = data.Description;
//                pizzaEdit.Image = data.Image;
//                pizzaEdit.Price = data.Price;
//                pizzaEdit.Category = data.Category;

//                //context.SaveChanges();  per db

//                return RedirectToAction("Index");
//            }
//            else
//            {
//                return NotFound(); //restituisce errore 404
//            }
//        }


//        //Delete
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Delete(int id)
//        {
//            var pizzaDelete = Pizza.pizzas.Where(p => p.Id == id).FirstOrDefault();

//            if (pizzaDelete != null)
//            {
//                Pizza.pizzas.Remove(pizzaDelete);
//                //context.SaveChanges();  per db

//                return RedirectToAction("Index");
//            }
//            else
//            {
//                return NotFound();
//            }
//        }
//    }
//}
