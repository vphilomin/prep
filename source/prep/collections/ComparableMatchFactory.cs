using System;
using prep.matching;
using prep.ranges;

namespace prep.collections
{
  public class ComparableMatchFactory<ItemToMatch, AttributeType>  : ICreateMatchers<ItemToMatch, AttributeType> 
    where AttributeType : IComparable<AttributeType>
  {
    ICreateMatchers<ItemToMatch, AttributeType> match_factory;

    public ComparableMatchFactory(ICreateMatchers<ItemToMatch, AttributeType> match_factory)
    {
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

    public IMatchA<ItemToMatch> falls_in(IContainValues<AttributeType> range)
    {
      return for_value_matcher(new FallsIn<AttributeType>(range));
    }

    public IMatchA<ItemToMatch> greater_than(AttributeType value)
    {
      return for_value_matcher(new GreaterThan<AttributeType>(value));
    }

    public IMatchA<ItemToMatch> less_than(AttributeType value)
    {
      return for_value_matcher(new LessThan<AttributeType>(value));
    }

    public IMatchA<ItemToMatch> between(AttributeType start, AttributeType end)
    {
      return (greater_than(start).or(equal_to(start))).and(less_than(end).or(equal_to(end)));
    }


    public IMatchA<ItemToMatch> for_condition(Predicate<ItemToMatch> condition)
    {
      return match_factory.for_condition(condition);
    }

    public IMatchA<ItemToMatch> for_value_matcher(IMatchA<AttributeType> value_condition)
    {
      return match_factory.for_value_matcher(value_condition);
    }
  }
}