using TestingExamAPI.Core.Entities;

namespace TestingExamAPI.Infrastructure
{
    public class DbInitializer : IDbInitializer
    {
        public void Initialize(TestingExamAPIContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            if (context.Users.Any())
            {
                return;  
            }

            List<User> users = new List<User>
            {
                //make users
            };
            List<Interest> interests = new List<Interest>
            {
                //make interests
            };
            List<User> preferences = new List<User>
            {
                //make preferences
            };

            context.Users.AddRange(users);
            context.Interests.AddRange(interests);
            context.Preferences.AddRange(preferences);
            context.SaveChanges();
        }
    }
}
