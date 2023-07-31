using ConsoleApp1.Data.Enums;
using ConsoleApp1.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services.Concrete
{
    public class MenuServices
    {
        public static MarketServices marketServices = new MarketServices();
        public static void MenuAddProduct()
        {
            try
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter price:");
                string price = Console.ReadLine();
                decimal PriceProduct = decimal.Parse(price);

                Console.WriteLine("Enter count:");
                string count = Console.ReadLine();
                int.TryParse(count, out int CountProduct);

                Console.WriteLine("Enter Category:");
                Categories categories = (Categories)Enum.Parse(typeof(Categories), Console.ReadLine(), true);

                int newId = marketServices.AddProduct(name, PriceProduct, categories, CountProduct);
                Console.WriteLine("Product Added Successfully");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuUptadeProduct()
        {
            try
            {
                Console.WriteLine("Please type the product ID you want to update");
                string ProductID = Console.ReadLine();
                int.TryParse(ProductID, out int ID);

                Console.WriteLine("Please Add New name");
                var NewName = Console.ReadLine();

                Console.WriteLine("Enter New price:");
                string Newprice = Console.ReadLine();
                decimal NewPriceProduct = decimal.Parse(Newprice);

                Console.WriteLine("Enter new count:");
                string Newcount = Console.ReadLine();
                int.TryParse(Newcount, out int NewCountProduct);

                Console.WriteLine("Enter Category:");
                Categories Newcategories = (Categories)Enum.Parse(typeof(Categories), Console.ReadLine(), true);
                marketServices.UpdateProduct(NewName, NewPriceProduct, NewCountProduct, Newcategories, ID);
                Console.WriteLine("Product Updated Successfully");
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
                Console.WriteLine("Please write Product Id which you want to delete");
                string ProductID = Console.ReadLine();
                int.TryParse(ProductID, out int ID);
                marketServices.DeleteProduct(ID);
                Console.WriteLine("Product Deleted Successfully");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuShowProduct()
        {
            try
            {
                var allproducts = marketServices.GetProducts();
                Console.WriteLine("All Products");
                foreach (Product item in allproducts)
                {
                    Console.WriteLine($"{item.Id},{item.Name},{item.Price},{item.Categories},{item.Count}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuRangePrice()
        {
            try
            {
                Console.WriteLine("Please Enter minimum Price");
                string minimum = Console.ReadLine();
                decimal minimumPrice = decimal.Parse(minimum);

                Console.WriteLine("Please Enter maximum Price");
                string maximum = Console.ReadLine();
                decimal maximumPrice = decimal.Parse(maximum);

                var ProductsPriceInterval = marketServices.GetProductsForPriceInterval(minimumPrice, maximumPrice);
                foreach (var item in ProductsPriceInterval)
                {
                    Console.WriteLine($"{item.Id},{item.Name},{item.Price},{item.Categories},{item.Count}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuGetSalesForPriceInteerval()
        {
            try
            {
                Console.WriteLine("Please Enter minimum Price");
                string minimum = Console.ReadLine();
                decimal minimumPrice = decimal.Parse(minimum);

                Console.WriteLine("Please Enter maximum Price");
                string maximum = Console.ReadLine();
                decimal maximumPrice = decimal.Parse(maximum);

                var SalesPriceInterval = marketServices.GetSalesForPriceInterval(minimumPrice, maximumPrice);
                foreach (var item in SalesPriceInterval)
                {
                    Console.WriteLine($"{item.Id},{item.Price},{item.Date}");
                    foreach (var saleitem in item.Salesİtem)
                    {
                        Console.WriteLine($"{saleitem.Product.Name},{saleitem.SaleItemCount}");
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuGetProductsByCategory()
        {
            Console.WriteLine("Please choose the Category Name");
            foreach (Categories categoryy in Enum.GetValues(typeof(Categories)))
            {
                Console.WriteLine($"{categoryy}");
            }
            Categories categories = (Categories)Enum.Parse(typeof(Categories), Console.ReadLine(), true);
            var procategory = marketServices.GetProductsByCategory(categories);
            foreach (var item in procategory)
            {
                Console.WriteLine($"{item.Id},{item.Name},{item.Price},{item.Categories},{item.Count}");
            }

        }
        public static void MenuFindProductName()
        {
            try
            {
                Console.WriteLine("Please enter the text for search");
                string ProductSearch = Console.ReadLine();
                var Search = marketServices.GetProductsByName(ProductSearch);
                foreach (var item in Search)
                {
                    Console.WriteLine($"{item.Id},{item.Name},{item.Price},{item.Categories},{item.Count}");
                }
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
                Console.WriteLine("Please enter which sale you want to update ");
                string saleIdsInput = Console.ReadLine();
                int.TryParse(saleIdsInput, out int saleId);

                Console.WriteLine("Please enter which product you want to return");
                string productIdsInput = Console.ReadLine();
                int.TryParse(productIdsInput, out int productId);

                Console.WriteLine("Please enter how many product you want to return");
                string productCountInput = Console.ReadLine();
                int.TryParse(productCountInput, out int productCount);

                marketServices.ReturnProductFromSale(saleId, productId, productCount);
                Console.WriteLine("Product returned successfully");

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuDeleteSales()
        {
            try
            {
                Console.WriteLine("Please enter Sale Id which you want to delete");
                string SaleID = Console.ReadLine();
                int.TryParse(SaleID, out int ID);
                marketServices.DeleteSale(ID);
                Console.WriteLine("Sale deleted successfully");
            }

            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuAddSales()
        {
            try
            {
                Console.WriteLine("Enter Product Ids:");
                string productIdsInput = Console.ReadLine();
                List<int> productIds = productIdsInput.Split(',').Select(int.Parse).ToList();


                Console.WriteLine("Enter Sale Counts:");
                string saleCountsInput = Console.ReadLine();
                List<int> saleCounts = saleCountsInput.Split(',').Select(int.Parse).ToList();
                if (saleCounts.Count != productIds.Count)
                {
                    throw new Exception("The number of product Ids and sale counts must be same");
                }

                marketServices.AddSales(productIds, saleCounts);
                Console.WriteLine("Sale Added Successfully");


            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuShowSales()
        {
            try
            {
                var sales = marketServices.GetSales();
                Console.WriteLine("All Sales");
                foreach (var item in sales)
                {
                    Console.WriteLine($"{item.Id},{item.Price},{item.Date}");
                    foreach (var saleitem in item.Salesİtem)
                    {
                        Console.WriteLine($"{saleitem.Product.Name},{saleitem.SaleItemCount}");
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuDatetimeSales()
        {
            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuDateSale()
        {
            try
            {
                Console.WriteLine("Enter date (dd/MM/yyyy):");
                DateTime date = DateTime.Parse(Console.ReadLine());
                var SalesForDate = marketServices.GetSalesForDate(date);
                foreach (var item in SalesForDate)
                {
                    Console.WriteLine($"{item.Id},{item.Price},{item.Date}");
                    foreach (var saleitem in item.Salesİtem)
                    {
                        Console.WriteLine($"{saleitem.Product.Name},{saleitem.SaleItemCount}");

                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuFindSales()
        {
            try
            {

                Console.WriteLine("Please Enter which sale you want to see ");
                string saleIdsInput = Console.ReadLine();
                int.TryParse(saleIdsInput, out int saleId);

                var SingleSale = marketServices.GetSalesById(saleId);

                Console.WriteLine($"{SingleSale.Id},{SingleSale.Price},{SingleSale.Date}");
                foreach (var saleitem in SingleSale.Salesİtem)
                {
                    Console.WriteLine($"{saleitem.Product.Id},{saleitem.Product.Name},{saleitem.SaleItemCount}");

                }


            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
        public static void MenuFindSalesForDateInterval()
        {
            try
            {
                Console.WriteLine("Enter First date (dd/MM/yyyy):");
                DateTime Firstdate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter Last date (dd/MM/yyyy):");
                DateTime Lastdate = DateTime.Parse(Console.ReadLine());

                var SalesForDateInterval = marketServices.GetSalesForDateInterval(Firstdate, Lastdate);
                foreach (var item in SalesForDateInterval)
                {
                    Console.WriteLine($"{item.Id},{item.Price},{item.Date}");
                    foreach (var saleitem in item.Salesİtem)
                    {
                        Console.WriteLine($"{saleitem.Product.Name},{saleitem.SaleItemCount}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
    }
}
