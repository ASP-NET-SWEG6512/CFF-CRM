using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFF_CRM.Controllers
{
    public class SupplyRequestController : Controller
    {
        // GET: SupplyRequestController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SupplyRequestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SupplyRequestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplyRequestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplyRequestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SupplyRequestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplyRequestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupplyRequestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
