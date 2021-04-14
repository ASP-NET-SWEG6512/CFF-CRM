﻿using System;
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
    //[Authorize]
    public class SupplyRequestsController : Controller
    {
        private UserManager<User> userManager;
        private readonly CRMContext _context;

        public SupplyRequestsController(CRMContext context)
        {
            _context = context;
        }

        // GET: SupplyRequests
        public async Task<IActionResult> Index()
        {
            //Check user permission

            string userId = "";
            if (!getAccess("SupplyRequest", "read", userId))
            {
                return RedirectToAction("Index","Home");
            }
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
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "Name");
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Name");
            ViewData["SupplyRequestOriginId"] = new SelectList(_context.SupplyRequestOrigins, "SupplyRequestOriginId", "Name");
            ViewData["SupplyRequestTypeId"] = new SelectList(_context.SupplyRequestTypes, "SupplyRequestTypeId", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: SupplyRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplyRequestId,StatusId,UserId,OrderItemId,SupplyRequestOriginId,SupplyRequestTypeId,ClientName,OwnerName,CreatedBy,CreatedTime,UpdateBy,UpdateTime")] SupplyRequest supplyRequest, Note note)
        {

            //Check user permission
            string userId = "";
            if (!getAccess("SupplyRequest", "write", userId))
            {
                return RedirectToAction(nameof(Index));
            }

            supplyRequest.CreatedBy = "Prathna Pel"; //Get from user
            supplyRequest.CreatedTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(supplyRequest);
                
                await _context.SaveChangesAsync();
                //Add note to db
                if (supplyRequest.StatusId == 2)
                {
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
            ViewData["OrderItemId"] = new SelectList(_context.OrderItems, "OrderItemId", "Name", supplyRequest.OrderItemId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Name", supplyRequest.StatusId);
            ViewData["SupplyRequestOriginId"] = new SelectList(_context.SupplyRequestOrigins, "SupplyRequestOriginId", "Name", supplyRequest.SupplyRequestOriginId);
            ViewData["SupplyRequestTypeId"] = new SelectList(_context.SupplyRequestTypes, "SupplyRequestTypeId", "Name", supplyRequest.SupplyRequestTypeId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", supplyRequest.UserId);
            //View bage for note
            ViewBag.Notes = await _context.SupplyRequestNotes.Include(sn => sn.note).Where(sn => sn.SupplyRequestId == id).ToListAsync();
            return View(supplyRequest);
        }

        // POST: SupplyRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplyRequestId,StatusId,UserId,OrderItemId,SupplyRequestOriginId,SupplyRequestTypeId,ClientName,OwnerName,CreatedBy,CreatedTime,UpdateBy,UpdateTime")] SupplyRequest supplyRequest, Note note)
        {
            //Check user permission
            string userId = "";
            if (!getAccess("SupplyRequest", "write", userId))
            {
                return RedirectToAction(nameof(Index));
            }
            //Check id
            if (id != supplyRequest.SupplyRequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Add Update By
                    supplyRequest.UpdateBy = "Remove It";
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", supplyRequest.UserId);
            //View bage for note
            ViewBag.Notes = await _context.SupplyRequestNotes.Include(sn => sn.note).Where(sn => sn.SupplyRequestId == id).ToListAsync();
            return View(supplyRequest);
        }

        // GET: SupplyRequests/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var supplyRequest = await _context.SupplyRequests
        //        .Include(s => s.orderItem)
        //        .Include(s => s.status)
        //        .Include(s => s.supplyRequestOrigin)
        //        .Include(s => s.supplyRequestType)
        //        .Include(s => s.User)
        //        .FirstOrDefaultAsync(m => m.SupplyRequestId == id);
        //    if (supplyRequest == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(supplyRequest);
        //}

        //// POST: SupplyRequests/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var supplyRequest = await _context.SupplyRequests.FindAsync(id);
        //    _context.SupplyRequests.Remove(supplyRequest);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool SupplyRequestExists(int id)
        {
            return _context.SupplyRequests.Any(e => e.SupplyRequestId == id);
        }

        private bool getAccess(string page, string action, string userID)
        {
            bool access = false;
            ////find user permission
            //int permission = _context.Users.Where(u => u.Id == userID).Select(u => u.PermissionId).First();
            ////Get all user permission
            //var AllPermission = _context.PermissionRelations.Where(p => p.PermissionId == permission).Include(p => p.PermissionGroupPolicyId);
            ////action includes read,write,archive,ArchiveForOwner
            ////either Task, SupplyRequest, or Admin
            //string permissionName = _context.Permissions.Where(p => p.PermissionId == permission).Select(p => p.Name).FirstOrDefault();
            //switch (permissionName)
            //{
            //    case "Administrator":
            //        access = true;
            //        break;
            //    case "Visitor":
            //        if (action == "read")
            //        {
            //            access = true;
            //        }
            //        break;
            //    case "User":
            //        if (page == "SupplyRequest" || page == "Task")
            //        {
            //            access = true;
            //        }
            //        break;
            //    default:
            //        access = AllPermission.Any(p => p.PermissionGroupPolicy.Page == page && p.PermissionGroupPolicy.Action == action);
            //        break;
            //}
            return !access;
        }
    }
}
