using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using MarektDemo.DATA.Enum;
using MarektDemo.Models;

namespace MarektDemo.Services.Concrete
{
    public class MenuService
    {
        private static MarketService marketservice = new MarketService();

        public static void MenuAddNewProduct()
        {
            try
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter price");
                int price = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter catagory:");
                Console.WriteLine("               ");
                Console.WriteLine("0. Food  1. Electronics  2.Drinks");
                Category catagory = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);

                Console.WriteLine("Enter number:");
                int number = int.Parse(Console.ReadLine());

                int newId = marketservice.AddProduct(name, price, catagory, number);
                Console.WriteLine($"Product with ID {newId} was created!");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuEditProduct()
        {
            try
            {
                Console.WriteLine("Enter Id:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter price:");
                int price = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter category");
                Console.WriteLine("               ");
                Console.WriteLine("0. Food  1. Electronics  2.Drinks");
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);
                Console.WriteLine("Enter number:");
                int number = int.Parse(Console.ReadLine());
                marketservice.EditProduct(id, name, price, category, number);
                Console.WriteLine("Successfult edited!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuDeleteProduct()
        {
            try
            {
                Console.WriteLine("Enter product's ID:");
                int id = int.Parse(Console.ReadLine());

                marketservice.DeleteProduct(id);
                Console.WriteLine("The product deleted successfuly!");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuShowAllProducts()
        {
            try
            {
                var products = marketservice.GetProducts();

                if (products.Count == 0)
                {
                    Console.WriteLine("There are no products!");
                }
                var table = new ConsoleTable("Id", "Name", "Price", "Category", "Number");
                foreach (var product in products)
                {
                    table.AddRow(product.Id, product.Name, product.Price, product.Catagory, product.Number);
                }
                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuShowProductsForCategory()
        {
            Console.Clear();
            var array = Enum.GetValues(typeof(Category)).Cast<Category>().ToArray();
            try
            {
                var products = marketservice.GetProducts();
                Console.WriteLine($"1.Food 2.Electronics 3.Drinks");
                Console.WriteLine("                         ");
                Console.WriteLine("Enter product's category:");
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);
                bool isEqual = array.Any(c => c.Equals(category));
                if (isEqual == false)
                {
                    throw new Exception("SomeThings Went Wrong!!!");
                }
                var table = new ConsoleTable("Id", "Name", "Price", "Category", "Number");
                var getcategory = products.FindAll(x => x.Catagory == category);
                foreach (var product in getcategory)
                {
                    table.AddRow(product.Id, product.Name, product.Price, product.Catagory, product.Number);
                }
                table.Write();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuShowProductsForPriceRange()
        {
            try
            {
                Console.WriteLine("Enter minamount:");
                int minamount = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter maxamount:");
                int maxamount = int.Parse(Console.ReadLine());
                var existproduct = marketservice.ShowProductsForPriceRange(minamount, maxamount);
                if (existproduct.Count == 0)
                {
                    Console.WriteLine("Not Found!");
                }

                var table = new ConsoleTable("Id", "Name", "Price", "Category", "Number");
                foreach (var product in existproduct)
                {
                    table.AddRow(product.Id, product.Name, product.Price, product.Catagory, product.Number);
                }
                table.Write();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuSearchProductbyName()
        {
            try
            {
                var products = marketservice.GetProducts();
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();
                if (products.Count == 0) throw new Exception("Not Found!");
                if (string.IsNullOrEmpty(name)) throw new Exception("Name cannot be null!");

                var table = new ConsoleTable("Id", "Name", "Price", "Category", "Number");

                var productna = products.Where(x => x.Name == name).ToArray();

                foreach (var productn in productna)
                {
                    table.AddRow(productn.Id, productn.Name, productn.Price, productn.Catagory, productn.Number);
                }
                table.Write();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuAddNewSale()
        {
            try
            {
                Console.WriteLine("Enter product ID:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter sale's quantity");
                int quantity = int.Parse(Console.ReadLine());

                marketservice.AddSale(id, quantity, DateTime.Now);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuReturnProduct()
        {
            try
            {
                Console.WriteLine("Enter ID for checking:");
                int saleId = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Enter product ID for checking:");
                int productId = int.Parse(Console.ReadLine());                

                Console.WriteLine("Enter number for cehcking:");
                int productNumber = int.Parse(Console.ReadLine());

                marketservice.ReturnOfProduct(saleId, productId, productNumber);

                Console.WriteLine("Product returned successfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }           
        public static void MenuShowAllSales()
        {
            try
            {
                var sale = marketservice.GetSale();

                if (sale.Count == 0) throw new Exception("There are no sales!");

                var table = new ConsoleTable("ID", "Amount", "Time");
                foreach (var sales in sale)
                {
                    table.AddRow(sales.Id, sales.Amount, sales.Time);
                }
                table.Write();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuDeleteSale()
        {
            try 
            {
                Console.WriteLine("Enter sales's ID:");
                int id = int.Parse(Console.ReadLine());

                marketservice.DeleteSale(id);
                Console.WriteLine("Sale deleted successfuly!");
            }
            catch ( Exception ex ) 
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            } 
        }
        public static void MenuShowSalesForDateRange()
        {
            try
            {
                Console.WriteLine("Enter mindate dd/MM/yyyy format: ");
                DateTime mindate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter maxdate dd//MM/yyyy format:");
                DateTime maxdate = DateTime.Parse(Console.ReadLine());
                var existsales = marketservice.ShowSalesForDateRange(mindate, maxdate);
                if (existsales.Count == 0) throw new Exception("Sale not found!");

               foreach( var item in existsales) 
                {    
                    var table = new ConsoleTable("ID","Name","Number","Amount","Date");

                    foreach (var item2 in item.SaleItems)
                    {
                        table.AddRow(item.Id,item2.Product.Name,item.SaleItems.Count ,item.Amount,item.Time);                     
                    }
                    table.Write();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuShowSalesForGivenAmount()
        {
            try
            {
                Console.WriteLine("Enter minprice:");
                decimal minamount = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter maxprice:");
                decimal maxamount = decimal.Parse(Console.ReadLine());
                var existsale = marketservice.ShowSalesForGivenAmount(minamount, maxamount);
                if (existsale.Count == 0) throw new Exception("Sale is not found!");

                foreach (var item in existsale)
                {
                    var table = new ConsoleTable("ID", "Name", "Number", "Amount", "Date");
                    foreach (var item2 in item.SaleItems)
                    {
                        table.AddRow(item.Id, item2.Product.Name, item.SaleItems.Count, item.Amount, item.Time);
                    }
                    table.Write();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            } 
        }
        public static void MenuShowSalesForGivenDate()
        {
            try
            {
                Console.WriteLine("Enter date dd/MM/yyyy format:");
                DateTime dateTime = DateTime.Parse(Console.ReadLine());

                var existsale = marketservice.ShowSaleForGivenDate(dateTime);
                if (existsale.Count == 0) throw new Exception("Sale is not found!");

                foreach (var item in existsale)
                {
                    var table = new ConsoleTable("ID", "Name", "Number", "Amount", "Date");
                    foreach (var item2 in item.SaleItems)
                    {
                        table.AddRow(item.Id, item2.Product.Name, item.SaleItems.Count, item.Amount, item.Time);
                    }
                    table.Write();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuShowSalesByID()
        {
            try
            {
                var sales = marketservice.GetSale();
                Console.WriteLine("Enter sale's ID:");
                int id =int.Parse(Console.ReadLine());

                var existsale = marketservice.ShowSalesByID(id);
                if (sales.Count == 0) throw new Exception("Not Found!");
               
                var table = new ConsoleTable("ID", "Name", "Number", "Amount", "Date");
               
                foreach (var item in existsale)
                {
                    foreach (var item2 in item.SaleItems)
                    {
                        table.AddRow(item.Id, item2.Product.Name, item.SaleItems.Count, item.Amount, item.Time);
                    }
                    table.Write();
                }
            }
            catch ( Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
    }
}        
