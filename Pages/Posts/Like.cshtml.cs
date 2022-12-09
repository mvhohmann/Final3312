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
    public class LikeModel : PageModel
    {
        private readonly Final3312.DBContext _context;
        private readonly ILogger<DetailsModel> _logger;

        public LikeModel(Final3312.DBContext context,ILogger<DetailsModel> logger)
        {
            _context = context;
            _logger=logger;
        }

        public post? post { get; set; }= default!;
        public async Task<IActionResult> OnGetAsync(int id,int liked)
        {
            if(!@Pages.IndexModel.loginpass)
            {
                return Redirect("../index");
            }

            post = await _context.post.FirstOrDefaultAsync(m => m.PostID == id);

            if (post == null)
            {
                return NotFound();
            }
            _logger.LogInformation("OnPost() Called "+liked+" "+id);
            var holder=_context.like.Select(l => l).Where(l => l.PostID==id).Where(l => l.UserID==@Pages.IndexModel.login).FirstOrDefault();
            if(holder!=null)
            {
                holder.likes=liked;
                _context.like.Update(holder);
            }
            else
            {
                holder=new like{PostID=id ,UserID=@Pages.IndexModel.login ,CommentID=null ,likes=liked};
                _context.like.Add(holder);
            }
            _context.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
