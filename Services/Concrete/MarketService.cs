using MarektDemo.DATA.Enum;
using MarektDemo.Models;
using MarektDemo.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarektDemo.Services.Concrete
{
    public class MarketService : IMarketable
    {
        private List<Product> products;
        private List<Sale> sales;
        private List<SaleItem> sale_İtems;
        private List<Category> categories;

        public MarketService()
        {
            products = new List<Product>();
            sales = new List<Sale>();
            sale_İtems = new List<SaleItem>();
            categories = new List<Category>();
        }
        public int AddProduct(string name, int price, Category catagory, int number) 
        {        
            if (string.IsNullOrEmpty(name))   throw new ArgumentNullException("Name is null!"); 
            if (price <= 0)  throw new Exception("Price is negative"); 
            if (number < 0) { throw new Exception("Number is negative"); }
            if (catagory == null) throw new Exception("There is no Category!");
            var product = new Product (name, price, catagory, number);
                products.Add(product);
                return product.Id;
        } 
        public void EditProduct (int id,string name, int price, Category catagory, int number)
        {
            if (string.IsNullOrEmpty(name))  throw new Exception("Name is null!"); 
            if (price <= 0)  throw new Exception("Price is negative"); 
            if (number < 0)  throw new Exception("Number is negative"); 
            if (id < 0) throw new Exception("ID is negative!");
            var existing = products.FirstOrDefault(x => x.Id ==id);
            if (existing == null) throw new Exception("Product not found!");
            existing.Name = name;
            existing.Price = price;
            existing.Catagory = catagory;
            existing.Number = number;
        }
        public void DeleteProduct (int id)
        {
            if (id < 0) throw new Exception("ID cannot be negative!");
            int getproduct = products.FindIndex(x => x.Id == id);
            if (getproduct == -1) throw new Exception("Products not found!");
            products.RemoveAt(getproduct);
        }
        public List<Product> ShowProductsForPriceRange(int minamount, int maxamount) 
        {
            if (minamount <= 0) throw new Exception("minamount cannot be less than 0 or equals 0");
            if (maxamount <= 0) throw new Exception("minamount cannot be less than 0 or equals 0");
            if (minamount > maxamount) throw new Exception("minamount cannot be greater than maxamount!");
            return products.Where(x => x.Price >=minamount && x.Price <=maxamount).ToList();
        }
        public void AddSale(int id ,int quantity,DateTime time)
        {
            List<SaleItem> tempSale = new List<SaleItem>();

            var product = products.FirstOrDefault(x => x.Id == id);
            if (quantity < 0) throw new Exception("Quantity must be grater than 0!");
            else if (product.Number < quantity) throw new Exception("Not enough product in stock!");
            else if (product == null) throw new Exception("Product is not found");
            else
            {
                var sum = product.Price * quantity;
                var saleItem = new SaleItem(product, quantity);
                tempSale.Add(saleItem);
                var sale = new Sale(sum, time);

                foreach (var item in tempSale)
                {
                    sale.AddSaleItem(item);
                }
                sales.Add(sale);
                Console.WriteLine("Sale added successfuly!");
            }
        }        
         public void ReturnOfProduct(int SaleId, int ProductId, int productNumber)
         {
            
            Sale sale = sales.Find(s => s.Id == SaleId);
            if (sale == null) throw new Exception("Sale is not found");

            
            SaleItem salesItem = sale.SaleItems.Find(x=>x.Id == ProductId);           
            if (salesItem == null) throw new Exception("Product in Sale is not found");
            if (productNumber > salesItem.Number) throw new Exception("Quantity must not more than product's number");

            decimal refundamount = (decimal)(productNumber * salesItem.Product.Price);
            
            salesItem.Product.Number += productNumber;
            salesItem.Number -= productNumber;
            sale.Amount -= refundamount;

         }
        public void DeleteSale(int id)
        {
            if (id < 0) throw new Exception("ID cannot be negative!");
            int getsaleid = sales.FindIndex(x => x.Id == id);
            if (getsaleid == -1) throw new Exception("Sale not found!");
            sales.RemoveAt(getsaleid);
        }
        public List<Sale> ShowSalesForDateRange(DateTime mintime, DateTime maxtime)
        {  
            if (mintime > maxtime) throw new Exception("Minimum time cannot be greater than maximum time!");
            List<Sale> result = sales.Where(x=>x.Time >= mintime && x.Time <= maxtime).ToList();
            if (result == null) throw new Exception("Sale is not found!");
            return result;
        }
        public List<Sale> ShowSalesForGivenAmount(decimal minamount,  decimal maxamount)
        {
            if (minamount > maxamount) throw new Exception("Minamonut cannot be greater than maxamount!");
            List<Sale> result = sales.Where(x=> x.Amount >= minamount && x.Amount <= maxamount).ToList();
            if (result == null) throw new Exception("Sale is not found!");
            return result;
        }
        public List<Sale> ShowSaleForGivenDate (DateTime dateTime)
        {
            if (dateTime == null) throw new Exception("Sale is not found!");
            List<Sale> result = sales.Where(x=> x.Time >= dateTime).ToList();
            return result;
        }
        public List<Sale> ShowSalesByID(int id)
        {
            if (id < 0) throw new Exception("ID cannot be negatice!");
            List<Sale> result = sales.FindAll(x => x.Id >= id).ToList();
            return result;  
        }
        public List<Product> GetProducts()
        {
            return products; 
        }
        public List<Sale> GetSale()
        {
            return sales;
        }
        public List<SaleItem> GetSaleItems()
        {
            return sale_İtems;
        }
    }
}
