using System;
using System.Text.RegularExpressions;

namespace HeroBot.Common.Helpers
{
    public static class TimeSpanHelper
    {
        private static Regex Regex { get; set; } = new Regex(@"[\s,]0[m,d,h,s]");
        public static string ToHumanReadable(this TimeSpan timeSpan)
        {
            return Regex.Replace(string.Format(" {0:%d}d {0:%h}h {0:%m}m {0:%s}s", timeSpan),string.Empty);
        }
    }
}
