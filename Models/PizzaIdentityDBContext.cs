using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pizzaorder.Models
{
    public class PizzaIdentityDBContext : IdentityDbContext
    {
        public PizzaIdentityDBContext(DbContextOptions<PizzaIdentityDBContext> options)
            :base(options)
        {

        }
        public DbSet<PizzaModel> Pizza { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PizzaModel>().HasData(
                new PizzaModel {SNo= 1,ImagePath ="/Margherita.jpg",PizzaName="Double Cheese Margherita",Category ="Veg",Size="Medium",Price=350 },
                new PizzaModel { SNo = 2, ImagePath = "/MexicanGreenWave.jpg", PizzaName = "Mexican Green Wave", Category = "Veg", Size = "Large", Price = 550 },
                new PizzaModel { SNo = 3, ImagePath = "/ChesseNCorn.jpg", PizzaName = "Cheese N Corn", Category = "Veg", Size = "Large", Price = 450 },
                new PizzaModel { SNo = 4, ImagePath = "/ChickenFiesta.jpg", PizzaName = "Chicken Fiesta", Category = "Non Veg", Size = "Medium", Price = 450 },
                new PizzaModel { SNo = 5, ImagePath = "/ChickenPepperoni.jpg", PizzaName = "Chicken Pepperoni", Category = "Non Veg", Size = "Large", Price = 600 },
                new PizzaModel { SNo = 6, ImagePath = "/ChickenSausage.jpg", PizzaName = "Chicken Sausage", Category = "Non Veg", Size = "Medium", Price = 480 }
                );
        }
    }
}
