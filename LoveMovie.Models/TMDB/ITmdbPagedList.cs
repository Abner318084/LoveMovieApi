using System;
using System.Collections.Generic;
using System.Text;

namespace LoveMovie.Models.TMDB
{
    public interface ITmdbPagedList<T>
    {
        int Page { get; set; }
        List<T> Results { get; set; }
        int Total_results { get; set; }
        int Total_pages { get; set; }
    }
}
