using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestingExamAPI.Core.Entities;

namespace TestingExamAPI.ProviderTest
{
    public class ProviderStateMiddleware
    {
        private readonly IDictionary<string, Action> providerStates;
        private readonly RequestDelegate next;

        public ProviderStateMiddleware(RequestDelegate next)
        {
            this.next = next;
            providerStates = new Dictionary<string, Action>
            {
                {
                    "There is a something with id '1,2,3 & 4'",
                    AddUserIfDoesntExist
                }
            };
        }

        private void AddUserIfDoesntExist()
        {
            var dataDirectory = Directory.CreateDirectory(Path.Combine("..", "..", "..","..", "data"));
            var dataFilePath = Path.Combine(dataDirectory.FullName, "users.json");
            var fileData = File.Exists(dataFilePath) ? File.ReadAllText(dataFilePath) : null;
            var userData = string.IsNullOrEmpty(fileData)
                ? new List<User>()
                : JsonConvert.DeserializeObject<List<User>>(fileData);
            if (!userData.Any(user => user.Id == 1))
            {
                userData.Add(new User()
                {
                    Id = 1,
                    Name = "Martin Emil Wøbbe",
                    Email = "SomeEmail@Yahoo.dk",
                    IsAvailable = false
                });
                userData.Add(new User()
                {
                    Id = 2,
                    Name = "Martin Park Brodersen",
                    Email = "SomeOtherEmail@Yahoo.dk",
                    IsAvailable = true,
                });
                userData.Add(new User()
                { 
                    Id = 3,
                    Name = "Tienesh Sivasubremaniyam",
                    Email = "SomeSeperateEmail@Yahoo.dk",
                    IsAvailable = true,
                });
                userData.Add(new User()
                {
                    Id = 4,
                    Name = "Non Descript Female",
                    Email = "TheEmail@Yahoo.dk",
                    IsAvailable = true,
                });
            }
            File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(userData));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Path
                .Value?.StartsWith("/provider-states") ?? false)
            {
                await next.Invoke(context);
                return;
            }

            context.Response.StatusCode = (int)HttpStatusCode.OK;

            if (context.Request.Method == HttpMethod.Post.ToString()
                && context.Request.Body != null)
            {
                string jsonRequestBody;
                using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8))
                {
                    jsonRequestBody = await reader.ReadToEndAsync();
                }

                var providerState = JsonConvert.DeserializeObject<ProviderState>(jsonRequestBody);

                //A null or empty provider state key must be handled
                if (!string.IsNullOrEmpty(providerState?.State))
                {
                    providerStates[providerState.State].Invoke();
                }

                await context.Response.WriteAsync(string.Empty);
            }
        }

    }
}
