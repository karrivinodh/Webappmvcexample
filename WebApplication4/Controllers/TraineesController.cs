using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.DBContext;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class TraineesController : Controller
    {
        private readonly traineeContext _context;

        public TraineesController(traineeContext context)
        {
            _context = context;
        }

        // GET: Trainees
        public async Task<IActionResult> Index()
        {
              return View(await _context.trainees.ToListAsync());
        }

        // GET: Trainees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.trainees == null)
            {
                return NotFound();
            }

            var trainee = await _context.trainees
                .FirstOrDefaultAsync(m => m.traineeid == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // GET: Trainees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trainees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("traineeid,name,salary,city,joiningdate,creditcard,Email,password,phoneNumber")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainee);
        }

        // GET: Trainees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.trainees == null)
            {
                return NotFound();
            }

            var trainee = await _context.trainees.FindAsync(id);
            if (trainee == null)
            {
                return NotFound();
            }
            return View(trainee);
        }

        // POST: Trainees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("traineeid,name,salary,city,joiningdate,creditcard,Email,password,phoneNumber")] Trainee trainee)
        {
            if (id != trainee.traineeid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeExists(trainee.traineeid))
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
            return View(trainee);
        }

        // GET: Trainees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.trainees == null)
            {
                return NotFound();
            }

            var trainee = await _context.trainees
                .FirstOrDefaultAsync(m => m.traineeid == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // POST: Trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.trainees == null)
            {
                return Problem("Entity set 'traineeContext.trainees'  is null.");
            }
            var trainee = await _context.trainees.FindAsync(id);
            if (trainee != null)
            {
                _context.trainees.Remove(trainee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TraineeExists(int id)
        {
          return _context.trainees.Any(e => e.traineeid == id);
        }
    }
}
