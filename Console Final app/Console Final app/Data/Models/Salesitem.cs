using ConsoleApp1.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data.Models
{
    public class SalesItem : BaseEntity
    {
        private static int count = 1;
        public SalesItem()
        {
            Id = count;
            count++;
        }
        public Product Product { get; set; }
        public int SaleItemCount { get; set; }
    }
}
