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
                new User{ Name="Martin Emil Wøbbe", Email="SomeEmail@Yahoo.dk", IsAvailable=false},
                new User{ Name="Martin Park Brodersen", Email="SomeOtherEmail@Yahoo.dk", IsAvailable=true},
                new User{ Name="Tienesh Sivasubremaniyam", Email="SomeSeperateEmail@Yahoo.dk", IsAvailable=true},
                new User{ Name="Non Descript Female", Email="TheEmail@Yahoo.dk", IsAvailable=true}
            };
            List<Interest> interests = new List<Interest>
            {
                new Interest{ Name="Cars"},
                new Interest{ Name="Coding"},
                new Interest{ Name="Cinema"},
                new Interest{ Name="Carousels"},
                new Interest{ Name="Cats"},
                new Interest{ Name="Carpentry"},
                new Interest{ Name="Cheese"},
                new Interest{ Name="Coffee"}
            };
            List<Preference> preferences = new List<Preference>
            {
                new Preference{ Name="Men" },
                new Preference{ Name="Women" },
                new Preference{ Name="Mix" }
            };

            users[0].Interests.Add(interests[0]);
            users[0].Interests.Add(interests[3]);
            users[0].Interests.Add(interests[4]);

            users[1].Interests.Add(interests[1]);
            users[1].Interests.Add(interests[2]);
            users[1].Interests.Add(interests[6]);
            users[1].Interests.Add(interests[4]);

            users[2].Interests.Add(interests[1]);
            users[2].Interests.Add(interests[6]);
            users[2].Interests.Add(interests[5]);
            users[2].Interests.Add(interests[7]);

            users[0].Interests.Add(interests[0]);
            users[0].Interests.Add(interests[5]);
            users[0].Interests.Add(interests[7]);

            context.Interests.AddRange(interests);
            context.Preferences.AddRange(preferences);
            context.SaveChanges();
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
