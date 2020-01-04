using System;

namespace LoveMovie
{
    public static class TmdbApiUrl
    {
        public const string Get_Popular = "/movie/popular";
        public const string Get_Discover = "/discover/movie";
    }

    public static class CacheKeys
    {
        public const string TmdbApiReadAccessToken = "TmdbApiReadAccessToken";
    }

}
