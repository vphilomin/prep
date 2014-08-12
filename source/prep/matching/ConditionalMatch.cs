using System;
using prep.matching_core;

namespace prep.matching
{
  public class ConditionalMatch<ItemToMatch> : IMatchA<ItemToMatch>
  {
    Predicate<ItemToMatch> predicate;

    public ConditionalMatch(Predicate<ItemToMatch> predicate)
    {
      this.predicate = predicate;
    }

    public bool matches(ItemToMatch item)
    {
      return predicate(item);
    }
  }
}