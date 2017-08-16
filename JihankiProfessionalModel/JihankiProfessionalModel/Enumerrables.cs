using System;
using System.Collections.Generic;
using System.Linq;

namespace Cranberries.Util
{

    public static partial class TupleEnumerable
    {
        public static IEnumerable<(T item, int index)> Indexed<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            IEnumerable<(T item, int index)> impl()
            {
                var i = 0;
                foreach (var item in source)
                {
                    yield return (item, i);
                    ++i;
                }
            }

            return impl();
        }
    }

    public class Enumerables
    {
        public static IEnumerable<int> Random()
        {
            var engine = new Random();
            while (true) yield return engine.Next();
        }

        public static IEnumerable<int> Random(int maxVlaue)
        {
            var engine = new Random();
            while (true) yield return engine.Next(maxVlaue);
        }

        public static IEnumerable<int> Random(int minValue, int maxValue)
        {
            var engine = new Random();
            while (true) yield return engine.Next(minValue, maxValue);
        }

        public static IEnumerable<int> Random(Random engine)
        {
            while (true) yield return engine.Next();
        }

        public static IEnumerable<int> Random(Random engine, int maxValue)
        {
            while (true) yield return engine.Next(maxValue);
        }

        public static IEnumerable<int> Random(Random engine, int minValue, int maxValue)
        {
            while (true) yield return engine.Next(minValue, maxValue);
        }

        public static IEnumerable<double> GenerateCanonical()
        {
            var engine = new Random();
            while (true) yield return engine.NextDouble();
        }

    }
}
