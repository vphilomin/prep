using System;
using prep.matching;

namespace prep.collections
{
  public class ComparableMatchFactory<ItemToMatch, AttributeType>  : ICreateMatchers<ItemToMatch, AttributeType> 
    where AttributeType : IComparable<AttributeType>
  {
    IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor;
    ICreateMatchers<ItemToMatch, AttributeType> match_factory;

    public ComparableMatchFactory(IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor,
      ICreateMatchers<ItemToMatch, AttributeType> match_factory)
    {
      this.accessor = accessor;
      this.match_factory = match_factory;
    }

    public IMatchA<ItemToMatch> equal_to(AttributeType value)
    {
      return match_factory.equal_to(value);
    }

    public IMatchA<ItemToMatch> equal_to_any(params AttributeType[] values)
    {
      return match_factory.equal_to_any(values);
    }

    public IMatchA<ItemToMatch> not_equal_to(AttributeType value)
    {
      return match_factory.not_equal_to(value);
    }

    public IMatchA<ItemToMatch> greater_than(AttributeType value)
    {
      return Match<ItemToMatch>.CreateConditionalMatch(x => accessor(x).CompareTo(value) > 0);
    }

    public IMatchA<ItemToMatch> between(AttributeType start, AttributeType end)
    {
      return (greater_than(start).or(equal_to(start))).and(less_than(end).or(equal_to(end)));
    }

    public IMatchA<ItemToMatch> less_than(AttributeType value)
    {
        return Match<ItemToMatch>.CreateConditionalMatch(x => accessor(x).CompareTo(value) < 0);
    }

  }
}