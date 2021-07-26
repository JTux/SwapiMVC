using System.Linq;
using System.Text.Json.Serialization;

namespace Models
{
    public class BingImageViewModel
    {
        [JsonPropertyName("value")]
        public BingImageValue[] Results { get; set; }

        public BingImageValue Value => Results.FirstOrDefault();
    }

    public class BingImageValue
    {
        [JsonPropertyName("thumbnailUrl")]
        public string Url { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}