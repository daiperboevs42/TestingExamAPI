using API.Provider.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xunit;

namespace Provider.Tests
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
                    "1", () =>
                    AddTesterIfItDoesntExist(1)
                }
            };
        }

        private void AddTesterIfItDoesntExist(int id)
        {
            var dataDirectory = Directory.CreateDirectory(Path.Combine("..", "..", "..", "data"));
            var dataFilePath = Path.Combine(dataDirectory.FullName, "somethings.json");
            var fileData = File.Exists(dataFilePath) ? File.ReadAllText(dataFilePath) : null;
            var userData = string.IsNullOrEmpty(fileData)
                ? new List<User>()
                : JsonConvert.DeserializeObject<List<User>>(fileData);
            if (!userData.Any(user => user.Id == id))
            {
                userData.Add(new User()
                {
                    Id = 1,
                    Name = "NotAMartin",
                    Email = "Awesomepossum@gmail.com",
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