using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CFF_CRM.Models;
using Microsoft.AspNetCore.Authorization;

namespace CFF_CRM.Controllers
{
    [Authorize]
    public class SupplyRequestsController : Controller
    {
        private readonly CRMContext _context;

        public SupplyRequestsController(CRMContext context)
        {
            _context = context;
        }

        // GET: SupplyRequests
        public async Task<IActionResult> Index()
        {
            var cRMContext = _context.SupplyRequests.Include(s => s.orderItem).Include(s => s.status).Include(s => s.supplyRequestOrigin).Include(s => s.supplyRequestType).Include(s => s.User);
            return View(await cRMContext.ToListAsync());
        }

        // GET: SupplyRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplyRequest = await _context.SupplyRequests
                .Include(s => s.orderItem)
                .Include(s => s.status)
                .Include(s => s.supplyRequestOrigin)
                .Include(s => s.supplyRequestType)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SupplyRequestId == id);
            if (supplyRequest == null)
            {
                return NotFound();
            }

            return View(supplyRequest);
        }

        // GET: SupplyRequests/Create
        public IActionResult Create()
        {
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId");
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId");
            ViewData["SupplyRequestOriginId"] = new SelectList(_context.SupplyRequestOrigins, "SupplyRequestOriginId", "SupplyRequestOriginId");
            ViewData["SupplyRequestTypeId"] = new SelectList(_context.SupplyRequestTypes, "SupplyRequestTypeId", "SupplyRequestTypeId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: SupplyRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplyRequestId,StatusId,UserId,OrderItemId,SupplyRequestOriginId,SupplyRequestTypeId,ClientName,OwnerName,CreatedBy,CreatedTime")] SupplyRequest supplyRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplyRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId", supplyRequest.OrderItemId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", supplyRequest.StatusId);
            ViewData["SupplyRequestOriginId"] = new SelectList(_context.SupplyRequestOrigins, "SupplyRequestOriginId", "SupplyRequestOriginId", supplyRequest.SupplyRequestOriginId);
            ViewData["SupplyRequestTypeId"] = new SelectList(_context.SupplyRequestTypes, "SupplyRequestTypeId", "SupplyRequestTypeId", supplyRequest.SupplyRequestTypeId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", supplyRequest.UserId);
            return View(supplyRequest);
        }

        // GET: SupplyRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplyRequest = await _context.SupplyRequests.FindAsync(id);
            if (supplyRequest == null)
            {
                return NotFound();
            }
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId", supplyRequest.OrderItemId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", supplyRequest.StatusId);
            ViewData["SupplyRequestOriginId"] = new SelectList(_context.SupplyRequestOrigins, "SupplyRequestOriginId", "SupplyRequestOriginId", supplyRequest.SupplyRequestOriginId);
            ViewData["SupplyRequestTypeId"] = new SelectList(_context.SupplyRequestTypes, "SupplyRequestTypeId", "SupplyRequestTypeId", supplyRequest.SupplyRequestTypeId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", supplyRequest.UserId);
            return View(supplyRequest);
        }

        // POST: SupplyRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplyRequestId,StatusId,UserId,OrderItemId,SupplyRequestOriginId,SupplyRequestTypeId,ClientName,OwnerName,CreatedBy,CreatedTime")] SupplyRequest supplyRequest)
        {
            if (id != supplyRequest.SupplyRequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplyRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplyRequestExists(supplyRequest.SupplyRequestId))
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
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "OrderItemId", supplyRequest.OrderItemId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", supplyRequest.StatusId);
            ViewData["SupplyRequestOriginId"] = new SelectList(_context.SupplyRequestOrigins, "SupplyRequestOriginId", "SupplyRequestOriginId", supplyRequest.SupplyRequestOriginId);
            ViewData["SupplyRequestTypeId"] = new SelectList(_context.SupplyRequestTypes, "SupplyRequestTypeId", "SupplyRequestTypeId", supplyRequest.SupplyRequestTypeId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", supplyRequest.UserId);
            return View(supplyRequest);
        }

        // GET: SupplyRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplyRequest = await _context.SupplyRequests
                .Include(s => s.orderItem)
                .Include(s => s.status)
                .Include(s => s.supplyRequestOrigin)
                .Include(s => s.supplyRequestType)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SupplyRequestId == id);
            if (supplyRequest == null)
            {
                return NotFound();
            }

            return View(supplyRequest);
        }

        // POST: SupplyRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplyRequest = await _context.SupplyRequests.FindAsync(id);
            _context.SupplyRequests.Remove(supplyRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplyRequestExists(int id)
        {
            return _context.SupplyRequests.Any(e => e.SupplyRequestId == id);
        }
    }
}
