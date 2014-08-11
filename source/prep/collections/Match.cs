using System;
using prep.matching;

namespace prep.collections
{
  public class Match<ItemToMatch>
  {
    public static MatchFactory<ItemToMatch, AttributeType>
      with_attribute<AttributeType>(IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor)
    {
      return new MatchFactory<ItemToMatch, AttributeType>(accessor);
    }

    public static ComparableMatchFactory<ItemToMatch, AttributeType>
      with_comparable_attribute<AttributeType>(IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor) where AttributeType : IComparable<AttributeType>
    {
      return new ComparableMatchFactory<ItemToMatch, AttributeType>(accessor,
        with_attribute(accessor));
    }

      public static ConditionalMatch<ItemToMatch> CreateConditionalMatch(Predicate<ItemToMatch> predicate)
      {
          return new ConditionalMatch<ItemToMatch>(predicate);
      }
  }
}