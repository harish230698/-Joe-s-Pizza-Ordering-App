using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaorder.Controllers
{
    public class AddressController : Controller
    {
        public IActionResult Address()
        {
            return View();
        }
        public IActionResult OrderPlaced()
        {
            ViewBag.msg = "Your order has been placed and will be delivered shortly!";
            return View();
        }
    }
}
