using Microsoft.AspNetCore.Mvc;
using MVCTest.Data;
using MVCTest.Models;

namespace MVCTest.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCreategoryList = _db.Categories.ToList();
            return View(objCreategoryList);

        }
    }
}
