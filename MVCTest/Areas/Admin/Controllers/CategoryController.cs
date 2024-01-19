using GenericServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCTest.DataAccess.Data;
using MVCTest.Models;

namespace MVCTest.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        //private readonly ApplicationDbContext _db;
        private readonly ICrudServices _service;
        public CategoryController(ICrudServices service)
        {
            //_db = db;
            _service = service;
        }
        public IActionResult Index()
        {
            //List<Category> objCreategoryList = _db.Categories.ToList();
            List<Category> objCreategoryList = _service.ReadManyNoTracked<Category>().ToList();
            return View(objCreategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "類別名稱不能跟顯示順序一致。");
            }

            if (ModelState.IsValid)
            {
                _service.CreateAndSave(obj);
                //_db.Categories.Add(obj);
                //_db.SaveChanges();

                TempData["success"] = "類別新增成功!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Category? categoryFromDb = _db.Categories.Find(id);
            Category? categoryFromDb = _service.ReadSingle<Category>(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateAndSave(obj);
                //_db.Categories.Update(obj);
                //_db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Category categoryFromDb = _db.Categories.Find(id);
            Category? categoryFromDb = _service.ReadSingle<Category>(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            //Category? obj = _db.Categories.Find(id);
            Category? obj = _service.ReadSingle<Category>(id);
            if (obj == null)
            {
                return NotFound();
            }
            _service.DeleteAndSave<Category>(obj.Id);
            //_db.Categories.Remove(obj);
            //_db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
