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
    public class DetailsModel : PageModel
    {
        private readonly Final3312.DBContext _context;
        private readonly ILogger<DetailsModel> _logger;
        public int likes {get;set;}
        public int dislikes {get;set;}

        public DetailsModel(Final3312.DBContext context,ILogger<DetailsModel> logger)
        {
            _context = context;
            _logger=logger;
        }

        public post? post { get; set; }= default!;
        public IList<comment> comments { get;set; }= default!;
        public string findUser(int userId)
        {
            return _context.user.FirstOrDefault(user => user.UserID == userId)!.username;
        }
        public int findLike(int userId,int PostID,int commentID)
        {
            if(commentID==0)
            {
                return _context.like.Where(like => like.UserID == userId).Where(like => like.PostID == PostID).Where(like => like.CommentID ==null).Select(l=>l.likes).FirstOrDefault();
            }
            else
            {
                return _context.like.Where(like => like.UserID == userId).Where(like => like.PostID == PostID).Where(like => like.CommentID ==commentID).Select(l=>l.likes).FirstOrDefault();
            }
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(!@Pages.IndexModel.loginpass)
            {
                return Redirect("../index");
            }
            if (id == null)
            {
                return NotFound();
            }

            post = await _context.post.FirstOrDefaultAsync(m => m.PostID == id);

            if (post == null)
            {
                return NotFound();
            }
            likes=_context.like.Where(l=>l.PostID==id).Where(l=>l.likes==1).Count();
            dislikes=_context.like.Where(l=>l.PostID==id).Where(l=>l.likes==2).Count();
            comments = await _context.comment.Select(c => c).Where(c => c.PostID==id).ToListAsync();
            return Page();
        }
    }
}
