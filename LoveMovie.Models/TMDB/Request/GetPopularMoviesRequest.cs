using System.ComponentModel.DataAnnotations;

namespace LoveMovie.Models.TMDB
{
    public class GetPopularMoviesRequest : IHttpGetRequest
    {
        [QueryStringProperty(Name = "language")]
        [RegularExpression(@"([a-z]{2})-([A-Z]{2})")]
        public string Language { get; set; }

        [QueryStringProperty(Name = "page")]
        [Range(1, 1000)]
        public int? Page { get; set; }

        [QueryStringProperty(Name = "region")]
        [RegularExpression(@"^[A-Z]{2}$")]
        public string Region { get; set; }
    }
}
