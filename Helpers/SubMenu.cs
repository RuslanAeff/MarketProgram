using MarektDemo.Services.Abstract;
using MarektDemo.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarektDemo.Helpers
{
    public class SubMenu 
    {
        public static void SubMenuHelpProduct()
        {
            Console.Clear();

            int option;

            do
            {
                Console.WriteLine("1. Add new product");
                Console.WriteLine("2. Edit product");
                Console.WriteLine("3. Delete product");
                Console.WriteLine("4. Show all products");
                Console.WriteLine("5. Show products for category");
                Console.WriteLine("6. Show product for pricerange");
                Console.WriteLine("7. Search product by name");
                Console.WriteLine("0. Go back");
                Console.WriteLine("------------------------");
                Console.WriteLine("Please enter option:");
                Console.WriteLine("------------------------");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option!");
                    Console.WriteLine("Enter an option please:");
                    Console.WriteLine("----------------");
                }
                switch (option)
                {
                    case 1:
                       MenuService.MenuAddNewProduct();
                       break;
                    case 2:
                       MenuService.MenuEditProduct();
                       break;
                    case 3:
                       MenuService.MenuDeleteProduct();
                       break;
                    case 4:
                       MenuService.MenuShowAllProducts();
                       break;
                    case 5:
                       MenuService.MenuShowProductsForCategory();
                       break;
                    case 6:
                       MenuService.MenuShowProductsForPriceRange();
                       break;
                    case 7:
                       MenuService.MenuSearchProductbyName();
                       break;
                    case 8:
                       MenuService.MenuShowSalesByID();
                        break;
                    case 0:
                       Console.Clear();
                       break;
                    default:
                       Console.WriteLine("There is no such option!");
                       break;
                }

            } while (option != 0);
        }
        public static void SubMenuHelpSell()
        {
            Console.Clear ();

            int option;

            do
            {
                Console.WriteLine("1. Add new sale");
                Console.WriteLine("2. Product return (withdrawal from sale)");
                Console.WriteLine("3. Delete sale");
                Console.WriteLine("4. Show all sales");
                Console.WriteLine("5. Showing sales by date range");
                Console.WriteLine("6. Showing sales by amount range");
                Console.WriteLine("7. Showing sales on a given date");
                Console.WriteLine("8. Showing information of the sale with the given ID");
                Console.WriteLine("0. Go back");
                Console.WriteLine("------------------------");
                Console.WriteLine("Please enter option:");
                Console.WriteLine("------------------------");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option!");
                    Console.WriteLine("Enter an option please:");
                    Console.WriteLine("----------------");
                }
                switch (option)
                {
                    case 1:
                       MenuService.MenuAddNewSale();
                        break;
                    case 2:
                        MenuService.MenuReturnProduct();
                        break;
                    case 3:
                       MenuService.MenuDeleteSale();
                        break;
                    case 4:
                       MenuService.MenuShowAllSales();
                        break;
                    case 5:
                       MenuService.MenuShowSalesForDateRange();
                        break;
                    case 6:
                    MenuService.MenuShowSalesForGivenAmount();
                        break;
                    case 7:
                        MenuService.MenuShowSalesForGivenDate();
                        break; 
                    case 8:
                        MenuService.MenuShowSalesByID();
                        break;
                    case 0:
                        Console.Clear();
                        break;
                    default:
                       Console.WriteLine("There is no such option!");
                        break;
                }
            } while (option != 0);
        }
    }
}
