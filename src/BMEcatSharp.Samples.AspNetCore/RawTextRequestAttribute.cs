using System;

namespace BMEcatSharp.Samples.AspNetCore
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RawTextRequestAttribute : Attribute
    {
        public RawTextRequestAttribute()
        {
            MediaType = "text/plain";
        }

        public string MediaType { get; set; }
    }
}
