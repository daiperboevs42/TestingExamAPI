using System;

namespace TestingExamAPI.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAvailable { get; set; }
        //public List<Interest>? Interests { get; set; }
        //public List<Preference>? Preferences { get; set; }
    } 
}
