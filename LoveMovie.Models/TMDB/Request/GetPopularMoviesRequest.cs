using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LoveMovie.Models.TMDB
{
    public class GetPopularMoviesRequest : HttpGetRequest
    {
        [JsonPropertyName("language")]
        [RegularExpression(@"([a-z]{2})-([A-Z]{2})")]
        public string Language { get; set; }

        [JsonPropertyName("page")]
        [Range(1, 1000)]
        public int? Page { get; set; }

        [JsonPropertyName("region")]
        [RegularExpression(@"^[A-Z]{2}$")]
        public string Region { get; set; }
    }
}
