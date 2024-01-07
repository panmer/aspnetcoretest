using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using gcsharpRPC.Services;
using gcsharpRPC.Models;

namespace gcsharpRPC.Pages.Polls
{
    public class JoinPollPageModel : PageModel
    {
        private readonly PollService _service;

        [Required]
        public Poll Poll { get; set; }

        [BindProperty]
        [Required, MinLength(1)]
        public string Name { get; set; }

        [BindProperty]
        [Required, EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [Required, MinLength(1)]
        public int[] SelectedPollOptionIds { get; set; }

        public JoinPollPageModel(PollService service)
        {
            _service = service;
        }

        public async Task OnGetAsync(Guid guid)
        {
            Poll = await _service.GetPollByGuidAsync(guid);
        }

        public async Task<IActionResult> OnPostAsync(Guid guid) {
            Poll = await _service.GetPollByGuidAsync(guid);

            if (ModelState.IsValid)
            {
                await _service.VotePollAsync(guid, Name, Email, SelectedPollOptionIds);
            }

            return Page();
        }
    }
}
