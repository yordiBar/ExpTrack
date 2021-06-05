using ExpTrack.Data;
using ExpTrack.Models;
using ExpTrack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpTrack.Controllers
{
    public class ExpenseController : Controller
    {

        private readonly ApplicationDBContext _db;

        public ExpenseController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> expenseList = _db.Expenses;
            return View(expenseList);
        }

        //GET Create
        public IActionResult Create()
        {
            ExpenseVM expenseVM = new ExpenseVM()
            {
                Expense = new Expense(),
                TypeDropDown = _db.ExpenseTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(expenseVM);
        }

        // POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseVM expenseVM)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(expenseVM.Expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseVM);
        }


        // Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var expense = _db.Expenses.Find(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        // Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var expense = _db.Expenses.Find(id);
            if(expense == null)
            {
                return NotFound();
            }
            _db.Expenses.Remove(expense);
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
            var expense = _db.Expenses.Find(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(expense);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);
        }

    }
}
