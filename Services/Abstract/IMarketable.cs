using MarektDemo.DATA.Enum;
using MarektDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarektDemo.Services.Abstract
{
    public interface IMarketable
    {
        List<Product> GetProducts();
        List<Sale> GetSale();
        List<SaleItem> GetSaleItems();
        int AddProduct(string name, int price, Category catagory, int number);
        void AddSale(int id, int quantity, DateTime time);
    }
}
