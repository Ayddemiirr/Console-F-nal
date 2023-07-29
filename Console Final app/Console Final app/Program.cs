using ConsoleApp1.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int option = 0;
            do
            {
                Console.WriteLine("1. Transaction On Products");
                Console.WriteLine("2. Transaction On Sales");
                Console.WriteLine("3. Exit");

                Console.WriteLine("----------------");
                Console.WriteLine("Enter an option please:");
                Console.WriteLine("----------------");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option!");
                    Console.WriteLine("Enter an option please:");
                    Console.WriteLine("----------------");
                }

                switch (option)
                {
                    case 1:
                        Sabmenu.ProductSabmenu();
                        break;
                    case 2:
                        Sabmenu.SalesSubMenu();
                        break;
                    case 0:
                        Console.WriteLine("Bye");
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }
            } while (option != 0);
        }
    }
}
