using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreTShirtStore.Data;
using CoreTShirtStore.Models;
using CoreTShirtStore.Repositories;

namespace CoreTShirtStore.Controllers
{
    public class TShirtsController : Controller
    {
        //private readonly TShirtContext _context;
        private readonly IRepository<TShirt> _TShirtRepository;

        public TShirtsController(IRepository<TShirt> tShirtRepository)
        {
            //_context = context;
            _TShirtRepository = tShirtRepository;
        }

        // GET: TShirts
        public async Task<IActionResult> Index()
        {
            //return View(await _context.TShirts.ToListAsync());
            return View(await _TShirtRepository.GetFullListAsync());
        }

        // GET: TShirts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tShirt = await _TShirtRepository.GetItemAsync(id);

            if (tShirt == null)
            {
                return NotFound();
            }

            return View(tShirt);
        }

        // GET: TShirts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TShirts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Size,Color,isTightFit,message")] TShirt tShirt)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(tShirt);
                _TShirtRepository.Add(tShirt);
                //await _context.SaveChangesAsync();
                await _TShirtRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tShirt);
        }

        // GET: TShirts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var tShirt = await _context.TShirts.FindAsync(id);
            var tShirt = await _TShirtRepository.FindAsync(id);
            if (tShirt == null)
            {
                return NotFound();
            }
            return View(tShirt);
        }

        // POST: TShirts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Size,Color,isTightFit,message")] TShirt tShirt)
        {
            if (id != tShirt.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(tShirt);
                    _TShirtRepository.Update(tShirt);

                    //await _context.SaveChangesAsync();

                    await _TShirtRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TShirtExists(tShirt.ID))
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
            return View(tShirt);
        }

        // GET: TShirts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var tShirt = await _context.TShirts
            //    .FirstOrDefaultAsync(m => m.ID == id);

            var tShirt = await _TShirtRepository.FindAsync(id);

            if (tShirt == null)
            {
                return NotFound();
            }

            return View(tShirt);
        }

        // POST: TShirts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var tShirt = await _context.TShirt.FindAsync(id);
            //_context.Remove(tShirt);
            //await _context.SaveChangesAsync();

            await _TShirtRepository.DeleteConfirmed(id);

            return RedirectToAction(nameof(Index));
        }

        private bool TShirtExists(int id)
        {
            //return _context.TShirts.Any(e => e.ID == id);
            return _TShirtRepository.CheckTShirtExists(id);
        }
    } 
}
