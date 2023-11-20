using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcFormProject.OtherClasses;
using MvcFormProject.Models;

namespace MvcFormProject.Controllers
{
    public class SalesController : Controller
    {
        private readonly MvcProjDbContext _context;
        public SalesController(MvcProjDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var viewModel = new SalesViewModel
            {
                Customers = _context.Customer.ToList(),
                Employees = _context.Employee.ToList(),
                Inventory = _context.Inventory.ToList()
            };

            return View(viewModel);
        }


        public IActionResult SalesLogs()
        {
            var logs = _context.SalesLogs
                .Include(s => s.Customer)
                .Include(s => s.Employee)
                .Include(s => s.Item)
                .ToList();

            return View(logs);
        }
        [HttpGet]
        public IActionResult GetMoreInfo(int id)
        {
            var logs = _context.SalesLogs
                .Include(s => s.Customer)
                .Include(s => s.Employee)
                .Include(s => s.Item)
                .FirstOrDefault(s => s.SaleID == id);

            return View(logs);
        }

    }
}
