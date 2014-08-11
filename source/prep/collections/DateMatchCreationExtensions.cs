using System;
using prep.matching;

namespace prep.collections
{
  public static class DateMatchCreationExtensions
  {
    public static IMatchA<ItemToMatch> greater_than<ItemToMatch>(
      this MatchCreationExtensionPoint<ItemToMatch, DateTime> extension_point, int year)
    {
      return extension_point.for_value_matcher(
        Match<DateTime>.with_attribute(x => x.Year).greater_than(year));
    }
  }
}