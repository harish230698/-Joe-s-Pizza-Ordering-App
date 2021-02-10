using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaorder.Models
{
    [Table("tblPizza")]
    public class PizzaModel
    {
        [Key]
        public int SNo { get; set; }

        public string ImagePath { get; set; }
        public string PizzaName { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }

        public double Price { get; set; }
    }
}
