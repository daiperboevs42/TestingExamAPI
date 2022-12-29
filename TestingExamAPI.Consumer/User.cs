using System.Text.Json.Serialization;

namespace TestingExamAPI.Consumer
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAvailable { get; set; }
    }
}
