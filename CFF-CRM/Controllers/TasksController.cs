using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CFF_CRM.Models;

namespace CFF_CRM.Controllers
{
    public class TasksController : Controller
    {
        private readonly CRMContext _context;

        public TasksController(CRMContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var cRMContext = _context.Tasks.Include(t => t.priority).Include(t => t.related).Include(t => t.status).Include(t => t.taskType).Include(t => t.user);
            return View(await cRMContext.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.priority)
                .Include(t => t.related)
                .Include(t => t.status)
                .Include(t => t.taskType)
                .Include(t => t.user)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "PriorityId", "PriorityId");
            ViewData["RelatedId"] = new SelectList(_context.Related, "RelatedId", "RelatedId");
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId");
            ViewData["TaskTypeId"] = new SelectList(_context.TaskTypes, "TaskTypeId", "TaskTypeId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,StatusId,UserId,Owner,RelatedId,RelatedName,TaskTypeId,PriorityId,CreatedBy,CreatedTime")] Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "PriorityId", "PriorityId", task.PriorityId);
            ViewData["RelatedId"] = new SelectList(_context.Related, "RelatedId", "RelatedId", task.RelatedId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", task.StatusId);
            ViewData["TaskTypeId"] = new SelectList(_context.TaskTypes, "TaskTypeId", "TaskTypeId", task.TaskTypeId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", task.UserId);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "PriorityId", "PriorityId", task.PriorityId);
            ViewData["RelatedId"] = new SelectList(_context.Related, "RelatedId", "RelatedId", task.RelatedId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", task.StatusId);
            ViewData["TaskTypeId"] = new SelectList(_context.TaskTypes, "TaskTypeId", "TaskTypeId", task.TaskTypeId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", task.UserId);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,StatusId,UserId,Owner,RelatedId,RelatedName,TaskTypeId,PriorityId,CreatedBy,CreatedTime")] Models.Task task)
        {
            if (id != task.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.TaskId))
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
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "PriorityId", "PriorityId", task.PriorityId);
            ViewData["RelatedId"] = new SelectList(_context.Related, "RelatedId", "RelatedId", task.RelatedId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", task.StatusId);
            ViewData["TaskTypeId"] = new SelectList(_context.TaskTypes, "TaskTypeId", "TaskTypeId", task.TaskTypeId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", task.UserId);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.priority)
                .Include(t => t.related)
                .Include(t => t.status)
                .Include(t => t.taskType)
                .Include(t => t.user)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.TaskId == id);
        }
    }
}
