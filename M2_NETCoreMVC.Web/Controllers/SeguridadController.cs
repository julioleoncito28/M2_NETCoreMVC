using M2_NETCoreMVC.Web.Views.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M2_NETCoreMVC.Web.Controllers
{
    public class SeguridadController : Controller
    {
        //por defecto crea un action Index
        public IActionResult Index()
        {
            //como averiguar si creo una vista es:"Click derecho"+"Ir a Vista"
            return View();
        }

        //Este es un actionResult Login por Get
        public IActionResult Login()
        {
            return View();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //[HttpPost]
        ////creando un IActionResult por POST
        ////metodo enviando parametros:
        //public IActionResult Login(string email,string password)
        //{
        //    //simulando que estamos preguntado a la base de datos
        //    if (email=="julio_3030@hotmail.com" && password=="123")
        //    {
        //        return RedirectToAction("UNA NUEVA ACTION");
        //    }


        //    return RedirectToAction("Login");
        //}
        ////////////////////////////////////////////////////////////////////////////////////////////
        ///
        //[HttpPost]
        ////creando un IActionResult por POST
        ////metodo creando una clase usuario:
        //public IActionResult Login(Usuario usuario)
        //{

        //    string email = usuario.email;
        //    string password = usuario.password;
        //    //simulando que estamos preguntado a la base de datos
        //    if (email == "julio_3030@hotmail.com" && password == "123")
        //    {
        //        return RedirectToAction("UNA NUEVA ACTION");
        //    }


        //    return RedirectToAction("Login");
        //}
        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        //otra forma usando las colecciones
        [HttpPost]
        //creando un IActionResult por POST        
        public IActionResult Login(IFormCollection form)
        {
            string email = form["email"];
            string password = form["password"];
            //simulando que estamos preguntado a la base de datos
            if (email == "julio_3030@hotmail.com" && password == "123")
            {
                //redireccionando al action:"Index" del controlador Home y del area de marketing
                return RedirectToAction("Index","Home",new { area = "Marketing" });
            }


            return RedirectToAction("Login");
        }
    }
}
