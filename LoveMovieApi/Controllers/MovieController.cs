using LoveMovie.Models;
using LoveMovie.Models.TMDB;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoveMovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly TmdbApiClient _tmdbApiClient;

        public MovieController(TmdbApiClient tmdbApiClient)
        {
            this._tmdbApiClient = tmdbApiClient;
        }

        [HttpGet("Popular")]
        public async Task<ActionResult<GetPopularMoviesResponse>> PopularAsync([FromQuery]GetPopularMoviesRequest request)
        {
            return await _tmdbApiClient.GetAsync<GetPopularMoviesResponse>(TmdbApiUrl.Get_Popular, request);
        }

        [HttpGet("Discover")]
        public async Task<ActionResult<DiscoverMoviesResponse>> DiscoverAsync([FromQuery]DiscoverMoviesRequest request)
        {
            return await _tmdbApiClient.GetAsync<DiscoverMoviesResponse>(TmdbApiUrl.Get_Discover, request);
        }

    }
}