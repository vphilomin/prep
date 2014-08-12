namespace prep.matching_core
{
  public class Match<ItemToMatch>
  {
    public static MatchCreationExtensionPoint<ItemToMatch, AttributeType>
      with_attribute<AttributeType>(IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor)
    {
      return new MatchCreationExtensionPoint<ItemToMatch, AttributeType>(accessor);
    }

    public static ValueMatchCreationExtensionPoint<ItemToMatch> where
    {
      get { return new ValueMatchCreationExtensionPoint<ItemToMatch>(); }
    }
  }
}