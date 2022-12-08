using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Final3312;

namespace Final3312.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly Final3312.DBContext _context;
        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 3;
        public int Items {get;set;}
        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;} = string.Empty;
        public SelectList SortList {get; set;} = default!;

        public IndexModel(Final3312.DBContext context)
        {
            _context = context;
        }

        public IList<post> post { get;set; }= default!;
        public string findUser(int userId)
        {
            return _context.user.FirstOrDefault(user => user.UserID == userId)!.username;
        }

        public async Task OnGetAsync()
        {
            var query = _context.post.Select(p => p);
            Items=query.Count();
            List<SelectListItem> sortItems = new List<SelectListItem> {
                new SelectListItem { Text = "Date & Time Ascending", Value = "DT_asc" },
                new SelectListItem { Text = "Date & Time Descending", Value = "DT_desc"}
            };
            SortList = new SelectList(sortItems, "Value", "Text", CurrentSort);

            switch (CurrentSort)
            {
                case "DT_asc": 
                    query = query.OrderBy(p => p.postTime);
                    break;
                case "DT_desc":
                    query = query.OrderByDescending(p => p.postTime);
                    break;
            }
            post = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
        }
    }
}
