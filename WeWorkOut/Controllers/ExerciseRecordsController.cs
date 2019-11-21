using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeWorkOut.Models;
using WeWorkOut.Data;

namespace WeWorkOut.Controllers
{
    public class ExerciseRecordsController : Controller
    {
        private readonly DB _context;

        public ExerciseRecordsController(DB context)
        {
            _context = context;
        }

        // GET: ExerciseRecords
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExerciseRecord.ToListAsync());
        }

        // GET: ExerciseRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseRecord = await _context.ExerciseRecord
                .FirstOrDefaultAsync(m => m.ExerciseRecordID == id);
            if (exerciseRecord == null)
            {
                return NotFound();
            }

            return View(exerciseRecord);
        }

        // GET: ExerciseRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExerciseRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciseRecordID,ExcerciseID,SubmitDate")] ExerciseRecord exerciseRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exerciseRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exerciseRecord);
        }

        // GET: ExerciseRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseRecord = await _context.ExerciseRecord.FindAsync(id);
            if (exerciseRecord == null)
            {
                return NotFound();
            }
            return View(exerciseRecord);
        }

        // POST: ExerciseRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExerciseRecordID,ExcerciseID,SubmitDate")] ExerciseRecord exerciseRecord)
        {
            if (id != exerciseRecord.ExerciseRecordID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exerciseRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseRecordExists(exerciseRecord.ExerciseRecordID))
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
            return View(exerciseRecord);
        }

        // GET: ExerciseRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseRecord = await _context.ExerciseRecord
                .FirstOrDefaultAsync(m => m.ExerciseRecordID == id);
            if (exerciseRecord == null)
            {
                return NotFound();
            }

            return View(exerciseRecord);
        }

        // POST: ExerciseRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exerciseRecord = await _context.ExerciseRecord.FindAsync(id);
            _context.ExerciseRecord.Remove(exerciseRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseRecordExists(int id)
        {
            return _context.ExerciseRecord.Any(e => e.ExerciseRecordID == id);
        }
    }
}
