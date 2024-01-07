using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gcsharpRPC.Models;

namespace gcsharpRPC.Services
{
    static class PollExtensions
    {
        public static IQueryable<Poll> IncludeOptionsAndVotes(this IQueryable<Poll> targetQuery) =>
            targetQuery
                .Include(poll => poll.Options)
                .ThenInclude(poll => poll.UserVotes);
    }
}