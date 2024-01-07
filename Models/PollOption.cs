namespace gcsharpRPC.Models
{
    public class PollOption
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public ICollection<UserVote> UserVotes { get; set; }  = new List<UserVote>();
    }
}