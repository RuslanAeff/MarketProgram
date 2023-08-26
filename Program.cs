using MarektDemo.Helpers;
using MarektDemo.Services.Concrete;
using System;
using System.Data.SqlTypes;

namespace MarketDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            int option;

            do
            {
                Console.WriteLine("1. Transaction on products ");
                Console.WriteLine("2. Transaction on sales");
                Console.WriteLine("3. Exit");
                Console.WriteLine("------------------------");
                Console.WriteLine("Please enter option:");
                Console.WriteLine("------------------------");


               while(!int.TryParse(Console.ReadLine(), out option))
               {
                    Console.WriteLine("Invalid option!");
                    Console.WriteLine("Enter an option please:");
                    Console.WriteLine("----------------");
               }

                switch (option)
                {
                    case 1:
                        SubMenu.SubMenuHelpProduct();
                        break;
                    case 2:
                        SubMenu.SubMenuHelpSell();
                        break;                         
                    default:
                        Console.WriteLine("There is no such option");
                        break;
                }
            } while (option!=0);
        }
    }
}