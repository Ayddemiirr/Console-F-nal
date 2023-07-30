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
        public void AddSales(List<int> ProductIds, List<int> SaleCounts)
        {
            if (ProductIds == null & SaleCounts == null & ProductIds.Count != SaleCounts.Count & ProductIds.Count == 0 & SaleCounts.Count == 0)
            {
                throw new Exception("Sale must contain at least one product with their quantity!");
            }
            decimal totalPrice = 0;
            List<SalesItem> saleItems = new List<SalesItem>();

            for (int i = 0; i < ProductIds.Count; i++)
            {
                int productId = ProductIds[i];
                int saleCount = SaleCounts[i];
                Product product = products.Find(m => m.Id == productId);
                if (product == null)
                {
                    throw new Exception($"Product Id {productId} is not found!");
                }
                if (product.Count < saleCount)
                {
                    throw new Exception("Quantity that you want to add is more than product's quantity");
                }
                totalPrice += (decimal)(product.Price * saleCount);
                SalesItem salesItem = new SalesItem
                {
                    Product = product,
                    SaleItemCount = saleCount
                };
                saleItems.Add(salesItem);
                product.Count -= saleCount;

            }
            Sales newSales = new Sales
            {
                Price = totalPrice,
                Salesİtem = saleItems,
                Date = DateTime.Now
            };
            sales.Add(newSales);
        }
        public List<Product> GetProducts()
        {
            return products;
        }
        public void DeleteProduct(int id)
        {
            if (id == null) throw new Exception("id is null");
            Product product = products.Find(m => m.Id == id);
            if (product == null) throw new Exception("Product is not found");

            products.Remove(product);

        }
        public List<Product> GetProductsByCategory(Categories categoryName)
        {
            if (categoryName == null) throw new Exception("Category is null");
            List<Product> ProductCategory = products.FindAll(m => m.Categories == categoryName);
            return ProductCategory;
        }
        public List<Product> GetProductsForPriceInterval(decimal minPrice, decimal maxPrice)
        {
            if (minPrice == null) throw new Exception("minimum Price is null");
            if (maxPrice == null) throw new Exception("maximum Price is null");
            List<Product> productsForPrice = products.FindAll(m => m.Price > minPrice && m.Price < maxPrice);
            return productsForPrice;
        }
        public List<Product> GetProductsByName(string name)
        {
            if (name == null) throw new Exception("name is null");
            List<Product> ProductName = products.FindAll(m => m.Name.Contains(name));
            return ProductName;
        }
        public List<Sales> GetSales()
        {
            return sales;
        }
        public Sales GetSalesById(int saleId)
        {
            if (saleId == null) throw new Exception("sale Id is null");
            Sales sale = sales.Find(s => s.Id == saleId);
            if (sale == null) throw new Exception("Sale is not founf");
            return sale;
        }
        public List<Sales> GetSalesForDate(DateTime dateTime)
        {
            if (dateTime == null) throw new Exception("Date is null");
            List<Sales> result = sales.Where(x => x.Date == dateTime).ToList();
            if (result.Count == 0) throw new Exception("Sale is not found");
            return result;
        }
        public List<Sales> GetSalesForDateInterval(DateTime FirstDate, DateTime LastDate)
        {
            if (FirstDate > LastDate) throw new Exception("Min date is grater than last date!");
            List<Sales> result = sales.Where(x => x.Date >= FirstDate && x.Date <= LastDate).ToList();
            if (result == null) throw new Exception("Sale is not found");
            return result;
        }
        public List<Sales> GetSalesForPriceInterval(decimal minPrice, decimal maxPrice)
        {
            if (minPrice == null) throw new Exception("minimum Price is null");
            if (maxPrice == null) throw new Exception("maximum Price is null");
            List<Sales> salesForPrice = sales.FindAll(m => m.Price > minPrice && m.Price < maxPrice);
            return salesForPrice;
        }
        public void ReturnProductFromSale(int SaleId, int ProductId, int count)
        {
            Sales sale = sales.Find(s => s.Id == SaleId);
            if (sale == null) throw new Exception("Sale is not found");
            SalesItem salesItem = sale.Salesİtem.Find(s => s.Id == ProductId);
            if (salesItem == null) throw new Exception("Product in Sale is not found");
            if (count > salesItem.SaleItemCount) throw new Exception("Quantity must not more than product's count");
            decimal refundamount = (decimal)(count * salesItem.Product.Price);

            salesItem.Product.Count += count;
            salesItem.SaleItemCount -= count;
            sale.Price -= refundamount;



        }
        public void DeleteSale(int SaleId)
        {
            if (SaleId == null) throw new Exception("id is null");
            Sales sale = sales.Find(m => m.Id == SaleId);
            if (sale == null) throw new Exception("Sale is not found");

            sales.Remove(sale);

        }
        public void UpdateProduct(string NewName, decimal NewPrice, int NewCount, Categories NewCategories, int id)
        {
            if (id == null) throw new Exception("Id is null!");
            Product singleProduct = products.Find(s => s.Id == id);
            if (singleProduct == null)
            {
                throw new Exception("Product is not Found");
            }
            //Console.WriteLine("We Find This Producr");
            //Console.WriteLine($"{singleProduct.Id},{singleProduct.Name},{singleProduct.Price},{singleProduct.Categories},{singleProduct.Count}");
            if (NewName == null) throw new Exception("New name is null!");
            if (NewPrice == null) throw new Exception("New Price is null!");
            if (NewCount == null) throw new Exception("New Count is null!");

            singleProduct.Name = NewName;
            singleProduct.Price = NewPrice;
            singleProduct.Categories = NewCategories;
            singleProduct.Count = NewCount;
        }

    }
}
