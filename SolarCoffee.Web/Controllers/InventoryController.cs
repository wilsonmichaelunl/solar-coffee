using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Services.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCoffee.Web.Controllers
{
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IInventoryService _inventoryService;

        public InventoryController(ILogger<InventoryController> logger, IInventoryService inventoryService)
        {
            _logger = logger;
            _inventoryService = inventoryService;
        }

        [HttpGet("/api/inventory")]
        public ActionResult GetCurrentInventory()
        {
            _logger.LogInformation("Getting all inventory...");
            var inventory = _inventoryService.GetCurrentInventory()
                .Select(pi => new ProductInventoryModel { })
                .OrderBy(inv => inv.Product.Name)
                .ToList();

            return Ok(inventory);
        }
    }
}
