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
    }
}
