using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneyOrg.Client.Shared;
using MoneyOrg.Server;

namespace MoneyOrg.Server.Controllers
{
    public class IncExpsController : Controller
    {
        private readonly MoneyOrgDbContext _context;

        public IncExpsController(MoneyOrgDbContext context)
        {
            _context = context;
        }

        // GET: IncExps
        public async Task<IActionResult> Index()
        {
              return _context.IncomeExpense != null ? 
                          View(await _context.IncomeExpense.ToListAsync()) :
                          Problem("Entity set 'MoneyOrgDbContext.IncomeExpense'  is null.");
        }

        // GET: IncExps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.IncomeExpense == null)
            {
                return NotFound();
            }

            var incExp = await _context.IncomeExpense
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incExp == null)
            {
                return NotFound();
            }

            return View(incExp);
        }

        // GET: IncExps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IncExps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,SubType,Amount,Balance,PrevBalance,Time")] IncExp incExp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incExp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incExp);
        }

        // GET: IncExps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.IncomeExpense == null)
            {
                return NotFound();
            }

            var incExp = await _context.IncomeExpense.FindAsync(id);
            if (incExp == null)
            {
                return NotFound();
            }
            return View(incExp);
        }

        // POST: IncExps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,SubType,Amount,Balance,PrevBalance,Time")] IncExp incExp)
        {
            if (id != incExp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incExp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncExpExists(incExp.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(incExp);
        }

        // GET: IncExps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.IncomeExpense == null)
            {
                return NotFound();
            }

            var incExp = await _context.IncomeExpense
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incExp == null)
            {
                return NotFound();
            }

            return View(incExp);
        }

        // POST: IncExps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.IncomeExpense == null)
            {
                return Problem("Entity set 'MoneyOrgDbContext.IncomeExpense'  is null.");
            }
            var incExp = await _context.IncomeExpense.FindAsync(id);
            if (incExp != null)
            {
                _context.IncomeExpense.Remove(incExp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncExpExists(int id)
        {
          return (_context.IncomeExpense?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
