using M2_NETCoreMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace M2_NETCoreMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //forma dinamica de enviar datos del action a la vista
            ViewBag.FullName = "Julio";
            //la ruta es HomeContralor/Action
            //el action me va devolver una Vista si no hay nada me devolvera con el nombre del action que seria Privacy
            return View();
        }

        //las peticiones por Get es cuando alguien escribe algo y te devuelve los recursos
        //mayormente estas peticiones son por Get
        
        //creando un action Products
        //recordar llega a la vista pasa por el controlador
        public IActionResult Products()
        {
            return View("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
