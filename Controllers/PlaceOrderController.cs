using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pizzaorder.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Pizzaorder.Controllers
{
    public class PlaceOrderController : Controller
    {
        private readonly PizzaIdentityDBContext _context;
        public PlaceOrderController(PizzaIdentityDBContext context)
        {
            _context = context;
        }
        public ActionResult PlaceOrder(int id, string val)
        {
            List<PizzaModel> lstOlddata = null;
            if (val == "Add")
            {
                PizzaModel model = new PizzaModel();

                var pizza = _context.Pizza.Where(s => s.SNo == id).ToList();
                if (pizza.Count > 0)
                    model = pizza[0];

                lstOlddata = SessionHelper.GetObjectFromJson<List<PizzaModel>>(HttpContext.Session, "Placeorder");

                if (lstOlddata == null)
                    lstOlddata = new List<PizzaModel>();

                if (pizza.Count > 0)
                    lstOlddata.Add(model);

                SessionHelper.SetObjectAsJson(HttpContext.Session, "Placeorder", lstOlddata);
                // return View(lstOlddata);
            }
            else if (val == "Remove")
            {
                PizzaModel model = new PizzaModel();
                lstOlddata = SessionHelper.GetObjectFromJson<List<PizzaModel>>(HttpContext.Session, "Placeorder");

                if (lstOlddata.Count > 0)
                {
                    var lapmodellst = lstOlddata.Where(item => item.SNo == id).ToList();
                    if (lapmodellst.Count > 0)
                    {
                        PizzaModel lapmodel = lapmodellst[0];
                        lstOlddata.Remove(lapmodel);
                    }
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "Placeorder", lstOlddata);


            }
            else
            {
                lstOlddata = SessionHelper.GetObjectFromJson<List<PizzaModel>>(HttpContext.Session, "Placeorder");

                if (lstOlddata == null)
                {
                    lstOlddata = new List<PizzaModel>();
                }

            }
            return View(lstOlddata);
        }

        public ActionResult ProceedToBuy(int id)
        {
          
                PizzaModel model = new PizzaModel();

                var pizza = _context.Pizza.Where(s => s.SNo == id).ToList();
                if (pizza.Count > 0)
                    model = pizza[0];

                List<PizzaModel> lstOlddata = SessionHelper.GetObjectFromJson<List<PizzaModel>>(HttpContext.Session, "Placeorder");

                if (lstOlddata == null)
                    lstOlddata = new List<PizzaModel>();

                if (pizza.Count > 0)
                    lstOlddata.Add(model);

                SessionHelper.SetObjectAsJson(HttpContext.Session, "Placeorder", lstOlddata);


                return RedirectToAction("Address", "Address");
            
        }

    }


    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
