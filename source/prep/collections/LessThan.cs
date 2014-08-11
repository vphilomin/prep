using System;
using prep.matching;

namespace prep.collections
{
  public class LessThan<T> : IMatchA<T> where T : IComparable<T>
  {
    T start;

    public LessThan(T start)
    {
      this.start = start;
    }

    public bool matches(T item)
    {
      return item.CompareTo(start) < 0;
    }
  }

  public class GreaterThan<T> : IMatchA<T> where T : IComparable<T>
  {
    T start;

    public GreaterThan(T start)
    {
      this.start = start;
    }

    public bool matches(T item)
    {
      return item.CompareTo(start) > 0;
    }
  }
}