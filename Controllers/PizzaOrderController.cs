using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pizzaorder.Models;
using Microsoft.EntityFrameworkCore;

namespace Pizzaorder.Controllers
{
    public class PizzaOrderController : Controller
    {
        private readonly PizzaIdentityDBContext _context;
        public PizzaOrderController(PizzaIdentityDBContext context)
        {
            _context = context;
        }
        // GET: LaptopController
        public async Task<ActionResult> Index()
        {
            return View(await _context.Pizza.ToListAsync());
        }

        // GET: LaptopController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pizza = await _context.Pizza.FirstOrDefaultAsync(x => x.SNo == id);
            if (pizza == null)
            {
                return NotFound();
            }
            return View(pizza);
        }
    }
}
