using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dependences.Models;
using Ninject;

namespace dependences.Controllers
{
    public class HomeController : Controller
    {
        Book[] books =
        {
            new Book{Autor="Shakespiere",Title="Hamlet",Category=BookCategory.Gexarvestakan,Price=1000 },
            new Book{Autor="Troelsen",Title="C#7",Category=BookCategory.Programming,Price=20 },
            new Book{Autor="Sevak",Title="Anlreli zangakatun",Category=BookCategory.Gexarvestakan,Price=1 },
            new Book{Autor="Steven Hawking",Title="Black Holes",Category=BookCategory.Gitakan,Price=30 }
        };
        ITotalValueCalculator calc;
        public HomeController(ITotalValueCalculator clc)
        {
            calc = clc;
        }
        // GET: Home
        public ActionResult Index()
        {
            //IKernel kernel = new StandardKernel();
            //kernel.Bind<ITotalValueCalculator>().To<TotalValueCalculator>();
            //ITotalValueCalculator iCalc = kernel.Get<ITotalValueCalculator>();

            //ITotalValueCalculator calc = new TotalValueCalculator();
                
            Library lib = new Library(calc) { Books = books };
            decimal totalPrice = lib.TotalPrice();

            return View(totalPrice);
        }
        public ViewResult lesson2()
        {
            return View("Index");
        }
    }
}