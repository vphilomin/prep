using System;
using prep.matching;
using prep.ranges;

namespace prep.collections
{
  public static class MatchCreationExtensions
  {
    public static ReturnType equal_to<ItemToMatch, AttributeType, ReturnType>(this IProvideAccessToMatchCreationExtensions<ItemToMatch,AttributeType, ReturnType> extension_point, AttributeType value)
    {
      return extension_point.equal_to_any(value);
    }

    public static ReturnType equal_to_any<ItemToMatch, AttributeType, ReturnType>(this IProvideAccessToMatchCreationExtensions<ItemToMatch,AttributeType, ReturnType> extension_point, params AttributeType[] values)
    {
      return extension_point.for_value_matcher(new EqualAnyMatch<AttributeType>(values));
    }

    public static ReturnType for_value_matcher<ItemToMatch, AttributeType, ReturnType>(this IProvideAccessToMatchCreationExtensions<ItemToMatch,AttributeType, ReturnType> extension_point, IMatchA<AttributeType> value_condition)
    {
      return extension_point.create_dsl_result(value_condition);
    }

    public static ReturnType falls_in<ItemToMatch, AttributeType, ReturnType>(this IProvideAccessToMatchCreationExtensions<ItemToMatch,AttributeType, ReturnType> extension_point, IContainValues<AttributeType> range)
      where AttributeType : IComparable<AttributeType>
    {
      return extension_point.for_value_matcher(new FallsIn<AttributeType>(range));
    }

    public static ReturnType greater_than<ItemToMatch, AttributeType, ReturnType>(this IProvideAccessToMatchCreationExtensions<ItemToMatch,AttributeType, ReturnType> extension_point, AttributeType value)
      where AttributeType : IComparable<AttributeType>
    {
      return extension_point.for_value_matcher(new GreaterThan<AttributeType>(value));
    }

    public static ReturnType less_than<ItemToMatch, AttributeType, ReturnType>(this IProvideAccessToMatchCreationExtensions<ItemToMatch,AttributeType, ReturnType> extension_point, AttributeType value)
      where AttributeType : IComparable<AttributeType>
    {
      return extension_point.for_value_matcher(new LessThan<AttributeType>(value));
    }

    public static ReturnType between<ItemToMatch, AttributeType, ReturnType>(this IProvideAccessToMatchCreationExtensions<ItemToMatch,AttributeType, ReturnType> extension_point, AttributeType start, AttributeType end)
      where AttributeType : IComparable<AttributeType>
    {
      var match = new EqualAnyMatch<AttributeType>(start).or(new GreaterThan<AttributeType>(start)).and(
        new EqualAnyMatch<AttributeType>(end).or(new LessThan<AttributeType>(end)));

      return extension_point.for_value_matcher(match);
    }
  }
}
