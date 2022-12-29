using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace TestingExamAPI.Consumer
{
    public class RequestMaker
    {
        static HttpClient client = new HttpClient();
        public RequestMaker()
        {
            client.BaseAddress = new Uri("https://localhost:44316");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public static async Task<HttpResponseMessage> GetAllUsers()
        {
            HttpResponseMessage response =
            await client.GetAsync("https://localhost:44316/user/");
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.Write(responseBody);
            return response;
        }
        public static async Task GetSpecificUser()
        {
            HttpResponseMessage response =
            await client.GetAsync("https://localhost:44316/user/1");
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.Write(responseBody);
        }

        public static async Task CreateUser()
        {
            var userToCreate = new User() { Id = 5, Name = "The Hot Single Near You", Email = "TotallyLegitEmail@Yahoo.dk", IsAvailable = true };
            HttpResponseMessage response =
            await client.PostAsJsonAsync($"https://localhost:44316/user", userToCreate);
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.Write(responseBody);
        }

        public static async Task UpdateUser()
        {
            var userToUpdate = new User() { Id = 1, Name = "Martin Emil Wøbbe", Email = "SomeEmail@Yahoo.dk", IsAvailable = true };
            HttpResponseMessage response =
            await client.PutAsJsonAsync($"https://localhost:44316/user/", userToUpdate);
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.Write(responseBody);
        }

        public static async Task DeleteUser()
        {
            HttpResponseMessage response =
            await client.DeleteAsync($"https://localhost:44316/user/4");
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.Write(responseBody);
        }

        
    }
}
