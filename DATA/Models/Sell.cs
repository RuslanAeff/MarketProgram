using MarektDemo.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarektDemo.Models
{
    public class Sale : BaseEntity
    {
        private static int counter = 0;
        public decimal Amount;
        public DateTime Time;
        public List<SaleItem> SaleItems = new List<SaleItem>();

        public Sale(int amount,DateTime time)
        {
            Amount = amount;
            Time = time;
            Id = counter;
            counter++;
        }
        public void AddSaleItem(SaleItem saleItem)
        {
            SaleItems.Add(saleItem);
        }
    }
}
