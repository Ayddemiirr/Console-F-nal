using ConsoleApp1.Data.Enums;
using ConsoleApp1.Data.Models;
using ConsoleApp1.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services.Concrete
{
    public class MarketServices : IMarketable
    {
        public List<Product> products = new();
        public List<Sales> sales = new();
        public int AddProduct(string name, decimal price, Categories categories, int count)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name is null!");
            if (price == null) throw new Exception("price is null!");
            if (count == null) throw new Exception("count is null!");


            Product product = new Product
            {
                Name = name,
                Price = price,
                Categories = categories,
                Count = count
            };
            products.Add(product);
            return product.Id;
        }
    }
}
