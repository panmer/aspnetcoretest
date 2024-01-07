using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gcsharpRPC.Helpers;
using gcsharpRPC.Models;

namespace MyApp.Namespace
{
    public class ListModel : PageModel
    {
        private readonly ILogger<ListModel> _logger;

        public DbSet<Poll> Polls { get; set; }

        public ListModel(TrungContext pc, ILogger<ListModel> logger)
        {
            Polls = pc.Polls;
            _logger = logger;
        }
    }
}
