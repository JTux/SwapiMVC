using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace SwapiMVC.Models
{
    public class PeopleViewModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("height")]
        public string Height { get; set; }

        [JsonPropertyName("mass")]
        public string Mass { get; set; }

        [JsonPropertyName("birth_year")]
        public string BirthYear { get; set; }

        [JsonPropertyName("eye_color")]
        public string EyeColor { get; set; }

        [JsonPropertyName("hair_color")]
        public string HairColor { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("skin_color")]
        public string SkinColor { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        public string Id
        {
            get
            {
                return Url
                    .Split("/", StringSplitOptions.RemoveEmptyEntries)
                    .LastOrDefault();
            }
        }

        [JsonPropertyName("starships")]
        public string[] Starships { get; set; }

        [JsonPropertyName("species")]
        public string[] Species { get; set; }

        [JsonPropertyName("vehicles")]
        public string[] Vehicles { get; set; }
    }
}