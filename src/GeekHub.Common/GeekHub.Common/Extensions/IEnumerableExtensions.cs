using System.Collections.Generic;
using System.Linq;

namespace GeekHub.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || source.Any() == false;
        }
    }
}
