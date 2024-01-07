using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;

namespace gcsharpRPC.Pages;

public class LogoutModel : PageModel
{
    private readonly IConfiguration _config;

    public LogoutModel(IConfiguration config)
    {
        _config = config;
    }

    public IActionResult OnGet()
    {
        HttpContext.Session.Remove("username");
        return Page();
    }
}