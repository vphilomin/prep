using System;
using prep.matching_core;
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

  public static class FallInExtensions
  {
    public static ReturnType falls_in<ItemToMatch, AttributeType, ReturnType>(
      this IProvideAccessToMatchCreationExtensions<ItemToMatch, AttributeType, ReturnType> extension_point,
      IContainValues<AttributeType> range)
      where AttributeType : IComparable<AttributeType>
    {
      return extension_point.create_dsl_result(new FallsIn<AttributeType>(range));
    }
  }
}