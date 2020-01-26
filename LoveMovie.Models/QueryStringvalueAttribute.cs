using System;

namespace LoveMovie.Models
{
    /// <summary>
    /// Query string value for enum
    /// </summary>
    public class QueryStringvalueAttribute : Attribute
    {
        public QueryStringvalueAttribute(object value) => this.Value = value;

        public object Value { get; set; }
    }
}