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
    public class PersonalContactsController : Controller
    {
        private readonly AspNetAppDbContext _context;

        public PersonalContactsController(AspNetAppDbContext context)
        {
            _context = context;
        }

        // GET: PersonalContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalContacts.ToListAsync());
        }

        // GET: PersonalContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalContact = await _context.PersonalContacts
                .FirstOrDefaultAsync(m => m.PersonalContactId == id);
            if (personalContact == null)
            {
                return NotFound();
            }

            return View(personalContact);
        }

        // GET: PersonalContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalContactId,PersonalFirstName,PersonalLastName,PersonalEmail,PersonalPhoneNumber,PersonalAddressLine1,PersonalAddressLine2,PersonalPostcode,PersonalCountry")] PersonalContact personalContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalContact);
        }

        // GET: PersonalContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalContact = await _context.PersonalContacts.FindAsync(id);
            if (personalContact == null)
            {
                return NotFound();
            }
            return View(personalContact);
        }

        // POST: PersonalContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalContactId,PersonalFirstName,PersonalLastName,PersonalEmail,PersonalPhoneNumber,PersonalAddressLine1,PersonalAddressLine2,PersonalPostcode,PersonalCountry")] PersonalContact personalContact)
        {
            if (id != personalContact.PersonalContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalContactExists(personalContact.PersonalContactId))
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
            return View(personalContact);
        }

        // GET: PersonalContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalContact = await _context.PersonalContacts
                .FirstOrDefaultAsync(m => m.PersonalContactId == id);
            if (personalContact == null)
            {
                return NotFound();
            }

            return View(personalContact);
        }

        // POST: PersonalContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalContact = await _context.PersonalContacts.FindAsync(id);
            _context.PersonalContacts.Remove(personalContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalContactExists(int id)
        {
            return _context.PersonalContacts.Any(e => e.PersonalContactId == id);
        }
    }
}
