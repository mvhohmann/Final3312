using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final3312;

namespace Final3312.Pages.Posts
{
    public class DeleteModel : PageModel
    {
        private readonly Final3312.DBContext _context;

        public DeleteModel(Final3312.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public post? post { get; set; }= default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            post = await _context.post.FirstOrDefaultAsync(m => m.PostID == id);

            if (post == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            post = await _context.post.FindAsync(id);

            if (post != null)
            {
                _context.post.Remove(post);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
