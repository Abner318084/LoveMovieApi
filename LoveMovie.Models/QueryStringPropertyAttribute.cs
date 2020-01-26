using System;

namespace LoveMovie.Models
{
    public class QueryStringPropertyAttribute : Attribute
    {
        public string Name { get; set; }

        public bool Ignored { get; set; }

        public string DateTimeFormat { get; set; }
    }
}