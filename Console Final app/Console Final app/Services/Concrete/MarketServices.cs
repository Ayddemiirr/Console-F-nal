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
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name is empty!");
            if (price == null) throw new Exception("price is empty!");
            if (count == null) throw new Exception("count is empty!");


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
                throw new Exception("Must have at least one of the products sold!");
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
                    throw new Exception("The amount you want to add is greater than the amount of the product!");
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
            if (id == null) throw new Exception("id is empty");
            Product product = products.Find(m => m.Id == id);
            if (product == null) throw new Exception("Product is not found");

            products.Remove(product);

        }
        public List<Product> GetProductsByCategory(Categories categoryName)
        {
            if (categoryName == null) throw new Exception("Category is empty");
            List<Product> ProductCategory = products.FindAll(m => m.Categories == categoryName);
            return ProductCategory;
        }
        public List<Product> GetProductsForPriceInterval(decimal minPrice, decimal maxPrice)
        {
            if (minPrice == null) throw new Exception("minimum Price is empty");
            if (maxPrice == null) throw new Exception("maximum Price is empty");
            List<Product> productsForPrice = products.FindAll(m => m.Price > minPrice && m.Price < maxPrice);
            return productsForPrice;
        }
        public List<Product> GetProductsByName(string name)
        {
            if (name == null) throw new Exception("name is empty");
            List<Product> ProductName = products.FindAll(m => m.Name.Contains(name));
            return ProductName;
        }
        public List<Sales> GetSales()
        {
            return sales;
        }
        public void UpdateProduct(string NewName, decimal NewPrice, int NewCount, Categories NewCategories, int id)
        {
            if (id == null) throw new Exception("Id is empty!");
            Product singleProduct = products.Find(s => s.Id == id);
            if (singleProduct == null)
            {
                throw new Exception("Product is not Found");
            }
            if (NewName == null) throw new Exception("New name is empty!");
            if (NewPrice == null) throw new Exception("New Price is empty!");
            if (NewCount == null) throw new Exception("New Count is empty!");

            singleProduct.Name = NewName;
            singleProduct.Price = NewPrice;
            singleProduct.Categories = NewCategories;
            singleProduct.Count = NewCount;
        }
        public Sales GetSalesById(int saleId)
        {
            if (saleId == null) throw new Exception("sale Id is empty");
            Sales sale = sales.Find(s => s.Id == saleId);
            if (sale == null) throw new Exception("Sale is not found");
            return sale;
        }
        public List<Sales> GetSalesForDate(DateTime dateTime)
        {
            if (dateTime == null) throw new Exception("Date is empty");
            List<Sales> result = sales.Where(x => x.Date == dateTime).ToList();
            if (result.Count == 0) throw new Exception("Sale is not found");
            return result;
        }
        public List<Sales> GetSalesForDateInterval(DateTime FirstDate, DateTime LastDate)
        {
            if (FirstDate > LastDate) throw new Exception("The minimum date cannot be greater than the deadline!");
            List<Sales> result = sales.Where(x => x.Date >= FirstDate && x.Date <= LastDate).ToList();
            if (result == null) throw new Exception("Sale is not found");
            return result;
        }
        public List<Sales> GetSalesForPriceInterval(decimal minPrice, decimal maxPrice)
        {
            if (minPrice == null) throw new Exception("minimum Price is empty");
            if (maxPrice == null) throw new Exception("maximum Price is empty");
            List<Sales> salesForPrice = sales.FindAll(m => m.Price > minPrice && m.Price < maxPrice);
            return salesForPrice;
        }
        public void ReturnProductFromSale(int SaleId, int ProductId, int count)
        {
            Sales sale = sales.Find(s => s.Id == SaleId);
            if (sale == null) throw new Exception("Sale is not found");
            SalesItem salesItem = sale.Salesİtem.Find(s => s.Id == ProductId);
            if (salesItem == null) throw new Exception("Product in Sale is not found");
            if (count > salesItem.SaleItemCount) throw new Exception("The amount should not exceed the number of products!");
            decimal refundamount = (decimal)(count * salesItem.Product.Price);

            salesItem.Product.Count += count;
            salesItem.SaleItemCount -= count;
            sale.Price -= refundamount;



        }
        public void DeleteSale(int SaleId)
        {
            if (SaleId == null) throw new Exception("id is empty");
            Sales sale = sales.Find(m => m.Id == SaleId);
            if (sale == null) throw new Exception("Sale is not found");

            sales.Remove(sale);

        }

    }
}
