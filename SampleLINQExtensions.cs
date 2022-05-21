using System;
using System.Collections.Generic;
using System.Linq;

namespace Namespace
{
    public static class SampleLINQExtensions
    {
        public static T Sample<T>(this IEnumerable<T> source)
        {
            var count = source.Count();
            if (count == 0)
            {
                throw new InvalidOperationException("Tried to get a sample from an empty list.");
            }
            return source.ElementAt(UnityEngine.Random.Range(0, count));
        }

        public static T SampleOrDefault<T>(this IEnumerable<T> source)
        {
            var count = source.Count();
            return source.ElementAtOrDefault(UnityEngine.Random.Range(0, count));
        }

        public static T SampleOrDefault<T>(this IEnumerable<T> source, T defaultValue)
        {
            var count = source.Count();
            if (count == 0)
            {
                return defaultValue;
            }
            return source.ElementAt(UnityEngine.Random.Range(0, count));
        }
    }
}
