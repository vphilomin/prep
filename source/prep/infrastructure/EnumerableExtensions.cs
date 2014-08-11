using System;
using System.Collections.Generic;
using prep.matching;

namespace prep.infrastructure
{
  public static class EnumerableExtensions
  {
    public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
    {
      foreach (var item in items)
        yield return item;
    }

    static IEnumerable<T> filter<T>(this IEnumerable<T> items, Predicate<T> predicate)
    {
      foreach (var item in items)
      {
        if (predicate(item))
          yield return item;
      }
    }

    public static IEnumerable<T> filter<T>(this IEnumerable<T> items, IMatchA<T> specification)
    {
      return items.filter(specification.matches);
    }
  }
}