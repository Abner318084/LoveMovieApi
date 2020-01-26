using System;
using System.Reflection;

namespace LoveMovie.Models.Extension
{
    public static class EnumExtension
    {
        public static string GetQueryStringValue(this Enum @enum)
        {
            var fieldInfo = @enum.GetType().GetField(@enum.ToString());
            var queryStringvalueAttr = fieldInfo.GetCustomAttribute<QueryStringvalueAttribute>();
            return queryStringvalueAttr != null
                ? queryStringvalueAttr.Value.ToString()
                : @enum.ToString();
        }
    }
}
