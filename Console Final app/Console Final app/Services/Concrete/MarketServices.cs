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

    }
}
