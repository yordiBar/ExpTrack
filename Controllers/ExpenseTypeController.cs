using ExpTrack.Data;
using ExpTrack.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpTrack.Controllers
{
    public class ExpenseTypeController : Controller
    {

        private readonly ApplicationDBContext _db;

        public ExpenseTypeController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseType> expenseTypeList = _db.ExpenseTypes;
            return View(expenseTypeList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseType expenseType)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Add(expenseType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseType);
        }


        // Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var expenseType = _db.ExpenseTypes.Find(id);
            if (expenseType == null)
            {
                return NotFound();
            }
            return View(expenseType);
        }

        // Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var expenseType = _db.ExpenseTypes.Find(id);
            if(expenseType == null)
            {
                return NotFound();
            }
            _db.ExpenseTypes.Remove(expenseType);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Get Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var expenseType = _db.ExpenseTypes.Find(id);
            if (expenseType == null)
            {
                return NotFound();
            }
            return View(expenseType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseType expenseType)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseTypes.Update(expenseType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseType);
        }

    }
}
