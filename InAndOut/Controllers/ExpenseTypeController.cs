using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseType> objList = _db.ExpensesTypes;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpensesTypes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = _db.ExpensesTypes.Find(id);

            if (obj == null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.ExpensesTypes.Find(id);

            if (obj == null)
                return NotFound();

            _db.ExpensesTypes.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = _db.ExpensesTypes.Find(id);

            if (obj == null)
                return NotFound();

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Update(ExpenseType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpensesTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
