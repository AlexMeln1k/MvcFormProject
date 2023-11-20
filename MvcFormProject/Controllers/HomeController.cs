using Microsoft.AspNetCore.Mvc;
using MvcFormProject.Models;
using MvcFormProject.OtherClasses;
using System.Diagnostics;
using System.Linq;

namespace MvcFormProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MvcProjDbContext _context;

        public HomeController(ILogger<HomeController> logger, MvcProjDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var customers = _context.Customer.ToList();
            return View(customers);
        }

        [HttpGet]
        public IActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewCustomer(Customer newCustomer)
        {
            if (ModelState.IsValid)
            {
                if (!IsDuplicateCustomer(newCustomer))
                {
                    _context.Customer.Add(newCustomer);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "A user with the same name, last name, and birthdate already exists.");
                    return View(newCustomer);
                }
            }
            return View(newCustomer);
        }

        private bool IsDuplicateCustomer(Customer newCustomer)
        {
            return _context.Customer.Any(c =>
                c.FirstName == newCustomer.FirstName &&
                c.LastName == newCustomer.LastName &&
                c.BirthDate == newCustomer.BirthDate);
        }

        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            if (_context.Customer.Any(c => c.CustomerID == id) && id != 0)
            {
                var customer = _context.Customer.FirstOrDefault(f => f.CustomerID == id);
                return View(customer);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditCustomer(Customer editedCustomer)
        {
            if (ModelState.IsValid)
            {
                if (!IsDuplicateCustomerOnEdit(editedCustomer))
                {
                    var existingCustomer = _context.Customer.FirstOrDefault(c => c.CustomerID == editedCustomer.CustomerID);

                    if (existingCustomer != null)
                    {
                        existingCustomer.FirstName = editedCustomer.FirstName;
                        existingCustomer.LastName = editedCustomer.LastName;
                        existingCustomer.BirthDate = editedCustomer.BirthDate;
                        existingCustomer.DisabilityInfo = editedCustomer.DisabilityInfo;

                        _context.SaveChanges();

                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "A user with the same name, last name, and birthdate already exists.");
                    return View(editedCustomer);
                }
            }
            return View(editedCustomer);
        }

        private bool IsDuplicateCustomerOnEdit(Customer editedCustomer)
        {
            return _context.Customer.Any(c =>
                c.CustomerID != editedCustomer.CustomerID &&
                c.FirstName == editedCustomer.FirstName &&
                c.LastName == editedCustomer.LastName &&
                c.BirthDate == editedCustomer.BirthDate);
        }

        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customer.FirstOrDefault(c => c.CustomerID == id);

            if (customer != null)
            {
                _context.Customer.Remove(customer);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Inventory()
        {
            var inventory = _context.Inventory.ToList();
            return View(inventory);
        }

        [HttpGet]
        public IActionResult NewInventoryItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewInventoryItem(Inventory newItem)
        {
            if (ModelState.IsValid)
            {
                if (!IsDuplicateInventoryItem(newItem))
                {
                    _context.Inventory.Add(newItem);
                    _context.SaveChanges();

                    return RedirectToAction("Inventory");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An item with the same name already exists.");
                    return View(newItem);
                }
            }
            return View(newItem);
        }

        private bool IsDuplicateInventoryItem(Inventory newItem)
        {
            return _context.Inventory.Any(i =>
                i.ItemName == newItem.ItemName);
        }

        [HttpGet]
        public IActionResult EditInventoryItem(int id)
        {
            if (_context.Inventory.Any(i => i.ItemID == id) && id != 0)
            {
                var inventoryItem = _context.Inventory.FirstOrDefault(i => i.ItemID == id);
                return View(inventoryItem);
            }
            return RedirectToAction("Inventory");
        }

        [HttpPost]
        public IActionResult EditInventoryItem(Inventory editedItem)
        {
            if (ModelState.IsValid)
            {
                if (!IsDuplicateInventoryItemOnEdit(editedItem))
                {
                    var existingItem = _context.Inventory.FirstOrDefault(i => i.ItemID == editedItem.ItemID);

                    if (existingItem != null)
                    {
                        existingItem.ItemName = editedItem.ItemName;
                        existingItem.Description = editedItem.Description;
                        existingItem.Category = editedItem.Category;
                        existingItem.Price = editedItem.Price;
                        existingItem.StockQuantity = editedItem.StockQuantity;
                        existingItem.AvailableForSale = editedItem.AvailableForSale;
                        existingItem.RecommendedForDisabilities = editedItem.RecommendedForDisabilities;

                        _context.SaveChanges();

                        return RedirectToAction("Inventory");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An item with the same name already exists.");
                    return View(editedItem);
                }
            }
            return View(editedItem);
        }

        private bool IsDuplicateInventoryItemOnEdit(Inventory editedItem)
        {
            return _context.Inventory.Any(i =>
                i.ItemID != editedItem.ItemID &&
                i.ItemName == editedItem.ItemName);
        }

        public IActionResult DeleteItemFromInventory(int id)
        {
            var item = _context.Inventory.FirstOrDefault(c => c.ItemID == id);

            if (item != null)
            {
                _context.Inventory.Remove(item);
                _context.SaveChanges();

                return RedirectToAction("Inventory");
            }

            return RedirectToAction("Inventory");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
