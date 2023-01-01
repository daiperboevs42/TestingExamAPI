using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TestingExamAPI.Consumer.Entities;

namespace TestingExamAPI.Consumer
{
    public class RequestMaker
    {
        static HttpClient client = new HttpClient();
        public RequestMaker(Uri baseUri = null)
        {
            client = new HttpClient { BaseAddress = baseUri ?? new Uri("http://localhost:49736") };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public static async Task<List<User>> GetAllUsers()
        {
            HttpResponseMessage response =
            await client.GetAsync("http://localhost:49736/user/");
            string responseBody = await response.Content.ReadAsStringAsync();
            var returnedUsers = JsonConvert.DeserializeObject<List<User>>(responseBody);
            var status = response.StatusCode;
            if (status == System.Net.HttpStatusCode.OK)
                return returnedUsers;
            throw new Exception("It went wrong");
        }
        public static async Task<User> GetSpecificUser(int id)
        {
            HttpResponseMessage response =
            await client.GetAsync($"http://localhost:49736/user/{id}");
            var responseBody = await response.Content.ReadAsStringAsync();
            var returnedUser = JsonConvert.DeserializeObject<User>(responseBody);
            var status = response.StatusCode;
            if (status == System.Net.HttpStatusCode.OK)
                return returnedUser;
            throw new Exception("It went wrong");
        }

        public static async Task<User> CreateUser()
        {
            var userToCreate = new User() { Id = 5, Name = "The Hot Single Near You", Email = "TotallyLegitEmail@Yahoo.dk", IsAvailable = true };
            HttpResponseMessage response =
            await client.PostAsJsonAsync($"http://localhost:49736/user", userToCreate);
            string responseBody = await response.Content.ReadAsStringAsync();
            var createdUser = JsonConvert.DeserializeObject<User>(responseBody);
            var status = response.StatusCode;
            if (status == System.Net.HttpStatusCode.OK)
                return createdUser;
            throw new Exception("It went wrong");
        }

        public static async Task<User> UpdateUser()
        {
            var userToUpdate = new User() { Id = 1, Name = "Martin Emil Wøbbe", Email = "SomeEmail@Yahoo.dk", IsAvailable = true };
            HttpResponseMessage response =
            await client.PutAsJsonAsync($"http://localhost:49736/user/", userToUpdate);
            string responseBody = await response.Content.ReadAsStringAsync();
            var updatedUser = JsonConvert.DeserializeObject<User>(responseBody);
            var status = response.StatusCode;
            if (status == System.Net.HttpStatusCode.OK)
                return updatedUser;
            throw new Exception("It went wrong");
        }

        public static async Task<User> DeleteUser()
        {
            HttpResponseMessage response =
            await client.DeleteAsync($"http://localhost:49736/user/4");
            string responseBody = await response.Content.ReadAsStringAsync();
            var deletedUser = JsonConvert.DeserializeObject<User>(responseBody);
            var status = response.StatusCode;
            if (status == System.Net.HttpStatusCode.OK)
                return deletedUser;
            throw new Exception("It went wrong");
        }

        
    }
}
