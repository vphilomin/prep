using System;
using prep.matching;

namespace prep.collections
{
  public class ComparableMatchFactory<ItemToMatch, AttributeType> where AttributeType : IComparable<AttributeType>
  {
    IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor;
      MatchFactory<ItemToMatch, AttributeType> matchFactory;

      public ComparableMatchFactory(IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
          this.matchFactory = new MatchFactory<ItemToMatch, AttributeType>(accessor);
    }

    public IMatchA<ItemToMatch> greater_than(AttributeType value)
    {
      return new ConditionalMatch<ItemToMatch>(x => accessor(x).CompareTo(value) > 0);
    }

    public IMatchA<ItemToMatch> between(AttributeType start, AttributeType end)
    {
        return greater_than(start).and(less_than(end));
    }

      public IMatchA<ItemToMatch> less_than(AttributeType value)
      {
          return new ConditionalMatch<ItemToMatch>(x => accessor(x).CompareTo(value) < 0);
      }

      public IMatchA<ItemToMatch> equal_to(AttributeType value)
      {
          return matchFactory.equal_to(value);
      }

      public IMatchA<ItemToMatch> equal_to_any(params AttributeType[] values)
      {
          return matchFactory.equal_to_any(values);
      }

      public IMatchA<ItemToMatch> not_equal_to(AttributeType value)
      {
          return matchFactory.not_equal_to(value);
      }
  }

    
}