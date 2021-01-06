using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StaffProductNew.Data;
using StaffProductNew.Repository;
using StaffProductNew.Services.PurchaseRequestStockService;

namespace StaffProductNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseRequestController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IPurchaseRequestService _purchaseRequestService;

        public PurchaseRequestController(IProductRepository productRepository, IPurchaseRequestService purchaseRequestService)
        {
            _productRepository = productRepository;
            _purchaseRequestService = purchaseRequestService;
        }

        //PUT api/purchaseRequest/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult>CreatePurchaseRequest(int id, int productId, int purchaseAmount)
        {
            var purchaseRequest = await _purchaseRequestService.CreatePurchaseRequest(id, productId, purchaseAmount);
            return Ok(purchaseRequest);
        }

    }
}
