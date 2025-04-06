using Microsoft.AspNetCore.Mvc;

namespace MVCPeliculas.Controllers
{
    public class HolaMundoController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Titulo"] = "Este es mi Titulo desde mi controlador";
            return View();
        }


        public IActionResult Welcome(string name, int Count = 1)
        {
            ViewData["Message"] = "bienvenido a mi controlador" +name;
            ViewData["Count"] = Count;


            return View();
        }


    }
}
