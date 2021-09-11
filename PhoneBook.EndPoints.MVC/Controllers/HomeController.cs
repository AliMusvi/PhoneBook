using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult index()
        {
            return View();
        }
    }
}
