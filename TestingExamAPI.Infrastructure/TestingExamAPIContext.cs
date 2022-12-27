using Microsoft.EntityFrameworkCore;
using TestingExamAPI.Core.Entities;

namespace TestingExamAPI.Infrastructure
{
    public class TestingExamAPIContext : DbContext
    {
        public TestingExamAPIContext(DbContextOptions<TestingExamAPIContext> options)
            :base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Preference> Preferences { get; set; }
    }
}
