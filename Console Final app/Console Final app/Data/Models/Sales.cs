using ConsoleApp1.Data.Common;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data.Models
{
    public class Sales : BaseEntity
    {
        private static int count = 1;
        public Sales()
        {
            Id = count;
            count++;
        }
        public List<SalesItem> Salesİtem { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
