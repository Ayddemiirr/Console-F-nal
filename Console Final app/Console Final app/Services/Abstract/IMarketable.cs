using ConsoleApp1.Data.Enums;
using ConsoleApp1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services.Abstract
{
    public interface IMarketable
    {
        public List<Sales> GetSales();
        public List<Product> GetProducts();
    }
}
