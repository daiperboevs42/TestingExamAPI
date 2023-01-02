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

            var interest1 = context.Interests.Add(new Interest { Name = "Cars" }).Entity;
            var interest2 = context.Interests.Add(new Interest { Name = "Coding" }).Entity;
            var interest3 = context.Interests.Add(new Interest { Name = "Cinema" }).Entity;
            var interest4 = context.Interests.Add(new Interest { Name = "Carousels" }).Entity;
            var interest5 = context.Interests.Add(new Interest { Name = "Cats" }).Entity;
            var interest6 = context.Interests.Add(new Interest { Name = "Carpentry" }).Entity;
            var interest7 = context.Interests.Add(new Interest { Name = "Cheese" }).Entity;
            var interest8 = context.Interests.Add(new Interest { Name = "Coffee" }).Entity;

            var preference1 = context.Preferences.Add(new Preference { Name = "Men" }).Entity;
            var preference2 = context.Preferences.Add(new Preference { Name = "Women" }).Entity;
            var preference3 = context.Preferences.Add(new Preference { Name = "Mix" }).Entity;



            var user1 = context.Users.Add(new User()
            { 
                Id = 1,
                Name = "Martin Emil Wøbbe",
                Email = "SomeEmail@Yahoo.dk",
                IsAvailable = false,
            //    Interests = new List<Interest>
            //    {
            //        interest1,interest4,interest5
            //    },
            //    Preferences = new List<Preference> { preference2 }
            //
            }).Entity;

            var user2 = context.Users.Add(new User()
            {
                Id = 2,
                Name = "Martin Park Brodersen",
                Email = "SomeOtherEmail@Yahoo.dk",
                IsAvailable = true,
                //Interests = new List<Interest>
                //{
                //    interest2,interest3,interest5, interest7
                //},
                //Preferences = new List<Preference> { preference1, preference2 }
            }).Entity;

            var user3 = context.Users.Add(new User()
            {
                Id = 3, 
                Name = "Tienesh Sivasubremaniyam",
                Email = "SomeSeperateEmail@Yahoo.dk",
                IsAvailable = true,
                //Interests = new List<Interest>
                //{
                //    interest2,interest6,interest7, interest8
                //},
                //Preferences = new List<Preference> { preference2, preference3 }
            }).Entity;

            var user4 = context.Users.Add(new User()
            {
                Id = 4, 
                Name = "Non Descript Female",
                Email = "TheEmail@Yahoo.dk",
                IsAvailable = true,
                //Interests = new List<Interest>
                //{
                //    interest1,interest6,interest8
                //},
                //Preferences = new List<Preference> { preference2, preference3 }
            }).Entity;


            //List<Interest> interests = new List<Interest>
            //{
            //    new Interest{ Name="Cars"},
            //    new Interest{ Name="Coding"},
            //    new Interest{ Name="Cinema"},
            //    new Interest{ Name="Carousels"},
            //    new Interest{ Name="Cats"},
            //    new Interest{ Name="Carpentry"},
            //    new Interest{ Name="Cheese"},
            //    new Interest{ Name="Coffee"}
            //};
            //List<Preference> preferences = new List<Preference>
            //{
            //    new Preference{ Name="Men" },
            //    new Preference{ Name="Women" },
            //    new Preference{ Name="Mix" }
            //};

            //List<User> users = new List<User>
            //{
            //    new User{ Name="Martin Emil Wøbbe", Email="SomeEmail@Yahoo.dk", IsAvailable=false},
            //    new User{ Name="Martin Park Brodersen", Email="SomeOtherEmail@Yahoo.dk", IsAvailable=true},
            //    new User{ Name="Tienesh Sivasubremaniyam", Email="SomeSeperateEmail@Yahoo.dk", IsAvailable=true},
            //    new User{ Name="Non Descript Female", Email="TheEmail@Yahoo.dk", IsAvailable=true}
            //};

            //users[0].Interests.Add(interests[0]);
            //users[0].Interests.Add(interests[3]);
            //users[0].Interests.Add(interests[4]);

            //users[1].Interests.Add(interests[1]);
            //users[1].Interests.Add(interests[2]);
            //users[1].Interests.Add(interests[6]);
            //users[1].Interests.Add(interests[4]);

            //users[2].Interests.Add(interests[1]);
            //users[2].Interests.Add(interests[6]);
            //users[2].Interests.Add(interests[5]);
            //users[2].Interests.Add(interests[7]);

            //users[0].Interests.Add(interests[0]);
            //users[0].Interests.Add(interests[5]);
            //users[0].Interests.Add(interests[7]);

            //context.Interests.AddRange(interests);
            //context.Preferences.AddRange(preferences);
            //context.SaveChanges();
            //context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
