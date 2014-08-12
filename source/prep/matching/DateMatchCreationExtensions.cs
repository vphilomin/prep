using System;
using prep.collections;

namespace prep.matching
{
  public static class DateMatchCreationExtensions
  {
    public static ReturnType greater_than<ItemToMatch, ReturnType>(
      this IProvideAccessToMatchCreationExtensions<ItemToMatch, DateTime, ReturnType> extension_point, int year)
    {
      return extension_point.for_value_matcher(
        Match<DateTime>.with_attribute(x => x.Year).greater_than(year));
    }
  }
}