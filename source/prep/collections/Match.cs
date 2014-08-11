using prep.matching;

namespace prep.collections
{
  public class Match<ItemToMatch>
  {
    public static MatchCreationExtensionPoint<ItemToMatch, AttributeType>
      with_attribute<AttributeType>(IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor)
    {
      return new MatchCreationExtensionPoint<ItemToMatch, AttributeType>(accessor);
    }
  }
}