using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LoveMovie.Models
{
    public static class IHttpGetRequestExtension
    {
        public static string ToQueryString(this IHttpGetRequest obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return "?" + string.Join("&", properties.ToArray());
        }
    }
}
