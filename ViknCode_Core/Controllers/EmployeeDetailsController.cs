using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ViknCode_Core.Data;
using ViknCode_Core.Models;

namespace ViknCode_Core.Controllers
{
    public class EmployeeDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: EmployeeDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmployeeDetails.Include(e => e.designation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmployeeDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeeDetails == null)
            {
                return NotFound();
            }

            var employeeDetails = await _context.EmployeeDetails
                .Include(e => e.designation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDetails == null)
            {
                return NotFound();
            }

            return View(employeeDetails);
        }

        // GET: EmployeeDetails/Create
        public IActionResult Create()
        {
            ViewData["DesignationId"] = new SelectList(_context.Designation, "Id", "Name");
            return View();
        }

        // POST: EmployeeDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeName,Address,EmployeePhoneNumber,DesignationId")] EmployeeDetails employeeDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DesignationId"] = new SelectList(_context.Designation, "Id", "Name", employeeDetails.DesignationId);
            return View(employeeDetails);
        }

        // GET: EmployeeDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeeDetails == null)
            {
                return NotFound();
            }

            var employeeDetails = await _context.EmployeeDetails.FindAsync(id);
            if (employeeDetails == null)
            {
                return NotFound();
            }
            ViewData["DesignationId"] = new SelectList(_context.Designation, "Id", "Name", employeeDetails.DesignationId);
            return View(employeeDetails);
        }

        // POST: EmployeeDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeName,Address,EmployeePhoneNumber,DesignationId")] EmployeeDetails employeeDetails)
        {
            if (id != employeeDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDetailsExists(employeeDetails.Id))
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
            ViewData["DesignationId"] = new SelectList(_context.Designation, "Id", "Name", employeeDetails.DesignationId);
            return View(employeeDetails);
        }

        // GET: EmployeeDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployeeDetails == null)
            {
                return NotFound();
            }

            var employeeDetails = await _context.EmployeeDetails
                .Include(e => e.designation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDetails == null)
            {
                return NotFound();
            }

            return View(employeeDetails);
        }

        // POST: EmployeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeeDetails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EmployeeDetails'  is null.");
            }
            var employeeDetails = await _context.EmployeeDetails.FindAsync(id);
            if (employeeDetails != null)
            {
                _context.EmployeeDetails.Remove(employeeDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDetailsExists(int id)
        {
          return _context.EmployeeDetails.Any(e => e.Id == id);
        }
    }
}
