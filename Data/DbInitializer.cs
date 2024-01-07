using gcsharpRPC.Models;
using gcsharpRPC.Helpers;

namespace gcsharpRPC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TrungContext context)
        {
            // // Look for any polls
            // if (context.Polls.Any())
            // {
            //     return;   // DB has been seeded
            // }

            // var polls = new Poll[]
            // {
            //     new Poll {
            //         Title = "dwdadasdw",
            //         Description = "dqwdddw",
            //         Location = "wdadacsd"
            //     },
            //     new Poll {
            //         Title = "addsdasda",
            //         Description = "dsdsadasd",
            //         Location = "sdasdsads"
            //     }
            // };

            // context.Polls.AddRange(polls);
            // context.SaveChanges();

            // var courses = new Person[]
            // {
            // };

            // context.Persons.AddRange(courses);
            // context.SaveChanges();
        }
    }
}