using Microsoft.AspNetCore.Mvc;
using MvcFormProject.OtherClasses;

namespace MvcFormProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MvcProjDbContext _context;
        public EmployeeController(MvcProjDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var employee = _context.Employee.ToList();
            return View(employee);
        }
    }
}
