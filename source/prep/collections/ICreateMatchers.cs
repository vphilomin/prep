using System;
using prep.matching;

namespace prep.collections
{
  public interface ICreateMatchers<ItemToMatch, AttributeType>
  {
    IMatchA<ItemToMatch> equal_to(AttributeType value);
    IMatchA<ItemToMatch> equal_to_any(params AttributeType[] values);
    IMatchA<ItemToMatch> not_equal_to(AttributeType value);
    IMatchA<ItemToMatch> for_condition(Predicate<ItemToMatch> condition);
    IMatchA<ItemToMatch> for_value_matcher(IMatchA<AttributeType> value_condition);
  }
}