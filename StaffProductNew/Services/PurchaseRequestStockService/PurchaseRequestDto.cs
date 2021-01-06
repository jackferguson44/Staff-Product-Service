using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Services.PurchaseRequestStockService
{
    public class PurchaseRequestDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int purchaseAmount { get; set; }
    }
}
