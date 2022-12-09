using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Final3312;

namespace Final3312.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly Final3312.DBContext _context;

        public CreateModel(Final3312.DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if(!@Pages.IndexModel.loginpass)
            {
                return Redirect("../index");
            }
            else
            {
                return Page();
            }
        }

        [BindProperty]
        public post post { get; set; }= default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.post.Add(post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
