using System;

namespace prep.matching
{
  public class ConditionalSpecification<ItemToMatch> : IMatchA<ItemToMatch>
  {
    Predicate<ItemToMatch> predicate;

    public ConditionalSpecification(Predicate<ItemToMatch> predicate)
    {
      this.predicate = predicate;
    }

    public bool matches(ItemToMatch item)
    {
      return predicate(item);
    }
  }
}