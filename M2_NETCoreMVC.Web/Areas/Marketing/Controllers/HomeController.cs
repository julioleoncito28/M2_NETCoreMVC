using M2_NETCoreMVC.Web.Areas.Marketing.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace M2_NETCoreMVC.Web.Areas.Marketing.Controllers
{
    //especificando que es HomeController pertenercera a Marketing
    [Area("Marketing")]
    public class HomeController : Controller
    {
        //Metodo de envio desde la vista hacia el controlador
        public IActionResult Index()
        {
            //aca esta viajando a la vista Index de la raiz de Controllers,y eso no queremos
            //queremos que tenga su propia vista el area de Marketing
            return View();
        }

        //Diferencia de envio #1
        //envio mediante el ViewModel desde el contralador hacia la vista(hemos creado la vista ProductsWithViewModel)
        public IActionResult ProductsWithViewModel()
        {
            //quiero enviarle el listado de Products(json)
            var products = GetProductsJsonLocal();
            return View(products);
        }

        //Diferencia de envio #2(consumo mayor,no esta fuertemente tipeado)
        public IActionResult ProductsWithViewBag()
        {
            //quiero enviarle el listado de Products(json)
            var products = GetProductsJsonLocal();
            //creamos la vista ProductsWithViewBag
            ViewBag.ProductList = products;
            return View();
        }

        //Diferencia de envio #3(consumo mayor,no esta fuertemente tipeado)
        public IActionResult ProductsWithViewData()
        {
            //quiero enviarle el listado de Products(json)
            var products = GetProductsJsonLocal();
            //creamos la vista ProductsWithViewData
            ViewData["ProductList"] = products;
            return View();
        }

        //quiero devolver un enumarado o listado de Product(la clase de Product) con el nombre GetProductsJsonLocal
        //esto va ser como nuestra base de datos y lo enviaremos a la vista
        public List<Product> GetProductsJsonLocal()
        {
            //mapeando nuestro metodo
            //codigo que lee un archivo json
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"Areas\\Marketing\\Data\\Products.json");
            var json = System.IO.File.ReadAllText(folderDetails);
            //este json lo voy a deserializar(DeserializeObject) y lo convertirmos en un IEnumerable Producto y lo enviamos al json
            var products = JsonConvert.DeserializeObject<List<Product>>(json);

            return products;

        }

        //private int IEnumerable<T>(string json)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
