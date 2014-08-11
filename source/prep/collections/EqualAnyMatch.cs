using System.Collections.Generic;
using prep.matching;

namespace prep.collections
{
  public class EqualAnyMatch<T> : IMatchA<T>
  {
    IList<T> values;

    public EqualAnyMatch(params T[] values)
    {
      this.values = new List<T>(values);
    }

    public bool matches(T item)
    {
      return values.Contains(item);
    }
  }
}