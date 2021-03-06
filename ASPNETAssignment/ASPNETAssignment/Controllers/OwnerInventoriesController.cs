﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNETAssignment.Data;
using Microsoft.AspNetCore.Authorization;
using ASPNETAssignment.Models;

namespace ASPNETAssignment.Controllers
{
    [Authorize(Roles = "Owner")]
    public class OwnerInventoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OwnerInventoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OwnerInventories
        public async Task<IActionResult> Index()
        {
            var aSPNetAssignmentContext = _context.OwnerInventory.Include(o => o.Product);
            return View(await aSPNetAssignmentContext.ToListAsync());
        }

        // POST: OwnerInventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,StockLevel")] OwnerInventory ownerInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ownerInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", ownerInventory.ProductID);
            return View(ownerInventory);
        }

        // GET: OwnerInventories/Edit/5
        public async Task<IActionResult> SetStockLevel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ownerInventory = await _context.OwnerInventory.SingleOrDefaultAsync(m => m.ProductID == id);
            if (ownerInventory == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", ownerInventory.ProductID);
            return View(ownerInventory);
        }

        // POST: OwnerInventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,StockLevel")] OwnerInventory ownerInventory)
        {
            if (id != ownerInventory.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ownerInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerInventoryExists(ownerInventory.ProductID))
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
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductID", ownerInventory.ProductID);
            return View(ownerInventory);
        }

        private bool OwnerInventoryExists(int id)
        {
            return _context.OwnerInventory.Any(e => e.ProductID == id);
        }
    }
}
