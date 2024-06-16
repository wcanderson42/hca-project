using HCAPatientPortalPOC.Models;
using HCAPatientPortalPOC.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace HCAPatientPortalPOC.Controllers;

public class ProvidersController : Controller
{
    private readonly PortalDbContext _context;

    public ProvidersController(PortalDbContext context)
    {
        _context = context;
    }

        // GET: Providers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Providers.ToListAsync());
        }

        // GET: Providers/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provider = await _context.Providers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

         // GET Providers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Providers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dictionary<string, string> dict)
        {
            try
            {
                Provider provider = Validator.ValidateProvider(dict);
                if (ModelState.IsValid)
                {
                    _context.Add(provider);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception e)
            {
                //TODO: route to error page
                Console.WriteLine(e.Message);
                
            }  
            return View();
        }

         // GET: Providers/Update/id
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provider = await _context.Providers.FindAsync(id);
            if (provider == null)
            {
                return NotFound();
            }
            return View(provider);
        }

        // POST: Providers/Update/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Dictionary<string, string> dict)
        {
            Provider provider;
            try
            {
                provider = Validator.ValidateProvider(dict);
            }
            catch(Exception e)
            {
                // TODO: route to error page
                Console.WriteLine(e.Message);
                return View();
            }
            if (id != provider.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProviderExists((int)provider.Id))
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
            return View();
        }

        private bool ProviderExists(int id)
        {
            return _context.Providers.Any(e => e.Id == id);
        }

        // GET: Providers/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provider = await _context.Providers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provider == null)
            {
                return NotFound();
            }

            return View(provider);
        }

        // POST: Providers/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var provider = await _context.Providers.FindAsync(id);
            if (provider != null)
            {
                _context.Providers.Remove(provider);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
}
