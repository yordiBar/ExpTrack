using ExpTrack.Data;
using ExpTrack.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense expense)
        {
            _db.Expenses.Add(expense);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
