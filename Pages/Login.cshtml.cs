using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace gcsharpRPC.Pages;

public class LoginModel : PageModel
{
    public String Message { get; set; } = "";

    // private readonly IConfiguration _config;

    // public LoginModel()
    // {
    // }

    public IActionResult OnGet()  
    {
        return Page();
    }

    public IActionResult OnPost(string username, string password)  
    {
        if ( username.Equals("trungdeptrai", StringComparison.CurrentCulture) &&
             password.Equals("trungdeptrai69", StringComparison.CurrentCulture) )
        {
            HttpContext.Session.SetString("username", username);
            return Redirect("/Events/List");
        }

        Message = "Invalid Username Or Password!"; 

        return Page();  
    }
}