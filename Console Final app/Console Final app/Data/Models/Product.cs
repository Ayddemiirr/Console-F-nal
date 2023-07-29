using ConsoleApp1.Data.Common;
using ConsoleApp1.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data.Models
{
    public class Product : BaseEntity
    {
        private static int count = 1;
        public Product()
        {
            Id = count;
            count++;
        }

        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public Categories? Categories { get; set; }
        public int? Count { get; set; }

    }
}
