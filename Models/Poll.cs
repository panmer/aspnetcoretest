using System.ComponentModel.DataAnnotations;

namespace gcsharpRPC.Models;

public class Poll
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    public string Location { get; set; }
    public DateTime? CloseDate { get; set; }
    public Guid PollGuid { get; set; }

    public bool IsDeleted { get; set; } = false;

    public ICollection<PollOption> Options { get; set; }
    public ICollection<UserVote> UserVotes { get; set; }

    public Poll() {
        PollGuid = Guid.NewGuid();
        UserVotes = new List<UserVote>();
        Options = new List<PollOption>();
    }
}