using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Data
{
    public class Product
    {
        public int Id { get; set; }

        public string Ean { get; set; }
        public int CategoryId { get; set; }

        public int BrandId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Boolean InStock { get; set; }
        public DateTime ExpectedRestock { get; set; }

        public int Stock { get; set; }
    }
}
