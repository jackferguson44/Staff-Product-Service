using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffProductNew.Services.PurchaseRequestStockService
{
    public class FakePurchaseRequestService : IPurchaseRequestService
    {
        private readonly PurchaseRequestDto[] _purchaseRequests =
        {
            new PurchaseRequestDto{ Id = 1, ProductId = 1, purchaseAmount = 10},
            new PurchaseRequestDto{ Id = 2, ProductId = 2, purchaseAmount = 25}
        };

        public Task<PurchaseRequestDto> CreatePurchaseRequest(int id, int productId, int purchaseAmount)
        {

            var purchaseRequest = _purchaseRequests.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(purchaseRequest);
            //return 

        }
    }
}
