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
    public class TasksController : Controller
    {
        private readonly CRMContext _context;
        private UserManager<User> _userManager;
        public TasksController(CRMContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Tasks
        public async Task<IActionResult> Index(string? username)
        {
            //Only query from task that the user has created
            string userId = _userManager.GetUserId(HttpContext.User);
            var cRMContext = _context.Tasks.Include(t => t.priority).Include(t => t.related).Include(t => t.status).Include(t => t.taskType).Include(t => t.User).Where(t => t.UserId == userId);
            ViewBag.Result = username;
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
                .Include(t => t.User)
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
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "PriorityId", "Name");
            ViewData["RelatedId"] = new SelectList(_context.Related, "RelatedId", "Name");
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Name");
            ViewData["TaskTypeId"] = new SelectList(_context.TaskTypes, "TaskTypeId", "Name");


            ViewData["Owner"] = _context.Tasks.Select(t => t.Owner).Distinct().ToList();
            ViewData["Related"] = _context.Tasks.Select(t => t.RelatedName).Distinct().ToList();

            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,StatusId,UserId,Owner,RelatedId,RelatedName,TaskTypeId,PriorityId,CreatedBy,CreatedTime")] Models.Task task, Note note)
        {

            //Check user permission
            User user = await _userManager.GetUserAsync(HttpContext.User);

            //set user info
            task.UserId = user.Id;
            task.CreatedBy = user.UserName;
            task.CreatedTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();

                //save note if status equal to 2
                if (task.StatusId == 2 && note.Content != null)
                {
                    note.CreatedBy = user.UserName;
                    note.CreatedDate = DateTime.Now;
                    _context.Add(note);
                    await _context.SaveChangesAsync();
                    _context.TaskNotes.Add(new TaskNote { TaskId = task.TaskId, NoteId = note.NoteId });
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "PriorityId", "Name", task.PriorityId);
            ViewData["RelatedId"] = new SelectList(_context.Related, "RelatedId", "Name", task.RelatedId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Name", task.StatusId);
            ViewData["TaskTypeId"] = new SelectList(_context.TaskTypes, "TaskTypeId", "Name", task.TaskTypeId);

            ViewData["Owner"] = _context.Tasks.Select(t => t.Owner).Distinct().ToList();
            ViewData["Related"] = _context.Tasks.Select(t => t.RelatedName).Distinct().ToList();

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
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "PriorityId", "Name", task.PriorityId);
            ViewData["RelatedId"] = new SelectList(_context.Related, "RelatedId", "Name", task.RelatedId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Name", task.StatusId);
            ViewData["TaskTypeId"] = new SelectList(_context.TaskTypes, "TaskTypeId", "Name", task.TaskTypeId);

            ViewData["Owner"] = _context.Tasks.Select(t => t.Owner).Distinct().ToList();
            ViewData["Related"] = _context.Tasks.Select(t => t.RelatedName).Distinct().ToList();

            ViewBag.Notes = await _context.TaskNotes.Include(tn => tn.note).Where(tn => tn.TaskId == id).ToListAsync();
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,StatusId,UserId,Owner,RelatedId,RelatedName,TaskTypeId,PriorityId,CreatedBy,CreatedTime")] Models.Task task)
        {
            //Get Current user
            User user = await _userManager.GetUserAsync(HttpContext.User);
            if (id != task.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Add Update By current user
                    task.UpdateBy = user.UserName;
                    //Add Update Time
                    task.UpdateTime = DateTime.Now;
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
            ViewData["PriorityId"] = new SelectList(_context.Priorities, "PriorityId", "Name", task.PriorityId);
            ViewData["RelatedId"] = new SelectList(_context.Related, "RelatedId", "Name", task.RelatedId);
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Name", task.StatusId);
            ViewData["TaskTypeId"] = new SelectList(_context.TaskTypes, "TaskTypeId", "Name", task.TaskTypeId);

            ViewData["Owner"] = _context.Tasks.Select(t => t.Owner).Distinct().ToList();
            ViewData["Related"] = _context.Tasks.Select(t => t.RelatedName).Distinct().ToList();

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
                .Include(t => t.User)
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

        /*
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNoteFromEdit([FromRoute] int id, Note note)
        {
            var task = _context.Tasks.First(t => t.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }
            if (task.StatusId == 2 && note.Content != null)
            {
                User user = await _userManager.GetUserAsync(HttpContext.User);
                note.CreatedBy = user.UserName;
                note.CreatedDate = DateTime.Now;
                _context.Notes.Add(note);

                //save note
                await _context.SaveChangesAsync();

                //save change to Supply Request Note
                _context.TaskNotes.Add(new TaskNote { TaskId = task.TaskId, NoteId = note.NoteId });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Edit), new { ID = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public async Task<IActionResult> ChangeOwner(int id, string UserName)
        {
            //get user id from user name

            User newOwner = _userManager.Users.First(u => u.UserName == UserName);
            if (newOwner == null)
            {
                return NotFound();
            }
            //get supply request
            Models.Task task = _context.Tasks.First(t => t.TaskId == id);

            if (task == null)
            {
                return NotFound();
            }
            //update supply request
            task.UserId = newOwner.Id;
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { USERNAME = UserName });
        }

    }
}
