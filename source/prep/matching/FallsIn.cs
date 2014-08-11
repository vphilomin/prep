using System;
using prep.ranges;

namespace prep.matching
{
  public class FallsIn<T> : IMatchA<T> where T : IComparable<T>
  {
    IContainValues<T> range;

    public FallsIn(IContainValues<T> range)
    {
      this.range = range;
    }

    public bool matches(T item)
    {
      return range.contains(item);
    }
  }
}