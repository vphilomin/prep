using System;
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
      return new ConditionalSpecification<ItemToMatch>(x => accessor(x).Equals(value));
    }

    public IMatchA<ItemToMatch> equal_to_any(params AttributeType[] values)
    {
        var match = equal_to(values[0]);
        for (int i = 1; i < values.Length; i++)
        {
            match = new OrMatch<ItemToMatch>(match, equal_to(values[i]));
        }

        return match;
    }
  }
}