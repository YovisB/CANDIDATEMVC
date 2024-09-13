using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCANDIDATE.Models;

namespace MVCCANDIDATE.Controllers
{
    public class CandidateexperiencesController : Controller
    {
        private readonly MvccandidateContext _context;

        public CandidateexperiencesController(MvccandidateContext context)
        {
            _context = context;
        }

        // GET: Candidateexperiences
        public async Task<IActionResult> Index()
        {
            var mvccandidateContext = _context.Candidateexperiences.Include(c => c.IdCandidateNavigation);
            return View(await mvccandidateContext.ToListAsync());
        }

        // GET: Candidateexperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateexperience = await _context.Candidateexperiences
                .Include(c => c.IdCandidateNavigation)
                .FirstOrDefaultAsync(m => m.IdCandidateExperience == id);
            if (candidateexperience == null)
            {
                return NotFound();
            }

            return View(candidateexperience);
        }

        // GET: Candidateexperiences/Create
        public IActionResult Create()
        {
            ViewData["IdCandidate"] = new SelectList(_context.Candidates, "Idcandidate", "Idcandidate");
            return View();
        }

        // POST: Candidateexperiences/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCandidateExperience,IdCandidate,Company,Job,Description,Salary,BeginDate,EndDate,InsertDate,ModifyDate")] Candidateexperience candidateexperience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidateexperience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCandidate"] = new SelectList(_context.Candidates, "Idcandidate", "Idcandidate", candidateexperience.IdCandidate);
            return View(candidateexperience);
        }

        // GET: Candidateexperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Console.WriteLine(id);

            var candidateexperience = await _context.Candidateexperiences.FindAsync(id);
            if (candidateexperience == null)
            {
                return NotFound();
            }
            ViewData["IdCandidate"] = new SelectList(_context.Candidates, "Idcandidate", "Idcandidate", candidateexperience.IdCandidate);
            return View(candidateexperience);
        }

        // POST: Candidateexperiences/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCandidateExperience,IdCandidate,Company,Job,Description,Salary,BeginDate,EndDate,InsertDate,ModifyDate")] Candidateexperience candidateexperience)
        {
            if (id != candidateexperience.IdCandidateExperience)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidateexperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateexperienceExists(candidateexperience.IdCandidateExperience))
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
            ViewData["IdCandidate"] = new SelectList(_context.Candidates, "Idcandidate", "Idcandidate", candidateexperience.IdCandidate);
            return View(candidateexperience);
        }

        // GET: Candidateexperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateexperience = await _context.Candidateexperiences
                .Include(c => c.IdCandidateNavigation)
                .FirstOrDefaultAsync(m => m.IdCandidateExperience == id);
            if (candidateexperience == null)
            {
                return NotFound();
            }

            return View(candidateexperience);
        }

        // POST: Candidateexperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidateexperience = await _context.Candidateexperiences.FindAsync(id);
            if (candidateexperience != null)
            {
                _context.Candidateexperiences.Remove(candidateexperience);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateexperienceExists(int id)
        {
            return _context.Candidateexperiences.Any(e => e.IdCandidateExperience == id);
        }
    }
}
