using System;
using System.Collections.Generic;
using System.Text;

namespace LoveMovie.Models.TMDB
{
    public class GetPopularMoviesRequest : IHttpGetRequest
    {
        public string Language { get; set; }
        public int? Page { get; set; }
        public string Region { get; set; }
    }

    public class GetPopularMoviesResponse : ITmdbPagedList<GetPopularMoviesResult>
    {
        public int Page { get; set; }
        public List<GetPopularMoviesResult> Results { get; set; }
        public int Total_results { get; set; }
        public int Total_pages { get; set; }
    }

    public class GetPopularMoviesResult
    {
        public string Poster_path { get; set; }
        public bool Adult { get; set; }
        public string Overview { get; set; }
        public string Release_date { get; set; }
        public List<int> Genre_ids { get; set; }
        public int Id { get; set; }
        public string Original_title { get; set; }
        public string Original_language { get; set; }
        public string Title { get; set; }
        public string Backdrop_path { get; set; }
        public double Popularity { get; set; }
        public int Vote_count { get; set; }
        public bool Video { get; set; }
        public double Vote_average { get; set; }
    }    

}
