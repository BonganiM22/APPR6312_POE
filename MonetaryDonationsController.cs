using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APPR6312_ST10104738_POE.Data;
using APPR6312_ST10104738_POE.Models;
using Microsoft.AspNetCore.Authorization;

namespace APPR6312_ST10104738_POE.Controllers
{
    [Authorize]
    public class MonetaryDonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonetaryDonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MonetaryDonations
        public async Task<IActionResult> Index()
        {
              return _context.MonetaryDonations != null ? 
                          View(await _context.MonetaryDonations.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MonetaryDonation'  is null.");
        }

        // GET: MonetaryDonations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MonetaryDonations == null)
            {
                return NotFound();
            }

            var monetaryDonation = await _context.MonetaryDonations
                .FirstOrDefaultAsync(m => m.MoneyId == id);
            if (monetaryDonation == null)
            {
                return NotFound();
            }

            return View(monetaryDonation);
        }

        // GET: MonetaryDonations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MonetaryDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MoneyId,MoneyDonatorName,Amount,MoneyDonationDate")] MonetaryDonation monetaryDonation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monetaryDonation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monetaryDonation);
        }

        // GET: MonetaryDonations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MonetaryDonations == null)
            {
                return NotFound();
            }

            var monetaryDonation = await _context.MonetaryDonations.FindAsync(id);
            if (monetaryDonation == null)
            {
                return NotFound();
            }
            return View(monetaryDonation);
        }

        // POST: MonetaryDonations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MoneyId,MoneyDonatorName,Amount,MoneyDonationDate")] MonetaryDonation monetaryDonation)
        {
            if (id != monetaryDonation.MoneyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monetaryDonation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonetaryDonationExists(monetaryDonation.MoneyId))
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
            return View(monetaryDonation);
        }

        // GET: MonetaryDonations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MonetaryDonations == null)
            {
                return NotFound();
            }

            var monetaryDonation = await _context.MonetaryDonations
                .FirstOrDefaultAsync(m => m.MoneyId == id);
            if (monetaryDonation == null)
            {
                return NotFound();
            }

            return View(monetaryDonation);
        }

        // POST: MonetaryDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MonetaryDonations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MonetaryDonation'  is null.");
            }
            var monetaryDonation = await _context.MonetaryDonations.FindAsync(id);
            if (monetaryDonation != null)
            {
                _context.MonetaryDonations.Remove(monetaryDonation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonetaryDonationExists(int id)
        {
          return (_context.MonetaryDonations?.Any(e => e.MoneyId == id)).GetValueOrDefault();
        }
    }
}
