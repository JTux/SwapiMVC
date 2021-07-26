using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Views.Shared.Components.ImageDisplay
{
    [ViewComponent(Name = "ImageDisplay")]
    public class ImageDisplayVC : ViewComponent
    {
        private readonly HttpClient _httpClient;
        public ImageDisplayVC(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("bing");
        }

        public async Task<IViewComponentResult> InvokeAsync(string query)
        {
            var response = await _httpClient.GetAsync($"search?safeSearch=Strict&count=1&q={query}");
            if (response.IsSuccessStatusCode)
            {
                var responseData = JsonSerializer.Deserialize<BingImageViewModel>(
                    await response.Content.ReadAsStringAsync()
                );
                return View(responseData);
            }
            
            return View(new BingImageViewModel());
        }
    }
}