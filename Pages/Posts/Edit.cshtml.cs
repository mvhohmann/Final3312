using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final3312;

namespace Final3312.Pages.Posts
{
    public class EditModel : PageModel
    {
        private readonly Final3312.DBContext _context;

        public EditModel(Final3312.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public post? post { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(!@Pages.IndexModel.loginpass)
            {
                Response.Redirect("../index");
            }
            if (id == null)
            {
                return NotFound();
            }

            post = await _context.post.FirstOrDefaultAsync(m => m.PostID == id);

            if (post == null||@Pages.IndexModel.login!=post.UserID)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(post!).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!postExists(post!.PostID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool postExists(int id)
        {
            return _context.post.Any(e => e.PostID == id);
        }
    }
}
