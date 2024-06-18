using HCAPatientPortalPOC.Models;
using HCAPatientPortalPOC.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HCAPatientPortalPOC.Controllers;

public class ScheduleSlotsController : Controller
{
    private readonly PortalDbContext _context;

    public ScheduleSlotsController(PortalDbContext context)
    {
        _context = context;
    }

        // GET: ScheduleSlots
        public async Task<IActionResult> Index()
        {
            return View(await _context.ScheduleSlots
                .OrderBy(x => x.ProviderId)
                .ThenBy(x => x.StartTime)
                .ToListAsync());
        }

        // GET: ScheduleSlots/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.ScheduleSlots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slot == null)
            {
                return NotFound();
            }

            return View(slot);
        }

        // GET ScheduleSlots/Create
        public async Task<IActionResult> Create()
        {
            List<Provider> providers = await _context.Providers.ToListAsync();
            ViewData["Providers"] = providers;
            return View();
        }

        // POST: ScheduleSlots/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScheduleSlot slot)
        {
            if(ModelState.IsValid)
            {
                _context.Add(slot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            List<Provider> providers = await _context.Providers.ToListAsync();
            ViewData["Providers"] = providers;
            return View();
        }

        // GET: ScheduleSlot/Update/id
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.ScheduleSlots.FindAsync(id);
            if (slot == null)
            {
                return NotFound();
            }
            List<Provider> providers = await _context.Providers.ToListAsync();
            ViewData["Providers"] = providers;
            return View(slot);
        }

        // POST: ScheduleSlot/Update/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ScheduleSlot slot)
        {
            if (id != slot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleSlotExists(slot.Id))
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
            List<Provider> providers = await _context.Providers.ToListAsync();
            ViewData["Providers"] = providers;
            return View();
        }

        private bool ScheduleSlotExists(int? id)
        {
            if(id != null ){
               return _context.ScheduleSlots.Any(e => e.Id == id); 
            }
            return false;
        }

        // GET: ScheduleSlots/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slot = await _context.ScheduleSlots.FindAsync(id);

            if (slot == null)
            {
                return NotFound();
            }

            return View(slot);
        }

        // POST: Providers/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slot = await _context.ScheduleSlots.FindAsync(id);
            if (slot != null)
            {
                _context.ScheduleSlots.Remove(slot);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
}
