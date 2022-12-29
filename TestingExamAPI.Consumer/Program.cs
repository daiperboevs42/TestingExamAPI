using System.Net.Http.Headers;
using System.Text.Json;
using TestingExamAPI.Consumer;
using System.Net.Http.Headers;
using System.Text.Json;

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

await ProcessRepositoriesAsync(client);

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    await using Stream stream =
    await client.GetStreamAsync("https://localhost:44316/user");
    var users =
        await JsonSerializer.DeserializeAsync<List<User>>(stream);
    foreach (var user in users)
        Console.Write(user);
}