using System.Text.Json.Serialization;

namespace TestingExamAPI.Consumer
{
    public record class User(
    [property: JsonPropertyName("Id")] int Id,
    [property: JsonPropertyName("Name")] string Name,
    [property: JsonPropertyName("Email")] string Email,
    [property: JsonPropertyName("IsAvailable")] bool IsAvailable);

}
