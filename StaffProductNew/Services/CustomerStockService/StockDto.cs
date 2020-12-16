using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Services.CustomerStockService
{
    public class StockDto
    {
        public int ProductId { get; set; }
        public int StockAmount { get; set; }

        public string ProductName { get; set; }
      
    }
}
