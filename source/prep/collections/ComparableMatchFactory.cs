using System;
using prep.matching;

namespace prep.collections
{
  public class ComparableMatchFactory<ItemToMatch, AttributeType> where AttributeType : IComparable<AttributeType>
  {
    IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor;

    public ComparableMatchFactory(IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<ItemToMatch> greater_than(AttributeType value)
    {
      throw new NotImplementedException();
    }
  }
}