using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Views.Shared.Components.ListDisplay
{
    [ViewComponent(Name = "ListDisplay")]
    public class ListDisplayVC : ViewComponent
    {
        private readonly HttpClient _httpClient;
        public ListDisplayVC(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("swapi");
        }

        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<string> urls, string controller, string title)
        {
            List<SwapiResponse> data = new();

            var ids = urls.Select(u => GetIdFromUrl(u));
            foreach (var id in ids)
            {
                var response = await _httpClient.GetAsync($"{controller}/{id}");
                if (!response.IsSuccessStatusCode) continue;
                    
                var responseData = JsonSerializer.Deserialize<SwapiResponse>(
                    await response.Content.ReadAsStringAsync()
                );

                responseData.Id = id;
                data.Add(responseData);
            }
            
            ListDisplayViewModel viewModel = new()
            {
                Title = title,
                Data = data,
                Controller = controller
            };

            return View(viewModel);
        }

        private string GetIdFromUrl(string url)
        {
            var id = url.Split("/", StringSplitOptions.RemoveEmptyEntries).LastOrDefault();
            return id;
        }
    }

    public class ListDisplayViewModel
    {
        public string Title { get; set; }
        public string Controller { get; set; }
        public IEnumerable<SwapiResponse> Data { get; set; }
    }

    public class SwapiResponse
    {
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}