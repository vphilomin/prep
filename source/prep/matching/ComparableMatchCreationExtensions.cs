using System;
using prep.matching_core;

namespace prep.matching
{
  public static class ComparableMatchCreationExtensions
  {
    public static ReturnType between<ItemToMatch, AttributeType, ReturnType>(
      this IProvideAccessToMatchCreationExtensions<ItemToMatch, AttributeType, ReturnType> extension_point,
      AttributeType start, AttributeType end)
      where AttributeType : IComparable<AttributeType>
    {
      var x = Match<AttributeType>.where;

      var start_match = x.equal_to(start).or(x.greater_than(start));
      var end_match = x.equal_to(end).or(x.less_than(end));
      var match = start_match.and(end_match);

      return extension_point.create_dsl_result(match);
    }
  }
}