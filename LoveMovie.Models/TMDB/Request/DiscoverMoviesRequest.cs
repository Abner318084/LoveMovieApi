using System;
using System.ComponentModel.DataAnnotations;

namespace LoveMovie.Models.TMDB
{
    public class DiscoverMoviesRequest : IHttpGetRequest
    {
        [RegularExpression(@"([a-z]{2})-([A-Z]{2})")]
        [QueryStringProperty(Name = "language")]
        public string Language { get; set; }

        [Range(1, 1000)]
        [QueryStringProperty(Name = "page")]
        public int? Page { get; set; }

        [RegularExpression(@"^[A-Z]{2}$")]
        [QueryStringProperty(Name = "region")]
        public string Region { get; set; }

        [QueryStringProperty(Name = "sort_by")]
        public SortByOption? SortBy { get; set; }

        [QueryStringProperty(Name = "certification_country")]
        public string CertificationCountry { get; set; }

        [QueryStringProperty(Name = "certification")]
        public string Certification { get; set; }

        [QueryStringProperty(Name = "certification.lte")]
        public string CertificationLte { get; set; }

        [QueryStringProperty(Name = "certification.gte")]
        public string CertificationGte { get; set; }

        [QueryStringProperty(Name = "include_adult")]
        public bool? IncludeAdult { get; set; }

        [QueryStringProperty(Name = "include_video")]
        public bool? IncludeVideo { get; set; }

        [QueryStringProperty(Name = "primary_release_year")]
        public int? PrimaryReleaseYear { get; set; }

        [QueryStringProperty(Name = "primary_release_date.gte", DateTimeFormat = "yyyy-MM-dd")]
        public DateTime? PrimaryReleaseDateGte { get; set; }

        [QueryStringProperty(Name = "primary_release_date.lte", DateTimeFormat = "yyyy-MM-dd")]
        public DateTime? PrimaryReleaseDateLte { get; set; }

        [QueryStringProperty(Name = "release_date.gte", DateTimeFormat = "yyyy-MM-dd")]
        public DateTime? ReleaseDateGte { get; set; }

        [QueryStringProperty(Name = "release_date.lte", DateTimeFormat = "yyyy-MM-dd")]
        public DateTime? ReleaseDateLte { get; set; }

        [Range(1, 6)]
        [QueryStringProperty(Name = "with_release_type")]
        public short? WithReleaseType { get; set; }

        [QueryStringProperty(Name = "year")]
        public int? Year { get; set; }

        [Range(0, int.MaxValue)]
        [QueryStringProperty(Name = "vote_count.gte")]
        public int? VoteCountGte { get; set; }

        [Range(1, int.MaxValue)]
        [QueryStringProperty(Name = "vote_count.lte")]
        public int? VoteCountLte { get; set; }

        [Range(0, int.MaxValue)]
        [QueryStringProperty(Name = "vote_average.gte")]
        public int? VoteAverageGte { get; set; }

        [Range(0, int.MaxValue)]
        [QueryStringProperty(Name = "vote_average.lte")]
        public int? VoteAverageLte { get; set; }

        [QueryStringProperty(Name = "with_cast")]
        public string WithCast { get; set; }

        [QueryStringProperty(Name = "with_crew")]
        public string WithCrew { get; set; }

        [QueryStringProperty(Name = "with_people")]
        public string WithPeople { get; set; }

        [QueryStringProperty(Name = "with_companies")]
        public string WithCompanies { get; set; }

        [QueryStringProperty(Name = "with_genres")]
        public string WithGenres { get; set; }

        [QueryStringProperty(Name = "without_genres")]
        public string WithoutGenres { get; set; }

        [QueryStringProperty(Name = "with_keywords")]
        public string WithKeywords { get; set; }

        [QueryStringProperty(Name = "without_keywords")]
        public string WithoutKeywords { get; set; }

        [QueryStringProperty(Name = "with_runtime.gte")]
        public int? WithRuntimeGte { get; set; }

        [QueryStringProperty(Name = "with_runtime.lte")]
        public int? WithRuntimeLte { get; set; }

        [QueryStringProperty(Name = "with_original_language")]
        public string WithOriginalLanguage { get; set; }

        public enum SortByOption
        {
            [QueryStringvalue("popularity.asc")]
            PopularityAsc,
            [QueryStringvalue("popularity.desc")]
            PopularityDesc,
            [QueryStringvalue("release_date.asc")]
            ReleaseDateAsc,
            [QueryStringvalue("release_date.desc")]
            ReleaseDateDesc,
            [QueryStringvalue("revenue.asc")]
            RevenueAsc,
            [QueryStringvalue("revenue.desc")]
            RevenueDesc,
            [QueryStringvalue("primary_release_date.asc")]
            PrimaryReleaseDateAsc,
            [QueryStringvalue("primary_release_date.desc")]
            PrimaryReleaseDateDesc,
            [QueryStringvalue("original_title.asc")]
            OriginalTitleAsc,
            [QueryStringvalue("original_title.desc")]
            OriginalTitleDesc,
            [QueryStringvalue("vote_average.asc")]
            VoteAverageAsc,
            [QueryStringvalue("vote_average.desc")]
            VoteAverageDesc,
            [QueryStringvalue("vote_count.asc")]
            VoteCountAsc,
            [QueryStringvalue("vote_count.desc")]
            VoteCountDesc
        }
    }   
}
