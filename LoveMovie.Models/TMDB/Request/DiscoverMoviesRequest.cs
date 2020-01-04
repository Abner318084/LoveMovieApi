using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoveMovie.Models.TMDB
{
    public class DiscoverMoviesRequest : HttpGetRequest
    {
        [RegularExpression(@"([a-z]{2})-([A-Z]{2})")]
        public string Language { get; set; }

        [Range(1, 1000)]
        public int? Page { get; set; }

        [RegularExpression(@"^[A-Z]{2}$")]
        public string Region { get; set; }
        public SortByOption? SortBy { get; set; }
        public string CertificationCountry { get; set; }
        public string Certification { get; set; }
        public string CertificationLte { get; set; }
        public string CertificationGte { get; set; }
        public bool? IncludeAdult { get; set; }
        public bool? IncludeVideo { get; set; }
        public int? PrimaryReleaseYear { get; set; }
        public DateTime? PrimaryReleaseDateGte { get; set; }
        public DateTime? PrimaryReleaseDateLte { get; set; }
        public DateTime? ReleaseDateGte { get; set; }
        public DateTime? ReleaseDateLte { get; set; }

        [Range(1, 6)]
        public short? WithReleaseType { get; set; }

        public int? Year { get; set; }

        [Range(0, int.MaxValue)]
        public int? VoteCountGte { get; set; }

        [Range(1, int.MaxValue)]
        public int? VoteCountLte { get; set; }

        [Range(0, int.MaxValue)]
        public int? VoteAverageGte { get; set; }

        [Range(0, int.MaxValue)]
        public int? VoteAverageLte { get; set; }
        public string WithCast { get; set; }
        public string WithCrew { get; set; }
        public string WithPeople { get; set; }
        public string WithCompanies { get; set; }
        public string WithGenres { get; set; }
        public string WithoutGenres { get; set; }
        public string WithKeywords { get; set; }
        public string WithoutKeywords { get; set; }
        public int? WithRuntimeGte { get; set; }
        public int? WithRuntimeLte { get; set; }
        public string WithOriginalLanguage { get; set; }

        public override string ToQueryString()
        {
            var sb = new StringBuilder();
            sb.Append("?");

            if(!string.IsNullOrWhiteSpace(Language))
                sb.Append($"language={Language}&");

            if (Page.HasValue)
                sb.Append($"page={Page}&");

            if (!string.IsNullOrWhiteSpace(Region))
                sb.Append($"region={Region}&");

            if (SortBy.HasValue)
            {
                sb.Append($"sort_by={SortBy?.ToQueryString()}&");
            }

            if (!string.IsNullOrWhiteSpace(CertificationCountry))
                sb.Append($"certification_country={CertificationCountry}&");

            if (!string.IsNullOrWhiteSpace(Certification))
                sb.Append($"certification={Certification}&");

            if (!string.IsNullOrWhiteSpace(CertificationLte))
                sb.Append($"Certification.lte={CertificationLte}&");

            if (!string.IsNullOrWhiteSpace(CertificationGte))
                sb.Append($"Certification.gte={CertificationGte}&");

            if (IncludeAdult.HasValue)
                sb.Append($"include_adult={IncludeAdult}&");

            if (IncludeVideo.HasValue)
                sb.Append($"include_video={IncludeVideo}&");

            if (PrimaryReleaseYear.HasValue)
                sb.Append($"primary_release_year={PrimaryReleaseYear}&");

            if (PrimaryReleaseDateGte.HasValue)
                sb.Append($"primary_release_date.gte={PrimaryReleaseDateGte?.ToString("yyyy-MM-dd")}&");

            if (PrimaryReleaseDateLte.HasValue)
                sb.Append($"primary_release_date.lte={PrimaryReleaseDateLte?.ToString("yyyy-MM-dd")}&");

            if (ReleaseDateGte.HasValue)
                sb.Append($"release_date.gte={ReleaseDateGte?.ToString("yyyy-MM-dd")}&");

            if (ReleaseDateLte.HasValue)
                sb.Append($"release_date.lte={ReleaseDateLte?.ToString("yyyy-MM-dd")}&");

            if (WithReleaseType.HasValue)
                sb.Append($"with_release_type={WithReleaseType}&");

            if (Year.HasValue)
                sb.Append($"year={Year}&");

            if (VoteCountGte.HasValue)
                sb.Append($"vote_count.gte={VoteCountGte}&");

            if (VoteCountLte.HasValue)
                sb.Append($"vote_count.lte={VoteCountLte}&");

            if (VoteAverageGte.HasValue)
                sb.Append($"vote_average.gte={VoteAverageGte}&");

            if (VoteAverageLte.HasValue)
                sb.Append($"vote_average.lte={VoteAverageLte}&");

            if (!string.IsNullOrWhiteSpace(WithCast))
                sb.Append($"with_cast={WithCast}&");

            if (!string.IsNullOrWhiteSpace(WithCrew))
                sb.Append($"with_crew={WithCrew}&");

            if (!string.IsNullOrWhiteSpace(WithPeople))
                sb.Append($"with_people={WithPeople}&");

            if (!string.IsNullOrWhiteSpace(WithCompanies))
                sb.Append($"with_companies={WithCompanies}&");

            if (!string.IsNullOrWhiteSpace(WithGenres))
                sb.Append($"with_genres={WithGenres}&");

            if (!string.IsNullOrWhiteSpace(WithoutGenres))
                sb.Append($"without_genres={WithoutGenres}&");

            if (!string.IsNullOrWhiteSpace(WithKeywords))
                sb.Append($"with_keywords={WithKeywords}&");

            if (!string.IsNullOrWhiteSpace(WithoutKeywords))
                sb.Append($"without_keywords={WithoutKeywords}&");

            if (WithRuntimeGte.HasValue)
                sb.Append($"with_runtime.gte={WithRuntimeGte}&");

            if (WithRuntimeLte.HasValue)
                sb.Append($"with_runtime.lte={WithRuntimeLte}&");

            if (!string.IsNullOrWhiteSpace(WithOriginalLanguage))
                sb.Append($"with_original_language={WithOriginalLanguage}&");

            return sb.ToString();
        }

        public enum SortByOption
        {
            PopularityAsc,
            PopularityDesc,
            ReleaseDateAsc,
            ReleaseDateDesc,
            RevenueAsc,
            RevenueDesc,
            PrimaryReleaseDateAsc,
            PrimaryReleaseDateDesc,
            OriginalTitleAsc,
            OriginalTitleDesc,
            VoteAverageAsc,
            VoteAverageDesc,
            VoteCountAsc,
            VoteCountDesc
        }
    }

    static class DiscoverMoviesRequestSortByOptionExtensions
    {
        public static string ToQueryString(this DiscoverMoviesRequest.SortByOption option)
        {
            switch (option)
            {
                case DiscoverMoviesRequest.SortByOption.PopularityAsc:
                    return "popularity.asc";
                case DiscoverMoviesRequest.SortByOption.PopularityDesc:
                    return "popularity.desc";
                case DiscoverMoviesRequest.SortByOption.ReleaseDateAsc:
                    return "release_date.asc";
                case DiscoverMoviesRequest.SortByOption.ReleaseDateDesc:
                    return "release_date.desc";
                case DiscoverMoviesRequest.SortByOption.RevenueAsc:
                    return "revenue.asc";
                case DiscoverMoviesRequest.SortByOption.RevenueDesc:
                    return "revenue.desc";
                case DiscoverMoviesRequest.SortByOption.PrimaryReleaseDateAsc:
                    return "primary_release_date.asc";
                case DiscoverMoviesRequest.SortByOption.PrimaryReleaseDateDesc:
                    return "primary_release_date.desc";
                case DiscoverMoviesRequest.SortByOption.OriginalTitleAsc:
                    return "original_title.asc";
                case DiscoverMoviesRequest.SortByOption.OriginalTitleDesc:
                    return "original_title.desc";
                case DiscoverMoviesRequest.SortByOption.VoteAverageAsc:
                    return "vote_average.asc";
                case DiscoverMoviesRequest.SortByOption.VoteAverageDesc:
                    return "vote_average.desc";
                case DiscoverMoviesRequest.SortByOption.VoteCountAsc:
                    return "vote_count.asc";
                case DiscoverMoviesRequest.SortByOption.VoteCountDesc:
                    return "vote_count.desc";
                default:
                    throw new ArgumentOutOfRangeException(nameof(DiscoverMoviesRequest.SortByOption));
            }
        }
    }

}
