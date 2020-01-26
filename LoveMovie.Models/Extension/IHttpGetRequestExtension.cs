using LoveMovie.Models.Extension;
using System;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LoveMovie.Models.Extension
{
    public static class IHttpGetRequestExtension
    {
        public static string ToQueryString(this IHttpGetRequest request)
        {
            var propertiesToNameValue =
                request.GetType().GetProperties()
                .Where(p => p.GetValue(request, null) != null)
                .Select(p => propertyToNameValue(p))
                //ignored property will be null
                .Where(p => p != null)
                .ToList();

            return propertiesToNameValue.Any()
                ? "?" + string.Join("&", propertiesToNameValue)
                : null;

            string propertyToNameValue(PropertyInfo property)
            {
                var queryStringAttr = property.GetCustomAttribute<QueryStringPropertyAttribute>();

                if (queryStringAttr == null)
                    return property.Name + "=" + HttpUtility.UrlEncode(property.GetValue(request, null).ToString());

                if (queryStringAttr.Ignored)
                    return null;

                var propertyName = string.IsNullOrWhiteSpace(queryStringAttr.Name) ? property.Name : queryStringAttr.Name;

                string propertyValue;

                if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                {
                    propertyValue = ((DateTime)property.GetValue(request, null)).ToString(queryStringAttr.DateTimeFormat);
                }
                else if (property.PropertyType.IsEnum || property.PropertyType.IsNullableEnum())
                {
                    propertyValue = ((Enum)property.GetValue(request, null)).GetQueryStringValue();
                }
                else
                {
                    propertyValue = property.GetValue(request, null).ToString();
                }

                return propertyName + "=" + HttpUtility.UrlEncode(propertyValue);
            }
        }
    }
}
