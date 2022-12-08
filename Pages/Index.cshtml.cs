using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.ComponentModel.DataAnnotations;


namespace Final3312.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly DBContext _context;
    [BindProperty]
    [Display(Name = "Username")]
    [StringLength(60,MinimumLength =3)]
    [Required]
    public string Username {get; set;} = string.Empty;
    [BindProperty]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    [StringLength(60,MinimumLength =3)]
    [Required]
    public string Password {get; set;} = string.Empty;

    public IndexModel(DBContext context,ILogger<IndexModel> logger)
    {
        _context=context;
        _logger = logger;
    }

    public void OnGet()
    {

    }
    public void OnPost()
    {
        _logger.LogInformation("OnPost() Called "+Username+" "+Password);
        var holder=_context.user.FirstOrDefault(user => user.username == Username);
        if(holder!=null&&holder.password==Hash.hash256(Password,holder.UserID.ToString()))
        {
            //identification
            Response.Redirect("/posts");
        }
    }
}
