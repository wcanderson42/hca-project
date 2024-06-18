using System.IO.Compression;
using HCAPatientPortalPOC.Models;
using HCAPatientPortalPOC.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace HCAPatientPortalPOC.Controllers;

public class PatientsController : Controller
{
    private readonly PortalDbContext _context;

    public PatientsController(PortalDbContext context)
    {
        _context = context;
    }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patients.ToListAsync());
        }

        // GET: Patients/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient patient)
        {
            if(ModelState.IsValid){
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        // GET: Patients/Update/id
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patients/Update/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        // TODO: handle concurrency exception
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        private bool PatientExists(int? id)
        {
            if(id != null){
                return _context.Patients.Any(e => e.Id == id);
            }
            return false;
        }

        // GET: Patients/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
}
