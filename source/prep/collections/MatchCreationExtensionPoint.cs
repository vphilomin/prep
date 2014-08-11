using prep.matching;

namespace prep.collections
{
  public class MatchCreationExtensionPoint<ItemToMatch, AttributeType>
  {
    public IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor { get; set; }

    public MatchCreationExtensionPoint(IGetTheValueOfAnAttribute<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
    }

     
  }
}