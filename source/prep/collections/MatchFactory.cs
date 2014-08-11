using System;
using System.Collections.Generic;
using prep.matching;

namespace prep.collections
{
  public class MatchFactory<ItemToMatch, AttributeType>
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
      return new ConditionalSpecification<ItemToMatch>(x =>
      {
        var value = accessor(x);
        return new List<AttributeType>(values).Contains(value);
      });
    }

    public IMatchA<ItemToMatch> not_equal_to(AttributeType value)
    {
      throw new NotImplementedException();
    }
  }
}