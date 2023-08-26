using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarektDemo.Models
{
    public class SaleItem 
    {
        private static int counter = 0;
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Number { get; set; }

        public SaleItem (Product product, int quantity)
        {
            Product = product;
            Number = quantity;
            counter++;
        }
    }
}
