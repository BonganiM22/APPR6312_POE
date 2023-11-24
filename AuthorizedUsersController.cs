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
    public class AuthorizedUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorizedUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AuthorizedUsers
        public async Task<IActionResult> Index()
        {
              return _context.AuthorizedUser != null ? 
                          View(await _context.AuthorizedUser.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AuthorizedUser'  is null.");
        }

        // GET: AuthorizedUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AuthorizedUser == null)
            {
                return NotFound();
            }

            var authorizedUser = await _context.AuthorizedUser
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (authorizedUser == null)
            {
                return NotFound();
            }

            return View(authorizedUser);
        }

        // GET: AuthorizedUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AuthorizedUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,Password")] AuthorizedUser authorizedUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorizedUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authorizedUser);
        }

        // GET: AuthorizedUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AuthorizedUser == null)
            {
                return NotFound();
            }

            var authorizedUser = await _context.AuthorizedUser.FindAsync(id);
            if (authorizedUser == null)
            {
                return NotFound();
            }
            return View(authorizedUser);
        }

        // POST: AuthorizedUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,Password")] AuthorizedUser authorizedUser)
        {
            if (id != authorizedUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorizedUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorizedUserExists(authorizedUser.UserId))
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
            return View(authorizedUser);
        }

        // GET: AuthorizedUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AuthorizedUser == null)
            {
                return NotFound();
            }

            var authorizedUser = await _context.AuthorizedUser
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (authorizedUser == null)
            {
                return NotFound();
            }

            return View(authorizedUser);
        }

        // POST: AuthorizedUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AuthorizedUser == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AuthorizedUser'  is null.");
            }
            var authorizedUser = await _context.AuthorizedUser.FindAsync(id);
            if (authorizedUser != null)
            {
                _context.AuthorizedUser.Remove(authorizedUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorizedUserExists(int id)
        {
          return (_context.AuthorizedUser?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
