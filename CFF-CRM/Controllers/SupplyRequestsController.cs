using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CFF_CRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CFF_CRM.Controllers
{
    [Authorize]
    public class SupplyRequestsController : Controller
    {
        private UserManager<User> _userManager;
        private readonly CRMContext _context;

        public SupplyRequestsController(CRMContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: SupplyRequests
        public async Task<IActionResult> Index(string? username)
        {
            //Only query from task that the user has created
            string userId = _userManager.GetUserId(HttpContext.User);
            var cRMContext = _context.SupplyRequests.Include(s => s.orderItem).Include(s => s.status).Include(s => s.supplyRequestOrigin).Include(s => s.supplyRequestType).Include(s => s.User).Where(s => s.UserId == userId);
            ViewBag.Result = username;
            return View(await cRMContext.ToListAsync());
        }

        public async Task<IActionResult> ListCurrent(string username)
        {
            //Only query from task that the user has created
            string userId = _userManager.GetUserId(HttpContext.User);
            var currentRequests = _context.SupplyRequests.Include(s => s.orderItem).Include(s => s.status).Include(s => s.supplyRequestOrigin).Include(s => s.supplyRequestType).Include(s => s.User).Where(s => s.UserId == userId).Take(10);
            ViewBag.Result = username;
            ViewBag.Action = "ListCurrent";
            return View("Index", await currentRequests.ToListAsync());
            //return View(await currentRequests.ToListAsync());
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
        [Authorize(Roles = "Admin, User")]
        public IActionResult Create()
        {
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "Name");
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Name");
            ViewData["SupplyRequestOriginId"] = new SelectList(_context.SupplyRequestOrigins, "SupplyRequestOriginId", "Name");
            ViewData["SupplyRequestTypeId"] = new SelectList(_context.SupplyRequestTypes, "SupplyRequestTypeId", "Name");

            ViewData["Owner"] = _context.SupplyRequests.Select(s => s.OwnerName).Distinct().ToList();
            ViewData["Client"] = _context.SupplyRequests.Select(s => s.ClientName).Distinct().ToList();

            return View();
        }

        // POST: SupplyRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Create([Bind("SupplyRequestId,StatusId,UserId,OrderItemId,SupplyRequestOriginId,SupplyRequestTypeId,ClientName,OwnerName,CreatedBy,CreatedTime,UpdateBy,UpdateTime")] SupplyRequest supplyRequest, Note note)
        {

            //Check user permission
            User user = await _userManager.GetUserAsync(HttpContext.User);
            //set value to supply request
            supplyRequest.UserId = user.Id;

            supplyRequest.CreatedBy = user.UserName; //Get from user
            supplyRequest.CreatedTime = DateTime.Now; //default
            if (ModelState.IsValid)
            {

                //add supply request to db
                _context.Add(supplyRequest);
                await _context.SaveChangesAsync();

                //Add note to db
                if (supplyRequest.StatusId == 2 && note.Content != null)
                {
                    note.CreatedBy = user.UserName;
                    note.CreatedDate = DateTime.Now;
                    _context.Add(note);
                    await _context.SaveChangesAsync();
                    _context.Add(new SupplyRequestNote { SupplyRequestId = supplyRequest.SupplyRequestId, NoteId = note.NoteId });
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "Name", supplyRequest.OrderItemId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Name", supplyRequest.StatusId);
            ViewData["SupplyRequestOriginId"] = new SelectList(_context.SupplyRequestOrigins, "SupplyRequestOriginId", "Name", supplyRequest.SupplyRequestOriginId);
            ViewData["SupplyRequestTypeId"] = new SelectList(_context.SupplyRequestTypes, "SupplyRequestTypeId", "Name", supplyRequest.SupplyRequestTypeId);

            ViewData["Owner"] = _context.SupplyRequests.Select(s => s.OwnerName).Distinct().ToList();
            ViewData["Client"] = _context.SupplyRequests.Select(s => s.ClientName).Distinct().ToList();

            return View(supplyRequest);
        }

        // GET: SupplyRequests/Edit/5
        [Authorize(Roles = "Admin, User")]
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
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "Name", supplyRequest.OrderItemId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Name", supplyRequest.StatusId);
            ViewData["SupplyRequestOriginId"] = new SelectList(_context.SupplyRequestOrigins, "SupplyRequestOriginId", "Name", supplyRequest.SupplyRequestOriginId);
            ViewData["SupplyRequestTypeId"] = new SelectList(_context.SupplyRequestTypes, "SupplyRequestTypeId", "Name", supplyRequest.SupplyRequestTypeId);

            ViewData["Owner"] = _context.SupplyRequests.Select(s => s.OwnerName).Distinct().ToList();
            ViewData["Client"] = _context.SupplyRequests.Select(s => s.ClientName).Distinct().ToList();

            //View bage for note
            ViewBag.Notes = await _context.SupplyRequestNotes.Include(sn => sn.note).Where(sn => sn.SupplyRequestId == id).ToListAsync();
            return View(supplyRequest);
        }

        // POST: SupplyRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> Edit(int id, [Bind("SupplyRequestId,StatusId,UserId,OrderItemId,SupplyRequestOriginId,SupplyRequestTypeId,ClientName,OwnerName,CreatedBy,CreatedTime,UpdateBy,UpdateTime")] SupplyRequest supplyRequest)
        {
            //Get Current user
            User user = await _userManager.GetUserAsync(HttpContext.User);
            //Check supply request id
            if (id != supplyRequest.SupplyRequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Add Update By current user
                    supplyRequest.UpdateBy = user.UserName;
                    //Add Update Time
                    supplyRequest.UpdateTime = DateTime.Now;
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
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "Name", supplyRequest.OrderItemId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Name", supplyRequest.StatusId);
            ViewData["SupplyRequestOriginId"] = new SelectList(_context.SupplyRequestOrigins, "SupplyRequestOriginId", "Name", supplyRequest.SupplyRequestOriginId);
            ViewData["SupplyRequestTypeId"] = new SelectList(_context.SupplyRequestTypes, "SupplyRequestTypeId", "Name", supplyRequest.SupplyRequestTypeId);

            ViewData["Owner"] = _context.SupplyRequests.Select(s => s.OwnerName).Distinct().ToList();
            ViewData["Client"] = _context.SupplyRequests.Select(s => s.ClientName).Distinct().ToList();

            //View bage for note
            ViewBag.Notes = await _context.SupplyRequestNotes.Include(sn => sn.note).Where(sn => sn.SupplyRequestId == id).ToListAsync();
            return View(supplyRequest);
        }

        // GET: SupplyRequests/Delete/5
        [Authorize(Roles = "Admin, User")]
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
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplyRequest = await _context.SupplyRequests.FindAsync(id);
            _context.SupplyRequests.Remove(supplyRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> CreateNoteFromEdit([FromRoute] int id, Note note)
        {
            var supplyRequest = _context.SupplyRequests.First(s => s.SupplyRequestId == id);
            if (supplyRequest == null)
            {
                return NotFound();
            }
            if (supplyRequest.StatusId == 2 && note.Content != null)
            {
                User user = await _userManager.GetUserAsync(HttpContext.User);
                note.CreatedBy = user.UserName;
                note.CreatedDate = DateTime.Now;
                _context.Notes.Add(note);

                //save note
                await _context.SaveChangesAsync();

                //save change to Supply Request Note
                _context.SupplyRequestNotes.Add(new SupplyRequestNote { SupplyRequestId = supplyRequest.SupplyRequestId, NoteId = note.NoteId});
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Edit), new { ID = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> ArchiveNote(int id, Note noteinput)
        {
            Note note = await _context.Notes.FirstAsync(n => n.NoteId == noteinput.NoteId);
            if (note == null)
            {
                return NotFound();
            }
            note.Archived = true;
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Edit), new { ID = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> ChangeOwner(int id, string UserName)
        {
            //get user id from user name

            User newOwner = _userManager.Users.First(u => u.UserName == UserName);
            if (newOwner == null)
            {
                return NotFound();
            }
            //get supply request
            SupplyRequest supplyRequest = _context.SupplyRequests.First(s => s.SupplyRequestId == id);
            
            if (supplyRequest == null)
            {
                return NotFound();
            }
            //update supply request
            supplyRequest.UserId = newOwner.Id;
            _context.SupplyRequests.Update(supplyRequest);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { USERNAME = UserName });
        }


        private bool SupplyRequestExists(int id)
        {
            return _context.SupplyRequests.Any(e => e.SupplyRequestId == id);
        }
    }
}
