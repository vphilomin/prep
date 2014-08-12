using System;
using prep.matching_core;

namespace prep.matching
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

  public static class LessThanExtensions
  {
    public static ReturnType less_than<ItemToMatch, AttributeType, ReturnType>(
      this IProvideAccessToMatchCreationExtensions<ItemToMatch, AttributeType, ReturnType> extension_point,
      AttributeType value)
      where AttributeType : IComparable<AttributeType>
    {
      return extension_point.create_dsl_result(new LessThan<AttributeType>(value));
    }
  }
}