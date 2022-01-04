#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MistyHollowWoodsInventory.Data;
using MistyHollowWoodsInventory.Models;

namespace MistyHollowWoodsInventory.Controllers
{
    public class BowlsController : Controller
    {
        private readonly misty_hollowContext _context;

        public BowlsController(misty_hollowContext context)
        {
            _context = context;
        }

        // GET: Bowls
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bowls.ToListAsync());
        }

        // GET: Bowls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowl = await _context.Bowls
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bowl == null)
            {
                return NotFound();
            }
            return View(bowl);
        }

        // GET: Bowls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bowls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,WoodSpecies,BowlType,Price,Sold")] Bowls bowls)
        {
            if (ModelState.IsValid)
            {
                bowls.Image = GetImageBytesFromFile(Request.Form.Files);
                _context.Add(bowls);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bowls);
        }

        // GET: Bowls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowl = await _context.Bowls.FindAsync(id);
            if (bowl == null)
            {
                return NotFound();
            }

            return View(bowl);
        }

        // POST: Bowls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,WoodSpecies,BowlType,Price,Sold")] Bowls bowls)
        {
            if (id != bowls.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Request.Form.Files.Count > 0)
                    {
                        bowls.Image = GetImageBytesFromFile(Request.Form.Files);
                    }
                    _context.Update(bowls);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BowlsExists(bowls.ID))
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
            return View(bowls);
        }

        // GET: Bowls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowls = await _context.Bowls
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bowls == null)
            {
                return NotFound();
            }

            return View(bowls);
        }

        // POST: Bowls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bowls = await _context.Bowls.FindAsync(id);
            _context.Bowls.Remove(bowls);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BowlsExists(int id)
        {
            return _context.Bowls.Any(e => e.ID == id);
        }

        private byte[]? GetImageBytesFromFile(IFormFileCollection files)
        {
            Console.WriteLine(files.Count.ToString());
            if (files.Count > 0)
            {
                var file = files[0];
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                byte[] image = ms.ToArray();

                ms.Close();
                ms.Dispose();
                return image;
            }
            return null;
        }
    }
}
