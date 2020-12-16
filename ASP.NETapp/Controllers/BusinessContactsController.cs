using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NETapp.Data;
using ASP.NETapp.Models;

namespace ASP.NETapp.Controllers
{
    public class BusinessContactsController : Controller
    {
        private readonly AspNetAppDbContext _context;

        public BusinessContactsController(AspNetAppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// displays business contact list
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.BusinessContacts.ToListAsync());
        }

        /// <summary>
        /// displays business contact details based on the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessContact = await _context.BusinessContacts
                .FirstOrDefaultAsync(m => m.BusinessContactId == id);
            if (businessContact == null)
            {
                return NotFound();
            }

            return View(businessContact);
        }

        /// <summary>
        /// displays the create new business contact form
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// store new personal contact in database
        /// </summary>
        /// <param name="businessContact"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusinessContactId,BusinessFirstName,BusinessLastName,BusinessEmail,BusinessPhoneNumber,BusinessAddressLine1,BusinessAddressLine2,BusinessPostcode,BusinessCountry,BusinessCompany")] BusinessContact businessContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessContact);
        }

        /// <summary>
        /// displays the edit business contact form
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessContact = await _context.BusinessContacts.FindAsync(id);
            if (businessContact == null)
            {
                return NotFound();
            }
            return View(businessContact);
        }

        // POST: BusinessContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// edit and store business contact in database based on id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="businessContact"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusinessContactId,BusinessFirstName,BusinessLastName,BusinessEmail,BusinessPhoneNumber,BusinessAddressLine1,BusinessAddressLine2,BusinessPostcode,BusinessCountry,BusinessCompany")] BusinessContact businessContact)
        {
            if (id != businessContact.BusinessContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessContactExists(businessContact.BusinessContactId))
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
            return View(businessContact);
        }

        /// <summary>
        /// displays the delete business contact form
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessContact = await _context.BusinessContacts
                .FirstOrDefaultAsync(m => m.BusinessContactId == id);
            if (businessContact == null)
            {
                return NotFound();
            }

            return View(businessContact);
        }

        /// <summary>
        /// deletes business contact from the database based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var businessContact = await _context.BusinessContacts.FindAsync(id);
            _context.BusinessContacts.Remove(businessContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessContactExists(int id)
        {
            return _context.BusinessContacts.Any(e => e.BusinessContactId == id);
        }
    }
}
