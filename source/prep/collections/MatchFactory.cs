using System;
using System.Collections.Generic;
using prep.matching;

namespace prep.collections
{
  public class MatchFactory<ItemToMatch, AttributeType> : ICreateMatchers<ItemToMatch, AttributeType>
  {
    IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor;

    public MatchFactory(IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<ItemToMatch> equal_to(AttributeType value)
    {
      return equal_to_any(value);
    }

    public IMatchA<ItemToMatch> equal_to_any(params AttributeType[] values)
    {
      return for_value_matcher(new EqualAnyMatch<AttributeType>(values));
    }

    public IMatchA<ItemToMatch> not_equal_to(AttributeType value)
    {
      return equal_to(value).not();
    }

    public IMatchA<ItemToMatch> for_value_matcher(IMatchA<AttributeType> value_condition)
    {
      return new AttributeMatch<ItemToMatch, AttributeType>(accessor, value_condition);
    }

    public IMatchA<ItemToMatch> for_condition(Predicate<ItemToMatch> condition)
    {
      return new ConditionalMatch<ItemToMatch>(condition);
    }
  }
}