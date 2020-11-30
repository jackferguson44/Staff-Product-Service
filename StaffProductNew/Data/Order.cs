using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Data
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime When { get; set; }

        public string ProductName { get; set; }

        public string ProductEan { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
