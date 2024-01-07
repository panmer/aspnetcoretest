using gcsharpRPC.Models;
using gcsharpRPC.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gcsharpRPC.Services
{
    public class PollService
    {
        private readonly TrungContext dbContext;

        private readonly ILogger _logger;

        public PollService(TrungContext _dbContext,
                        ILogger<PollService> logger)
        {
            dbContext = _dbContext;
            _logger = logger;
        }

        public async Task<Poll> GetPollAsync(int id)
        {
            return await dbContext.Polls
                .Where(poll => poll.Id == id)
                .IncludeOptionsAndVotes()
                .SingleOrDefaultAsync();
        }

        public async Task<int> CreatePollAsync(Poll poll, PollOption[] pollOptions)
        {
            foreach (var option in pollOptions) {
                poll.Options.Add(option);
                // _logger.LogInformation(")))) " + option.Date);
                // _logger.LogInformation(")))) " + option.StartTime);
            }

            await dbContext.Polls.AddAsync(poll);

            _logger.LogInformation("===== " + poll);

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeletePollAsync(int id)
        {
            var pollToDelete = await GetPollAsync(id);

            if (pollToDelete is null)
            {
                return id;
            }

            pollToDelete.IsDeleted = true;

            // if (pollToDelete?.Options is not null)
            // {
            //     foreach (var option in pollToDelete.Options)
            //     {
            //         dbContext.PollOptions.Remove(option);
            //     }
            // }

            // dbContext.Polls.Remove(pollToDelete);

            await dbContext.SaveChangesAsync();

            return id;
        }

        public async Task<int> ClosePollAsync(int id)
        {
            var poll = dbContext.Polls.Single(poll => poll.Id == id);

            poll.CloseDate = poll.CloseDate.HasValue ? null : DateTime.Now;
            
            await dbContext.SaveChangesAsync();

            return id;
        }

        public async Task<Poll> GetPollByGuidAsync(Guid guid)
        {
            return await dbContext.Polls
                .Where(poll => poll.PollGuid == guid)
                .IncludeOptionsAndVotes()
                .SingleOrDefaultAsync();
        }

        public async Task VotePollAsync(Guid guid, string name, string email, int[] selectedPollOptions)
        {
            var poll = dbContext.Polls.Single(poll => poll.PollGuid == guid);

            var existingUserVote = poll.UserVotes.FirstOrDefault(x => x.Email == email);

            if (existingUserVote is not null)
                dbContext.UserVotes.Remove(existingUserVote);

            var voteOptions = poll.Options.Where(poll => selectedPollOptions.Contains(poll.Id)).ToList();

            dbContext.UserVotes.Add(
                new UserVote {
                    Email = email,
                    Name = name,
                    Poll = poll,
                    Options = voteOptions
                }
            );

            await dbContext.SaveChangesAsync();
        }
    }
}