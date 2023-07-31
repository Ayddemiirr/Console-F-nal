using ConsoleApp1.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Sabmenu
    {
        public static void ProductSabmenu()
        {
            int option = 0;
            do
            {
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Show Product");
                Console.WriteLine("5. Find Categories");
                Console.WriteLine("6. Find Price Range");
                Console.WriteLine("7. Find Product");
                Console.WriteLine("0. Exit");

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
                        MenuServices.MenuAddProduct();
                        break;
                    case 2:
                        MenuServices.MenuUptadeProduct();
                        break;
                    case 3:
                        MenuServices.MenuDeleteProduct();
                        break;
                    case 4:
                        MenuServices.MenuShowProduct();
                        break;
                    case 5:
                        MenuServices.MenuGetProductsByCategory();
                        break;
                    case 6:
                        MenuServices.MenuRangePrice();
                        break;
                    case 7:
                        MenuServices.MenuFindProductName();
                        break;
                    case 0:
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.WriteLine("There is no such option!");
                        break;
                }
            } while (option != 0);
        }
        public static void SalesSubMenu()
        {
            int option;
            do
            {
                Console.WriteLine("1. Add Sales");
                Console.WriteLine("2. Return Product From Sales");
                Console.WriteLine("3. Remove Sales");
                Console.WriteLine("4. Show Sales");
                Console.WriteLine("5. Show Price Sales Range");
                Console.WriteLine("6. Show Date Sales");
                Console.WriteLine("7. Finding sales by ID");
                Console.WriteLine("8. Show Sale For Date Interval");
                Console.WriteLine("0. Go back");
                Console.WriteLine("------------------------");
                Console.WriteLine("Please, select an option:");
                Console.WriteLine("------------------------");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("------------------------");
                }

                switch (option)
                {
                    case 1:
                        MenuServices.MenuAddSales();
                        break;
                    case 2:
                        MenuServices.MenuReturnProduct();
                        break;
                    case 3:
                        MenuServices.MenuDeleteSales();
                        break;
                    case 4:
                        MenuServices.MenuShowSales();
                        break;
                    case 5:
                        MenuServices.MenuGetSalesForPriceInteerval();
                        break;
                    case 6:
                        MenuServices.MenuDateSale();
                        break;
                    case 7:
                        MenuServices.MenuFindSales();
                        break;
                    case 8:
                        MenuServices.MenuFindSalesForDateInterval();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }
            } while (option != 0);
        }
    }
}
