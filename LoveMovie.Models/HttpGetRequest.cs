using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LoveMovie.Models
{
    public abstract class HttpGetRequest
    {
        public virtual string ToQueryString()
        {
            var properties = from p in GetType().GetProperties()
                             where p.GetValue(this, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(this, null).ToString());

            return properties.Any() ? "?" + string.Join("&", properties) : null;
        }
    }
}
